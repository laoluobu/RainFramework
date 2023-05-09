using Microsoft.AspNetCore.Mvc;

namespace WMS.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class aaaaController:ControllerBase
    {
        /// <summary>
        /// ssssssssssssss
        /// </summary>
        /// <param name="ss"></param>
        /// <returns></returns>
        [HttpGet]
        public string sss(string ss)
        {
            return ss;
        }
    }
}
