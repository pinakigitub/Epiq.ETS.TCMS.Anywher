using TechTalk.SpecFlow;
using FluentAssertions;
using Epiq.ETS.TCMS.Anywhere.Testing.E2ETest.Test_Framework.Pages.Documents;
using System.Data;
using Epiq.ETS.TCMS.Anywhere.Testing.E2ETest.TestFramework.Pages.Cases.Detail;
using System.Threading;

namespace Epiq.ETS.TCMS.Anywhere.Testing.E2ETest.Test_Framework.Steps.Documents
{
    [Binding]
    public class DocumentsSteps : StepBase
    {
        DocumentsPage documents = new DocumentsPage(driver);
        DataTable randomDocumentsRecords;
        AssetsDetailTab assetsDetailTab = new AssetsDetailTab(driver);


        [Then(@"'(.*)' header should be displayed on Document Page")]
        public void ThenHeaderShouldBeDisplayedOnDocumentPage(string header)
        {
            documents = ((DocumentsPage)GetSharedPageObjectFromContext("Documents"));
            documents.GetHeaderName().Should().Contain(header);
          
        }

        [When(@"I click on Filter on Documents page")]
        public void WhenIClickOnFilterOnDocumentsPage()
        {
            documents = ((DocumentsPage)GetSharedPageObjectFromContext("Documents"));
            documents.ClickOnFilter();
        }

        [Then(@"Documents '(.*)' should be displayed")]
        public void ThenDocumentsShouldBeDisplayed(string filterHeader)
        {
            documents.GetFilterOptionHeader().Should().Contain(filterHeader);
        }

        [When(@"I click on close on Documents page")]
        public void WhenIClickOnCloseOnDocumentsPage()
        {
            documents.ClickOnFilterClose();
        }

        [Then(@"Documents '(.*)' should be closed")]
        public void ThenDocumentsShouldBeClosed(string filterHeader)
        {
            documents.GetFilterOptionHeader().Should().BeNullOrWhiteSpace();
        }
        [When(@"I click on Row Expand button on Document page")]
        public void WhenIClickOnRowExpandButtonOnDocumentPage()
        {
            documents = ((DocumentsPage)GetSharedPageObjectFromContext("Documents"));
            documents.clickOnRowExpandButton();
        }
        [Then(@"I should be able to see column CASE STATUS")]
        public void ThenIShouldBeAbleToSeeColumnCASESTATUS()
        {
            documents = ((DocumentsPage)GetSharedPageObjectFromContext("Documents"));
            documents.GetCaseStatusDisplayed().Should().BeTrue();
        }
        [Then(@"I should be able to see column TRUSTEE")]
        public void ThenIShouldBeAbleToSeeColumnTRUSTEE()
        {
            documents = ((DocumentsPage)GetSharedPageObjectFromContext("Documents"));
            documents.GetTrusteeDisplayed().Should().BeTrue();
        }
        [Then(@"I should be able to see column DISTRICT")]
        public void ThenIShouldBeAbleToSeeColumnDISTRICT()
        {
            documents = ((DocumentsPage)GetSharedPageObjectFromContext("Documents"));
            documents.GetDistrictDisplayed().Should().BeTrue();
        }
        [Then(@"I should be able to see column CASE TYPE")]
        public void ThenIShouldBeAbleToSeeColumnCASETYPE()
        {
            documents = ((DocumentsPage)GetSharedPageObjectFromContext("Documents"));
            documents.GetCaseTypeDisplayed().Should().BeTrue();
        }
        [Then(@"I should be able to see column ASSET STATUS")]
        public void ThenIShouldBeAbleToSeeColumnASSETSTATUS()
        {
            documents = ((DocumentsPage)GetSharedPageObjectFromContext("Documents"));
            documents.GetAssetStatusDisplayed().Should().BeTrue();
        }
        [Then(@"I should be able to see column FILE NAME")]
        public void ThenIShouldBeAbleToSeeColumnFILENAME()
        {
            documents = ((DocumentsPage)GetSharedPageObjectFromContext("Documents"));
            documents.GetFileNameDisplayed().Should().BeTrue();
        }
        [When(@"Enter Case Number '(.*)' in document filter option")]
        public void WhenEnterCaseNumberInDocumentFilterOption(string caseNumber)
        {
            documents.EnterCaseNumber(caseNumber);
        }
        [Then(@"'(.*)' should be able to sort on Document Page")]
        public void ThenShouldBeAbleToSortOnDocumentPage(string column)
        {
            var list = documents.GetSortedList(column);
            list.Should().BeInAscendingOrder();
        }
        [Then(@"Document records should be displayed")]
        public void ThenDocumentRecordsShouldBeDisplayed()
        {
            documents.GetDocumentsRecords().Should().NotBeNull();
        }
        [When(@"I search '(.*)' and click on '(.*)' on Documents Filter")]
        public void WhenISearchAndClickOnOnDocumentsFilter(string case_no, string casename)
        {
            documents.searchInfo(case_no, casename);
        }
        [When(@"I select date '(.*)' from DATE FILED FROM field")]
        public void WhenISelectDateFromDATEFILEDFROMField(string selectDate)
        {
            documents.SelectDateFrom(selectDate);
        }
        [When(@"I select date '(.*)' from DATE FILED TO field")]
        public void WhenISelectDateFromDATEFILEDTOField(string selectDate)
        {
            documents.SelectDateTo(selectDate);
        }
        [Then(@"Document result should contains '(.*)' '(.*)'")]
        public void ThenDocumentResultShouldContains(string caseNo, string debtor)
        {
            System.Threading.Thread.Sleep(1500);

            if (!string.IsNullOrWhiteSpace(caseNo))
                documents.GetRecordsByColumnName("CASE #", caseNo);

            if (!string.IsNullOrWhiteSpace(debtor))
                documents.GetRecordsByColumnName("DEBTOR", debtor);
        }
        [When(@"I click on X button of case Status dropdown")]
        public void WhenIClickOnXButtonOfCaseStatusDropdown()
        {
            documents.ClickCaseStatusX();
        }
        [Then(@"default Documents result should be present")]
        public void ThenDefaultDocumentsResultShouldBePresent()
        {
            System.Threading.Thread.Sleep(2000);
            documents = ((DocumentsPage)GetSharedPageObjectFromContext("Documents"));
            randomDocumentsRecords = documents.GetDocumentsRecords();
        }
        [Then(@"Documents Result should not match with default result")]
        public void ThenDocumentsResultShouldNotMatchWithDefaultResult()
        {
            System.Threading.Thread.Sleep(2000);
            documents = ((DocumentsPage)GetSharedPageObjectFromContext("Documents"));
            documents.GetDocumentsRecords().Should().NotBeSameAs(randomDocumentsRecords);
        }
        [Then(@"case status filter value should be All")]
        public void ThenCaseStatusFilterValueShouldBeAll()
        {
            documents.GetCaseStausValue().Should().Contain("Select...");
        }
        [When(@"I click on reset button of documents filter")]
        public void WhenIClickOnResetButtonOfDocumentsFilter()
        {
            documents.ClickOnResetButton();
        }
        [When(@"User clicks on the add document button")]
        public void WhenUserClicksOnTheAddDocumentButton()
        {
            documents = ((DocumentsPage)GetSharedPageObjectFromContext("Documents"));
            documents.ClickOnAddDocument();
        }
        [When(@"user selects the Case Number or Debtor Name on new window")]
        public void WhenUserSelectsTheCaseNumberOrDebtorNameOnNewWindow()
        {
            string casenumber = "01-21039";
            documents.selectCaseNumberOrDebtorNumber(casenumber);
        }
        [When(@"User Uploads the Document in new window")]
        public void WhenUserUploadsTheDocumentInNewWindow()
        {
            documents.UploadNewDocument();
        }
        [Then(@"User clicks on save button on the current window")]
        public void ThenUserClicksOnSaveButtonOnTheCurrentWindow()
        {
            documents.ClickOnSaveButton();
        }
        [Then(@"I Edit Tags and Description '(.*)'")]
        public void ThenIEditTagsAndDescription(string DesText)
        {
            documents.EditTagsOfCaseAndDesc(DesText);
        }
        [Then(@"I Add Tags '(.*)', '(.*)' and '(.*)' to that Case")]
        public void ThenIAddTagsAndToThatCase(string tag1, string tag2, string tag3)
        {
            documents.AddTagsToCase(tag1, tag2, tag3);
        }
        [Then(@"I save the Added tags")]
        public void ThenISaveTheAddedTags()
        {
            documents.SaveTags();
        }
        [Then(@"I see Records should contain '(.*)'")]
        public void ThenISeeRecordsShouldContain(string value)
        {
            assetsDetailTab.GetRecordsByColumnName(value.Split('-')[0], value.Split('-')[1]);
        }
        [Then(@"I see the Security Warning Icon in Orange")]
        public void ThenISeeTheSecurityWarningIconInOrange()
        {
            documents.VerifyWarningIcon();
        }
        [Then(@"Security Warning msg as '(.*)'")]
        public void ThenSecurityWarningMsgAs(string warningMsg)
        {
            documents.VerifyWarningMsg(warningMsg).Should().BeTrue();
        }     
        [When(@"I see the text '(.*)' and Select Administrator '(.*)'")]
        public void ThenISeeTheTextAndSelectAdministrator(string ContactText, string Admin)
        {
            documents.ContactAdmin(ContactText, Admin);
        }
        [Then(@"an Email '(.*)' and Admin Name '(.*)' are Populated below")]
        public void ThenAnEmailAndAdminNameArePopulatedBelow(string Email, string Admin)
        {
            documents.AdminContactInfo(Email, Admin);
        }
        [When(@"I Click on Description button on Documents Page")]
        public void WhenIClickOnDescriptionButtonOnDocumentsPage()
        {
            documents.ClickOnDescription();
        }
        [Then(@"I Sould be able to edit description in line")]
        public void ThenISouldBeAbleToEditDescriptionInLine()
        {
            documents.EditDescription();
        }
        [When(@"I Click on Tag button on Documents Page")]
        public void WhenIClickOnTagButtonOnDocumentsPage()
        {
            documents.ClickOnTAG();
        }
        [Then(@"I Sould be able to edit Tag in line - '(.*)' or Blank")]
        public void ThenISouldBeAbleToEditTagInLine_OrBlank(string tag)
        {
            documents.EditTag(tag);
        }
        [When(@"I click on File Name button on document Page")]
        public void WhenIClickOnFileNameButtonOnDocumentPage()
        {
            documents.ClickOnFileName();
        }
        [Then(@"Should be able to edit File Name in line")]
        public void ThenShouldBeAbleToEditFileNameInLine()
        {
            documents.EditFileName();
        }
        [Then(@"I see eye button for all records")]
        public void ThenISeeEyeButtonForAllRecords()
        {
            documents.ValidateEyeButton().Should().BeTrue();
        }
        [When(@"I clik on Eye Button of Document")]
        public void WhenIClikOnEyeButtonOfDocument()
        {
            documents.ClickOnViewOfDocument();
        }
        [Then(@"I should not be able to edit the documents details")]
        public void ThenIShouldNotBeAbleToEditTheDocumentsDetails()
        {
            documents.ValidateDocumentsEditing().Should().BeFalse();
        }
        [Then(@"I see edit-pencil button for all records")]
        public void ThenISeeEdit_PencilButtonForAllRecords()
        {
            documents.ValidatePencilButton().Should().BeTrue();
        }
        [When(@"I clik on pencil Button of Document")]
        public void WhenIClikOnPencilButtonOfDocument()
        {
            documents.ClickOnEditPencilOfDocument();
        }
        [Then(@"I should be able to edit the documents details")]
        public void ThenIShouldBeAbleToEditTheDocumentsDetails()
        {
            documents.ValidateDocumentsEditing().Should().BeTrue();
        }
        [When(@"I click on TAG button on Document Viewer Page")]
        public void WhenIClickOnTAGButtonOnDocumentViewerPage()
        {
            documents.ClickOnTagButton_on_DocumentViewer();
        }
        [When(@"I Click on Header of Document Viewer Page")]
        public void WhenIClickOnHeaderOfDocumentViewerPage()
        {
            documents.ClickOnDocumentHeader_on_DocumentViewer();
        }
        [When(@"I click on File Name button on Document Viewer Page")]
        public void WhenIClickOnFileNameButtonOnDocumentViewerPage()
        {
            documents.ClickOnFileNameButton_on_DocumentViewer();
        }
        [When(@"I click on Description button on Document Viewer Page")]
        public void WhenIClickOnDescriptionButtonOnDocumentViewerPage()
        {
            documents.ClickOnDescriptionButton_on_DocumentViewer();
        }
        [When(@"I click on Assigned To button on Document Viewer Page")]
        public void WhenIClickOnAssignedToButtonOnDocumentViewerPage()
        {
            documents.ClickOnAssigendToButton_on_DocumentViewer();
        }
        [When(@"I click on Doc button on Document Viewer Page")]
        public void WhenIClickOnDocButtonOnDocumentViewerPage()
        {
            documents.ClickOnDocButton_on_DocumentViewer();
        }
        [When(@"I click on Source button on Document Viewer Page")]
        public void WhenIClickOnSourceButtonOnDocumentViewerPage()
        {
            documents.ClickOnSourceButton_on_DocumentViewer();
        }
        [Then(@"I Should be able to edit Description in line on Document Viewer Page")]
        public void ThenIShouldBeAbleToEditDescriptionInLineOnDocumentViewerPage()
        {
            documents.EditDescription_on_DocumentViewer();
        }
        [Then(@"I Should be able to edit Assigned To in line on Document Viewer Page")]
        public void ThenIShouldBeAbleToEditAssignedToInLineOnDocumentViewerPage()
        {
            documents.EditAssigendTo_on_DocumentViewer();
        }
        [When(@"I enter Description '(.*)'")]
        public void WhenIEnterDescription(string desc)
        {
            documents.InputDescription(desc);
        }
        [Then(@"I can click on delete button in the Dcouments Page")]
        public void ThenICanClickOnDeleteButtonInTheDcoumentsPage()
        {
            documents.DeleteFuntionality();
        }
        [When(@"I select CaseStatus '(.*)'")]
        public void WhenISelectCaseStatus(string casestatus)
        {
            documents.SelectCaseStatus(casestatus);
        }
        [When(@"I select Tag '(.*)'")]
        public void WhenISelectTag(string tag)
        {
            documents.SelectTagName(tag);
        }
        [Then(@"Document result should contain Tag '(.*)'")]
        public void ThenDocumentResultShouldContainTag(string tag)
        {
            documents.CheckTagName(tag);
        }
        [Then(@"I should  be able to see column CASE \#")]
        public void ThenIShouldBeAbleToSeeColumnCASE()
        {
            documents = ((DocumentsPage)GetSharedPageObjectFromContext("Documents"));
            documents.GetCaseNumberDisplayed().Should().BeTrue();
        }
        [Then(@"I should  be able to see column CURRENT (.*) DATE")]
        public void ThenIShouldBeAbleToSeeColumnCURRENTDATE(int p0)
        {
            documents = ((DocumentsPage)GetSharedPageObjectFromContext("Documents"));
            documents.GetCurrent341DateDisplayed().Should().BeTrue();
        }
        [Then(@"I should  be able to see column HISTORY")]
        public void ThenIShouldBeAbleToSeeColumnHISTORY()
        {
            documents = ((DocumentsPage)GetSharedPageObjectFromContext("Documents"));
            documents.GetHistoryDisplayed().Should().BeTrue();
        }
    }
}
