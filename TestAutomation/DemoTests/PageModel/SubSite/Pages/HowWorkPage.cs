using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using Magenic.MaqsFramework.BaseSeleniumTest;
using Magenic.MaqsFramework.Utilities;
using Magenic.MaqsFramework.Utilities.Helper;
using Magenic.MaqsFramework.BaseSeleniumTest.Extensions;

namespace PageModel.SubSite.Pages
{
    /// <summary>
    /// Page object for the login page
    /// </summary>
    public class HowWorkPage : BaseSubSitePage
    {
        /// <summary>
        /// The page url
        /// </summary>
        private static string PageUrl = Config.GetValue("WebSiteBase").Trim('/') + "/static/BasicSite/HowWork.html";

        /// <summary>
        /// Sample element 'By' finder
        /// </summary>
        public FluentElement HowWorks
        {
            get { return new FluentElement(this.testObject, By.CssSelector("#HowWorks"), "HowWorks"); }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Model1" /> class.
        /// </summary>
        /// <param name="webDriver">The selenium web driver</param>
        public HowWorkPage(SeleniumTestObject testObject)
            : base(testObject)
        {
        }

        /// <summary>
        /// Verify we are on the  page
        /// </summary>
        public override bool IsPageLoaded()
        {
            return this.testObject.WebDriver.Wait().UntilElementExist(HowWorks.By);
        }
    }
}
