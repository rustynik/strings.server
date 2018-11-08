using StringsServer.Contracts;
using System;
using Xunit;
using System.IO;
using System.Threading.Tasks;
using System.Linq;

namespace FileSystemRepository.Tests
{
    
    public class FileSystemRepository_WhenWriting : FileSystemRepositoryTestBase
    {
        public FileSystemRepository_WhenWriting() : base()
        { }
        
        [Fact]
        public async Task CreatesFileIfItDoesNotExist()
        {
            Assert.False(File.Exists(_filePath));
            await _repo.InsertAsync(new TestClass(Guid.NewGuid()));
            Assert.True(File.Exists(_filePath));
        }

        [Fact]
        public async Task AppendsFirstRecord()
        {
            var first = Guid.NewGuid();

            await _repo.InsertAsync(new TestClass(first));
            var records = await _repo.ReadAllAsync();

            Assert.NotNull(records.SingleOrDefault(x => x.Id == first));
        }

        [Fact]
        public async Task AppendsSecondRecord()
        {
            var first = Guid.NewGuid();
            var second = Guid.NewGuid();
            await _repo.InsertAsync(new TestClass(first));
            await _repo.InsertAsync(new TestClass(second));
            var records = (await _repo.ReadAllAsync()).ToArray();

            Assert.Equal(2, records.Length);
            Assert.Equal(second, records.Last().Id);
        }

        [Fact]
        public async Task IgnoresDuplicates()
        {
            var first = Guid.NewGuid();
            var second = first;
            await _repo.InsertAsync(new TestClass(first));
            await _repo.InsertAsync(new TestClass(second));
            var records = (await _repo.ReadAllAsync()).ToArray();

            Assert.Single(records);
        }

        public void Dispose()
        {
            if (File.Exists(_filePath)) File.Delete(_filePath);
        }
    }

    public class TestClass : IHasId
    {
        public TestClass(Guid id)
        {
            Id = id;
        }
        public Guid Id { get; internal set; }
    }
}
