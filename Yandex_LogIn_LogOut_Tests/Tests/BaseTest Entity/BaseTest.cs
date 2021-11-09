using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
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
        public void Setup()
        {
            new DriverManager().SetUpDriver(new ChromeConfig());
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            yandexHomePage = new YandexHomePage(driver);
            passportYandexPage = new PassportYandexPage(driver);
        }

        [TearDown]
        public void CloseDriver()
        {
            if (driver != null)
            {
                driver.Quit();
            }
        }
    }
}
