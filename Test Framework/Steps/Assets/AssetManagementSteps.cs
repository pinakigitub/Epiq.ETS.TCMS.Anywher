using Epiq.ETS.TCMS.Anywhere.Testing.E2ETest.Test_Framework.Core;
using Epiq.ETS.TCMS.Anywhere.Testing.E2ETest.Test_Framework.Pages.Assets;
using Epiq.ETS.TCMS.Anywhere.Testing.E2ETest.TestFramework.Pages.Cases.Detail;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using TechTalk.SpecFlow;

namespace Epiq.ETS.TCMS.Anywhere.Testing.E2ETest.Test_Framework.Steps.Assets
{
    [Binding]
    [Scope(Feature = "AssetManagement")]
    public class AssetManagementSteps : StepBase
    {
        AssetsDetailTab assetsDetailTab = new AssetsDetailTab(driver);
        AddAsset addAsset = new AddAsset(driver);
        DataTable randomClaimRecords;

        [Then(@"'(.*)' page should be display")]
        public void ThenPageShouldBeDisplay(string assetManagement)
        {
            assetsDetailTab = ((AssetsDetailTab)GetSharedPageObjectFromContext("Assets"));
        }
        [Then(@"Page Count shoud be display")]
        public void ThenPageCountShoudBeDisplay()
        {
            //  assetsDetailTab.GetPageCount().Should().BeGreaterOrEqualTo(0);
            // TestsLogger.Log(string.Format("Claims count is [{0}]", assetsDetailTab.GetPageCount()));
            assetsDetailTab.GetPageCount();
        }
        [Then(@"'(.*)' should be able sorted")]
        public void ThenShouldBeAbleSorted(string columnName)
        {
            var list = assetsDetailTab.GetSortedList(columnName);
            list.Should().BeInDescendingOrder();
            list = assetsDetailTab.GetSortedList(columnName);
            list.Should().BeInAscendingOrder();
        }
        [Then(@"navigation and pagination should display")]
        public void navigationandpaginationshoulddisplay()
        {
            assetsDetailTab.VerifyPaginationAndNavigations();
        }
        [Then(@"Table data should be present")]
        public void ThenTableDataShouldBePresent()
        {
            randomClaimRecords = assetsDetailTab.GetClaimRecords();
            randomClaimRecords.Columns.Count.Should().BeGreaterOrEqualTo(0);
        }
        [When(@"I Click on Add Asset")]
        public void WhenIClickOnAddAsset()
        {
            addAsset = assetsDetailTab.ClickOnAsset();
        }
        [Then(@"Add Asset page should be display")]
        public void ThenAddAssetPageShouldBeDisplay()
        {
            addAsset.VerifyAddAsset.Should().BeTrue();
        }

        [When(@"I enter '(.*)' fileds")]
        public void WhenIEnterFileds(string fieldInputs)
        {
            // input Criteria  (InputLabelName-InputValue) Ex :([CASE # / DEBTOR NAME]-[09-28278;])
            var inputEntries = fieldInputs.Split(';').Select(i=>i.Trim()).ToList();
            addAsset.PopulateFields(inputEntries);
        }
        [When(@"I click on save")]
        public void WhenIClickOnSave()
        {
            addAsset.ClickOnsave();
        }
        [When(@"I click on filter button")]
        public void WhenIClickOnFilterButton()
        {
            assetsDetailTab = ((AssetsDetailTab)GetSharedPageObjectFromContext("Assets"));
            assetsDetailTab.ClickFilterButton();
        }
        [When(@"Click on reset")]
        public void WhenClickOnReset()
        {
            assetsDetailTab.ClickOnResetButton();
        }
        [Then(@"default data should be present")]
        public void ThenDefaultDataShouldBePresent()
        {
            System.Threading.Thread.Sleep(2000);
            assetsDetailTab.GetClaimRecords().Should().Equals(randomClaimRecords);
        }
        [When(@"I click on close")]
        public void WhenIClickOnClose()
        {
            assetsDetailTab.ClickOnCloseButton();
        }
        [When(@"I enter description '(.*)'")]
        public void WhenIEnterDescription(string description)
        {
            assetsDetailTab.EnterDescription(description);
        }
        [When(@"I select fully administered '(.*)'")]
        public void WhenISelectFullyAdministered(string fullyAdministered)
        {
            assetsDetailTab.SelectFullyAdministered(fullyAdministered);
        }
        [When(@"I select fully abandoned '(.*)'")]
        public void WhenISelectFullyAbandoned(string abandoned)
        {
            assetsDetailTab.SelectFullyAbondoned(abandoned);
        }
        [When(@"I select fully reserved '(.*)'")]
        public void WhenISelectFullyReserved(string fullyReserved)
        {
            assetsDetailTab.SelectFullyReserved(fullyReserved);
        }
        [When(@"I select fully case status '(.*)'")]
        public void WhenISelectFullyCaseStatus(string casuStatus)
        {
            assetsDetailTab.SelectCaseStatus(casuStatus);
        }
        [Then(@"Records should contain '(.*)'")]
        public void ThenRecordsShouldContain(string value)
        {
            assetsDetailTab.GetRecordsByColumnName(value.Split('-')[0], value.Split('-')[1]);
        }
        [Then(@"fully administered should contains '(.*)'")]
        public void ThenFullyAdministeredShouldContains(string value)
        {
            assetsDetailTab.CheckFullyAdministeredFormat(value).Should().BeTrue();
        }
        [Then(@"Fully abandoned should contains '(.*)'")]
        public void ThenFullyAbandonedShouldContains(string value)
        {
            assetsDetailTab.GetRecordValue("ABANDONED").Should().Contain(value);
        }
        [Then(@"Fully reserved should contains '(.*)'")]
        public void ThenFullyReservedShouldContains(string value)
        {
            assetsDetailTab.GetRecordValue("RESERVED").Should().Contain(value.ToUpper());
        }
        [Then(@"Case status should be '(.*)'")]
        public void ThenCaseStatusShouldBe(string value)
        {
            assetsDetailTab.GetCaseStatus().Should().Contain(value.ToString());
        }
        [When(@"I click on fully administered x")]
        public void WhenIClickOnFullyAdministeredX()
        {
            assetsDetailTab.ClickFullyAdministeredX();
        }
        [When(@"I click on fully abandoned x")]
        public void WhenIClickOnFullyAbandonedX()
        {
            assetsDetailTab.ClickFullyAbondonedX();
        }
        [When(@"I click on fully reserved x")]
        public void WhenIClickOnFullyReservedX()
        {
            assetsDetailTab.ClickFullyReservedX();
        }
        [When(@"I click on fully case status x")]
        public void WhenIClickOnFullyCaseStatusX()
        {
            assetsDetailTab.ClickFullyCaseStatusX();
        }
        [When(@"I clear the description")]
        public void WhenIClearTheDescription()
        {
            assetsDetailTab.ClearDescription();
        }
        [When(@"I see the Table Contains the Same Number of Rows as per Selected (.*)")]
        public void WhenISeeTheTableContainsTheSameNumberOfRowsAsPerSelected(int PageSize)
        {
            assetsDetailTab.VerifyRowsLength(PageSize);
        }
        [Then(@"I edit Record containing DESCRIPTION '(.*)'")]
        public void ThenIEditRecordContainingDESCRIPTION(string DesValue)
        {
            assetsDetailTab.EditWithDescription(DesValue);
        }
        [Then(@"I click on Taxrefund request button")]
        public void ThenIClickOnTaxrefundRequestButton()
        {
            assetsDetailTab.TaxrefundRequest();
        }

        [Then(@"I click on Tax refund request button")]
        public void ThenIClickOnTaxRefundRequestButton()
        {
            assetsDetailTab.ClickOnTaxrefundrequest();
        }
        [Then(@"I edit PETITION InLineEdit '(.*)'")]
        public void ThenIEditPETITIONInLineEdit(string petition)
        {
            assetsDetailTab.EditPetition(petition);
        }
        [Then(@"I edit TRUSTEE '(.*)'")]
        public void ThenIEditTRUSTEE(string trustee)
        {
            assetsDetailTab.EditTrustee(trustee);
        }
        [Then(@"I edit EXEMPTIONS '(.*)'")]
        public void ThenIEditEXEMPTIONS(string exemption)
        {
            assetsDetailTab.EditExemptions(exemption);
        }
        [Then(@"I edit ABANDONED '(.*)'")]
        public void ThenIEditABANDONED(string abandoned)
        {
            assetsDetailTab.EditAbandoned(abandoned);
        }
        [Then(@"I edit OWNED '(.*)'")]
        public void ThenIEditOWNED(string owned)
        {
            assetsDetailTab.EditOwned(owned);
        }
        [Then(@"I Edit RESERVED NOTE '(.*)'")]
        public void ThenIEditRESERVEDNOTE(string note)
        {
            assetsDetailTab.ReservedNotes(note);
        }
        [Then(@"I edit Reserved")]
        public void ThenIEditReserved()
        {
            assetsDetailTab.Reserved();
        }
        [Then(@"I see the PETITION value '(.*)'")]
        public void ThenISeeThePETITIONValue(string petition)
        {
            assetsDetailTab.PetitionValue(petition);
        }
        [Then(@"the TRUSTEE value as '(.*)'")]
        public void ThenTheTRUSTEEValueAs(string trustee)
        {
            assetsDetailTab.TrusteeValue(trustee);
        }
        [Then(@"the EXEMPTIONS value as '(.*)'")]
        public void ThenTheEXEMPTIONSValueAs(string exemption)
        {
            assetsDetailTab.ExemptionValue(exemption);
        }
        [Then(@"I edit FA '(.*)'")]
        public void ThenIEditFA(string date)
        {
            assetsDetailTab.EditFA(date);
        }
        [Then(@"the FA value as '(.*)'")]
        public void ThenTheFAValueAs(string fa)
        {
            assetsDetailTab.FAValue(fa);
        }
        [Then(@"the ABANDONED value as '(.*)'")]
        public void ThenTheABANDONEDValueAs(string abandoned)
        {
            assetsDetailTab.AbandonedValue(abandoned);
        }
        [Then(@"the OWNED value as '(.*)'")]
        public void ThenTheOWNEDValueAs(string owned)
        {
            assetsDetailTab.OwnedValue(owned);
        }
        [Then(@"the RESERVED Notes as '(.*)'")]
        public void ThenTheRESERVEDNotesAs(string notes)
        {
            assetsDetailTab.ReservedText(notes);
        }
        [Then(@"I edit PETITION '(.*)'")]
        public void ThenIEditPETITION(string petition)
        {
            assetsDetailTab.CancelPetitionEdit(petition);
        }
        [Then(@"edit TRUSTEE '(.*)'")]
        public void ThenEditTRUSTEE(string trustee)
        {
            assetsDetailTab.CancelTrusteeEdit(trustee);
        }
        [Then(@"edit EXEMPTIONS '(.*)'")]
        public void ThenEditEXEMPTIONS(string exemption)
        {
            assetsDetailTab.CancelExemptionEdit(exemption);
        }
        [Then(@"edit FA '(.*)'")]
        public void ThenEditFA(string date)
        {
            assetsDetailTab.CancelFAEdit(date);
        }
        [Then(@"edit ABANDONED '(.*)'")]
        public void ThenEditABANDONED(string abandoned)
        {
            assetsDetailTab.CancelAbandonedEdit(abandoned);
        }
        [Then(@"edit OWNED '(.*)'")]
        public void ThenEditOWNED(string owned)
        {
            assetsDetailTab.CancelOwnedEdit(owned);
        }
        [Then(@"Edit RESERVED NOTE '(.*)'")]
        public void ThenEditRESERVEDNOTE(string notes)
        {
            assetsDetailTab.CancelReservedNotesEdit(notes);
        }
        [Then(@"I see the InLineEdit Fields as Non-Editable Fields")]
        public void ThenISeeTheInLineEditFieldsAsNon_EditableFields()
        {
            assetsDetailTab.InLineEditViewFields();
        }
        [Then(@"I verify Fully Administered Cases as Green")]
        public void ThenIVerifyFullyAdministeredCasesAsGreen()
        {
            assetsDetailTab.VerifyCaseFullyAdministered();
        }
        [Then(@"I see default value '(.*)' as '(.*)'")]
        public void ThenISeeDefaultValueAs(string header, string value)
        {
            assetsDetailTab.VerifyFilterDefaultValue(header, value);
        }
        [Then(@"I should not be able to see '(.*)'")]
        public void ThenIShouldNotBeAbleToSee(string caseStatus)
        {
            assetsDetailTab.CaseStatusHidden(caseStatus);
        }
    }
}
