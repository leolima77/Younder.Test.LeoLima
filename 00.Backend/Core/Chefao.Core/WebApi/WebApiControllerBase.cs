using System.Collections.Generic;
using System.Threading.Tasks;
using Chefao.Core.DomainService;
using Microsoft.AspNetCore.Mvc;

namespace Chefao.Core.WebApi
{
    [Route("api/[controller]")]
    public abstract class WebApiControllerBase<TDomain,TId>: Controller
        where TDomain : class, new()
    { 
        protected DomainService<TDomain,TId> DomainService;
        protected WebApiControllerBase(DomainService<TDomain, TId> domainService)
        {
            DomainService = domainService;
        }

        [ApiExplorerSettings(IgnoreApi = true)]
        [HttpGet("getAll")]
        public virtual async Task<IEnumerable<TDomain>> GetAll()
        {
            return await DomainService.GetAll();
        }

        [ApiExplorerSettings(IgnoreApi = true)]
        [HttpGet("get/{slug}")]
        public virtual async Task<TDomain> Get(TId slug)
        {
            return await DomainService.GetById(slug);
        }

        [ApiExplorerSettings(IgnoreApi = true)]
        [HttpPost("post")]
        public virtual async Task Post(TDomain domain)
        {
            await DomainService.Add(domain);
        }

        [ApiExplorerSettings(IgnoreApi = true)]
        [HttpPut("put/{slug}")]
        public virtual async Task Put(TId slug, TDomain domain)
        {
            await DomainService.Update(slug, domain);
        }

        [ApiExplorerSettings(IgnoreApi = true)]
        [HttpDelete("delete/{slug}")]
        public virtual async Task Delete(TId slug)
        {
            await DomainService.Delete(slug);
        }
    }
}
