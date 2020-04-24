using Chefao.DataServices.EFCore;
using Chefao.Domains.Entities;
using Chefao.EFCore.Setup;
using Chefao.Test.Core.TestBases;

namespace Chefao.DomainServices.ComponentTests.EFCore
{
    public class LojaDomainServiceComponentTests : DomainServiceBaseComponentTests<Loja, long>
    {
        public LojaDomainServiceComponentTests() :
            base(new LojaDomainService(Factory_DataService()), x => x.IdLoja)
        {
            
        }

        static LojaDataService Factory_DataService()
        {
            LojaDataService lojaDataService = new LojaDataService(TestDbContextFactory.CreateDbContext());

            return lojaDataService;
        }
    }
}
