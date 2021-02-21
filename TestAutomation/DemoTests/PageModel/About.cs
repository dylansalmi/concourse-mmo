using System;
using Magenic.MaqsFramework.BaseSeleniumTest;
using Magenic.MaqsFramework.BaseSeleniumTest.Extensions;
using Magenic.MaqsFramework.Utilities.Helper;
using OpenQA.Selenium;

namespace PageModel
{
    /// <summary>
    /// Page object for the HomePageModel page
    /// </summary>
    public class About : BasePage
    {
        /// <summary>
        /// The page url
        /// </summary>
        private static readonly string PageUrl = Config.GetValue("WebSiteBase").Trim('/') + "/Home/About";

        /// <summary>
        /// Initializes a new instance of the <see cref="HomePageModel" /> class.
        /// </summary>
        /// <param name="testObject">The selenium test object</param>
        public About(SeleniumTestObject testObject): base(testObject)
        {
        }

        /// <summary>
        /// Check if the home page has been loaded
        /// </summary>
        /// <returns>True if the page was loaded</returns>
        public override bool IsPageLoaded()
        {
            return this.testObject.WebDriver.Url.Trim('/').Equals(PageUrl.Trim('/'), StringComparison.CurrentCultureIgnoreCase);
        }
    }
}

