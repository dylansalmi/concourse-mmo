using Magenic.MaqsFramework.BaseSeleniumTest;
using Magenic.MaqsFramework.BaseSeleniumTest.Extensions;
using OpenQA.Selenium;

namespace PageModel.SubSite.Pages
{
    /// <summary>
    /// Page object for the login page
    /// </summary>
    public abstract class BaseSubSitePage
    {
        /// <summary>
        /// Element of type input. This is a field that requires user input.
        /// </summary>
        private FluentElement HomeNavigation
        {
            get { return new FluentElement(this.testObject, By.CssSelector("#Home"), "Home"); }
        }

        /// <summary>
        /// Element of type input. This is a field that requires user input.
        /// </summary>
        private FluentElement HowWorkNavigation
        {
            get { return new FluentElement(this.testObject, By.CssSelector("#HowWork"), "HowWork"); }
        }

        /// <summary>
        /// Element of type input. This is a field that requires user input.
        /// </summary>
        private FluentElement AsyncNavigation
        {
            get { return new FluentElement(this.testObject, By.CssSelector("#Async"), "Async"); }
        }

        /// <summary>
        /// Element of type input. This is a field that requires user input.
        /// </summary>
        private FluentElement AboutNavigation
        {
            get { return new FluentElement(this.testObject, By.CssSelector("#About"), "About"); }
        }

        /// <summary>
        /// Selenium test object
        /// </summary>
        protected SeleniumTestObject testObject;

        /// <summary>
        /// Initializes a new instance of the <see cref="Model1" /> class.
        /// </summary>
        /// <param name="webDriver">The selenium web driver</param>
        protected BaseSubSitePage(SeleniumTestObject testObject)
        {
            this.testObject = testObject;
        }

        /// <summary>
        /// Click the home navigation link
        /// </summary>
        /// <returns>The home page</returns>
        public HomePage ClickHomeNavigation()
        {
            HomeNavigation.Click();
            return new HomePage(this.testObject);
        }

        /// <summary>
        /// Click the how work navigation link
        /// </summary>
        /// <returns>The how work page</returns>
        public HowWorkPage ClickHowWorkNavigation()
        {
            HowWorkNavigation.Click();
            return new HowWorkPage(this.testObject);
        }

        /// <summary>
        /// Click the async navigation link
        /// </summary>
        /// <returns>The async page</returns>
        public AsyncPage ClickAsyncNavigation()
        {
            AsyncNavigation.Click();
            return new AsyncPage(this.testObject);
        }

        /// <summary>
        /// Click the about navigation link
        /// </summary>
        /// <returns>The about page</returns>
        public AboutPage ClickAboutNavigation()
        {
            AboutNavigation.Click();
            return new AboutPage(this.testObject);
        }

        /// <summary>
        /// Check if the page has been loaded
        /// </summary>
        /// <returns>True if the page was loaded</returns>
        public abstract bool IsPageLoaded();
    }
}
