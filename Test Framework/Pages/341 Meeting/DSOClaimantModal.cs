using Epiq.ETS.TCMS.Anywhere.Testing.E2ETest.Test_Framework.Pages.Common;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;

namespace Epiq.ETS.TCMS.Anywhere.Testing.E2ETest.Test_Framework.Pages.Meeting341
{
    public class DSOClaimantModal : UnityPageBase
    {
        private By MODAL_FORM_TITLE_LOCATOR = By.XPath("//*[@id='addClaimantInfoModal-ModalContainer']//*[contains(@class,'keyDateModalTitle')]");


        //Form ACTIONS
        private By SAVE_BUTTON_LOCATOR = By.XPath("//*[@id='addClaimantInfoModal-ModalContainer']//*[@id='addClaimantButton']");
        private By CANCEL_BUTTON_LOCATOR = By.XPath("//*[@id='addClaimantInfoModal-ModalContainer']//*[@id='cancelButton']");


        public DSOClaimantModal(IWebDriver driver) : base(driver, null)
        {

        }
    }
}