using System;
using GlobalSqa.Framework.Selenium;
using GlobalSqa.Helpers;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace GlobalSqa.Pages
{
    public class DropDownMenuPage
    {
        public readonly DropDownMenuPageMap Map;

        public DropDownMenuPage()
        {
            Map = new DropDownMenuPageMap();
        }

        #region Visibility Methods

        public bool IsDropDownMenuPageVisible()
        {
            if (Map.DropDownMenu != null) return Map.DropDownMenu.Displayed;
            else return false;
        }

        #endregion

        #region Selection Methods

        public bool SelectCountry(string country)
        {
            if (Map.DropDown != null)
            {
                Map.DropDown.Click();
                SelectElement select = new SelectElement(Map.DropDown);
                try
                {
                    select.SelectByText(country, false);
                    Map.DropDown.Click();
                    return true;
                }
                catch (NoSuchElementException e)
                {
                    return false;
                }
            }
            else return false;
        }

        #endregion

    }

    public class DropDownMenuPageMap
    {
        public Element DropDownMenu => Driver.FindElement(By.CssSelector(DropDownMenuHooks.DropDownMenuCss), "Drop Down Menu");
        public Element DropDown => Driver.FindElement(By.XPath(DropDownMenuHooks.DropDownXPath), "Select Country");
    }
}
