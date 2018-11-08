using StringsServer.Contracts.Repository;
using StringsServer.Repository.FileSystem;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace FileSystemRepository.Tests
{
    public abstract class FileSystemRepositoryTestBase : IDisposable
    {
        protected readonly string _filePath;
        protected readonly IRepository<TestClass> _repo;

        public FileSystemRepositoryTestBase()
        {
            _filePath = "records.json";
            _repo = new FileSystemRepository<TestClass>(_filePath);

            Cleanup();
        }

        public void Dispose()
        {
            Cleanup();
        }

        private void Cleanup()
        {
            if (File.Exists(_filePath)) File.Delete(_filePath);
        }
    }
}
