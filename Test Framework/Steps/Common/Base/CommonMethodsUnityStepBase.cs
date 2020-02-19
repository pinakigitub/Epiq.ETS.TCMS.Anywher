using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OpenQA.Selenium;
using TechTalk.SpecFlow;
using NUnit.Framework;
using OpenQA.Selenium.Support.UI;
using System.Data;
using System.Data.SqlClient;
using System.Text.RegularExpressions;
using System.Collections.ObjectModel;
using Epiq.ETS.TCMS.Anywhere.Testing.E2ETest.Test_Framework.Core;
using System.Threading;
using OpenQA.Selenium.Interactions;
using System.Configuration;

namespace Epiq.ETS.TCMS.Anywhere.Testing.E2ETest.Test_Framework.Steps.Common
{
    [Binding]
    public abstract class CommonMethodsUnityStepBase:StepBase
    {
        // Metodos para Dropdown
        //(constructor se pasa el id)

        //Abrir el dropdown(id_dropdown) //click en la flechita
        //Tipear algo en el input(id_dropdown, texto)
        //Get lista de resultados(id_dropdown): List<string>
        //Seleccionar un resultado con Click(id_dropdown, texto)
        //Seleccionar un resultado con Tab(id_dropdown, texto)
        //Seleccionar un resultado con Enter(id_dropdown, texto)

        //Buscar y seleccionar por texto(id_dropdown, texto) //click + tipear + seleccionar resultado (text)


        //Ejemplo:

        //pulic class commonStepsFran
        //        {

        //private string XPathPrefix = "//select2//select[@id[contains(.,'" + id_dropdown + "')]]";

            //Abrir el dropdown
            protected static void OpenSelect2DropDown(string XPathPrefix)
            {
                string arrowDropdown = XPathPrefix + "/..//span/b";
                IWebElement element = createVisibleWebElementByXpath(arrowDropdown);
                element.Click();
            }

            //Tipear algo en el input
            protected static void TypeInSelect2InputField(string XPathPrefix, string text)
            {
                string textInput = XPathPrefix + "//span/input[@class='select2-search__field']";
                IWebElement element = createVisibleWebElementByXpath(textInput);
                typeStringByChar(text, element);
            }

//----
//Opcionales(si se están usando en algun lado)

//    Seleccionar resultado por posicion(posicion)


        protected static void clickNotVisualizedElement(IWebElement element)
        {
            ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].click();", element);
        }

        protected static void ScrollToTopOfThePage()
        {
            ((IJavaScriptExecutor)driver).ExecuteScript("window.scrollBy(0,-10000)", "");
        }

        protected static void ScrollPageUpOrDown(string ScrollPixelsValue)
        {
            ((IJavaScriptExecutor)driver).ExecuteScript("window.scrollBy(0,"+ ScrollPixelsValue + ")", "");
        }

        protected static void ScrollToBottomOfThePage()
        {
            ((IJavaScriptExecutor)driver).ExecuteScript("window.scrollBy(0,1000)", "");
        }

        protected static void ignoreAllExceptions()
        {
            try
            {
                // code 
            }
            catch { }
        }

        protected static void drapAndDropElementOrWindow(IWebElement element, int horizontalMove, int verticalMove)
        {
            Actions move = new Actions(driver);
            move.DragAndDropToOffset(element, horizontalMove, verticalMove).Build().Perform();
        }

        protected static void moveElementHorizontalOrVertical(IWebElement element, int horizontalMove, int verticalMove)
        {
            Actions move = new Actions(driver);
            move.MoveToElement(element, horizontalMove, verticalMove).Build().Perform();
        }

        protected static string createRandomNumber()
        {
            Random rnd = new Random();
            int randomNumberInt = rnd.Next(100, 999); // creates a number between 1 and 1000
            return randomNumberInt.ToString();
        }

        protected static int createRandomNumberWithinSpecificRange(int topRange)
        {
            Random rnd = new Random();
            int randomNumberInt = rnd.Next(0, topRange); // creates a number between 0 and Assigned Top Range
            return randomNumberInt;
        }

        protected static int createRandomIntFromMinorToTopRange(int minorRange, int topRange)
        {
            Random rnd = new Random();
            int randomNumberInt = rnd.Next(minorRange, topRange); // creates a number between 0 and Assigned Top Range
            return randomNumberInt;
        }

        protected static void GoToTopOfThePage()
        {
            Actions builder = new Actions(driver);
            builder.KeyDown(Keys.Control).SendKeys(Keys.Home).KeyUp(Keys.Control).Perform();
        }

        protected static string setDBDateToUIFormat(DataRowCollection rows, int rowNumber, int itemArrayNumber)
        {
            DateTime dt = DateTime.Parse(rows[rowNumber].ItemArray[itemArrayNumber].ToString().ToLower());
            string fomratedDate = String.Format("{0:MM/dd/yyyy}", dt);
            return fomratedDate;
        }

        protected static string setDBTimeToUIFormat(DataRowCollection rows, int rowNumber, int itemArrayNumber)
        {
            DateTime time = Convert.ToDateTime(rows[rowNumber].ItemArray[itemArrayNumber].ToString());
            TimeSpan timespan = new TimeSpan(00, 00, 00);
            time.Add(timespan);
            string displayTime = time.ToString("hh:mm tt"); // It will give "03:00 AM"
            return displayTime;
        }

        protected static string removeLastCharsFromString(string original, int charsToRemove)
        {
            string lastChars = original.Substring(original.Length - charsToRemove);
            return lastChars;
        }

        protected static string removeFirstCharsFromString(string original)
        {
            string lastChars = original.Remove(0,1);
            return lastChars;
        }

        protected static void focusOnElement(IWebElement element)
        {
            ((IJavaScriptExecutor)driver).ExecuteScript("document.getElementById('" + element.GetAttribute("id").ToString() + "').focus()");
        }

        protected static void scrollToElement(IWebElement element)
        {
            ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].scrollIntoView(true);", element);
        }

        protected static void pleaseWaitSignDissapear()
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(60));
            Assert.True(wait.Until(ExpectedConditions.InvisibilityOfElementWithText(By.XPath("//div[@class='blockUI blockMsg block Page']/p"), "Please Wait...")));
        }

        protected static bool isElementPresent(string xpath)
        {
            int Size = driver.FindElements(By.XPath("" + xpath + "")).Count;
            bool isPresent = Size > 0;
            return isPresent;
        }

        protected void WaitForBlockOverlayToDissapear()
        {
            //Message 'Please wait' is appearing multiple times, 
            //expecting it as many times as the max we could define per the current pages Ajax calls
            //Thread.Sleep(2000);
            TestsLogger.Log("WaitForBlockOverlayToDissapear with locator " + By.CssSelector("div.blockUI.blockOverlay") + " for " + 65 + " secs (" + 30 + " times)");
            for (int i = 0; i < 30; i++)
            {
                this.WaitForElementToDissapear(By.CssSelector("div.blockUI.blockOverlay"), 65);
            }
        }

        //Waits for an element to dissappear from the UI for the given time
        protected void WaitForElementToDissapear(By by, int seconds)
        {
            string logMsg = "WaitForElementToDissapear " + by.ToString() + " for " + seconds + " seconds top.";
            if (by.ToString() != "By.CssSelector: div.blockUI.blockOverlay")
            {
                TestsLogger.Log(logMsg);
            }
            try
            {
                WebDriverWait webDriverWait = new WebDriverWait(driver, GetTimeSpanInMilliseconds(seconds));
                webDriverWait.IgnoreExceptionTypes(typeof(NoSuchElementException)); //to avoid instant failure breaks
                webDriverWait.Until(ExpectedConditions.InvisibilityOfElementLocated(by));
            }
            catch (WebDriverException exception)
            {
                throw new MissingElementException("Exception when performing: " + logMsg, exception);
            }
        }

        private TimeSpan GetTimeSpanInMilliseconds(int seconds)
        {
            //return new TimeSpan(0, 0, 0, 0, seconds * 1000);
            return TimeSpan.FromSeconds(seconds);
        }

        protected static void waitElementIsVisibleByXPath(string xpath)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(25));
            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath(xpath)));
        }

        protected static bool waitElementIsInvisibleByXPath(string xpath, string text)
        {
            bool isVisible = false;
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(25));
            Assert.True(wait.Until(ExpectedConditions.InvisibilityOfElementWithText(By.XPath(xpath), text)));
            return isVisible;
        }

        protected static void enterTextIntoField(string valueToType, IWebElement element)
        {
            if (valueToType != "")
            {
                Thread.Sleep(100);
                element.Click();
                element.Clear();
                typeStringByChar(valueToType, element);
            }
            else
            {
                TestsLogger.Log("No Need to enter value into field");
            }
        }

        protected static void clickLabelEqualText(string text)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(25));
            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//*[text()='" + text + "']"))).Click();
        }

        protected static void clickLabelContainingText(string text)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(25));
            IWebElement label = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//*[contains(text(), '" + text + "')]")));
            clickNotVisualizedElement(label);
        }

        protected static void assertTextIsVisible(string text)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(25));
            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//*[contains(text(), '" + text + "')]")));
        }

        protected static void checkElementWithTextIsDisplayed(string text)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(25));
            IWebElement element = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//*[contains(text(),'" + text + "')]")));
            Assert.True(element.Displayed);
        }

        protected static void scrollToElementWithText(string text)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(25));
            IWebElement element = createExistentWebElementByXpath("//*[text()='" + text + "']");
            ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].scrollIntoView(true);", element);
        }

        protected static ReadOnlyCollection<IWebElement> createVisibleElementsCollectionByXpath(string xpath)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(25));
            ReadOnlyCollection<IWebElement> element = wait.Until(ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.XPath("" + xpath + "")));
            return element;
        }

        protected static ReadOnlyCollection<IWebElement> createPresentElementsCollectionByXpath(string xpath)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(25));
            ReadOnlyCollection<IWebElement> element = wait.Until(ExpectedConditions.PresenceOfAllElementsLocatedBy(By.XPath("" + xpath + "")));
            return element;
        }

        protected static IWebElement createVisibleWebElementByXpath(string xpath)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(25));
            IWebElement element = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("" + xpath + "")));
            return element;
        }

        protected static List<IWebElement> convertCollectionToListWebElement(ReadOnlyCollection<IWebElement> collection)
        {
            List<IWebElement> myList = new List<IWebElement>(collection);
            return myList;
        }

        protected static List<string> convertCollectionToList(ReadOnlyCollection<IWebElement> collection)
        {
            List<string> myList = new List<string>();

            foreach (var item in collection)
            {
                myList.Add(item.Text);
            }

            return myList;
        }

        protected static IWebElement createVisibleWebElementById(string id)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(25));
            IWebElement element = wait.Until(ExpectedConditions.ElementIsVisible(By.Id("" + id + "")));
            return element;
        }

        protected static IWebElement createExistentWebElementByXpath(string xpath)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(25));
            IWebElement element = wait.Until(ExpectedConditions.ElementExists(By.XPath("" + xpath + "")));
            return element;
        }

        protected static IWebElement createExistentWebElementById(string id)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(25));
            IWebElement element = wait.Until(ExpectedConditions.ElementExists(By.Id("" + id + "")));
            return element;
        }

        protected static void waitElementIsInvisibleById(string id, string text)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(25));
            Assert.True(wait.Until(ExpectedConditions.InvisibilityOfElementWithText(By.Id(id), text)));
        }

        protected static void checkElementIsDisabled(IWebElement element)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(25));
            Assert.True(element.GetAttribute("disabled") != null);

        }

        protected static bool assertElementIsDisabled(IWebElement element)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(25));
            Assert.True(element.GetAttribute("disabled") != null);
            return true;
        }

        protected static void ignoreNoSuchElementException()
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
            wait.IgnoreExceptionTypes(typeof(NoSuchElementException));
        }

        protected static void assertEachElementComposedTextInUIIsContainedInDB(IReadOnlyCollection<IWebElement> collection, DataRowCollection rows, int itemArrayNumber1, int itemArrayNumber2, string composedText)
        {
            bool wasFound = false;
            foreach (var item in collection)
            {
                string elementInUI = item.Text.TrimEnd();

                foreach (DataRow row in rows)
                {
                    string elementInDB = row.ItemArray[itemArrayNumber1].ToString() + composedText + row.ItemArray[itemArrayNumber2].ToString();
                    if (elementInUI.Contains(elementInDB))
                    {
                        wasFound = true;
                        break;
                    }
                }
                if (!wasFound)
                {
                    Assert.Fail("Element " + elementInUI + " was not Found in DB");
                }
            }
        }

        protected static void assertEachElementTextInUIIsContainedInDB(IReadOnlyCollection<IWebElement> collection, DataRowCollection rows, int itemArrayNumber)
        {
            bool wasFound = false;
            foreach (var item in collection)
            {
                string elementInUI = item.Text.TrimEnd();
                string elementInDB = "";
                if (elementInUI.Contains("$") || elementInUI.Contains("..."))
                {
                    elementInUI = elementInUI.Replace("$", "").Replace(",", "").Replace("...","");
                }

                foreach (DataRow row in rows)
                {
                    elementInDB = row.ItemArray[itemArrayNumber].ToString().Replace(".0000",".00");
                    if (elementInDB == " ")
                    {
                        elementInDB = "";
                    }
                    if (elementInDB.Contains("$"))
                    {
                        elementInDB = elementInDB.Replace("$", "").Replace(",", "");
                    }
                    if (elementInUI.Contains(elementInDB))
                    {
                        wasFound = true;
                        break;
                    }
                }
                if (!wasFound)
                {
                    Assert.Fail("Element in UI '" + elementInUI + "' does not contains element in DB '" + elementInDB+"'");
                }
            }
        }

        protected static void assertEachElementTextInDBIsContainedInUI(IReadOnlyCollection<IWebElement> collection, DataRowCollection rows, int itemArrayNumber)
        {
            bool wasFound = false;
            foreach (var item in collection)
            {
                string elementInUI = item.Text.Replace("    ", "").Replace("...","").Replace("\r\n"," ").TrimEnd();
                string elementInDB = "";
                if (elementInUI == "OPEN DATE")
                {
                    elementInUI = "PETITION DATE";
                }

                foreach (DataRow row in rows)
                {
                    elementInDB = row.ItemArray[itemArrayNumber].ToString();
                    if (elementInDB.Contains(elementInUI))
                    {
                        wasFound = true;
                        break;
                    }
                }
                if (!wasFound)
                {
                    Assert.Fail("Element in DB '" + elementInDB + "' does not contains element in UI '" + elementInUI + "'");
                }
            }
        }

        protected static void assertEachElementTextInUIIsEqualInDB(IReadOnlyCollection<IWebElement> collection, DataRowCollection rows, int itemArrayNumber)
        {
            bool wasFound = false;
            foreach (var item in collection)
            {
                string elementInUI = item.Text.TrimEnd();

                foreach (DataRow row in rows)
                {
                    string elementInDB = row.ItemArray[itemArrayNumber].ToString();
                    if (elementInDB == elementInUI)
                    {
                        wasFound = true;
                        break;
                    }
                }
                if (!wasFound)
                {
                    Assert.Fail("Element " + elementInUI + " was not Found in DB");
                }
            }
        }

        protected static void assertEachElementAttributeInUIExistInDB(IReadOnlyCollection<IWebElement> collection, DataRowCollection rows, int itemArrayNumber, string key)
        {
            bool wasFound = false;
            string elementInDB = "";
            DateTime dateFromDB = DateTime.Today;
            foreach (var item in collection)
            {
                string elementInUI = item.GetAttribute(key).ToString().TrimEnd();

                foreach (DataRow row in rows)
                {
                    string type = row.ItemArray[itemArrayNumber].GetType().ToString();
                    if (type.Contains("DateTime"))
                    {
                        dateFromDB = Convert.ToDateTime(row.ItemArray[itemArrayNumber].ToString());
                        elementInDB = dateFromDB.ToString("MM/dd/yyyy");
                    }
                    else
                    {
                        elementInDB = row.ItemArray[itemArrayNumber].ToString();
                    }

                    if (elementInDB.Contains(elementInUI))
                    {
                        wasFound = true;
                        break;
                    }
                }
                if (!wasFound)
                {
                    Assert.Fail("Element " + elementInUI + " was not Found in DB");
                }
            }
        }

        protected static void assertElementAttributeInUIExistInDBUsingTwoArrayNumbers(IReadOnlyCollection<IWebElement> collection, DataRowCollection rows, int arrayNumberToExtractRow, int arrayNumberToCompare, string key)
        {
            bool wasFound = false;
            foreach (var item in collection)
            {
                string elementIDInUI = item.GetAttribute("id").ToString();
                elementIDInUI = Regex.Replace(elementIDInUI, "(.*)-(.*)-(.*)-(.*)-", "");
                if (elementIDInUI == "0")
                {
                    elementIDInUI = "";
                }
                string elementInUI = item.GetAttribute(key).ToString().TrimEnd();

                foreach (DataRow row in rows)
                {
                    if (row.ItemArray[arrayNumberToExtractRow].ToString() == elementIDInUI)
                    {
                        int rowNumber = rows.IndexOf(row);
                        string elementInDB = setDBDateToUIFormat(rows, rowNumber, arrayNumberToCompare);
                        if (elementInDB.Contains(elementInUI))
                        {
                            wasFound = true;
                            break;
                        }
                    }
                }
                if (!wasFound)
                {
                    Assert.Fail("Element " + elementInUI + " was not Found in DB");
                }
            }
        }

        protected static void assertElementIsDisplayedIfDBValueNotNullInUpperCase(DataRowCollection rows, int rowNumber, int itemArrayNumber, string distinctOfString, IWebElement element)
        {
            if ((rows[rowNumber].ItemArray[itemArrayNumber].ToString() != distinctOfString) && (rows[rowNumber].ItemArray[itemArrayNumber].ToString() == "pro se"))
            {
                string capitalizeMe = rows[rowNumber].ItemArray[itemArrayNumber].ToString();
                string capitalizedString = System.Globalization.CultureInfo.CurrentCulture.TextInfo.ToTitleCase(capitalizeMe);
                Assert.True(element.Text.Contains(capitalizedString.Replace("\r\n", " ").Replace("\n"," ")));
            }
            else if ((rows[rowNumber].ItemArray[itemArrayNumber].ToString() != distinctOfString) && (rows[rowNumber].ItemArray[itemArrayNumber].ToString() != "pro se"))
            {
                Assert.True(element.Text.Replace("\r\n"," ").Contains(rows[rowNumber].ItemArray[itemArrayNumber].ToString().ToUpper().Replace("\r\n"," ").Replace("\n"," ")));
            }
            else
            {
                Assert.True(element.Text.Contains(""));
            }
        }

        protected static void assertElementIsDisplayedIfDBValueNotNullRegularCase(DataRowCollection rows, int rowNumber, int itemArrayNumber, string distinctOfString, IWebElement element)
        {
            if ((rows[rowNumber].ItemArray[itemArrayNumber].ToString() != distinctOfString) && (rows[rowNumber].ItemArray[itemArrayNumber].ToString() == "pro se"))
            {
                string capitalizeMe = rows[rowNumber].ItemArray[itemArrayNumber].ToString();
                string capitalizedString = System.Globalization.CultureInfo.CurrentCulture.TextInfo.ToTitleCase(capitalizeMe);
                Assert.True(element.Text.Contains(capitalizedString.Replace("\r\n", " ").Replace("\n", " ")));
            }
            else if ((rows[rowNumber].ItemArray[itemArrayNumber].ToString() != distinctOfString) && (rows[rowNumber].ItemArray[itemArrayNumber].ToString() != "pro se"))
            {
                string textFromDB = rows[rowNumber].ItemArray[itemArrayNumber].ToString().Replace("\r\n", " ").Replace("   ", "").Replace("\n", " ");
                Assert.True(element.Text.Replace("\r\n", " ").Contains(textFromDB));
            }
            else
            {
                Assert.True(element.Text.Contains(""));
            }
        }

        protected static void assertEachResultContainsSearchedText(IReadOnlyCollection<IWebElement> collection, string value)
        {
            foreach (var item in collection)
            {
                Assert.True(item.Text.Contains(value));
            }
        }

        protected static void selectResultEqualToSearchedText(IReadOnlyCollection<IWebElement> results, string value)
        {
            foreach (var result in results)
            {
                if (result.Text == value)
                {
                    result.Click();
                    break;
                }
            }
        }

        protected static void selectResultContainsSearchedText(IReadOnlyCollection<IWebElement> results, string value)
        {
            foreach (var result in results)
            {
                if (result.Text.Contains(value))
                {
                    result.Click();
                    break;
                }
            }
        }

        protected static string removeCharsFromString(string mainString, int position, int charsToRemove, string newChars)
        {
            var aStringBuilder = new StringBuilder(mainString);
            aStringBuilder.Remove(position, charsToRemove);
            aStringBuilder.Insert(position, newChars);
            mainString = aStringBuilder.ToString();
            return mainString;
        }

        protected static string removeCharsAfterSpecificChar(string input, string specificChar)
        {
            int index = input.IndexOf(specificChar);
            if (index > 0)
                input = input.Substring(0, index);
            return input;
        }

        protected static string convertToDecimalWithCommasFromElement(IWebElement element, string attributeKey)
        {

            int number = Convert.ToInt32(element.GetAttribute(attributeKey).ToString().Replace("$", "").Replace(" ", "").Replace("  ", "").Replace("   ", "").Replace(".", "").Replace(".", ""));
            return Convert.ToDecimal(number).ToString("#,##0.00");
        }

        protected static string convertToDecimalWithCommasFromRows(DataRowCollection rows, int rowNumber, int itemArrayNumber)
        {

            int number = Convert.ToInt32(rows[rowNumber].ItemArray[itemArrayNumber].ToString().Replace("$", "").Replace(" ", "").Replace("  ", "").Replace("   ", "").Replace(".", "").Replace(".", ""));
            return Convert.ToDecimal(number).ToString("#,##0.00");
        }

        protected static void typeStringByChar(string value, IWebElement element)
        {
            char[] x = value.ToCharArray();
            element.Clear();

            foreach (char a in x)
            {
                element.SendKeys(a.ToString());
            }
        }

        protected static void typeLongStringsByChar(string value, IWebElement element)
        {
            char[] x = value.ToCharArray();

            foreach (char a in x)
            {
                element.SendKeys(a.ToString());
            }
        }

        protected static void typeStringByCharInPositionX(string value, IWebElement element, string position)
        {
            if (position == "End")
            {
                element.SendKeys(Keys.Control+Keys.End);
                element.Clear();
            }
            else if (position == "Beginning")
            {
                element.SendKeys(Keys.Control+Keys.Home);
                element.Clear();
            }
            else if (position == "Middle")
            {
                element.SendKeys(Keys.Control+Keys.End);
                for (int i = 0; i < 3; i++)
                {
                    element.SendKeys(Keys.ArrowLeft);
                }
                element.Clear();
            }
            else if (position == "Highlighted")
            {
                element.SendKeys(Keys.Control + "a");
            }
            char[] x = value.ToCharArray();

            foreach (char a in x)
            {
                element.SendKeys(a.ToString());
            }
        }

        protected static void assertTextForEachItem(IReadOnlyCollection<IWebElement> collection, string textValue)
        {
            foreach (var item in collection)
            {
                Assert.True(item.Text.Contains(textValue));
            }
        }

        protected static void assertMoreThan1TextForEachItem(IReadOnlyCollection<IWebElement> collection, string textValue1, string textValue2)
        {
            foreach (var item in collection)
            {
                Assert.True(item.Text.Contains(textValue1) || item.Text.Contains(textValue2));
            }
        }

        protected static void assertCollectionSortAscending(ReadOnlyCollection<IWebElement> collection1)
        {
            bool equal = false;
            IOrderedEnumerable<IWebElement> collection2 = null;
            collection2 = collection1.OrderBy(a => a.Text);
            equal = collection1.SequenceEqual(collection2);
        }

        protected static void assertCollectionSortDescending(ReadOnlyCollection<IWebElement> collection1)
        {
            bool equal = false;
            IOrderedEnumerable<IWebElement> collection2 = null;
            collection2 = collection1.OrderByDescending(a => a.Text);
            equal = collection1.SequenceEqual(collection2);
        }

        protected static void selectResultInDifferentWaysInSelect2(ReadOnlyCollection<IWebElement> collection, string text, string selecMethod, IWebElement inputField)
        {
            Actions builder = new Actions(driver);
            foreach (var item in collection)
            {
                Thread.Sleep(500);
                if (item.Text.Contains(text))
                {
                    if (selecMethod == "Enter")
                    {
                        builder.MoveToElement(item).Build().Perform();
                        inputField.SendKeys(Keys.Enter);
                        break;
                    }
                    else if (selecMethod == "Tab")
                    {
                        builder.MoveToElement(item).Build().Perform();
                        inputField.SendKeys(Keys.Tab);
                        break;
                    }
                    else
                    {
                        builder.MoveToElement(item).Build().Perform();
                        item.Click();
                        break;
                    }
                }
            }
        }

        protected static void assertEachItemIsDisplayed(IReadOnlyCollection<IWebElement> collection)
        {
            foreach (var item in collection)
            {
                Assert.True(item.Displayed);
            }
        }

        protected static void assertSingleElementIsDisplayed(IWebElement element)
        {
                Assert.True(element.Displayed, element+" is not being displayed on current page.");
        }

        protected static void assertEachItemInUIContainsText(IReadOnlyCollection<IWebElement> collection, string text)
        {
            foreach (var item in collection)
            {
                Assert.True(item.Text.Contains(text));
            }
        }

        protected static void clickElementWhileEachItemNotContainsValueX(IReadOnlyCollection<IWebElement> collection, string key, string value, IWebElement element)
        {
            foreach (var item in collection)
            {
                string uiValue = item.GetAttribute(key).ToString();
                while (!uiValue.Contains(value))
                {
                    element.Click();
                    uiValue = item.GetAttribute(key).ToString();
                }
            }
        }

        protected static void clickElementWhileEachItemContainsValueX(IReadOnlyCollection<IWebElement> collection, string key, string value, IWebElement element)
        {
            foreach (var item in collection)
            {
                string uiValue = item.GetAttribute(key).ToString();
                while (uiValue.Contains(value))
                {
                    element.Click();
                    uiValue = item.GetAttribute(key).ToString();
                }
            }
        }

        protected static void scrollListDown(ReadOnlyCollection<IWebElement> collection, int collectionExpectedCount, IWebElement elementToSendKeys, string collectionXpath)
        {
            DateTime dt = DateTime.Now.AddMinutes(5);

            while (collection.Count != collectionExpectedCount && dt >= DateTime.Now)
            {
                elementToSendKeys.Click();
                for (int i = 0; i < 200; i++)
                {
                    elementToSendKeys.SendKeys(Keys.ArrowDown);
                }

                collection = createVisibleElementsCollectionByXpath(collectionXpath);
                string actualCount = collection.Count.ToString();
                TestsLogger.Log(actualCount + " VS " + collectionExpectedCount);
            }
        }

        protected static void scrollListDownToSpecificElement(IWebElement element, string textToMatch, IWebElement elementToSendKeys, string elementXpath)
        {
            while (element.Text.Contains(textToMatch).Equals(false))
            {
                elementToSendKeys.SendKeys(Keys.ArrowDown);
                element = createVisibleWebElementByXpath(elementXpath);
                string actualText = element.Text;
                TestsLogger.Log(actualText + " VS " + textToMatch);
            }
        }

        protected static void assertAttributeContainsTextForEachItem(IReadOnlyCollection<IWebElement> collection, string key, string value)
        {
            foreach (var item in collection)
            {
                string uiValue = item.GetAttribute(key).ToString();
                Assert.True(uiValue.Contains(value));
            }
        }

        protected static void assertAttributeNotContainsTextForEachItem(IReadOnlyCollection<IWebElement> collection, string key, string value)
        {
            foreach (var item in collection)
            {
                string uiValue = item.GetAttribute(key).ToString();
                Assert.False(uiValue.Contains(value));
            }
        }

        protected static void assertAttributeContainsText(IWebElement element, string key, string value)
        {
            string uiValue = element.GetAttribute(key).ToString();
            Assert.True(uiValue.Contains(value));
        }

        protected static void assertGetAttributeContainsText(IWebElement element, string key, string value, string errorMessage)
        {
            string uiValue = element.GetAttribute(key).ToString();
            Assert.True(uiValue.Replace("\r\n", " ").Replace("\n", " ").Contains(value.Replace("\r\n", " ").Replace("\n", " ")), errorMessage+"\r\n'"+uiValue+"' does not contains value '"+value+"'");
        }

        protected static string GetAttributeText(IWebElement element, string key)
        {
            string keyValue = element.GetAttribute(key).ToString();
            return keyValue;
        }

        protected static bool DoesAttributeContainsText(IWebElement element, string key, string value)
        {
            string uiValue = element.GetAttribute(key).ToString();
            if (uiValue.Contains(value) == true)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        protected static void assertElementContainsSingleText(IWebElement element, string value1, string errorMessage)
        {
            Assert.True(element.Text.Replace("\r\n", " ").Replace("\n", " ").Contains(value1.Replace("\r\n", " ").Replace("\n", " ")), errorMessage+"\r\n'"+element.Text+"' does not contains value '"+value1+"'");
        }

        protected static void assertElementCouldContainThreeTexts(IWebElement element, string value1, string value2, string value3)
        {
            Assert.True(element.Text.Contains(value1) || element.Text.Contains(value2) || element.Text.Contains(value3));
        }

        protected static void assertElementCouldContainTwoTexts(IWebElement element, string value1, string value2, string errorMessage)
        {
            Assert.True(element.Text.Replace("\r\n", " ").Replace("\n", " ").Contains(value1.Replace("\r\n", " ").Replace("\n", " ")) || element.Text.Replace("\r\n", " ").Replace("\n", " ").Contains(value2.Replace("\r\n", " ").Replace("\n", " ")), errorMessage + "\r\n'" + element.Text + "' does not contains value '" + value1 + "' or '"+value2+"'");
        }

        protected static void verifyTextFormat(IReadOnlyCollection<IWebElement> collection, Regex format)
        {
            foreach (var item in collection)
            {
                format.IsMatch(item.Text);
            }
        }


        //DB Queries
        protected DataRowCollection ExecuteQueryOnDBWithString(string query, Dictionary<string, string> parameters)
        {
            DataTable results = new DataTable();

            using (SqlConnection connection = new SqlConnection(ConfigurationManager.AppSettings.Get("DBConnectionString")))
            //using (SqlConnection connection = new SqlConnection(ConfigurationManager.AppSettings.Get("DBConnectionString")))
            {
                //Prepare command to execute
                SqlCommand command = new SqlCommand(query, connection);

                //Add given parameters
                if (parameters != null)
                {
                    foreach (KeyValuePair<string, string> param in parameters)
                    {
                        command.Parameters.AddWithValue("@" + param.Key, param.Value);
                    }
                }

                //Connect to DB and execute
                connection.Open();
                SqlDataAdapter dataAdapter = new SqlDataAdapter(command);
                dataAdapter.Fill(results);
                TestsLogger.Log("RowsAffected: " + results.Rows.Count);
            }

            return results.Rows;
        }

        protected DataRowCollection ExecuteQueryOnDBWithString(string query)
        {
            return this.ExecuteQueryOnDBWithString(query, null);
        }

        protected DataRowCollection ExecuteQueryOnDBWithInt(string query, Dictionary<string, int> parameters)
        {
            DataTable results = new DataTable();

            using (SqlConnection connection = new SqlConnection(ConfigurationManager.AppSettings.Get("DBConnectionString")))
            //using (SqlConnection connection = new SqlConnection(ConfigurationManager.AppSettings.Get("DBConnectionString")))
            {
                //Prepare command to execute
                SqlCommand command = new SqlCommand(query, connection);

                //Add given parameters
                if (parameters != null)
                {
                    foreach (KeyValuePair<string, int> param in parameters)
                    {
                        command.Parameters.AddWithValue("@" + param.Key, param.Value);
                    }
                }

                //Connect to DB and execute
                connection.Open();
                SqlDataAdapter dataAdapter = new SqlDataAdapter(command);
                dataAdapter.Fill(results);
                TestsLogger.Log("RowsAffected: " + results.Rows.Count);
            }

            return results.Rows;
        }

        protected DataRowCollection ExecuteQueryOnDBWithIntAndString(string query, Dictionary<string, int> parameterInt, Dictionary<string, string> parameterString)
        {
            DataTable results = new DataTable();

            using (SqlConnection connection = new SqlConnection(ConfigurationManager.AppSettings.Get("DBConnectionString")))
            //using (SqlConnection connection = new SqlConnection(ConfigurationManager.AppSettings.Get("DBConnectionString")))
            {
                //Prepare command to execute
                SqlCommand command = new SqlCommand(query, connection);

                //Add given parameters
                if (parameterInt != null)
                {
                    foreach (KeyValuePair<string, int> param in parameterInt)
                    {
                        command.Parameters.AddWithValue("@" + param.Key, param.Value);
                    }
                }

                //Add given parameters
                if (parameterString != null)
                {
                    foreach (KeyValuePair<string, string> param in parameterString)
                    {
                        command.Parameters.AddWithValue("@" + param.Key, param.Value);
                    }
                }

                //Connect to DB and execute
                connection.Open();
                SqlDataAdapter dataAdapter = new SqlDataAdapter(command);
                dataAdapter.Fill(results);
                TestsLogger.Log("RowsAffected: " + results.Rows.Count);
            }

            return results.Rows;
        }

        protected DataRowCollection ExecuteQueryOnDBWithIntAndDateTime(string query, Dictionary<string, int> parameterInt, Dictionary<string, DateTime> parameterString)
        {
            DataTable results = new DataTable();

            using (SqlConnection connection = new SqlConnection(ConfigurationManager.AppSettings.Get("DBConnectionString")))
            //using (SqlConnection connection = new SqlConnection(ConfigurationManager.AppSettings.Get("DBConnectionString")))
            {
                //Prepare command to execute
                SqlCommand command = new SqlCommand(query, connection);

                //Add given parameters
                if (parameterInt != null)
                {
                    foreach (KeyValuePair<string, int> param in parameterInt)
                    {
                        command.Parameters.AddWithValue("@" + param.Key, param.Value);
                    }
                }

                //Add given parameters
                if (parameterString != null)
                {
                    foreach (KeyValuePair<string, DateTime> param in parameterString)
                    {
                        command.Parameters.AddWithValue("@" + param.Key, param.Value);
                    }
                }

                //Connect to DB and execute
                connection.Open();
                SqlDataAdapter dataAdapter = new SqlDataAdapter(command);
                dataAdapter.Fill(results);
                TestsLogger.Log("RowsAffected: " + results.Rows.Count);
            }

            return results.Rows;
        }

        public static string GetExpectedSerialNumberTextForLedger(string trxType)
        {
            string trxExpectedSerialText = trxType;
            if ((trxType == "Check") || (trxType == "Deposit") || (trxType == "Deposit Correcting Check"))
            {
                string serialNbr = ScenarioContext.Current.Get<string>("Transaction Serial Number");
                trxExpectedSerialText = trxType + " #" + serialNbr;
            }
            else if (trxType.Contains("Bank Service Charge Refund"))
                trxExpectedSerialText = "Service Charge Refund";

            return trxExpectedSerialText;
        }

        protected DataRowCollection ExecuteQueryOnDBWithDateTime(string query, Dictionary<string, DateTime> parameters)
        {
            DataTable results = new DataTable();

            using (SqlConnection connection = new SqlConnection(ConfigurationManager.AppSettings.Get("DBConnectionString")))
            //using (SqlConnection connection = new SqlConnection(ConfigurationManager.AppSettings.Get("DBConnectionString")))
            {
                //Prepare command to execute
                SqlCommand command = new SqlCommand(query, connection);

                //Add given parameters
                if (parameters != null)
                {
                    foreach (KeyValuePair<string, DateTime> param in parameters)
                    {
                        command.Parameters.AddWithValue("@" + param.Key, param.Value);
                    }
                }

                //Connect to DB and execute
                connection.Open();
                SqlDataAdapter dataAdapter = new SqlDataAdapter(command);
                dataAdapter.Fill(results);
                TestsLogger.Log("RowsAffected: " + results.Rows.Count);
            }

            return results.Rows;
        }       
        public static List<string> getElementsIds(ReadOnlyCollection<IWebElement> collection, string stringToReplace)
        {
            string caseId = "";
            List<string> newIds = null;
            foreach (var item in collection)
            {
                caseId = item.GetAttribute("Id");
                caseId = caseId.Replace(stringToReplace, "").Split('-')[0];
                newIds.Add(caseId);
            }
            return newIds;
        }

        public static string getSingleElementId(IWebElement element, string stringToReplace)
        {
            string id = "";
            id = element.GetAttribute("id");
            id = id.Replace(stringToReplace, "").Split('-')[0];
            return id;
        }
    }
}
