using GlobalSqa.Framework.Enums;
using GlobalSqa.Framework.Helpers;
using OpenQA.Selenium;
using System;
using System.Drawing;
using System.IO;
using OpenQA.Selenium.Support.Extensions;

namespace GlobalSqa.Framework.Selenium
{
    public static class Driver
    {
        [ThreadStatic] 
        private static IWebDriver _driver;

        public static string wpd = Path.GetFullPath(@"../../../../");

        [ThreadStatic]
        public static Wait Wait;

        /// <summary>
        /// Initializes driver by supplying browser name.
        /// </summary>
        /// <param name="browsers">Chrome, Firefox</param>
        public static void Init(Browsers browsers)
        {
            _driver = DriverMaker.Make(browsers.GetStringValue());
            Wait = new Wait(60);
        }

        public static IWebDriver Current => _driver ?? throw new NullReferenceException($"{_driver.GetType().Name} is null.");
        public static void Goto(string url)
        {
            Current.Navigate().GoToUrl(url);
        }
        public static Element FindElement(By by, string name = "")
        {
            try
            {
                var element = Wait.Until(driver => driver.FindElement(by));
                return new Element(element, name)
                {
                    FoundBy = by
                };
            }
            catch (NoSuchElementException)
            {
                return null;
            }
        }
        public static Elements FindElements(By by)
        {
            return new Elements(Current.FindElements(by))
            {
                FoundBy = by
            };
        }
        public static void Maximize()
        {
            Current.Manage().Window.Maximize();
        }
        public static void Minimize()
        {
            Current.Manage().Window.Minimize();
        }
        public static void CustomSize(int W, int H)
        {
            Current.Manage().Window.Size = new Size(W, H);
        }

        public static void Refresh()
        {
            Current.ExecuteJavaScript("return document.location.reload();");
        }
        public static string TakeScreenshot(string name)
        {
            var screenshot = ((ITakesScreenshot)Current).GetScreenshot();
            var screenshotPath = Path.Combine($"{wpd}", "TestResults", name, name);
            screenshot.SaveAsFile($"{screenshotPath}.png", ScreenshotImageFormat.Png);
            return $"{screenshotPath}.png";
        }
        public static void Close()
        {
            Current.Close();
        }
        public static void Quit()
        {
            Current.Quit();
        }
        public static void CloseAndQuit()
        {
            Close();
            Quit();
        }
    }
}
