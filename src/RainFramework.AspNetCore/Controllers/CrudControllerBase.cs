using Microsoft.AspNetCore.Mvc;
using RainFramework.Common.Base;
using RainFramework.Common.Moudel.VO;

namespace RainFramework.AspNetCore.Controllers
{
    public class CrudControllerBase<TEntity>: AuthControllerBase where TEntity : EntityBase 
    {
        private ICrudService<TEntity> crudService;

        public CrudControllerBase(ICrudService<TEntity> crudService)
        {
            this.crudService = crudService;
        }

        [HttpGet, Route("{Id}")]
        public async Task<ResultVO<TEntity>> FindAsync(int key)
        {
            var entity = await crudService.FindAsync(key);
            return ResultVO<TEntity>.Ok(entity);
        }
    }
}