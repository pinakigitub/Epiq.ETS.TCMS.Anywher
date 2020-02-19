using Epiq.ETS.TCMS.Anywhere.Testing.E2ETest.Test_Framework.Pages.Imports;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace Epiq.ETS.TCMS.Anywhere.Testing.E2ETest.Test_Framework.Steps.Imports
{
    public class ImportSteps : StepBase
    {
        ImportAssets importAsset = new ImportAssets(driver);
        string defaultCount, afterFilterCount, headerTitle;

        [When(@"I Click on one AssetToImport link of listed cases")]
        public void WhenIClickOnOneAssetToImportLinkOfListedCases()
        {
            importAsset = ((ImportAssets)GetSharedPageObjectFromContext("Import Assets"));
            importAsset.ClickOnAssetToImportLink();
        }

        [Then(@"I see header on Import Assets Page")]
        public void ThenISeeHeaderOnImportAssetsPage()
        {
            importAsset.ValidatePageHeader().Equals(true);
        }
        [Then(@"I see the count for Assets to Import")]
        public void ThenISeeTheCountForAssetsToImport()
        {
            importAsset.ValidateAssetsToImport_Count().Equals(true);
        }

        [Then(@"I see the count for Assets in case")]
        public void ThenISeeTheCountForAssetsInCase()
        {
            importAsset.ValidateAssetsInCase_Count().Equals(true);
        }
        [When(@"I click on Row Expand Button of Assets to Import")]
        public void WhenIClickOnRowExpandButtonOfAssetsToImport()
        {
            importAsset.ClickOnExpandButton();
        }

        [Then(@"I see all Hidden coulumns hearder")]
        public void ThenISeeAllHiddenCoulumnsHearder()
        {
            importAsset.HiddenHeadersExist();
        }
        [Then(@"I see the Visible headers on Assets to Import are '(.*)' '(.*)' and '(.*)'")]
        public void ThenISeeTheVisibleHeadersOnAssetsToImportAreAnd(string h1, string h2, string h3)
        {
            importAsset.VisibleHeaderExists(h1,h2,h3);
        }
        [Then(@"I see the Visible headers on Assets In Case are '(.*)' '(.*)' and '(.*)'")]
        public void ThenISeeTheVisibleHeadersOnAssetsInCaseAreAnd(string h1, string h2, string h3)
        {
            importAsset.VisibleHeaderExists_AssetsInCase(h1, h2, h3);
        }
        [When(@"I click on Row Expand Button of Assets in Case")]
        public void WhenIClickOnRowExpandButtonOfAssetsInCase()
        {
            importAsset.ClickOnExpandButton_AssetsInCase();
        }
        [Then(@"I see all Hidden coulumns hearder for Assets in case")]
        public void ThenISeeAllHiddenCoulumnsHearderForAssetsInCase()
        {
            importAsset.HiddenHeadersExist_AssetsInCase();
        }
        [Then(@"I see Import and Ignore button Disabled")]
        public void ThenISeeImportAndIgnoreButtonDisabled()
        {
            importAsset.ImportIsDisabled().Equals(true);
            importAsset.IgnoreIsDisabled().Equals(true);
        }

        [When(@"I click on one checkbox of listed assets")]
        public void WhenIClickOnOneCheckboxOfListedAssets()
        {
            importAsset.ClickOnAssetCheckbox();
        }

        [Then(@"I see Import and Ignore button Enabled")]
        public void ThenISeeImportAndIgnoreButtonEnabled()
        {
            importAsset.ImportIsEnabled().Equals(true);
            importAsset.IgnoreIsEnabled().Equals(true);
        }
        [Then(@"I should be able to Import Assets and get Success Message")]
        public void ThenIShouldBeAbleToImportAssetsAndGetSuccessMessage()
        {
             importAsset.ClickOnImport_and_VerifyToastMessage().Should().BeTrue(); 
        }
        [Then(@"I see same Asset in Asset in Case Tab")]
        public void ThenISeeSameAssetInAssetInCaseTab()
        {
            importAsset.IsExistInAssetsInCaseTab().Equals(true);
        }
        [Then(@"Same Asset should not be listed in Asset to import Tab")]
        public void ThenSameAssetShouldNotBeListedInAssetToImportTab()
        {
            importAsset.Is_Exist_In_AssetsToImport_Tab().Equals(false);
        }
        [Then(@"I should be able to click on Ignore Assets and get Success Message")]
        public void ThenIShouldBeAbleToClickOnIgnoreAssetsAndGetSuccessMessage()
        {
            importAsset.ClickOnIgnore_and_VerifyToastMessage().Should().BeTrue();
        }

        [Then(@"Same Asset should not be listed in Asset in Case Tab")]
        public void ThenSameAssetShouldNotBeListedInAssetInCaseTab()
        {
            importAsset.IsExistInAssetsInCaseTab().Equals(false);
        }


        [When(@"User clicks on the filter options of Import Asset Page")]
        public void WhenUserClicksOnTheFilterOptionsOfImportAssetPage()
        {
            importAsset = ((ImportAssets)GetSharedPageObjectFromContext("Import Assets"));
            importAsset.ClickFilterButton();
        }

        [When(@"Validate by default the imports text is'(.*)'")]
        public void WhenValidateByDefaultTheImportsTextIs(string defaultImportValue)
        {
            importAsset.ValidateDefaultImportedValue().Contains(defaultImportValue);
        }

        [When(@"Validate by default the Case status is '(.*)'")]
        public void WhenValidateByDefaultTheCaseStatusIs(string defaultCaseStatusValue)
        {
            importAsset.ValidateDefaultCaseStatusValue().Contains(defaultCaseStatusValue);
        }

        [Then(@"User clicks on cross button of the filter option")]
        public void ThenUserClicksOnCrossButtonOfTheFilterOption()
        {
            importAsset.ClickFilterCrossButton();
        }

        [Then(@"Validate the Header title of Import Page")]
        public void ThenValidateTheHeaderTitleOfImportPage()
        {
            importAsset.ValidateHeaderTilteValue().Equals(true);
        }
        [When(@"Enter imports text as '(.*)'")]
        [When(@"Enter imports text as'(.*)'")]
        public void WhenEnterImportsTextAs(string newImportValue)
        {
            importAsset = ((ImportAssets)GetSharedPageObjectFromContext("Import Assets"));
            importAsset.FilterWithImportedNewValue(newImportValue);
        }

        [When(@"Enter the Case status as '(.*)'")]
        public void WhenEnterTheCaseStatusAs(string newCaseStatusValue)
        {
            importAsset.FilterWithCaseStatusNewValue(newCaseStatusValue);
        }

        [When(@"User clicks on Close button of the filter option")]
        public void WhenUserClicksOnCloseButtonOfTheFilterOption()
        {
            importAsset.ClickFilterCLoseButton();
        }

        [Then(@"Clicks on the reset button of the filter options")]
        public void ThenClicksOnTheResetButtonOfTheFilterOptions()
        {
            importAsset.ClickFilterResetButton();
        }

        [Then(@"Inline edit the Description as '(.*)'")]
        public void ThenInlineEditTheDescriptionAs(string description)
        {
            importAsset.NewInlineEditDescriptionValue(description);
        }

        [Then(@"Inline edit the FA as '(.*)'")]
        public void ThenInlineEditTheFAAs(string faValue)
        {
            importAsset.NewInlineEditFaValue(faValue);
        }

        [Then(@"Inline edit the UTC as '(.*)'")]
        public void ThenInlineEditTheUTCAs(int uctValue)
        {
            importAsset.NewInlineEditUTCValue(uctValue.ToString());
        }
        [When(@"I Select the PageSize as (.*) under Pagination Section in import asset page")]
        public void WhenISelectThePageSizeAsUnderPaginationSectionInImportAssetPage(int PageSize)
        {
            importAsset = ((ImportAssets)GetSharedPageObjectFromContext("Import Assets"));
            importAsset.SelectPageSize(PageSize);
        }
        [When(@"I see the Assets Table Contains the Same Number of Rows as per Selected (.*)")]
        public void WhenISeeTheAssetsTableContainsTheSameNumberOfRowsAsPerSelected(int PageSize)
        {
            importAsset.VerifyRowsLength(PageSize);
        }
        [Then(@"I see the Visible headers on View Documents Tab are '(.*)' '(.*)' and '(.*)'")]
        public void ThenISeeTheVisibleHeadersOnViewDocumentsTabAreAnd(string C1, string C2, string C3)
        {
            importAsset.VisibleHeaderExists_Documents_View(C1,C2,C3);
        }
        [Then(@"Validate the count of the documents in the view document tab")]
        public void ThenValidateTheCountOfTheDocumentsInTheViewDocumentTab()
        {
            importAsset.ValidateViewDocuments_Count();
        }
        [Then(@"Validate the error message turns up")]
        public void ThenValidateTheErrorMessageTurnsUp()
        {
            importAsset.ValidateErrorTextMessage().Should().BeTrue();
        }
        [Then(@"I Click on Cross Button on Universal search box")]
        public void ThenIClickOnCrossButtonOnUniversalSearchBox()
        {
            importAsset = ((ImportAssets)GetSharedPageObjectFromContext("Import Assets"));
            ImportAssets importAssets = importAsset.ClickOnCrossButton();
        }
        [Then(@"Validate the message as '(.*)'")]
        public void ThenValidateTheMessageAs(string message)
        {
            importAsset.MessageVerify(message);
        }
        [Then(@"Validate the header tilte '(.*)'")]
        public void ThenValidateTheHeaderTilte(string header)
        {
            var headerTilte = importAsset.VerifyTableHeaderTitle(header);
        }
        [Then(@"Validate the Record Default Count on the Page")]
        public void ThenValidateTheRecordDefaultCountOnThePage()
        {
            importAsset = ((ImportAssets)GetSharedPageObjectFromContext("Import Assets"));
            defaultCount = importAsset.ValidateTheTableRecordCount();
        }
        [Then(@"Validate the count after filter applied")]
        public void ThenValidateTheCountAfterFilterApplied()
        {
            afterFilterCount = importAsset.ValidateTheTableRecordCount();
            afterFilterCount.Should().NotBe(defaultCount);
        }
        [Then(@"verify the expand functionality on '(.*)' section")]
        public void ClickExpandSymbolOnSections(string sectionHeaders)
        {
            var sectionHeaderList = sectionHeaders.Split(';').Select(sectionName => sectionName.Trim()).ToList();
            importAsset.ClickExpandSymbol(sectionHeaderList);
        }
        [Then(@"verify the displayed options in '(.*)' section as '(.*)'")]
        public void VerifyAndClickCheckBoxOptions(string sectionHeader, string CheckBoxes)
        {
            var sectionCheckBoxList = CheckBoxes.Split(';').Select(sectionName => sectionName.Trim()).ToList();
            importAsset.ClickCheckBox(sectionHeader,sectionCheckBoxList);
        }
        [Then(@"I click on View Documents Tab")]
        public void ThenIClickOnViewDocumentsTab()
        {
            importAsset.ClickViewDocumentTab();
        }

        [Then(@"I click on Expand button")]
        public void ThenIClickOnExpandButton()
        {
            importAsset.ClickOnExpandCollapseButton();
        }

        [When(@"I View that Import Option is Disabled")]
        public void WhenIViewThatImportOptionIsDisabled()
        {
            importAsset.ImportIsDisabled();
        }


        [Then(@"I View that Import Option is Enabled")]
        public void ThenIViewThatImportOptionIsEnabled()
        {
            importAsset.ImportIsEnabled();            
        }

        [When(@"I click import '(.*)' in Assets to import tile")]
        public void WhenIClickImportInAssetsToImportTile(string option)
        {
            importAsset.ClickImportOrIgnoreAsset(option);            
        }


    }
}
