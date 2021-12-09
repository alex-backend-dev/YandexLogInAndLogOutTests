using OpenQA.Selenium;
using Yandex_LogIn_LogOut_Tests.Page_Object_Entities.BasePage_Entity;

namespace Yandex_LogIn_LogOut_Tests.Page_Object_Entities
{
    public class PassportYandexPage : BasePage
    {
        private By LoginFormSelector = By.CssSelector("#passp-field-login");
        private By PasswordFormSelector = By.CssSelector("#passp-field-passwd");

        private IWebElement SearchResultLogin => driver.FindElement(LoginFormSelector);
        private IWebElement SearchResultPassword => driver.FindElement(PasswordFormSelector);

        public PassportYandexPage(IWebDriver? driver) : base(driver)
        {
        }

        public PassportYandexPage EnterLoginData(string loginData)
        {
            SearchResultLogin.SendKeys(loginData);
            SearchResultLogin.SendKeys(Keys.Enter);

            return this;
        }

        public YandexHomePage EnterPasswordData(string passwordData)
        {
            SearchResultPassword.SendKeys(passwordData);
            SearchResultPassword.SendKeys(Keys.Enter);

            return new YandexHomePage(driver);
        }
    }
}
