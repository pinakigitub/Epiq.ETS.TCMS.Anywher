using Epiq.ETS.TCMS.Anywhere.Testing.E2ETest.Test_Framework.Pages.Superadmin;
using Epiq.ETS.TCMS.Anywhere.Testing.E2ETest.Test_Framework.Steps.Common;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace Epiq.ETS.TCMS.Anywhere.Testing.E2ETest.Test_Framework.Steps.Superadmin
{
    [Binding]
    public class SuperAdminSteps : SignedInUnityUserSteps
    {
        SuperAdminPages superAdmin = new SuperAdminPages(driver);
        [Given(@"I select '(.*)' under User icon")]
        public void GivenISelectUnderUserIcon(string user)
        {
            superAdmin.SelectUserPermission(user);
        }
        [When(@"I select tab '(.*)'")]
        public void WhenISelectTab(string AdminTabs)
        {
            superAdmin.SelectAdminTabs(AdminTabs);
        }
        [Then(@"I select the document with Description '(.*)'")]
        public void ThenISelectTheDocumentWithDescription(string description)
        {
            superAdmin.SelectCheckBoxWithDescription(description);
        }
        [Then(@"I see DELETE button in Enabled State")]
        public void ThenISeeDELETEButtonInEnabledState()
        {
            superAdmin.VerifyDeleteButtonInEnabledState();
        }
        [Then(@"I Select '(.*)','(.*)'")]
        public void ThenISelect(int index, string button)
        {
            superAdmin.SelectButton(index, button);
        }
        [Then(@"I see Restore button in '(.*)' state")]
        public void ThenISeeRestoreButtonInState(string state)
        {
            superAdmin.VerifyRestoreButtonDisabledState(state);
        }
        [Then(@"I see the Records should contain '(.*)'")]
        public void ThenISeeTheRecordsShouldContain(string description)
        {
            superAdmin.GetRecordsByColumnName(description.Split('-')[0], description.Split('-')[1]);
        }
        [Given(@"I should not be able to see '(.*)' under User icon")]
        public void GivenIShouldNotBeAbleToSeeUnderUserIcon(string userType)
        {
            superAdmin.verifyNoVisibilitySuperAdmin(userType);
        }
        [Given(@"I should be able to see '(.*)' under User icon")]
        public void GivenIShouldBeAbleToSeeUnderUserIcon(string userType)
        {
            superAdmin.VerifySuperAdminVisibility(userType);
        }
        [Given(@"I see internal message '(.*)' and '(.*)'")]
        public void GivenISeeInternalMessageAnd(string internalError, string ErrorMessage)
        {
            superAdmin.VerifyErrorMessage(internalError, ErrorMessage);
        }
        [Given(@"I see Navigation section contains '(.*)' and '(.*)'")]
        public void GivenISeeNavigationSectionContainsAnd(string allCasesText, string superAdminText)
        {
            superAdmin.VerifyNavigationSection(allCasesText, superAdminText);
        }
        [Given(@"I see message '(.*)'")]
        public void GivenISeeMessage(string message)
        {
            superAdmin.VerifyMessage(message);
        }
        [When(@"I see office as '(.*)'")]
        public void WhenISeeOfficeAs(string office)
        {
            superAdmin.verifyOfficeMessage(office);
        }
        [Then(@"I see Admin Tab '(.*)'")]
        public void ThenISeeAdminTab(string tab)
        {
            superAdmin.verifyAdminTabs(tab);
        }
        [Then(@"I see DELETE button in Disable State")]
        public void ThenISeeDELETEButtonInDisableState()
        {
            superAdmin.verifyDeleteInDisableState();
        }
        [When(@"I see SuperAdmin Table header contains '(.*)'")]
        public void WhenISeeSuperAdminTableHeaderContains(string titles)
        {
            var TableTitles = titles.Split(';').Select(i => i.Trim()).ToList();
            superAdmin.VerifySuperAdminPageTableColumns(TableTitles);
        }
        [When(@"I verify '(.*)' caution header '(.*)'")]
        public void WhenIVerifyCautionHeader(int index, string cautionHeader)
        {
            superAdmin.VerifyCautionHeader(index, cautionHeader);
        }
        [When(@"I select selection column '(.*)' when sales of Asset is null")]
        public void WhenISelectSelectionColumnWhenSalesOfAssetIsNull(int index)
        {
            superAdmin.SelectSelectionColumn(index);
        }
        [Then(@"I see Docket\# in Ascending order")]
        [Then(@"I see Asset\# in Ascending order")]
        public void ThenISeeAssetInAscendingOrder()
        {
            var list = superAdmin.VerifyAssetNumberOrder();
            list.Should().BeInAscendingOrder();
        }
        [When(@"I see '(.*)' button '(.*)' in '(.*)' state")]
        public void WhenISeeButtonInState(string button, int index, string state)
        {
            superAdmin.VerifyButtonState(button, index, state);
        }
        [When(@"I select Tab '(.*)' Selection Column of row '(.*)'")]
        public void WhenISelectTabSelectionColumnOfRow(int section, int index)
        {
            superAdmin.SelectRowOfSelectionColumn(section, index);
        }
        [When(@"I click on meeting link in the page")]
        public void WhenIClickOnMeetingLinkInThePage()
        {
            superAdmin.MeetingLink();
        }
        [When(@"I click on AssetsLink on the page")]
        public void WhenIClickOnAssetsLinkOnThePage()
        {
            superAdmin.AssetsLink();
        }
        [When(@"I should able to click on ClaminsLink in the page")]
        public void WhenIShouldAbleToClickOnClaminsLinkInThePage()
        {
            superAdmin.CliamsLink();
        }

        [When(@"I click on Imports section to select the options")]
        public void WhenIClickOnImportsSectionToSelectTheOptions()
        {
            superAdmin.ImportsSection();
        }
        [When(@"I click on Batch options to see list of the options")]
        public void WhenIClickOnBatchOptionsToSeeListOfTheOptions()
        {
            superAdmin.BatchOptions();
        }
        [When(@"I click on Batch options to see list")]
        public void WhenIClickOnBatchOptionsToSeeList()
        {
            superAdmin.BatchOptions();
        }
        [When(@"I can able to select the options from the menu")]
        public void WhenICanAbleToSelectTheOptionsFromTheMenu()
        {
            superAdmin.AbondedStatusYes();
        }
        [When(@"I can save the selected seetings")]
        public void WhenICanSaveTheSelectedSeetings()
        {
            superAdmin.SaveTheStatus();
        }
        [When(@"I can able to select the options from the Batch Settings")]
        public void WhenICanAbleToSelectTheOptionsFromTheBatchSettings()
        {
            superAdmin.BatchSettings();
        }
        [Then(@"I Verify the General Import Defaults Pane")]
        public void ThenIVerifyTheGeneralImportDefaultsPane()
        {
            superAdmin.VerifyDefaultOptions();
        }
        [Then(@"I Verify for Import Claim in UpperCase")]
        public void ThenIVerifyForImportClaimInUpperCase()
        {
            superAdmin.UpperCaseImportClaim();
        }
        [Then(@"I Verify for Import Creditor Matrix Data")]
        public void ThenIVerifyForImportCreditorMatrixData()
        {
           superAdmin.MatrixDataimportCreditor();
        }
        [Then(@"I Verify Import Creditor Data on Demand")]
        public void ThenIVerifyImportCreditorDataOnDemand()
        {
            superAdmin.MatrixDataOnDemand();
        }        
    }
}
