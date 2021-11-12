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

        #region Goto Methods

        public void GoToHome()
        {
            if(Map.Home != null)
                Map.Home.Click();
        }

        public void GoToTesterHub()
        {
            if(Map.TesterHub != null)
                Map.TesterHub.Click();
        }

        public void GoToSamplePage()
        {
            if (Map.SamplePageLink != null)
                Map.SamplePageLink.Click();
        }

        #endregion

        public bool IsTesterHubVisible()
        {
            if (Map.TesterHub != null) return Map.TesterHub.Displayed;
            else return false;
        }
        public void HoverTesterHub()
        {
            if (Map.TesterHub != null)
                Map.TesterHub.Hover();
        }
    }

    public class NavigatorMap
    {
        public Element Home => Driver.FindElement(By.Id(NavigationHooks.HomeId), "Home");
        public Element TesterHub => Driver.FindElement(By.Id(NavigationHooks.TesterHubId), "Tester's Hub");
        public Element SamplePageLink => Driver.FindElement(By.Id(NavigationHooks.SamplePageLinkId), "Sample Page Test");

    }
}
