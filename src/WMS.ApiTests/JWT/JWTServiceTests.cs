
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WMS.Services.Core.Auth;

namespace WMS.ApiTests.JWT
{
    [TestClass()]
    public class JWTServiceTests
    {
        private IJWTService service = new JWTService();

        [TestMethod()]
        public void CreateTokenTest()
        {
            var ss = service.CreateToken(new List<System.Security.Claims.Claim>());
            Console.WriteLine(ss);
            Assert.IsNotNull(ss);
        }

        [TestMethod()]
        public void GeneralKeyTest()
        {
            var key1 = service.GeneralKey();
            var key2 = service.GeneralKey();
            Assert.AreNotEqual(key1, key2);
        }
    }
}