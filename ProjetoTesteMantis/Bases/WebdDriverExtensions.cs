using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace ProjetoTesteMantis.Bases
{
    public static partial class WebdDriverExtensions
    {
        public static void ClickBy(this IWebDriver driver, By locator)
        {
            var element = DriverFactory.Wait.Until(ExpectedConditions.ElementToBeClickable(locator));
            element.Click();
        }

        public static void ClearBy(this IWebDriver driver, By locator, WebDriverWait wait)
        {
            var element = wait.Until(ExpectedConditions.ElementIsVisible(locator));
            element.Clear();
        }

        public static void SendKeys(this IWebDriver driver,By locator, string txt, bool clearBefore = false)
        {
            var element = DriverFactory.Wait.Until(ExpectedConditions.ElementToBeClickable(locator));
            if (clearBefore) element.Clear();
            if (string.IsNullOrEmpty(txt)) return;

            element.SendKeys(Keys.Home);
            element.SendKeys(txt);
        }
        public static void SelectDropDownListByIndex(By locator, WebDriverWait wait, int index = 1, int timeout = 10, double before = 0.5, bool removeWhiteSpace = false)
        {
            if (index < 0) return;

            var element = wait.Until(ExpectedConditions.ElementToBeClickable(locator));

            new SelectElement(element).SelectByIndex(index);
        }
        public static void SelectDropDownListByText(this IWebDriver driver, By locator, string text)
        {
            if (string.IsNullOrEmpty(text)) return;

            var element = DriverFactory.Wait.Until(ExpectedConditions.ElementToBeClickable(locator));

            new SelectElement(element).SelectByText(text);
        }


        public static IAlert WaitAlert(By locator, WebDriverWait wait)
        {
            return wait.Until(ExpectedConditions.AlertIsPresent());
        }

        public static bool IsElementPresent(this IWebDriver driver, By locator)
        {
            try
            {
                return driver.FindElement(locator).Displayed;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }
    }
}
