using FluentAssertions;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using UI.Test.Helpers;

namespace UI.Test.Pages
{
    public class CheckoutView : NopView
    {
        public CheckoutView(IWebDriver Driver) : base(Driver)
        {
        }
        #region Web elements

        [FindsBy(How = How.XPath, Using = "//input[@id='BillingNewAddress_FirstName']")]
        private IWebElement FirstNameInput { get; set; }

        [FindsBy(How = How.XPath, Using = "//input[@id='BillingNewAddress_LastName']")]
        private IWebElement LastNameInput { get; set; }

        [FindsBy(How = How.XPath, Using = "//input[@id='BillingNewAddress_Email']")]
        private IWebElement EmailInput { get; set; }

        [FindsBy(How = How.XPath, Using = "//input[@id='BillingNewAddress_Company']")]
        private IWebElement CompanyInput { get; set; }

        [FindsBy(How = How.XPath, Using = "//select[@id='BillingNewAddress_CountryId']")]
        private IWebElement CountrySelectInput { get; set; }

        [FindsBy(How = How.XPath, Using = "//select[@id='BillingNewAddress_StateProvinceId']")]
        private IWebElement StateSelectInput { get; set; }

        [FindsBy(How = How.XPath, Using = "//input[@id='BillingNewAddress_City']")]
        private IWebElement CityInput { get; set; }

        [FindsBy(How = How.XPath, Using = "//input[@id='BillingNewAddress_Address1']")]
        private IWebElement Address1Input { get; set; }

        [FindsBy(How = How.XPath, Using = "//input[@id='BillingNewAddress_Address2']")]
        private IWebElement Address2Input { get; set; }

        [FindsBy(How = How.XPath, Using = "//input[@id='BillingNewAddress_ZipPostalCode']")]
        private IWebElement ZipCodeInput { get; set; }

        [FindsBy(How = How.XPath, Using = "//input[@id='BillingNewAddress_PhoneNumber']")]
        private IWebElement PhoneNumberInput { get; set; }

        [FindsBy(How = How.XPath, Using = "//input[@id='BillingNewAddress_FaxNumber']")]
        private IWebElement FaxNumberInput { get; set; }

        [FindsBy(How = How.XPath, Using = "//button[contains(@class, 'new-address-next-step-button')]")]
        private IWebElement BillingContinueButton { get; set; }

        [FindsBy(How = How.XPath, Using = "//input[@id='paymentmethod_0']")]
        private IWebElement CashPaymentMethodInput { get; set; }

        [FindsBy(How = How.XPath, Using = "//input[@id='paymentmethod_1']")]
        private IWebElement CreditPaymentMethodInput { get; set; }

        [FindsBy(How = How.XPath, Using = "//button[contains(@class, 'payment-method-next-step-button')]")]
        private IWebElement PaymentMethodContinueButton { get; set; }
        
        [FindsBy(How = How.XPath, Using = "//button[contains(@class, 'payment-info-next-step-button')]")]
        private IWebElement PaymentInfoContinueButton { get; set; }

        [FindsBy(How = How.XPath, Using = "//button[contains(@class, 'confirm-order-next-step-button')]")]
        private IWebElement ConfirmOrderButton { get; set; }
        
        [FindsBy(How = How.XPath, Using = "//h1[contains(text(), 'Thank you')]")]
        private IWebElement ThankYouMessage { get; set; }
        
        #endregion

        #region Methods

        public CheckoutView FillOutBillingAddressInfo(bool requiredOnly = true)
        {
            FirstNameInput.ClearSendKeys(userForLogin.firstName);
            LastNameInput.ClearSendKeys(userForLogin.lastName);
            EmailInput.ClearSendKeys(userForLogin.email);
            CountrySelectInput.SelectRandomOption();
            CityInput.ClearSendKeys(StringHelpers.GenerateRandomString());
            Address1Input.ClearSendKeys(StringHelpers.GenerateRandomString());
            ZipCodeInput.ClearSendKeys(StringHelpers.GenerateRandomNumber(5));
            PhoneNumberInput.ClearSendKeys(StringHelpers.GenerateRandomNumber());
            if (!requiredOnly)
            {
                CompanyInput.ClearSendKeys(StringHelpers.GenerateRandomString());
                StateSelectInput.SelectRandomOption();
                Address2Input.ClearSendKeys(StringHelpers.GenerateRandomString());
                FaxNumberInput.ClearSendKeys(StringHelpers.GenerateRandomNumber());
            }

            BillingContinueButton.Click();

            return this;
        }

        public CheckoutView ChooseAPaymentMethod(PaymentMethod paymentMethod = PaymentMethod.Cash)
        {
            if (paymentMethod.Equals(PaymentMethod.Cash))
            {
                CashPaymentMethodInput.WaitForVisible(3000);
                CashPaymentMethodInput.Click();
            }
            else
                CreditPaymentMethodInput.Click();

            PaymentMethodContinueButton.Click();
            return this;
        }

        public CheckoutView ContinueOnPaymentInfo()
        {
            PaymentInfoContinueButton.WaitForVisible(3000);
            PaymentInfoContinueButton.Click();
            return this;
        }

        public CheckoutView ConfirmCheckout()
        {
            ConfirmOrderButton.WaitForVisible(3000);
            ConfirmOrderButton.Click();
            return this;
        }

        #endregion

        #region Validation methods

        public CheckoutView ValidateOrderIsSuccessfullyProcessed()
        {
            //var message = Driver.FindElement(By.XPath("//h1[contains(text(), 'Thank you')]"));
            ThankYouMessage.WaitForVisible(3000);
            var successfulOrderMessage =
                Driver.FindElement(By.XPath("//div[contains(@class, 'order-completed')]//div[@class='title']/strong")).Text;
            successfulOrderMessage.Should().Be("Your order has been successfully processed!");
            return this;
        }

        #endregion
    }
}
