using Magenic.MaqsFramework.BaseSeleniumTest;
using Magenic.MaqsFramework.BaseSeleniumTest.Extensions;
using Magenic.MaqsFramework.Utilities.Helper;
using OpenQA.Selenium;

namespace PageModel
{
    /// <summary>
    /// Page object for Base
    /// </summary>
    public abstract class BasePage
    {

        /// <summary>
        /// Selenium test object
        /// </summary>
        protected SeleniumTestObject testObject;

        /// <summary>
        /// Initializes a new instance of the <see cref="BasePage" /> class.
        /// </summary>
        /// <param name="testObject">The selenium test object</param>
        public BasePage(SeleniumTestObject testObject)
        {
            this.testObject = testObject;
        }

        /// <summary>
        /// Gets root site navigation
        /// </summary>
        private FluentElement SiteRootNavigation
        {
            get { return new FluentElement(this.testObject, By.CssSelector("#RootNav"), "RootNav"); }
        }

        /// <summary>
        /// Gets home navigation
        /// </summary>
        private FluentElement HomeNavigation
        {
            get { return new FluentElement(this.testObject, By.CssSelector("#Home"), "Home"); }
        }

        /// <summary>
        /// Gets about navigation
        /// </summary>
        private FluentElement AboutNavigation
        {
            get { return new FluentElement(this.testObject, By.CssSelector("#About"), "About"); }
        }

        /// <summary>
        /// Gets contact navigation
        /// </summary>
        private FluentElement ContactNavigation
        {
            get { return new FluentElement(this.testObject, By.CssSelector("#Contact"), "Contact"); }
        }

        public Home OpenSiteRootTab()
        {
            SiteRootNavigation.Click();
            return new Home(this.testObject);
        }

        public Home OpenHomeTab()
        {
            HomeNavigation.Click();
            return new Home(this.testObject);
        }

        public About OpenAboutTab()
        {
            AboutNavigation.Click();
            return new About(this.testObject);
        }

        public Contact OpenContactTab()
        {
            ContactNavigation.Click();
            return new Contact(this.testObject);
        }

        /// <summary>
        /// Check if the page has been loaded
        /// </summary>
        /// <returns>True if the page was loaded</returns>
        public abstract bool IsPageLoaded();
    }
}
