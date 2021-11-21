using NUnit.Framework;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Remote;
using System;
using System.IO;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;
using Yandex_LogIn_LogOut_Tests.Page_Object_Entities;

namespace Yandex_LogIn_LogOut_Tests.Tests.BaseTest
{
    public class BaseTest
    {
        protected IWebDriver? driver;
        protected YandexHomePage? yandexHomePage;
        protected PassportYandexPage? passportYandexPage;

        [SetUp]
        [Obsolete]
        public void Setup()
        {
            new DriverManager().SetUpDriver(new ChromeConfig());
            var driverOptions = new ChromeOptions();
            var runName = GetType().Assembly.GetName().Name;
            var timestamp = $"{DateTime.Now:yyyyMMdd.HHmm}";
            driverOptions.AddAdditionalCapability("name", runName, true);
            driverOptions.AddAdditionalCapability("videoName", $"{runName}.{timestamp}.mp4", true);
            driverOptions.AddAdditionalCapability("logName", $"{runName}.{timestamp}.log", true);
            driverOptions.AddAdditionalCapability("enableVNC", true, true);
            driverOptions.AddAdditionalCapability("enableVideo", true, true);
            driverOptions.AddAdditionalCapability("enableLog", true, true);
            driverOptions.AddAdditionalCapability("screenResolution", "1920x1080x24", true);
            driver = new RemoteWebDriver(new Uri("http://127.0.0.1:4444/wd/hub"), driverOptions);

            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            yandexHomePage = new YandexHomePage(driver);
            passportYandexPage = new PassportYandexPage(driver);
        }

        [TearDown]
        public void CloseDriver()
        {
            if (TestContext.CurrentContext.Result.Outcome != ResultState.Success)
            {
                var screenshot = ((ITakesScreenshot)driver).GetScreenshot();
                string path = Path.Combine(Environment.CurrentDirectory, @"TestResults\", "Screenshoot.jpg");
                screenshot.SaveAsFile(path, ScreenshotImageFormat.Jpeg);
            }

            if (driver != null)
            {
                driver.Quit();
            }
        }
    }
}
