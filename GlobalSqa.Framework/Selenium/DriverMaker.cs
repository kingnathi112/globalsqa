using System.IO;
using System.Linq;
using System.Reflection;
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
                    CopyWebdriversToLocal("chromedriver.exe");
                    var chromeOptions = new ChromeOptions();
                    chromeOptions.AddArgument("--ignore-certificate-errors");
                    chromeOptions.AddExcludedArgument("--enable-automation");
                    chromeOptions.AddArguments("--incognito");
                    return new ChromeDriver(localPath,chromeOptions);

                case "firefox":
                    CopyWebdriversToLocal("geckodriver.exe");
                    var firefoxOptions = new FirefoxOptions();
                    firefoxOptions.AddArgument("--ignore-certificate-errors");
                    return new FirefoxDriver(localPath, firefoxOptions);

                default:
                    return new ChromeDriver(localPath);
            }
        }

        private static string localPath = @"C:\WebDrivers\";
        private static void CopyWebdriversToLocal(string driverName = "chromedriver.exe")
        {
            if (!Directory.Exists(localPath))
                Directory.CreateDirectory(localPath);

            string[] currentPath = Assembly.GetExecutingAssembly().GetManifestResourceNames();

            using (var resourceStream = Assembly.GetExecutingAssembly().GetManifestResourceStream(currentPath.Where(x => x.Contains(driverName)).First()))
            {
                using (var driver = new FileStream(Path.Combine(localPath, driverName), FileMode.Create, FileAccess.Write))
                {
                    resourceStream.CopyTo(driver);
                }
            }
        }
    }
}
