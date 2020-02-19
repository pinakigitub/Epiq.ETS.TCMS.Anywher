using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epiq.ETS.TCMS.Anywhere.Testing.E2ETest.Test_Framework.Pages.Common
{
    public class MyTextAreaField : PageObject
    {
        private const string FIELD_LOCATOR_BY_ID_TEMPLATE = "//my-textarea[@id='{0}']";
        private const string FIELD_INPUT_LOCATOR_BY_ID_TEMPLATE = "//textarea [@id='{0}']";
        private string fieldId;

        public MyTextAreaField(IWebDriver driver, string id) : base(driver, null)
        {
            fieldId = id;
        }
        public string Label
        {
            get
            {
                IWebElement element = this.WaitForElementToBeVisible(By.XPath(string.Format(FIELD_LOCATOR_BY_ID_TEMPLATE, fieldId)));
                return element.GetAttribute("label");
            }
        }

        public string Value
        {
            get
            {
                IWebElement element = this.WaitForElementToBeVisible(By.XPath(string.Format(FIELD_INPUT_LOCATOR_BY_ID_TEMPLATE, fieldId)));
                string ret = element.GetAttribute("value");
                if (ret != null)
                    return ret;
                else
                    return "";
            }
            set
            {
                IWebElement element = this.WaitForElementToBeVisible(By.XPath(string.Format(FIELD_INPUT_LOCATOR_BY_ID_TEMPLATE, fieldId)));
                this.ClearAndType(element, value);
            }
        }

    }
}
