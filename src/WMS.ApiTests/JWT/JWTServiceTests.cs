using WMS.Api.JWT;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace WMS.Api.JWT.Tests
{
    [TestClass()]
    public class JWTServiceTests
    {
        private IJWTService service = new JWTService();

        [TestMethod()]
        public void CreateTokenTest()
        {  
            var ss = service.CreateToken("222");
            Console.WriteLine(ss);
            Assert.IsNotNull(ss);
        }

        [TestMethod()]
        public void GeneralKeyTest()
        {
            var key1=service.GeneralKey();
            var key2=service.GeneralKey();
            Assert.AreNotEqual(key1, key2);
        }
    }
}