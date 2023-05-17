using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RainFramework.AspNetCore.Core.Auth;

namespace Demo.ApiTests
{
    [TestClass()]
    public class ProgramTests
    {
        private IMenuService? MenuService { get; set; }

        public ProgramTests(IServiceProvider serviceProvider)
        {
            MenuService = serviceProvider.GetService<IMenuService>();
        }

        [TestMethod()]
        public void MainTest()
        {
            Console.WriteLine(MenuService);
            Assert.Fail();
        }
    }
}