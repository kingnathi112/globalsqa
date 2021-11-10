using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;

namespace GlobalSqa.Framework.Selenium
{
    // Define driver to be used
    public static class DriverMaker
    {
        public static IWebDriver Make(string browser)
        {
            switch (browser)
            {
                case "chrome":
                    var chromeOptions = new ChromeOptions();
                    chromeOptions.AddArgument("--ignore-certificate-errors");
                    chromeOptions.AddExcludedArgument("--enable-automation");
                    chromeOptions.AddExcludedArgument("--load-extension");
                    return new ChromeDriver(chromeOptions);

                case "firefox":
                    var firefoxOptions = new FirefoxOptions();
                    firefoxOptions.AddArgument("--ignore-certificate-errors");
                    return new FirefoxDriver(firefoxOptions);

                default:
                    return new ChromeDriver();
            }
        }
    }
}
