using GlobalSqa.Framework.Selenium;
using GlobalSqa.Helpers;
using OpenQA.Selenium;

namespace GlobalSqa.Pages
{
    public class InteractionNavigator
    {
    }

    public class InteractionNavigatorMap
    {
        public Element DragAndDrop => Driver.FindElement(By.Id(InteractionHooks.DragAndDropId));
        public Element DropDownMenu => Driver.FindElement(By.Id(InteractionHooks.DropDownMenuId));
    }
}
