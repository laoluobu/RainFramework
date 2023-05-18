using Microsoft.AspNetCore.Mvc;
using RainFramework.AspNetCore.Base;
using RainFramework.AspNetCore.CoreService.Auth;
using RainFramework.Common.Configurer;
using RainFramework.Repository.Entity;

namespace RainFramework.AspNetCore.Controllers
{
    [ApiExplorerSettings(GroupName = nameof(ApiGroup.BASE))]
    public class RoleController : CrudControllerBase<Role>
    {
        private readonly IRoleService roleService;

        public RoleController(IRoleService roleService) : base(roleService)
        {
            this.roleService= roleService;
        }
    }
}
