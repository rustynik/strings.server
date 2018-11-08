using StringsServer.Contracts.Models;
using StringsServer.Contracts.Repository;
using System.Collections.Generic;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using System.Linq;
using StringsServer.Contracts;
using System;
using Newtonsoft.Json;

namespace StringsServer.Repository.FileSystem
{
    public class FileSystemRepository<T> : IRepository<T>
        where T : IHasId
    {
        private readonly string _filePath;

        private static readonly object _readLock = new object();
        private static readonly object _writeLock = new object();


        public FileSystemRepository(string file)
        {
            _filePath = file ?? throw new ArgumentNullException(nameof(file));
        }
        
        public async Task InsertAsync(T item)
        {
            await Task.Run(() => DoInsert(item));
        }

        public async Task<IEnumerable<T>> ReadAllAsync() 
            => await Task.Run(() => DoGetMessages());

        private void DoInsert(T item)
        {
            var items = DoGetMessages().ToList();
            if (items.All(x => x.Id != item.Id))
            {
                items.Add(item);
                lock (_writeLock)
                {
                    System.IO.File.WriteAllText(_filePath, JArray.FromObject(items).ToString());
                }
            }
        }
        
        private IEnumerable<T> DoGetMessages()
        {
            lock (_readLock)
            {
                if (!System.IO.File.Exists(_filePath)) return new T[0];
                var fileContent = System.IO.File.ReadAllText(_filePath);
                var items = JsonConvert.DeserializeObject<IEnumerable<T>>(fileContent);
                return items;
            }
        }
    }
}
