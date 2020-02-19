using Epiq.ETS.TCMS.Anywhere.Testing.E2ETest.Test_Framework.Core;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;

namespace Epiq.ETS.TCMS.Anywhere.Testing.E2ETest.Test_Framework.Pages.Cases.List
{
    public class PickListField : PageObject
    {
        private IWebElement picklistWebElement;
        private string picklistId = "";

        // Locator templates based on the pick-list id

        //path to the "li" element of an option (template)
        private string OPTION_LOCATOR_TEMPLATE = "//pick-list[@id='{0}']//ul/li";

        //path to the "li" element of selected option (template)
        private string OPTION_SELECTED_LOCATOR_TEMPLATE = "//pick-list[@id='{0}']//ul/li/input[contains(@class,'selected')]/..";

        //path to the "li" element by index (template)
        private string OPTION_BY_INDEX_LOCATOR_TEMPLATE = "//pick-list[@id='{0}']//ul/li[{1}]";

        //path to the "li" element by visible text (template)
        private string OPTION_BY_VISIBLE_TEXT_LOCATOR_TEMPLATE = "//pick-list[@id='{0}']//ul/li/label[contains(text(),'{1}')]/..";   
        
        //path to the "li" element by its value (template)
        private string OPTION_BY_VALUE_LOCATOR_TEMPLATE = "//pick-list[@id='{0}']//ul/li/input[@value='{1}']/..";
        
        //selected value locator template
        private string DROPDOWN_SELECTED_VALUE_LOCATOR_TEMPLATE = "//pick-list[@id='{0}']//div[contains(@class,'dropdown-selection')]/span";


        private string ALL_OPTION_UNSELECTED_LOCATOR_TEMPLATE = 
            "//pick-list[@id='{0}']//ul/li/label[contains(text(),'All')]/../input[contains(@class, 'picklist-all-option')]";



        // Locators
        private By DROP_DOWN_ARROW = By.CssSelector("i.fa.fa-caret-down");
        private By OPTION_ITEM_LOCATOR;
        private By SELECTED_OPTION_LOCATOR;
        private By DROPDOWN_SELECTED_VALUE_LOCATOR;
        private By ALL_OPTION_UNSELECTED_LOCATOR;


        public PickListField(IWebDriver driver, IWebElement webElement) : base(driver, null)
        {
            picklistWebElement = webElement;

            //Get the picklist Id and set locators and templates
            picklistId = this.picklistWebElement.GetAttribute("id");

            OPTION_ITEM_LOCATOR = By.XPath(String.Format(OPTION_LOCATOR_TEMPLATE, picklistId));
            SELECTED_OPTION_LOCATOR = By.XPath(String.Format(OPTION_SELECTED_LOCATOR_TEMPLATE, picklistId));
            DROPDOWN_SELECTED_VALUE_LOCATOR = By.XPath(String.Format(DROPDOWN_SELECTED_VALUE_LOCATOR_TEMPLATE, picklistId));
            ALL_OPTION_UNSELECTED_LOCATOR = By.XPath(String.Format(ALL_OPTION_UNSELECTED_LOCATOR_TEMPLATE, picklistId));
        }

        /**
         * Gets the picklist field label
         */
        public string GetLabel() {
            return picklistWebElement.FindElement(By.TagName("label")).Text;
        }

        /**
         * Gets the value on the box next to the dropdown arrow
         * that idicates what theuser has selected (All, Value, 2 Selected, 3 Selected, etcetera)
         */
        public string GetValue()
        {
            return picklistWebElement.FindElement(DROPDOWN_SELECTED_VALUE_LOCATOR).Text;
        }


        /**
         * Gets the labels of the available options in the dropdown
         */
        public List<string> GetOptions()
        {
            //get the options 
            IReadOnlyCollection<IWebElement> optionsWE = picklistWebElement.FindElements(OPTION_ITEM_LOCATOR);
            
            List<string> options = new List<string>();
            foreach (var opt in optionsWE)
            {
                options.Add(opt.FindElement(By.TagName("label")).GetAttribute("innerHTML").TrimStart());
            }

            return options;
        }

        /**
         * Gets the first selected option on the dropdown
         */
        public string GetFirstSelectedOption()
        {
            try
            {
                return picklistWebElement.FindElement(SELECTED_OPTION_LOCATOR).FindElement(By.TagName("label")).GetAttribute("innerHTML").TrimStart();
            }
            catch (MissingElementException)
            {
                return "";
            }
        }


        /**
         * Gets all selected options on the dropdown
         */
        public List<string> GetAllSelectedOptions()
        {
            IReadOnlyCollection<IWebElement> selectedOptsWEs = picklistWebElement.FindElements(SELECTED_OPTION_LOCATOR);

            List<string> selectedOptions = new List<string>();  
            foreach (var opt in selectedOptsWEs)
            {
                selectedOptions.Add(opt.FindElement(By.TagName("label")).GetAttribute("innerHTML").TrimStart());
            }

            return  selectedOptions;
        }

        /**
         * Says if an option on the picklist is selected
         */
        public bool IsSelected(string optionVisibleText)
        {            
            return IsSelected(picklistWebElement.FindElement(By.XPath(String.Format(OPTION_BY_VISIBLE_TEXT_LOCATOR_TEMPLATE, picklistId, optionVisibleText))));
        }

        /**
         * Selects all the options on the pick-list (or the 'All' option if exists)
         */
        public void SelectAll()
        {
            this.ToggleAll(true);           
        }

        /**
         * Unselects all the options on the pick-list (or the 'All' option if exists)
         */
        public void UnselectAll()
        {
            this.ToggleAll(false);
        }

        /**
         * Selects or unselects all options, depending on the value of "select". 
         * True means select all, false means unselect all.
         */
        private void ToggleAll(bool select)
        {   
            //Open the drop-down
            this.ToggleDropdown();

            //Select/unselect one by one (if not already on the desired state)
            IReadOnlyCollection<IWebElement> options = picklistWebElement.FindElements(OPTION_ITEM_LOCATOR);
            foreach (IWebElement item in options)
            {
                if (IsSelected(item) != select)
                {
                    item.Click();
                }
            }

            //Close the drop-down
            this.ToggleDropdown();
        }

        /**
         * Selects the option on the given position in the pick-list
         */
        public void SelectByIndex(int index)
        {
            this.ToggleByIndex(true, index);
        }

        /**
         * Unselects the option on the given position in the pick-list
         */
        public void UnselectByIndex(int index)
        {
            this.ToggleByIndex(false, index);
        }

        public bool IsAllOptionUnselected()
        {
            bool partiallySelected = false;

            try
            {
                this.WaitForElementToBePresent(ALL_OPTION_UNSELECTED_LOCATOR);
                partiallySelected = true;
            }
            catch (MissingElementException) {
                //do nothing, partiallySelected is already false
            }
           
            return partiallySelected;
        }

        /**
         * Selects or unselects the option on the given position, depending on the value of "select". 
         * True means select, false means unselect
         */
        private void ToggleByIndex(bool select, int index)
        {
            IWebElement option =  picklistWebElement.FindElement(By.XPath(String.Format(OPTION_BY_INDEX_LOCATOR_TEMPLATE, picklistId, index)));
            if (IsSelected(option) != select)
            {
                this.ToggleDropdown();
                option.Click();
                this.ToggleDropdown();
            }
        }

        /**
        * Selects the option with the given value in the pick-list
        */
        public void SelectByValue(string value) {
            this.ToggleByValue(true, value);
        }

        /**
        * Unselects the option wwith the given value in the pick-list
        */
        public void UnselectByValue(string value)
        {
            this.ToggleByValue(false, value);
        }

        /**
        * Selects or unselects the option with the given value, depending on the value of "select". 
        * True means select, false means unselect
        */
        private void ToggleByValue(bool select, string value)
        {
            //TODO test: not sure if 'value' is having something
            IWebElement option = picklistWebElement.FindElement(By.XPath(String.Format(OPTION_BY_VALUE_LOCATOR_TEMPLATE, picklistId, value)));
            if (IsSelected(option) != select)
            {
                this.ToggleDropdown();
                option.Click();
                this.ToggleDropdown();
            }
        }

        /**
        * Selects the option with the given text in the pick-list
        */
        public void SelectByVisibleText(string text) {
            this.ToggleByVisibleText(true, text);
        }

        /**
        * Unselects the option with the given text in the pick-list
        */
        public void UnselectByVisibleText(string text)
        {
            this.ToggleByVisibleText(false, text);
        }

        /**
        * Selects or unselects the option with the given Text, depending on the value of "select". 
        * True means select, false means unselect
        */
        private void ToggleByVisibleText(bool select, string text)
        {
            IWebElement option = picklistWebElement.FindElement(By.XPath(String.Format(OPTION_BY_VISIBLE_TEXT_LOCATOR_TEMPLATE, picklistId, text)));
            if (IsSelected(option) != select)
            {
                this.ToggleDropdown();
                option.Click();
                this.ToggleDropdown();
            }
        }

        private void ToggleDropdown()
        {
            picklistWebElement.FindElement(DROP_DOWN_ARROW).Click();
        }

        /**
         * Says if the given IWebElement is selected
         */
        private bool IsSelected(IWebElement option)
        {
            return option.FindElement(By.TagName("input")).GetAttribute("class").Contains("selected");
        }
    }
}