using System;
using Magenic.MaqsFramework.BaseSeleniumTest;
using Magenic.MaqsFramework.Utilities;
using Magenic.MaqsFramework.Utilities.Helper;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using Magenic.MaqsFramework.BaseSeleniumTest.Extensions;

namespace PageModel.SubSite.Pages
{
    /// <summary>
    /// Page object for the login page
    /// </summary>
    public class HomePage : BaseSubSitePage
    {
        /// <summary>
        /// The page url
        /// </summary>
        private static string PageUrl = Config.GetValue("WebSiteBase").Trim('/') + "/static/BasicSite/HomePage.html";

        /// <summary>
        /// Sample element 'By' finder
        /// </summary>
        public FluentElement WelcomeMessage
        {
            get { return new FluentElement(this.testObject, By.CssSelector("#WelcomeMessage"), "WelcomeMessage"); }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Model1" /> class.
        /// </summary>
        /// <param name="webDriver">The selenium web driver</param>
        public HomePage(SeleniumTestObject testObject)
            : base(testObject)
        {
        }

        public override bool IsPageLoaded()
        {
            return this.testObject.WebDriver.Wait().UntilElementExist(WelcomeMessage.By);
        }
    }
}
