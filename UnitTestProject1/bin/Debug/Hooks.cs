using BoDi;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using TechTalk.SpecFlow;
using System.Drawing;
using System.Windows.Forms;
using GhprSpecFlow.Common;

namespace UnitTestProject1
{
    [Binding]
    public class Hooks
    {
        private IObjectContainer _objectContainer;
        private IWebDriver _driver;        

        public Hooks(IObjectContainer objectContainer)
        {
            _objectContainer = objectContainer;

        }

        [BeforeScenario]
        public void Init()
        {
            _driver = new ChromeDriver();
           _objectContainer.RegisterInstanceAs<IWebDriver>(_driver);        
        }

        [AfterScenario]
        public void CloseBrowser()
        {
            _driver.Quit();
        }

        //[TearDown]
        //public void TakeScreenIfFailed()
        //{
        //    var res = TestContext.CurrentContext.Result.Outcome;
        //    if (res.Equals(ResultState.Failure) || res.Equals(ResultState.Error))
        //    {
        //        ScreenHelper.SaveScreenshot(TakeScreen());
        //    }
        //}

        public static byte[] TakeScreen()
        {
            var b = Screen.PrimaryScreen.Bounds;                        
            var ic = new ImageConverter();
            using (var btm = new Bitmap(b.Width, b.Height))
            using (var g = Graphics.FromImage(btm))
            {
                g.CopyFromScreen(b.X, b.Y, 0, 0, btm.Size, CopyPixelOperation.SourceCopy);
                return (byte[])ic.ConvertTo(btm, typeof(byte[]));
            }
        }

        [AfterStep(Order = 1)]
        public static void WrapUpReport()

        {
            if (TestContext.CurrentContext.Result.Outcome.Status == TestStatus.Failed || TestContext.CurrentContext.Result.Outcome.Status == TestStatus.Warning)
            {
                var bytes = TakeScreen();
                GhprPluginHelper.TestExecutionEngineHelper.ScreenHelper.SaveScreenshot(bytes);
            }
        }
    }
}
