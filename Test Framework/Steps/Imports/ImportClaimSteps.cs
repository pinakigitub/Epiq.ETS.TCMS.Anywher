using Epiq.ETS.TCMS.Anywhere.Testing.E2ETest.Test_Framework.Pages.Imports;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;
using OpenQA.Selenium;
using FluentAssertions;
using System.Collections;

namespace Epiq.ETS.TCMS.Anywhere.Testing.E2ETest.Test_Framework.Steps.Imports
{
    [Binding]
    class ImportClaimsSteps : StepBase
    {
        ImportClaimsPage importClaims = new ImportClaimsPage(driver);
        [Then(@"I see subheader as '(.*)'")]
        public void VerifySubHeader(string subHeader)
        {
            importClaims.VerifySubHeader(subHeader);
        }
        [Then(@"verify the columns from '(.*)' to '(.*)' displayed on '(.*)' as '(.*)'")]
        public void VerifyColumns(int colStartIndex, int colEndIndex, string page,string columns)
        {
            var inputEntries = columns.Split(';').Select(i => i.Trim()).ToList();
            importClaims.VerifyColumns(colStartIndex,colEndIndex,inputEntries,page);
        }
        [When(@"Click on filter option")]
        public void ClickFilter()
        {
            importClaims.ClickFilter();
        }
        [When(@"Click on filter option on tile page")]
        public void WhenClickOnFilterOptionOnTilePage()
        {
            importClaims.ClickTwoTileFilter();
        }

        [Then(@"Filter with '(.*)' as '(.*)'")]
        public void SelectFilterOptions(string field,string option)
        {
            importClaims.SelectFilterOptions(field,option);
        }
        [Then(@"I click on checkbox on tile")]
        public void ThenIClickOnCheckboxOnTile()
        {
            importClaims.ClickOnCheckBox();
        }

        [When(@"I Select the PageSize as '(.*)' under Pagination Section in import dates page '(.*)' in table '(.*)'")]
        [When(@"I Select the PageSize as '(.*)' under Pagination Section in import claims page '(.*)' in table '(.*)'")]
        public void SelectPageSize(int pageSize,string xpath,int count)
        {          
            importClaims.SelectPageSize(pageSize,xpath,count);
        }
        [Then(@"verify the data on Assets Import Page")]
        public void VerifyAssetsData()
        {
            importClaims.VerifyAssetsData();
        }
        [Then(@"verify the data on the grid with default page size '(.*)' with status '(.*)'")]
        public void VerifyDataOnGrid(int pageSize,string status)
        {
            importClaims.VerifyDataOnGrid(pageSize,status);
        }
       [When(@"I '(.*)' Filter option")]
       [When(@"I click '(.*)' Filter option")]
        public void ClickFilterOption(string option)
        {
            importClaims.ClickFilterOption(option);
        }
        [Then(@"'(.*)' should be able sorted")]
        public void ThenShouldBeAbleSorted(string columnName)
        {
 
            var list = importClaims.GetSortedList(columnName);
            list.Should().BeInDescendingOrder();
           list = importClaims.GetSortedList(columnName);
            list.Should().BeInAscendingOrder();
            
        }
        [Then(@"select View Documents Tab")]
        public void SelectViewDocumentsTab()
        {
            importClaims.SelectTabViewDocuments();
        }
        [Then(@"verify the pagination and navigation '(.*)' and '(.*)'")]
        public void PaginationAndNavigationToPages(int count,string section)
        {   
            importClaims.VerifyPaginationAndNavigation(count,section);
        }
        [When(@"I click on claims for case '(.*)'")]
        public void ClickClaims(string caseNo)
        {
            importClaims.ClickClaim(caseNo);
        }
        [When(@"I see the Claims Table Rows as per Selected (.*) and '(.*)' in table '(.*)'")]    
        public void verifyClaimsTablePageSize(int pageSize,string xpath,int count)
        {
            importClaims.VerifyRowsLength(pageSize,xpath,count);
        }
        [Then(@"verify the message displayed on table as '(.*)'")]
        public void VerifyMessageOnTable(string message)
        {
            importClaims.VerifyMessageOnTable(message);
        }
        [Then(@"I see '(.*)' and '(.*)' options in Enabled")]
        public void IsVerifyEnabled(string label1, string label2)
        {
            importClaims.VerifyEnabled(label1, label2);
        }
        [When(@"I select claim to delete for creditor '(.*)'")]
        public void SelectClaimtoDelete(string creditorName)
        {
            importClaims.SelectClaimToDelete(creditorName);
        }
        [When(@"I click delete")]
        public void claimDeletetion()
        {
            importClaims.ClickDeleteClaim();
        }
        [When(@"I select claim to Import for creditor '(.*)'")]
        [When(@"I select claim to Ignore for creditor '(.*)'")] 
        public void SelectClaimToImportOrIgnore(string creditorName)
        {
            importClaims.SelectClaimToImportOrIgnore(creditorName);
        }
        [When(@"I click import '(.*)'")]
        [When(@"I click ignore '(.*)'")]
       
        public void ClaimImportOrIgnore(string option)
        {
            importClaims.ClickImportOrIgnoreClaim(option);
        }
        [Then(@"I click Restore '(.*)'")]
        public void ClaimImportRestore(string option)
        {
            importClaims.ClickImportRestore(option);
        }
        [Then(@"verify the header '(.*)'")]
        public void VerifyHeader(string header)
        {
            importClaims.VerifyHeader(header);
        }
        [Then(@"verify the case header '(.*)'")]
        public void verifytheCaseHeader(string caseHeader)
        {
            importClaims.VerifyCaseHeader(caseHeader);
        }
        [Then(@"verify the subheader '(.*)'")]
        public void VerifyTheSubHeader(string subHeader)
        {
            importClaims.VerifyTheSubHeader(subHeader);
        }
        [Then(@"click on expand symbol and verify the columns on '(.*)' as '(.*)' in table '(.*)'")]
        public void VerifyColumnsExpand(string page, string columns,int count)
        {
            var inputEntries = columns.Split(';').Select(i => i.Trim()).ToList();
            importClaims.ClickColumnsExpandIcon(inputEntries, page,count);
        }
        [Then(@"verify the display and navigation to Assets tab on Claims page")]
        public void VerifyAssetsNavigation()
        {
            importClaims.VerifyAssetsNavigation();
        }
        [Then(@"click on Next")]
        public void ClickNext()
        {
            importClaims.ClickNextOnHeader();
        }      
        [Then(@"verify the display of Assets button on Import Management page")]
        public void DisplayAssetsButton()
        {
            importClaims.DisplayAssetsButton();
        }
        [When(@"I click on settings icon")]
        public void ClickSettingsIcon()
        {
            importClaims.ClickSettingsIcon();
        }
        [Then(@"verify the sections displayed '(.*)'")]
        public void VerifyTheSections(string sectionHeaders)
        {
            var inputEntries = sectionHeaders.Split(';').Select(sectionName => sectionName.Trim()).ToList();
            importClaims.VerifySections(inputEntries);
        }       
        [Then(@"verify the expand functionality on '(.*)' section '(.*)'")]
        public void ExpandSectionByClick(string sectionHeaders,string sectionLabels)
        {
            var sectionHeaderList = sectionHeaders.Split(';').Select(sectionName => sectionName.Trim()).ToList();
            var sectionLabelsList = sectionLabels.Split(';').Select(sectionName => sectionName.Trim()).ToList();
            importClaims.ExpandSectionByClick(sectionHeaderList, sectionLabelsList);                    
        }
        [Then(@"verify the options displayed in '(.*)' section as '(.*)'")]
        public void VerifyAndClickCheckBoxOptions(string sectionHeader, string CheckBoxes)
        {
            var sectionCheckBoxList = CheckBoxes.Split(';').Select(sectionName => sectionName.Trim()).ToList();
            importClaims.ClickCheckBox(sectionCheckBoxList);
        }
        [Then(@"verify the labels displayed on '(.*)' section '(.*)'")]
        public void VerifyLabels(string sectionHeaders, string sectionLabels)
        {
            var sectionHeaderList = sectionHeaders.Split(';').Select(sectionName => sectionName.Trim()).ToList();
            var sectionLabelsList = sectionLabels.Split(';').Select(sectionName => sectionName.Trim()).ToList();
            importClaims.VerifyLabels(sectionHeaderList, sectionLabelsList);
        }
        [Then(@"select data from '(.*)' section '(.*)' as '(.*)'")]
        public void SelectData(string sectionHeader, string sectionLabels,String amount)
        {
            var amountList = amount.Split(';').Select(amountValue => amountValue.Trim()).ToList();
            var sectionLabelsList = sectionLabels.Split(';').Select(sectionName => sectionName.Trim()).ToList();           
            importClaims.SelectData(sectionHeader, sectionLabelsList, amountList);
        }
        [Then(@"I save the settings")]
        public void Save()
        {
             importClaims.ClickSave();
        }
        [When(@"I Click on Date Link Under Imported Dates")]
        public void WhenIClickOnDateLinkUnderImportedDates()
        {
            importClaims.ClickOnDocumentNumberToImportLink();
        }
        [Then(@"Verify Navigation and Pagination display")]
        public void ThenVerifyNavigationAndPaginationDisplay()
        {
            importClaims.VerifyPaginationAndNavigations();            
        }
    }
}
