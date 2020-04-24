using Chefao.Core.DataService.EFCore;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Chefao.DataServices.EFCore
{
    using DataContext;
    using Domains.Entities;
    using Interfaces;

    public class LojaDataService : EntityDataService<Loja>, ILojaDataService
    {
        public LojaDataService(AppDbContext dbContext) : base(dbContext)
        {

        }

        public virtual async Task<IList<Loja>> ListAll()
        {
            return await DbContext.Set<Loja>().ToListAsync();
        }

    }
}