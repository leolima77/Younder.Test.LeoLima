using Chefao.DataServices.EFCore.DataContext;

namespace Chefao.EFCore.Setup
{
    public static class TestDbContextFactory
    {
        public static AppDbContext CreateDbContext()
        {
            return new InMemoryDbContext(true);
        }
    }
}