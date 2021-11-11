using GlobalSqa.Framework.Selenium;
using GlobalSqa.Helpers;
using OpenQA.Selenium;

namespace GlobalSqa.Pages
{
    public class InteractionNavigator
    {
        public readonly InteractionNavigatorMap Map;
        public InteractionNavigator()
        {
            Map = new InteractionNavigatorMap();
        }

        #region Goto Methods

        public void GoToDragAndDrop()
        {
            if(Map.DragAndDrop != null)
                Map.DragAndDrop.Click();
        }

        public void GoToDropDownMenu()
        {
            if (Map.DropDownMenu != null)
                Map.DropDownMenu.Click();
        }

        #endregion

        #region Visibility Methods

        public bool IsDropDownMenuVisible()
        {
            if (Map.DropDownMenu != null) return Map.DropDownMenu.Displayed;
            else return false;
        }

        #endregion
    }

    public class InteractionNavigatorMap
    {
        public Element DragAndDrop => Driver.FindElement(By.Id(InteractionHooks.DragAndDropId));
        public Element DropDownMenu => Driver.FindElement(By.Id(InteractionHooks.DropDownMenuId));
    }
}
