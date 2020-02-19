using System;
using Epiq.ETS.TCMS.Anywhere.Testing.E2ETest.Test_Framework.Pages;
using OpenQA.Selenium;
using Epiq.ETS.TCMS.Anywhere.Testing.E2ETest.TestFramework.Pages.Cases.Detail;
using OpenQA.Selenium.Interactions;
using System.Collections.Generic;
using Epiq.ETS.TCMS.Anywhere.Testing.E2ETest.Test_Framework.Pages.Cases.Detail.Banking;

namespace Epiq.ETS.TCMS.Anywhere.Testing.E2ETest.TestFramework.Pages.Cases.Detail
{
    public class TransactionForm:BankingDetailTab
    {
        protected bool isCheck = true;
        protected bool isNew = true;
        private ClaimLinksComponent _ClaimLinks;

        private By TRANSACTION_FORM_TITLE_LOCATOR = By.XPath("//*[@class[contains(.,'transactionHeader')]]//*[contains(@id,'Title')]");
       
        private By SERIAL_NUMBER_INPUT_LOCATOR = By.XPath("//input[contains(@id,'SerialTextBox')]");
        private By SERIAL_NUMBER_INPUT_READ_ONLY_LOCATOR = By.XPath("//*[contains(@id,'SerialLabel')]");
        private By SERIAL_NUMBER_LABEL_LOCATOR = By.XPath("//*[contains(@id,'SerialTextBox')]/label");

        //Pay to the Order Of / Received
        //deposit
        private By RECEIVED_PAY_TO_INPUT_LOCATOR = By.XPath("//input[contains(@id,'receivedTextBox') or contains(@id, 'ayToTheOrderOfValue')]");
        private By RECEIVED_PAY_TO_INPUT_READ_ONLY_LOCATOR = By.XPath("//span[@id[contains(.,'receivedLabel')] or @id[contains(.,'payToTheOrderOfLabel')]]");
        private By RECEIVED_PAY_TO_LABEL_LOCATOR = By.XPath("//*[contains(@id,'receivedTextBox') or contains(@id, 'ayToTheOrderOfValue')]/label");
        //check
        private By RECEIVED_PAY_TO_SELECT2_LABEL_LOCATOR = By.Id("searchLabelPayToTheOrderOfValue");
        private By RECEIVED_PAY_TO_SELECT2_PLACEHOLDER_LOCATOR = By.CssSelector("#select2-PayToTheOrderOfValue-container > span.select2-selection__placeholder");
        private By RECEIVED_PAY_TO_SELECT2_VALUE_LOCATOR = By.Id("select2-PayToTheOrderOfValue-container");
        private By RECEIVED_PAY_TO_SELECT2_READ_ONLY_VALUE_LOCATOR = By.XPath("//*[@id[contains(.,'payToTheOrderOfLabel')]]");
        private By RECEIVED_PAY_TO_SELECT2_INPUT_LOCATOR = By.XPath("//input[@class='select2-search__field']");

        private By NAME_SELECT2_RESULT_ROW_LOCATOR = By.XPath("//*[@id='select2-PayToTheOrderOfValue-results']/*");
        private string NAME_SELECT2_RESULT_BY_NOT_CONTAINS_TEXT_TEMPLATE_LOCATOR = "//li[contains(@class,'select2-results__option')]/div[not(contains(text(),'{0}'))]";
        private string NAME_SELECT2_RESULT_BY_TEXT_TEMPLATE_LOCATOR = "//li[contains(@class,'select2-results__option') and contains(text(),'{0}')]";
        
        private By RECEIVED_PAY_TO_VALIDATION_MSG_LOCATOR = By.XPath("//*[@id='receivedTextBox']/*[@class='aurelia-validation-message error']");
        private By RECEIVED_PAY_TO_SELECT2_VALIDATION_MSG_LOCATOR = By.XPath("//*[@id='PayToTheOrderOfValue']/*[@class='aurelia-validation-message error']");      

        //Description
        private By DESCRIPTION_INPUT_LOCATOR = By.XPath("//input[contains(@id,'DescriptionTextBox') or contains(@id,'descriptionTextBox')]");
        private By DESCRIPTION_LABEL_LOCATOR = By.XPath("//*[contains(@id,'escriptionTextBox')]/label");

        //Transaction Date
        private By TRX_DATE_DEPOSIT_INPUT_READ_ONLY_LOCATOR = By.XPath("//span[contains(@id,'TransactionLabel') or @id[contains(.,'transactionDateBoxLabel')] or @id[contains(.,'checkTransactionDateLabel')]]");
        private By TRX_DATE_DEPOSIT_LABEL_READ_ONLY_LOCATOR = By.XPath("//my-label[@id='depositTransactionLabel']/label");


        private By TRX_DATE_INPUT_LOCATOR = By.XPath("//input[contains(@id,'ransactionDate')]");
        private By TRX_DATE_LABEL_LOCATOR = By.XPath("//*[contains(@id,'ransactionDate')]//label");
        private By TRX_DATE_VALIDATION_MSG_LOCATOR = By.XPath("//*[contains(@id,'ransactionDate')]//small[@class='aurelia-validation-message error']");          


        protected By CLEARED_DATE_INPUT_LOCATOR = By.XPath("//input[contains(@id,'learedDate')]");        
        private By CLEARED_DATE_LABEL_LOCATOR = By.XPath("//*[contains(@id,'learedDate')]//label");
        private By CLEARED_DATE_VALIDATION_MSG_LOCATOR = By.XPath("//*[contains(@id,'learedDate')]//small[@class='aurelia-validation-message error']");
                
        private By CODE_INPUT_CONTAINER_LOCATOR = By.XPath("//*[contains(@id, 'select2-mainCodeDropdown-container')]");        

        private By CODE_INPUT_LOCATOR = By.XPath("//*[contains(@class,'select2-search__field')]");
        private By CHECK_CODE_LABEL_LOCATOR = By.XPath("//*[contains(@id,'codeSearchLabel')]");
        private By DEPOSIT_CODE_LABEL_LOCATOR = By.CssSelector("#containerCheckCode>span");

        private By CHECK_SUBCODE_LABEL_LOCATOR = By.XPath("//*[contains(@id,'subcodeDropdown')]//label");
        private By SUBCODE_VALUE_LOCATOR = By.XPath(".//*[contains(@id,'subcodeDropdown')]//*[contains(@class,'selectParent')]/span");

        private By NON_COMPENSABLE_INPUT_LOCATOR = By.CssSelector("input#checkbox1");
        private By NON_COMPENSABLE_LABEL_LOCATOR = By.Id("label1");

        private By ASSET_LINK_LABEL_LOCATOR = By.XPath("//label[@id[contains(.,'AssetTitle')]]");
        
        private By AMOUNT_INPUT_LOCATOR = By.XPath("//input[contains(@id,'netDeposit') or contains(@id, 'Amount')]");
        private By AMOUNT_LABEL_LOCATOR = By.XPath("//*[contains(@id,'netDeposit') or contains(@id, 'Amount')]/label");
        private By AMOUNT_VALIDATION_MSG_LOCATOR = By.XPath("//*[contains(@id,'netDeposit') or contains(@id, 'Amount')]//small[@class='aurelia-validation-message error']");
        
        private By CANCEL_BUTTON_LOCATOR = By.Id("cancelNewTransactionButton");
        protected By SAVE_BUTTON_LOCATOR = By.Id("saveNewTransactionButton");
        private By SAVE_AND_ADD_ANOTHER_BUTTON_LOCATOR = By.Id("saveAndAddAnotherNewTransactionButton");

        //UTC Split
        private By SUM_OF_ALLOCATION_VALUE_LOCATOR = By.XPath("//*[@id[contains(.,'umOfAllocationValue')]]");
        private By UTC_SPLIT_TITLE_LOCATOR = By.Id("utcSplitLinkTitle");
        private By UTC_SPLIT_LINK_LOCATOR = By.CssSelector(".addRowOption");
        private By UTC_SPLIT_LINK_ICON_LOCATOR = By.XPath("//*[@id='utc-addRowContainer-firstRow']/i");
        private By UTC_SPLIT_CODE_LABEL_LOCATOR = By.Id("codeHeader");
        private By UTC_SPLIT_NON_COMPENSABLE_LABEL_LOCATOR = By.Id("nonCompensableHeader");
        private By UTC_SPLIT_CODE_AMOUNT_LABEL_LOCATOR = By.Id("amountHeader");
        private By UTC_SPLIT_TABLE_ROW_LOCATOR = By.XPath("//*[@id='utcSplitTable']//tr");
        private By UTC_SPLIT_VALIDATION_MESSAGE_LOCATOR = By.Id("errorMessage");
        private string UTC_SPLIT_REMOVE_ICON_BY_ROW_POSITION_LOCATOR_TEMPLATE = "//*[@id='utcSplitTable']//*[@id='icon-{0}-remove']";
        private string UTC_SPLIT_NAME_BY_POSITION_LOCATOR_TEMPLATE = "//*[@id='utcSplitTable-{0}-name']";
        private string UTC_SPLIT_CODE_CONTAINER_BY_POSITION_LOCATOR_TEMPLATE = "//*[@id='select2-utcSplitTable-{0}-checkCodeTextBox-container']";
        private string UTC_SPLIT_ALLOCATION_DESCRIPTION_BY_POSITION_LOCATOR_TEMPLATE = "//*[@id='utcSplitTable-{0}-allocation']";        
        private string UTC_SPLIT_NON_COMPENSABLE_BY_POSITION_LOCATOR_TEMPLATE = "//*[@id='checkboxutcSplitTable-{0}-']";
        private string UTC_SPLIT_NON_COMPENSABLE_LABEL_BY_POSITION_LOCATOR_TEMPLATE = "//*[@id='labelutcSplitTable-{0}-']";
        private string UTC_SPLIT_AMOUNT_BY_POSITION_LOCATOR_TEMPLATE = "//*[@id='utcSplitTable-{0}-amount']";
        

        //Closing costs
        private By SUM_OF_CLOSING_COSTS_LABEL_LOCATOR = By.Id("sumOfClosingCosts");
        private By SUM_OF_CLOSING_COSTS_VALUE_LOCATOR = By.Id("sumOfClosingCostsValue");
        private By GROSS_DEPOSIT_INPUT_LOCATOR = By.XPath("//input[@id='grossDepositTextbox']");
        private By DEPOSIT_BOTTOM_VALIDATION_MESSAGES_LOCATOR = By.Id("message.id");

        //Transfer Founds transaction only
        private By FROM_BANK_ACCOUNT_LABEL_LOCATOR = By.CssSelector(".labelTransferFunds");
        private By FROM_BANK_ACCOUNT_LOCATOR = By.Id("fromBankAndAccount");
        private By TO_BANK_ACCOUNT_LOCATOR = By.XPath("//my-dropdown[@id='toBankAndAccount']");
        private By RECEIVED_PAY_TO_SELECT2_ARROW_LOCATOR = By.XPath("//*[contains(@id,'searchLabelPayToTheOrderOfValue')]//*[contains(@class,'select2-selection__arrow')]");
        private By CODE_OPEN_ARROW_LOCATOR = By.XPath("//*[contains(@id,'mainCodeDropdown')]//*[contains(@class,'select2-selection__arrow')]");

        public TransactionForm(IWebDriver driver, bool check, bool isNew): base(driver)
        {
            this.isCheck = check;
            this.isNew = isNew;
        }

        
        // FORM TITLE
        public string TransactionFormTitle
        {
            get
            {                
                return this.WaitForElementToBeVisible(TRANSACTION_FORM_TITLE_LOCATOR).Text;                
            }
        }

        //SERIAL NUMBER
        //label
        public string SerialNumberLabel
        {
            get
            {
                return this.WaitForElementToBeVisible(SERIAL_NUMBER_LABEL_LOCATOR).Text;
            }
        }

        //value
        public string SerialNumber {
            get {
                if (isNew)
                {
                return this.WaitForElementToBeVisible(SERIAL_NUMBER_INPUT_LOCATOR).GetAttribute("value");
                }
                else
                {
                    string ret = this.WaitForElementToBeVisible(SERIAL_NUMBER_INPUT_READ_ONLY_LOCATOR).Text;
                    if (ret.Contains("\r\n"))
                    {
                        string[] stringSeparators = new string[] { "\r\n" };
                        ret = ret.Split(stringSeparators, StringSplitOptions.None)[1].TrimEnd(' ');
                    }

                    return ret;
                }
            }
            set {
                this.ClearAndType(this.WaitForElementToBeVisible(SERIAL_NUMBER_INPUT_LOCATOR), value);
            }
        }

        public void ClickOnAmountField()
        {
            this.WaitForElementToBeVisible(AMOUNT_INPUT_LOCATOR).Click();
        }

        //NAME - PAY TO THE ORDER OF OR RECEIVED FROM
        //TODO convert to ToOrFromName property with get-set
        public void SetName(string payTo)
        {
            if (this.isNew)
            {
                if (this.isCheck)
                {
                    this.TypePayToTheOrderOf(payTo);
                    this.Pause(2);
                    this.SelectFirstResultPayToTheOrderOfContaining(payTo);
                }
                else
                {
                    //deposit is just text field
                    this.ClearAndType(this.WaitForElementToBeVisible(RECEIVED_PAY_TO_INPUT_LOCATOR), payTo);
                }
            }//else do nothing, name is not editable
        }

        public string GetTransactionName()
        {
            if (this.isNew)
            {
                if (this.isCheck) {
                    string[] stringSeparators = new string[] { "\b" };
                    string[] name = this.WaitForElementToBeVisible(RECEIVED_PAY_TO_SELECT2_VALUE_LOCATOR).Text.Split(stringSeparators, StringSplitOptions.None);
                    return name[0].TrimEnd(' ');                    
                }
            else
                return this.WaitForElementToBeVisible(RECEIVED_PAY_TO_INPUT_LOCATOR).GetAttribute("value");
        }
            else
            {
                if (this.isCheck)
                    return this.WaitForElementToBeVisible(RECEIVED_PAY_TO_SELECT2_READ_ONLY_VALUE_LOCATOR).Text;
                else
                    return this.WaitForElementToBeVisible(RECEIVED_PAY_TO_INPUT_READ_ONLY_LOCATOR).Text;
            }

        }

        public void TypePayToTheOrderOf(string payTo)
        {
            //Center screen to see Name field
            this.MoveToViewElement(this.WaitForElementToBeVisible(TRX_DATE_LABEL_LOCATOR));
            this.MoveToViewElement(this.WaitForElementToBeVisible(ACCOUNT_SUMMARY_SECTION_TITLE_LOCATOR));

            try
            {
                //input could be already be visible (if opens up when opening the form)
                this.ClearAndType(this.WaitForElementToBeVisible(RECEIVED_PAY_TO_SELECT2_INPUT_LOCATOR, 5), payTo);
            }
            catch (Exception)
            {
                //if not visible, then open it and type the name
                this.WaitForElementToBeVisible(RECEIVED_PAY_TO_SELECT2_ARROW_LOCATOR).Click();
                this.ClearAndType(this.WaitForElementToBeVisible(RECEIVED_PAY_TO_SELECT2_INPUT_LOCATOR), payTo);
            }

            this.Pause(2);
        }

        public void SelectFirstResultPayToTheOrderOfContaining(string payTo)
        {
            //select the first participant record (add new participant record)
            this.WaitForElementToBeVisible(By.XPath(String.Format(NAME_SELECT2_RESULT_BY_TEXT_TEMPLATE_LOCATOR, payTo))).Click();
        }

        public void SelectFirstResultPayToTheOrderOfNotContaining(string payTo)
        {
            //select the first participant record (add new participant record)
            this.WaitForElementToBeVisible(By.XPath(String.Format(NAME_SELECT2_RESULT_BY_NOT_CONTAINS_TEXT_TEMPLATE_LOCATOR, payTo))).Click();
        }

        public List<string> PayToTheOrderOfSearchResults
        {
            get
            {
                List<string> ret = new List<string>();
                IReadOnlyCollection<IWebElement> results = this.WaitForElementsToBeVisible(NAME_SELECT2_RESULT_ROW_LOCATOR);
                foreach (IWebElement result in results)
                {
                    ret.Add(result.Text);
                }
                return ret;
            }
        }

        public List<string> GetPayToTheOrderOfResultsByContent(string text)
        {
            List<string> ret = new List<string>();
            IReadOnlyCollection<IWebElement> results = this.WaitForElementsToBeVisible(By.XPath(String.Format(NAME_SELECT2_RESULT_BY_TEXT_TEMPLATE_LOCATOR, text)));
            foreach (IWebElement result in results)
            {
                ret.Add(result.Text);
            }

            return ret;
        }

        public string ToOrFromNameLabel
        {
            get
            {
                if (this.isCheck)
                {
                    string[] stringSeparators = new string[] { "\r\n" };
                    string[] name = this.WaitForElementToBeVisible(RECEIVED_PAY_TO_SELECT2_LABEL_LOCATOR).Text.Split(stringSeparators, StringSplitOptions.None);
                    string ret = name[0];
                    return ret.TrimEnd(' ');
                }else
                {
                    return this.WaitForElementToBeVisible(RECEIVED_PAY_TO_LABEL_LOCATOR).Text;
                }
            }
        }

        public string ToOrFromNamePlaceholder
        {
            get
            {
                if(this.isCheck)
                    return this.WaitForElementToBeVisible(RECEIVED_PAY_TO_SELECT2_PLACEHOLDER_LOCATOR).Text;
                else
                    return this.WaitForElementToBeVisible(RECEIVED_PAY_TO_INPUT_LOCATOR).GetAttribute("placeholder");
            }
        }


        //DESCRIPTION
        //TODO convert to Description property with get-set

        public void SetDescription(string description)
        {
            this.ClearAndType(this.WaitForElementToBeVisible(DESCRIPTION_INPUT_LOCATOR), description);
        }

        public bool UTCSplitRowsDissapeared()
        {
            try
            {
                this.WaitForElementToDissapear(UTC_SPLIT_TABLE_ROW_LOCATOR);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool IsCodeDefaultInputVisible()
        {
            try
            {
                this.WaitForElementToBeVisible(CODE_INPUT_CONTAINER_LOCATOR);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public string DescriptionLabel
        {
            get
            {
                return this.WaitForElementToBeVisible(DESCRIPTION_LABEL_LOCATOR).Text;
            }
        }

        public string DescriptionPlaceholder
        {
            get
            {
                return this.WaitForElementToBeVisible(DESCRIPTION_INPUT_LOCATOR).GetAttribute("placeholder");
            }
        }


        //TRANSACTION DATE
        private By TrxDateInputLocator
        {
            get
            {
                By trxDateInputLocator;
                trxDateInputLocator = TRX_DATE_INPUT_LOCATOR;               
                return trxDateInputLocator;
            }
        }

        private By TrxDateInputReadOnlyLocator
        {
            get
            {
                By TrxDateInputReadOnlyLocator;
                    if (this.isCheck && this.isNew)
                        TrxDateInputReadOnlyLocator = TRX_DATE_INPUT_LOCATOR;
                    else
                        TrxDateInputReadOnlyLocator = TRX_DATE_DEPOSIT_INPUT_READ_ONLY_LOCATOR;

                return TrxDateInputReadOnlyLocator;
            }
        }

        //TODO convert to Trx Date property set
        public void SetTransactionDate(string TrxDate)
        {
            //IWebElement trxDateWE = this.WaitForElementToBeVisible(this.TrxDateInputLocator);
            if (this.isNew)
            {
                IWebElement trxDateWE = this.WaitForElementToLooseAttribute(this.TrxDateInputLocator, "disabled");
                this.ClearAndType(trxDateWE, TrxDate);
                trxDateWE.SendKeys(Keys.Tab);
                trxDateWE.SendKeys(Keys.Escape);
                if (this.isNew)
                    this.clickNotVisualizedElement(this.WaitForElementToBeVisible(DESCRIPTION_INPUT_LOCATOR));   
                else
                    this.clickNotVisualizedElement(this.WaitForElementToBeVisible(TRANSACTION_FORM_TITLE_LOCATOR));
            }
        }

        public string TransactionDate
        {
            get
            {
                if (isNew)
                {
                return this.WaitForElementToBeVisible(this.TrxDateInputLocator).GetAttribute("value");               
            }
                else
                {
                    return this.WaitForElementToBeVisible(this.TrxDateInputReadOnlyLocator).Text;
                }
        }
        }

        public string TransactionDateLabel
        {
            get
            {             
                string ret = this.WaitForElementToBeVisible(TRX_DATE_LABEL_LOCATOR).Text;
                if (ret.Contains("\r\n"))
                {
                    string[] stringSeparators = new string[] { "\r\n" };
                    ret = ret.Split(stringSeparators, StringSplitOptions.None)[0].TrimEnd(' ');
                }           

                return ret;
            }
        }

        public string TransactionDatePlaceholder
        {
            get
            {                
                return this.WaitForElementToBeVisible(this.TrxDateInputLocator).GetAttribute("placeholder");
            }
        }


        //CLEARED DATE
        private By ClearedInputLocator
        {
            get {
                By clearedInputLocator;
                clearedInputLocator = CLEARED_DATE_INPUT_LOCATOR;                
                return clearedInputLocator;
            }
        }

        //TODO Convert to Cleared property set
        public void SetClearedDate(string clearedDate)
        {
            IWebElement clearedDateWE = this.WaitForElementToBeVisible(this.ClearedInputLocator);
            this.ClearAndType(clearedDateWE, clearedDate);
            clearedDateWE.SendKeys(Keys.Tab);
            clearedDateWE.SendKeys(Keys.Escape);
            if (this.isNew)
                this.clickNotVisualizedElement(this.WaitForElementToBeVisible(DESCRIPTION_INPUT_LOCATOR));
            else
                this.clickNotVisualizedElement(this.WaitForElementToBeVisible(TRANSACTION_FORM_TITLE_LOCATOR));
        }

        

        public string Cleared
        {
            get {
                return this.WaitForElementToBeVisible(this.ClearedInputLocator).GetAttribute("value");
            }
        }

        public string ClearedLabel
        {
            get
            {
                return this.WaitForElementToBeVisible(CLEARED_DATE_LABEL_LOCATOR).Text;
            }
        }

        public string ClearedPlaceholder
        {
            get
            {
                return this.WaitForElementToBeVisible(this.ClearedInputLocator).GetAttribute("placeholder");
            }
        }


        //UTC SPLIT

        public void ClickAddUTCSplit()
        {
            this.MoveToViewElement(this.WaitForElementToBeVisible(SAVE_BUTTON_LOCATOR));
            this.MoveToViewElement(this.WaitForElementToBeVisible(UTC_SPLIT_LINK_LOCATOR));
            this.WaitForElementToBeVisible(UTC_SPLIT_LINK_LOCATOR).Click();
        }


        public string UTCSplitLinkText{
            get {
                return this.WaitForElementToBeVisible(UTC_SPLIT_LINK_LOCATOR).Text;
            }
        }

        public bool IsUTCSplitLinkIconVisible {
            get {
                try
                {
                    this.WaitForElementToBeVisible(UTC_SPLIT_LINK_ICON_LOCATOR);
                    return true;
                }
                catch (Exception)
                {
                    return false;
                }
            }
        }

        //CODE
        //TODO convert to Code property set
        public void SetCode(string code)
        {
            try
            {
                this.WaitForElementToBePresent(CODE_OPEN_ARROW_LOCATOR).Click();                
            }
            catch (Exception)
            {
                //do nothing, code input might be already open
            }
            //IWebElement codeLabel = this.WaitForElementToBeVisible(CHECK_CODE_LABEL_LOCATOR);
            //this.JSMoveToViewElement(codeLabel);
            IWebElement codeInput = this.WaitForElementToBeVisible(CODE_INPUT_LOCATOR);
            this.ClearAndType(codeInput, code);
            this.Pause(2);
            codeInput.SendKeys(Keys.Enter);
            this.Pause(1);
        }

        private By GetCodeLocator()
        {                
            return CODE_INPUT_CONTAINER_LOCATOR;
        }

        public string Code
        {
            get
            {
                return this.WaitForElementToBeVisible(this.GetCodeLocator()).Text.Replace("\r\n","");
            }
            set
            {
                this.SetCode(value);
        }
        }

        public string CodeLabel
        {
            get
            {
                if (isCheck)
                {
                    string[] stringSeparators = new string[] { "\r\n" };
                    return this.WaitForElementToBeVisible(CHECK_CODE_LABEL_LOCATOR).Text.Split(stringSeparators, StringSplitOptions.None)[0].TrimEnd(' ');
            }
                else {
                    try
                    {
                        return this.WaitForElementToBeVisible(DEPOSIT_CODE_LABEL_LOCATOR).Text;
                    }
                    catch (Exception)
                    {
                        string[] stringSeparators = new string[] { "\r\n" };
                        return this.WaitForElementToBeVisible(CHECK_CODE_LABEL_LOCATOR).Text.Split(stringSeparators, StringSplitOptions.None)[0].TrimEnd(' ');
                    }
        }
            }
        }

        public string SubCodeLabel
        {
            get
            {               
                    string[] stringSeparators = new string[] { "\r\n" };
                    return this.WaitForElementToBeVisible(CHECK_SUBCODE_LABEL_LOCATOR).Text.Split(stringSeparators, StringSplitOptions.None)[0].TrimEnd(' ');                
            }
        }


        public string SubCode {
            get {                
                return this.WaitForElementToBeVisible(SUBCODE_VALUE_LOCATOR).Text.Replace("\r\n", "");
            }
        }

        //NON COMPENSABLE
        public void SetNonCompensable(bool nonCompensable)
        {
            bool isSelected = this.NonCompensable;
            if((nonCompensable && !isSelected)||(!nonCompensable && isSelected))
                this.WaitForElementToBePresent(NON_COMPENSABLE_LABEL_LOCATOR).Click();
        }

        public bool NonCompensable
        {
            get
            {
                return this.WaitForElementToBePresent(NON_COMPENSABLE_INPUT_LOCATOR).Selected;
            }
            set
            {
                this.SetNonCompensable(value);
        }
        }

        public void ClickOnRemoveIconByRowPosition(int rowPosition)
        {
            this.WaitForElementToBeClickeable(By.XPath(String.Format(UTC_SPLIT_REMOVE_ICON_BY_ROW_POSITION_LOCATOR_TEMPLATE, rowPosition))).Click();
        }

        public string NonCompensableLabel
        {
            get
            {
                return this.WaitForElementToBeVisible(NON_COMPENSABLE_LABEL_LOCATOR).Text;
            }
        }

        //ASSET LINK

        public string AssetLinkLabel
        {
            get
            {
                return this.WaitForElementToBeVisible(ASSET_LINK_LABEL_LOCATOR).Text;
            }
        }

        //AMOUNT
        //TODO convert to Amount property set
        public void SetAmount(string amount)
        {
            this.ClearAndType(this.WaitForElementToBeVisible(AMOUNT_INPUT_LOCATOR), amount);            
        }


        public string Amount
        {
            get
            {
                this.Pause(1);
                return this.WaitForElementToBeVisible(AMOUNT_INPUT_LOCATOR).GetAttribute("value");
            }
            set
            {
                this.SetAmount(value);
        }
        }

        public string AmountLabel
        {
            get
            {
                string[] stringSeparators = new string[] { "\r\n" };
                return this.WaitForElementToBeVisible(AMOUNT_LABEL_LOCATOR).Text.Split(stringSeparators, StringSplitOptions.None)[0].TrimEnd(' ');
            }
        }

        public string AmountPlaceholder
        {
            get
            {
                return this.WaitForElementToBeVisible(AMOUNT_INPUT_LOCATOR).GetAttribute("placeholder");

            }
        }

        //Validation Messages - TODO convert to properties for each validated field

        private By TrxValidationMessageLocator
        {
            get
            {
                By validationMsgLocator;
                //if (isCheck)
                    validationMsgLocator = TRX_DATE_VALIDATION_MSG_LOCATOR;
                //else
                //    validationMsgLocator = TRX_DATE_DEPOSIT_VALIDATION_MSG_LOCATOR;
                return validationMsgLocator;
            }
        }

        private By ClearedValidationMessageLocator
        {
            get
            {
                By validationMsgLocator;
                ////if (isCheck)
                    validationMsgLocator = CLEARED_DATE_VALIDATION_MSG_LOCATOR;
                //else
                //    validationMsgLocator = CLEARED_DATE_DEPOSIT_VALIDATION_MSG_LOCATOR;
                return validationMsgLocator;
            }
        }        

       

        public string GetPayToValidationMessage()
        {
            if(this.isCheck)
                return this.WaitForElementToBeVisible(RECEIVED_PAY_TO_SELECT2_VALIDATION_MSG_LOCATOR).Text;
            else
                return this.WaitForElementToBeVisible(RECEIVED_PAY_TO_VALIDATION_MSG_LOCATOR).Text;
        }

        public string GetTrxDateValidationMessage()
        {
            return this.WaitForElementToBeVisible(this.TrxValidationMessageLocator).Text;            
        }

        public string GetClearedDateValidationMessage()
        {
            return this.WaitForElementToBeVisible(this.ClearedValidationMessageLocator).Text;
        }

        public string GetAmountValidationMessage()
        {
            try
            {
                return this.WaitForElementToBeVisible(AMOUNT_VALIDATION_MSG_LOCATOR).Text;            
            }
            catch (Exception)
            {
                return null;
            }
        }

        public bool HasPayToValidationMessageDissapeared()
        {
            try
            {
                if(this.isCheck)
                    this.WaitForElementToDissapear(RECEIVED_PAY_TO_SELECT2_VALIDATION_MSG_LOCATOR);
                else
                    this.WaitForElementToDissapear(RECEIVED_PAY_TO_VALIDATION_MSG_LOCATOR);

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool HasTrxDateValidationMessageDissapeared()
        {
            try
            {
                this.WaitForElementToDissapear(this.TrxValidationMessageLocator);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool HasClearedDateValidationMessageDissapeared()
        {
            try
            {
                this.WaitForElementToDissapear(this.ClearedValidationMessageLocator);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool HasAmountValidationMessageDissapeared()
        {            
            try
            {
                this.WaitForElementToDissapear(AMOUNT_VALIDATION_MSG_LOCATOR);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }


        //Form Actions
        public void Cancel()
        {
            //Scroll section into view            
            this.ScrollSavingButtonsSectionIntoView();

            //Click on button 
            try
            {
                this.WaitForElementToBeVisible(CANCEL_BUTTON_LOCATOR).Click();
            }
            catch (Exception)
            {
                try { 
                this.JSMoveToViewElement(this.WaitForElementToBeVisible(CANCEL_BUTTON_LOCATOR));
                this.WaitForElementToBeVisible(CANCEL_BUTTON_LOCATOR).Click();
                }
                catch (Exception)
                {
                    this.clickNotVisualizedElement(this.WaitForElementToBeVisible(CANCEL_BUTTON_LOCATOR));
                }
            }
            this.Pause(2);

            //Wait for content to load
            this.WaitForBlockOverlayToDissapear();
        }

        public void Save()
        {
            //Scroll section into view 
            this.ScrollSavingButtonsSectionIntoView();

            //Click on button
            try
            {
                Pause(1);
                this.WaitForElementToBeClickeable(SAVE_BUTTON_LOCATOR).Click();
            }
            catch (Exception)
            {
                try
                {
                    this.JSMoveToViewElement(this.WaitForElementToBeVisible(SAVE_BUTTON_LOCATOR));
                    this.WaitForElementToBeClickeable(SAVE_BUTTON_LOCATOR).Click();
                }
                catch (Exception)
                {
                    this.clickNotVisualizedElement(this.WaitForElementToBeVisible(SAVE_BUTTON_LOCATOR));
                }

            }
            this.Pause(2);

            //Wait for content to load
            this.WaitForBlockOverlayToDissapear();            
        }

        private void ScrollSavingButtonsSectionIntoView()
        {
            //Scroll button into view 
            try
            {
                this.MoveToViewElement(this.WaitForElementToBePresent(CHECK_CODE_LABEL_LOCATOR));
            } catch(Exception){
                this.MoveToViewElement(this.WaitForElementToBePresent(DEPOSIT_CODE_LABEL_LOCATOR));                
            }

            ScrollDownToAvoidStickyHeadersOnClick();       
        }

        public void FocusAndHitEnterOnField(string field)
        {
            switch (field)
            {
                case "Pay to the Order Of":
                    this.WaitForElementToBeVisible(RECEIVED_PAY_TO_SELECT2_VALUE_LOCATOR).Click();
                    this.WaitForElementToBeVisible(RECEIVED_PAY_TO_SELECT2_INPUT_LOCATOR).SendKeys(Keys.Enter);
                    break;

                case "Received From":
                    this.WaitForElementToBeVisible(RECEIVED_PAY_TO_INPUT_LOCATOR).SendKeys(Keys.Enter);
                    break;

                case "Serial Number":
                    this.WaitForElementToBeVisible(SERIAL_NUMBER_INPUT_LOCATOR).SendKeys(Keys.Enter);
                    break;

                case "Description":
                    this.WaitForElementToBeVisible(DESCRIPTION_INPUT_LOCATOR).SendKeys(Keys.Enter);
                    break;

                case "Transaction":
                    {
                        this.WaitForElementToBeVisible(this.TrxDateInputLocator).SendKeys(Keys.Enter);
                        break;
                    }
                case "Cleared":
                    {
                        this.WaitForElementToBeVisible(this.ClearedInputLocator).SendKeys(Keys.Enter);
                        break;
                    }
                case "Code":
                    this.WaitForElementToBeVisible(this.GetCodeLocator()).Click();
                    this.WaitForElementToBeVisible(CODE_INPUT_LOCATOR).SendKeys(Keys.Enter);
                    break;

                case "Amount":
                    this.WaitForElementToBeVisible(AMOUNT_INPUT_LOCATOR).SendKeys(Keys.Enter);
                    break;

                default:
                    throw new NotImplementedException();
            }

            //Enter Key is also supposed to save, so wait for overlay to dissapear  
            this.Pause(2);
            this.WaitForBlockOverlayToDissapear();
        }

        

        public bool IsFocusOnNameField()
        {
            IWebElement element;
            if(this.isCheck)
                element = this.WaitForElementToBeVisible(RECEIVED_PAY_TO_SELECT2_INPUT_LOCATOR);
            else
                element =this.WaitForElementToBeVisible(RECEIVED_PAY_TO_INPUT_LOCATOR);
            return element.Equals(driver.SwitchTo().ActiveElement());            
        }
               
        public bool IsDatePickerPresentOnTransactionInput()
        {
           this.WaitForElementToBeVisible(this.TrxDateInputLocator).Click();
            Pause(2);
            try
            {
               this.WaitForElementToBeVisible(By.XPath("//div[contains(@class,'datepicker')]"));
               return true;

            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool IsDatePickerPresentOnClearedInput()
        {
            IWebElement trxInput = this.WaitForElementToBeVisible(this.ClearedInputLocator);
            try
            {
                this.WaitForElementToBeVisible(By.CssSelector("div.datepicker"));
                return true;

            }
            catch (Exception)
            {
                return false;
            }
        }

        //UTC SPLIT
        public bool IsSumOfAllocationFieldInvisible()
        {
            try
            {
                this.WaitForElementToDissapear(SUM_OF_ALLOCATION_VALUE_LOCATOR);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        

        public void ClickOnSerialNumber()
        {
            this.WaitForElementToBeVisible(SERIAL_NUMBER_INPUT_LOCATOR).Click();
        }
        
        //Focus
        public bool IsFocusOnAmountField()
        {
            return this.IsFocusOnElement(this.WaitForElementToBeVisible(AMOUNT_INPUT_LOCATOR));
        }

        public bool IsFocusOnDescriptionField()
        {
            return this.IsFocusOnElement(this.WaitForElementToBeVisible(DESCRIPTION_INPUT_LOCATOR));
        }

        public bool IsFocusOnNonCompensableField()
        {
            return this.IsFocusOnElement(this.WaitForElementToBeVisible(NON_COMPENSABLE_INPUT_LOCATOR));           
        }

        public bool IsFocusOnTransactionField()
        {
            //if(isCheck)
                return this.IsFocusOnElement(this.WaitForElementToBeVisible(TRX_DATE_INPUT_LOCATOR));
            //else
            //    return this.IsFocusOnElement(this.WaitForElementToBeVisible(TRX_DATE_DEPOSIT_INPUT_LOCATOR));
        }

        public bool IsFocusOnClearedField()
        {
            //if (isCheck)
                return this.IsFocusOnElement(this.WaitForElementToBeVisible(CLEARED_DATE_INPUT_LOCATOR));
            //else
            //    return this.IsFocusOnElement(this.WaitForElementToBeVisible(CLEARED_DATE_DEPOSIT_INPUT_LOCATOR));
        }

        public bool IsFocusOnCodeField()
        {
            return this.IsFocusOnElement(this.WaitForElementToBeVisible(CODE_INPUT_LOCATOR));
        }

        public bool IsFocusOnAddUTCSplitField()
        {
            return this.IsFocusOnElement(this.WaitForElementToBeVisible(UTC_SPLIT_LINK_LOCATOR));
        }

        public bool IsFocusOnSerialNumberField()
        {
            return this.IsFocusOnElement(this.WaitForElementToBeVisible(SERIAL_NUMBER_INPUT_LOCATOR));
        }

        public bool IsFocusOnSaveButton()
        {
            return this.IsFocusOnElement(this.WaitForElementToBeVisible(SAVE_BUTTON_LOCATOR));
        }

        public bool IsFocusOnSaveAndAddAnotherButton()
        {
            return this.IsFocusOnElement(this.WaitForElementToBeVisible(SAVE_AND_ADD_ANOTHER_BUTTON_LOCATOR));
        }

        public bool IsFocusOnCancelButton()
        {
            return this.IsFocusOnElement(this.WaitForElementToBeVisible(CANCEL_BUTTON_LOCATOR));
        }
       
        public void DeleteFirstFourDigitsFromAmount(string key)
        {
            IWebElement fieldWe = this.WaitForElementToBeVisible(AMOUNT_INPUT_LOCATOR);
            //select
            this.SelectFirstNDigits(4, fieldWe);

            //delete
            if (key == "delete")
                fieldWe.SendKeys(Keys.Delete);
            else if (key == "backspace")
                fieldWe.SendKeys(Keys.Backspace);

            //loose focus
            fieldWe.SendKeys(Keys.Tab);
        }

        public void DeleteAllDigitsFromAmount(string key)
        {
            IWebElement fieldWe = this.WaitForElementToBeVisible(AMOUNT_INPUT_LOCATOR);
            //select
            this.SelectAllDigits(fieldWe);

            //delete
            if (key == "delete")
                fieldWe.SendKeys(Keys.Delete);
            else if (key == "backspace")
                fieldWe.SendKeys(Keys.Backspace);

            //loose focus
            fieldWe.SendKeys(Keys.Tab);
        }

        public string SumOfAllocation
        {
            get
            {
                this.Pause(1);
                return this.WaitForElementToBeVisible(SUM_OF_ALLOCATION_VALUE_LOCATOR).Text;
            }
        }

        public string SumOfAllocationBoxColor {
            get {
                this.Pause(1);
                return this.GetColorFromColorCode(this.WaitForElementToBeVisible(SUM_OF_ALLOCATION_VALUE_LOCATOR).GetCssValue("background-color"));
            }
        }

        public string CodeAmountLabel {
            get
            {
                return this.WaitForElementToBeVisible(UTC_SPLIT_CODE_AMOUNT_LABEL_LOCATOR).Text;
            }
        }

        public string UTCSplitCodeLabel
        {
            get
            {
                return this.WaitForElementToBeVisible(UTC_SPLIT_CODE_LABEL_LOCATOR).Text;
            }
        }

        public string UTCSplitNonCompensableLabel {
            get {
                return this.WaitForElementToBeVisible(UTC_SPLIT_NON_COMPENSABLE_LABEL_LOCATOR).Text;
            }
        }

        public string UTCSplitValidationMessage {
            get
            {
                try
                {
                    return this.WaitForElementToBeVisible(UTC_SPLIT_VALIDATION_MESSAGE_LOCATOR).Text;
                }
                catch (Exception)
                {
                    return "";
                }
            }    
            
        }
       
        public int GetUTCSplitsCount()
        {
            return this.WaitForElementsToBeVisible(UTC_SPLIT_TABLE_ROW_LOCATOR).Count - 1;
        }

        public string GetUTCSplitNameBySplitPosition(int rowPosition)
        {
            if (isNew)
            {
                return this.WaitForElementToBeVisible(By.XPath(String.Format(UTC_SPLIT_NAME_BY_POSITION_LOCATOR_TEMPLATE, rowPosition - 1))).GetAttribute("value");
            }
            else
            {
                return this.WaitForElementToBeVisible(By.XPath(String.Format(UTC_SPLIT_NAME_BY_POSITION_LOCATOR_TEMPLATE, rowPosition))).GetAttribute("value");
            }
        }

        public void SetUTCSplitNameBySplitPosition(int rowPosition, string name)
        {
            this.ClearAndType(this.WaitForElementToBeVisible(By.XPath(String.Format(UTC_SPLIT_NAME_BY_POSITION_LOCATOR_TEMPLATE, rowPosition - 1))),name);           
        }

        public string GetUTCSplitAllocationDescriptionBySplitPosition(int rowPosition)
        {
            if (isNew)
            {
            return this.WaitForElementToBeVisible(By.XPath(String.Format(UTC_SPLIT_ALLOCATION_DESCRIPTION_BY_POSITION_LOCATOR_TEMPLATE, rowPosition - 1))).GetAttribute("value");
            }
            else
            {
            return this.WaitForElementToBeVisible(By.XPath(String.Format(UTC_SPLIT_ALLOCATION_DESCRIPTION_BY_POSITION_LOCATOR_TEMPLATE, rowPosition))).GetAttribute("value");
            }
        }

        public void SetUTCSplitAllocationDescriptionBySplitPosition(int rowPosition, string name)
        {
            this.ClearAndType(this.WaitForElementToBeVisible(By.XPath(String.Format(UTC_SPLIT_ALLOCATION_DESCRIPTION_BY_POSITION_LOCATOR_TEMPLATE, rowPosition - 1))), name);
        }

        public string GetUTCSplitCodeBySplitPosition(int rowPosition)
        {
            if (isNew)
            {
                return this.WaitForElementToBeVisible(By.XPath(String.Format(UTC_SPLIT_CODE_CONTAINER_BY_POSITION_LOCATOR_TEMPLATE, rowPosition-1))).Text;
            }
            else
            {
                return this.WaitForElementToBeVisible(By.XPath(String.Format(UTC_SPLIT_CODE_CONTAINER_BY_POSITION_LOCATOR_TEMPLATE, rowPosition))).Text;
            }
        }
        public void SetUTCSplitCodeBySplitPosition(int rowPosition, string code)
        {
            IWebElement utcSplitInput = this.WaitForElementToBeVisible(By.XPath(String.Format(UTC_SPLIT_CODE_CONTAINER_BY_POSITION_LOCATOR_TEMPLATE, rowPosition - 1)));
            try
            {
                this.MoveToViewElement(this.WaitForElementToBeVisible(UTC_SPLIT_TITLE_LOCATOR));                
                utcSplitInput.Click();
            }
            catch (Exception)
            {
                ScrollWindowBy(0, -200);
                utcSplitInput.Click();
            }
            
            this.ClearAndType(driver.SwitchTo().ActiveElement(), code);
            this.Pause(2);
            IWebElement codeInput = this.WaitForElementToBeVisible(CODE_INPUT_LOCATOR);
            codeInput.SendKeys(Keys.Enter);
            this.Pause(1);
        }

        public bool GetUTCSplitNonCompensableBySplitPosition(int rowPosition)
        {
            if (isNew)
            {
                return this.WaitForElementToBePresent(By.XPath(String.Format(UTC_SPLIT_NON_COMPENSABLE_BY_POSITION_LOCATOR_TEMPLATE, rowPosition - 1))).Selected;
            }
            else
            {
                return this.WaitForElementToBePresent(By.XPath(String.Format(UTC_SPLIT_NON_COMPENSABLE_BY_POSITION_LOCATOR_TEMPLATE, rowPosition))).Selected;
            }
        }

        public void SetNonCompensableBySplitPosition(int rowPosition, bool nonCompensable)
        {
            IWebElement nonCompensableWE = this.WaitForElementToBePresent(By.XPath(String.Format(UTC_SPLIT_NON_COMPENSABLE_BY_POSITION_LOCATOR_TEMPLATE, rowPosition - 1)));
            if ((nonCompensable && !nonCompensableWE.Selected) || (!nonCompensable && nonCompensableWE.Selected))
            {
                this.WaitForElementToBeVisible(By.XPath(String.Format(UTC_SPLIT_NON_COMPENSABLE_LABEL_BY_POSITION_LOCATOR_TEMPLATE, rowPosition-1))).Click();
            }
        }       

        public string GetUTCSplitAmountBySplitPosition(int rowPosition)
        {
            if (isNew)
            {
                return this.WaitForElementToBeVisible(By.XPath(String.Format(UTC_SPLIT_AMOUNT_BY_POSITION_LOCATOR_TEMPLATE, rowPosition - 1))).GetAttribute("value");
            }
            else
            {
                return this.WaitForElementToBeVisible(By.XPath(String.Format(UTC_SPLIT_AMOUNT_BY_POSITION_LOCATOR_TEMPLATE, rowPosition))).GetAttribute("value");
            }
        }

        public void SetAmountBySplitPosition(int rowPosition, string amount)
        {
            this.ClearAndType(this.WaitForElementToBeVisible(By.XPath(String.Format(UTC_SPLIT_AMOUNT_BY_POSITION_LOCATOR_TEMPLATE, rowPosition - 1))),amount);
        }

        public void RemoveUTCSplitRowByPosition(int rowPosition)
        {
            this.WaitForElementToBeVisible(By.XPath(String.Format(UTC_SPLIT_REMOVE_ICON_BY_ROW_POSITION_LOCATOR_TEMPLATE, rowPosition-1))).Click();
        }

        public bool IsSaveButtonEnabled()
        {
            return this.WaitForElementToBeVisible(SAVE_BUTTON_LOCATOR).Enabled;
        }

        public bool IsSaveAndAddAnotherButtonEnabled()
        {
            return this.WaitForElementToBeVisible(SAVE_AND_ADD_ANOTHER_BUTTON_LOCATOR).Enabled;
        }


        public ClaimLinksComponent TransactionLinks
        {
            get
            {
                if (this._ClaimLinks == null)
                    this._ClaimLinks = new ClaimLinksComponent(driver, this.isCheck, this.isNew);

                return _ClaimLinks;
            }
        }

        public string SumOfClosingCostsLabel
        {
            get
            {
                string[] stringSeparators = new string[] { "\r\n" };
                return this.WaitForElementToBeVisible(SUM_OF_CLOSING_COSTS_LABEL_LOCATOR).Text.Split(stringSeparators, StringSplitOptions.None)[0].TrimEnd(' ');
            }

        }

        public string SumOfClosingCosts
        {
            get
            {
                this.Pause(1);
                return this.WaitForElementToBeVisible(SUM_OF_CLOSING_COSTS_VALUE_LOCATOR).Text;
            }

        }

        public string UTCSplitTitle {
            get {
                return this.WaitForElementToBeVisible(UTC_SPLIT_TITLE_LOCATOR).Text;
            }
        }

        public void SetGrossDeposit(string grossDeposit)
        {
            IWebElement grossDepositWE = this.WaitForElementToBeVisible(GROSS_DEPOSIT_INPUT_LOCATOR);
            this.ClearAndType(grossDepositWE, grossDeposit);            
        }


        public string TransferOutFrom {
            get {
                return this.WaitForElementToBeVisible(FROM_BANK_ACCOUNT_LOCATOR).Text;
            }
        }
        public string TransferOutFromLabel
        {
            get
            {
                string[] stringSeparators = new string[] { "\r\n" };
                return this.WaitForElementToBeVisible(FROM_BANK_ACCOUNT_LABEL_LOCATOR).Text.Split(stringSeparators, StringSplitOptions.None)[0].TrimEnd(' ');
            }
        }

        public string TransferOutTo {
            get {
                string[] stringSeparators = new string[] { "\r\n            \r\n" };
               // "TO BANK AND ACCOUNT \r\n            \r\n                Please open an account or set existing accounts to open to complete transfer.\r\n            \r\n         Required field, please select bank and account to receive transferred funds."
                string ret = this.WaitForElementToBeVisible(TO_BANK_ACCOUNT_LOCATOR).Text.Split(stringSeparators, StringSplitOptions.None)[1];
                return ret.TrimStart(' ').TrimEnd(' ');
            }
        }

        public string TransferOutToLabel
        {
            get
            {
                return this.WaitForElementToBeVisible(TO_BANK_ACCOUNT_LOCATOR).GetAttribute("label");
            }
        }

        public string GetBottomDepositValidationMessage()
        {
            return this.WaitForElementToBeVisible(DEPOSIT_BOTTOM_VALIDATION_MESSAGES_LOCATOR).Text;
        }

        public List<ClaimLinkData> GetUTCSplitsData()
        {
            List<ClaimLinkData> utcData = new List<ClaimLinkData>();
            IReadOnlyCollection<IWebElement> UTCSplits = null;
            try {
                //try getting the UTC splits
                UTCSplits = this.WaitForElementsToBeVisible(UTC_SPLIT_TABLE_ROW_LOCATOR);
            }
            catch (Exception) {
                //no UTC splits present
                //set utc split data empty but fill check normal code, since it could have something
                ClaimLinkData linkData = new ClaimLinkData();
                linkData.Name = this.GetTransactionName().Replace(" | Add New Participant Record","");
                linkData.Code = this.Code.Split(' ')[0];
                linkData.Description = "";
                linkData.NonCompensable = this.NonCompensable;
                linkData.Amount = this.Amount;
                utcData.Add(linkData);
            }

            if (UTCSplits != null)
            {
                for (int rowPosition = 1; rowPosition < UTCSplits.Count; rowPosition++)
                {               
                    ClaimLinkData splitData = new ClaimLinkData();
                    splitData.Name = this.GetUTCSplitNameBySplitPosition(rowPosition);
                    splitData.Code = this.GetUTCSplitCodeBySplitPosition(rowPosition);
                    splitData.Description = this.GetUTCSplitAllocationDescriptionBySplitPosition(rowPosition);
                    splitData.NonCompensable = this.GetUTCSplitNonCompensableBySplitPosition(rowPosition);
                    splitData.Amount = this.GetUTCSplitAmountBySplitPosition(rowPosition);
                    utcData.Add(splitData);
                }
            }

            return utcData;
        }
    }
}