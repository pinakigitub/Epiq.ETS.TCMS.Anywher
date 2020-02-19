using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epiq.ETS.TCMS.Anywhere.Testing.E2ETest.Test_Framework.Pages.Common
{
    public class CircleIcon : PageObject
    {

        private IWebElement icon;
        private string elementId;

        public CircleIcon(IWebDriver driver, string elemId) :base(driver, null) {
            this.elementId = elemId;
            icon = this.WaitForElementToBeVisible(By.Id(elementId));
        }        

        public bool DisplaysCorrectly()
        {
            try
            {                
                icon.FindElement(By.ClassName("circle"));
                return true;
            }
            catch (Exception)
            {

                return false;
            }

        }

        public string Description
        {
            get
            {
                return this.WaitForElementToBeVisible(By.Id(elementId+"-description")).Text;
            }
        }

        /**
         * Gets the value of the Claims Icon
         */
        public string Value
        {
            get
            {
                return this.WaitForElementToBeVisible(By.Id(elementId + "-value")).Text;
            }
        }
    }
}
