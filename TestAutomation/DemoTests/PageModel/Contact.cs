using System;
using Magenic.MaqsFramework.BaseSeleniumTest;
using Magenic.MaqsFramework.BaseSeleniumTest.Extensions;
using Magenic.MaqsFramework.Utilities.Helper;
using OpenQA.Selenium;

namespace PageModel
{
    /// <summary>
    /// Page object for the Contact page
    /// </summary>
    public class Contact : BasePage
    {
        /// <summary>
        /// The page url
        /// </summary>
        private static readonly string PageUrl = Config.GetValue("WebSiteBase").Trim('/') + "/Home/Contact";

        /// <summary>
        /// Initializes a new instance of the <see cref="Contact" /> class.
        /// </summary>
        /// <param name="testObject">The selenium test object</param>
        public Contact(SeleniumTestObject testObject):base(testObject)
        {
        }

        /// <summary>
        /// Gets physical address
        /// </summary>
        public FluentElement PhysicalAddress
        {
            get { return new FluentElement(this.testObject, By.CssSelector("#PhysicalAddress"), "Physical Address"); }
        }

        /// <summary>
        /// Gets company name
        /// </summary>
        public FluentElement CompanyName
        {
            get { return new FluentElement(this.testObject, By.CssSelector("#companyName"), "Company Name"); }
        }

        /// <summary>
        /// Gets email contact
        /// </summary>
        public FluentElement EmailContact
        {
            get { return new FluentElement(this.testObject, By.CssSelector("#EmailContact"), "Email Contact"); }
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

