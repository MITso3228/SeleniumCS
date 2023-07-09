/// This project was created in order to complete Test Task
/// Author: Kostiantyn Vasyliev
/// Email: k.vasiliev32@gmail.com

using SeleniumCS.Helpers;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using EC = SeleniumExtras.WaitHelpers.ExpectedConditions;

namespace SeleniumCS.Pages
{
    public class BasePage
    {
        protected Logging Logger;

        public BasePage(IWebDriver driver, Logging logger)
        {
            Driver = driver;
            Wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            Logger = logger;
        }

        protected IWebDriver Driver { get; private set; }
        protected WebDriverWait Wait { get; private set; }

        protected void Click(By locator)
        {
            Driver.FindElement(locator).Click();

            Logger.Info($"Clicked on {locator}");
        }

        protected void SetText(By locator, string text)
        {
            LocateElement(locator).SendKeys(text);

            Logger.Info($"Inputed text {text} in {locator}");
        }

        protected string GetTextOfElement(By locator) => LocateElement(locator).Text;

        protected IWebElement LocateElement(By locator) => Driver.FindElement(locator);

        protected bool IsElementDisappearedAfterWaiting(By locator)
        {
            try
            {
                Wait.Until(EC.InvisibilityOfElementLocated(locator));

                return true;
            }
            catch (Exception)
            {
                throw new Exception("Element is still visible");
            }
        }

        protected IWebElement WaitAndFind(By locator)
        {
            Wait.Until(EC.ElementIsVisible(locator));
            return Driver.FindElement(locator);
        }

        protected void WaitForBrowserAlert() => Wait.Until(EC.AlertIsPresent());
    }
}
