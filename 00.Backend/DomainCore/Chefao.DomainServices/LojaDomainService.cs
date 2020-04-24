using System.Collections.Generic;
using System.Threading.Tasks;
namespace Chefao.DomainServices
{
    using Core.DomainService;
    using DataServices.Interfaces;
    using Domains.Entities;
    using System;

    public class LojaDomainService : DomainService<Loja, long>
    {
        private readonly ILojaDataService _lojaDataService;

        public LojaDomainService(ILojaDataService lojaDataService) : base(lojaDataService)
        {
            _lojaDataService = lojaDataService;
        }

        public virtual async Task<IList<Loja>> ListAll()
        {
            return await _lojaDataService.ListAll();
        }

        public virtual async Task<IList<Loja>> List(System.Linq.Expressions.Expression<Func<Loja, bool>> predicated)
        {
            return await _lojaDataService.List(predicated);
        }
    }
}