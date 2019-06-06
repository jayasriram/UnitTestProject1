
using BoDi;
using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Threading;
using TechTalk.SpecFlow;

namespace UnitTestProject1
{
    [Binding]
    public class Feature1Steps 
    {
        //private readonly ScenarioContext scenarioContext;

        private IWebDriver _driver;
        public Feature1Steps(IWebDriver driver)
        {
            _driver = driver;
            
        }

        public Feature1Steps(IWebDriver driver, ScenarioContext scenarioContext)
        {
           _driver = driver;
            if (scenarioContext == null)
            {
                throw new ArgumentNullException("scenarioContext");
            }
            //else
            //{
            //    this.scenarioContext = scenarioContext;
            //}
        }

        [Given(@"I Navigate to the Google Home Page")]
        public void GivenINavigateToTheGoogleHomePage()
        {
            _driver.Navigate().GoToUrl("https://www.google.com/");
        }
        
        [When(@"I Search for '(.*)'")]
        public void WhenISearchFor(string p0)
        {
            Thread.Sleep(5000);
            _driver.FindElement(By.XPath("//input[@title='Search']")).SendKeys("Selenium");
        }
        
        [Then(@"the corresponding results are displayed")]
        public void ThenTheCorrespondingResultsAreDisplayed()
        {
            ScenarioContext.Current.Pending();
            
        }
        [Given(@"I navigate to craneware home page")]
        public void GivenINavigateToCranewareHomePage()
        {
            _driver.Navigate().GoToUrl("https://intranet.cw-data.local/");
        }

        [When(@"I hit the Profile Update Page")]
        public void WhenIHitTheProfileUpdatePage()
        {
            _driver.FindElement(By.XPath("//a[text()='Add information to your profile']")).Click();
        }

        [Then(@"the Edit details page is displayed")]
        public void ThenTheEditDetailsPageIsDisplayed()
        {
           bool title =  _driver.FindElement(By.Id("pageTitle")).Displayed;
            Assert.IsTrue(title,"title is not displayed");
        }

        [Then(@"the contact number is available")]
        public void ThenTheContactNumberIsAvailable()
        {
            bool contact = _driver.FindElement(By.XPath("//a[text()='Jaya Vasudevan']")).Displayed;
            Assert.IsTrue(contact, "title is not displayed");
        }

    }
}
