using Microsoft.VisualStudio.TestTools.UnitTesting;
using WebSitePOM;
using WebSitePOM.POM;

namespace Tests
{
    [TestClass]
    public class LoginTests
    {
        [TestMethod]
        public void Can_Login_With_Valid_Credentials()
        {
            Pages.LoginPage.Goto();
            Pages.LoginPage.Login("mr@bobbins.com", "password");
            Assert.IsTrue(Pages.HomePage.IsAt());
            Pages.HomePage.SignOut();
        }

        [TestCleanup]
        public void CleanUp()
        {
            Browser.Close();
        }
    }
    
}
