using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace UI.Test.Pages
{
    public class CartView : NopView
    {
        public CartView(IWebDriver Driver) : base(Driver)
        {
        }
        #region Web elements

        [FindsBy(How = How.XPath, Using = "//input[@id='termsofservice']")]
        private IWebElement TermsAndConditionsCheck { get; set; }

        [FindsBy(How = How.XPath, Using = "//button[@id='checkout']")]
        private IWebElement CheckoutButton { get; set; }


        #endregion

        #region Methods

        public CartView ToggleTermsAndConditions()
        {
            TermsAndConditionsCheck.Click();
            return this;
        }

        public CheckoutView ClickOnCheckout()
        {
            CheckoutButton.Click();
            return CheckoutView;
        }

        #endregion
    }
}
