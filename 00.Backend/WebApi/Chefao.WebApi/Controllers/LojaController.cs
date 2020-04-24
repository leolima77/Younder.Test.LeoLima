namespace Chefao.WebApi.Controllers
{
    using Chefao.Core.WebApi;
    using Domains.Entities;
    using DomainServices;
    using Microsoft.AspNetCore.Mvc;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public class LojaController : WebApiControllerBase<Loja, long>
    {
        protected LojaDomainService _lojaService;
        
        public LojaController(LojaDomainService lojaDomainService) : base(lojaDomainService)
        {
            _lojaService = lojaDomainService;
        }

        [HttpGet("list")]
        public async Task<IList<Loja>> List() => await _lojaService.ListAll();

        [HttpGet("getById/{idLoja}")]
        public async Task<Loja> GetById(long idLoja) => await _lojaService.GetById(idLoja);

        [HttpPost("insert")]
        public async Task<Loja> Insert([FromBody]Loja loja) => await _lojaService.Add(loja);

        [HttpPut("update/{idLoja}")]
        public async Task<Loja> Update(long idLoja,[FromBody] Loja loja) => await _lojaService.Update(idLoja, loja);
    }
}
