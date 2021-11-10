using GlobalSqa.Framework.Selenium;
using GlobalSqa.Helpers;
using OpenQA.Selenium;

namespace GlobalSqa.Pages
{
    public class Navigator
    {
        public readonly NavigatorMap Map;

        public Navigator()
        {
            Map = new NavigatorMap();
        }

        // Go HomeId
        public void GoHome()
        {
            if(Map.Home != null)
                Map.Home.Click();
        }
    }

    public class NavigatorMap
    {
        public Element Home => Driver.FindElement(By.Id(NavigationHooks.HomeId));
        public Element TesterHub => Driver.FindElement(By.Id(NavigationHooks.TesterHubId));

    }
}
