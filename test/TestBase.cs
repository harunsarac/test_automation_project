using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using src;
using UI.Test.Pages;

namespace UI.Test
{
    [TestClass]
    public class TestBase
    {
        private static IWebDriver _browser;
        protected static IWebDriver Driver
        {
            get
            {
                if (_browser == null)
                {
                    InitializePages();
                }

                return _browser;
            }
            set => _browser = value;
        }
        protected static User userForLogin = new User();
        protected static NopView NopView { get; set; }
        protected static RegisterView RegisterView { get; set; }
        protected static CartView CartView { get; set; }
        protected static WishListView WishListView { get; set; }
        protected static ProductView ProductView { get; set; }
        protected static CheckoutView CheckoutView { get; set; }

        /// <summary>
        /// Pages collection for simple initialization
        /// </summary>
        private static void InitializePages()
        {
            
            NopView = new NopView(Driver);
            RegisterView = new RegisterView(Driver);
            CartView = new CartView(Driver);
            WishListView = new WishListView(Driver);
            ProductView = new ProductView(Driver);
            CheckoutView = new CheckoutView(Driver);
            
        }

        /// <summary>
        /// Test Initialize method that is executed before Test method.
        /// </summary>
        [TestInitialize]
        public void TestInitialize()
        {
            Driver = new ChromeDriver();
            NopView = new NopView(Driver);
            InitializePages();
            NopView
                .OpenPage()
                .NavigateToRegisterPage()
                .RegisterUser(userForLogin)
                .VerifyRegistrationSuccess()
                .NavigateToHomePage();
        }

        /// <summary>
        /// Test Cleanup method that is executed after Test method.
        /// </summary>
        [TestCleanup]
        public void TestCleanup()
        {
            Driver.Close();
        }
    }
}
