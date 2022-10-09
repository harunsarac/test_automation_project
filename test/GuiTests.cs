using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UI.Test
{
    [TestClass]
    public class GuiTests : TestBase
    {
        [TestMethod]
        public void TestCase_001_OrderProcessFlow()
        {
            NopView
                .OpenPage()
                .OpenProductPage()
                .FillOutRecipientInfo()
                .FillOutPersonalInfo()
                .ClickAddToWishList()
                .OpenWishList()
                .UpdateProductQuantity(3)
                .UpdateWishList()
                .AddWishListItemToCart()
                .ToggleTermsAndConditions()
                .ClickOnCheckout()
                .FillOutBillingAddressInfo()
                .ChooseAPaymentMethod()
                .ContinueOnPaymentInfo()
                .ConfirmCheckout()
                .ValidateOrderIsSuccessfullyProcessed();
        }
    }
}