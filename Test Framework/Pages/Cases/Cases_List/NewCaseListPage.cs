using Epiq.ETS.TCMS.Anywhere.Testing.E2ETest.Test_Framework.Pages.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using OpenQA.Selenium;
using System.Threading;
using NUnit.Framework;
using Bogus;


namespace Epiq.ETS.TCMS.Anywhere.Testing.E2ETest.Test_Framework.Pages.Cases.Cases_List
{
    public class NewCaseListPage : UnityPageBase
    {
        #region locators
        private static string pageTitle = "UNITY";
        private By casesDashboardLink = By.XPath("//ol/li/a");
        private By restFilterButton = By.XPath("//i[@class='fa fa-refresh']");
        private By debtorSortingControl = By.XPath("//th[5]/i");
        private By petitionDateSortingControl = By.XPath("//th[6]/i");
        private By expandAndCollapseButton = By.XPath("//tr/td/div/i");
        private By caseTableRowLocator = By.XPath("//table[contains(@class,'epiq-table table')]/tbody/tr");
        private By pageSizeLocator = By.XPath("//div[@class='epiq-paging-pagesize']/div/div/div/span[2]");
        private By caseCount = By.XPath("//h3/span");
        private By markedFavorite = By.XPath("//table/tbody/tr[3]/td[2]/i[@class='fa fa-star epiq-favorite-cases-selected-star epiq-cursor-pointer']");
        #endregion locators

        #region Add New Case Locators
        private By addCaseButton = By.XPath("//button[text()=' CASE']");
        private By caseNumberValue = By.XPath("//div[label[text()='CASE #']]/input");
        private By meetingDate = By.XPath("//div[label[text()='341 DATE']]//div/input");
        private By petitionDate = By.XPath("//div[label[text()='PETITION DATE']]//div/input");
        private By newParticipant = By.XPath("//div[@class='epiq-accordion panel-group'][2]//div[@class='epiq-radio-checkbox-list']//label//span[text()='New Participant']");
        private By firstName = By.XPath("//div[@class='epiq-no-divider row']/div[label[text()='FIRST NAME']]/input");
        private By middleName = By.XPath("//div[@class='epiq-no-divider row']/div[label[text()='MIDDLE NAME']]/input");
        private By lastName = By.XPath("//div[@class='epiq-no-divider row']/div[label[text()='LAST NAME']]/input");
        private By saveButton = By.XPath("//button[text()='SAVE']");
        private By petitionDateFrom = By.XPath("//div[label[text()='PETITION DATE (FROM)']]/span//input");
        #endregion Add New Case

        #region Basic Methods

        public NewCaseListPage(IWebDriver driver) : base(driver, pageTitle)
        {

        }
        public void ClickDashboardLink()
        {
            this.WaitForElementToBeVisible(casesDashboardLink).Click();
        }
        public void MeetingDateSortingControls()
        {
            driver.FindElement(By.XPath("//th[3]/i")).Click();
        }
        public void AscendingMeetingDateSection()
        {
            Thread.Sleep(3500);
            IList<IWebElement> Rows = driver.FindElements(caseTableRowLocator);
            int RowLength = Rows.Count;

            for (int i = 1; i <= RowLength; i++)
            {
                IWebElement TableColumnData1 = driver.FindElement(By.XPath("//*[@id='epiq-main-page-wrap']/div/div[4]/div/div/table/tbody/tr[" + (i) + "]/td[3]"));
                i++;
                string SortedList = TableColumnData1.Text;
                string ExpectedList = SortedList;
                Assert.AreEqual(SortedList, ExpectedList);
            }
        }
        public void ResetFilterButton()
        {
            this.WaitForElementToBeVisible(restFilterButton).Click();
        }
        public void DefaultMeetingDateDetails()
        {
            Thread.Sleep(4000);
            IList<IWebElement> Rows = driver.FindElements(caseTableRowLocator);
            int RowLength = Rows.Count;
            for (int i = 1; i <= RowLength; i++)
            {
                IWebElement MeetingDateColumnData = driver.FindElement(By.XPath("//table[@class='epiq-table table table-condensed']/tbody/tr[" + (i) + "]/td[3]"));
                i++;
                var ActualList = MeetingDateColumnData.Text;
                String Expected = ActualList;
                Assert.AreEqual(ActualList, Expected);
            }
        }
        public void DebtorSortingControls()
        {
            this.WaitForElementToBeVisible(debtorSortingControl).Click();
        }
        public void DebtorAscendingDetails()
        {
            Thread.Sleep(3000);
            IList<IWebElement> DebtorRow = driver.FindElements(caseTableRowLocator);
            int DebtorRowLength = DebtorRow.Count;

            for (int i = 1; i <= DebtorRowLength; i++)
            {
                IWebElement DebtorColumnData = driver.FindElement(By.XPath("//table[@class='epiq-table table table-condensed']/tbody/tr[" + (i) + "]/td[5]"));
                i++;
                var DebtorSortedList = DebtorColumnData.Text;
                string DebtorExpectedList = DebtorSortedList;
                Assert.AreEqual(DebtorSortedList, DebtorExpectedList);
            }
        }
        public void PetitionDateSortingControls()
        {
            this.WaitForElementToBeVisible(petitionDateSortingControl).Click();
        }
        public void PetitionDateAscendingSection()
        {
            Thread.Sleep(3000);
            IList<IWebElement> PetitionDateRow = driver.FindElements(caseTableRowLocator);
            int PetitionRowLength = PetitionDateRow.Count;
            for (int i = 1; i <= PetitionRowLength; i++)
            {
                IWebElement PetitionDateColumnData = driver.FindElement(By.XPath("//table[@class='epiq-table table table-condensed']/tbody/tr[" + (i) + "]/td[6]"));
                i++;
                var PetitionSortedList = PetitionDateColumnData.Text;
                string PetitionExpectedList = PetitionSortedList;
                Assert.AreEqual(PetitionSortedList, PetitionExpectedList);
            }
        }
        public void DebtorDefaultDetails()
        {
            Thread.Sleep(3000);
            IList<IWebElement> DebtorRow = driver.FindElements(caseTableRowLocator);
            int DebtorRowLength = DebtorRow.Count;

            for (int i = 1; i <= DebtorRowLength; i++)
            {
                IWebElement DebtorColumnData = driver.FindElement(By.XPath("//table[@class='epiq-table table table-condensed']/tbody/tr[" + (i) + "]/td[5]"));
                i++;
                var ActualList = DebtorColumnData.Text;
                string ExpectedList = ActualList;
                Assert.AreEqual(ActualList, ExpectedList);
            }
        }
        public void MeetingDateDescendingDetails()
        {
            Thread.Sleep(3000);
            IList<IWebElement> MeetingDateRows = driver.FindElements(caseTableRowLocator);
            int MeetingDateRowLength = MeetingDateRows.Count;

            for (int i = 1; i <= MeetingDateRowLength; i++)
            {
                IWebElement DesMeetingColumnData = driver.FindElement(By.XPath("//*[@id='epiq-main-page-wrap']/div/div[4]/div/div/table/tbody/tr[" + (i) + "]/td[3]"));
                i++;
                var DescSortedList = DesMeetingColumnData.Text;
                string ExpectedList = DescSortedList;
                Assert.AreEqual(DescSortedList, ExpectedList);
            }
        }
        public void SelectPages(int pageNumber)
        {
            this.ScrollDownToPageBottom();
            int count = pageNumber + 2;
            driver.FindElement(By.XPath("//ul[@class='pagination']/li[" + count + "]/a[contains(text(),'')]")).Click();
        }
        public void SelectPageSize(int pageSize)
        {
            this.ScrollDownToPageBottom();
            this.WaitForElementToBeClickeable(pageSizeLocator).Click();
            driver.FindElement(By.XPath("//div[@class='Select-menu']/div[text()='" + pageSize + "']")).Click();
            this.Pause(1);
            this.ScrollDownToPageBottom();
        }
        public void VerifyRowsLength(int pageSize)
        {
            this.ScrollUpToPageTop();
            // Thread.Sleep(1000);
            this.Pause(10);
            IList<IWebElement> rows = driver.FindElements(caseTableRowLocator);
            int caseRows = rows.Count() / 2;
            Assert.AreEqual(pageSize, caseRows);
        }
        public void SelectedPageCaseDetails()
        {
            this.ScrollUpToPageTop();
            for (int i = 1; i <= 10; i++)
            {
                IWebElement caseTableHeader = driver.FindElement(By.XPath("//*[@id='epiq-main-page-wrap']/div/div[4]/div/div/table/thead/tr/th[" + (i) + "]"));
                var HeaderList = caseTableHeader.Text;
                string ExpectedList = HeaderList;
                Assert.AreEqual(HeaderList, ExpectedList);
            }
            Thread.Sleep(3000);
            this.ScrollDownToPageBottom();
        }
        public void FieldsUnderExpandButtonInCaseTable()
        {
            this.Pause(3);
            IList<IWebElement> rows = driver.FindElements(caseTableRowLocator);
            int caseRows = rows.Count;
            for (int caseRow = 1; caseRow <= caseRows; caseRow++)
            {
                IList<IWebElement> detailRows = driver.FindElements(caseTableRowLocator);
                int expandRowLength = detailRows.Count;
                for (int expandRow = 2; expandRow <= expandRowLength; expandRow++)
                {
                    IWebElement Expand = driver.FindElement(By.XPath("//table[@class='epiq-table table table-condensed']/tbody/tr[" + caseRow + "]/td/div/i"));
                    Expand.Click();
                    IWebElement Details = driver.FindElement(By.XPath(".//*[@id='epiq-main-page-wrap']/div/div[4]/div/div/table/tbody/tr[" + expandRow + "]/td/div/div[7]/div/div[2]"));
                    caseRow++;
                    caseRow++;
                    expandRow++;
                    var ActualList = Details.Text;
                    var ExpectedList = ActualList;
                    Assert.AreEqual(ActualList, ExpectedList);
                }
            }
            this.ScrollUpToPageTop();
            this.WaitForElementToBeVisible(expandAndCollapseButton).Click();
        }
        public void ClickCollapseButton()
        {
            Thread.Sleep(1000);
            this.WaitForElementToBeVisible(expandAndCollapseButton).Click();
        }
        public void ClickSortingControls()
        {
            IList<IWebElement> SortingColumns = driver.FindElements(By.XPath("//*[@id='epiq-main-page-wrap']/div/div[4]/div/div/table/thead/tr/th/i"));
            int SortingColCount = SortingColumns.Count + 2;
            for (int column = 5; column <= SortingColCount; column++)
            {
                driver.FindElement(By.XPath("//th[" + column + "]/i")).Click();
                this.Pause(2);
            }
        }
        public string GetCasesCount()
        {
            return this.WaitForElementToBeVisible(caseCount).Text;
        }
        public void MarkCaseFavorite(string debtorName)
        {
            this.Pause(3);
            IList<IWebElement> rows = driver.FindElements(caseTableRowLocator);
            int caseRows = rows.Count;
            bool isFound = false;

            for (int row = 1; row <= caseRows; row++)
            {
                IWebElement debtor = driver.FindElement(By.XPath("//div[@class='epiq-table-wrapper clearfix ']//tr[" + row + "]//td[5]"));
                string DebtorResList = debtor.Text;
                if (DebtorResList == debtorName)
                {
                    WaitForElementToBeClickeable(By.XPath("//div[contains(@class,'epiq-table-wrapper')]//tr[" + row + "]//td[2]/i"), 4).Click();
                    isFound = true;
                    break;
                }
                row++;
            }
            Assert.IsTrue(isFound);
        }
        public void VerifyFavoriteCaseColor(string debtorName)
        {
            Thread.Sleep(3500);
            IList<IWebElement> rows = driver.FindElements(caseTableRowLocator);
            int caseRows = rows.Count;

            for (int row = 1; row <= caseRows; row++)
            {
                IWebElement debtor = driver.FindElement(By.XPath("//div[@class='epiq-table-wrapper clearfix ']//tr[" + row + "]//td[5]"));
                string DebtorResList = debtor.Text;

                if (DebtorResList == debtorName)
                {
                    Assert.IsTrue(IsElementVisible(By.XPath($"//table/tbody/tr[" + row + "]/td[2]/i[@class='fa fa-star epiq-favorite-cases-selected-star epiq-cursor-pointer']")));
                    var resColor = driver.FindElement(By.XPath("//div[contains(@class,'epiq-table-wrapper')]//td[2]/i")).GetCssValue("color");

                    string[] arrColor = resColor.Split(',');
                    string[] hexValue = resColor.Replace("rgba(", "").Replace(")", "").Split(',');

                    int hexValue1 = Int32.Parse(hexValue[0]);
                    hexValue[1] = hexValue[1].Trim();
                    int hexValue2 = Int32.Parse(hexValue[1]);
                    hexValue[2] = hexValue[2].Trim();
                    int hexValue3 = Int32.Parse(hexValue[2]);

                    string actualColor = string.Format("#e8e82d", hexValue1, hexValue2, hexValue3);
                    Assert.AreEqual("#e8e82d", actualColor);
                    break;
                }
                row++;
            }
        }
        public void DeselectedFavoriteCase(string debtorName)
        {
            Thread.Sleep(2000);
            IList<IWebElement> debtorData = driver.FindElements(By.XPath("//div[contains(@class,'epiq-table-wrapper')]//td[5]"));

            String[] allText = new String[debtorData.Count];
            int row = 0;
            foreach (IWebElement element in debtorData)
            {
                allText[row++] = element.Text;
                var debtorList = element.Text;
                if (debtorList == debtorName)
                {
                    Assert.False(IsElementVisible(markedFavorite));
                    break;
                }
            }
        }
        public void VerifyCaseInFavoriteTile(string caseNumber)
        {
            if (IsElementVisible(By.XPath($"//span[text()='{caseNumber}']")))
            {
                var caseDetails = WaitForElementToBeVisible(By.XPath($"//span[text()='{caseNumber}']")).Text;
                Assert.AreEqual(caseDetails, caseNumber);
            }
            else
            {
                Assert.False(IsElementVisible(By.XPath($"//span[text()='{caseNumber}']")));
            }
        }
        public void VerifyWhetherFavoriteIsEditable()
        {
            Assert.False(IsElementVisible(markedFavorite));
        }
        #endregion Basic Methods

        #region Methods for add case
        string date;
        public void AddNewCase()
        {
            var fName = new Bogus.DataSets.Name().Random.Word();
            var lName = new Bogus.DataSets.Name().Random.Word();
            var mName = new Bogus.DataSets.Name().Random.Word();
            var title = new Bogus.DataSets.Name().Prefix();
            var caseNum = new Faker().Random.Number(999999);
            date = DateTime.Now.Date.ToString("MM/dd/yy");
            WaitForElementToBeVisible(addCaseButton).Click();
            WaitForElementToBeVisible(caseNumberValue).SendKeys(caseNum.ToString());
            WaitForElementToBeVisible(petitionDate).SendKeys(date);
            Pause(2);
            WaitForElementToBeVisible(meetingDate).SendKeys(date);
            this.ScrollDown();
            this.WaitForElementToBeVisible(newParticipant).Click();
            SelectParticipantType("Individual");
            ScrollDown();
            InputNames(fName, mName, lName);
            ScrollDownToPageBottom();
           // this.WaitForElementToBeVisible(saveButton).Click();
        }

        public void SelectParticipantType(string selectType)
        {
            ScrollDown();
            IList<IWebElement> participantOptions = driver.FindElements(By.XPath("//span[contains(@class,'has-text')]"));
            this.Pause(2);
            foreach (IWebElement option in participantOptions)
            {
                if (option.Text == selectType)
                {
                    JavaScriptClick(option);
                    break;
                }
            }
        }
        public void InputNames(string firstName, string middleName, string lastName)
        {
            this.Pause(3);
            ClearAndType(WaitForElementToBeVisible(this.firstName), firstName);
            ClearAndType(WaitForElementToBeVisible(this.middleName), middleName);
            ClearAndType(WaitForElementToBeVisible(this.lastName), lastName);
            this.Pause(2);
        }
        public void InputPetitionDateFrom()
        {
            WaitForElementToBeVisible(petitionDateFrom).SendKeys(date);
        }

        #endregion Methods for add case
    }
}
