using OpenQA.Selenium;
using Yandex_LogIn_LogOut_Tests.Page_Object_Entities.BasePage_Entity;

namespace Yandex_LogIn_LogOut_Tests.Page_Object_Entities
{
    public class YandexHomePage : BasePage
    {
        private By EnterFormXpath = By.XPath("//div[contains(text(),'Войти')]");
        private By LoginNameLink = By.XPath("//span[@class = 'username desk-notif-card__user-name']/parent::a");
        private By LogOutLink = By.XPath("//a[@aria-label = 'Выйти']");
        private By LoginNameAfterLogging = By.XPath("//span[@class = 'username__first-letter']");

        private IWebElement SearchResultEnter => driver.FindElement(EnterFormXpath);
        private IWebElement SearchLoginNameLink => driver.FindElement(LoginNameLink);
        private IWebElement SearchLogOutLink => driver.FindElement(LogOutLink);

        public YandexHomePage(IWebDriver? driver) : base(driver)
        {
        }

        public PassportYandexPage ClickOnEnterForm()
        {
            SearchResultEnter.Click();
            return new PassportYandexPage(driver);
        }

        public YandexHomePage ClickOnLoginNameLink()
        {
            SearchLoginNameLink.Click();
            return this;
        }

        public YandexHomePage ClickOnLogOutLink()
        {
            SearchLogOutLink.Click();
            return this;
        }

        public bool IsDisplayedLoginName()
        {
            return IsDisplayed(driver, LoginNameLink, 4);
        }

        public bool IsDisplayedLogOutLink()
        {
            return IsDisplayed(driver, LogOutLink, 4);
        }

        public bool IsDisplayedEnterButton()
        {
            return IsDisplayed(driver, EnterFormXpath, 4);
        }

        public bool IsDisplayedLoginNameAfterLogging()
        {
            return IsDisplayed(driver, LoginNameAfterLogging, 4);
        }
    }
}
