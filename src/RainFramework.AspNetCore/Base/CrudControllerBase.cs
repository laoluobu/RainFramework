using Microsoft.AspNetCore.Mvc;
using RainFramework.Common.Base;
using RainFramework.Common.Moudel.VO;

namespace RainFramework.AspNetCore.Base
{
    [Route("api/[controller]")]
    public class CrudControllerBase<TEntity> : AuthControllerBase where TEntity : EntityBase
    {
        private ICrudService<TEntity> crudService;

        public CrudControllerBase(ICrudService<TEntity> crudService)
        {
            this.crudService = crudService;
        }
        /// <summary>
        /// 根据主键获取实体
        /// </summary>
        /// <param name="key">主键</param>
        /// <returns></returns>
        [HttpGet, Route("{Id}")]
        public async Task<ResultVO<TEntity>> FindAsync(int key)
        {
            var entity = await crudService.FindAsync(key);
            return ResultVO<TEntity>.Ok(entity);
        }

        /// <summary>
        /// 获取所有实体
        /// </summary>
        /// <returns></returns>
        [HttpGet, Route("All")]
        public async Task<ResultVO<IEnumerable<TEntity>>> FindAllAsync()
        {
            var entity = await crudService.FindAll();
            return ResultVO<IEnumerable<TEntity>>.Ok(entity);
        }

        /// <summary>
        /// 获取所有实体
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public async Task<ResultVO<IEnumerable<TEntity>>> FindAllAsync()
        {
            var entity = await crudService.FindAll();
            return ResultVO<IEnumerable<TEntity>>.Ok(entity);
        }
    }
}