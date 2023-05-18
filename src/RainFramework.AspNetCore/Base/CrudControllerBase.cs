using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RainFramework.Common.Base;
using RainFramework.Common.Moudel.VO;
using static RainFramework.Common.Moudel.VO.ResultTool;

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
        /// <param name="id">主键</param>
        /// <returns></returns>
        [HttpGet, Route("{id}")]
        public async Task<ResultVO<TEntity>> FindAsync(int id)
        {
            var entity = await crudService.FindAsync(id);
            return ResultTool.Success(entity);
        }

        /// <summary>
        /// 获取所有实体
        /// </summary>
        /// <returns></returns>
        [HttpGet, Route("all")]
        public async Task<ResultVO<IEnumerable<TEntity?>>> FindAllAsync()
        {
            var entity = await crudService.FindAll();
            return ResultTool.Success(entity);
        }

        /// <summary>
        /// 添加实体
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public async Task<ResultVO> Add(TEntity entity)
        {
            return await crudService.AddAsync(entity) ? Success() : Fail($"Add {entity.GetType().Name} Errr.");
        }

        /// <summary>
        /// 删除实体
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        [HttpDelete, Authorize(Roles = "Administrator")]
        public async Task<ResultVO> Delete(TEntity entity)
        {
            return await crudService.RemoveAsync(entity) ? Success() : Fail($"Delete {entity.GetType().Name} Errr.");
        }

        /// <summary>
        /// 修改整个实体
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        [HttpPut, Authorize(Roles = "Administrator")]
        public async Task<ResultVO> Update(TEntity entity)
        {
            return await crudService.UpdatesAsync(entity) ? Success() : Fail($"Delete {entity.GetType().Name} Errr.");
        }
    }
}