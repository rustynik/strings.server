using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace FileSystemRepository.Tests
{
    public class FileSystemRepository_WhenReading : FileSystemRepositoryTestBase
    {
        public FileSystemRepository_WhenReading() : base()
        { }

        [Fact]
        public async Task ReturnsRecordArray()
        {
            var guid = Guid.Parse("88BACA59-3D58-4FCF-A278-7C2B3D2D94A6");
            var content = $"[{{ \"Id\": \"{ guid }\" }}]";
            File.WriteAllText(_filePath, content);
            var items = await _repo.ReadAllAsync();
            Assert.Single(items);
            Assert.Equal(guid, items.First().Id);
        }

        [Fact]
        public async Task ReturnsEmptyArrayIfFileDoesNotExist()
        {
            var items = await _repo.ReadAllAsync();
            Assert.NotNull(items);
            Assert.Empty(items);
        }
    }
}
