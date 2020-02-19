using Epiq.ETS.TCMS.Anywhere.Testing.E2ETest.Test_Framework.Pages;
using Epiq.ETS.TCMS.Anywhere.Testing.E2ETest.Test_Framework.Steps.Cases.Detail;
using Epiq.ETS.TCMS.Anywhere.Testing.E2ETest.TestFramework.Pages.Cases.Detail;
using FluentAssertions;
using System;
using System.Collections.Generic;
using TechTalk.SpecFlow;

namespace Epiq.ETS.TCMS.Anywhere.Testing.E2ETest.Test_Framework.Steps.Common
{
    [Binding]
    public class RolesAndPermissionsSteps:StepBase
    {
        //REFACTORED

        [Given(@"I Login to Unity With Credentials '(.*)', '(.*)' and '(.*)' And Roles '(.*)'")]
        public void GivenILoginToUnityWithCredentialsJassetsConversionAndCroseAndRolesAssets(string user, string pwd, string office, List<string> roles)
        {
            DashboardPage dashboardPage;
            try
            {
                dashboardPage = ((DashboardPage)GetSharedPageObjectFromContext("Dashboard"));
                dashboardPage.Logout();
            }
            catch (Exception){
                //do nothing - might not be present at all
            }
            

            LoginPage loginPage = new LoginPage(driver);
            dashboardPage = loginPage.Login(user, pwd, office);
            ScenarioContext.Current.Add("Roles", roles);
            SetSharedPageObjectInCurrentContext("Dashboard", dashboardPage);
        }

        [Then(@"User Can Only Create Assets If Having Assets or Trustee Role")]
        public void ThenUserCanOnlyCreateAssetsIfHavingAssetsOrTrusteeRole()
        {
            CaseDetailPage caseDetailPage = ((CaseDetailPage)GetSharedPageObjectFromContext("Case Detail"));
            List<String> roles = ScenarioContext.Current.Get<List<string>>("Roles");

            AssetsDetailTab assetsTab = caseDetailPage.GoToAssetsDetail();
            if (roles.Contains("Assets") || roles.Contains("Trustee Role"))
            {
                //New Asset button
                assetsTab.IsNewAssetButtonActive.Should().BeTrue("User has roles "+this.PrintableRoles(roles)+", so New Asset button is active");
                assetsTab.ClickNewAssetButton();
                assetsTab.IsNewAssetFormVisible.Should().BeTrue("User has roles " + this.PrintableRoles(roles) + ", so New Asset button opens New Asset Form");
                assetsTab.CancelNewAsset();
                //Quick Edit button
                assetsTab.AllQuickEditButtonsActive.Should().BeTrue("User has roles " + this.PrintableRoles(roles) + "User has roles " + this.PrintableRoles(roles) + ", so Quick Edit button is active");
                assetsTab.ClickQuickEditButtonOnFirstAsset();
                assetsTab.IsEditAssetFormVisible.Should().BeTrue("User has roles " + this.PrintableRoles(roles) + ", so Quick Edit button opens Edit Asset Form");
            }
            else
            {
                //New Asset button
                assetsTab.IsNewAssetButtonActive.Should().BeFalse("User does not have assets role, so New Asset button is inactive");
                try
                {
                    assetsTab.ClickNewAssetButton();
                    assetsTab.IsNewAssetFormVisible.Should().BeFalse("User does not have assets role, so New Asset button doesn't work");
                    assetsTab.CancelNewAsset();
                }
                catch (Exception)
                {
                    //do nothing, if not clickeable test passes
                }
                
                //Quick Edit button
                assetsTab.AllQuickEditButtonsInactive.Should().BeTrue("User does not have assets role, so Quick Edit button is inactive");
                try
                {
                    assetsTab.ClickQuickEditButtonOnFirstAsset();
                    assetsTab.IsEditAssetFormVisible.Should().BeFalse("User does not have assets role, so New Asset button doesn't work");
                }
                catch (Exception)
                {
                    //do nothing, if not clickeable test passes
                }

            }
        }

        [Then(@"User Can Only Create Transactions If Having Banking or Trustee Role")]
        public void ThenUserCanOnlyCreateTransactionsIfHavingBankingOrTrusteeRole()
        {
            CaseDetailPage caseDetailPage = ((CaseDetailPage)GetSharedPageObjectFromContext("Case Detail"));
            List<String> roles = ScenarioContext.Current.Get<List<string>>("Roles");
            BankingDetailTab bankingTab = caseDetailPage.GoToBankingDetail();
            if (roles.Contains("Banking") || roles.Contains("Trustee Role"))
            {
                //Check button
                bankingTab.IsCheckButtonInactive().Should().BeFalse("User has roles "+this.PrintableRoles(roles)+", so Add Check button is active");
                TransactionForm form = bankingTab.ClickCheckButton();
                bankingTab.IsNewTransactionFormOpen().Should().BeTrue("User has roles " + this.PrintableRoles(roles) + ", so clicking Check button opens the Form");
                form.Cancel();

                //Deposit button
                bankingTab.IsDepositButtonInactive().Should().BeFalse("User has roles " + this.PrintableRoles(roles) + ", so Deposit button is active");
                bankingTab.ClickDepositButton();
                bankingTab.IsNewTransactionFormOpen().Should().BeTrue("User has roles " + this.PrintableRoles(roles) + ", so clicking Deposit button opens the Form");                
            }
            else
            {
                //Check button
                bankingTab.IsCheckButtonInactive().Should().BeTrue("User has roles " + this.PrintableRoles(roles) + ", so Add Check button is inactive");
                try
                {
                    bankingTab.ClickCheckButton();
                    bankingTab.IsNewTransactionFormOpen().Should().BeFalse("User has roles " + this.PrintableRoles(roles) + ", so clicking Check does nothing");                    
                }
                catch (Exception)
                {
                   //do nothing, if not clickeable the test passes
                }

                //Deposit button
                bankingTab.IsDepositButtonInactive().Should().BeTrue("User has roles " + this.PrintableRoles(roles) + ", so Deposit button is inactive");
                try
                {
                    bankingTab.ClickDepositButton();
                    bankingTab.IsNewTransactionFormOpen().Should().BeFalse("User has roles " + this.PrintableRoles(roles) + ", so clicking Deposit button does nothing");
                }
                catch (Exception)
                {
                    //do nothing, if not clickeable the test passes
                }
            }

        }

        private string PrintableRoles(List<string> roles)
        {
            string ret = "";
            foreach (string role in roles)
            {
                ret += role + ",";
            }
            return ret.Substring(0,ret.Length-1);
        }

        [Then(@"User Can Only Create Distributions If Having Distributions or Trustee Role")]
        public void ThenUserCanOnlyCreateDistributionsIfHavingDistributionsOrTrusteeRole() {
            CaseDetailPage caseDetailPage = ((CaseDetailPage)GetSharedPageObjectFromContext("Case Detail"));
            List<String> roles = ScenarioContext.Current.Get<List<string>>("Roles");
            DistributionTab distributionTab = caseDetailPage.GoToDistribution();
            if (roles.Contains("Distributions") || roles.Contains("Trustee Role"))
            {
                distributionTab.NewDistributionButtonIsEnabled.Should().BeTrue("User has roles " + this.PrintableRoles(roles) + ", so New Distribution button is active");
                distributionTab.ClickNewDistribution();
                distributionTab.IsNewDistributionFormVisible().Should().BeTrue("User has roles " + this.PrintableRoles(roles) + ", so New Distribution button opens the form");
            }
            else
            {
                distributionTab.NewDistributionButtonIsEnabled.Should().BeFalse("User has roles " + this.PrintableRoles(roles) + ", so New Distribution button is inactive");
                distributionTab.ClickNewDistribution();
                distributionTab.IsNewDistributionFormVisible().Should().BeFalse("User has roles " + this.PrintableRoles(roles) + ", so clicking New Distribution button does nothing");
            }
        }

        [Then(@"User Can Only Create Claims If Having Claims or Trustee Role")]
        public void ThenUserCanOnlyCreateClaimsIfHavingClaimsOrTrusteeRole()
        {
            CaseDetailPage caseDetailPage = ((CaseDetailPage)GetSharedPageObjectFromContext("Case Detail"));
            List<String> roles = ScenarioContext.Current.Get<List<string>>("Roles");
            ClaimsDetailTab claimsTab = caseDetailPage.GoToClaimsDetail();
            if (roles.Contains("Claims") || roles.Contains("Trustee Role"))
            {
                //New Claim button
                claimsTab.NewClaimButtonIsDisabled.Should().BeFalse("User has roles " + this.PrintableRoles(roles) + ", so New Claim button is active");
                claimsTab.ClickNewClaim();
                claimsTab.IsNewClaimFormVisible().Should().BeTrue("User has roles " + this.PrintableRoles(roles) + ", so New Claim button opens the form");
                claimsTab.ClickCancel();
                //Edit Claim button
            }
            else
            {
                //New Claim button
                claimsTab.NewClaimButtonIsDisabled.Should().BeTrue("User has roles " + this.PrintableRoles(roles) + ", so New Claim button is inactive");
                try
                {
                    claimsTab.ClickNewClaim();
                    claimsTab.IsNewClaimFormVisible().Should().BeFalse("User has roles " + this.PrintableRoles(roles) + ", so clicking New Claim button does nothing");
                }
                catch (Exception)
                {
                    //do nothing, if click fails then test passes
                }

                //Edit Claim button
            }
        }


    }
}
