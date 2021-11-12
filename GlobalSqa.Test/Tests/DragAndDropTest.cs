using System;
using GlobalSqa.Test.Base;
using NUnit.Framework;

namespace GlobalSqa.Test.Tests
{
    [TestFixture]
    public class DragAndDropTest: TestBase
    {
        [Test, Order(10)]
        public void Given_UserNavigateToDragAndDrop_Then_PhotoManagerMustBeVisible()
        {
            Assert.That(dragAndDropPage.IsPhotoManagerHeaderVisible, Is.True);
            Assert.That(dragAndDropPage.IsPhotoManagerVisible, Is.True);
        }

        [Test, Order(20)]
        public void Given_UserNavigateToDragAndDrop_When_UserClickAndDragAnItemFromGallery_And_DropsItOnTrash_Then_ItemMustBeRemovedFromGallery()
        {
           Assert.That(dragAndDropPage.IsGalleryVisible, Is.True);
        }
    }
}
