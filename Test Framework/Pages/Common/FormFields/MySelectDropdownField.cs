using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epiq.ETS.TCMS.Anywhere.Testing.E2ETest.Test_Framework.Pages.Common
{
    public class MySelectDropdownField : PageObject
    {
        private const string FIELD_LABEL_LOCATOR_BY_ID_TEMPLATE = "//my-dropdown[@id='{0}']";
        private const string FIELD_VALUE_LOCATOR_BY_ID_TEMPLATE = "//select[@id='{0}']";
        private By FIELD_LABEL_LOCATOR_BY_ID;
        private By FIELD_VALUE_LOCATOR_BY_ID;

        public MySelectDropdownField(IWebDriver driver, string id) : base(driver, null)
        {
            FIELD_LABEL_LOCATOR_BY_ID = By.XPath(string.Format(FIELD_LABEL_LOCATOR_BY_ID_TEMPLATE, id));
            FIELD_VALUE_LOCATOR_BY_ID = By.XPath(string.Format(FIELD_VALUE_LOCATOR_BY_ID_TEMPLATE, id));
        }

        public string Label
        {
            get
            {
                return this.WaitForElementToBeVisible(FIELD_LABEL_LOCATOR_BY_ID).GetAttribute("label");
            }
        }

        public string SelectedOption
        {
            get
            {
                string[] stringSeparators = new string[] { "\r\n" };
                SelectElement select = new SelectElement(this.WaitForElementToBeVisible(FIELD_VALUE_LOCATOR_BY_ID));
                return select.SelectedOption.Text.Split(stringSeparators, StringSplitOptions.None)[0].TrimStart(' ').TrimEnd(' ');
            }
            set
            {
                SelectElement select = new SelectElement(this.WaitForElementToBeVisible(FIELD_VALUE_LOCATOR_BY_ID));
                select.SelectByText(value);
            }
        }

    }
}
