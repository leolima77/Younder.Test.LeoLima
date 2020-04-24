
namespace Chefao.DataServices.EFCore.IntegrationTests
{
    using Chefao.EFCore.Setup;
    using Domains.Entities;
    using Test.Core.TestBases;

    public class EmployeeDataServiceTests: DataServiceBaseIntegrationTests<Employee, int>
    {
        public EmployeeDataServiceTests():base (new EmployeeDataService(TestDbContextFactory.CreateDbContext()), x => x.Id)
        {

        }

    }
}
