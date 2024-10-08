﻿using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using RainFramework.AspNetCore.Base;
using RainFramework.AspNetCore.CoreService.Auth;
using RainFramework.AspNetCore.Model.VO;
using RainFramework.Model.Entities;
using RainFramework.Preconfigured.Configurer;
using static RainFramework.Common.Moudels.VO.HttpResult;

namespace RainFramework.AspNetCore.Controllers
{
    [Route("api/[controller]/")]
    [ApiExplorerSettings(GroupName = nameof(ApiGroup.BASICS))]
    public class UserInfoController : CrudControllerBase<UserInfo>
    {
        private IUserInfoService userInfoService;

        public UserInfoController(IUserInfoService userInfoService): base(userInfoService)
        {
            this.userInfoService = userInfoService;
        }

        /// <summary>
        /// 获取当前用户信息
        /// </summary>
        /// <returns></returns>
        [HttpGet("myself")]
        public async Task<ResultVO<UserInfoVO>> GetCurrentUserInfo()
        {
            var userInfo = await userInfoService.FindUserInfoByUserId(RequestUser.Id);
            return Success(userInfo);
        }

        /// <summary>
        /// 局部修改用户
        /// </summary>
        /// <param name="id"></param>
        /// <param name="patchDoc"></param>
        /// <returns></returns>
        [HttpPatch("{id}")]
        public async Task<ResultVO> UpdateUser(int id, [FromBody] JsonPatchDocument<UserInfo> patchDoc)
        {
            var userInfo = await userInfoService.GetOrThrowByIdAsync(id);
            patchDoc.ApplyTo(userInfo);
            await userInfoService.UpdatesAsync(userInfo);
            return Success();
        }
    }
}