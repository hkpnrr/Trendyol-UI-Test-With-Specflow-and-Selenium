using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using System;
using TechTalk.SpecFlow;
using SpecflowTestProject.Pages;

namespace SpecflowTestProject.Steps
{
    [Binding]
    public class E_CommerceSteps
    {
        SitePage page = null;
        [Given(@"enter the website")]
        public void GivenEnterTheWebsite()
        {
            IWebDriver webDriver = new FirefoxDriver();
            //IWebDriver webDriver = new ChromeDriver();
            page = new SitePage(webDriver);
            page.EnterTheWebSite();
        }
        
        [Given(@"close popup")]
        public void GivenClosePopup()
        {
            page.ClosePopup();
        }
        
        [Given(@"type the sentence for search product")]
        public void GivenTypeTheSentenceForSearchProduct()
        {
            page.TypeTheSearchString();
        }
        
        [When(@"click first search result")]
        public void WhenClickFirstSearchResult()
        {
            page.ClickFirstSearchResult();
        }
        
        [When(@"if color options of product popup exists close popup")]
        public void WhenİfColorOptionsOfProductPopupExistsClosePopup()
        {
            page.CloseColorOptionPopup();
        }
        
        [When(@"click first product")]
        public void WhenClickFirstProduct()
        {
            page.ClickFirstProduct();
        }
        
        [When(@"switch browser tab")]
        public void WhenSwitchBrowserTab()
        {
            page.SwitchBrowserTab();
        }
        
        [When(@"click add to basket button")]
        public void WhenClickAddToBasketButton()
        {
            page.AddToBasket();
        }
        
        [Then(@"save name of product")]
        public void ThenSaveNameOfProduct()
        {
            page.SaveNameOfProduct();
        }
        
        [When(@"click account basket button")]
        public void WhenClickAccountBasketButton()
        {
            page.ClickAccountBasketButton();
        }
        
        [When(@"find added product and delete it")]
        public void WhenFindAddedProductAndDeleteİt()
        {
            page.deleteAddedProduct();
        }
        
        [Then(@"close window")]
        public void ThenCloseWindow()
        {
            page.CloseWindow();
        }

    }
}
