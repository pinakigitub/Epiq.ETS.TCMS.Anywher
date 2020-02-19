using Epiq.ETS.TCMS.Anywhere.Testing.E2ETest.Test_Framework.Steps.Common;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Threading;
using TechTalk.SpecFlow;

namespace Epiq.ETS.TCMS.Anywhere.Testing.E2ETest.Test_Framework.Core
{
    [Binding]
    public class CaseResultsPageStepsNew : CommonMethodsUnityStepBase
    {
        [Given(@"Click on Assets tab")]
        [When(@"Click on Assets tab")]
        [Then(@"Click on Assets tab")]
        public void ClickAssetsTab()
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
            Thread.Sleep(1000);
            pleaseWaitSignDissapear();
            IWebElement assetsTab = wait.Until(ExpectedConditions.ElementExists(By.XPath("//div/a[@id='navItem-Assets']")));
            IWebElement scrollToMe = createExistentWebElementByXpath("//div[@id='nonStickyHeader']");
            scrollToElement(scrollToMe);
            clickNotVisualizedElement(assetsTab);
            pleaseWaitSignDissapear();
        }

        [Given(@"Click on Banking tab")]
        [When(@"Click on Banking tab")]
        [Then(@"Click on Banking tab")]
        public void ClickBankingTab()
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
            Thread.Sleep(1000);
            pleaseWaitSignDissapear();
            IWebElement assetsTab = wait.Until(ExpectedConditions.ElementExists(By.XPath("//div/a[@id='navItem-Banking']")));
            IWebElement scrollToMe = createExistentWebElementByXpath("//div[@id='nonStickyHeader']");
            scrollToElement(scrollToMe);
            clickNotVisualizedElement(assetsTab);
            pleaseWaitSignDissapear();
        }

        [Given(@"I save Case ID from '(.*)' tab")]
        [When(@"I save Case ID from '(.*)' tab")]
        [Then(@"I save Case ID from '(.*)' tab")]
        public void saveCaseIdFromSpecificTab(string tabName)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
            pleaseWaitSignDissapear();
            Thread.Sleep(1000);
            IWebElement assetsTab = null;
            string href = "";
            string caseIdString = "";
            int caseIdInt = 0;

            if (tabName == "Assets")
            {
                assetsTab = wait.Until(ExpectedConditions.ElementExists(By.XPath("//div/a[@id='navItem-Assets']")));
                href = assetsTab.GetAttribute("href").ToString();
                string str = href.Substring(href.IndexOf("general/") + 8);
                caseIdString = str.Replace("/asset", "");
                caseIdInt = Convert.ToInt32(caseIdString);
            }
            else if (tabName == "Banking")
            {
                assetsTab = wait.Until(ExpectedConditions.ElementExists(By.XPath("//div/a[@id='navItem-Banking']")));
                href = assetsTab.GetAttribute("href").ToString();
                string str = href.Substring(href.IndexOf("general/") + 8);
                caseIdString = str.Replace("/banking", "");
                caseIdInt = Convert.ToInt32(caseIdString);
            }
            else
            {
                assetsTab = wait.Until(ExpectedConditions.ElementExists(By.XPath("//div/a[@id='navItem-Claims']")));
                href = assetsTab.GetAttribute("href").ToString();
                string str = href.Substring(href.IndexOf("general/") + 8);
                caseIdString = str.Replace("/", "");
                caseIdInt = Convert.ToInt32(caseIdString);
            }
            ScenarioContext.Current.Add("caseId", caseIdInt);
            TestsLogger.Log(caseIdString);
            pleaseWaitSignDissapear();
        }

        [Given(@"Verify Case Level Details section layout")]
        [When(@"Verify Case Level Details section layout")]
        [Then(@"Verify Case Level Details section layout")]
        public void verifyCaseLevelDetailsSectionLayout()
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(50));
            Thread.Sleep(2000);
            pleaseWaitSignDissapear();

            IWebElement caseNumber = createVisibleWebElementByXpath("//span[@id='caseNumber']");
            IWebElement judgeName = createExistentWebElementByXpath("//span[@id='judgeName']");
            IWebElement caseChapter = createVisibleWebElementByXpath("//span[@id='caseDetail']");
            IWebElement assetStatus = null;
            string caseChapters1 = caseChapter.Text.Replace(" ", "");
            string caseChapters2 = caseChapters1.Insert(7, " ");
            if (caseChapters2 != "CHAPTER 7" && caseChapters2 != "CHAPTER 11" && caseChapters2 != "CHAPTER 12")
            {
                waitElementIsInvisibleByXPath("//div[@id='assetStatus']", "ASSET");
                waitElementIsInvisibleByXPath("//div[@id='assetStatus']", "NO ASSET");
            }
            else
            {
                assetStatus = createVisibleWebElementByXpath("//div[@id='assetStatus']");
            }
            IWebElement caseStatus = createVisibleWebElementByXpath("//div[@id='caseStatus']");
            IWebElement debtorName = createVisibleWebElementByXpath("//span[@id='debtorName']");
            IWebElement jointDebtor = createExistentWebElementByXpath("//span[@id='jointDebtor']");
            IWebElement debtorAttorneyTitle = createVisibleWebElementByXpath("//span[@id='debtorAttorneyTitle']");
            IWebElement attorneyDisplayName = createExistentWebElementByXpath("//span[@id='attorneyDisplayName']");
            IWebElement attorneyPhoneNumber = createExistentWebElementByXpath("//span[@id='attorneyPhoneNumber']");
            IWebElement attorneyEmail = createExistentWebElementByXpath("//span[@id='attorneyEmail']");
            IWebElement attorneyAddressTitle = createVisibleWebElementByXpath("//span[@id='attorneyAddressTitle']");
            IWebElement attorneyStreet = createExistentWebElementByXpath("//span[@id='attorneyStreet']");
            IWebElement attorneyState = createExistentWebElementByXpath("//span[@id='attorneyState']");
            IWebElement claimsIconTitle = createVisibleWebElementByXpath("//h1[@id='claimsIcon-description']");
            IWebElement claimsIcon = createVisibleWebElementByXpath("//div[@id='claimsIcon']");
            IWebElement claimsIconValue = createVisibleWebElementByXpath("//div[@id='claimsIcon-value']");
            IWebElement distributionIcon = createVisibleWebElementByXpath("//div[@id='distributionIcon']");
            IWebElement distributionIconTitle = createVisibleWebElementByXpath("//h1[@id='distributionIcon-description']");
            IWebElement distributionIconValue = createVisibleWebElementByXpath("//div[@id='distributionIcon-value']");
            IWebElement balanceIcon = createVisibleWebElementByXpath("//div[@id='balanceIcon']");
            IWebElement balanceIconTitle = createVisibleWebElementByXpath("//h1[@id='balanceIcon-description']");
            IWebElement balanceIconValue = createVisibleWebElementByXpath("//div[@id='balanceIcon-value']");

            /////////// Query to DB and validations between UI and DB ///////////
            DataRowCollection rows = null;
            Dictionary<string, int> parameters = new Dictionary<string, int>();
            int caaseId = ScenarioContext.Current.Get<int>("caseId");
            parameters.Clear();
            parameters.Add("caseId", caaseId);
            rows = this.ExecuteQueryOnDBWithInt(Properties.Resources.getCaseLevelDetailsForSpecificCaseId, parameters);
            Assert.True(caseNumber.Text.Contains(rows[0].ItemArray[1].ToString().ToUpper()));
            Assert.True(caseStatus.Text.Replace(" ", "").Contains(rows[0].ItemArray[3].ToString().ToUpper()));
            if (caseChapters2 == "CHAPTER 7" || caseChapters2 == "CHAPTER 11" || caseChapters2 == "CHAPTER 12")
            {
                if ((rows[0].ItemArray[16].ToString() == "Asset"))
                {
                    Assert.True(assetStatus.Text.Contains("ASSET"));
                }
                else
                {
                    Assert.True(assetStatus.Text.Contains("NO ASSET"));
                }
            }
            if (rows[0].ItemArray[11].ToString() != "Pro Se")
            {
                Assert.True(debtorName.Text.Contains(rows[0].ItemArray[11].ToString() + " /") || debtorName.Text.Contains(rows[0].ItemArray[11].ToString().Replace("   ", "")));
            }
            else
            {
                string one = rows[0].ItemArray[11].ToString();
                string two = System.Globalization.CultureInfo.CurrentCulture.TextInfo.ToTitleCase(one);
                Assert.True(debtorName.Text.Contains(two + "/") || debtorName.Text.Contains(two));
            }
            assertElementIsDisplayedIfDBValueNotNullInUpperCase(rows, 0, 13, "", jointDebtor);
            Assert.True(debtorAttorneyTitle.Text == "DEBTOR ATTORNEY");
            Assert.True(attorneyAddressTitle.Text == "ADDRESS");
            Assert.True(judgeName.Text.Contains("JUDGE "));
            assertElementIsDisplayedIfDBValueNotNullInUpperCase(rows, 0, 15, "", judgeName);
            assertElementIsDisplayedIfDBValueNotNullInUpperCase(rows, 0, 17, "", attorneyDisplayName);
            assertElementIsDisplayedIfDBValueNotNullInUpperCase(rows, 0, 23, "", attorneyPhoneNumber);
            assertElementIsDisplayedIfDBValueNotNullRegularCase(rows, 0, 22, "", attorneyEmail);
            assertElementIsDisplayedIfDBValueNotNullInUpperCase(rows, 0, 20, "", attorneyStreet);
            assertElementIsDisplayedIfDBValueNotNullInUpperCase(rows, 0, 21, "", attorneyState);
            assertElementIsDisplayedIfDBValueNotNullInUpperCase(rows, 0, 18, "", attorneyState);
            assertElementIsDisplayedIfDBValueNotNullInUpperCase(rows, 0, 19, "", attorneyState);
            Assert.True(caseChapter.Text.Contains(rows[0].ItemArray[4].ToString().ToUpper()));
            Assert.True(claimsIcon.Displayed);
            Assert.True(claimsIconTitle.Text == "Claims");
            Assert.True(claimsIconValue.Text.Contains(rows[0].ItemArray[10].ToString().ToUpper()));
            Assert.True(distributionIcon.Displayed);
            Assert.True(distributionIconTitle.Text == "Dist. to Date");
            Assert.True(distributionIconValue.Text.Contains(rows[0].ItemArray[9].ToString()));
            Assert.True(balanceIcon.Displayed);
            Assert.True(balanceIconTitle.Text == "Balance");
            Assert.True(balanceIconValue.Text.Contains(rows[0].ItemArray[8].ToString().ToUpper()));
        }

        [Given(@"Verify Case level Details section is Sticky in '(.*)' tab")]
        [When(@"Verify Case level Details section is Sticky in '(.*)' tab")]
        [Then(@"Verify Case level Details section is Sticky in '(.*)' tab")]
        public void checkCaseLevelSticky(string tabName)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
            Thread.Sleep(1000);
            pleaseWaitSignDissapear();
            IWebElement scrollToMe = null;
            IWebElement caseLevelSection = null;
            IWebElement debtorAttorneySection = null;
            if (tabName == "Claims")
            {
                caseLevelSection = createVisibleWebElementById("stickyCaseHeader");
                Assert.True(caseLevelSection.Displayed);
                debtorAttorneySection = createVisibleWebElementByXpath("//div[@id='nonStickyHeader']/div");
                Assert.True(debtorAttorneySection.Displayed);
                scrollToMe = createExistentWebElementByXpath("//span[@id='claimsSectionTitle']");
                scrollToElement(scrollToMe);
                Assert.True(caseLevelSection.Displayed);
                waitElementIsInvisibleByXPath("//span[@id='claimsSectionTitle']", "");
            }
            else if (tabName == "Banking")
            {
                caseLevelSection = createVisibleWebElementById("stickyCaseHeader");
                Assert.True(caseLevelSection.Displayed);
                debtorAttorneySection = createVisibleWebElementByXpath("//div[@id='nonStickyHeader']/div");
                Assert.True(debtorAttorneySection.Displayed);
                scrollToMe = createExistentWebElementByXpath("//span[@id='ledgerSectionTitle']");
                scrollToElement(scrollToMe);
                Assert.True(caseLevelSection.Displayed);
                waitElementIsInvisibleByXPath("//span[@id='claimsSectionTitle']", "");
            }
            else
            {
                caseLevelSection = createVisibleWebElementById("stickyCaseHeader");
                Assert.True(caseLevelSection.Displayed);
                debtorAttorneySection = createVisibleWebElementByXpath("//div[@id='nonStickyHeader']/div");
                Assert.True(debtorAttorneySection.Displayed);
                scrollToMe = createExistentWebElementByXpath("//span[@id='Title']");
                scrollToElement(scrollToMe);
                Assert.True(caseLevelSection.Displayed);
                waitElementIsInvisibleByXPath("//span[@id='claimsSectionTitle']", "");
            }
            pleaseWaitSignDissapear();
        }

        [Given(@"Verify Additional Debtor Information section layout")]
        [When(@"Verify Additional Debtor Information section layout")]
        [Then(@"Verify Additional Debtor Information section layout")]
        public void verifyAdditionalDebtorInformationSectionLayout()
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(50));
            Thread.Sleep(2000);

            /////////// Query to DB and validations between UI and DB ///////////
            DataRowCollection rows = null;
            Dictionary<string, int> parameters = new Dictionary<string, int>();
            int caseId = ScenarioContext.Current.Get<int>("caseId");
            parameters.Clear();
            parameters.Add("caseId", caseId);
            rows = ExecuteQueryOnDBWithInt(Properties.Resources.getCaseDetailSP, parameters);

            pleaseWaitSignDissapear();
            /////////// DEBTOR SECTION ////////////
            IWebElement debtorLabel = createVisibleWebElementByXpath("//label[@id='debtorLabel']");
            IWebElement debtorNameSection = createVisibleWebElementByXpath("//div[@id='debtorNameSection']");
            IWebElement debtorSSNLabel = createVisibleWebElementByXpath("//label[@id='debtorSSNLabel']");
            IWebElement debtorSSNSection = createVisibleWebElementByXpath("//div[@id='debtorSSNSection']");
            IWebElement debtorPhoneLabel = createVisibleWebElementByXpath("//label[@id='debtorPhoneLabel']");
            IWebElement debtorPhoneSection = createVisibleWebElementByXpath("//div[@id='debtorPhoneSection']");
            IWebElement debtorEmailLabel = createVisibleWebElementByXpath("//label[@id='debtorEmailLabel']");
            IWebElement debtorEmailSection = createVisibleWebElementByXpath("//div[@id='debtorEmailSection']");
            IWebElement debtorAddressLabel = createVisibleWebElementByXpath("//label[@id='debtorAddressLabel']");
            IWebElement debtorAddressStreetSection = createVisibleWebElementByXpath("//div[@id='debtorAddressSection']/div[1]");
            IWebElement debtorAddressStateSection = createVisibleWebElementByXpath("//div[@id='debtorAddressSection']/div[2]");
            IWebElement closeSectionButton = createVisibleWebElementByXpath("//div[@class[contains(.,'debtorAdditionalInformationClose')]]");
            IWebElement closeSectionButtonIcon = createVisibleWebElementByXpath("//div[@class[contains(.,'debtorAdditionalInformationClose')]]/i");

            if (rows[0].ItemArray[13].ToString() != "")
            {
                /////////// JOINT DEBTOR SECTION ////////////
                IWebElement jointDebtorLabel = createVisibleWebElementByXpath("//label[@id='jointDebtorLabel']");
                IWebElement jointDebtorNameSection = createVisibleWebElementByXpath("//div[@id='jointDebtorNameSection']");
                IWebElement jointDebtorSSNLabel = createVisibleWebElementByXpath("//label[@id='jointDebtorSSNLabel']");
                IWebElement jointDebtorSSNSection = createVisibleWebElementByXpath("//div[@id='jointDebtorSSNSection']");
                IWebElement jointDebtorPhoneLabel = createVisibleWebElementByXpath("//label[@id='jointDebtorPhoneLabel']");
                IWebElement jointDebtorPhoneSection = createVisibleWebElementByXpath("//div[@id='jointDebtorPhoneSection']");
                IWebElement jointDebtorEmailLabel = createVisibleWebElementByXpath("//label[@id='jointDebtorEmailLabel']");
                IWebElement jointDebtorEmailSection = createVisibleWebElementByXpath("//div[@id='jointDebtorEmailSection']");
                IWebElement jointDebtorAddressLabel = createVisibleWebElementByXpath("//label[@id='jointDebtorAddressLabel']");
                IWebElement jointDebtorAddressStreetSection = createVisibleWebElementByXpath("//div[@id='jointDebtorAddressSection']/div[1]");
                IWebElement jointDebtorAddressStateSection = createVisibleWebElementByXpath("//div[@id='jointDebtorAddressSection']/div[2]");
                Assert.True(jointDebtorLabel.Text == "JOINT DEBTOR");
                Assert.True(jointDebtorSSNLabel.Text == "SSN");
                Assert.True(jointDebtorPhoneLabel.Text == "PHONE #");
                Assert.True(jointDebtorEmailLabel.Text == "EMAIL");
                Assert.True(jointDebtorAddressLabel.Text == "ADDRESS");
                assertElementIsDisplayedIfDBValueNotNullInUpperCase(rows, 0, 13, "", jointDebtorNameSection);
                if (rows[0].ItemArray[14].ToString() == "")
                {
                    Assert.True(jointDebtorSSNSection.Text.Contains("-  -"));
                }
                else
                {
                    string fullSSN = rows[0].ItemArray[14].ToString();
                    string partialSSN1 = removeCharsFromString(fullSSN, 0, 7, fullSSN);
                    string partialSSN2 = "XXX-XX-" + partialSSN1;
                    string partialSSN3 = "XXX-XX-";
                    string noSSN = "XXX-XX-XXXX";
                    Assert.True(jointDebtorSSNSection.Text.Contains(fullSSN) || jointDebtorSSNSection.Text.Contains(partialSSN2) || jointDebtorSSNSection.Text.Contains(noSSN) || jointDebtorSSNSection.Text.Contains(partialSSN3));
                }
                assertElementIsDisplayedIfDBValueNotNullInUpperCase(rows, 0, 29, "", jointDebtorPhoneSection);
                assertElementIsDisplayedIfDBValueNotNullRegularCase(rows, 0, 28, "", jointDebtorEmailSection);
                assertElementIsDisplayedIfDBValueNotNullInUpperCase(rows, 0, 26, "", jointDebtorAddressStreetSection);
                assertElementIsDisplayedIfDBValueNotNullInUpperCase(rows, 0, 25, "", jointDebtorAddressStateSection);
                //assertElementIsDisplayedIfDBValueNotNullInUpperCase(rows, 0, 24, "", jointDebtorAddressStateSection);
                assertElementIsDisplayedIfDBValueNotNullInUpperCase(rows, 0, 27, "", jointDebtorAddressStateSection);
            }
            else
            {
                waitElementIsInvisibleByXPath("//label[@id='jointDebtorLabel']", "JOINT DEBTOR");
                waitElementIsInvisibleByXPath("//div[@id='jointDebtorNameSection']", "");
                waitElementIsInvisibleByXPath("//label[@id='jointDebtorSSNLabel']", "SSN");
                waitElementIsInvisibleByXPath("//div[@id='jointDebtorSSNSection']", "");
                waitElementIsInvisibleByXPath("//label[@id='jointDebtorPhoneLabel']", "PHONE #");
                waitElementIsInvisibleByXPath("//div[@id='jointDebtorPhoneSection']", "");
                waitElementIsInvisibleByXPath("//label[@id='jointDebtorEmailLabel']", "EMAIL");
                waitElementIsInvisibleByXPath("//div[@id='jointDebtorEmailSection']", "");
                waitElementIsInvisibleByXPath("//label[@id='jointDebtorAddressLabel']", "ADDRESS");
                waitElementIsInvisibleByXPath("//div[@id='jointDebtorAddressSection']", "");
            }
            Assert.True(closeSectionButton.Text == "CLOSE");
            Assert.True(closeSectionButtonIcon.GetAttribute("class").ToString().Contains("up"));
            Assert.True(debtorLabel.Text == "DEBTOR");
            Assert.True(debtorSSNLabel.Text == "SSN");
            Assert.True(debtorPhoneLabel.Text == "PHONE #");
            Assert.True(debtorEmailLabel.Text == "EMAIL");
            Assert.True(debtorAddressLabel.Text == "ADDRESS");
            assertElementIsDisplayedIfDBValueNotNullRegularCase(rows, 0, 2, "", debtorNameSection);
            if (rows[0].ItemArray[12].ToString() == "")
            {
                Assert.True(debtorSSNSection.Text.Contains("-  -"));
            }
            else
            {
                string fullSSN = rows[0].ItemArray[12].ToString();
                string partialSSN1 = removeCharsFromString(fullSSN, 0, 7, fullSSN);
                string partialSSN2 = "XXX-XX-" + partialSSN1;
                string partialSSN3 = "XXX-XX-";
                string noSSN = "XXX-XX-XXXX";
                Assert.True(debtorSSNSection.Text.Contains(fullSSN) || debtorSSNSection.Text.Contains(partialSSN2) || debtorSSNSection.Text.Contains(noSSN) || debtorSSNSection.Text.Contains(partialSSN3));
            }
            assertElementIsDisplayedIfDBValueNotNullInUpperCase(rows, 0, 23, "", debtorPhoneSection);
            assertElementIsDisplayedIfDBValueNotNullRegularCase(rows, 0, 22, "", debtorEmailSection);
            assertElementIsDisplayedIfDBValueNotNullInUpperCase(rows, 0, 20, "", debtorAddressStreetSection);
            assertElementIsDisplayedIfDBValueNotNullInUpperCase(rows, 0, 21, "", debtorAddressStateSection);
            assertElementIsDisplayedIfDBValueNotNullInUpperCase(rows, 0, 18, "", debtorAddressStateSection);
            assertElementIsDisplayedIfDBValueNotNullInUpperCase(rows, 0, 19, "", debtorAddressStateSection);
        }

        [Given(@"Expand Additional Debtor Information section")]
        [When(@"Expand Additional Debtor Information section")]
        [Then(@"Expand Additional Debtor Information section")]
        public void expandDebtorInformatonSection()
        {
            pleaseWaitSignDissapear();
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(25));
            Thread.Sleep(2000);
            IWebElement button = createVisibleWebElementByXpath("//span/i[@class[contains(.,'optionDebtorInformation')]]");
            Assert.True(button.GetAttribute("class").ToString().Contains("down"));
            button.Click();
            pleaseWaitSignDissapear();
            waitElementIsVisibleByXPath("//label[@id='debtorLabel']");
            IWebElement buttonAfter = createVisibleWebElementByXpath("//span/i[@class[contains(.,'optionDebtorInformation')]]");
            Assert.True(buttonAfter.GetAttribute("class").ToString().Contains("up"));
            pleaseWaitSignDissapear();
        }

        [Given(@"Collapse Additional Debtor Information section")]
        [When(@"Collapse Additional Debtor Information section")]
        [Then(@"Collapse Additional Debtor Information section")]
        public void collapseDebtorInformatonSection()
        {
            pleaseWaitSignDissapear();
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(25));
            Thread.Sleep(2000);
            IWebElement button = createVisibleWebElementByXpath("//span/i[@class[contains(.,'optionDebtorInformation')]]");
            Assert.True(button.GetAttribute("class").ToString().Contains("up"));
            button.Click();
            pleaseWaitSignDissapear();
            waitElementIsInvisibleByXPath("//label[@id='debtorLabel']", "DEBTOR");
            IWebElement buttonAfter = createVisibleWebElementByXpath("//span/i[@class[contains(.,'optionDebtorInformation')]]");
            Assert.True(buttonAfter.GetAttribute("class").ToString().Contains("down"));
            pleaseWaitSignDissapear();
        }

        [Given(@"Close Additional Debtor Information section")]
        [When(@"Close Additional Debtor Information section")]
        [Then(@"Close Additional Debtor Information section")]
        public void closeDebtorInformatonSection()
        {
            pleaseWaitSignDissapear();
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(25));
            Thread.Sleep(2000);
            IWebElement button = createVisibleWebElementByXpath("//div[@class[contains(.,'debtorAdditionalInformationClose')]]/i");
            Assert.True(button.GetAttribute("class").ToString().Contains("up"));
            button.Click();
            pleaseWaitSignDissapear();
            waitElementIsInvisibleByXPath("//label[@id='debtorLabel']", "DEBTOR");
            waitElementIsInvisibleByXPath("//div[@class[contains(.,'debtorAdditionalInformationClose')]]", "CLOSE");
            pleaseWaitSignDissapear();
        }

        [Given(@"Click on Add Dates button")]
        [When(@"Click on Add Dates button")]
        [Then(@"Click on Add Dates button")]
        public void ClickAddDatesButton()
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
            Thread.Sleep(1000);
            pleaseWaitSignDissapear();
            IWebElement button = wait.Until(ExpectedConditions.ElementExists(By.XPath("//a[@id='addKeyDatesButton']")));
            button.Click();
            pleaseWaitSignDissapear();
        }

        [Given(@"Click on Add button inside Key Dates modal")]
        [When(@"Click on Add button inside Key Dates modal")]
        [Then(@"Click on Add button inside Key Dates modal")]
        public void ClickAddButtonInsideKeyDates()
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
            Thread.Sleep(1000);
            pleaseWaitSignDissapear();
            IWebElement button = createVisibleWebElementById("addKeyDateButton");
            button.Click();
            pleaseWaitSignDissapear();
        }

        [Given(@"Click on Cancel button inside Key Dates modal")]
        [When(@"Click on Cancel button inside Key Dates modal")]
        [Then(@"Click on Cancel button inside Key Dates modal")]
        public void ClickCancelButtonInsideKeyDates()
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
            Thread.Sleep(1000);
            pleaseWaitSignDissapear();
            IWebElement button = createVisibleWebElementById("cancelKeyDateButton");
            button.Click();
            pleaseWaitSignDissapear();
        }

        [Given(@"Perform action '(.*)' Date with text '(.*)' from list")]
        [When(@"Perform action '(.*)' Date with text '(.*)' from list")]
        [Then(@"Perform action '(.*)' Date with text '(.*)' from list")]
        public void clickDatesFilterCancelButton(string action, string text)
        {
            pleaseWaitSignDissapear();
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
            Thread.Sleep(500);
            IWebElement button = null;
            IWebElement actionSelected = null;
            ReadOnlyCollection<IWebElement> actionsSelected = null;
            if (action == "Select" && text != "All")
            {
                actionSelected = createExistentWebElementByXpath("//label[@id[contains(.,'keyDateListCheck-results-')]][contains(text(),'" + text + "')]/../input");

                while (!actionSelected.GetAttribute("class").ToString().Contains("checked"))
                {
                    button = createVisibleWebElementByXpath("//label[@id[contains(.,'keyDateListCheck-results-')]][contains(text(),'" + text + "')]");
                    button.Click();
                }

                actionSelected = createExistentWebElementByXpath("//label[@id[contains(.,'keyDateListCheck-results-')]][contains(text(),'" + text + "')]/../input");
                Assert.True(actionSelected.GetAttribute("class").ToString().Contains("checked"));
            }
            else if (action == "Unselect" && text != "All")
            {
                actionSelected = createExistentWebElementByXpath("//label[@id[contains(.,'keyDateListCheck-results-')]][contains(text(),'" + text + "')]/../input");
                while (actionSelected.GetAttribute("class").ToString().Contains("checked"))
                {
                    button = createVisibleWebElementByXpath("//label[@id[contains(.,'keyDateListCheck-results-')]][contains(text(),'" + text + "')]");
                    button.Click();
                }

                actionSelected = createExistentWebElementByXpath("//label[@id[contains(.,'keyDateListCheck-results-')]][contains(text(),'" + text + "')]/../input");
                Assert.False(actionSelected.GetAttribute("class").ToString().Contains("checked"));
            }
            else if (action == "Select" && text == "All")
            {
                actionsSelected = createPresentElementsCollectionByXpath("//label[not(@id='keyDateListCheck-results-AllElement-label')]/../input");
                button = createVisibleWebElementByXpath("//label[@id[contains(.,'keyDateListCheck-results-')]][contains(text(),'" + text + "')]");
                clickElementWhileEachItemNotContainsValueX(actionsSelected, "class", "checked", button);
                actionsSelected = createPresentElementsCollectionByXpath("//label[not(@id='keyDateListCheck-results-AllElement-label')]/../input");
                assertAttributeContainsTextForEachItem(actionsSelected, "class", "checked");
            }
            else if (action == "Unselect" && text == "All")
            {
                actionsSelected = createPresentElementsCollectionByXpath("//label[not(@id='keyDateListCheck-results-AllElement-label')]/../input");
                button = createVisibleWebElementByXpath("//label[@id[contains(.,'keyDateListCheck-results-')]][contains(text(),'" + text + "')]");
                clickElementWhileEachItemContainsValueX(actionsSelected, "class", "checked", button);
                actionsSelected = createPresentElementsCollectionByXpath("//label[not(@id='keyDateListCheck-results-AllElement-label')]/../input");
                assertAttributeNotContainsTextForEachItem(actionsSelected, "class", "checked");
            }

            pleaseWaitSignDissapear();
        }

        [Given(@"Verify All Dates selected layout")]
        [When(@"Verify All Dates selected layout")]
        [Then(@"Verify All Dates selected layout")]
        public void verifyAllDatesSectionLayout()
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(50));
            Thread.Sleep(2000);
            pleaseWaitSignDissapear();
            IReadOnlyCollection<IWebElement> datesLabels = createPresentElementsCollectionByXpath("//my-datebox/div/label");
            IReadOnlyCollection<IWebElement> datesValues = createPresentElementsCollectionByXpath("//my-datebox/div/label/input");

            IWebElement caseChapter = createVisibleWebElementByXpath("//span[@id='caseDetail']");
            string chapter1 = caseChapter.Text.Replace(" ", "");
            string Chapter2 = chapter1.Insert(7, " ");

            /////////// Query to DB and validations between UI and DB ///////////
            DataRowCollection rows = null;
            Dictionary<string, int> parameters = new Dictionary<string, int>();
            int caaseId = ScenarioContext.Current.Get<int>("caseId");
            parameters.Clear();
            parameters.Add("caseId", caaseId);
            rows = this.ExecuteQueryOnDBWithInt(Properties.Resources.getDatesListForCurrentCaseId, parameters);

            if (Chapter2 == "CHAPTER 7" || Chapter2 == "CHAPTER 11" || Chapter2 == "CHAPTER 12")
            {
                Assert.True(datesLabels.Count <= 20);
                assertEachElementTextInDBIsContainedInUI(datesLabels, rows, 3);
                assertElementAttributeInUIExistInDBUsingTwoArrayNumbers(datesValues, rows, 4, 0, "value");
            }
            else if (Chapter2 != "CHAPTER 7" && Chapter2 != "CHAPTER 11" && Chapter2 != "CHAPTER 12")
            {
                Assert.True(datesLabels.Count <= 7);
                assertEachElementTextInDBIsContainedInUI(datesLabels, rows, 3);
                assertElementAttributeInUIExistInDBUsingTwoArrayNumbers(datesValues, rows, 4, 0, "value");
            }
        }

        [Given(@"Enter Date with text '(.*)' for Ky Date '(.*)'")]
        [When(@"Enter Date with text '(.*)' for Ky Date '(.*)'")]
        [Then(@"Enter Date with text '(.*)' for Ky Date '(.*)'")]
        public void enterDateForKeyDate(string text, string keyDateName)
        {

            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(50));
            pleaseWaitSignDissapear();
            Thread.Sleep(500);
            IWebElement clickMe = createVisibleWebElementByXpath("//my-datebox/div/label[contains(text(),'DISPOSITION DATE')]");
            IWebElement typeBar = createVisibleWebElementByXpath("//my-datebox/div/label[contains(text(),'" + keyDateName + "')]/input");
            typeBar.Click();
            typeBar.Clear();
            pleaseWaitSignDissapear();
            Thread.Sleep(500);
            typeStringByChar(text, typeBar);
            pleaseWaitSignDissapear();
            pleaseWaitSignDissapear();
            Thread.Sleep(1000);
            clickMe.Click();
            pleaseWaitSignDissapear();
        }

        [Given(@"Select day '(.*)' from Key Date datepicker with name '(.*)'")]
        [When(@"Select day '(.*)' from Key Date datepicker with name '(.*)'")]
        [Then(@"Select day '(.*)' from Key Date datepicker with name '(.*)'")]
        public void selectKeyDateWithDatePicker(string text, string keyDateName)
        {

            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(50));
            pleaseWaitSignDissapear();
            Thread.Sleep(500);
            IWebElement datePickerIcon = createVisibleWebElementByXpath("//my-datebox/div/label[contains(text(),'" + keyDateName + "')]/i");
            datePickerIcon.Click();
            IWebElement dateToSelect = createVisibleWebElementByXpath("//div[@style[contains(.,'display')]]//div[@class='datepicker-days']/table/tbody/tr/td[@class[not(contains(.,'old'))] and @class[not(contains(.,'new'))] and @class[not(contains(.,'disabled'))]][text()='" + text + "']");
            dateToSelect.Click();
        }

        [Given(@"Verify error message for invalid Key Date format")]
        [When(@"Verify error message for invalid Key Date format")]
        [Then(@"Verify error message for invalid Key Date format")]
        public void errorMessageWrongKeyDateFormat()
        {

            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(50));
            pleaseWaitSignDissapear();
            IWebElement errorMessage = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//div[@id[contains(.,'errorMessageContainer')]]/small")));
            Assert.That(errorMessage.Text.Contains("Date must be in MM/DD/YYYY format"));
            pleaseWaitSignDissapear();
        }

        [Given(@"Verify error message for invalid Key Date format dissapears when correcting value")]
        [When(@"Verify error message for invalid Key Date format dissapears when correcting value")]
        [Then(@"Verify error message for invalid Key Date format dissapears when correcting value")]
        public void errorMessageWrongKeyDateFormatDissapears()
        {

            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(50));
            pleaseWaitSignDissapear();
            waitElementIsInvisibleByXPath("//div[@id[contains(.,'errorMessageContainer')]]/small", "Date must be in MM/DD/YYYY format");
            pleaseWaitSignDissapear();
        }

        [Given(@"Verify Key Dates modal layout")]
        [When(@"Verify Key Dates modal layout")]
        [Then(@"Verify Key Dates modal layout")]
        public void verifyKeyDatesModalLayout()
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(50));
            Thread.Sleep(2000);
            pleaseWaitSignDissapear();
            ReadOnlyCollection<IWebElement> datesLabels = createPresentElementsCollectionByXpath("//div[@id='keyDateListCheck-listSection']//label[not(@id='keyDateListCheck-results-AllElement-label')]");
            IWebElement addButton = createVisibleWebElementById("addKeyDateButton");
            IWebElement cancelButton = createVisibleWebElementById("cancelKeyDateButton");

            /////////// Query to DB and validations between UI and DB ///////////
            DataRowCollection rows = null;
            rows = this.ExecuteQueryOnDBWithString(Properties.Resources.getKeyDatesModalListedItems);

            assertCollectionSortAscending(datesLabels);
            assertEachElementTextInUIIsContainedInDB(datesLabels, rows, 1);
            Assert.True(addButton.Text.Contains("ADD"));
            Assert.True(cancelButton.Text.Contains("CANCEL"));
        }
    }
}
