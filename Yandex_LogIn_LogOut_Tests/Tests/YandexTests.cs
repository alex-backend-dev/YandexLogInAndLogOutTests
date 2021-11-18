using NUnit.Allure.Attributes;
using NUnit.Allure.Core;
using NUnit.Framework;
using Yandex_LogIn_LogOut_Tests.Tests.BaseTest;
using Allure.Commons;

namespace Yandex_LogIn_LogOut_Tests
{
    [TestFixture]
    [AllureNUnit]
    [AllureDisplayIgnored]
    public class YandexTests : BaseTest
    {
        [Test(Description = "Log In and Log Out Yandex")]
        [AllureTag("Regression")]
        [AllureSeverity(SeverityLevel.critical)]
        [AllureIssue("ISSUE-1")]
        [AllureTms("TMS-12")]
        [AllureOwner("Alexander Ulyanitskiy")]
        [AllureSuite("PassedSuite")]
        [AllureSubSuite("NoAssert")]
        public void YandexTest()
        {
            yandexHomePage?
                .GoTo(Constant.Url.YANDEX_HOME_PAGE_URL);
            Assert.IsTrue(yandexHomePage?.AtPageByURL(Constant.Url.YANDEX_HOME_PAGE_URL), "Incorrect URL, we are not on a current page");
            Assert.IsTrue(yandexHomePage?.AtPageByTitle(Constant.Title.YANDEX_HOME_PAGE_TITLE), "Incorrect Title, we are not on a current page");
            yandexHomePage?
                .ClickOnEnterForm();
            Assert.IsTrue(yandexHomePage?.AtPageByTitle(Constant.Title.YANDEX_PASSPORT_PAGE_TITLE), "Incorrect Title, we are not on a current page");

            passportYandexPage?
                .EnterLoginData(Constant.Credential.LOGIN_YANDEX)
                .EnterPasswordData(Constant.Credential.PASSWORD_YANDEX);
            Assert.IsTrue(yandexHomePage?.IsDisplayedLoginNameAfterLogging(), "Login name after logging isn't displayed");
            Assert.IsTrue(yandexHomePage?.AtPageByURL(Constant.Url.YANDEX_HOME_PAGE_URL), "Incorrect URL, we are not on a current page");
            Assert.IsTrue(yandexHomePage?.AtPageByTitle(Constant.Title.YANDEX_HOME_PAGE_TITLE), "Incorrect Title, we are not on a current page");

            Assert.IsTrue(yandexHomePage?.IsDisplayedLoginName(), "Login name isn't displayed");
            yandexHomePage?
                .ClickOnLoginNameLink();
            Assert.IsTrue(yandexHomePage?.IsDisplayedLogOutLink(), "LogOut link isn't displayed");
            yandexHomePage?.ClickOnLogOutLink();
            Assert.IsTrue(yandexHomePage?.IsDisplayedEnterButton(), "LogOut button isn't displayed");
        }
    }
}