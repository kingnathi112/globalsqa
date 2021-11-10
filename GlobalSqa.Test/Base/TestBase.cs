using NUnit.Framework;

namespace GlobalSqa.Test.Base
{
    public class TestBase
    {
        [OneTimeSetUp]
        public void BeforeAllTests()
        {

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

        }
    }
}
