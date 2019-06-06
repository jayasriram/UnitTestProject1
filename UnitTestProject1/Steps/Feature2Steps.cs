using NUnit.Framework;
using OpenQA.Selenium;
using System.Threading;
using TechTalk.SpecFlow;

namespace UnitTestProject1
{
    [Binding]
    public class Feature2Steps
    {
        private IWebDriver _driver;
        public Feature2Steps(IWebDriver driver)
        {
            _driver = driver;
        }

        [Given(@"I am in the Google Home Page")]
        public void GivenIAmInTheGoogleHomePage()
        {
            _driver.Navigate().GoToUrl("https://www.google.com/");
            _driver.Manage().Window.Maximize();
        }
        
        [When(@"I Search for the '(.*)' text")]
        public void WhenISearchForTheText(string p0)
        {
            
            _driver.FindElement(By.XPath("//input[@title='Search']")).SendKeys("Specflow");
           // Assert.IsFalse(_driver.FindElement(By.XPath("//input[@title='Search']")).Displayed,
           //   "Search bar is displayed");
        }
        
        [Then(@"the results are displayed")]
        public void ThenTheResultsAreDisplayed()
        {
            Assert.IsEmpty(_driver.FindElement(By.XPath("//input[@title='Search']")).Text,"Value is null");
        }

        
    }
}
