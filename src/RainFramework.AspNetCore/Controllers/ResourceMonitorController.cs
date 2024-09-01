using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Diagnostics.ResourceMonitoring;
using RainFramework.Preconfigured.Configurer;
using static RainFramework.Common.Moudels.VO.HttpResult;

namespace RainFramework.AspNetCore.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [ApiExplorerSettings(GroupName = nameof(ApiGroup.BASICS))]
    public class ResourceMonitorController:ControllerBase
    {
        private readonly IResourceMonitor monitor;

        public ResourceMonitorController(IResourceMonitor monitor)
        {
            this.monitor = monitor;
        }

        [HttpGet]
        public ResultVO Get()
        {
            return Success(monitor.GetUtilization(TimeSpan.FromSeconds(3)));
        }
    }
}
