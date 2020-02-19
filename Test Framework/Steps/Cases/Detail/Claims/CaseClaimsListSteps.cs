using Epiq.ETS.TCMS.Anywhere.Testing.E2ETest.Test_Framework.Core;
using Epiq.ETS.TCMS.Anywhere.Testing.E2ETest.Test_Framework.Steps.Common;
using Epiq.ETS.TCMS.Anywhere.Testing.E2ETest.TestFramework.Pages.Cases.Detail;
using Epiq.ETS.TCMS.Anywhere.Testing.E2ETest.TestFramework.Pages.Cases.List;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Data;
using System.Security.Claims;
using TechTalk.SpecFlow;

namespace Epiq.ETS.TCMS.Anywhere.Testing.E2ETest.Test_Framework.Steps.Cases.Detail.Claims
{
    [Binding]
    public class CaseClaimsListSteps:StepBase
    {
        //REFACTORED
        private CaseDetailPage caseDetailPage = ((CaseDetailPage)GetSharedPageObjectFromContext("Case Detail"));        
        private ClaimsDetailTab claimsTab = ((ClaimsDetailTab)GetSharedPageObjectFromContext("Claims Tab"));

        [Then(@"I See Claims Icon Count Matches the Total of Claims on the List")]
        public void ThenISeeClaimsIconCountMatchesTheTotalOfClaimsOnTheList()
        {
            int claimsIconValue = Convert.ToInt32(caseDetailPage.ClaimsIcon.Value);
            claimsIconValue.Should().Be(claimsTab.GetClaimsCount(), "Claims Icon value matches the count of claims");
        }
        
        [Then(@"I See No Claims Display on the List And a Message Shows Reading '(.*)'")]
        public void ThenISeeNoClaimsDisplayOnTheListAndAMessageShowsReading(string noResultsMsg)
        {
            claimsTab.IsResultsListEmpty().Should().BeTrue("No results display on Claims list");
            claimsTab.GetNoResultsMessage().Should().Be(noResultsMsg,"No results message is displayed and correct");
        }
        
        [Then(@"I See Claims Display on the List With Valid Data In Order")]
        public void ThenISeeClaimsDisplayOnTheListWithValidDataInOrder()
        {
            Dictionary<string, string> parameters = new Dictionary<string, string>();
            parameters.Add("CaseId", Convert.ToString(CaseDetailSteps.GetCaseIdFromCaseNumber(ScenarioContext.Current.Get<string>("Case Number"))));
            parameters.Add("OfficeId", Convert.ToString(CommonDBSteps.GetConfigOfficeId()));

            DataRowCollection expected = ExecuteQueryOnDB(Properties.Resources.GetClaimsDetailsByCaseId, parameters);
            
            IEnumerator<ClaimData> actualClaims = claimsTab.GetFirstNClaims(expected.Count).GetEnumerator();
            actualClaims.MoveNext();

            foreach (DataRow claimFromDB in expected)
            {
                ClaimData claim = actualClaims.Current;
                
                claim.ClaimNumber.Trim().Should().Be(claimFromDB.Field<string>("ClaimNumber").Trim(), "["+claim.Id+ "] Claim Number is correct");
                claim.CreditorName.Should().BeEquivalentTo(claimFromDB.Field<string>("CreditorName").TrimEnd(), "[" + claim.Id + "] Claim Creditor Name is correct");

                string status = claimFromDB.Field<string>("Status");
                claim.Status.Should().Be(status.ToUpper(), "[" + claim.Id + "] Claim Status is " + status);
                string statusColor = this.GetStatusColor(status);
                claim.CornerTagColor.Should().Be(statusColor, "[" + claim.Id + "] Claim Corner Tag Color is " + statusColor);
                string cornerTagLetter = this.getCornerTagLetter(status);
                claim.CornerTagLetter.Should().Be(cornerTagLetter, "[" + claim.Id + "] Claim Corner Tag Letter is " + cornerTagLetter);
                claim.StatusColor.Should().Be(statusColor, "[" + claim.Id + "] Claim Status Color is " + statusColor);

                string claimClass = claimFromDB.Field<string>("ClaimClass");
                claim.Class.Should().Be(claimClass, "[" + claim.Id + "] Claim Class is " + claimClass);
                string classColor = this.GetCircleClassColor(claimClass);
                claim.CircleIndicatorColor.Should().Be(classColor, "[" + claim.Id + "] Claim Circle Ind. Color is " + classColor);

                claim.Category.Should().Be(claimFromDB.Field<string>("Category"), "[" + claim.Id + "] Claim Category is correct");
                claim.Code.Should().Be(claimFromDB.Field<string>("Code"), "[" + claim.Id + "] Claim CODE is correct");
                claim.PaySequence.Should().Be(""+claimFromDB.Field<int>("PaySequence"), "[" + claim.Id + "] Claim Pay Sequence is correct");

                string expClaimedStr = this.GetClaimExpectedAmount(claimFromDB.Field<Decimal>("ClaimedAmount"));                
                claim.Claimed.Replace(",", "").Should().Be(expClaimedStr, "[" + claim.Id + "] Claim Claimed amount is correct");

                string expAllowedStr = this.GetClaimExpectedAmount(claimFromDB.Field<Decimal>("AllowedAmount"));                
                claim.Allowed.Replace(",", "").Should().Be(expAllowedStr, "[" + claim.Id + "] Claim Allowed amount is correct");

                string expPaidStr = this.GetClaimExpectedAmount(claimFromDB.Field<Decimal>("PaidAmount"));
                claim.Paid.Replace(",", "").Should().Be(expPaidStr, "[" + claim.Id + "] Claim Paid amount is correct");

                string expReservedStr = this.GetClaimExpectedAmount(claimFromDB.Field<Decimal>("ReservedAmount"));
                claim.Reserved.Replace(",", "").Should().Be(expReservedStr, "[" + claim.Id + "] Claim Reserved amount is correct");

                string expInterestStr = this.GetClaimExpectedAmount(claimFromDB.Field<Decimal>("Interest"));
                claim.Interest.Replace(",", "").Should().Be(expInterestStr, "[" + claim.Id + "] Claim Interest amount is correct");

                string expBalanceStr = this.GetClaimExpectedAmount(claimFromDB.Field<Decimal>("BalanceAmount"));
                claim.Balance.Replace(",", "").Should().Be(expBalanceStr, "[" + claim.Id + "] Claim Balance amount is correct");

                actualClaims.MoveNext();
            }
        }

        private string GetClaimExpectedAmount(decimal amount)
        {
            string expAmountStr = "";

            if (amount > 999999999)
                expAmountStr = "MAX";
            else
            {
                expAmountStr = Convert.ToString(amount);
                expAmountStr = "$" + expAmountStr.Substring(0, expAmountStr.Length - 2);
            }
            return expAmountStr;
        }

        private string getCornerTagLetter(string status)
        {
            if (status != "NULL")
                return Convert.ToString(status[0]).ToUpper();
            else
                return "";
        }

        private string GetCircleClassColor(string claimClass)
        {
            switch (claimClass)
            {
                case "Administrative":
                    return "ORANGE";
                case "Priority":
                    return "RED";
                case "Unsecured":
                    return "YELLOW";
                case "Secured":
                    return "PURPLE";
                case "Unknown":
                    return "";
                default:
                    throw new NotImplementedException();
            }
        }

        private string GetStatusColor(string status)
        {
            switch (status)
            {
                case "Valid To Pay":
                    return "GREEN";
                case "Objection Pending":
                    return "ORANGE";
                case "NULL":
                    return "ORANGE";
                default:
                    return "RED";
            }
        }
    }
}
