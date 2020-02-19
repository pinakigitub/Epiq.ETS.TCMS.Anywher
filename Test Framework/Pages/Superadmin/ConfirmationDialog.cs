using OpenQA.Selenium;
using System;

namespace Epiq.ETS.TCMS.Anywhere.Testing.E2ETest.Test_Framework.Pages.Superadmin
{
    public class ConfirmationDialog:PageObject
    {
        private By confirmationDialogPopupLocator = By.XPath("//*[@id='confirm-modal-superadmin' or @id='confirm-modal-superadmin-delete-document']");
        private By confirmationButtonYesLocator = By.XPath("//*[@id='confirm-modal-superadmin' or @id='confirm-modal-superadmin-delete-document']//*[contains(@class,'confirmButtons')]//*[contains(@class,'yes')]");
        private By confirmationButtonNoLocator = By.XPath("//*[@id='confirm-modal-superadmin' or @id='confirm-modal-superadmin-delete-document']//*[contains(@class,'confirmButtons')]//*[contains(@class,'no')]");

        public ConfirmationDialog(IWebDriver driver):base(driver, null)
        {

        }

        public bool IsVisibleConfirmationDialog
        {
            get
            {
                try
                {
                    this.WaitForElementToBeVisible(confirmationDialogPopupLocator);
                    return true;
                }
                catch (Exception)
                {
                    return false;
                }
            }
        }

        public string DialogMessage {
            get
            {
                return this.WaitForElementToBeVisible(confirmationDialogPopupLocator).Text.Split('\r')[0];
            }
        }

        public void ClickYesOnConfirmationDialog()
        {
            this.WaitForElementToBeVisible(confirmationButtonYesLocator).Click();
        }

        public void ClicknOnConfirmationDialog()
        {
            this.WaitForElementToBeVisible(confirmationButtonNoLocator).Click();
        }
    }
}