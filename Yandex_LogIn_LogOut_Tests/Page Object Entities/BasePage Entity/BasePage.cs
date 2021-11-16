using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;

namespace Yandex_LogIn_LogOut_Tests.Page_Object_Entities.BasePage_Entity
{
    public class BasePage
    {
        protected IWebDriver? driver;

        public BasePage(IWebDriver? driver)
        {
            this.driver = driver;
        }

        public void GoTo(string URL)
        {
            driver?.Navigate().GoToUrl(URL);
        }

        public bool IsDisplayed(IWebDriver driver, By by, int timeoutInSeconds)
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeoutInSeconds));

            var element = wait.Until(condition =>
            {
                try
                {
                    var elementToBeDisplayed = driver.FindElement(by);
                    return elementToBeDisplayed.Displayed;
                }

                catch (StaleElementReferenceException)
                {
                    return false;
                }

                catch (NoSuchElementException)
                {
                    return false;
                }
            });

            return true;
        }

        public bool AtPageByURL(string url)
        {
            return driver?.Url == url;
        }

        public bool AtPageByTitle(string title)
        {
            return driver?.Title == title;
        }
    }
}
