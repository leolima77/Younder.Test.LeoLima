using System.Collections.Generic;
using Chefao.Core.DataService;
using System.Threading.Tasks;
using Chefao.Domains.Entities;

namespace Chefao.DataServices.Interfaces
{
    public interface ILojaDataService: IEntityDataService<Loja>
    {
        Task<IList<Loja>> ListAll();
    }
}