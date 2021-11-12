using GlobalSqa.Test.Base;
using GlobalSqa.Test.Services;
using NUnit.Framework;
using System;
using System.Threading;

namespace GlobalSqa.Test.Tests
{
    [TestFixture]
    public class SamplePageTest : TestBase
    {
        private int person = 0;
        public SamplePageTest()
        {
            var rnd = new Random();
            person = rnd.Next(0, 19);
        }
        [Test, Order(10)]
        public void Given_UserNavigateToDragAndDrop_When_UserHoverTesterHub_And_ClickOnSamplePageTestLink_Then_SamplePageTestMustLoad()
        {
            Assert.That(navigator.IsTesterHubVisible(), Is.True);
            navigator.HoverTesterHub();
            navigator.GoToSamplePage();

            // This is a hack :)
            samplePage.CloseAdByRefreshIntoThePage();

            navigator.HoverTesterHub();
            navigator.GoToSamplePage();
            Assert.That(samplePage.WaitForPageToLoad, Is.True);
        }

        [Test, Order(20)]
        public void Given_SamplePageHasLoaded_When_UserEnterNameEmailCommentAndWebsite_Then_NoErrorMustPopUp()
        {
            samplePage.EnterName(TestdataService.Testdata()[person].Fullname);
            samplePage.EnterEmail(TestdataService.Testdata()[person].Email);
            samplePage.EnterWebsite(TestdataService.Testdata()[person].Website);
            samplePage.EnterComment(TestdataService.Testdata()[person].Comment);
        }

        [Test, Order(30)]
        public void Given_SamplePageHasLoaded_When_SelectExperienceExpertiseAndEducation_Then_NoErrorMustPopUp()
        {
            samplePage.SelectExperience(TestdataService.Testdata()[person].Experience);
            samplePage.SelectExpertise(TestdataService.Testdata()[person].Expertise);
            samplePage.SelectEducation(TestdataService.Testdata()[person].Education);
        }

        [Test, Order(40),Ignore("Not Testing Alert")]
        public void Given_SamplePageHasLoaded_When_UserClickOnAlertBox_Then_AlertDialogIsShown()
        {
            samplePage.ClickAlertButton();
            samplePage.CloseQuestionAlertByAccept();
            samplePage.CloseWarningAlertByAccept();
        }

        [Test, Order(50)]
        public void Given_SamplePageHasLoaded_When_UserClickSubmit_Then_SuccessfulPageIsDisplayed()
        {
            samplePage.ClickSubmitButton();
            samplePage.CloseQuestionAlertByAccept();
        }
    }
}
