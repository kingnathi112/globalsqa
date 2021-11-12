using GlobalSqa.Framework.Selenium;
using GlobalSqa.Helpers;
using OpenQA.Selenium;

namespace GlobalSqa.Pages
{
    public class DragAndDropPage
    {
        public readonly DragAndDropPageMap Map;

        public DragAndDropPage()
        {
            Map = new DragAndDropPageMap();
        }

        #region GoTo methods

        public void GoToPhotoManager()
        {
            if(Map.PhotoManagerHeader != null)
                Map.PhotoManagerHeader.Click();
        }

        public void GoToAcceptedElements()
        {
            if (Map.AcceptedElements != null)
                Map.AcceptedElements.Click();
        }        
        
        public void GoToPropagation()
        {
            if (Map.Propagation != null)
                Map.Propagation.Click();
        }

        #endregion

        #region Visibility Methods

        public bool IsPhotoManagerVisible()
        {
            if (Map.PhotoManager != null)
                return Map.PhotoManager.Displayed;
            else
                return false;
        }

        public bool IsPhotoManagerHeaderVisible()
        {
            if (Map.PhotoManagerHeader != null)
                return Map.PhotoManagerHeader.Displayed;
            else
                return false;
        }

        public bool IsAcceptedElementsVisible()
        {
            if (Map.AcceptedElements != null)
                return Map.AcceptedElements.Displayed;
            else
                return false;
        }

        public bool IsPropagationVisible()
        {
            if (Map.Propagation != null)
                return Map.Propagation.Displayed;
            else
                return false;
        }

        public bool IsTrashVisible()
        {
            if (Map.Trash != null)
                return Map.Trash.Displayed;
            else
                return false;
        }        
        
        public bool IsGalleryVisible()
        {
            if (Map.Gallery != null)
                return Map.Gallery.Displayed;
            else
                return false;
        }

        #endregion

        public int Items()
        {
            return Map.GalleryItems.Count;
        }
    }
    public class DragAndDropPageMap
    {
        public Element PhotoManagerHeader => Driver.FindElement(By.Id(DragAndDropHooks.PhotoManagerHeaderId), "Photo Manager Header");
        public Element PhotoManager => Driver.FindElement(By.CssSelector(DragAndDropHooks.PhotoManagerCss), "Photo Manager");
        public Element AcceptedElements => Driver.FindElement(By.Id(DragAndDropHooks.AcceptedElementsId), "Accepted Elements Header");
        public Element Propagation => Driver.FindElement(By.Id(DragAndDropHooks.PropagationId), "Propagation Header");
        public Element Trash => Driver.FindElement(By.Id(DragAndDropHooks.TrashId), "Trash");
        public Element Gallery => Driver.FindElement(By.Id(DragAndDropHooks.GalleryId), "Gallery");
        public Elements GalleryItems => Driver.FindElements(By.ClassName(DragAndDropHooks.GalleryItemClass));
    }
}
