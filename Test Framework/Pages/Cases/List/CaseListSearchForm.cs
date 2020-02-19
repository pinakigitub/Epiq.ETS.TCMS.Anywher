using Epiq.ETS.TCMS.Anywhere.Testing.E2ETest.Test_Framework.Core;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epiq.ETS.TCMS.Anywhere.Testing.E2ETest.Test_Framework.Pages.Cases.List
{
    public class CaseListSearchForm:PageObject
    {
        //New LOCATORS
        //Pick-List filters locators
        private By TYPE_PICKILST_LOCATOR = By.Id("typesFilter");
        private By STATUS_PICKILST_LOCATOR = By.Id("statusFilter");

        //Search button
        private By SEARCH_BUTTON_LOCATOR = By.Id("searchButton");

        //Text Filters locators
        private By CASE_NUMBER_SEARCH_FIELD_LABEL_LOCATOR = By.XPath("//input[@id='caseNumber']/..");
        private By CASE_NUMBER_SEARCH_FIELD_INPUT_LOCATOR = By.Id("caseNumber");
        private By CASE_NAME_SEARCH_FIELD_LABEL_LOCATOR = By.XPath("//input[@id='caseName']/..");
        private By CASE_NAME_SEARCH_FIELD_INPUT_LOCATOR = By.Id("caseName");
        private By RESET_BUTTON_LOCATOR = By.Id("resetButton");

        public CaseListSearchForm(IWebDriver driver) :base(driver, null) { }

        private PickListField TypeFilter {
            get { return new PickListField(driver, WaitForElementToBeVisible(TYPE_PICKILST_LOCATOR)); }
        }

        private PickListField StatusFilter
        {
            get { return new PickListField(driver, WaitForElementToBeVisible(STATUS_PICKILST_LOCATOR)); }
        }
               

        /**
        * Click on Search button to perform the search
        */
        public void SubmitSearch()
        {
            this.WaitForElementToBeClickeable(SEARCH_BUTTON_LOCATOR).Click();
        }

        /**
         * Gets the LABEL of the given Search Field
         */
        /*
        TODO 
            On Multiple Search : use TextInputField and remove CASE clause 
            for all methods on SearchForm page object.

         Handle on Steps as:
            searchForm.StatusField.GetPickListLabel()
            searchForm.CaseNumberField.GetLabel()

        */
        public string GetSearchFieldLabel(string field)
        {
            switch (field)
            {
                case CaseListFields.STATUS:
                    return StatusFilter.GetLabel();

                case CaseListFields.TYPE:
                    return TypeFilter.GetLabel();

                case CaseListFields.CASE_NUMBER:
                    return this.WaitForElementToBeVisible(CASE_NUMBER_SEARCH_FIELD_LABEL_LOCATOR).Text;

                case CaseListFields.CASE_NAME:
                    return this.WaitForElementToBeVisible(CASE_NAME_SEARCH_FIELD_LABEL_LOCATOR).Text;

                default:
                    throw new NotImplementedException();
            }
        }

        /**
         * Gets a list of the available options on the given pick-list Search field 
         * The list is empty if there are not options
         */
        public List<string> GetSearchFieldOptions(string field)
        {           
            switch (field)
            {
                case CaseListFields.STATUS:
                    return this.StatusFilter.GetOptions();

                case CaseListFields.TYPE:
                    return this.TypeFilter.GetOptions();
                    
                default:
                    throw new NotImplementedException();
            }
        }

        /**
        * Gets the current VALUE of the given Search Field
        */
        public string GetSearchFieldValue(string field)
        {
            switch (field)
            {
                case CaseListFields.STATUS:
                    return this.StatusFilter.GetValue();

                case CaseListFields.TYPE:
                    return this.TypeFilter.GetValue();

                case CaseListFields.CASE_NUMBER:                    
                        return this.WaitForElementToBeVisible(CASE_NUMBER_SEARCH_FIELD_INPUT_LOCATOR).GetAttribute("value");
                    
                case CaseListFields.CASE_NAME:
                    return this.WaitForElementToBeVisible(CASE_NAME_SEARCH_FIELD_INPUT_LOCATOR).GetAttribute("value");

                default:
                    throw new NotImplementedException();
            }
        }

        /**
         * Gets the currently SELECTED OPTIONS for the given search field
         */
        public List<string> GetSearchFieldSelectedOptions(string field)
        {
            switch (field)
            {
                case CaseListFields.STATUS:
                    return this.StatusFilter.GetAllSelectedOptions();

                case CaseListFields.TYPE:
                    return this.TypeFilter.GetAllSelectedOptions();

                default:
                    throw new NotImplementedException();
            }
        }

        

        /**
         * Selects the given options from the given pick-list search field
         */
        public void SelectOptionsFromSearchField(string field, List<string> options)
        {
            switch (field)
            {
                case CaseListFields.STATUS:
                    {
                        //Clean all selections
                        this.StatusFilter.UnselectAll();
                        

                        // Select all options from the pick list
                        foreach (string option in options)
                        {
                            this.StatusFilter.SelectByVisibleText(option);                           
                        }                        
                        break;
                    }

                case CaseListFields.TYPE:
                    {
                        //Clean all selections
                        this.TypeFilter.UnselectAll();


                        // Select all options from the pick list
                        foreach (string option in options)
                        {
                            this.TypeFilter.SelectByVisibleText(option);
                        }
                        break;
                    }

                default:
                    throw new NotImplementedException();

            }
        }

        /**
         * Unselects the given options from the given pick-list search field
         */
        public void UnselectOptionsFromSearchField(string field, List<string> options)
        {
            PickListField picklist;

            //Get the correct picklist
            switch (field)
            {
                case CaseListFields.STATUS:
                    {
                        picklist = this.StatusFilter;                        
                        break;
                    }
                case CaseListFields.TYPE:
                    {
                        picklist = this.TypeFilter;                        
                        break;
                    }

                default:
                    throw new NotImplementedException();

            }

            // For all options on the list: if selected, then unselect it (otherwise, do nothing)
            foreach (string option in options)
            {
                picklist.UnselectByVisibleText(option);
            }
        }


        /**
         * Says if the "All" option of a given pick-list field is unselected
         */
        /*
        TODO direct refator for multiple search: 
            1. make status and type filter getter public
            2. move return to step
            3. remove this method
            
        Note: complexity comes from '(.*)' selector for fields on specflow steps
        */
        public bool AllOptionUnselectedForField(string field)
        {
            PickListField picklist;
            
            switch (field)
            {
                case CaseListFields.STATUS:
                { 
                    picklist = this.StatusFilter;
                    break;
                }
                case CaseListFields.TYPE:
                {
                    picklist = this.StatusFilter;
                    break;
                }

                default:
                    throw new NotImplementedException();
            }

            return picklist.IsAllOptionUnselected();

        }

        public void Reset()
        {
            this.WaitForElementToBeClickeable(RESET_BUTTON_LOCATOR).Click();
        }

        /**
         * Types the given value on the Case Number search field
         */
        public void TypeInCaseNumberValue(string caseNumber)
        {
            this.ClearAndType(this.WaitForElementToBeVisible(CASE_NUMBER_SEARCH_FIELD_INPUT_LOCATOR), caseNumber);
        }

        /**
         * Types the given value on the Case Name search field
         */
        public void TypeInCaseNameValue(string caseName)
        {
            this.ClearAndType(this.WaitForElementToBeVisible(CASE_NAME_SEARCH_FIELD_INPUT_LOCATOR), caseName);
        }

    }
}
