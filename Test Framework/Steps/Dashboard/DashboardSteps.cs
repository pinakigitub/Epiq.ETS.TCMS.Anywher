using Epiq.ETS.TCMS.Anywhere.Testing.E2ETest.Test_Framework.Pages;
using Epiq.ETS.TCMS.Anywhere.Testing.E2ETest.Test_Framework.Steps;
using Epiq.ETS.TCMS.Anywhere.Testing.E2ETest.Test_Framework.Steps.Common;
using Epiq.ETS.TCMS.Anywhere.Testing.E2ETest.Test_Framework.Core;
using FluentAssertions;
using System;
using System.Configuration;
using TechTalk.SpecFlow;

namespace Epiq.ETS.TCMS.Anywhere.Testing.E2ETest
{
    [Binding]
    public class DashboardSteps:StepBase
    {
        //REFACTORED
        private DashboardPage dashboardPage = ((DashboardPage)GetSharedPageObjectFromContext("Dashboard"));

        [Then(@"I See The Office Name On The Application Bar")]
        public void GivenISeeTheOfficeNameOnTheApplicationBar()
        {            
            var office = ConfigurationManager.AppSettings.Get("OfficeName");
            dashboardPage.UniversalApplicationBar.OfficeName.Should().Be(office,"Office name corresponds to the logged in user office");
        }

        [Then(@"I See The Welcome Message For My User")]
        public void GivenISeeTheWelcomeMessageForMyUser()
        {
            var user = ConfigurationManager.AppSettings.Get("user");
            dashboardPage.WelcomeMessageIntroduction.Should().Be("Welcome","User greeting starts with 'Welcome'");
            dashboardPage.UserNameOnWelcomeMessage.Should().Be(user, "User greeting name corresponds to the logged in user");
        }

        [Then(@"I See Court Icon With the Balance Value And No Formatting")]
        public void GivenISeeCourtIconWithTheBalanceValueAndNoFormatting()
        { 
            dashboardPage.IsCourtIconPresent().Should().BeTrue("Court Icon is present");
            dashboardPage.BalanceLabel.Should().Be("Balance", "Balance Label displays correctly");
            string balance = dashboardPage.Balance;
            balance.Should().MatchRegex("\\$([0-9]*),?([0-9]*)(\\.[0-9][0-9])?", "Balance value format is correct");

            ScenarioContext.Current.Add("Dashboard Balance", balance);
        }

        [Then(@"I See The Gavel Icon With The Number of Open Cases")]
        public void GivenISeeTheGavelIconWithTheNumberOfOpenCases()
        {
            dashboardPage.IsGavelIconPresent().Should().BeTrue("Gavel Icon is present");
            dashboardPage.OpenCasesLabel.Should().Be("Open Cases", "Open Cases Label displays correctly");
            string openCases = dashboardPage.OpenCases;
            openCases.Should().MatchRegex("([0-9]*),?([0-9]*)", "Open Cases value format is correct");

            ScenarioContext.Current.Add("Dashboard Open Cases", openCases);
        }

        [Then(@"I Click On Open Cases To Navigate to Case List Page")]
        public void ThenIClickOnOpenCasesToNavigateToCaseListPage()
        {
            CaseListPage caseListPage = dashboardPage.ClickOpenCasesLink();                
            SetSharedPageObjectInCurrentContext("Case List", caseListPage);
        }

        [Then(@"I See The Formatted Total Balance Corresponds To Dashboard Balance Value")]
        public void ThenISeeTheFormattedTotalBalanceCorrespondsToDashboardBalanceValue()
        {
            string balance = ScenarioContext.Current.Get<string>("Dashboard Balance");
            CaseListPage caseListPage = ((CaseListPage)GetSharedPageObjectFromContext("Case List"));
            caseListPage.TotalBalanceIcon.Value.Should().Be(this.GetFormattedBalance(balance), "Case List Balance corresponds with Dashboard's");
        }

        private string GetFormattedBalance(string balance)
        {
            //only positives for now
            string retBalance="";
            balance = balance.Replace("$", "");
            double balanceNbr = Convert.ToDouble(balance);
            double dividend = balanceNbr;
            int thousandsPow = 0;
            while (dividend >= 1000) {
                thousandsPow++;
                dividend = dividend / 1000;
            }
                        
            retBalance = "$" ;

            if (thousandsPow == 0)
            {
                retBalance += balance;
            }            
            else if (thousandsPow == 2)
                {
                   retBalance += Math.Floor(dividend)+ "M";
                }
                else if(thousandsPow == 1)
                    {
                        retBalance += Math.Floor(dividend) + "K";
                    }
                    else if (thousandsPow >= 3)
                        {
                            retBalance = "MAX";
                        }


            return retBalance;
        }

        [Then(@"I See The Open Cases Correspond To Dashboard Open Cases Value")]
        public void ThenISeeTheOpenCasesCorrespondToDashboardOpenCasesValue()
        {
            string openCases = ScenarioContext.Current.Get<string>("Dashboard Open Cases");
            CaseListPage caseListPage = ((CaseListPage)GetSharedPageObjectFromContext("Case List"));
            caseListPage.GetCurrenttlyOpenCasesNumber().Should().Be(openCases+" Open Cases", "Case List Open Cases corresponds with Dashboard's");
        }

        [When(@"I Click on Top User Icon")]
        public void WhenIClickOnTopUserIcon()
        {
            dashboardPage.ClickOnUserIcon();
        }
        [When(@"I click on change password")]
        public void WhenIClickOnChangePassword()
        {
            dashboardPage.ClickOnChangePassword();
        }
        [When(@"I Enter the Old Password '(.*)'")]
        public void WhenIEnterTheOldPassword(string oldPwd)
        {
            dashboardPage.EnterOldPassword(oldPwd);
        }
        [When(@"I Enter the New Password '(.*)'")]
        public void WhenIEnterTheNewPassword(string newPwd)
        {
            dashboardPage.EnterNewPassword(newPwd);
        }
        [Then(@"Validate all password conditions are satisfied")]
        public void ThenValidateAllPasswordConditionsAreSatisfied()
        {
            dashboardPage.VerifyDangerExist().Should().BeFalse();
        }
        [Then(@"I click on Cancel Button of Change password")]
        public void ThenIClickOnCancelButtonOfChangePassword()
        {
            dashboardPage.ClickOnChangePasswordCalcelButton();
        }
        [Then(@"Validate password conditions are not satisfied completly")]
        public void ThenValidatePasswordConditionsAreNotSatisfiedCompletly()
        {
            dashboardPage.VerifyDangerExist().Should().BeTrue();
        }
        [Then(@"I clear the New Password Field")]
        public void ThenIClearTheNewPasswordField()
        {
            dashboardPage.ClearNewPassword();
        }
        [Then(@"Verify all fields are required")]
        public void ThenVerifyAllFieldsAreRequired()
        {
            dashboardPage.ValidateAllAreRequiredFields();
        }
        [When(@"I search and select case '(.*)' from Top search")]
        public void WhenISearchAndSelectCaseFromTopSearch(string caseNo)
        {
            dashboardPage.SelectCaseNumberFromTopSearch(caseNo);
        }
        //[When(@"I click on Past Meeting date link")]
        //public void WhenIClickOnPastMeetingDateLink()
        //{
        //    dashboardPage.ClickOnPast341MeetingDate();
        //}
        [When(@"I click on the Past Meeting date link")]
        public void WhenIClickOnThePastMeetingDateLink()
        {
            dashboardPage.ClickOnPast341MeetingDate();
        }

        [When(@"I click on Upcoming Meeting date link")]
        public void WhenIClickOnUpcomingMeetingDateLink()
        {
            dashboardPage.ClickOnUpcoming341MeetingDate();
        }
        [When(@"I select '(.*)' from trustee dropdown on UpcomingMeeting Tile")]
        public void WhenISelectFromTrusteeDropdownOnUpcomingMeetingTile(string trustee)
        {
            dashboardPage.SelectTrustee_ON_UpcomingMeeting(trustee);
        }

        [Then(@"I see No Data for selected trustee on Tile")]
        public void ThenISeeNoDataForSelectedTrusteeOnTile()
        {
            dashboardPage.Is_NoneDataMessage_Displayed().Should().BeTrue();
        }
        [Then(@"I see Data for selected trustee on Tile")]
        public void ThenISeeDataForSelectedTrusteeOnTile()
        {
            dashboardPage.Is_UpcomingDataPanel_Displayed().Should().BeTrue();
        }
        [When(@"I select '(.*)' from trustee dropdown on Past Meeting Tile")]
        public void WhenISelectFromTrusteeDropdownOnPastMeetingTile(string trustee)
        {
            dashboardPage.SelectTrustee_ON_PastMeeting(trustee);
        }

        [Then(@"I see Data for selected trustee on Past Meeting Tile")]
        public void ThenISeeDataForSelectedTrusteeOnPastMeetingTile()
        {
            dashboardPage.Is_PastMeetingDataGraph_Displayed();
        }
        [When(@"I click on DSO Summary record link")]
        public void WhenIClickOnDSOSummaryRecordLink()
        {
            dashboardPage.ClickOnDSO_Summary_Record();
        }
        [When(@"I Click on Quantity displaying for Deposits Outstanding in Bank Summary tile")]
        public void WhenIClickOnQuantityDisplayingForDepositsOutstandingInBankSummaryTile()
        {
            dashboardPage.ClickOnDepositsOutstandingQuantity();
        }


    }
}
