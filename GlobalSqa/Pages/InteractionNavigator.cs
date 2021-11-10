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

        public void GoDragAndDrop()
        {
            if(Map.DragAndDrop != null)
                Map.DragAndDrop.Click();
        }

        public void GoDropDownMenu()
        {
            if (Map.DropDownMenu != null)
                Map.DropDownMenu.Click();
        }
    }

    public class InteractionNavigatorMap
    {
        public Element DragAndDrop => Driver.FindElement(By.Id(InteractionHooks.DragAndDropId));
        public Element DropDownMenu => Driver.FindElement(By.Id(InteractionHooks.DropDownMenuId));
    }
}
