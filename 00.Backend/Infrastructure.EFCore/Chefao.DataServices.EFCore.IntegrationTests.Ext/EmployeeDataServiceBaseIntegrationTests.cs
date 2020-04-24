using Chefao.DataServices.Interfaces;
using Chefao.Domains.Entities;
using Chefao.Test.Core.TestBases;

namespace Chefao.DataServices.EFCore.IntegrationTests.Ext
{
    public abstract class EmployeeDataServiceBaseIntegrationTests : DataServiceBaseIntegrationTests<Employee, int>
    {
        protected EmployeeDataServiceBaseIntegrationTests(IEmployeeDataService employeeDataService) :base (employeeDataService, x => x.Id)
        {

        }

    }
}
