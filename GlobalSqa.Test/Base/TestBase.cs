using GlobalSqa.Framework.Enums;
using GlobalSqa.Framework.Selenium;
using GlobalSqa.Pages;
using NUnit.Framework;

namespace GlobalSqa.Test.Base
{
    public class TestBase
    {
        protected DragAndDropPage dragAndDropPage;
        protected DropDownMenuPage dropDownMenuPage;
        protected InteractionNavigator interactionNavigator;

        [OneTimeSetUp]
        public void BeforeAllTests()
        {
            Driver.Init(Browsers.Chrome);
            Driver.Maximize();

            dragAndDropPage = new DragAndDropPage();
            dropDownMenuPage = new DropDownMenuPage();
            interactionNavigator = new InteractionNavigator();

            Driver.Goto("http://www.globalsqa.com/demo-site/draganddrop/");
        }

        [SetUp]
        public void BeforeEachTest()
        {
 
        }

        [TearDown]
        public void AfterEachTest()
        {

        }

        [OneTimeTearDown]
        public void AfterAllTests()
        {
            Driver.CloseAndQuit();
        }
    }
}
