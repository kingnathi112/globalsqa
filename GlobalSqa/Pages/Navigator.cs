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

        public void GoHome()
        {
            if(Map.Home != null)
                Map.Home.Click();
        }

        public void GoTesterHub()
        {
            if(Map.TesterHub != null)
                Map.TesterHub.Click();
        }

        public void HoverTesterHub()
        {
            if (Map.TesterHub != null)
                Map.TesterHub.Hover();
        }
    }

    public class NavigatorMap
    {
        public Element Home => Driver.FindElement(By.Id(NavigationHooks.HomeId));
        public Element TesterHub => Driver.FindElement(By.Id(NavigationHooks.TesterHubId));

    }
}
