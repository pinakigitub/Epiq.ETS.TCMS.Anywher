using Epiq.ETS.TCMS.Anywhere.Testing.E2ETest.Test_Framework.Pages.Common;
using OpenQA.Selenium;
using FluentAssertions;
using System.Linq;
using System.Collections.Generic;
using Epiq.ETS.TCMS.Anywhere.Testing.E2ETest.Test_Framework.Core;
using System.Threading;
using Epiq.ETS.TCMS.Anywhere.Testing.E2ETest.Test_Framework.Utils;
using TechTalk.SpecFlow;

namespace Epiq.ETS.TCMS.Anywhere.Testing.E2ETest.Test_Framework.Pages.BankingCenter
{
    public class AddDeposit : UnityPageBase
    {
        private static string pageTitle = "UNITY";

        #region Constructor
        public AddDeposit(IWebDriver driver) : base(driver, pageTitle) { }
        #endregion

        #region Add Deposit Fields
        By linkAssetsClosingCost = By.XPath("//div[@class='epiq-link-list-container epiq-link-claim-list']/div/div/div");
        By depositClosingCostButton = By.XPath("//button[text()=' CLOSING COST (CLAIM)']");
        By depositClosingCostName = By.XPath("//div[@class='epiq-link-claim-list-item'][1]/div//div[label[text()='NAME']]/div//button");
        By depositClosingCostDescription = By.XPath("//div[@class='epiq-link-claim-list-item'][1]/div//div[label[text()='DESCRIPTION']]/div//button");
        //By DepositClosingCostUTC = By.XPath("//div[@class='epiq-link-claim-list-item'][1]/div//div[label[text()='UTC']]/div//button"); (Only One reference so commented)
        //By DepositClosingCostLinkedAmount = By.XPath("//div[@class='epiq-link-claim-list-item'][1]/div//div[label[text()='LINKED AMOUNT']]/div//button");(Only One reference so commented)
        By depositClosingCostX = By.XPath("//div[@class='epiq-form-item-display']/div/i");
        #endregion

        #region Add Closing cost Fields

        //By AddClosingCostNonClaimType = By.XPath("//div[@class='modal-body']//div[@class='epiq-radio-checkbox-list']/div[1]/div");(Only One reference so commented)
        By addClosingCostClaimType = By.XPath("//div[@class='epiq-radio-checkbox-list']//div[2]//label");
        By addClosingCostPayeeName = By.Name("addCLAIMListItem.payeeName");
        By addClosingCostDescription = By.Name("addCLAIMListItem.description");
        By addClosingCostLinkedAmount = By.Name("addCLAIMListItem.linkedAmount");
        By addClosingCostAddress = By.Name("addCLAIMListItem.address");
        By addClosingCostUTCCode = By.XPath("//div[@class='modal-body']//div[label[text()='UTC CODE']]//div/input");
        //By AddClosingCostUTCSubCode = By.XPath("//div[@class='modal-body']//div[label[text()='UTC SUB CODE']]/div");(Only One reference so commented)
        //By AddClosingCostNonCompensible = By.XPath("//div[@class='modal-body']//div[3]/div/div/label");(Only One reference so commented)
        By addClosingCostAdd = By.XPath("//div[@class='modal-footer']//button[@class='btn btn-info']");
        By addClosingCostCancel = By.XPath("//div[@class='modal-footer']//button[@class='btn btn-default']");
        By addClosingCostRequiredFields = By.XPath("//div[@class='row epiq-lookup-picker-card-content-body']");
        By addClosingCostSearchClaim = By.XPath("//div[@class='modal-body']/div[1]/div[2]/div[1]//input");
        //By AddClosingCostRecords = By.XPath("//div[@class='modal-body']/div[1]/div[2]/div[2]/div/div/div | //div[@class='modal-body']/div[1]/div[2]/div[2]/div/div/span");(Only One reference so commented)
        By addClosingCostReport = By.XPath("//div[text()='FARID AHMED']");

        #endregion

        #region Properties
        List<string> _claimNames = new List<string>();
        List<string> _claimNumbers = new List<string>();
        public List<string> ClaimNames { get { return _claimNames; } }
        public List<string> ClaimNumbers { get { return _claimNumbers; } }
        #endregion

        #region Methods

        public void VerifyDefaultAssetsAndClosingCosts()
        {
            ScrollDownToPageBottom();
            this.WaitForElementToBePresent(linkAssetsClosingCost, 2);
            var text = driver.FindElements(linkAssetsClosingCost).Select(e => e.Text.Trim()).ToList();
            text.Should().Contain(new List<string>() { "No Assets Linked", "No Closing Costs Linked" });
        }

        public void ClickClosingCostButton()
        {
            ScrollDownToPageBottom();
            this.WaitForElementToBePresent(depositClosingCostButton).Click();
        }

        public void VerifyAddClosingCostModal()
        {
            this.WaitForElementToBePresent(addClosingCostRequiredFields, 2).Click();

            //// Verify Required fields
            //var requiredFields = driver.FindElements(ADD_CLOSING_COST_REQUIRED_FIELDS).Select(e => e.Text.Trim()).ToList();
            //requiredFields.Should().Contain(new List<string>() { "PAYEE NAME", "DESCRIPTION", "AMOUNT", "UTC CODE" });

            //// Closing modal controls displayed
            //this.WaitForElementToBePresent(ADD_CLOSING_COST_NON_CLAIM_TYPE, 1).Displayed.Should().BeTrue();
            //this.WaitForElementToBePresent(ADD_CLOSING_COST_CLAIM_TYPE, 1).Displayed.Should().BeTrue();
            //this.WaitForElementToBePresent(ADD_CLOSING_COST_LINKEDAMOUNT, 1).Displayed.Should().BeTrue();
            //this.WaitForElementToBePresent(ADD_CLOSING_COST_ADDRESS, 1).Displayed.Should().BeTrue();
            //this.WaitForElementToBePresent(ADD_CLOSING_COST_UTC_SUB_CODE, 1).Displayed.Should().BeTrue();
            //this.WaitForElementToBePresent(ADD_CLOSING_COST_NON_COMPENSIBLE, 1).Displayed.Should().BeTrue();
            //this.WaitForElementToBePresent(ADD_CLOSING_COST_ADD, 1).Displayed.Should().BeTrue();
            //this.WaitForElementToBePresent(ADD_CLOSING_COST_CANCEL, 1).Displayed.Should().BeTrue();

            //// Closing Modal
            //this.WaitForElementToBeClickeable(ADD_CLOSING_COST_CANCEL).Click();
        }

        public void VerifyClaimType()
        {
            //this.WaitForElementToBeClickeable(ADD_CLOSING_COST_NON_CLAIM_TYPE).Selected.Should().BeTrue();
        }

        public void SelectClaimRadioButton()
        {
            Pause(1);
            this.WaitForElementToBeClickeable(addClosingCostClaimType).Click();
        }

        public void EnterAllFields()
        {
            this.WaitForElementToBeClickeable(addClosingCostPayeeName).Text.Should().BeNullOrWhiteSpace();
            this.WaitForElementToBeClickeable(addClosingCostDescription).Text.Should().BeNullOrWhiteSpace();
            this.WaitForElementToBeClickeable(addClosingCostLinkedAmount).Text.Should().BeNullOrWhiteSpace();
            this.WaitForElementToBeClickeable(addClosingCostAddress).Text.Should().BeNullOrWhiteSpace();
            ScenarioContext.Current.Add("ClosingCostFullName", FakeData.FullName());
            ScenarioContext.Current.Add("ClosingCostDescription", FakeData.Description());

            this.WaitForElementToBeClickeable(addClosingCostPayeeName).SendKeys(ScenarioContext.Current.Get<string>("ClosingCostFullName"));
            this.WaitForElementToBeClickeable(addClosingCostDescription).SendKeys(ScenarioContext.Current.Get<string>("ClosingCostDescription"));
            this.WaitForElementToBeClickeable(addClosingCostLinkedAmount).SendKeys(FakeData.RandomNumber(3).ToString());
            this.WaitForElementToBeClickeable(addClosingCostAddress).SendKeys(FakeData.RandomAddress());
            this.WaitForElementToBeClickeable(addClosingCostUTCCode).SendKeys("2100");
            this.WaitForElementToBeClickeable(addClosingCostUTCCode).SendKeys(Keys.ArrowDown);
            this.WaitForElementToBeClickeable(addClosingCostUTCCode).SendKeys(Keys.Enter);
        }

        public void VerifyAddedClosingCost()
        {
            ScrollDownToPageBottom();
            this.WaitForElementToBePresent(depositClosingCostName, 1).Text.Should().Equals(ScenarioContext.Current.Get<string>("ClosingCostFullName"));
            this.WaitForElementToBePresent(depositClosingCostDescription, 1).Text.Should().Equals(ScenarioContext.Current.Get<string>("ClosingCostDescription"));
            //this.WaitForElementToBePresent(ADD_CLOSING_COST_LINKEDAMOUNT, 1).Text.Should().Equals(ScenarioContext.Current.Get<string>("ClosingCostAmount"));
        }
        public void RemoveClosingCost()
        {
            this.WaitForElementToBePresent(depositClosingCostX, 8).Click();
        }
        public bool VerifyClosingCostRecordPresent()
        {
            try
            {
                return this.WaitForElementToBePresent(depositClosingCostX, 8).Displayed;
            }
            catch { return false; }
        }
        public void ClearAllFields()
        {
            this.WaitForElementToBeClickeable(addClosingCostPayeeName).Clear();
            this.WaitForElementToBeClickeable(addClosingCostDescription).Clear();
            this.WaitForElementToBeClickeable(addClosingCostLinkedAmount).Clear();
            this.WaitForElementToBeClickeable(addClosingCostAddress).SendKeys(Keys.LeftControl + "a" + Keys.Delete);
            driver.FindElements(By.XPath("//div[@class='modal-content']/div[@class='modal-body']//span[text()='×']")).ToList().ForEach(e => { e.Click(); });

        }

        public void VerifyAllFieldsCleared()
        {
            this.WaitForElementToBePresent(addClosingCostPayeeName, 1).Text.Should().BeNullOrWhiteSpace();
            this.WaitForElementToBePresent(addClosingCostDescription, 1).Text.Should().BeNullOrWhiteSpace();
            this.WaitForElementToBePresent(addClosingCostLinkedAmount, 1).Text.Should().BeNullOrWhiteSpace();
            this.WaitForElementToBePresent(addClosingCostAddress, 1).Text.Should().BeNullOrWhiteSpace();
            this.WaitForElementToBeClickeable(addClosingCostUTCCode).Text.Should().BeNullOrWhiteSpace();
        }

        public void ClearPayeeName()
        {
            this.WaitForElementToBeClickeable(addClosingCostPayeeName).Clear();
        }

        public string VerifyPayeeNameCleared()
        {
            return this.WaitForElementToBeClickeable(addClosingCostPayeeName).Text;
        }

        public bool GetAsteriskDispalyed()
        {
            try
            {
                Thread.Sleep(1000);
                driver.FindElement(By.XPath("//div[@class='modal-body']//span[text()='*']"));
                return true;
            }
            catch
            {
                return false;
            }
        }

        public void EnterClaimNameSearch(string claimName)
        {
            this.WaitForElementToBeClickeable(addClosingCostSearchClaim).Clear();
            this.WaitForElementToBeClickeable(addClosingCostSearchClaim).SendKeys(claimName);
        }

        public ClaimRecord GetClaimResults()
        {
            ClaimRecord cliamRecord = null;
            for (var i = 0; i < 4; i++)
            {
                try
                {
                    var records = this.WaitForElementToBeClickeable(addClosingCostReport);
                    if (records.FindElements(By.ClassName("epiq-lookup-picker-card  ")).Count <= 1)
                        cliamRecord = new ClaimRecord(records);
                    else
                    {
                        foreach (var record in records.FindElements(By.ClassName("epiq-lookup-picker-card  ")))
                        {
                            var claims = new ClaimRecord(record);
                            _claimNames.Add(claims.ClaimName);
                            _claimNumbers.Add(claims.ClaimNumber);
                        }
                    }
                    break;
                }
                catch (StaleElementReferenceException e)
                {
                    continue;
                }
            }
            return cliamRecord;
        }

        public List<string> GetClaimResultsInfo()
        {
                this.Pause(5);
                var record = this.WaitForElementToBeClickeable(addClosingCostReport);
                var records = new ClaimRecord(record);
                var list = new List<string>(){
               records.ClaimName,records.ClaimNumber,records.Code,records.Allowed,records.PaidToDate,records.BalanceDue,
            };
                 return list;              
        }

        public void ClickClaimClosingCostModal()
        {
            var AddClosingCostClose = driver.FindElement(By.XPath($"//div[@class='modal-content']/div/button"));
            ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].click();", AddClosingCostClose);
        }
       public void ClickAddButton()
        {
            this.WaitForElementToBePresent(addClosingCostAdd).Click();
        }
        public void ClickCancelButton()
        {
            this.WaitForElementToBePresent(addClosingCostCancel,2).Click();
            Pause(1);
        }
        public bool VerifyAddDepositPage()
        {
            this.Pause(3);
            JSMoveToViewElement(this.WaitForElementToBePresent(By.TagName("h4")));
            return this.WaitForElementToBePresent(By.TagName("h4")).Text.Contains("Add Closing Cost");
        }
        #endregion

        public class ClaimRecord
        {
            #region Methods

            IWebElement record;

            By claimName = By.ClassName("epiq-lookup-picker-card-content-title");
            By claimNumber = By.XPath("//div[label[text()='CLAIM NUMBER']]/div");
            By code = By.XPath("//div[label[text()='CODE']]/div");
            By claimed = By.XPath("//div[label[text()='CLAIMED']]/div");
            By allowed = By.XPath("//div[label[text()='ALLOWED']]/div");
            By paidToDate = By.XPath("//div[label[text()='PAID TO DATE']]/div");
            By balanceDue = By.XPath("//div[label[text()='BALANCE DUE']]/div");

            #endregion
            public ClaimRecord(IWebElement claimRecord)
            {
                record = claimRecord;
            }

            public string ClaimName { get { Thread.Sleep(2000); return record.FindElement(claimName).Text; } }
            public string ClaimNumber { get { Thread.Sleep(2000); return record.FindElement(claimNumber).Text; } }
            public string Code { get { Thread.Sleep(2000); return record.FindElement(code).Text; } }
            public string Claimed { get { Thread.Sleep(2000); return record.FindElement(claimed).Text; } }
            public string Allowed { get { Thread.Sleep(2000); return record.FindElement(allowed).Text; } }
            public string PaidToDate { get { Thread.Sleep(2000); return record.FindElement(paidToDate).Text; } }
            public string BalanceDue { get { Thread.Sleep(2000); return record.FindElement(balanceDue).Text; } }
            public string NoResultsFound { get { Thread.Sleep(2000); return record.FindElement(By.TagName("span")).Text; } }

        }
    }
}
