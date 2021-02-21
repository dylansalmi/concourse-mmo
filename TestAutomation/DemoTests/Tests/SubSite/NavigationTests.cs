//--------------------------------------------------
// <copyright file="NavigationTests.cs" company="Magenic">
//  Copyright 2016 Magenic, All rights Reserved
// </copyright>
// <summary>Sample Selenium test class</summary>
//--------------------------------------------------
using Magenic.MaqsFramework.Utilities.Helper;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PageModel.SubSite;
using PageModel.SubSite.Pages;

namespace Tests.SubSite
{
    /// <summary>
    /// Sample test class
    /// </summary>
    [TestClass]
    public class NavigationTests : BaseSelenium
    {
        private string userName = Config.GetValue("UserName");
        private string password = Config.GetValue("Password");

        /// <summary>
        /// Invalid login test
        /// </summary>
        [TestMethod]
        [TestCategory(TestCategories.Regression)]
    //    [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV",
    //@"|DataDirectory|\TestData\InvalidLogins.csv",
    //"InvalidLogins#csv",
    //DataAccessMethod.Sequential)]
        public void InvalidLoginTest()
        {
            // Remover data driving until MS fixes reporting bug
            //string userName = TestContext.DataRow["UserName"].ToString();
            //string password = TestContext.DataRow["Password"].ToString();

            string userName = "zed";
            string password = "fred";

            LoginPage login = new LoginPage(this.TestObject);
            login.OpenLoginPage();
            login.LoginWithInvalidCredentials(userName, password);
        }

        /// <summary>
        /// Sample test
        /// </summary>
        [TestMethod]
        [TestCategory(TestCategories.Regression)]
        public void NavigateToHowWork()
        {
            LoginPage login = new LoginPage(this.TestObject);
            login.OpenLoginPage();
            HomePage home = login.LoginWithValidCredentials(userName, password);
            Assert.IsTrue(home.ClickHowWorkNavigation().IsPageLoaded());
        }

        [TestMethod]
        [TestCategory(TestCategories.Regression)]
        public void NavigateToAsync()
        {
            LoginPage login = new LoginPage(this.TestObject);
            login.OpenLoginPage();
            HomePage home = login.LoginWithValidCredentials(userName, password);
            Assert.IsTrue(home.ClickAsyncNavigation().IsPageLoaded());
        }

        [TestMethod]
        [TestCategory(TestCategories.Regression)]
        public void NavigateToAbout()
        {
            LoginPage login = new LoginPage(this.TestObject);
            login.OpenLoginPage();
            HomePage home = login.LoginWithValidCredentials(userName, password);
            AsyncPage demo = home.ClickAsyncNavigation();
            Assert.IsTrue(demo.IsPageLoaded());
        }

        /// <summary>
        /// Navigation tests
        /// </summary>
        [TestMethod]
        [TestCategory(TestCategories.Regression)]
        public void ChainedNavigate()
        {
            LoginPage login = new LoginPage(this.TestObject);
            login.OpenLoginPage();
            HomePage home = login.LoginWithValidCredentials(userName, password);

            HowWorkPage howWorks = home.ClickHowWorkNavigation();
            Assert.IsTrue(howWorks.IsPageLoaded());

            AboutPage about = howWorks.ClickAboutNavigation();
            Assert.IsTrue(about.IsPageLoaded());

            AsyncPage async = about.ClickAsyncNavigation();
            Assert.IsTrue(async.IsPageLoaded());

            home = async.ClickHomeNavigation();
            Assert.IsTrue(home.IsPageLoaded());
        }
    }
}
