using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using UI.Test.Helpers;

namespace UI.Test.Pages
{
    public class ProductView : NopView
    {
        public ProductView(IWebDriver Driver) : base(Driver)
        {
        }
        #region Web elements

        [FindsBy(How = How.XPath, Using = "//input[@class='recipient-name']")]
        private IWebElement RecipientNameInput { get; set; }

        [FindsBy(How = How.XPath, Using = "//input[@class='recipient-email']")]
        private IWebElement RecipientEmailInput { get; set; }
        
        [FindsBy(How = How.XPath, Using = "//input[contains(@class, 'sender-name')]")]
        private IWebElement YourNameInput { get; set; }

        [FindsBy(How = How.XPath, Using = "//input[contains(@class, 'sender-email')]")]
        private IWebElement YourEmailInput { get; set; }

        [FindsBy(How = How.XPath, Using = "//div[@class='add-to-wishlist']//button")]
        private IWebElement AddToWishListButton { get; set; }

        [FindsBy(How = How.XPath, Using = "//a[@class='ico-wishlist']")]
        private IWebElement WishListButton { get; set; }


        #endregion

        #region Navigation methods

        public WishListView OpenWishList()
        {
            WishListButton.Click();
            return WishListView;
        }

        #endregion

        #region Methods

        /// <summary>
        /// Fill the input fields for the info of recipient of gift card
        /// </summary>
        public ProductView FillOutRecipientInfo()
        {
            RecipientNameInput.Clear();
            RecipientNameInput.SendKeys(StringHelpers.GenerateRandomString());
            RecipientEmailInput.Clear();
            RecipientEmailInput.SendKeys(StringHelpers.GenerateRandomEmail());
            return this;
        }

        /// <summary>
        /// Fill the input fields for personal info
        /// </summary>
        public ProductView FillOutPersonalInfo()
        {
            if (YourNameInput.GetAttribute("value").Equals(string.Empty))
                YourNameInput.SendKeys(userForLogin.firstName);
            if (YourEmailInput.GetAttribute("value").Equals(string.Empty))
                YourEmailInput.SendKeys(userForLogin.email);
            return this;
        }

        /// <summary>
        /// Click to add the product to the wish list
        /// </summary>
        public ProductView ClickAddToWishList()
        {
            AddToWishListButton.Click();
            return this;
        }
        
        #endregion
    }
}
