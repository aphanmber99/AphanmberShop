using System.Threading.Tasks;
using Shared.ViewModel;
using BackEnd.Models;
using BackEnd.Service;
using Xunit;
using BackEnd.Test;

namespace BackEnd.Test
{
    public class CategoryServiceTests : IClassFixture<SqliteInMemoryFixture>
    {
        private readonly SqliteInMemoryFixture _fixture;

        public CategoryServiceTests(SqliteInMemoryFixture fixture)
        {
            _fixture = fixture;
            _fixture.CreateDatabase();
        }

        [Fact]
        public async Task GetCate_Success()
        {
            // get MOCK
            var mapper = MapperMock.Get();
            // initial mock data
            var dbContext = _fixture.Context;
            var category = new Category {ID=1, Name = "Product Category"};
            dbContext.Categories.Add(category);
            await dbContext.SaveChangesAsync();
            // create dependency
            var cateSer = new CategoryService(dbContext, mapper);
            // test
            var result = await cateSer.GetAsync(1);
            Assert.NotNull(result);
        }
    }
}