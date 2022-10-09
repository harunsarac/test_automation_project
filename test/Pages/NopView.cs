using FluentAssertions;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace UI.Test.Pages
{
    public class NopView : GuiTests
    {
        public NopView(IWebDriver driver)
        {
            Driver = driver;
            PageFactory.InitElements(Driver, this);
        }

        #region Web elements

        [FindsBy(How = How.XPath, Using = "//img[@alt='nopCommerce demo store']")]
        private IWebElement HomePageLogo { get; set; }
        
        [FindsBy(How = How.XPath, Using = "//a[@class='ico-register']")]
        private IWebElement RegisterButton { get; set; }

        [FindsBy(How = How.XPath, Using = "//div[@data-productid='43']//a")]
        private IWebElement GiftCardItem { get; set; }

        #endregion
        
        #region Web elements

        public NopView OpenPage()
        {
            Driver.Navigate().GoToUrl(@"https://demo.nopcommerce.com/");
            HomePageLogo.Displayed.Should().BeTrue();

            return this;
        }

        public ProductView OpenProductPage()
        {
            GiftCardItem.Click();

            return ProductView;
        }

        //public NopView NavigateToHomePage()
        //{
        //    HomePageLogo.Click();
        //    return this;
        //}

        public RegisterView NavigateToRegisterPage()
        {
            RegisterButton.Click();
            return RegisterView;
        }

        //public NopView RegisterAndVerify(User user)
        //{
        //    RegisterView.RegisterUser(user)
        //        .VerifyRegistrationSuccess();
        //    return this;
        //}
        
        #endregion
    }
}
