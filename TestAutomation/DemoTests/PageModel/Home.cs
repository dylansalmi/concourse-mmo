using Magenic.MaqsFramework.BaseSeleniumTest;
using Magenic.MaqsFramework.BaseSeleniumTest.Extensions;
using Magenic.MaqsFramework.Utilities.Helper;
using OpenQA.Selenium;
using System;

namespace PageModel
{
    /// <summary>
    /// Page object for the HomePageModel page
    /// </summary>
    public class Home : BasePage
    {
        /// <summary>
        /// The page url
        /// </summary>
        private static readonly string PageUrl = Config.GetValue("WebSiteBase").Trim('/');

        /// <summary>
        /// Initializes a new instance of the <see cref="Contact" /> class.
        /// </summary>
        /// <param name="testObject">The selenium test object</param>
        public Home(SeleniumTestObject testObject):base(testObject)
        {
        }

        public void OpenPage()
        {
            this.testObject.WebDriver.Navigate().GoToUrl(PageUrl);
        }

        /// <summary>
        /// Gets how to section
        /// </summary>
        private FluentElement HowToSection
        {
            get { return new FluentElement(this.testObject, By.CssSelector("#HowTo"), "How to section"); }
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

