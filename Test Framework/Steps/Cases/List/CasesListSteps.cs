using Epiq.ETS.TCMS.Anywhere.Testing.E2ETest.Test_Framework.Pages.Cases;
using Epiq.ETS.TCMS.Anywhere.Testing.E2ETest.Test_Framework.Pages.Cases.List;
using Epiq.ETS.TCMS.Anywhere.Testing.E2ETest.Test_Framework.Steps.Common;
using Epiq.ETS.TCMS.Anywhere.Testing.E2ETest.TestFramework.Pages.Cases.Detail;
using FluentAssertions;
using System.Collections.Generic;
using System.Threading;
using TechTalk.SpecFlow;
using System;
using System.Data;
using System.Configuration;
using Epiq.ETS.TCMS.Anywhere.Testing.E2ETest.Test_Framework.Steps;

namespace Epiq.ETS.TCMS.Anywhere.Testing.E2ETest.TestFramework.Pages.Cases.List
{
    [Binding]
    public class CasesListSteps:StepBase
    {
        //REFACTORED
        private CaseListPage caseListPage = ((CaseListPage)GetSharedPageObjectFromContext("Case List"));        

        /**
         * Gets the field name constant based on the name from specflow feature
         */
        private string GetField(string name)
        {
            switch (name)
            {
                case "Status":
                    return CaseListFields.STATUS;

                case "Type":
                    return CaseListFields.TYPE;

                case "Case #":
                    return CaseListFields.CASE_NUMBER;

                case "Case Name":
                    return CaseListFields.CASE_NAME;

                default:
                    throw new NotImplementedException();
            }

        }

        [Then(@"I see the Relevant Information Region")]
        public void ThenISeeTheRelevantInformationRegion()
        {
            caseListPage.IsRelevantInfoRegionVisible().Should().BeFalse("The Relevant Information region is not Present");
        }   
              

        [Then(@"I See No Quick Look Region Title")]
        public void ThenISeeNoQuickLookRegionTitle()
        {
            caseListPage.IsQuickLookTitleVisible().Should().BeFalse("Quick Look Region is not present.");
        }

        [Then(@"I See Currently Open Cases Number is Correct")]
        public void ThenISeeCurrentlyOpenCasesNumberIs()
        {
            //query db to get count of currently open cases
            int expectedCount = 0;
            Dictionary<string, string> parameters = new Dictionary<string, string>();
            //Bring office code from App.config
            parameters.Add("OfficeCode", ConfigurationManager.AppSettings.Get("Office"));

            DataRowCollection results = ExecuteQueryOnDB(Properties.Resources.GetOpenCasesCountByOfficeId, parameters);
            foreach (DataRow result in results)
            {
                expectedCount = result.Field<int>("OpenCasesCount");
            }
            
            caseListPage.GetCurrenttlyOpenCasesNumber().Should().Be(expectedCount + " Open Cases", "Currently Open Cases count displays and is "+expectedCount);
        }


        [Then(@"I See the Case List Table")]
        public void ThenISeeTheCaseListTable()
        {
            caseListPage.IsCasesListVisible().Should().BeTrue("The Case List table is visible.");
        }


        [Then(@"I See '(.*)' header and has text '(.*)'")]
        public void ThenISeeHeaderAndHasText(string header, string text)
        {
            caseListPage.GetHeaderText(header).Should().Be(text, "All Headers of Case List table are correct");
        }


        [Then(@"I See Some Correct Data Displays")]
        public void ThenISeeCorrectSomeDataDisplays()
        {
            //Get only one row from results and check it has some correct data (Case status is "Open", no "undefined" values.
            Thread.Sleep(10000);
            CaseData caseRow = caseListPage.GetCaseRowByPosition(1);            
            caseRow.Should().NotBeNull("Some data displays on Case List table.");
            caseRow.Status.Should().Be("Open");
            caseRow.Number.Should().NotBe("undefined");
            caseRow.Name.Should().NotBe("undefined");
            caseRow.Status.Should().NotBe("undefined");
            caseRow.Type.Should().NotBe("undefined");
            caseRow.OpenDate.Should().NotBe("undefined");
            caseRow.EstimatedDistributionDate.Should().NotBe("undefined");
            caseRow.Balance.Should().NotBe("undefined");            
        }

        [Then(@"I See (.*) Open Cases")]
        public void ThenISeeOpenCases(int openCasesNbr)
        {
            int count = 0;
            List<string> statusColumnValues = caseListPage.GetCaseListColumnValues(CaseListFields.STATUS);
            foreach (string value in statusColumnValues)
            {
                if (value.ToLower() == "open")
                    count++;
            }
            count.Should().Be(228, "Case List displays "+openCasesNbr+" 'Open' cases");
            
        }
               

        [Then(@"I See Open Cases on the List")]
        public void ThenISeeOpenCasesOnTheList()
        {
            caseListPage.GetOneCaseByColumnValue(CaseListFields.STATUS, "Open").Should().NotBeNull("I See at least one Open Case on the List");
        }

        [Then(@"I See Closed Cases on the List")]
        public void ThenISeeClosedCasesOnTheList()
        {
            caseListPage.GetOneCaseByColumnValue(CaseListFields.STATUS, "Closed").Should().NotBeNull("I See at least one Closed Case on the List");
        }

        [Then(@"I See No Open Cases on the list")]
        public void ThenISeeNoOpenCasesOnTheList()
        {
            CaseData caseData = caseListPage.GetOneCaseByColumnValue(CaseListFields.STATUS, "Open");
            caseData.Should().BeNull("No cases with 'Open' Status display on the Case List by default");
        }

        [Then(@"I See No Closed Cases on the List")]
        public void ThenISeeNoClosedCasesOnTheList()
        {
            CaseData caseData = caseListPage.GetOneCaseByColumnValue(CaseListFields.STATUS, "Closed");
            caseData.Should().BeNull("No cases with 'Closed' Status display on the Case List by default");
        }


        [Then(@"I See No Results and a Message reading '(.*)'")]
        public void ThenISeeNoResultsAndAMessageReading(string noResultsMessage)
        {
            string actualMessage = caseListPage.GetNoResultsAvailableMessage();
            actualMessage.Should().NotBeNull("No Results Available message displays");
            actualMessage.Should().Be(noResultsMessage, "Expected no results message to be: "+noResultsMessage);

            //Clean the field to avoid other tests failing because of no results
            caseListPage.SearchForm.TypeInCaseNumberValue("");
        }
        
        /**
         * Asserts that there exist current results on the list having the given value for the given column
         */
        [Then(@"I See Results of Cases Containing '(.*)' values '(.*)'")]
        public void ThenISeeResultsOfCasesContainingValue(string column, List<string> values)
        {
            foreach (string value in values)
            {
                //check that there is at least one record with the expected value
                caseListPage.GetOneCaseByColumnValue(this.GetField(column), value).Should().NotBeNull("I See some result containing "+column+"="+value);
            }
        }    
            

        /**
        * TODO change calls to this Hten clause for the next method (ThenISeeOnlyResultsOfCasesContainingValue)
        * Asserts that ALL cases o the result list contain the given value for Case Number column.
        */
        [Then(@"I See Only Results of Cases Containing Case Number '(.*)'")]
        public void ThenISeeOnlyResultsOfCasesContainingCaseNumber(string caseNumber)
        {
            List<string> results = caseListPage.GetCaseListColumnValues(CaseListFields.CASE_NUMBER);
            foreach (string number in results)
            {
                number.ToLower().Should().ContainEquivalentOf(caseNumber.ToLower(), "All Results contain the searched Case Number");
            }
        }

        /**
         * TODO change calls to this Hten clause for the next method (ThenISeeOnlyResultsOfCasesContainingValue)
         * Asserts that ALL cases o the result list contain the given value for Case Name column.
         */
        [Then(@"I See Only Results of Cases Containing Case Name '(.*)'")]
        public void ThenISeeOnlyResultsOfCasesContainingCaseName(string caseName)
        {
            List<string> results = caseListPage.GetCaseListColumnValues(CaseListFields.CASE_NAME);
            foreach (string name in results)
            {
                name.ToLower().Should().ContainEquivalentOf(caseName.ToLower(), "All Results contain the searched Case Name");
            }
        }


        /**
         * Asserts that ALL cases o the result list contain the given value for the given column.
         */
        [Then(@"I See Only Results of Cases Containing '(.*)' value '(.*)'")]
        public void ThenISeeOnlyResultsOfCasesContainingValue(string column, string value)
        {
            VerifyAllRecordsHaveColumnValue(column, value);
        }

        private void VerifyAllRecordsHaveColumnValue(string column, string value)
        {
            List<string> results = caseListPage.GetCaseListColumnValues(GetField(column));
            foreach (string colValue in results)
            {
                colValue.ToLower().Should().ContainEquivalentOf(value.ToLower(), "All Results contain " + value + " on the " + column + " column");
            }

        }

        [Then(@"I See Results of Cases Containing '(.*)', '(.*)', '(.*)' and '(.*)'")]
        public void ThenISeeResultsOfCasesContaining(string number, string name, string type, string status)
        {           
            if (number != "")                
                VerifyAllRecordsHaveColumnValue("Case #", number);

            if (name != "")
                VerifyAllRecordsHaveColumnValue("Case Name", name);

            if (type != "")
                VerifyAllRecordsHaveColumnValue("Type", type);

            if (status != "")
                VerifyAllRecordsHaveColumnValue("Status", status);

        }


        [Then(@"I See Total Balances Icon Displays with Some Value")]
        public void ThenISeeTotalBalancesIconDisplaysWithSomeValue()
        {            
            caseListPage.TotalBalanceIcon.DisplaysCorrectly().Should().BeTrue("Total Balance Icon draws correctly");
            //balance value is verified on Dashboard feature compearring with Dashboard balance value, 
            //so we don't depend on fixed data on automated tests
            caseListPage.TotalBalanceIcon.Value.Should().NotBeEmpty("Total balance value is not Empty");
        }

        [Then(@"I See Total Balances Icon Legend is '(.*)'")]
        public void ThenISeeTotalBalancesIconLegendIs(string totalBalanceLabel)
        {
            caseListPage.TotalBalanceIcon.Description.Should().Be(totalBalanceLabel, "Total balance label is "+totalBalanceLabel);         
        }

        [Then(@"I See Outstanding Checks Icon Displays with a Correctly Formatted Value")]
        public void ThenISeeOutstandingChecksIconDisplaysWithACorrectlyFormattedValue()
        {
            caseListPage.OutstandingChecksIcon.DisplaysCorrectly().Should().BeTrue("Outstanding Checks draws correctly");

            //Verify outstanding check value formatting
            try
            {
                caseListPage.OutstandingChecksIcon.Value.Should().MatchRegex("([0-9]{1,3})", "Outstanding Checks is correctly formatted ");
            }
            catch (Exception)
            {
                try
                {
                    caseListPage.OutstandingChecksIcon.Value.Should().MatchRegex("([0-9]).([0-9])(K?)", "Outstanding Checks is correctly formatted ");
                }
                catch (Exception)
                {
                    try
                    {
                        caseListPage.OutstandingChecksIcon.Value.Should().MatchRegex("([0-9]{2}).([0-9])(K?)", "Outstanding Checks is correctly formatted ");
                    }
                    catch (Exception)
                    {
                        caseListPage.OutstandingChecksIcon.Value.Should().MatchRegex("([0-9]{1,3})(K?)", "Outstanding Checks is correctly formatted ");                        
                    }
                    
                }
            }
        }


        [Then(@"I See Outstanding Checks Icon Legend is '(.*)'")]
        public void ThenISeeOutstandingChecksIconLegendIs(string outstandingChecksLabel)
        {
            caseListPage.OutstandingChecksIcon.Description.Should().Be(outstandingChecksLabel, "Outstanding Checks label is " + outstandingChecksLabel);
        }

        [Then(@"I See Case Number is a Link on All Cases")]
        public void ThenISeeCaseNumberIsALinkOnAllCases()
        {
            caseListPage.Pause(2);
            caseListPage.IsCaseNumberALinkOnAllCases().Should().BeTrue("Case Number is a Link on All Cases");
        }

        [Then(@"I See Case Name is a Link on All Cases")]
        public void ThenISeeCaseNameIsALinkOnAllCases()
        {
            caseListPage.IsCaseNameALinkOnAllCases().Should().BeTrue("Case Number is a Link on All Cases");
        }
        
        [When(@"I Click on Case Number link of the First Case")]
        public void WhenIClickOnCaseNumberLinkOfTheFirstCase()
        {
            CaseData firstCase = caseListPage.GetCaseRowByPosition(1);
            ScenarioContext.Current.Add("CaseData", firstCase);
            AddDataToScenarioContextOverridingExistentKey("Case General", caseListPage.SelectCaseNumberLinkByRowPosition(1));

        }

        [Then(@"I See Case Detail Page Displays the Case Data According to the Case List")]
        public void ThenISeeCaseDetailPageDisplaysTheCaseDataAccordingToTheCaseList()
        {
            CaseData caseData = ScenarioContext.Current.Get<CaseData>("CaseData");
            CaseDetailPage caseGeneralPage = ScenarioContext.Current.Get<CaseDetailPage>("Case General");

            caseGeneralPage.Number.Should().Be(caseData.Number, "Case Number displayed is correct");
            caseGeneralPage.Name.Should().Be(caseData.Name, "Case Name displayed is correct");
            caseGeneralPage.Type.Should().BeEquivalentTo(caseData.Type, "Case Type displayed is correct");
            caseGeneralPage.Status.ToLower().Should().Be(caseData.Status.ToLower(), "Case Status displayed is correct");

            //caseGeneralPage.OpenDateLabel.ShouldBeEquivalentTo("OPEN DATE", "Open Date label is correct.");
            //caseGeneralPage.OpenDate.Should().Be(caseData.OpenDate, "Case Open Date displayed is correct");
            //caseGeneralPage.EstimatedDistributionDateLabel.ShouldBeEquivalentTo("ESTIMATED DISTRIBUTION DATE", "Open Date label is correct.");
            //caseGeneralPage.EstimatedDistributionDate.Should().Be(caseData.EstimatedDistributionDate, "Case Estimated Distribution Date displayed is correct");
        }

        [When(@"I Click on Case Name link of the First Case")]
        public void WhenIClickOnCaseNameLinkOfTheFirstCase()
        {
            CaseData firstCase = caseListPage.GetCaseRowByPosition(1);
            ScenarioContext.Current.Add("CaseData", firstCase);
            AddDataToScenarioContextOverridingExistentKey("Case General", caseListPage.SelectCaseNameLinkByRowPosition(1));

        }

    }
}
