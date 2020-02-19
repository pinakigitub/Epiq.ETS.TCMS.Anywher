using Epiq.ETS.TCMS.Anywhere.Testing.E2ETest.Test_Framework.Pages.DashboardExtendNoData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace Epiq.ETS.TCMS.Anywhere.Testing.E2ETest.Test_Framework.Steps.DashboardExtendNoData
{
    [Binding]
    class TrusteeVisibilitySteps:StepBase
    {
        TrusteeVisibilityPage trusteepage = new TrusteeVisibilityPage(driver);
        [Then(@"I verify the DSO record with Claimant Name as '(.*)' and '(.*)'")]
        [Then(@"I verify the Banking record with Account No as '(.*)','(.*)'")]
        [Then(@"I verify the Tasks record with Debtor Name as '(.*)' and '(.*)'")]
        [Then(@"I verify the Checks record with Case# as '(.*)' and '(.*)'")]
        [Then(@"I verify the ReceiptLog record with Received from as '(.*)' and '(.*)'")]
        [Then(@"I verify the Claims record with Received from as '(.*)' and '(.*)'")]
        [Then(@"I verify the Activity record with Account#  as '(.*)' and '(.*)'")]

        public void VerifyRecord(string search,string num)
        {
           trusteepage.VerifyDataonUIGrid(search,num);
        }
        [Then(@"Verify DB count from UI AND DB '(.*)'")]
        public void DBandUIcount(string page)
        {
            trusteepage.DBQueryMethod(page);
        }
        [Then(@"I Verify the Favorite record with Case No as '(.*)'")]
        public void ThenIVerifyTheFavoriteRecordWithCaseNoAs(string Num)
        {
            trusteepage.VerifyFavoriteCase(Num);
        }
        [When(@"I Verify Case section with Case Num '(.*)'")]
        public void WhenIVerifyCaseSectionWithCaseNum(string CaseNum)
        {
            trusteepage.VerifyCaseSection(CaseNum);
        }
    }
}
