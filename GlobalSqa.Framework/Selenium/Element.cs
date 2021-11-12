using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using System;
using System.Collections.ObjectModel;
using System.Drawing;

namespace GlobalSqa.Framework.Selenium
{
    public class Element : IWebElement
    {
        private readonly IWebElement _element;
        public readonly string Name;

        public By FoundBy { get; set; }
        public Element(IWebElement element, string name = "")
        {
            _element = element;
            Name = name;
        }

        public IWebElement Current => _element ?? throw new System.NullReferenceException("Element is null.");
        public IWebElement FindElement(By by)
        {
            return Current.FindElement(by);
        }

        public ReadOnlyCollection<IWebElement> FindElements(By @by)
        {
            return Current.FindElements(by);
        }

        public void Clear()
        {
            Current.Clear();
        }

        public void Click()
        {
            GlobalSqaFW.Report.Step($"Click {Name}");
            Current.Click();
        }
        
        public string GetAttribute(string attributeName)
        {
            return Current.GetAttribute(attributeName);
        }

        public string GetDomAttribute(string attributeName)
        {
            return Current.GetDomAttribute(attributeName);
        }

        public string GetDomProperty(string propertyName)
        {
            return Current.GetDomProperty(propertyName);
        }

        public string GetCssValue(string propertyName)
        {
            return Current.GetCssValue(propertyName);
        }

        public ISearchContext GetShadowRoot()
        {
            throw new NotImplementedException();
        }

        public string GetProperty(string propertyName)
        {
            return Current.GetProperty(propertyName);
        }

        public void Hover()
        {
            GlobalSqaFW.Report.Step($"Hover {Name}");
            var actions = new Actions(Driver.Current);
            actions.MoveToElement(Current).Perform();
        }

        public void SendKeys(string text)
        {
            GlobalSqaFW.Report.Step($"Type {text} On {Name}");
            Current.SendKeys(text);
        }

        public void Submit()
        {
            GlobalSqaFW.Report.Step($"Click {Name}");
            Current.Submit();
        }

        public string TagName => Current.TagName;

        public string Text => Current.Text;

        public bool Enabled => Current.Enabled;

        public bool Selected => Current.Selected;

        public Point Location => Current.Location;

        public Size Size => Current.Size;

        public bool Displayed => Current.Displayed;
    }
}
