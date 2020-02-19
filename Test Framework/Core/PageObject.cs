using Epiq.ETS.TCMS.Anywhere.Testing.E2ETest.Test_Framework.Core;
using Epiq.ETS.TCMS.Anywhere.Testing.E2ETest.Test_Framework.Steps.Common;
using OpenQA.Selenium;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace Epiq.ETS.TCMS.Anywhere.Testing.E2ETest.Test_Framework.Pages
{    
    /**
     * This Class is the base for all Page Objects in the framework and encapsulates Selenium common operations that are going to be re-used 
     * all over the Page Object's code.
     *
     * Note that this class is site and application "agnostic": all code related to an specific application under test should go to a "<Project>PageObject" clas.
     */
    public abstract class PageObject
    {
        private const int defaultTimeoutSingleElement = 25;
        private const int defaultTimeoutGroupElement = 35;

        protected IWebDriver driver;

        private string universalPageTitle = "//title[contains(text(),'{0}')]";

        public PageObject(IWebDriver driver, string pageExpectedTitle)
        {
            //set the driver
            this.driver = driver;
            this.Pause(1);

            //set focus to opened window
            this.driver.SwitchTo().Window(this.driver.CurrentWindowHandle);           

            //wait for the page to be loaded and contain the correct title
            if (pageExpectedTitle != null)
            {
                int timeToWaitForPage = defaultTimeoutGroupElement;
                timeToWaitForPage = timeToWaitForPage * 2;                

                //Click on Login page to load - for IE only
                if ((driver.GetType() == typeof(InternetExplorerDriver)) && (pageExpectedTitle.Contains("Login")))
                {
                    timeToWaitForPage = timeToWaitForPage * 5;
                    driver.FindElement(By.XPath("//body")).Click();
                    TestsLogger.Log("[IEDriver] Click on <body> tag was made");
                }
                string titleLocator = string.Format(universalPageTitle, pageExpectedTitle);
                this.WaitForElementToBePresent(By.XPath(titleLocator), timeToWaitForPage);
            }
        }        

        public string Title
        {            
            get { return this.driver.Title; }
        }

        public void Reload()
        {
            driver.Navigate().Refresh();                      
        }

        public void ClearAndType(IWebElement input, string text)
        {
            //clear the input prior to type in
            input.Clear();
            //do not change this! - type char by char or face the consequences: fake failures
            this.TypeInCharByChar(input, text);            
        }

        public void SelectAndDeleteCompleteText(IWebElement input)
        {
            //Select the complete Text and deletes 
            input.SendKeys(Keys.LeftControl + "a" + Keys.Delete);
        }
        public void SelectAndDeleteCompleteText(By input)
        {          
            driver.FindElement(input).SendKeys(Keys.LeftControl + "a" + Keys.Delete);
        }

        public void TypeIn(IWebElement input, string text)
        {
            // when typing into a text field on IE, type each character instead of the whole text
            if (driver.GetType() == typeof(InternetExplorerDriver))
            {
                for (int counter = 0; counter < text.Length; counter++)
                {
                    input.SendKeys("" + text[counter]);
                }
            }
            else {
                input.SendKeys(text);
            }
        }        

        public void TypeInCharByChar(IWebElement input, string text)
        {
            //type each character instead of the whole text            
            for (int counter = 0; counter < text.Length; counter++)
            {
                input.SendKeys("" + text[counter]);
            }            
        }

        //Waits for an element to be present on the DOM for SINGLE_ELEMENT_DEFAULT_TIMEOUTseconds, then returns its IWebElement
        protected IWebElement WaitForElementToBePresent(By by)
        {
            return this.WaitForElementsToBePresent(by, defaultTimeoutSingleElement).First();
        }

        protected IWebElement WaitForElementToBePresent(By by, int timeout)
        {
            return this.WaitForElementsToBePresent(by, timeout).First();
        }

        //Waits for all the elements with the given locator to be present and returns a list
        protected IReadOnlyCollection<IWebElement> WaitForElementsToBePresent(By by)
        {
            return this.WaitForElementsToBePresent(by, defaultTimeoutSingleElement);
        }

        //Waits for an element to be present on the DOM for the given time, then returns its IWebElement
        protected IReadOnlyCollection<IWebElement> WaitForElementsToBePresent(By by, int seconds)
        {

            string logMsg = "WaitForElementToBePresent " + by.ToString() + " for " + seconds + " seconds top.";
            TestsLogger.Log(logMsg);
            try
            {
                WebDriverWait webDriverWait = new WebDriverWait(this.driver, GetTimeSpanInMilliseconds(seconds));
                webDriverWait.IgnoreExceptionTypes(typeof(NoSuchElementException)); //to avoid instant failure breaks
                return webDriverWait.Until(ExpectedConditions.PresenceOfAllElementsLocatedBy(by));
            }
            catch (WebDriverException exception)
            {
                throw new MissingElementException("Exception when performing: "+logMsg, exception);
            }           
        }

        //Waits for an element for SINGLE_ELEMENT_DEFAULT_TIMEOUT seconds to be visible on the UI, then returns its IWebElement
        protected IWebElement WaitForElementToBeVisible(By by)
        {
            return this.WaitForElementToBeVisible(by, defaultTimeoutSingleElement);
        }

        //Waits for an element to be visible on the UI for the given time, then returns its IWebElement
        protected IWebElement WaitForElementToBeVisible(By by, int seconds)
        {
            string logMsg = "WaitForElementToBeVisible " + by.ToString() + " for " + seconds + " seconds top.";
            TestsLogger.Log(logMsg);

            try
            {
                WebDriverWait webDriverWait = new WebDriverWait(this.driver, GetTimeSpanInMilliseconds(seconds));
                webDriverWait.IgnoreExceptionTypes(typeof(NoSuchElementException)); //to avoid instant failure breaks
                return webDriverWait.Until(ExpectedConditions.ElementIsVisible(by));
            }
            catch (WebDriverException exception)
            {
                throw new MissingElementException("Exception when performing: " + logMsg, exception);
            }

        }

        //Waits for a SET of elements to be visible and returns an IWebElement list

        protected IReadOnlyCollection<IWebElement> WaitForElementsToBeVisible(By by)
        {
            return this.WaitForElementsToBeVisible(by, defaultTimeoutGroupElement);
        }


        protected IReadOnlyCollection<IWebElement> WaitForElementsToBeVisible(By by, int seconds)
        {
            string logMsg = "WaitForElementsToBeVisible " + by.ToString() + " for " + seconds + " seconds top.";
            TestsLogger.Log(logMsg);

            try
            {
                WebDriverWait webDriverWait = new WebDriverWait(this.driver, GetTimeSpanInMilliseconds(seconds));
                webDriverWait.IgnoreExceptionTypes(typeof(NoSuchElementException)); //to avoid instant failure breaks
                return webDriverWait.Until(ExpectedConditions.VisibilityOfAllElementsLocatedBy(by));
            }
            catch (WebDriverException exception)
            {
                throw new MissingElementException("Exception when performing: " + logMsg, exception);
            }
        }

        //Waits for an element to ve visble AND have some (ANY) text
        protected IWebElement WaitForElementToBeVisibleAndHaveSomeText(By by)
        {
            return this.WaitForElementToBeVisibleAndHaveSomeText(by, defaultTimeoutSingleElement);
        }
           
        private IWebElement WaitForElementToBeVisibleAndHaveSomeText(By by, int seconds)
        {
            string logMsg = "WaitForElementToBeVisibleAndHaveSomeText " + by.ToString() + " for " + seconds + " seconds top.";
            TestsLogger.Log(logMsg);

            try {
                WebDriverWait webDriverWait = new WebDriverWait(this.driver, GetTimeSpanInMilliseconds(seconds));
                webDriverWait.IgnoreExceptionTypes(typeof(NoSuchElementException)); //to avoid instant failure breaks
                return webDriverWait.Until<IWebElement>((d) =>
                {
                    IWebElement element = d.FindElement(by);
                    if (element.Displayed &&
                        element.Enabled &&
                        element.Text.Length > 0)
                    {
                        return element;
                    }

                    throw new WebDriverTimeoutException();
                });
            }
            catch (WebDriverException exception)
            {
                throw new MissingElementException("Exception when performing: " + logMsg, exception);
            }
        }

        //Waits for an element to be visible and have the exact given text for the default amount of time
        protected IWebElement WaitForElementToHaveText(By by, string text)
        {
            return WaitForElementToHaveText(by, text, defaultTimeoutSingleElement);

        }

        //waits for an element to be visible and have the exact given text for the given amount of time
        protected IWebElement WaitForElementToHaveText(By by, string text, int seconds)
        {
            string logMsg = "WaitForElementToHaveText " + by.ToString() + " : '"+text+"' for " + seconds + " seconds top.";
            TestsLogger.Log(logMsg);
            try {
                IWebElement we = WaitForElementToBeVisible(by,seconds);
                WebDriverWait webDriverWait = new WebDriverWait(this.driver, GetTimeSpanInMilliseconds(seconds));
                webDriverWait.IgnoreExceptionTypes(typeof(NoSuchElementException)); //to avoid instant failure breaks
                webDriverWait.Until(ExpectedConditions.TextToBePresentInElementLocated(by, text));
                return we;
            }
            catch (WebDriverException exception)
            {
                throw new MissingElementException("Exception when performing: " + logMsg, exception);
            }
        }

        //Waits for an element to be visible and enabled on the UI for the given time, then and returns its IWebElement
        protected IWebElement WaitForElementToBeClickeable(By by)
        {
            return WaitForElementToBeClickeable(by, defaultTimeoutSingleElement);

        }

        //Waits for an element to be visible and enabled on the UI for the given time, then and returns its IWebElement
        protected IWebElement WaitForElementToBeClickeable(By by, int seconds)
        {
            string logMsg = "WaitForElementToBeClickeable " + by.ToString() + " for " + seconds + " seconds top.";
            TestsLogger.Log(logMsg);
            try { 
                WebDriverWait webDriverWait = new WebDriverWait(this.driver, GetTimeSpanInMilliseconds(seconds));
                webDriverWait.IgnoreExceptionTypes(typeof(NoSuchElementException)); //to avoid instant failure breaks
                return webDriverWait.Until(ExpectedConditions.ElementToBeClickable(by));
            }
            catch (WebDriverException exception)
            {
                throw new MissingElementException("Exception when performing: " + logMsg, exception);
            }
        }

        //waits for the requested element to (be visible and) have the attribute value until it appears or times out
        protected IWebElement WaitForElementToHaveAttributeValue(By by, string attribute, string value)
        {
            return WaitForElementToHaveAttributeValue(by, attribute, value, defaultTimeoutSingleElement);
        }

        //waits for the requested element to (be visible and) have the attribute value until it appears or times out
        protected IWebElement WaitForElementToHaveAttributeValue(By by, string attribute, string value, int seconds)
        {
            string logMsg = "WaitForElementToHaveAttributeValue " + by.ToString() + ". Attribute = " + attribute + ", Value = " + value + ". Waiting for " + seconds + " seconds top.";
            TestsLogger.Log(logMsg);
            try { 
                WebDriverWait webDriverWait = new WebDriverWait(this.driver, GetTimeSpanInMilliseconds(seconds));
                webDriverWait.IgnoreExceptionTypes(typeof(NoSuchElementException)); //to avoid instant failure breaks

                //TODO INVESTIGATE if this can be done with ExpectedConditions.ElementToHaveTextValue
                return webDriverWait.Until<IWebElement>((d) =>
                {
                    IWebElement element = d.FindElement(by);
                    if (element.Displayed &&
                        element.Enabled &&
                        element.GetAttribute(attribute) == value)
                    {
                        return element;
                    }

                    throw new WebDriverTimeoutException();
                });
            }
            catch (WebDriverException exception)
            {
                throw new MissingElementException("Exception when performing: " + logMsg, exception);
            }
        }

        //Waits for an element to dissappear from the UI for the given time, then returns its IWebElement
        protected void WaitForElementToDissapear(By by)
        {
           WaitForElementToDissapear(by,defaultTimeoutSingleElement);
           
        }

        //Waits for an element to dissappear from the UI for the given time
        protected void WaitForElementToDissapear(By by, int seconds)
        {
            string logMsg = "WaitForElementToDissapear " + by.ToString() + " for " + seconds + " seconds top.";
            if (by.ToString() != "By.CssSelector: div.blockUI.blockOverlay")
            {
                TestsLogger.Log(logMsg);
            }
            try { 
                WebDriverWait webDriverWait = new WebDriverWait(this.driver, GetTimeSpanInMilliseconds(seconds));
                webDriverWait.IgnoreExceptionTypes(typeof(NoSuchElementException)); //to avoid instant failure breaks
                webDriverWait.Until(ExpectedConditions.InvisibilityOfElementLocated(by));
            }
            catch (WebDriverException exception)
            {
                throw new MissingElementException("Exception when performing: " + logMsg, exception);
            }
        }


        //TODO add another method to waitForElementToLooseAttributeValue
        //-> See if loose attribute value can be modeled with the existent ExpectedCondition.ElementToHaveTextValue


        //waits for the requested element to (be visible and) loose the attribute until it appears or times out
        protected IWebElement WaitForElementToLooseAttribute(By by, string attribute)
        {
            return WaitForElementToLooseAttribute(by, attribute, defaultTimeoutSingleElement);
        }

        //waits for the requested element to (be visible and) loose the attribute until it appears or times out
        protected IWebElement WaitForElementToLooseAttribute(By by, string attribute, int seconds)
        {
            string logMsg = "WaitForElementToLooseAttribute " + by.ToString() + ". Attribute = " + attribute + " for " + seconds + " seconds top.";
            TestsLogger.Log(logMsg);
            try {
                WebDriverWait webDriverWait = new WebDriverWait(this.driver, GetTimeSpanInMilliseconds(seconds));
                webDriverWait.IgnoreExceptionTypes(typeof(NoSuchElementException)); //to avoid instant failure breaks
                return webDriverWait.Until<IWebElement>((d) =>
                {
                    IWebElement element = d.FindElement(by);
                    if (element.Displayed &&
                        element.Enabled &&
                        element.GetAttribute(attribute) == null)
                    {
                        return element;
                    }

                    throw new WebDriverTimeoutException();
                });
            }
            catch (WebDriverException exception)
            {
                throw new MissingElementException("Exception when performing: " + logMsg, exception);
            }
        }

       
        public Link GetLinkByExactTextAndURL(string text, string url)
        {
            //wait for the element to be visible and activem, then check the text
            this.WaitForElementToBeClickeable(By.PartialLinkText(text));
            IWebElement we = this.WaitForElementToHaveAttributeValue(By.PartialLinkText(text), "href", url);
            return new Link(we.Text, we.GetAttribute("href"));
        }


        public Link GetLink(By by)
        {
            IWebElement we = this.WaitForElementToBeClickeable(by);
            return new Link(we.GetAttribute("href"), we.Text);
            
        }

        public Link GetLinkByExactText(string linkText)
        {
            return this.GetLink(By.LinkText(linkText));
        }

        public Link GetLinkByPartialText(string linkText)
        {
            return GetLink(By.PartialLinkText(linkText));
        }

        //Common Pause method, do not use insted of Wait Conditions
        public void Pause(int seconds)
        {
            Thread.Sleep(seconds * 1000);
        }

        private TimeSpan GetTimeSpanInMilliseconds(int seconds)
        {
            //return new TimeSpan(0, 0, 0, 0, seconds * 1000);
            return TimeSpan.FromSeconds(seconds);
        }

        protected List<string> GetListOfTextsFromWebElements(IReadOnlyCollection<IWebElement> readOnlyCollection)
        {
            List<string> textlist = new List<string>();
            if (readOnlyCollection != null)
            {
                foreach (IWebElement option in readOnlyCollection)
                {
                    string text = option.Text;
                    textlist.Add(text);
                }
            }

            return textlist;
        }
                
        protected bool IsElementVisible(By by)
        {
            try
            {
                this.WaitForElementToBeVisible(by);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        protected void MoveToViewElement(IWebElement element)
        {
            Actions moveToviewElement = new Actions(driver);
            moveToviewElement.MoveToElement(element).Build().Perform();            
        }

        protected void MoveToViewElementandSAndkeys(IWebElement element,string value)
        {
            Actions moveToviewElement = new Actions(driver);
            moveToviewElement.MoveToElement(element).Click().SendKeys(value).Build().Perform();
        }

        protected void MoveToElementAndClick(IWebElement element)
        {
            Actions moveToviewElement = new Actions(driver);
            moveToviewElement.MoveToElement(element).Click().Build().Perform();                       
        }

        protected void MoveToElementAndClick(IWebElement element,int x,int y)
        {
            Actions moveToviewElement = new Actions(driver);
            moveToviewElement.MoveByOffset(x,y).Click(element).Build().Perform();
        }
        
        public void ScrollWindowBy(int X, int Y)
        {
            ((IJavaScriptExecutor)driver).ExecuteScript("window.scrollBy("+X+","+Y+")");
            Thread.Sleep(500);
        }

        protected void JSMoveToViewElement(IWebElement element) {
            ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].scrollIntoView(true);", element);
            Thread.Sleep(500);
        }

        protected void KeysDownToSelect(IWebElement element)
        {
            Pause(2);
            Actions action = new Actions(driver);
            action.MoveToElement(element).SendKeys(element,Keys.ArrowDown+Keys.Enter+Keys.Escape).Build().Perform();
        }
        
        protected void DragAndDropToOffsetOfElement(IWebElement areaToScroll) {
            Actions builder = new Actions(driver);
            builder.DragAndDropToOffset(areaToScroll, 0, -100).Build().Perform();
        }

        protected void clickNotVisualizedElement(IWebElement element)
        {
            ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].click();", element);
        }

        protected bool IsFocusOnElement(IWebElement field)
        {
            return field.Equals(driver.SwitchTo().ActiveElement());
        }

        protected void PressKeyOnActiveElement(string keys)
        {
            IWebElement activeElem = driver.SwitchTo().ActiveElement();
            Actions builder = new Actions(driver);
            builder.MoveToElement(activeElem).SendKeys(keys).Build().Perform();
        }

        public void PressEscapeKey()
        {
            this.PressKeyOnActiveElement(Keys.Escape);            
        }


        public void PressTabKey()
        {
            this.PressKeyOnActiveElement(Keys.Tab);
        }

        public void PressDeleteKey()
        {
            this.PressKeyOnActiveElement(Keys.Delete);
        }

        public void PressBackSpaceKey()
        {
            this.PressKeyOnActiveElement(Keys.Backspace);
        }

        protected void SelectFirstNDigits(int count, IWebElement valueField)
        {
            string positions = "";
            for (int counter = 0; counter < count; counter++)
            {
                positions += Keys.ArrowRight;
            }
            Actions actions = new Actions(driver);
            actions.Click(valueField).SendKeys(Keys.Home).Build().Perform();
            actions.SendKeys(Keys.Shift + positions).Build().Perform();
        }

        protected void SelectAllDigits(IWebElement valueField)
        {            
            Actions actions = new Actions(driver);
            actions.Click(valueField).SendKeys(Keys.Home).Build().Perform();
            actions.SendKeys(Keys.Shift+Keys.End).Release().Build().Perform();
        }

        public void ScrollDownToPageBottom()
        {
            ((IJavaScriptExecutor)driver).ExecuteScript("window.scrollBy(0,2000)");
            Thread.Sleep(500);
        }
        public void ScrollDown()
        {
            ((IJavaScriptExecutor)driver).ExecuteScript("window.scrollBy(0, 250)");
            Thread.Sleep(1000);
        }

        public void ScrollUpToPageTop()
        {
            ((IJavaScriptExecutor)driver).ExecuteScript("window.scrollBy(0,-300)","");
            Thread.Sleep(500);
        }

        public string GetAttrubuteValue(IWebElement element,string value="value")
        {
            return Convert.ToString(((IJavaScriptExecutor)driver).ExecuteScript($"return arguments[0].getAttribute('{value}');", element));           

        }

        public void JavaScriptClick(IWebElement element)
        {
            ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].click();",element);
        }
        public string GetCurrentDate()
        {
          string DateTime= System.DateTime.Now.ToString("yyyy-MM-dd");
            return DateTime;
        }
    }
}