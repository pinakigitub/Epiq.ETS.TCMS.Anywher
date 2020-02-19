using Epiq.ETS.TCMS.Anywhere.Testing.E2ETest.TestFramework.Pages.Cases.Detail;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epiq.ETS.TCMS.Anywhere.Testing.E2ETest.Test_Framework.Pages.Cases.Detail
{
    public class AssetForm:AssetsDetailTab
    {
        public bool IsEdit
        {
            get;
            internal set;
        }       


        //BASIC FORM SECTION
        private By SAVE_BUTTON_LOCATOR = By.Id("saveNewAsset");
        private By SAVE_AND_ADD_ANOTHER_BUTTON_LOCATOR = By.Id("saveAndAddAnotherAsset");
        private By CANCEL_BUTTON_LOCATOR = By.Id("cancelNewAsset");

        //MORE OPTIONS SECTION
        private By MORE_OPTIONS_LINK_ANCHOR_LOCATOR = By.Id("moreOptions-expandableAnchorTop");        
        private By MORE_OPTIONS_LINK_LOCATOR = By.Id("moreOptions-expandableTitle");
        private By LESS_OPTIONS_LINK_ANCHOR_LOCATOR = By.Id("moreOptions-expandableAnchorBottom");
        private By LESS_OPTIONS_LINK_LOCATOR = By.Id("moreOptions-expandableTitleBottom");

        private By FORM_ONE_NOTE_BAR_ANCHOR_LOCATOR = By.Id("formOneNote-expandableAnchorTop");
        private By FORM_ONE_NOTE_BAR_LOCATOR = By.Id("formOneNote-expandableTitle");
        private By FORM_ONE_NOTE_LABEL_LOCATOR = By.Id("formOneNoteTitle");
        private By FORM_ONE_NOTE_VALUE_LOCATOR = By.Id("formOneNoteTextArea");

        private By RESERVED_BAR_ANCHOR_LOCATOR = By.Id("reservedStatus-expandableAnchorTop");
        private By RESERVED_BAR_LOCATOR = By.Id("reservedStatus-expandableTitle");
        private By RESERVED_TEXT_VALUE_LOCATOR = By.Id("reservedStatusNote");
        private By DESCRIPTION_CONTAINER_INPUT_LOCATOR = By.Id("select2-assetDescriptionValue-container");
        private By DESCRIPTION_VALUE_INPUT_LOCATOR  = By.CssSelector(".select2-search__field");
        private By CODE_VALUE_INPUT_LOCATOR = By.CssSelector("input.select2-search__field");
        private By PETITION_VALUE_INPUT_LOCATOR = By.CssSelector("input#assetPetition");
        private By TRUSTEE_VALUE_INPUT_LOCATOR = By.CssSelector("input#assetTrustee");
        private By LIENS_INPUT_LOCATOR = By.CssSelector("input#assetLiens");
        private By EST_COST_OF_SALES_INPUT_LOCATOR = By.CssSelector("input#assetEstimatedCostValue");
        private By EXEMPTIONS_INPUT_LOCATOR = By.CssSelector("input#assetExemption");
        private By OPTIONS_AND_DATES_BAR_LOCATOR = By.Id("optionsAndDatesSection-expandableTitle");
        private By OPTIONS_AND_DATES_BAR_ANCHOR_LOCATOR = By.Id("optionsAndDatesSection-expandableAnchorTop");        
        private By FULLY_ADMIN_DATE_INPUT_LOCATOR = By.CssSelector("input#fullyAdministeredDatebox");
        private By FIRST_UST_REPORT_DATE_INPUT_LOCATOR = By.CssSelector("input#firstUSTReportDatebox");

        private By DEBTOR_OWNED_INPUT_LOCATOR = By.CssSelector("input#debtorOwnedValueTextbox");
        private By ABANDONED_LABEL_LOCATOR = By.Id("abandonedStatus-Label");
        private By ASSETS_LIST_CARD_LOCATOR = By.XPath("//*[contains(@title,'Assets')]");
        private By ASSET_PETITION_VALUE_PREVIEW_LOCATOR = By.Id("assetPetitionValue");
        private By NET_VALUE_REDUCTIONS_TITLE_LOCATOR = By.Id("assetNetValueReductionsLabel");
        private By ASSETS_LIST_SECTION_TITLE_LOCATOR = By.CssSelector("span#Title");

        public AssetForm(IWebDriver driver, bool isEdit):base(driver)
        {
            this.IsEdit = isEdit;
        }

        public bool IsMoreOptionsVisible()
        {
            return this.IsElementVisible(FORM_ONE_NOTE_LABEL_LOCATOR);
        }

        public void ClickMoreOptionsLink()
        {
            if (this.IsEdit)
            {
                this.WaitForElementToBePresent(SAVE_BUTTON_LOCATOR);                
                this.MoveToViewElement(this.WaitForElementToBeVisible(NET_VALUE_REDUCTIONS_TITLE_LOCATOR));
                this.clickNotVisualizedElement(this.WaitForElementToBePresent(MORE_OPTIONS_LINK_LOCATOR));
            }
            else {
                this.MoveToViewElement(this.WaitForElementToBeVisible(ASSETS_LIST_SECTION_TITLE_LOCATOR));
                this.MoveToViewElement(this.WaitForElementToBeVisible(ASSET_PETITION_VALUE_PREVIEW_LOCATOR));                
                this.clickNotVisualizedElement(this.WaitForElementToBeVisible(MORE_OPTIONS_LINK_LOCATOR));
            }
            //this.WaitForBlockOverlayToDissapear();
        }
              

        public bool IsFocusOnField(string field)
        {
            return this.IsFocusOnElement(this.WaitForElementToBeVisible(this.GetFieldLocator(field)));
        }

        public void DeleteFirstFourDigitsFromField(string field, string key)
        {
            if (field == "Debtor Owned Value")
                this.ScrollDownToDebtorOwnedValueSection();

            IWebElement fieldWe = this.WaitForElementToBeVisible(this.GetFieldLocator(field));
            //select
            this.SelectFirstNDigits(4, fieldWe);

            //delete
            if (key == "delete")
                fieldWe.SendKeys(Keys.Delete);
            else if(key == "backspace")
                fieldWe.SendKeys(Keys.Backspace);

            //loose focus
            fieldWe.SendKeys(Keys.Tab);
        }

        private void ScrollDownToDebtorOwnedValueSection()
        {
            this.MoveToViewElement(this.WaitForElementToBeVisible(SAVE_BUTTON_LOCATOR));
            this.MoveToViewElement(this.WaitForElementToBeVisible(OPTIONS_AND_DATES_BAR_LOCATOR));
        }

        public void DeleteAllDigitsFromField(string field, string key) {

            if (field == "Debtor Owned Value")
                this.ScrollDownToDebtorOwnedValueSection();

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

        public string GetFieldValue(string field)
        {
            return this.WaitForElementToBeVisible(this.GetFieldLocator(field)).GetAttribute("value");
        }

        public string GetFieldPlaceholder(string field)
        {
            return this.WaitForElementToBeVisible(this.GetFieldLocator(field)).GetAttribute("placeholder");
        }

        public void SetFieldValue(string field, string value)
        {
            IWebElement fieldWE = this.WaitForElementToBeVisible(this.GetFieldLocator(field));
            if (field == "Exemptions")
            {
                this.MoveToViewElement(this.WaitForElementToBeVisible(MORE_OPTIONS_LINK_LOCATOR));
                this.MoveToViewElement(this.WaitForElementToBeVisible(NET_VALUE_REDUCTIONS_TITLE_LOCATOR));
            }

            fieldWE.Clear();
            for (int i = 0; i < value.Length; i++)
            {
                fieldWE.SendKeys("" + value[i]);
            }
            this.Pause(1);
            fieldWE.SendKeys(Keys.Tab);
        }

        public void ClickOnField(string field)
        {
            if ((field == "Liens") || (field == "Est. Cost of Sale") || (field == "Exemptions"))
            {
                this.MoveToViewElement(this.WaitForElementToBeVisible(SAVE_BUTTON_LOCATOR));
                this.MoveToViewElement(this.WaitForElementToBeVisible(NET_VALUE_REDUCTIONS_TITLE_LOCATOR));
            }
            else if (field == "Debtor Owned Value") { 
                this.MoveToViewElement(this.WaitForElementToBeVisible(SAVE_BUTTON_LOCATOR));
                this.MoveToViewElement(this.WaitForElementToBeVisible(ABANDONED_LABEL_LOCATOR));
            }
            if (field == "Description")
            {
                IWebElement description = this.WaitForElementToBeVisible(DESCRIPTION_CONTAINER_INPUT_LOCATOR);
                this.MoveToViewElement(description);
                description.Click();
            }
            else
            {
                IWebElement fieldWE = this.WaitForElementToBeVisible(this.GetFieldLocator(field));
                this.MoveToViewElement(fieldWE);
                fieldWE.Click();
            }
        }

        private By GetFieldLocator(string field)
        {
            switch (field)
            {
                case "Description":
                    return DESCRIPTION_VALUE_INPUT_LOCATOR;

                case "Code":
                    return CODE_VALUE_INPUT_LOCATOR;

                case "Petition Value":
                    return PETITION_VALUE_INPUT_LOCATOR;

                case "Trustee Value":
                    return TRUSTEE_VALUE_INPUT_LOCATOR;

                case "Liens":
                    return LIENS_INPUT_LOCATOR;

                case "Est. Cost of Sale":
                    return EST_COST_OF_SALES_INPUT_LOCATOR;

                case "Exemptions":
                    return EXEMPTIONS_INPUT_LOCATOR;

                case "More Options":
                    return MORE_OPTIONS_LINK_ANCHOR_LOCATOR;

                case "Form 1 Note Bar":
                    return FORM_ONE_NOTE_BAR_ANCHOR_LOCATOR;

                case "Form 1 Note":
                    return FORM_ONE_NOTE_VALUE_LOCATOR;

                case "Options And Dates Bar":
                    return OPTIONS_AND_DATES_BAR_ANCHOR_LOCATOR;

                case "FA Date":
                    return FULLY_ADMIN_DATE_INPUT_LOCATOR;

                case "1st UST Report Date":
                    return FIRST_UST_REPORT_DATE_INPUT_LOCATOR;

                case "Debtor Owned Value":
                    return DEBTOR_OWNED_INPUT_LOCATOR;

                case "Reserved Bar":
                    return RESERVED_BAR_ANCHOR_LOCATOR;

                case "Reserved Text Box":
                    return RESERVED_TEXT_VALUE_LOCATOR;

                case "Less Options":
                    return LESS_OPTIONS_LINK_ANCHOR_LOCATOR;

                default:
                    throw new NotImplementedException();
            }
        }
        
    }
}
