using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using UI.Test.Helpers;

namespace UI.Test.Pages
{
    public class WishListView : NopView
    {
        public WishListView(IWebDriver Driver) : base(Driver)
        {
        }
        #region Web elements

        [FindsBy(How = How.XPath, Using = "//button[@id='updatecart']")]
        private IWebElement UpdateWishListButton { get; set; }

        [FindsBy(How = How.XPath, Using = "//button[@name='addtocartbutton']")]
        private IWebElement AddToCartButton { get; set; }


        #endregion

        #region Methods

        /// <summary>
        /// Update the quantity field of a certain product
        /// </summary>
        /// <param name="quantity"></param>
        /// <param name="product"></param>
        public WishListView UpdateProductQuantity(int quantity = 1, ShowcaseProducts product = ShowcaseProducts.GiftCard)
        {
            switch (product)
            {
                case ShowcaseProducts.GiftCard:
                    var tableRow = Driver.FindElement(By.XPath("//a[@href='/25-virtual-gift-card']/ancestor::tr"));
                    var inputQuantity = tableRow.FindElement(By.XPath(".//input[@class='qty-input']"));
                    inputQuantity.Clear();
                    inputQuantity.SendKeys(quantity.ToString());
                    break;

            }

            return this;
        }

        /// <summary>
        /// Click on update wish list button to save changes on wish list page
        /// </summary>
        public WishListView UpdateWishList()
        {
            UpdateWishListButton.Click();
            return this;
        }

        /// <summary>
        /// Adds wish list items to the cart
        /// </summary>
        public CartView AddWishListItemToCart(ShowcaseProducts product = ShowcaseProducts.GiftCard)
        {
            switch (product)
            {
                case ShowcaseProducts.GiftCard:
                    var tableRow = Driver.FindElement(By.XPath("//a[@href='/25-virtual-gift-card']/ancestor::tr"));
                    var checkBox = tableRow.FindElement(By.XPath(".//input[@name='addtocart']"));
                    checkBox.Click();
                    break;

            }
            AddToCartButton.Click();
            return CartView;
        }

        #endregion
    }
}
