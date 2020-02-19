using Epiq.ETS.TCMS.Anywhere.Testing.E2ETest.TestFramework.Pages.Cases.Detail;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;

namespace Epiq.ETS.TCMS.Anywhere.Testing.E2ETest.Test_Framework.Pages.Cases.Detail.Distribution
{
    public class DistributionForm : DistributionTab
    {
        //Form title locator
        private By NEW_DISTRIBUTION_FORM_TITLE_LOCATOR = By.Id("distributionTitle");

        //Action buttons locators
        private By NEXT_BUTTON_LOCATOR = By.Id("saveNewDistribution");
        private By CANCEL_BUTTON_LOCATOR = By.Id("cancelNewDistribution");

        //Fields Step 1 locators
        private By PROPOSED_AMOUNT_TO_DISTRIBUTE_BOX_LOCATOR = By.XPath("//my-moneybox[@id='amountToDistributeTextBox']");
        private By PROPOSED_AMOUNT_TO_DISTRIBUTE_INPUT_LOCATOR = By.XPath("//input[@id='amountToDistributeTextBox']");        
        private By PROPOSED_AMOUNT_VALIDATION_MESSAGE_LOCATOR = By.XPath("//my-moneybox[@id='amountToDistributeTextBox']//small[@class='aurelia-validation-message error']");

        private By DISTRIBUTION_NAME_LABEL_LOCATOR = By.XPath("//my-textbox[@id='proposedDistribution']/label");
        private By DISTRIBUTION_NAME_INPUT_LOCATOR = By.XPath("//input[@id='proposedDistribution']");
        private By DISTRIBUTION_NAME_VALIDATION_MESSAGE_LOCATOR = By.XPath("//my-textbox[@id='proposedDistribution']//small[@class='aurelia-validation-message error']");

        private By TYPE_LABEL_LOCATOR = By.Id("distributionType-Label");
        private By BREAKDOWN_TYPE_OPTION_LOCATOR = By.XPath("//div[@id='rb-container-Breakdown']/div");
        private By SELECTED_TYPE_DESCRIPTION_LOCATOR = By.Id("distributionTypeDescription");
        
        //TODO: IMPORTANT! CHANGE ALL THIS FOR LOCATORS BY ID
        private By BANK_BALANCE_LABEL_LOCATOR = By.XPath("//section[@id='newDistribution']/article/div[2]/div[4]/div/div/span");
        private By BANK_BALANCE_VALUE_LOCATOR = By.XPath("//section[@id='newDistribution']/article/div[2]/div[4]/div/div/div");

        private By AMOUNT_ON_RESERVE_LABEL_LOCATOR = By.XPath("//section[@id='newDistribution']/article/div[2]/div[4]/div/div[2]/span");
        private By AMOUNT_ON_RESERVE_VALUE_LOCATOR = By.XPath("//section[@id='newDistribution']/article/div[2]/div[4]/div/div[2]/div");

        private By AMOUNT_AVAILABLE_LABEL_LOCATOR = By.XPath("//section[@id='newDistribution']/article/div[2]/div[4]/div/div[3]/span");
        private By AMOUNT_AVAILABLE_VALUE_LOCATOR = By.XPath("//section[@id='newDistribution']/article/div[2]/div[4]/div/div[3]/div");
        private By AMOUNT_TO_DISTRIBUTE_LABEL_LOCATOR = By.XPath("//section[@id='newDistribution']/article/div[2]/div[4]/div/div[5]/span");        

        private By REMAINING_BALANCE_LABEL_LOCATOR = By.XPath("//section[@id='newDistribution']/article/div[2]/div[4]/div/div[6]/span");
        private By REMAINING_BALANCE_VALUE_LOCATOR = By.XPath("//section[@id='newDistribution']/article/div[2]/div[4]/div/div[6]/div");

        //Step 2 locators
        //TODO: IMPORTANT! CHANGE ALL THIS FOR LOCATORS BY ID
        private By NEW_DISTRIBUTION_STEP2_MESSAGE_LOCATOR = By.XPath("//div[contains(@class,'subDistributionHeader')]/div/p");

        private By PERCENTAGE_TO_DISTRIBUTE_LABEL_LOCATOR = By.XPath("//section[@id='newDistribution']/article/div[2]/div[7]/div[2]/span");
        private By PERCENTAGE_TO_DISTRIBUTE_INPUT_LOCATOR = By.XPath("//input[@id='percentageToDistribute']");
        private By PERCENTAGE_TO_DISTRIBUTE_VALIDATION_MESSAGE_LOCATOR = By.XPath("//my-numericbox[@id='percentageToDistribute']//small[@class='aurelia-validation-message error']");

        private By CALCULATED_AMOUNT_TO_DISTRIBUTE_LABEL_LOCATOR = By.XPath("//section[@id='newDistribution']/article/div[2]/div[7]/div[3]/span");
        private By CALCULATED_AMOUNT_TO_DISTRIBUTE_INPUT_LOCATOR = By.XPath("//input[@id='amountToDistribute']");
        private By CALCULATED_AMOUNT_VALIDATION_MESSAGE_LOCATOR = By.XPath("//my-moneybox[@id='amountToDistribute']//small[@class='aurelia-validation-message error']");

        //STEP 3 LOCATORS
        //Payment method
        private By METHOD_TITLE_LOCATOR = By.Id("distributionMethod-Label");
        private By METHOD_OPTION_NAME_LOCATOR = By.CssSelector("#radio-buton-text-distributionMethod > span.radio-button-name");
        private By SELECTED_PAYMENT_METHOD_LOCATOR = By.XPath("//div[contains(@id,'rb-container-')]/div[contains(@class,'')]");
        private By PRO_RATA_METHOD_RADIO_BUTTON_LOCATOR = By.XPath("//div[@id='rb-container-ProRata']/div");
        private By PAY_EQUALLY_METHOD_RADIO_BUTTON_LOCATOR = By.XPath("//div[@id='rb-container-PayEachClaimEqually']/div");

        //Class
        private By SELECT_CLASSES_AND_CATEGORIES_MESSAGE_LOCATOR = By.CssSelector("#selectClassAndCategory-Message > div > p");
        private By CLAIM_CLASS_HEADER_LOCATOR = By.Id("claimClassLabel");
        private By CLAIM_CATEGORY_HEADER_LOCATOR = By.Id("claimCategoryLabel");

        private By CLAIM_CLASS_SELECT_ALL_CHECKBOX_LOCATOR = By.XPath("//label[@id='claimClassAll']/../input");
        private By CLAIM_CLASS_SELECT_ALL_LABEL_LOCATOR = By.XPath("//label[@id='claimClassAll']");

        private By CLAIM_CLASS_CHECKBOX_GENERIC_LOCATOR = By.XPath("//div[@class='checkboxList']//label[contains(@id,'claimClass')]/../input");
        private By CLAIM_CLASS_LABEL_GENERIC_LOCATOR = By.XPath("//div[@class='checkboxList']//label[contains(@id,'claimClass')]");

        private string CLAIM_CLASS_CHECKBOX_BY_NAME_TEMPLATE_LOCATOR = "//div[@id='claimClass']/div[@class='checkboxList']/div/label[contains(text(),'{0}')]/../input";
        private string CLAIM_CLASS_LABEL_BY_NAME_TEMPLATE_LOCATOR = "//div[@id='claimClass']/div[@class='checkboxList']/div/label[contains(text(),'{0}')]";
                
        private By CLAIM_CLASS_BOX_LOCATOR = By.XPath("//div[@id='claimClass']/div[@class='checkboxList']/div");
        private string CLAIM_CLASS_CHECKBOX_BY_CLASSID_LOCATOR = "//div[@id='claimClass']/div[@class='checkboxList']/div/label[@id='claimClass{0}']/../input";
                                               


        //category
        private By CLAIM_CATEGORY_SELECT_ALL_LABEL_LOCATOR = By.XPath("//label[@id='claimCategoryAll']");
        private By CLAIM_CATEGORY_SELECT_ALL_CHECKBOX_LOCATOR = By.XPath("//label[@id='claimCategoryAll']/../input");

        private By CLAIM_CATEGORY_CHECKBOX_GENERIC_LOCATOR = By.XPath("//div[@id='claimCategory']/div[contains(@class,'checkboxList')]/div/input");
        private By CLAIM_CATEGORY_LABEL_GENERIC_LOCATOR = By.XPath("//div[@id='claimCategory']/div[contains(@class,'checkboxList')]/div/label");

        private string CLAIM_CATEGORY_CHECKBOX_BY_NAME_TEMPLATE_LOCATOR = "//div[@id='claimCategory']/div[contains(@class,'checkboxList')]/div/label[contains(text(),'{0}')]/../input";
        private string CLAIM_CATEGORY_LABEL_BY_NAME_TEMPLATE_LOCATOR = "//div[@id='claimCategory']/div[contains(@class,'checkboxList')]/div/label[contains(text(),'{0}')]";
        
        private By CLAIM_CATEGORY_BOX_LOCATOR = By.XPath("//div[@id='claimCategory']/div[contains(@class,'checkboxList')]/div");
        private string CLAIM_CATEGORY_CHECKBOX_BY_CATEGORYID_LOCATOR = "//div[@id='claimCategory']/div[contains(@class,'checkboxList')]/div/label[@id='claimCategory{0}']/../input";

        //Claims
        private By CLAIM_ITEM_NAME_GENERIC_LOCATOR = By.XPath("//p[contains(@id,'claimNameForClaim')]");
        private string CLAIM_LABEL_BY_NAME_TEMPLATE_LOCATOR = "//div[contains(@class,'distributionClaimSummaryContainer')]//p[contains(@id,'claimNameForClaim') and contains(text(),'{0}')]";
        private string CLAIM_CHECKBOX_BY_ID_TEMPLATE_LOCATOR = "{0}Checkbox";
        private string CLAIM_LIST_CLASS_TITLE_FOR_CLASSNAME_BY_ID_LOCATOR_TEMPLATE = "claimClassTitle{0}";
        private string CLAIM_LIST_COUNT_OF_CLASS_FOR_CLASSNAME_BY_ID_LOCATOR_TEMPLATE = "claimClassCountForClass{0}";
        private string VALID_TO_PAY_TITLE_FOR_CLASS_BY_ID_TEMPLATE_LOCATOR = "validToPaidTitleForClass{0}";
        private string OBJECTION_PENDING_TITLE_FOR_CLASS_BY_ID_TEMPLATE_LOCATOR = "objectionPendingTitleForClass{0}";
                
        private string CLAIM_SUMMARY_ITEM_CONTAINER_UNDER_STATUS_AND_CLASS_LOCATOR_TEMPLATE = "//p[contains(@id,'{0}TitleForClass{1}')]/..//div[contains(@class,'distributionClaimSummaryContainer')]";
        private By CLAIM_SUMMARY_ITEM_CHECKBOX_RELATIVE_LOCATOR = By.XPath(".//input[contains(@id,'Checkbox')]");
        private string CLAIM_NAME_BY_ID_LOCATOR_TEMPLATE = "claimNameForClaim{0}";
        private string CLAIM_CATEGORY_BY_ID_LOCATOR_TEMPLATE = "claimCategoryForClaim{0}";
        private string CLAIM_BALANCE_BY_ID_LOCATOR_TEMPLATE = "claimBalanceForClaim{0}";
        private string CLAIM_NUMBER_BY_ID_LOCATOR_TEMPLATE = "//span[@id='claimBalanceForClaim{0}']/../span[@class='distributionClaimSummaryText']";


        //Confirm Selection
        private By CONFIRM_SELECTION_MESSAGE_LOCATOR = By.Id("claimSectionsTitle");
        private By CONFIRM_SELECTION_DESCRIPTION_LOCATOR = By.Id("claimSectionsDescription");
       

        //Another Selection locators
        private By ANOTHER_SELECTION_MESSAGE_LOCATOR = By.Id("remainingAmountMessageText");
        private By GROUPING_SECTION_TITLE_LOCATOR = By.XPath("//section[@id='newDistribution']//compose/h4");
        private By SAVE_BUTTON_LOCATOR = By.Id("saveDistributedDistribution");

        private By DISTRIBUTION_GROUP_LOCATOR = By.XPath("//div[contains(@id,'distributionGroup')]");
        private string DISTR_GROUP_INDEX_LOCATOR_TEMPLATE = "distributionGroupIndex{0}";
        private string DISTR_GROUP_DISTRIBUTING_LABEL_LOCATOR_TEMPLATE = "groupingDistributingLabel{0}";
        private string DISTR_GROUP_PERCENTAGE_LOCATOR_TEMPLATE = "groupingDistributingPercentage{0}";
        private string DISTR_GROUP_AMOUNT_LOCATOR_TEMPLATE = "groupingDistributingAmount{0}";
        private string DISTR_GROUP_METHOD_LOCATOR_TEMPLATE = "groupingDistributingMethod{0}";
        private string DISTR_GROUP_RESERVED_AMOUNT_LOCATOR_TEMPLATE = "groupingDistributingReservedAmount{0}";
        private string DISTR_GROUP_RESERVED_AMOUNT_TEXT_LOCATOR_TEMPLATE = "groupingDistributingReservedAmountText{0}";
        private string DISTR_GROUP_CLAIMS_INCLUDED_LABEL_LOCATOR_TEMPLATE = "groupingClaimsIncludedLabel{0}";
        private string DISTR_GROUP_CLAIMS_INCLUDED_VALUE_LOCATOR_TEMPLATE = "groupingClaimsIncludedValue{0}";
        private string DISTR_GROUP_CLAIMS_INCLUDED_NOTE_LOCATOR_TEMPLATE = "groupingClaimIncludedText{0}";
        private string DISTR_GROUP_CLAIMS_INCLUDED_ITEMS_LOCATOR_TEMPLATE = "//span[contains(@id,'groupingClaimsIncludedDetails{0}')]";

        public DistributionForm(IWebDriver driver): base(driver) { }

        public string ProposedAmountToDistribute {
            get {
                return this.WaitForElementToBeVisible(PROPOSED_AMOUNT_TO_DISTRIBUTE_INPUT_LOCATOR).Text;
            }
            set {
                IWebElement proposedAmnt = this.WaitForElementToBeVisible(PROPOSED_AMOUNT_TO_DISTRIBUTE_INPUT_LOCATOR);
                proposedAmnt.Click();
                this.TypeIn(proposedAmnt, value);
            }
        }

        public string DistributionName {
            get
            {
                return this.WaitForElementToBeVisible(DISTRIBUTION_NAME_INPUT_LOCATOR).Text;
            }
            set
            {
                this.TypeIn(this.WaitForElementToBeVisible(DISTRIBUTION_NAME_INPUT_LOCATOR), value);
            }
        }

        public string TypeLabel {
            get {
                return this.WaitForElementToBeVisible(TYPE_LABEL_LOCATOR).Text;
            }
        }
     
        public string SelectedTypeDescription {
            get
            {
                return this.WaitForElementToBeVisible(SELECTED_TYPE_DESCRIPTION_LOCATOR).Text;
            }
        }
        
        public bool BreakdownTypeIsSelected {
            get
            {
                return this.WaitForElementToBeVisible(BREAKDOWN_TYPE_OPTION_LOCATOR).GetAttribute("class").Contains("checked");
            }
        }

        public string BankBalanceLabel {
            get {
                return this.WaitForElementToBeVisible(BANK_BALANCE_LABEL_LOCATOR).Text;
            }
        }
        public string BankBalance {
            get
            {
                return this.WaitForElementToBeVisible(BANK_BALANCE_VALUE_LOCATOR).Text;
            }
        }
        public string AmountOnReserveLabel {
            get
            {
                return this.WaitForElementToBeVisible(AMOUNT_ON_RESERVE_LABEL_LOCATOR).Text;
            }
        }
        public string AmountOnReserve {
            get
            {
                return this.WaitForElementToBeVisible(AMOUNT_ON_RESERVE_VALUE_LOCATOR).Text;
            }
        }
        public string AmountAvailableForDistributionLabel {
            get
            {
                return this.WaitForElementToBeVisible(AMOUNT_AVAILABLE_LABEL_LOCATOR).Text;
            }
        }
        public string AmountAvailableForDistribution {
            get
            {
                return this.WaitForElementToBeVisible(AMOUNT_AVAILABLE_VALUE_LOCATOR).Text;
            }
        }
        public string ProposedAmountToDistributeLabel {
            get
            {
                return this.WaitForElementToBeVisible(AMOUNT_TO_DISTRIBUTE_LABEL_LOCATOR).Text;
            }
        }
        public string ProposedAmountToDistributePlaceholder {
            get
            {
                return this.WaitForElementToBeVisible(PROPOSED_AMOUNT_TO_DISTRIBUTE_INPUT_LOCATOR).GetAttribute("placeholder");
            }
        }
        public string RemainingBalanceLabel {
            get
            {
                return this.WaitForElementToBeVisible(REMAINING_BALANCE_LABEL_LOCATOR).Text;
            }
        }
        public string RemainingBalance {
            get
            {
                return this.WaitForElementToBeVisible(REMAINING_BALANCE_VALUE_LOCATOR).Text;
            }
        }
        public string DistributionNameLabel {
            get
            {
                return this.WaitForElementToBeVisible(DISTRIBUTION_NAME_LABEL_LOCATOR).Text;
            }
        }
        public string ProposedDistributionPlaceholder {
            get
            {
                return this.WaitForElementToBeVisible(DISTRIBUTION_NAME_INPUT_LOCATOR).GetAttribute("placeholder");
            }
        }

        public bool NextButtonIsPresent {
            get {
                try
                {
                    this.WaitForElementToBeVisible(NEXT_BUTTON_LOCATOR);
                    return true;
                }
                catch (Exception)
                {
                    return false;
                }
            }
        }

        public void ClickOnNext()
        {
            IWebElement nextButton = this.WaitForElementToBeClickeable(NEXT_BUTTON_LOCATOR);
            this.JSMoveToViewElement(nextButton);
            nextButton.Click();
            this.WaitForBlockOverlayToDissapear();
        }

        public bool CancelButtonIsPresent
        {
            get
            {
                try
                {
                    this.WaitForElementToBeVisible(CANCEL_BUTTON_LOCATOR);
                    return true;
                }
                catch (Exception)
                {
                    return false;
                }
            }
        }
                
        public void ClickOnCancel()
        {
            IWebElement cancelButton = this.WaitForElementToBeClickeable(CANCEL_BUTTON_LOCATOR);
            this.JSMoveToViewElement(cancelButton);
            cancelButton.Click();
            this.WaitForBlockOverlayToDissapear();
        }

        public string FormTitle
        {
            get {
                return this.WaitForElementToBeVisible(NEW_DISTRIBUTION_FORM_TITLE_LOCATOR).Text;
            }
        }

        public string Step2Message {
            get
            {
                return this.WaitForElementToBeVisible(NEW_DISTRIBUTION_STEP2_MESSAGE_LOCATOR).Text;
            }
        }

        public bool ProposedAmountToDistributeIsEditable {
            get
            {
                return !(this.WaitForElementToBePresent(PROPOSED_AMOUNT_TO_DISTRIBUTE_BOX_LOCATOR).GetAttribute("class").Contains("aurelia-hide"));
            }
        }

        public string ProposedAmountToDistributeNonEditableValue {
            get
            {
                return this.WaitForElementToBePresent(PROPOSED_AMOUNT_TO_DISTRIBUTE_INPUT_LOCATOR).GetAttribute("value");
            }
        }

        public string PercentageToDistributeLabel {
            get
            {
                return this.WaitForElementToBeVisible(PERCENTAGE_TO_DISTRIBUTE_LABEL_LOCATOR).Text;
            }
        }

        public string PercentageToDistributePlaceholder {
            get
            {
                return this.WaitForElementToBeVisible(PERCENTAGE_TO_DISTRIBUTE_INPUT_LOCATOR).GetAttribute("placeholder");
            }
        }

        public string PercentageToDistributeValueOnFocus
        {
            get
            {
                IWebElement percentageWE = this.WaitForElementToBeVisible(PERCENTAGE_TO_DISTRIBUTE_INPUT_LOCATOR);
                IWebElement step2Message = this.WaitForElementToBeVisible(NEW_DISTRIBUTION_STEP2_MESSAGE_LOCATOR);
                this.JSMoveToViewElement(step2Message);
                percentageWE.Click();
                return percentageWE.GetAttribute("value");
            }
        }

        public string CalculatedAmountToDistributeLabel
        {
            get
            {
                return this.WaitForElementToBeVisible(CALCULATED_AMOUNT_TO_DISTRIBUTE_LABEL_LOCATOR).Text;
            }
        }

        public string CalculatedAmountToDistributePlaceholder
        {
            get
            {
                return this.WaitForElementToBeVisible(CALCULATED_AMOUNT_TO_DISTRIBUTE_INPUT_LOCATOR).GetAttribute("placeholder");
            }
        }

        public string CalculatedAmountToDistribute
        {
            get
            {
                IWebElement amountWE = this.WaitForElementToBeVisible(CALCULATED_AMOUNT_TO_DISTRIBUTE_INPUT_LOCATOR);
                amountWE.Click();
                return amountWE.GetAttribute("value");
            }
            set
            {
                IWebElement amountWE = this.WaitForElementToBeVisible(CALCULATED_AMOUNT_TO_DISTRIBUTE_INPUT_LOCATOR);
                amountWE.Click();
                this.TypeIn(amountWE, value);
            }
        }

        public object RemainingBalanceColor {
            get
            {
               return this.GetColorFromColorCode(this.WaitForElementToBeVisible(REMAINING_BALANCE_VALUE_LOCATOR).GetCssValue("color"));
            }
        }

        public string PercentageToDistribute {
            get
            {
                return this.WaitForElementToBeVisible(PERCENTAGE_TO_DISTRIBUTE_INPUT_LOCATOR).GetAttribute("value");
            }
            set
            {
                IWebElement percentageWE = this.WaitForElementToBeVisible(PERCENTAGE_TO_DISTRIBUTE_INPUT_LOCATOR);
                percentageWE.Click();
                this.ClearAndType(percentageWE, value);
            }
        }        

        //public void PressTabKey()
        //{
        //    driver.SwitchTo().ActiveElement().SendKeys(Keys.Tab);
        //    this.WaitForBlockOverlayToDissapear();
        //}

        public void PressEnterKey()
        {
            driver.SwitchTo().ActiveElement().SendKeys(Keys.Enter);
            this.WaitForBlockOverlayToDissapear();
        }

        public string DistributionNameValidationMessage
        {
            get {
                return this.WaitForElementToBeVisible(DISTRIBUTION_NAME_VALIDATION_MESSAGE_LOCATOR).Text;
            }
        }

        public bool DistributionNameMessageDissapeared()
        {
            try
            {
                this.WaitForElementToDissapear(DISTRIBUTION_NAME_VALIDATION_MESSAGE_LOCATOR,3);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public string ProposedAmountValidationMessage {
            get
            {
                return this.WaitForElementToBeVisible(PROPOSED_AMOUNT_VALIDATION_MESSAGE_LOCATOR).Text;
            }
        }

        public bool HasProposedAmountMessageDissapeared()
        {
            try
            {
                this.WaitForElementToDissapear(PROPOSED_AMOUNT_VALIDATION_MESSAGE_LOCATOR, 3);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public string PercentageValidationMessage {
            get
            {
                return this.WaitForElementToBeVisible(PERCENTAGE_TO_DISTRIBUTE_VALIDATION_MESSAGE_LOCATOR).Text;
            }
        }

        public bool HasPercentageMessageDissapeared()
        {
            try
            {
                this.WaitForElementToDissapear(PERCENTAGE_TO_DISTRIBUTE_VALIDATION_MESSAGE_LOCATOR, 3);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public string CalculatedAmountValidationMessage {
            get
            {
                return this.WaitForElementToBeVisible(CALCULATED_AMOUNT_VALIDATION_MESSAGE_LOCATOR).Text;
            }
        }

        public bool HasCalculatedAmountMessageDissapeared()
        {
            try
            {
                this.WaitForElementToDissapear(CALCULATED_AMOUNT_VALIDATION_MESSAGE_LOCATOR, 3);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool IsSelectedMethod(string method)
        {
            switch (method)
            {
                case "Pro Rata":
                    return this.WaitForElementToBeVisible(PRO_RATA_METHOD_RADIO_BUTTON_LOCATOR).GetAttribute("class").Contains("checked");

                case "Pay Each Claim Equally":
                    return this.WaitForElementToBeVisible(PAY_EQUALLY_METHOD_RADIO_BUTTON_LOCATOR).GetAttribute("class").Contains("checked");

                default:
                    throw new NotImplementedException();
            }
        }

        public bool Step2IsVisible {
            get {
                try
                {
                    this.WaitForElementToBeVisible(NEW_DISTRIBUTION_STEP2_MESSAGE_LOCATOR, 3);
                    return true;
                }
                catch (Exception)
                {
                    return false;
                }
                
          }
        }

        
        public string MethodTitle {
            get {
                return this.WaitForElementToBeVisible(METHOD_TITLE_LOCATOR).Text;
            }
        }

        public List<string> MethodOptions {
            get {
                IReadOnlyCollection<IWebElement> methods = this.WaitForElementsToBeVisible(METHOD_OPTION_NAME_LOCATOR);
                List<string> ret = new List<string>();
                foreach (IWebElement method in methods)
                {
                    ret.Add(method.Text);
                }
                return ret;
            }

        }

        public void SelectPaymentMethod(string method)
        {
            switch (method)
            {
                case "Pro Rata":
                    this.WaitForElementToBeVisible(PRO_RATA_METHOD_RADIO_BUTTON_LOCATOR).Click();
                    break;
                case "Pay Each Claim Equally":
                    this.WaitForElementToBeVisible(PAY_EQUALLY_METHOD_RADIO_BUTTON_LOCATOR).Click();
                    break;
                default:
                    throw new NotImplementedException();
            }
        }
        public string SelectedPaymentMethod {
            get {
                return this.WaitForElementToBeVisible(SELECTED_PAYMENT_METHOD_LOCATOR).Text;
            }
        }

        public string SelectClassesAndCategoriesMessage {
            get {
                return this.WaitForElementToBeVisible(SELECT_CLASSES_AND_CATEGORIES_MESSAGE_LOCATOR).Text;
            }
        }

        public string ClaimClassHeader {
            get {
                return this.WaitForElementToBeVisible(CLAIM_CLASS_HEADER_LOCATOR).Text;
            }
        }

        public string ClaimCategoryHeader {
            get {
                return this.WaitForElementToBeVisible(CLAIM_CATEGORY_HEADER_LOCATOR).Text;
            }
        }

        public string ConfirmSelectionsMessage {
            get {
                return this.WaitForElementToBeVisible(CONFIRM_SELECTION_MESSAGE_LOCATOR).Text;
            }
        }

        public string ConfirmSelectionsDescription {
            get {
                return this.WaitForElementToBeVisible(CONFIRM_SELECTION_DESCRIPTION_LOCATOR).Text;
            }
        }

        public int ClaimClassesCount {
            get {
                try
                {
                    return this.WaitForElementsToBeVisible(CLAIM_CLASS_LABEL_GENERIC_LOCATOR).Count;
                }
                catch (Exception)
                {
                    return 0; 
                }
            }
        }               

        public int ClaimCategoriesCount
        {
            get
            {
                try
                {
                    return this.WaitForElementsToBeVisible(CLAIM_CATEGORY_LABEL_GENERIC_LOCATOR).Count;
                }
                catch (Exception)
                {
                    return 0;
                }
            }
        }

        public int ClaimsListCount {
            get {
                try
                {
                    return this.WaitForElementsToBeVisible(CLAIM_ITEM_NAME_GENERIC_LOCATOR).Count;
                }
                catch (Exception)
                {
                    return 0;
                }
            }
        }

        //Claims Classes and Categories selection
        private bool IsCheckboxSelected(IWebElement optionWE)
        {
            return optionWE.GetAttribute("class").Contains("selected");
        }

        public bool AllClaimClassOptionsSelected {
            get {
                bool allSelected = true;
                try
                {
                    IReadOnlyCollection<IWebElement> options = this.WaitForElementsToBePresent(CLAIM_CLASS_CHECKBOX_GENERIC_LOCATOR);
                    foreach (IWebElement opt in options)
                    {
                        allSelected = allSelected && this.IsCheckboxSelected(opt);
                    }
                }
                catch (Exception)
                {
                    //empty list, nothing to check
                }
                
                return allSelected;
            }
        }

        public bool AllClaimClassOptionsUnselected {
            get {
                bool allUnselected = true;
                try
                {
                    IReadOnlyCollection<IWebElement> options = this.WaitForElementsToBePresent(CLAIM_CLASS_CHECKBOX_GENERIC_LOCATOR);
                    foreach (IWebElement opt in options)
                    {
                        allUnselected = allUnselected && (!this.IsCheckboxSelected(opt));
                    }
                }
                catch (Exception)
                {
                    //empty list, nothing to check
                }
                
                return allUnselected;
            }
        }

        public bool AllClaimCategoryOptionsSelected
        {
            get
            {
                bool allSelected = true;
                try
                {
                    IReadOnlyCollection<IWebElement> options = this.WaitForElementsToBePresent(CLAIM_CATEGORY_CHECKBOX_GENERIC_LOCATOR);
                    foreach (IWebElement opt in options)
                    {
                        allSelected = allSelected && this.IsCheckboxSelected(opt);
                    }
                }
                catch (Exception)
                {
                    //empty list, nothing to check
                }

                return allSelected;
            }
        }

        public bool AllClaimCategoryOptionsUnselected
        {
            get
            {
                bool allUnselected = true;
                try
                {
                    IReadOnlyCollection<IWebElement> options = this.WaitForElementsToBePresent(CLAIM_CATEGORY_CHECKBOX_GENERIC_LOCATOR);
                    foreach (IWebElement opt in options)
                    {
                        allUnselected = allUnselected && (!this.IsCheckboxSelected(opt));
                    }
                }
                catch (Exception)
                {
                    //empty list, nothing to check
                }
                
                return allUnselected;
            }
        }

        public string AnotherSelectionRequiredMessage {
            get {
                return this.WaitForElementToBeVisible(ANOTHER_SELECTION_MESSAGE_LOCATOR).Text;
            }
        }

        public string GroupingSectionTitle {
            get {
                return this.WaitForElementToBeVisible(GROUPING_SECTION_TITLE_LOCATOR).Text;
            } 
        }

        public bool IsPresentSaveButton
        {
            get {
                try
                {
                    this.WaitForElementToBeVisible(SAVE_BUTTON_LOCATOR);
                    return true;
                }
                catch (Exception)
                {
                    return false;
                }
            }
        }

        public bool AnotherSelectionRequiredMessageInvisible {
            get {
                try
                {
                    this.WaitForElementToDissapear(ANOTHER_SELECTION_MESSAGE_LOCATOR, 2);
                    return true;
                }
                catch (Exception)
                {
                    return false;
                }
            }
        }

        public bool NextButtonIsInvisible {
            get {
                try
                {
                    this.WaitForElementToDissapear(NEXT_BUTTON_LOCATOR,5);
                    return true;
                }
                catch (Exception)
                {
                    return false;
                }
            }
        }

        public object SaveButtonText {
            get
            {
                return this.WaitForElementToBeVisible(SAVE_BUTTON_LOCATOR).Text;
            }
        }

        public bool IsSelectedClaimClassOption(string classOption)
        {
            IWebElement checkboxWE;

            switch (classOption)
            {
                case "Select All":
                    checkboxWE = this.WaitForElementToBePresent(CLAIM_CLASS_SELECT_ALL_CHECKBOX_LOCATOR);
                    break;
                default:
                    checkboxWE = this.WaitForElementToBePresent(By.XPath(String.Format(CLAIM_CLASS_CHECKBOX_BY_NAME_TEMPLATE_LOCATOR, classOption)));
                    break;
            }

            return this.IsCheckboxSelected(checkboxWE);
        }

        public bool IsSelectedClaimCategoryOption(string categoryOption)
        {
            IWebElement checkboxWE;

            switch (categoryOption)
            {
                case "Select All":
                    checkboxWE = this.WaitForElementToBePresent(CLAIM_CATEGORY_SELECT_ALL_CHECKBOX_LOCATOR);
                    break;
                default:
                    checkboxWE = this.WaitForElementToBePresent(By.XPath(String.Format(CLAIM_CATEGORY_CHECKBOX_BY_NAME_TEMPLATE_LOCATOR, categoryOption)));
                    break;
            }
            return this.IsCheckboxSelected(checkboxWE);
        }

        public void UnselectClaimClassFirstOption()
        {
            this.ToggleClaimClass(this.WaitForElementToBePresent(CLAIM_CLASS_LABEL_GENERIC_LOCATOR).Text, false);
        }        

        public void UnselectClaimCategoryFirstOption()
        {
            this.ToggleClaimCategorySelection(this.WaitForElementToBePresent(CLAIM_CATEGORY_LABEL_GENERIC_LOCATOR).Text, false);
        }

        //Toggle selection to true
        public void SelectClassOption(string classOption)
        {
            this.ToggleClaimClass(classOption, true);
        }

        //Toggle selection to false
        public void UnselectClassOption(string classOption)
        {
            this.ToggleClaimClass(classOption, false);
        }

        //Toggle selection if different from what is already set
        private void ToggleClaimClass(string classOption, bool select)
        {
            IWebElement optionWE;
            IWebElement checkboxWE;

            switch (classOption)
            {
                case "Select All":
                    checkboxWE = this.WaitForElementToBePresent(CLAIM_CLASS_SELECT_ALL_CHECKBOX_LOCATOR);
                    optionWE = this.WaitForElementToBePresent(CLAIM_CLASS_SELECT_ALL_LABEL_LOCATOR);       
                    break;

                default:
                    checkboxWE = this.WaitForElementToBePresent(By.XPath(String.Format(CLAIM_CLASS_CHECKBOX_BY_NAME_TEMPLATE_LOCATOR, classOption)));
                    optionWE = this.WaitForElementToBePresent(By.XPath(String.Format(CLAIM_CLASS_LABEL_BY_NAME_TEMPLATE_LOCATOR, classOption)));
                    break;
            }

            if (this.IsCheckboxSelected(checkboxWE) != select)
            {
                this.JSMoveToViewElement(this.WaitForElementToBeVisible(SELECT_CLASSES_AND_CATEGORIES_MESSAGE_LOCATOR));
                optionWE.Click();
            }
        }

        //Toggle selection to true
        public void SelectClaimCategoryOption(string classOption)
        {
            this.ToggleClaimCategorySelection(classOption, true);
        }

        //Toggle selection to false
        public void UnselectClaimCategoryOption(string classOption)
        {
            this.ToggleClaimCategorySelection(classOption, false);
        }        

        //Toggle selection if different from what is already set
        private void ToggleClaimCategorySelection(string categoryOption, bool select)
        {
            IWebElement optionWE;
            IWebElement checkboxWE;

            switch (categoryOption)
            {
                case "Select All":
                    checkboxWE = this.WaitForElementToBePresent(CLAIM_CATEGORY_SELECT_ALL_CHECKBOX_LOCATOR);
                    optionWE = this.WaitForElementToBePresent(CLAIM_CATEGORY_SELECT_ALL_LABEL_LOCATOR);
                    break;

                default:
                    checkboxWE = this.WaitForElementToBePresent(By.XPath(String.Format(CLAIM_CATEGORY_CHECKBOX_BY_NAME_TEMPLATE_LOCATOR, categoryOption)));
                    optionWE = this.WaitForElementToBePresent(By.XPath(String.Format(CLAIM_CATEGORY_LABEL_BY_NAME_TEMPLATE_LOCATOR, categoryOption)));
                    break;
            }

            if (this.IsCheckboxSelected(checkboxWE) != select)
            {
                this.JSMoveToViewElement(this.WaitForElementToBeVisible(SELECT_CLASSES_AND_CATEGORIES_MESSAGE_LOCATOR));
                optionWE.Click();
            }
        }


        public bool IsSelectedClaimOption(string claimName)
        {
            IWebElement optionWE = this.WaitForElementToBePresent(By.XPath(String.Format(CLAIM_LABEL_BY_NAME_TEMPLATE_LOCATOR, claimName)));
            string claimId = optionWE.GetAttribute("id").Replace("claimNameForClaim", "");

            IWebElement checkboxWE = this.WaitForElementToBePresent(By.Id(String.Format(CLAIM_CHECKBOX_BY_ID_TEMPLATE_LOCATOR, claimId)));

            return this.IsCheckboxSelected(checkboxWE);
        }

        public void UnselectClaimOptionByName(string claimName)
        {
            this.ToggleClaimSelection(claimName, false);
        }

        public void SelectClaimOptionByName(string claimName)
        {
            this.ToggleClaimSelection(claimName, true);
        }

        private void ToggleClaimSelection(string claimName, bool select)
        {
            IWebElement optionWE = this.WaitForElementToBePresent(By.XPath(String.Format(CLAIM_LABEL_BY_NAME_TEMPLATE_LOCATOR, claimName)));
            string claimId = optionWE.GetAttribute("id").Replace("claimNameForClaim", "");

            IWebElement checkboxWE = this.WaitForElementToBePresent(By.Id(String.Format(CLAIM_CHECKBOX_BY_ID_TEMPLATE_LOCATOR, claimId)));


            if (this.IsCheckboxSelected(checkboxWE) != select) {
                this.JSMoveToViewElement(this.WaitForElementToBeVisible(CONFIRM_SELECTION_MESSAGE_LOCATOR));
                optionWE.FindElement(By.XPath("../../div")).Click();
            }
        }

        public bool IsClaimClassPresentOnClaimList(string claimClass)
        {
            try
            {
                this.WaitForElementToBeVisible(By.Id(String.Format(CLAIM_LIST_CLASS_TITLE_FOR_CLASSNAME_BY_ID_LOCATOR_TEMPLATE, claimClass)));
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public int GetClaimClassCountOnClaimList(string claimClass)
        {
            return Convert.ToInt32(this.WaitForElementToBeVisible(By.Id(String.Format(CLAIM_LIST_COUNT_OF_CLASS_FOR_CLASSNAME_BY_ID_LOCATOR_TEMPLATE, claimClass))).Text.Replace("(","").Replace(")", ""));
        }

        //Get list of classes and categories

        public List<DistributionClaimClassData> GetFirstNClasses(int top)
        {
            IReadOnlyCollection<IWebElement> allClaimClasses = this.WaitForElementsToBeVisible(CLAIM_CLASS_BOX_LOCATOR);
            List<DistributionClaimClassData> claimClasses = new List<DistributionClaimClassData>();

            int count = 0;
            IEnumerator<IWebElement> enumClasses = allClaimClasses.GetEnumerator();            

            while ((enumClasses.MoveNext()) && (count < top))
            {
                claimClasses.Add(this.CreateClaimClassFromWebElement(enumClasses.Current));
                count++;
            }

            return claimClasses;
        }       

        private DistributionClaimClassData CreateClaimClassFromWebElement(IWebElement claimClassBox)
        {
            this.MoveToViewElement(claimClassBox);

            DistributionClaimClassData classData = new DistributionClaimClassData();
            IWebElement label = claimClassBox.FindElement(By.XPath(".//label[contains(@id,'claimClass')]"));
            string classId = label.GetAttribute("id").Replace("claimClass","");

            classData.Name = label.Text;
            classData.Selected = this.IsCheckboxSelected(this.WaitForElementToBePresent(By.XPath(String.Format(CLAIM_CLASS_CHECKBOX_BY_CLASSID_LOCATOR, classId))));
            classData.BalanceLabel = claimClassBox.FindElement(By.Id(classId + "ReservedLabel")).Text;
            classData.BalanceValue = claimClassBox.FindElement(By.Id(classId + "BalanceValue")).Text;
            classData.Reserved = claimClassBox.FindElement(By.Id(classId + "Reserved")).Text;

            return classData;
        }

        public List<DistributionClaimCategoryData> GetFirstNCategories(int top)
        {
            IReadOnlyCollection<IWebElement> allClaimCategories = this.WaitForElementsToBeVisible(CLAIM_CATEGORY_BOX_LOCATOR);
            List<DistributionClaimCategoryData> claimCategories = new List<DistributionClaimCategoryData>();

            int count = 0;
            IEnumerator<IWebElement> enumCategories = allClaimCategories.GetEnumerator();

            while ((enumCategories.MoveNext()) && (count < top))
            {
                claimCategories.Add(this.CreateClaimCategoryFromWebElement(enumCategories.Current));
                count++;
            }

            return claimCategories;
        }

        public List<DistributionGroupData> GetDistributionGroups()
        {
            List<DistributionGroupData> groupsData = new List<DistributionGroupData>();
            IReadOnlyCollection<IWebElement> groups = this.WaitForElementsToBeVisible(DISTRIBUTION_GROUP_LOCATOR);

            foreach (IWebElement group in groups)
            {
                string groupId = group.GetAttribute("id").Replace("distributionGroup","");
                if (!groupId.Contains("Index"))
                {
                    DistributionGroupData groupData = new DistributionGroupData();
                    groupData.Number = this.WaitForElementToBeVisible(By.Id(String.Format(DISTR_GROUP_INDEX_LOCATOR_TEMPLATE, groupId))).Text;
                    groupData.DistributingLabel = this.WaitForElementToBeVisible(By.Id(String.Format(DISTR_GROUP_DISTRIBUTING_LABEL_LOCATOR_TEMPLATE, groupId))).Text;
                    groupData.Percentage = this.WaitForElementToBeVisible(By.Id(String.Format(DISTR_GROUP_PERCENTAGE_LOCATOR_TEMPLATE, groupId))).Text;
                    groupData.Amount = this.WaitForElementToBeVisible(By.Id(String.Format(DISTR_GROUP_AMOUNT_LOCATOR_TEMPLATE, groupId))).Text;
                    groupData.Method = this.WaitForElementToBeVisible(By.Id(String.Format(DISTR_GROUP_METHOD_LOCATOR_TEMPLATE, groupId))).Text;
                    groupData.ReservedValue = this.WaitForElementToBeVisible(By.Id(String.Format(DISTR_GROUP_RESERVED_AMOUNT_LOCATOR_TEMPLATE, groupId))).Text;
                    groupData.ReservedLabel = this.WaitForElementToBeVisible(By.Id(String.Format(DISTR_GROUP_RESERVED_AMOUNT_TEXT_LOCATOR_TEMPLATE, groupId))).Text;
                    groupData.ClaimsIncludedNumber = this.WaitForElementToBeVisible(By.Id(String.Format(DISTR_GROUP_CLAIMS_INCLUDED_VALUE_LOCATOR_TEMPLATE, groupId))).Text;
                    groupData.ClaimsIncludedLabel = this.WaitForElementToBeVisible(By.Id(String.Format(DISTR_GROUP_CLAIMS_INCLUDED_LABEL_LOCATOR_TEMPLATE, groupId))).Text;
                    groupData.ClaimsIncludedNote = this.WaitForElementToBeVisible(By.Id(String.Format(DISTR_GROUP_CLAIMS_INCLUDED_NOTE_LOCATOR_TEMPLATE, groupId))).Text;

                    groupData.ClaimsIncludedList = "";
                    IReadOnlyCollection<IWebElement> included = this.WaitForElementsToBeVisible(By.XPath(String.Format(DISTR_GROUP_CLAIMS_INCLUDED_ITEMS_LOCATOR_TEMPLATE, groupId)));
                    foreach (IWebElement claimsClass in included)
                    {
                        groupData.ClaimsIncludedList += claimsClass.Text;
                    }

                    groupsData.Add(groupData);
                }
            }

            return groupsData;
            
        }

        private DistributionClaimCategoryData CreateClaimCategoryFromWebElement(IWebElement claimCategoryBox)
        {
            this.MoveToViewElement(claimCategoryBox);

            DistributionClaimCategoryData classData = new DistributionClaimCategoryData();
            IWebElement label = claimCategoryBox.FindElement(By.XPath(".//label[contains(@id,'claimCategory')]"));
            string classId = label.GetAttribute("id").Replace("claimCategory", "");

            classData.Name = label.Text;
            classData.Selected = this.IsCheckboxSelected(this.WaitForElementToBePresent(By.XPath(String.Format(CLAIM_CATEGORY_CHECKBOX_BY_CATEGORYID_LOCATOR, classId))));
            classData.BalanceLabel = claimCategoryBox.FindElement(By.Id(classId + "Balance-Label")).Text;
            classData.BalanceValue = claimCategoryBox.FindElement(By.Id(classId + "Balance-Value")).Text;
            classData.Reserved = claimCategoryBox.FindElement(By.Id(classId + "-Reserved")).Text;

            return classData;
        }
                
        public List<DistributionClaimData> GetClaimsByStatusUnderClass(string status, string claimClass)
        {
            List<DistributionClaimData> allClaimsData = new List<DistributionClaimData>();
            string statusPrefix;
            switch (status)
            {
                case "Valid To Pay":
                    statusPrefix = "validToPaid"; 
                    break;
                case "Objection Pending":
                    statusPrefix = "objectionPending";
                    break;
                default:
                    throw new NotImplementedException();
            }

            IReadOnlyCollection <IWebElement> claims = this.WaitForElementsToBeVisible(
                By.XPath(String.Format(CLAIM_SUMMARY_ITEM_CONTAINER_UNDER_STATUS_AND_CLASS_LOCATOR_TEMPLATE,statusPrefix, claimClass.Trim())));

            foreach (IWebElement claim in claims)
            {
                DistributionClaimData claimData = new DistributionClaimData();
                IWebElement checkbox = claim.FindElement(CLAIM_SUMMARY_ITEM_CHECKBOX_RELATIVE_LOCATOR);
                string claimId = checkbox.GetAttribute("id").Replace("Checkbox","");
                claimData.Selected = this.IsCheckboxSelected(checkbox);
                claimData.Name = this.WaitForElementToBeVisible(By.Id(String.Format(CLAIM_NAME_BY_ID_LOCATOR_TEMPLATE, claimId))).Text;
                claimData.Balance = this.WaitForElementToBeVisible(By.Id(String.Format(CLAIM_BALANCE_BY_ID_LOCATOR_TEMPLATE, claimId))).Text;
                try
                {
                    //optional
                    claimData.Category = this.WaitForElementToBeVisible(By.Id(String.Format(CLAIM_CATEGORY_BY_ID_LOCATOR_TEMPLATE, claimId))).Text.Trim();
                }
                catch (Exception){
                    claimData.Category = "";
                }
                try
                {
                    //optional

                    claimData.Number = this.WaitForElementToBeVisible(By.XPath(String.Format(CLAIM_NUMBER_BY_ID_LOCATOR_TEMPLATE, claimId))).Text.Replace(", ", "").Trim();
                }
                catch (Exception){
                    claimData.Number = "";
                }

                allClaimsData.Add(claimData);
            }

            return allClaimsData;
        }

        public string StatusUnderClassTitle(string status, string claimClass)
        {
            By locator;
            switch (status)
            {
                case "Valid To Pay":
                    locator = By.Id(String.Format(VALID_TO_PAY_TITLE_FOR_CLASS_BY_ID_TEMPLATE_LOCATOR, claimClass));
                    break;
                case "Objection Pending":
                    locator = By.Id(String.Format(OBJECTION_PENDING_TITLE_FOR_CLASS_BY_ID_TEMPLATE_LOCATOR, claimClass));
                    break;
                default:
                    throw new NotImplementedException();
            }
            return this.WaitForElementToBeVisible(locator).Text;
        }
    }
}