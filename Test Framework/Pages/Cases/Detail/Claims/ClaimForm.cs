using System;
using Epiq.ETS.TCMS.Anywhere.Testing.E2ETest.Test_Framework.Pages;
using OpenQA.Selenium;
using Epiq.ETS.TCMS.Anywhere.Testing.E2ETest.TestFramework.Pages.Cases.Detail;
using OpenQA.Selenium.Interactions;
using System.Collections.Generic;

namespace Epiq.ETS.TCMS.Anywhere.Testing.E2ETest.TestFramework.Pages.Cases.Detail
{
    public class ClaimForm:ClaimsDetailTab
    {
        private bool isEdit = false;


        private By FORM_TITLE_LOCATOR = By.Id("newClaimTitle");

        //Claim #
        private By CLAIM_NUMBER_CORNER_TAG_LOCATOR = By.XPath("//*[@id='newClaimCornerTag']//*[contains(@class,'au-target')]");
        private By CLAIM_NUMBER_LABEL_LOCATOR = By.XPath("//my-textbox[@id='claimNumberBox']/label");
        private By CLAIM_NUMBER_LOCATOR = By.XPath("//input[@id='claimNumberBox']");
        private By CLAIM_NUMBER_BOX_LOCATOR = By.CssSelector(".transactionNumber.claimNumberBox");

        // Name
        private By NAME_LABEL_LOCATOR = By.Id("searchLabelclaimDescriptionValue");
        private By NAME_PLACEHOLDER_LOCATOR = By.CssSelector("css=#select2-claimDescriptionValue-container > span.select2-selection__placeholder");
        private By NAME_VALUE_LOCATOR = By.Id("select2-claimDescriptionValue-container");                                               
        private By NAME_VALUE_INPUT_LOCATOR = By.CssSelector("input.select2-search__field");
        private By NAME_VALIDATION_MESSAGE_LOCATOR = By.XPath("//*[@id='claimDescriptionValue']//*[contains(@class,'aurelia-validation-message')]");
        private By NAME_SEARCH_RESULTS_LOCATOR = By.XPath(".//*[@id='select2-claimDescriptionValue-results']/li");
        private String NAME_RESULT_BY_TEXT_LOCATOR = "//*[@id='select2-claimDescriptionValue-results']/li[contains(text(),'{0}')]";

        //Status
        private By STATUS_LABEL_LOCATOR = By.CssSelector("#statusDropdown > label");        
        private By STATUS_DROPDOWN_LOCATOR = By.Id("statusDropdown");
        private By STATUS_DROPDOWN_SELECT_LOCATOR = By.CssSelector("select#statusDropdown");
        private By STATUS_DROPDOWN_OPTION_LOCATOR = By.CssSelector("#statusDropdown > option");
        private string STATUS_DROPDOWN_OPTION_BY_TEXT_LOCATOR_TEMPLATE = "//select[@id='statusDropdown']/option[contains(text(),'{0}')]";

        //Objection Code
        private By OBJECTION_CODE_LABEL_LOCATOR = By.CssSelector("#objectionCodeDropdown > label");
        private By OBJECTION_CODE_DROPDOWN_LOCATOR = By.Id("objectionCodeDropdown");
        private By OBJECTION_CODE_DROPDOWN_SELECT_LOCATOR = By.CssSelector("select#objectionCodeDropdown");
        private By OBJECTION_CODE_DROPDOWN_OPTION_LOCATOR = By.CssSelector("#objectionCodeDropdown > option");

        //Category
        private By CATEGORY_LABEL_LOCATOR = By.CssSelector("#categoryDropdown > label");
        private By CATEGORY_DROPDOWN_LOCATOR = By.Id("categoryDropdown");
        private By CATEGORY_DROPDOWN_SELECT_LOCATOR = By.CssSelector("select#categoryDropdown");
        private By CATEGORY_DROPDOWN_OPTION_LOCATOR = By.CssSelector("#categoryDropdown > option");
        private string CATEGORY_DROPDOWN_OPTION_BY_TEXT_LOCATOR_TEMPLATE = "//select[@id='categoryDropdown']/option[contains(text(),'{0}')]";

        //Codes and Values
        private By CODES_AND_VALUES_TITLE_LOCATOR = By.XPath("//*[contains(@id,'codesAndValuesTitle')]");
        private By CODES_AND_VALUES_HORIZONTAL_LINE_LOCATOR = By.XPath("//*[contains(@class,'newContainer ')]//*[contains(@class,'underlineDivider')][1]");

        //Code
        private By CODE_PLACEHOLDER_LOCATOR = By.XPath("//span[@id='select2-claimCode-container']/span[@class='select2-selection__placeholder']");
        private By CODE_LABEL_LOCATOR = By.Id("codeSearchLabel");
        private By CODE_VALUE_LOCATOR = By.Id("select2-claimCode-container");
        private By CODE_VALUE_INPUT_LOCATOR = By.CssSelector("input.select2-search__field");
        private By CODE_SEARCH_RESULTS_LOCATOR = By.XPath("//*[@id='select2-claimCode-results']//div");
        private String CODE_RESULT_BY_TEXT_LOCATOR_TEMPLATE = "//*[@id='select2-claimCode-results']//div[contains(text(),'{0}')]";
        private By CODE_VALIDATION_MESSAGE_LOCATOR = By.XPath("//*[@id='claimCode']//*[contains(@class,'aurelia-validation-message')]");

        //Class
        private By CLASS_LABEL_LOCATOR = By.Id("claimClassSpan");
        private By CLASS_VALUE_LOCATOR = By.Id("claimClassSpanValue");

        //Subcode
        private By SUBCODE_LABEL_LOCATOR = By.CssSelector("#subcodeClaim > #codeSearchContainer > label");
        private By SUBCODE_PLACEHOLDER_LOCATOR = By.CssSelector("#select2-subcodeClaim-container > span.select2-selection__placeholder");
        private By SUBCODE_VALUE_LOCATOR = By.Id("select2-subcodeClaim-container");
        private By SUBCODE_VALUE_INPUT_LOCATOR = By.CssSelector("input.select2-search__field");
        private By SUBCODE_SEARCH_RESULTS_LOCATOR = By.XPath("//*[@id='select2-subcodeClaim-results']//div");
        private string SUBCODE_RESULT_BY_TEXT_LOCATOR_TEMPLATE = "//*[@id='select2-subcodeClaim-results']//div[contains(text(),'{0}')]";
        private By INACTIVE_SPAN_SUBCODE_INPUT_LOCATOR = By.XPath("//*[@id='subcodeClaim']/../span");

        //Pay Sequence
        private By PAY_SEQUENCE_LABEL_LOCATOR = By.CssSelector("#claimPaySequence>label");
        private By PAY_SEQUENCE_VALUE_LOCATOR = By.CssSelector("input#claimPaySequence");
        private By PAY_SEQUENCE_VALIDATION_MESSAGE_LOCATOR = By.CssSelector("my-numericbox#claimPaySequence > .aurelia-validation-message.error");

        //Scheduled Amount
        private By SCHEDULED_AMOUNT_LABEL_LOCATOR = By.CssSelector("#scheduleAmount > label");
        private By SCHEDULED_AMOUNT_VALUE_LOCATOR = By.CssSelector("input#scheduleAmount");

        //Claimed Amount
        private By CLAIMED_AMOUNT_LABEL_LOCATOR = By.CssSelector("#claimedAmount > label");
        private By CLAIMED_AMOUNT_VALUE_LOCATOR = By.CssSelector("input#claimedAmount");

        //Allowed Amount
        private By ALLOWED_AMOUNT_LABEL_LOCATOR = By.CssSelector("#allowedAmount > label");
        private By ALLOWED_AMOUNT_VALUE_LOCATOR = By.CssSelector("input#allowedAmount");

        //Reserved Amount
        private By RESERVED_AMOUNT_LABEL_LOCATOR = By.CssSelector("#reservedAmount > label");
        private By RESERVED_AMOUNT_VALUE_LOCATOR = By.CssSelector("input#reservedAmount");


        //Interes, Paid and Balance
        private By INTEREST_LABEL_LOCATOR = By.Id("claimInterestSpan");
        private By INTEREST_VALUE_LOCATOR = By.Id("claimInterestSpanValue");

        private By PAID_LABEL_LOCATOR = By.Id("claimPaidSpan");
        private By PAID_VALUE_LOCATOR = By.Id("claimPaidSpanValue");

        private By BALANCE_LABEL_LOCATOR = By.Id("claimBalanceSpan");
        private By BALANCE_VALUE_CREATE_LOCATOR = By.Id("claimBalanceSpanValueCreate");
        private By BALANCE_VALUE_EDIT_LOCATOR = By.Id("claimBalanceSpanValueEdit");


        //More Options
        private By MORE_OPTIONS_LINK_LOCATOR = By.Id("moreOptions-expandableTitle");
        private By MORE_OPTIONS_BAR_LOCATOR = By.Id("moreOptions-expandableSection");        
        private By MORE_OPTIONS_LINK_ARROW_LOCATOR = By.CssSelector("#moreOptions-expandableArrow > i");
        private By LESS_OPTIONS_LINK_LOCATOR = By.Id("moreOptions-expandableTitleBottom");
        private By LESS_OPTIONS_LINK_ARROW_LOCATOR = By.CssSelector("#moreOptions-expandableArrowBottom > i");

        //Save and Cancel section
        private By SAVE_BUTTON_LOCATOR = By.Id("saveNewClaim");
        private By SAVE_AND_ADD_ANOTHER_BUTTON_LOCATOR = By.Id("saveAndAddAnotherClaim");
        private By CANCEL_BUTTON_LOCATOR = By.Id("cancelNewClaim");

        //Payment Options and Additional Creditor Info
        private By PAYMENT_OPTIONS_SUBTITLE_LOCATOR = By.Id("paymentOptions-expandableTitle");
        private By PAYMENT_OPTIONS_UNFOLD_ARROW_LOCATOR = By.CssSelector("#paymentOptions-expandableArrow > i.fa.fa-chevron-down");
        private By PAYMENT_OPTIONS_FOLD_ARROW_LOCATOR = By.CssSelector("#paymentOptions-expandableArrow > i.fa.fa-chevron-up");

        private By CREDITOR_ACCOUNT_LABEL_LOCATOR = By.CssSelector("#creditorAccountNumber > label");
        private By CREDITOR_ACCOUNT_VALUE_LOCATOR = By.CssSelector("input#creditorAccountNumber");

        private By CHECK_DESCRIPTION_LABEL_LOCATOR = By.CssSelector("#checkDescription > label");
        private By CHECK_DESCRIPTION_VALUE_LOCATOR = By.CssSelector("input#checkDescription");

        //Claims Options
        private By CLAIMS_OPTION_LABEL_LOCATOR = By.Id("addClaimOptionsLabel");
        private By CLAIM_OPTION_WAGE_DEDUCTION_LABEL_LOCATOR = By.Id("labelIsWageClaim");
        private By CLAIM_OPTION_WAGE_DEDUCTION_VALUE_LOCATOR = By.Id("checkboxIsWageClaim");
        private By CLAIM_OPTION_NON_COMPENSABLE_LABEL_LOCATOR = By.Id("labelIsNonCompensable");
        private By CLAIM_OPTION_NON_COMPENSABLE_VALUE_LOCATOR = By.Id("checkboxIsNonCompensable");
        private By CLAIM_OPTION_EXCLUDE_FROM_UFR_LABEL_LOCATOR = By.Id("labelExcludeFromUFR");
        private By CLAIM_OPTION_EXCLUDE_FROM_UFR_VALUE_LOCATOR = By.Id("checkboxExcludeFromUFR");
        private By CLAIM_OPTION_NON_DISCHARGED_LABEL_LOCATOR = By.Id("labelIsNonDischarged");
        private By CLAIM_OPTION_NON_DISCHARGED_VALUE_LOCATOR = By.Id("checkboxIsNonDischarged");
        private By CLAIM_OPTION_REAFFIRMED_LABEL_LOCATOR = By.Id("labelIsReaffirmed");
        private By CLAIM_OPTION_REAFFIRMED_VALUE_LOCATOR = By.Id("checkboxIsReaffirmed");

        //Dates
        private By DATE_FILED_DATE_BOX_LOCATOR = By.CssSelector("my-datebox#dateFiledDatebox");
        private By DATE_FILED_VALUE_LOCATOR = By.CssSelector("input#dateFiledDatebox");
        private By BAR_DATE_DATE_BOX_LOCATOR = By.CssSelector("my-textbox#barDate");
        private By BAR_DATE_VALUE_LOCATOR = By.CssSelector("input#barDate");

        //Amends
        private By AMENDS_BOX_LOCATOR = By.CssSelector("my-textbox#amends");
        private By AMENDS_VALUE_LOCATOR = By.CssSelector("input#amends");
        private By AMENDS_VERSION_BOX_LOCATOR = By.CssSelector("my-textbox#amendsVersion");
        private By AMENDS_VERSION_VALUE_LOCATOR = By.CssSelector("input#amendsVersion");
        private By AMENDED_BY_BOX_LOCATOR = By.CssSelector("my-textbox#amendedBy");
        private By AMENDED_BY_VALUE_LOCATOR = By.CssSelector("input#amendedBy");
        private By AMENDED_BY_VERSION_BOX_LOCATOR = By.CssSelector("my-textbox#amendedByVersion");
        private By AMENDED_BY_VERSION_VALUE_LOCATOR = By.CssSelector("input#amendedByVersion");

        //Notes
        private By NOTES_TITLE_LOCATOR = By.Id("claimNotes-expandableTitle");
        private By REGISTER_NOTES_LABEL_LOCATOR = By.Id("claimRegisterNoteTitle");
        private By REGISTER_NOTES_VALUE_LOCATOR = By.Id("claimRegisterNoteTextArea");
        private By INTERNAL_NOTES_LABEL_LOCATOR = By.Id("claimInternalNoteTitle");
        private By INTERNAL_NOTES_VALUE_LOCATOR = By.Id("claimInternalNoteTextArea");
        private By NOTES_UNFOLD_ARROW_LOCATOR = By.CssSelector("#claimNotes-expandableArrow > i.fa.fa-chevron-down");
        private By NOTES_FOLD_ARROW_LOCATOR = By.CssSelector("#claimNotes-expandableArrow > i.fa.fa-chevron-up");
        private By LINE_UNDER_SAVE_BUTTON_LOCATOR = By.XPath("//article/div[2]/div[4]");

        public ClaimForm(IWebDriver driver, bool edit): base(driver)
        {
            this.isEdit= edit;
        }

        public string ClaimFormTitle {
            get {
               return this.WaitForElementToBeVisible(FORM_TITLE_LOCATOR).Text;
            }
        }

        public string ClaimNumberLabel
        {
            get
            {
                return this.WaitForElementToBeVisible(CLAIM_NUMBER_LABEL_LOCATOR).Text;
            }
        }

        public string ClaimNumber {
            get {
                return this.WaitForElementToBeVisible(CLAIM_NUMBER_LOCATOR).GetAttribute("value");
            }
            set {
                try
                {
                    this.ClearAndType(this.WaitForElementToBeVisible(CLAIM_NUMBER_LOCATOR), value);
                }
                catch (Exception)
                {
                    //this.JSMoveToViewElement(this.WaitForElementToBeVisible(NEW_CLAIM_FORM_TITLE_LOCATOR));
                    IWebElement numberInput = this.WaitForElementToBeVisible(CLAIM_NUMBER_LOCATOR);
                    clickNotVisualizedElement(numberInput);
                    this.ClearAndType(numberInput, value);
                }
            }
        }

        public string ClaimNumberCornerTagColor {
            get
            {
                return this.GetColorFromColorCode(this.WaitForElementToBeVisible(CLAIM_NUMBER_CORNER_TAG_LOCATOR).GetCssValue("fill"));
            }
        }

        public string ClaimNameLabel {
            get {
                string[] stringSeparators = new string[] { "\r\n" };
                string[] name = this.WaitForElementToBeVisible(NAME_LABEL_LOCATOR).Text.Split(stringSeparators, StringSplitOptions.None);
                string ret = name[0];
                return ret.TrimEnd(' ');
            }
        }

        public string ClaimNamePlaceholder {
            get {
                string[] stringSeparators = new string[] { "\r\n" };
                string[] name = this.WaitForElementToBeVisible(NAME_LABEL_LOCATOR).Text.Split(stringSeparators, StringSplitOptions.None);
                string ret = name[1];
                return ret.TrimStart(' ').TrimEnd(' ');
            }
        }        

        public string ClaimName {
            get {
                return this.WaitForElementToBeVisible(NAME_VALUE_LOCATOR).Text;
            }

            set {
                this.TypeClaimName(value);
                this.WaitForElementToBeVisible(By.XPath(String.Format(NAME_RESULT_BY_TEXT_LOCATOR, value))).Click();
            }
        }

        public void TypeClaimName(string name)
        {
            try
            {
                this.WaitForElementToBeVisible(NAME_VALUE_LOCATOR).Click();
            }
            catch (Exception)
            {
                this.JSMoveToViewElement(this.WaitForElementToBeVisible(selectionTitleLocator));
                this.WaitForElementToBeVisible(NAME_VALUE_LOCATOR).Click();
            }

            this.ClearAndType(this.WaitForElementToBeVisible(NAME_VALUE_INPUT_LOCATOR), name);
            this.Pause(2);
        }

        public string ValidationMessageOnName
        {
            get
            {
                try
                {
                    return this.WaitForElementToBeVisible(NAME_VALIDATION_MESSAGE_LOCATOR).Text;
                }
                catch (Exception)
                {
                    return "";

                }
            }
        }
        public bool ValidationMessageOnNameDissapeared
        {
            get
            {
                try
                {
                    this.WaitForElementToDissapear(NAME_VALIDATION_MESSAGE_LOCATOR, 5);
                    return true;
                }
                catch (Exception)
                {
                    return false;
                }

            }
        }       

        public List<string> ClaimNameSearchResults
        {
            get
            {
                this.Pause(2);
                List<string> ret = new List<string>();
                this.WaitForElementToDissapear(By.XPath(String.Format(NAME_RESULT_BY_TEXT_LOCATOR, "Searching...")));
                IReadOnlyCollection<IWebElement> results = this.WaitForElementsToBePresent(NAME_SEARCH_RESULTS_LOCATOR);
                foreach (IWebElement result in results)
                {
                    ret.Add(result.Text);
                }
                return ret;
            }
        }

        public void SelectAddClaimantResultFromNameSearch()
        {
            //select first result, should be "Add claimant"
            this.WaitForElementToBePresent(NAME_SEARCH_RESULTS_LOCATOR).Click();
        }

        public void SelectResultContainingClaimName(string name)
        {
            this.WaitForElementToBeVisible(By.XPath(String.Format(NAME_RESULT_BY_TEXT_LOCATOR, name))).Click();
        }

        public List<string> GetClaimNameResultsByContent(string name)
        {
            IReadOnlyCollection<IWebElement> results = this.WaitForElementsToBeVisible(By.XPath(String.Format(NAME_RESULT_BY_TEXT_LOCATOR, name)));
            List<string> ret = new List<string>();
            foreach (IWebElement result in results)
            {
                ret.Add(result.Text);
            }
            return ret;
        }

        public string ClaimStatusLabel {
            get {
                string[] stringSeparators = new string[] { "\r\n" };
                return this.WaitForElementToBeVisible(STATUS_LABEL_LOCATOR).Text.Split(stringSeparators, StringSplitOptions.None)[0].TrimEnd(' ');
            }
        }
        public string ClaimStatus {
            get {                
                return this.WaitForElementToBeVisible(STATUS_DROPDOWN_SELECT_LOCATOR).GetAttribute("value");
            }
            set
            {
                this.WaitForElementToBeClickeable(STATUS_DROPDOWN_SELECT_LOCATOR).Click();
                this.WaitForElementToBeClickeable(By.XPath(String.Format(STATUS_DROPDOWN_OPTION_BY_TEXT_LOCATOR_TEMPLATE, value))).Click();
            }
        }        

        public List<string> ClaimStatusList {
            get {
               return this.GetDropdownOptionsList(STATUS_DROPDOWN_OPTION_LOCATOR);
            }
        }

        public string ObjectionCodeLabel {
            get {
                string[] stringSeparators = new string[] { "\r\n" };
                return this.WaitForElementToBeVisible(OBJECTION_CODE_LABEL_LOCATOR).Text.Split(stringSeparators, StringSplitOptions.None)[0].TrimEnd(' ');
            }
        }

        public string ObjectionCode {
            get {
                return this.WaitForElementToBeVisible(OBJECTION_CODE_DROPDOWN_SELECT_LOCATOR).GetAttribute("value");
            }
        }
        public bool ObjectionCodeActive {
            get {
                return (this.WaitForElementToBeVisible(OBJECTION_CODE_DROPDOWN_LOCATOR).GetAttribute("disabled") == "");
            }
        }        

        public List<string> ObjectionCodeList
        {
            get
            {
                this.Pause(2);
                return this.GetDropdownOptionsList(OBJECTION_CODE_DROPDOWN_OPTION_LOCATOR);
            }
        }

        public string CategoryLabel {
            get {
                string[] stringSeparators = new string[] { "\r\n" };
                return this.WaitForElementToBeVisible(CATEGORY_LABEL_LOCATOR).Text.Split(stringSeparators, StringSplitOptions.None)[0].TrimEnd(' ');
            }
        }
        public string Category {
            get {
                return this.WaitForElementToBeVisible(CATEGORY_DROPDOWN_SELECT_LOCATOR).GetAttribute("value");
            }
            set
            {
                this.WaitForElementToBeClickeable(CATEGORY_DROPDOWN_LOCATOR).Click();
                this.WaitForElementToBeClickeable(By.XPath(String.Format(CATEGORY_DROPDOWN_OPTION_BY_TEXT_LOCATOR_TEMPLATE, value))).Click();
            }
        }

        public List<string> CategoryList {
            get {
                return this.GetDropdownOptionsList(CATEGORY_DROPDOWN_OPTION_LOCATOR);
            }
        }

        public string CodesAndValuesTitle {
            get {
                return this.WaitForElementToBeVisible(CODES_AND_VALUES_TITLE_LOCATOR).Text;
            }
        }        

        public bool CodesAndValuesHorizontalLinePresent {
            get {
                try
                {
                    this.WaitForElementToBeVisible(CODES_AND_VALUES_HORIZONTAL_LINE_LOCATOR);
                    return true;    
                }
                catch (Exception)
                {
                    return false;
                }

            }
        }

        public string CodePlaceholder {
            get {
                return this.WaitForElementToBeVisible(CODE_PLACEHOLDER_LOCATOR).Text;
            }
        }

        public string CodeLabel {
            get {
                string[] stringSeparators = new string[] { "\r\n" };
                return   this.WaitForElementToBeVisible(CODE_LABEL_LOCATOR).Text.Split(stringSeparators, StringSplitOptions.None)[0].TrimEnd(' ');
            }
        }

        public string Code {
            get {
                return this.WaitForElementToBeVisible(CODE_VALUE_LOCATOR).Text;
            }
            set {
                this.TypeCode(value);
                this.WaitForElementToBeClickeable(By.XPath(String.Format(CODE_RESULT_BY_TEXT_LOCATOR_TEMPLATE,value))).Click();
            }
        }

        public void TypeCode(string code)
        {
            this.MoveToViewElement(this.WaitForElementToBeVisible(CODE_LABEL_LOCATOR));
            this.WaitForElementToBeVisible(CODE_VALUE_LOCATOR).Click();
            this.ClearAndType(this.WaitForElementToBeVisible(CODE_VALUE_INPUT_LOCATOR), code);
            this.Pause(3);
        }

        public List<string> CodeSearchResults
        {
            get
            {
                List<string> ret = new List<string>();
                IReadOnlyCollection<IWebElement> results = this.WaitForElementsToBeVisible(CODE_SEARCH_RESULTS_LOCATOR);
                foreach (IWebElement result in results)
                {
                    ret.Add(result.Text);
                }
                return ret;
            }
        }        

        public string ClassLabel {
            get {                
                return this.WaitForElementToBeVisible(CLASS_LABEL_LOCATOR).Text;
            }
        }

        public string  Class {
            get {
                return this.WaitForElementToBeVisible(CLASS_VALUE_LOCATOR).Text;
            }
        }
               

        public object SubcodeLabel {
            get {
                string[] stringSeparators = new string[] { "\r\n" };
                return this.WaitForElementToBeVisible(SUBCODE_LABEL_LOCATOR).Text.Split(stringSeparators, StringSplitOptions.None)[0].TrimEnd(' ');
            }
        }       

        public object SubcodePlaceholder {
            get {
                return this.WaitForElementToBeVisible(SUBCODE_PLACEHOLDER_LOCATOR).Text;
            }
        }

        public bool SobcodeInputIsActive()
        {
            return !(this.WaitForElementToBeVisible(INACTIVE_SPAN_SUBCODE_INPUT_LOCATOR).GetAttribute("class").Contains("select2-container--disabled"));

        }

        public string Subcode {
            get
            {
                return this.WaitForElementToBeVisible(SUBCODE_VALUE_LOCATOR).Text;
            }
            set
            {
                this.TypeSubcode(value);
                this.MoveToViewElement(this.WaitForElementToBeVisible(MORE_OPTIONS_BAR_LOCATOR));
                this.MoveToViewElement(this.WaitForElementToBeVisible(SUBCODE_LABEL_LOCATOR));
                this.WaitForElementToBeClickeable(By.XPath(String.Format(SUBCODE_RESULT_BY_TEXT_LOCATOR_TEMPLATE, value))).Click();
            }
        }

        public void TypeSubcode(string subcode)
        {
            this.MoveToViewElement(this.WaitForElementToBeVisible(SUBCODE_LABEL_LOCATOR));
            this.WaitForElementToBeVisible(SUBCODE_VALUE_LOCATOR).Click();
            this.TypeIn(this.WaitForElementToBeVisible(SUBCODE_VALUE_INPUT_LOCATOR), subcode);
            this.Pause(2);
        }

        public List<string> SubcodeSearchResults
        {
            get
            {
                List<string> ret = new List<string>();
                IReadOnlyCollection<IWebElement> results = this.WaitForElementsToBeVisible(SUBCODE_SEARCH_RESULTS_LOCATOR);
                foreach (IWebElement result in results)
                {
                    ret.Add(result.Text);
                }
                return ret;
            }
        }

        public string PaySequenceLabel {
            get {
                string[] stringSeparators = new string[] { "\r\n" };
                return this.WaitForElementToBeVisible(PAY_SEQUENCE_LABEL_LOCATOR).Text.Split(stringSeparators, StringSplitOptions.None)[0].TrimEnd(' ');
            }
        }       

        public string PaySequence
        {
            get
            {                
                return this.WaitForElementToBeVisible(PAY_SEQUENCE_VALUE_LOCATOR).GetAttribute("value");
            }
            set {
                this.ClearAndType(this.WaitForElementToBeVisible(PAY_SEQUENCE_VALUE_LOCATOR),value);
            }
        }

        public string ScheduledAmountLabel {
            get {
                string[] stringSeparators = new string[] { "\r\n" };
                return this.WaitForElementToBeVisible(SCHEDULED_AMOUNT_LABEL_LOCATOR).Text.Split(stringSeparators, StringSplitOptions.None)[0].TrimEnd(' ');
            }
        }

        public string ScheduledAmount
        {
            get
            {
                return this.WaitForElementToBeVisible(SCHEDULED_AMOUNT_VALUE_LOCATOR).GetAttribute("value");
            }
            set
            {
                this.ClearAndType(this.WaitForElementToBeVisible(SCHEDULED_AMOUNT_VALUE_LOCATOR),value);
            }
        }       

        public string ClaimedAmountLabel
        {
            get
            {
                string[] stringSeparators = new string[] { "\r\n" };
                return this.WaitForElementToBeVisible(CLAIMED_AMOUNT_LABEL_LOCATOR).Text.Split(stringSeparators, StringSplitOptions.None)[0].TrimEnd(' ');
            }            
        }

        public string ClaimedAmount
        {
            get
            {
                return this.WaitForElementToBeVisible(CLAIMED_AMOUNT_VALUE_LOCATOR).GetAttribute("value");
            }
            set
            {
                this.ClearAndType(this.WaitForElementToBeVisible(CLAIMED_AMOUNT_VALUE_LOCATOR), value);
                this.Pause(2);
            }
        }


        public string AllowedAmountLabel
        {
            get
            {
                string[] stringSeparators = new string[] { "\r\n" };
                return this.WaitForElementToBeVisible(ALLOWED_AMOUNT_LABEL_LOCATOR).Text.Split(stringSeparators, StringSplitOptions.None)[0].TrimEnd(' ');
            }
        }


        public string AllowedAmount
        {
            get
            {
                return this.WaitForElementToBeVisible(ALLOWED_AMOUNT_VALUE_LOCATOR).GetAttribute("value");
            }
            set
            {
                this.ClearAndType(this.WaitForElementToBeVisible(ALLOWED_AMOUNT_VALUE_LOCATOR), value);
            }
        }

        public string ReservedAmountLabel
        {
            get
            {
                string[] stringSeparators = new string[] { "\r\n" };
                return this.WaitForElementToBeVisible(RESERVED_AMOUNT_LABEL_LOCATOR).Text.Split(stringSeparators, StringSplitOptions.None)[0].TrimEnd(' ');
            }
        }


        public string ReservedAmount
        {
            get
            {
                return this.WaitForElementToBeVisible(RESERVED_AMOUNT_VALUE_LOCATOR).GetAttribute("value");
            }
            set
            {
                this.ClearAndType(this.WaitForElementToBeVisible(RESERVED_AMOUNT_VALUE_LOCATOR), value);
            }
        }

        public object InterestLabel {
            get {
                return this.WaitForElementToBeVisible(INTEREST_LABEL_LOCATOR).Text;
            }
        }
        public object Interest {
            get {
                return this.WaitForElementToBeVisible(INTEREST_VALUE_LOCATOR).Text;
            }
        }
        public string PaidLabel {
            get {
                return this.WaitForElementToBeVisible(PAID_LABEL_LOCATOR).Text;
            }
        }
        public string Paid {
            get {
                return this.WaitForElementToBeVisible(PAID_VALUE_LOCATOR).Text;
            }
        }

        public void SelectResultContainingCode(string code)
        {
            this.WaitForElementToBeVisible(By.XPath(String.Format(CODE_RESULT_BY_TEXT_LOCATOR_TEMPLATE, code))).Click();
        }

        public string BalanceLabel {
            get {
                return this.WaitForElementToBeVisible(BALANCE_LABEL_LOCATOR).Text;
            }
        }

        public void SelectResultContainingSubcode(string subcode)
        {
            this.WaitForElementToBeVisible(By.XPath(String.Format(SUBCODE_RESULT_BY_TEXT_LOCATOR_TEMPLATE, subcode))).Click();

        }

        public string Balance {
            get {
                if(!isEdit)
                    return this.WaitForElementToBeVisible(BALANCE_VALUE_CREATE_LOCATOR).Text;
                else
                    return this.WaitForElementToBeVisible(BALANCE_VALUE_EDIT_LOCATOR).Text;
            }
        }        

        public string BalanceColor {
            get {
                return this.GetColorFromColorCode(this.WaitForElementToBeVisible(BALANCE_VALUE_CREATE_LOCATOR).GetCssValue("color"));
            }
        }

        public string MoreOptionsLinkText
        {
            get
            {
                return this.WaitForElementToBeVisible(MORE_OPTIONS_LINK_LOCATOR).Text;
            }
        }
        public bool MoreOptionsLinkArrowPointsDown
        {
            get
            {
                return this.WaitForElementToBeVisible(MORE_OPTIONS_LINK_ARROW_LOCATOR).GetAttribute("class").Contains("fa-chevron-down");
            }
        }

        public void ClickMoreOptionsLink()
        {
            //if (this.isEdit)
            //{
            //    this.WaitForElementToBePresent(SAVE_BUTTON_LOCATOR);
            //    //this.JSMoveToViewElement(lineUnderSaveButton);
            //    //this.MoveToViewElement(this.WaitForElementToBeVisible(SUBCODE_VALUE_INPUT_LOCATOR));
            //}
            //else {
            //    this.MoveToViewElement(this.WaitForElementToBeVisible(CLAIMS_LIST_SECTION_TITLE_LOCATOR));
            //    this.MoveToViewElement(this.WaitForElementToBeVisible(PAY_SEQUENCE_VALUE_LOCATOR));
            //    this.WaitForElementToBeClickeable(MORE_OPTIONS_BAR_LOCATOR).Click();
            //}
            this.clickNotVisualizedElement(this.WaitForElementToBePresent(MORE_OPTIONS_BAR_LOCATOR));

            //this.WaitForBlockOverlayToDissapear();
        }

        public bool MoreOptionsVisible
        {
            get
            {
                try
                {
                    this.MoveToViewElement(this.WaitForElementToBeVisible(claimsListSectionTitleLocator));
                    this.WaitForElementToBeVisible(PAYMENT_OPTIONS_SUBTITLE_LOCATOR);
                    return true;
                }
                catch (Exception)
                {
                    return false;
                }
            }
        }

        

        public string ValidationMessageOnPaySequence
        {
            get
            {
                try
                {
                    return this.WaitForElementToBeVisible(PAY_SEQUENCE_VALIDATION_MESSAGE_LOCATOR).Text;
                }
                catch (Exception)
                {
                    return "";
                }
            }
        }

        public bool ValidationMessageOnPaySequenceDissapeared
        {
            get
            {
                try
                {
                    this.WaitForElementToDissapear(PAY_SEQUENCE_VALIDATION_MESSAGE_LOCATOR, 5);
                    return true;
                }
                catch (Exception)
                {
                    return false;
                }

            }
        }

        public string  ValidationMessageOnCode {
            get
            {
                try
                {
                    return this.WaitForElementToBeVisible(CODE_VALIDATION_MESSAGE_LOCATOR).Text;
                }
                catch (Exception)
                {
                    return "";
                }
            }
        }

        public bool ValidationMessageOnCodeDissapeared
        {
            get
            {
                try
                {
                    this.WaitForElementToDissapear(CODE_VALIDATION_MESSAGE_LOCATOR, 5);
                    return true;
                }
                catch (Exception)
                {
                    return false;
                }

            }
        }        

        public string LessOptionsLinkText
        {
            get
            {
                return this.WaitForElementToBeVisible(LESS_OPTIONS_LINK_LOCATOR).Text;
            }
        }

        public void ClickLessOptionsLink()
        {
            this.clickNotVisualizedElement(this.WaitForElementToBeClickeable(LESS_OPTIONS_LINK_LOCATOR));
        }

        public bool LessOptionsLinkArrowPointsUp
        {
            get
            {
                return this.WaitForElementToBeVisible(LESS_OPTIONS_LINK_ARROW_LOCATOR).GetAttribute("class").Contains("fa-chevron-up");
            }
        }

        public string PaymentOptionsTitle {
            get
            {
               return this.WaitForElementToBeVisible(PAYMENT_OPTIONS_SUBTITLE_LOCATOR).Text;
            }
        }

        public string CreditorAccountNumberLabel {
            get {
                string[] stringSeparators = new string[] { "\r\n" };
                return this.WaitForElementToBeVisible(CREDITOR_ACCOUNT_LABEL_LOCATOR).Text.Split(stringSeparators, StringSplitOptions.None)[0].TrimEnd(' ');
            }
        }
        public string CreditorAccountNumber {
            get {
                return this.WaitForElementToBeVisible(CREDITOR_ACCOUNT_VALUE_LOCATOR).GetAttribute("value");
            }
            set {
                this.ClearAndType(this.WaitForElementToBeVisible(CREDITOR_ACCOUNT_VALUE_LOCATOR), value);
            }
        }
       
        public string CheckDescriptionLabel { get {
                string[] stringSeparators = new string[] { "\r\n" };
                return this.WaitForElementToBeVisible(CHECK_DESCRIPTION_LABEL_LOCATOR).Text.Split(stringSeparators, StringSplitOptions.None)[0].TrimEnd(' ');
            }
        }
        public string CheckDescription
        {
            get
            {
                return this.WaitForElementToBeVisible(CHECK_DESCRIPTION_VALUE_LOCATOR).GetAttribute("value");
            }
            set
            {
                this.ClearAndType(this.WaitForElementToBeVisible(CHECK_DESCRIPTION_VALUE_LOCATOR),value);
            }
        }

        public string ClaimOptionsLabel {
            get {
                    return this.WaitForElementToBeVisible(CLAIMS_OPTION_LABEL_LOCATOR).Text;
                }
        }
        public string WageDeductionLabel {
            get {
                return this.WaitForElementToBeVisible(CLAIM_OPTION_WAGE_DEDUCTION_LABEL_LOCATOR).Text;
            }
        }
        public bool WageDeductionSelect {
            get {
                return this.WaitForElementToBePresent(CLAIM_OPTION_WAGE_DEDUCTION_VALUE_LOCATOR).Selected;
            }
            set
            {
                IWebElement select = this.WaitForElementToBePresent(CLAIM_OPTION_WAGE_DEDUCTION_VALUE_LOCATOR);
                if ((value && !select.Selected)||(!value && select.Selected))
                    this.WaitForElementToBeVisible(CLAIM_OPTION_WAGE_DEDUCTION_LABEL_LOCATOR).Click();
            }
        }

        public string NonCompensableLabel {
            get
            {
                return this.WaitForElementToBeVisible(CLAIM_OPTION_NON_COMPENSABLE_LABEL_LOCATOR).Text;
            }
        }

        public bool NonCompensableSelect {
            get
            {
                return this.WaitForElementToBePresent(CLAIM_OPTION_NON_COMPENSABLE_VALUE_LOCATOR).Selected;
            }
            set
            {
                IWebElement select = this.WaitForElementToBePresent(CLAIM_OPTION_NON_COMPENSABLE_VALUE_LOCATOR);
                if ((value && !select.Selected) || (!value && select.Selected))
                    this.WaitForElementToBeVisible(CLAIM_OPTION_NON_COMPENSABLE_LABEL_LOCATOR).Click();
            }
        }

        public string ExcludeFromUFRLabel {
            get
            {
                return this.WaitForElementToBeVisible(CLAIM_OPTION_EXCLUDE_FROM_UFR_LABEL_LOCATOR).Text;
            }
        }

        public bool ExcludeFromUFRSelect {
            get
            {
                return this.WaitForElementToBePresent(CLAIM_OPTION_EXCLUDE_FROM_UFR_VALUE_LOCATOR).Selected;
            }
            set
            {
                IWebElement select = this.WaitForElementToBePresent(CLAIM_OPTION_EXCLUDE_FROM_UFR_VALUE_LOCATOR);
                if ((value && !select.Selected) || (!value && select.Selected))
                    this.WaitForElementToBeVisible(CLAIM_OPTION_EXCLUDE_FROM_UFR_LABEL_LOCATOR).Click();
            }
        }

        public string NonDischargedLabel {
            get
            {
                return this.WaitForElementToBeVisible(CLAIM_OPTION_NON_DISCHARGED_LABEL_LOCATOR).Text;
            }
        }

        public bool NonDischargedSelect {
            get
            {
                return this.WaitForElementToBePresent(CLAIM_OPTION_NON_DISCHARGED_VALUE_LOCATOR).Selected;
            }
            set
            {
                IWebElement select = this.WaitForElementToBePresent(CLAIM_OPTION_NON_DISCHARGED_VALUE_LOCATOR);
                if ((value && !select.Selected) || (!value && select.Selected))
                    this.WaitForElementToBeVisible(CLAIM_OPTION_NON_DISCHARGED_LABEL_LOCATOR).Click();
            }
        }

        public string ReaffirmedLabel {
            get
            {
                return this.WaitForElementToBeVisible(CLAIM_OPTION_REAFFIRMED_LABEL_LOCATOR).Text;
            }
        }

        public bool ReaffirmedSelect {
            get
            {
                return this.WaitForElementToBePresent(CLAIM_OPTION_REAFFIRMED_VALUE_LOCATOR).Selected;
            }
            set
            {
                IWebElement select = this.WaitForElementToBePresent(CLAIM_OPTION_REAFFIRMED_VALUE_LOCATOR);
                if ((value && !select.Selected) || (!value && select.Selected))
                    this.WaitForElementToBeVisible(CLAIM_OPTION_REAFFIRMED_LABEL_LOCATOR).Click();
            }
        }

        public string DateFiledLabel {
            get {
                return this.WaitForElementToBeVisible(DATE_FILED_DATE_BOX_LOCATOR).GetAttribute("label");
            }
        }
        public string DateFiledPlaceholder {
            get
            {
                return this.WaitForElementToBeVisible(DATE_FILED_VALUE_LOCATOR).GetAttribute("placeholder");
            }
        }
        public string DateFiled {
            get {
                return this.WaitForElementToBeVisible(DATE_FILED_VALUE_LOCATOR).GetAttribute("value");

            }
            set {
                this.ClearAndType(this.WaitForElementToBeVisible(DATE_FILED_VALUE_LOCATOR), value);
            }

        }

        public string BarDateLabel
        {
            get
            {
                return this.WaitForElementToBeVisible(BAR_DATE_DATE_BOX_LOCATOR).GetAttribute("label");
            }
        }
        public string BarDatePlaceholder
        {
            get
            {
                return this.WaitForElementToBeVisible(BAR_DATE_VALUE_LOCATOR).GetAttribute("placeholder");
            }
        }
        public string BarDate
        {
            get
            {
                return this.WaitForElementToBeVisible(BAR_DATE_VALUE_LOCATOR).GetAttribute("value");

            }
            set
            {
                this.ClearAndType(this.WaitForElementToBeVisible(BAR_DATE_VALUE_LOCATOR), value);
            }

        }

        public string AmendsLabel {
            get
            {                
                return this.WaitForElementToBeVisible(AMENDS_BOX_LOCATOR).GetAttribute("label");
            }
        }

        public string Amends {
            get
            {
                return this.WaitForElementToBeVisible(AMENDS_VALUE_LOCATOR).GetAttribute("value");
            }
            set
            {
                this.ClearAndType(this.WaitForElementToBeVisible(AMENDS_VALUE_LOCATOR),value);
            }
        }

        public string AmendsVersionLabel {
            get
            {
                return this.WaitForElementToBeVisible(AMENDS_VERSION_BOX_LOCATOR).GetAttribute("label");        
            }
        }

        public string AmendsVersion {
            get
            {
                return this.WaitForElementToBeVisible(AMENDS_VERSION_VALUE_LOCATOR).GetAttribute("value");
            }
            set
            {
                this.ClearAndType(this.WaitForElementToBeVisible(AMENDS_VERSION_VALUE_LOCATOR), value);                
            }
        }

        public string AmendedByLabel {
            get
            {
                return this.WaitForElementToBeVisible(AMENDED_BY_BOX_LOCATOR).GetAttribute("label");
            }
        }

        public string AmendedBy
        {
            get
            {
                return this.WaitForElementToBeVisible(AMENDED_BY_VALUE_LOCATOR).GetAttribute("value");
            }
            set
            {
                this.ClearAndType(this.WaitForElementToBeVisible(AMENDED_BY_VALUE_LOCATOR), value);
            }
        }

        public object AmendedByVersionLabel {
            get
            {
                return this.WaitForElementToBeVisible(AMENDED_BY_VERSION_BOX_LOCATOR).GetAttribute("label");

            }
        }

        public string AmendedByVersion {
            get
            {
                return this.WaitForElementToBeVisible(AMENDED_BY_VERSION_VALUE_LOCATOR).GetAttribute("value");
            }
            set
            {
                this.ClearAndType(this.WaitForElementToBeVisible(AMENDED_BY_VERSION_VALUE_LOCATOR), value);
            }
        }

        public string NotesTitle {
            get {
                return this.WaitForElementToBeVisible(NOTES_TITLE_LOCATOR).Text;
            }
        }

        public string ClaimsRegisterNoteLabel {
            get {
                return this.WaitForElementToBeVisible(REGISTER_NOTES_LABEL_LOCATOR).Text;
            }
        }

        public string ClaimsRegisterNote {
            get
            {
                return this.WaitForElementToBeVisible(REGISTER_NOTES_VALUE_LOCATOR).GetAttribute("value");
            }
            set {
                this.MoveToViewElement(this.WaitForElementToBeVisible(SAVE_BUTTON_LOCATOR));
                this.MoveToViewElement(this.WaitForElementToBeVisible(REGISTER_NOTES_LABEL_LOCATOR));
                this.ClearAndType(this.WaitForElementToBeVisible(REGISTER_NOTES_VALUE_LOCATOR), value);
            }
        }

        public string InternalClaimNoteLabel {
            get
            {
                return this.WaitForElementToBeVisible(INTERNAL_NOTES_LABEL_LOCATOR).Text;
            }
        }
        public string InternalClaimNote {
            get
            {
                return this.WaitForElementToBeVisible(INTERNAL_NOTES_VALUE_LOCATOR).GetAttribute("value");
            }
            set
            {
                this.MoveToViewElement(this.WaitForElementToBeVisible(SAVE_BUTTON_LOCATOR));
                this.MoveToViewElement(this.WaitForElementToBeVisible(INTERNAL_NOTES_LABEL_LOCATOR));
                this.ClearAndType(this.WaitForElementToBeVisible(INTERNAL_NOTES_VALUE_LOCATOR), value);
            }
        }

        public bool SaveButtonIsInactive {
            get {
                string disabled = this.WaitForElementToBeVisible(SAVE_BUTTON_LOCATOR).GetAttribute("disabled");
                if (disabled != null)
                    return true;
                else
                    return false;
            }
        }       

        public void ClickPaymentOptionsTitleBar()
        {
            this.MoveToViewElement(this.WaitForElementToBeVisible(PAY_SEQUENCE_VALUE_LOCATOR));
            this.WaitForElementToBeVisible(PAYMENT_OPTIONS_SUBTITLE_LOCATOR).Click() ;
        }

        public bool IsPaymentOptionsSectionHidden()
        {
            try
            {
                this.WaitForElementToDissapear(CREDITOR_ACCOUNT_LABEL_LOCATOR);
                this.WaitForElementToDissapear(CHECK_DESCRIPTION_LABEL_LOCATOR);
                this.WaitForElementToDissapear(CLAIMS_OPTION_LABEL_LOCATOR);
                this.WaitForElementToDissapear(DATE_FILED_DATE_BOX_LOCATOR);
                this.WaitForElementToDissapear(BAR_DATE_DATE_BOX_LOCATOR);
                this.WaitForElementToDissapear(AMENDS_BOX_LOCATOR);
                this.WaitForElementToDissapear(AMENDED_BY_BOX_LOCATOR);
                this.WaitForElementToDissapear(AMENDED_BY_VERSION_BOX_LOCATOR);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool IsPaymentOptionsUnfoldArrowVisible()
        {
           return this.IsElementVisible(PAYMENT_OPTIONS_UNFOLD_ARROW_LOCATOR);
        }

        public bool IsPaymentOptionsSectionVisible()
        {
            try
            {
                this.WaitForElementToBeVisible(CREDITOR_ACCOUNT_LABEL_LOCATOR);
                this.WaitForElementToBeVisible(CHECK_DESCRIPTION_LABEL_LOCATOR);
                this.WaitForElementToBeVisible(CLAIMS_OPTION_LABEL_LOCATOR);
                this.WaitForElementToBeVisible(DATE_FILED_DATE_BOX_LOCATOR);
                this.WaitForElementToBeVisible(BAR_DATE_DATE_BOX_LOCATOR);
                this.WaitForElementToBeVisible(AMENDS_BOX_LOCATOR);
                this.WaitForElementToBeVisible(AMENDED_BY_BOX_LOCATOR);
                this.WaitForElementToBeVisible(AMENDED_BY_VERSION_BOX_LOCATOR);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public void ScrollToClaimOptionsSection()
        {
            this.MoveToViewElement(this.WaitForElementToBeVisible(NOTES_TITLE_LOCATOR));
            this.MoveToViewElement(this.WaitForElementToBeVisible(CLAIMS_OPTION_LABEL_LOCATOR));
        }

        public bool IsPaymentOptionsFoldArrowVisible()
        {
            return this.IsElementVisible(PAYMENT_OPTIONS_FOLD_ARROW_LOCATOR);
        }

        public void ClickNotesTitleBar()
        {
            IWebElement lessOptionsBar = this.WaitForElementToBeVisible(LESS_OPTIONS_LINK_LOCATOR);
            this.MoveToViewElement(lessOptionsBar);            
            this.WaitForElementToBeVisible(NOTES_TITLE_LOCATOR).Click();
        }

        public bool IsNotesSectionHidden()
        {
            try
            {
                this.WaitForElementToDissapear(REGISTER_NOTES_LABEL_LOCATOR);
                this.WaitForElementToDissapear(REGISTER_NOTES_VALUE_LOCATOR);
                this.WaitForElementToDissapear(INTERNAL_NOTES_LABEL_LOCATOR);
                this.WaitForElementToDissapear(INTERNAL_NOTES_VALUE_LOCATOR);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool IsNotesUnfoldArrowVisible()
        {
            return this.IsElementVisible(NOTES_UNFOLD_ARROW_LOCATOR);
        }

        public bool IsNotesSectionVisible()
        {
            try
            {
                this.WaitForElementToBeVisible(REGISTER_NOTES_LABEL_LOCATOR);
                this.WaitForElementToBeVisible(REGISTER_NOTES_VALUE_LOCATOR);
                this.WaitForElementToBeVisible(INTERNAL_NOTES_LABEL_LOCATOR);
                this.WaitForElementToBeVisible(INTERNAL_NOTES_VALUE_LOCATOR);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool IsNotesFoldArrowVisible()
        {
            return this.IsElementVisible(NOTES_FOLD_ARROW_LOCATOR);
        }


        private List<string> GetDropdownOptionsList(By by)
        {
            IReadOnlyCollection<IWebElement> options = this.WaitForElementsToBeVisible(by);
            List<string> retOptions = new List<string>();
            foreach (IWebElement option in options)
            {
                retOptions.Add(option.Text.TrimStart(' ').Replace("\r\n", "").TrimEnd(' '));
            }
            return retOptions;
        }

        public void ClickSaveButton()
        {
            try
            {
                this.WaitForElementToBeClickeable(SAVE_BUTTON_LOCATOR).Click();
            }
            catch (Exception)
            {
                //this.MoveToViewElement(this.WaitForElementToBeVisible(CLAIMS_LIST_SECTION_TITLE_LOCATOR));
                this.clickNotVisualizedElement(this.WaitForElementToBeVisible(SAVE_BUTTON_LOCATOR));
            }
            this.WaitForBlockOverlayToDissapear();
        }

        public void ClickSaveAndAddAnotherButton()
        {
            try
            {
                this.WaitForElementToBeClickeable(SAVE_AND_ADD_ANOTHER_BUTTON_LOCATOR).Click();
            }
            catch (Exception)
            {
                this.MoveToViewElement(this.WaitForElementToBeVisible(claimsListSectionTitleLocator));
                this.WaitForElementToBeClickeable(SAVE_AND_ADD_ANOTHER_BUTTON_LOCATOR).Click();                
            }
            this.WaitForBlockOverlayToDissapear();
        }

        public void ClickCancelButton()
        {
            try
            {
                this.WaitForElementToBeClickeable(CANCEL_BUTTON_LOCATOR).Click();
            }
            catch (Exception)
            {                
               this.clickNotVisualizedElement(this.WaitForElementToBeClickeable(CANCEL_BUTTON_LOCATOR));                
            }            
            this.WaitForBlockOverlayToDissapear();
        }


        //Focus
        


        private By GetFieldLocator(string field) { 
            switch (field)
            {                
                case "Serial #":
                    return CLAIM_NUMBER_LOCATOR;

                case "Name":
                    return NAME_VALUE_INPUT_LOCATOR;

                case "Status":
                    return STATUS_DROPDOWN_SELECT_LOCATOR;

                case "Objection Code":
                    return OBJECTION_CODE_DROPDOWN_SELECT_LOCATOR;

                case "Category":
                    return CATEGORY_DROPDOWN_SELECT_LOCATOR;

                case "Code":
                    return CODE_VALUE_INPUT_LOCATOR;

                case "Subcode":
                    return SUBCODE_VALUE_INPUT_LOCATOR;

                case "Pay Sequence":
                    return PAY_SEQUENCE_VALUE_LOCATOR;

                case "Scheduled Amount":
                    return SCHEDULED_AMOUNT_VALUE_LOCATOR;

                case "Claimed Amount":
                    return CLAIMED_AMOUNT_VALUE_LOCATOR;

                case "Allowed Amount":
                    return ALLOWED_AMOUNT_VALUE_LOCATOR;

                case "Reserved Amount":
                    return RESERVED_AMOUNT_VALUE_LOCATOR;

                case "More Options":
                    return MORE_OPTIONS_LINK_LOCATOR;

                case "Payment Options Bar":
                    return PAYMENT_OPTIONS_SUBTITLE_LOCATOR;               

                case "Creditor Acc Number":
                    return LESS_OPTIONS_LINK_LOCATOR;

                case "Check Description":
                    return CHECK_DESCRIPTION_VALUE_LOCATOR;

                case "Date Filed":
                    return DATE_FILED_VALUE_LOCATOR;

                case "Bar Date":
                    return BAR_DATE_VALUE_LOCATOR;

                case "Amends":
                    return AMENDS_VALUE_LOCATOR;

                case "Amends Version":
                    return AMENDS_VERSION_VALUE_LOCATOR;

                case "Amended By":
                    return AMENDED_BY_VALUE_LOCATOR;

                case "Amended By Version":
                    return AMENDED_BY_VERSION_VALUE_LOCATOR;

                case "Notes Bar":
                    return NOTES_TITLE_LOCATOR;

                case "Register Note":
                    return REGISTER_NOTES_VALUE_LOCATOR;

                case "Internal Note":
                    return INTERNAL_NOTES_VALUE_LOCATOR;

                case "Less Options":
                    return LESS_OPTIONS_LINK_LOCATOR;

                default:
                    throw new NotImplementedException();

            }
        }

        public bool IsFocusOnButton(string button)
        {
            switch (button)
            {
                case "Save":
                    return this.IsFocusOnElement(this.WaitForElementToBeVisible(SAVE_BUTTON_LOCATOR));

                case "Save And Add Another":
                    return this.IsFocusOnElement(this.WaitForElementToBeVisible(SAVE_AND_ADD_ANOTHER_BUTTON_LOCATOR));

                case "Cancel":
                    return this.IsFocusOnElement(this.WaitForElementToBeVisible(CANCEL_BUTTON_LOCATOR));

                default:
                    throw new NotImplementedException();
            }
        }

        public void ClickOnField(string field)
        {
            this.MoveToViewElement(this.WaitForElementToBeVisible(SAVE_BUTTON_LOCATOR));
            this.WaitForElementToBeVisible(this.GetFieldLocator(field)).Click();
        }

        public bool IsFocusOnField(string field)
        {
            return this.IsFocusOnElement(this.WaitForElementToBeVisible(this.GetFieldLocator(field)));
        }

        public string GetFieldPlaceholder(string field)
        {
            return this.WaitForElementToBeVisible(this.GetFieldLocator(field)).GetAttribute("placeholder");
        }

        public string GetFieldValue(string field)
        {
            return this.WaitForElementToBeVisible(this.GetFieldLocator(field)).GetAttribute("value");
        }

        public void SetFieldValue(string field, string value)
        {             
            IWebElement fieldWE = this.WaitForElementToBeVisible(this.GetFieldLocator(field));
            fieldWE.Clear();
            for (int i = 0; i < value.Length; i++)
            {
                fieldWE.SendKeys("" + value[i]);
            }
            //this.Pause(1);
            fieldWE.SendKeys(Keys.Tab);
        }            

        public void DeleteFirstFourDigitsFromField(string field, string key)
        {
            IWebElement fieldWe = this.WaitForElementToBeVisible(this.GetFieldLocator(field));
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

        public void DeleteAllDigitsFromField(string field, string key)
        {
            IWebElement fieldWe = this.WaitForElementToBeVisible(this.GetFieldLocator(field));
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
        
    }
}