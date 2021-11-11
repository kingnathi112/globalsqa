using System;
using System.Threading;
using GlobalSqa.Test.Base;
using NUnit.Framework;

namespace GlobalSqa.Test.Tests
{
    [TestFixture]
    public class DropDownMenuTest : TestBase
    {
        [Test, Order(10)]
        public void Given_UserNavigateToDragAndDrop_When_UserClickOnDropdownMenuLink_Then_DropdownMenuPageIsLoaded()
        {
            Assert.That(interactionNavigator.IsDropDownMenuVisible, Is.True);
            interactionNavigator.GoToDropDownMenu();
        }

        [Test, Order(20)]
        [TestCase("South Africa")]
        [TestCase("Angola")]
        public void Given_DropDownMenuPageIsLoaded_When_UserClickDropDownMenu_And_SelectsACountry_Then_SelectedCountryMustBeVisible(string country)
        {
           Assert.That(dropDownMenuPage.SelectCountry(country), Is.True);
        }
    }
}
