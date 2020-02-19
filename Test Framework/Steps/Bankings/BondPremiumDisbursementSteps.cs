using Epiq.ETS.TCMS.Anywhere.Testing.E2ETest.Test_Framework.Core;
using Epiq.ETS.TCMS.Anywhere.Testing.E2ETest.Test_Framework.Pages;
using Epiq.ETS.TCMS.Anywhere.Testing.E2ETest.Test_Framework.Pages.BankingCenter;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading;
using TechTalk.SpecFlow;

namespace Epiq.ETS.TCMS.Anywhere.Testing.E2ETest.Test_Framework.Steps.Bankings
{
    [Binding]
    public class BondPremiumDisbursementSteps : StepBase
    {
        BondPremiumDisbursement bondPremiumDisbursement = new BondPremiumDisbursement(driver);
        
        [When(@"the user clicks on the filter option button on Bond Page")]
        public void WhenTheUserClicksOnTheFilterOptionButtonOnBondPage()
        {  
            bondPremiumDisbursement.ClickOnFilter();
        }
        [When(@"User click on Filter on Bond Distribution page")]
        public void WhenUserClickOnFilterOnBondDistributionPage()
        {  
            bondPremiumDisbursement.ClickOnFilter();
        }
        [When(@"they should click on reset button on filter options pane")]
        public void WhenTheyShouldClickOnResetButtonOnFilterOptionsPane()
        {
            bondPremiumDisbursement.ClickOnResetButton();
        }
        [When(@"the user should click on close button on filter option pane")]
        public void WhenTheUserShouldClickOnCloseButtonOnFilterOptionPane()
        {
            bondPremiumDisbursement.ClickOnCloseButton();
        }
        [When(@"the user should able to verify the Pagination on the page")]
        public void WhenTheUserShouldAbleToVerifyThePaginationOnThePage()
        {
            // BondPremiumDisbursement.GetPageCount();
        }
        [When(@"the user clicks on the Add Bond Button")]
        public void WhenTheUserClicksOnTheAddBondButton()
        {
                bondPremiumDisbursement.ClickOnAddBond();
        }
        [When(@"the user clicks on cancel button")]
        public void WhenTheUserClicksOnCancelButton()
        {
            bondPremiumDisbursement.ClickOnCancelBtn();
        }
        [When(@"I select the Trustee from the Drop Down")]
        public void WhenISelectTheTrusteeFromTheDropDown()
        {
            
        }
        [Then(@"I click on Add Bond button")]
        public void ThenIClickOnAddBondButton()
        {
            
        }
        [When(@"the user clicks on edit Bond Premium button")]
        public void WhenTheUserClicksOnEditBondPremiumButton()
        {
            bondPremiumDisbursement.EditBondPremiumDisbursement();
        }
        [Then(@"Verify the Alerts message on the Table")]
        public void ThenVerifyTheAlertsMessageOnTheTable()
        {
            bondPremiumDisbursement.MouseHoverOnAlerts();
        }
        [Then(@"Verify for Calculate Button is displayed at bottom of the page")]
        public void ThenVerifyForCalculateButtonIsDisplayedAtBottomOfThePage()
        {
            bondPremiumDisbursement.CalculateButton();
        }
        [Then(@"Verify for Mandatory Columns to be Filled")]
        public void ThenVerifyForMandatoryColumnsToBeFilled()
        {
            bondPremiumDisbursement.MandatoryCheckValidations();
        }
        [Then(@"I Select '(.*)' from the Payment Method Dropdown")]
        public void ThenISelectFromThePaymentMethodDropdown(string payMethod)
        {
            bondPremiumDisbursement.SelectPaymentMethod(payMethod);            
        }
        [When(@"I Select a Status '(.*)' from Drop Down")]
        public void WhenISelectAStatusFromDropDown(string Status)
        {
            bondPremiumDisbursement.SelectStatusOption(Status);
        }

    }
}
