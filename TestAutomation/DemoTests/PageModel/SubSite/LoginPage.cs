//--------------------------------------------------
// <copyright file="LoginPageModel.cs" company="Magenic">
//  Copyright 2015 Magenic, All rights Reserved
// </copyright>
// <summary>Page object for the login page</summary>
//--------------------------------------------------
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using Magenic.MaqsFramework.BaseSeleniumTest;
using Magenic.MaqsFramework.Utilities;
using Magenic.MaqsFramework.Utilities.Helper;
using Magenic.MaqsFramework.BaseSeleniumTest.Extensions;
using PageModel.SubSite.Pages;

namespace PageModel.SubSite
{
    /// <summary>
    /// Page object for the login page
    /// </summary>
    public class LoginPage
    {
        /// <summary>
        /// The page url
        /// </summary>
        private static string PageUrl = Config.GetValue("WebSiteBase").Trim('/') + "/static/BasicSite/LoginPage.html";

        /// <summary>
        /// The user name input element 'By' finder
        /// </summary>
        public FluentElement UserName
        {
            get { return new FluentElement(this.testObject, By.CssSelector("#UserName"), "UserName"); }
        }

        /// <summary>
        /// The password input element 'By' finder
        /// </summary>
        public FluentElement Password
        {
            get { return new FluentElement(this.testObject, By.CssSelector("#Password"), "Password"); }
        }

        /// <summary>
        /// The login button element 'By' finder
        /// </summary>
        private static By loginButton = By.CssSelector("#Login");
        public FluentElement LoginButton
        {
            get { return new FluentElement(this.testObject, By.CssSelector("#Login"), "Login button"); }
        }

        /// <summary>
        /// The login error message element 'By' finder
        /// </summary>
        public FluentElement LoginError
        {
            get { return new FluentElement(this.testObject, By.CssSelector("#LoginError"), "LoginError"); }
        }

        /// <summary>
        /// Selenium test object
        /// </summary>
        protected SeleniumTestObject testObject;

        /// <summary>
        /// Initializes a new instance of the <see cref="Model1" /> class.
        /// </summary>
        /// <param name="webDriver">The selenium web driver</param>
        public LoginPage(SeleniumTestObject testObject)
        {
            this.testObject = testObject;
        }

        /// <summary>
        /// Open the login page
        /// </summary>
        public void OpenLoginPage()
        {
            // Open the gmail login page
            this.testObject.WebDriver.Navigate().GoToUrl(PageUrl);
        }

        /// <summary>
        /// Enter the use credentials
        /// </summary>
        /// <param name="userName">The user name</param>
        /// <param name="password">The user password</param>
        public void EnterCredentials(string userName, string password)
        {
            UserName.SendKeys(userName);
            Password.SendKeys(password);
        }

        /// <summary>
        /// Enter the use credentials and log in
        /// </summary>
        /// <param name="userName">The user name</param>
        /// <param name="password">The user password</param>
        public HomePage LoginWithValidCredentials(string userName, string password)
        {
            this.EnterCredentials(userName, password);
            LoginButton.Click();

            HomePage newPage = new HomePage(this.testObject);
            return newPage;
        }

        /// <summary>
        /// Enter the use credentials and try to log in - Verify login failed
        /// </summary>
        /// <param name="userName">The user name</param>
        /// <param name="password">The user password</param>
        public void LoginWithInvalidCredentials(string userName, string password)
        {
            this.EnterCredentials(userName, password);
            LoginButton.Click();
            LoginError.GetTheVisibleElement();
        }

        /// <summary>
        /// Verify we are on the login page
        /// </summary>
        public bool IsPageLoaded()
        {
            return this.testObject.WebDriver.Wait().UntilElementExist(Password.By);
        }
    }
}