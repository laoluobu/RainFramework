using Microsoft.AspNetCore.JsonPatch;
using RainFramework.Common.Base;
using RainFramework.Common.Moudel.VO;
using RainFramework.Repository.Entity;

namespace RainFramework.AspNetCore.CoreService.Auth
{
    public interface IUserAuthService : ICrudService<UserAuth>
    {
        Task<string> LoginService(UserVO userVO);
        IEnumerable<UserAuth> ListUsers();
        Task DeleteUserById(int userId);
        Task PatchUserAuth(int userId, JsonPatchDocument<UserAuth> patchDoc);
        Task UpadteRoleByUserId(int userId, List<int> roleIds);
    }
}