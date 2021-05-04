using System;
using System.Collections.Generic;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.Extensions;
using OpenQA.Selenium.Support.UI;
using ExpectedConditions = SeleniumExtras.WaitHelpers.ExpectedConditions;

namespace Hydra.Tests.Selenium
{
    public class WebSimulator : IDisposable
    {
        public IWebDriver WebDriver;
        public readonly AppSettings _appSettings;
        public WebDriverWait Wait;

        public WebSimulator(Browser browser, AppSettings appSettings)
        {
            _appSettings = appSettings;
            WebDriver = WebDriverFactory.CreateWebDriver(browser, _appSettings.WebDrivers, _appSettings.Headless);
            Wait = new WebDriverWait(WebDriver, TimeSpan.FromSeconds(30));
        }

        /// <summary>
        /// click event by LinkText
        /// </summary>
        /// <param name="linkText"></param>
        public void ClickByLinkText(string linkText) => Wait.Until(ExpectedConditions.ElementIsVisible(By.LinkText(linkText)))
                                                            .Click();

        /// <summary>
        /// click event by Id
        /// </summary>
        /// <param name="id"></param>
        public void ClickById(string id) => Wait.Until(ExpectedConditions.ElementIsVisible(By.Id(id)))
                                                .Click();

        /// <summary>
        /// click by XPath
        /// </summary>
        /// <param name="xPath"></param>
        /// <returns></returns>
        public void ClickByXPath(string xPath) => Wait.Until(ExpectedConditions.ElementIsVisible(By.XPath(xPath)))
                                                      .Click();

        /// <summary>
        /// Get element by Css class
        /// </summary>
        /// <param name="className"></param>
        /// <returns></returns>
        public IWebElement GetElementByClass(string className) => Wait.Until(ExpectedConditions.ElementIsVisible(By.ClassName(className)));

        /// <summary>
        /// Get element by xPath
        /// </summary>
        /// <param name="xPath"></param>
        /// <returns></returns>
        public IWebElement GetElementByXPath(string xPath) => Wait.Until(ExpectedConditions.ElementIsVisible(By.XPath(xPath)));

        /// <summary>
        /// Get element by Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public IWebElement GetElementById(string id) => Wait.Until(ExpectedConditions.ElementIsVisible(By.Id(id)));


        /// <summary>
        /// Fill values to Dropdown by Id
        /// </summary>
        /// <param name="id"></param>
        /// <param name="value"></param>
        public void FillDropDownById(string id, string value)
        {
            var field = Wait.Until(ExpectedConditions.ElementIsVisible(By.Id(id)));
            var selectElement = new SelectElement(field);
            selectElement.SelectByValue(value);
        }

        /// <summary>
        /// Get element text by Css class
        /// </summary>
        /// <param name="className"></param>
        /// <returns></returns>
        public string GetElementTextByClass(string className) => Wait.Until(ExpectedConditions.ElementIsVisible(By.ClassName(className))).Text;

        /// <summary>
        /// Get elememt text by Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public string GetElementTextById(string id) => Wait.Until(ExpectedConditions.ElementIsVisible(By.Id(id))).Text;

        /// <summary>
        /// Get elememt value by Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public string GetTextBoxValueById(string id) => Wait.Until(ExpectedConditions.ElementIsVisible(By.Id(id)))
                                                             .GetAttribute("value");

        /// <summary>
        /// Get List of items by css class
        /// </summary>
        /// <param name="className"></param>
        /// <returns></returns>
        public IEnumerable<IWebElement> GetListByClass(string className) => Wait.Until(ExpectedConditions.PresenceOfAllElementsLocatedBy(By.ClassName(className)));

        public bool ElementExistsById(string id)
        {
            return ElementExists(By.Id(id));
        }

        /// <summary>
        /// Back the navigation
        /// </summary>
        /// <param name="vezes"></param>
        public void BackTheNavigation(int howMany = 1)
        {
            for (var i = 0; i < howMany; i++)
            {
                WebDriver.Navigate().Back();
            }
        }

        /// <summary>
        /// Take Screenshot
        /// </summary>
        /// <param name="nome"></param>
        public void TakeScreenShot(string nome)
        {
            SaveScreenShot(WebDriver.TakeScreenshot(), string.Format("{0}_" + nome + ".png", DateTime.Now.ToFileTime()));
        }

        /// <summary>
        /// Save Screenshot
        /// </summary>
        /// <param name="screenshot"></param>
        /// <param name="fileName"></param>
        private void SaveScreenShot(Screenshot screenshot, string fileName)
        {
            screenshot.SaveAsFile($"{_appSettings.FolderPicture}{fileName}", ScreenshotImageFormat.Png);
        }

        /// <summary>
        /// Valid existing element
        /// </summary>
        /// <param name="by"></param>
        /// <returns></returns>
        private bool ElementExists(By by)
        {
            try
            {
                WebDriver.FindElement(by);
                return true;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }

        /// <summary>
        /// Dispose the objects
        /// </summary>
        public void Dispose()
        {
            WebDriver.Quit();
            WebDriver.Dispose();
        }
    }
}
