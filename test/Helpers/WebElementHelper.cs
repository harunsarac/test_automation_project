using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Diagnostics;
using System.Threading;

namespace UI.Test.Helpers
{
    public static class WebElementHelper
    {
        /// <summary>
        /// Click on the element, clears its content and sends specified text by simulating typing
        /// </summary>
        /// <param name="element">IWebElement to send keys to</param>
        /// <param name="text">The text to type into the element</param>
        public static void ClearSendKeys(this IWebElement element, string text)
        {
            element.Click();
            element.SendKeys(Keys.Control + "a");
            element.SendKeys(Keys.Delete);
            element.Clear();
            element.SendKeys(text);
        }

        /// <summary>
        /// Select a random option from select dropdown
        /// </summary>
        /// <param name="element">IWebElement to send option to</param>
        public static void SelectRandomOption(this IWebElement element)
        {
            var selectElement = new SelectElement(element);
            var options = selectElement.Options;
            var randomIndex = new Random().Next(1, options.Count);
            var optionToSelect = options[randomIndex];

            if (optionToSelect == null)
                throw new Exception(
                    $"Unable to select option from {selectElement}");

            selectElement.SelectByValue(optionToSelect.GetAttribute("value"));
        }

        /// <summary>
        /// Waits for element to become visible
        /// </summary>
        /// <param name="element">Element that should be visible</param>
        /// <param name="timeoutDuration">Maximum waiting time in milliseconds</param>
        public static void WaitForVisible(this IWebElement element, int timeoutDuration, int sleepDuration = 200)
        {
            var stopwatch = new Stopwatch();
            var elementVisible = false;
            stopwatch.Start();

            while (!elementVisible)
            {
                try
                {
                    elementVisible = element.Displayed;

                    if (elementVisible)
                        return;

                    Thread.Sleep(sleepDuration);

                    if (stopwatch.ElapsedMilliseconds > timeoutDuration)
                        break;
                }
                catch (Exception)
                {
                    Thread.Sleep(sleepDuration);

                    if (stopwatch.ElapsedMilliseconds > timeoutDuration)
                        break;
                }
            }
        }
    }
}
