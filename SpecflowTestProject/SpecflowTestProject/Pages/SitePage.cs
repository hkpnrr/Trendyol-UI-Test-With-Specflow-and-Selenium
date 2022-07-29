using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace SpecflowTestProject.Pages
{
    class SitePage
    {
        public IWebDriver WebDriver { get; set; }

        public SitePage(IWebDriver webDriver)
        {
            WebDriver = webDriver;
        }

        string url = "https://www.trendyol.com";
        string searchString = "ipad air";
        string productName = null;


        public void EnterTheWebSite()
        {


            WebDriver.Manage().Window.Maximize();

            WebDriver.Navigate().GoToUrl(url);
        }

        public void ClosePopup()
        {
            FindElementWithWait(WebDriver, By.ClassName(Utilities.modalClose)).Click();
        }

        public void TypeTheSearchString()
        {
            FindElementWithWait(WebDriver, By.ClassName(Utilities.searchBox)).SendKeys(searchString);
        }

        public void ClickFirstSearchResult()
        {
            FindElementWithWait(WebDriver, By.ClassName(Utilities.suggestion)).Click();
        }

        public void CloseColorOptionPopup()
        {
            IWebElement popup = null;

            try
            {
                popup = FindElementWithWait(WebDriver, By.ClassName(Utilities.popUp));
            }
            catch (Exception)
            {


            }
            finally
            {
                if (popup != null)
                {
                    FindElementWithWait(WebDriver, By.ClassName(Utilities.cardWrapper)).Click();
                }
            }
        }

        public void ClickFirstProduct()
        {
            FindElementWithWait(WebDriver, By.ClassName(Utilities.cardWrapper)).Click();
        }

        public void SwitchBrowserTab()
        {
            WebDriver.SwitchTo().Window(WebDriver.WindowHandles[1]);
            Thread.Sleep(1000);
        }

        public void AddToBasket()
        {
            FindElementWithWait(WebDriver, By.ClassName(Utilities.addToBasket)).Click();
            
        }

        public void SaveNameOfProduct()
        {
            productName = FindElementWithWait(WebDriver, By.XPath(Utilities.productNameXPath)).Text;

        }

        public void ClickAccountBasketButton()
        {
            FindElementWithWait(WebDriver, By.ClassName(Utilities.accountBasket)).Click();


            Thread.Sleep(1000);
        }

        public void deleteAddedProduct()
        {
            var basketItems = FindElementsWithWait(WebDriver, By.ClassName(Utilities.basketItem));


            foreach (var item in basketItems)
            {


                var splittedTempProductName = item.FindElement(By.ClassName(Utilities.item)).Text.Split();

                if (productName.Contains(splittedTempProductName[1]))
                {

                    FindElementWithWait(WebDriver, By.ClassName(Utilities.trash)).Click();
                    break;
                }


            }
            FindElementWithWait(WebDriver, By.XPath(Utilities.delete)).Click();
        }

        public void CloseWindow()
        {
            WebDriver.Quit();
        }

        public static IWebElement FindElementWithWait(IWebDriver driver, By by)
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5)).Until(x => x.FindElement(by));

            if (wait != null)
            {
                return wait;
            }
            else
            {
                return null;
            }
        }

        public static System.Collections.ObjectModel.ReadOnlyCollection<IWebElement> FindElementsWithWait(IWebDriver driver, By by)
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5)).Until(x => x.FindElements(by));

            if (wait != null)
            {
                return wait;
            }
            else
            {
                return null;
            }
        }


    }

    

    public static class Utilities
    {
        public static string modalClose = "modal-close";
        public static string searchBox = "search-box";
        public static string suggestion = "suggestion";
        public static string popUp = "popup";
        public static string cardWrapper = "p-card-wrppr";
        public static string addToBasket = "add-to-basket";
        public static string productNameXPath = "//h1[@class='pr-new-br']/span[1]";
        public static string accountBasket = "account-basket";
        public static string basketItem = "pb-basket-item";
        public static string item = "pb-item";
        public static string trash = "i-trash";
        public static string delete = "//button[text()='Sil']";


    }
}
