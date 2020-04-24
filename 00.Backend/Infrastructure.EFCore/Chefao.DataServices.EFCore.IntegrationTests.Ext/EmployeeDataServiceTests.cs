namespace Chefao.DataServices.EFCore.IntegrationTests.Ext
{
    using Chefao.EFCore.Setup;

    public class EmployeeDataServiceTests: EmployeeDataServiceBaseIntegrationTests
    {
        public EmployeeDataServiceTests():base (new EmployeeDataService(TestDbContextFactory.CreateDbContext()))
        {

        }

    }
}
