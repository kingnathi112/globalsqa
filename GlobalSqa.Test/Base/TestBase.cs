using GlobalSqa.Framework;
using GlobalSqa.Framework.Enums;
using GlobalSqa.Framework.Selenium;
using GlobalSqa.Pages;
using GlobalSqa.Test.Helpers;
using NUnit.Framework;
using NUnit.Framework.Interfaces;

namespace GlobalSqa.Test.Base
{
    public class TestBase
    {
        protected DragAndDropPage dragAndDropPage;
        protected DropDownMenuPage dropDownMenuPage;
        protected InteractionNavigator interactionNavigator;
        protected Navigator navigator;
        protected SamplePage samplePage;

        [OneTimeSetUp]
        public void BeforeAllTests()
        {
            GlobalSqaFW.CreateTestResultsDirectory();

            Driver.Init(Browsers.Chrome);
            Driver.Maximize();

            dragAndDropPage = new DragAndDropPage();
            dropDownMenuPage = new DropDownMenuPage();
            interactionNavigator = new InteractionNavigator();
            navigator = new Navigator();
            samplePage = new SamplePage();

            Driver.Goto("http://www.globalsqa.com/demo-site/draganddrop/");
        }

        [SetUp]
        public void BeforeEachTest()
        {
            GlobalSqaFW.SetReporter(TestContext.CurrentContext.Test.Name.ToFriendlyName(), TestContext.CurrentContext.Test.ID);
        }

        [TearDown]
        public void AfterEachTest()
        {
            var outcome = TestContext.CurrentContext.Result.Outcome.Status;

            if (outcome == TestStatus.Passed)
            {
                GlobalSqaFW.Report.Info("Outcome: Passed");
                string screenshot = Driver.TakeScreenshot(TestContext.CurrentContext.Test.Name.ToFriendlyName());
                GlobalSqaFW.Report.Screenshot(screenshot);
            }
            else if (outcome == TestStatus.Failed)
            {
                GlobalSqaFW.Report.Info("Outcome: Failed");
                string screenshot = Driver.TakeScreenshot(TestContext.CurrentContext.Test.Name.ToFriendlyName());
                GlobalSqaFW.Report.Screenshot(screenshot);
            }
            else
            {
                GlobalSqaFW.Report.Fatal("Outcome: Fatal");
                string screenshot = Driver.TakeScreenshot(TestContext.CurrentContext.Test.Name.ToFriendlyName());
                GlobalSqaFW.Report.Screenshot(screenshot);
            }
        }

        [OneTimeTearDown]
        public void AfterAllTests()
        {
            Driver.CloseAndQuit();
        }
    }
}
