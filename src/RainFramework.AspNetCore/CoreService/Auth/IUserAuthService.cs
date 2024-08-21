using Microsoft.AspNetCore.JsonPatch;
using RainFramework.EFCore;
using RainFramework.Model.Entities;
using RainFramework.Model.VO;

namespace RainFramework.AspNetCore.CoreService.Auth
{
    public interface IUserAuthService : ICrudService<UserAuth>
    {
        Task<string> LoginService(UserVO userVO);

        IEnumerable<UserAuth> ListUsers();
        
        Task DeleteUserById(int id);
        
        Task PatchUserAuth(int id, JsonPatchDocument<UserAuth> patchDoc);
        
        Task UpadteRoleByUserId(int id, List<int> roleIds);
        
        Task<UserAuth> FindUserAuthIncludeInfoById(int id);

        /// <summary>
        /// 修改用户密码
        /// </summary>
        /// <param name="id"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        Task UpdatePasswordById(int id, string password);
    }
}