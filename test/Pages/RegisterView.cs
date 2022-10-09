using FluentAssertions;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using src;
using UI.Test.Helpers;

namespace UI.Test.Pages
{
    public class RegisterView : NopView
    {
        public RegisterView(IWebDriver Driver) : base(Driver)
        {
        }

        #region Web elements
        
        [FindsBy(How = How.XPath, Using = "//img[@alt='nopCommerce demo store']")]
        private IWebElement HomePageLogo { get; set; }

        [FindsBy(How = How.XPath, Using = "//input[@id='FirstName']")]
        private IWebElement FirstNameInput { get; set; }

        [FindsBy(How = How.XPath, Using = "//input[@id='LastName']")]
        private IWebElement LastNameInput { get; set; }

        [FindsBy(How = How.XPath, Using = "//input[@id='Email']")]
        private IWebElement EmailInput { get; set; }

        [FindsBy(How = How.XPath, Using = "//input[@id='Password']")]
        private IWebElement PasswordInput { get; set; }

        [FindsBy(How = How.XPath, Using = "//input[@id='ConfirmPassword']")]
        private IWebElement ConfirmPasswordInput { get; set; }

        [FindsBy(How = How.XPath, Using = "//button[@id='register-button']")]
        private IWebElement RegisterButton { get; set; }

        [FindsBy(How = How.XPath, Using = "//div[@class='result']")]
        private IWebElement RegisterConfirmation { get; set; }

        #endregion

        #region Methods

        public RegisterView RegisterUser(User user)
        {
            FirstNameInput.WaitForVisible(3000);
            FirstNameInput.SendKeys(user.firstName);
            LastNameInput.SendKeys(user.lastName);
            EmailInput.SendKeys(user.email);
            PasswordInput.SendKeys(user.password);
            ConfirmPasswordInput.SendKeys(user.password);
            RegisterButton.Click();

            return this;
        }

        public RegisterView VerifyRegistrationSuccess()
        {
            RegisterConfirmation.Text.Should().Be("Your registration completed");
            return this;
        }

        public NopView NavigateToHomePage()
        {
            HomePageLogo.Click();
            return this;
        }

        #endregion
    }
}