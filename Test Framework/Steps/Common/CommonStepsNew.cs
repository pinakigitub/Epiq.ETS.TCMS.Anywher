using Epiq.ETS.TCMS.Anywhere.Testing.E2ETest.Test_Framework.Steps.Common;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Threading;
using TechTalk.SpecFlow;

namespace Epiq.ETS.TCMS.Anywhere.Testing.E2ETest.Test_Framework.Core
{
    [Binding]
    public class CommonStepsNew : CommonMethodsUnityStepBase
    {
        [Given(@"I go to Unity login page")]
        [When(@"I go to Unity login page")]
        [Then(@"I go to Unity login page")]
        public void openUnityLoginPage()
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(80));
            pleaseWaitSignDissapear();
            Thread.Sleep(2500);
            Assert.True(wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//div/input[@id='userName']"))).Displayed);
            pleaseWaitSignDissapear();
        }

        [Given(@"I login Unity site with username (.*), password (.*) and office (.*)")]
        [When(@"I login Unity site with username (.*), password (.*) and office (.*)")]
        [Then(@"I login Unity site with username (.*), password (.*) and office (.*)")]
        public void loginTrusteesSiteWithUserAndPasswordX(string username, string password, string office)
        {
            Thread.Sleep(5500);
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(50));
            pleaseWaitSignDissapear();
            ScenarioContext.Current.Add("username", username);
            ScenarioContext.Current.Add("pswd", password);
            pleaseWaitSignDissapear();
            IWebElement usernameBox = wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//div[label[text()='USERNAME']]//input")));
            char[] usr = username.ToCharArray();

            foreach (char a in usr)
            {
                usernameBox.SendKeys(a.ToString());
            }

            IWebElement passwordBox = wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//div[label[text()='PASSWORD']]//input")));
            char[] pwd = password.ToCharArray();

            foreach (char a in pwd)
            {
                passwordBox.SendKeys(a.ToString());
            }

            IWebElement officeBox = wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//div[label[text()='OFFICE']]//input")));
            char[] off = office.ToCharArray();

            foreach (char a in off)
            {
                officeBox.SendKeys(a.ToString());
            }

            clickNotVisualizedElement(wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//button[text()='LOG IN']"))));
            pleaseWaitSignDissapear();
            Thread.Sleep(3500);
            //checkElementWithTextIsDisplayed("Get Started...");
        }

        [Given(@"I type a login Username (.*)")]
        [When(@"I type a login Username (.*)")]
        [Then(@"I type a login Username (.*)")]
        public void typeUserXOnLoginPage(string user)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(50));
            IWebElement usernameBox = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//div[label[text()='USERNAME']]//input")));
            usernameBox.Click();
            char[] x = user.ToCharArray();

            foreach (char a in x)
            {
                usernameBox.SendKeys(a.ToString());
            }
        }

        [Given(@"I type a login Password (.*)")]
        [When(@"I type a login Password (.*)")]
        [Then(@"I type a login Password (.*)")]
        public void typePasswordX(string password)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(50));
            IWebElement passwordBox = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//div[label[text()='PASSWORD']]//input")));
            passwordBox.Click();
            char[] x = password.ToCharArray();

            foreach (char a in x)
            {
                passwordBox.SendKeys(a.ToString());
            }
        }

        [Given(@"I type a login Office (.*)")]
        [When(@"I type a login Office (.*)")]
        [Then(@"I type a login Office (.*)")]
        public void typeOfficeX(string office)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(50));
            IWebElement officeBox = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//div[label[text()='OFFICE']]//input")));
            officeBox.Click();
            char[] x = office.ToCharArray();

            foreach (char a in x)
            {
                officeBox.SendKeys(a.ToString());
            }
        }

        [Given(@"I click Login button")]
        [When(@"I click Login button")]
        [Then(@"I click Login button")]
        public void clickLoginButton()
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(50));
            IWebElement loginButton = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//button[text()='LOG IN']")));
            loginButton.Click();
        }

        [Given(@"I successfully Login")]
        [When(@"I successfully Login")]
        [Then(@"I successfully Login")]
        public void loginOk()
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(50));
            IWebElement loginButton = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//button[text()='LOG IN']")));
            loginButton.Click();
            IWebElement userLink = wait.Until(ExpectedConditions.ElementIsVisible(By.Id("userLink")));
        }

        [AfterScenario("AssetsPage", "ReportsPage", "DashboardPage", Order = 0)]
        public void deletingScenarioContext()
        {
            ScenarioContext.Current.Clear();
        }

        //[AfterScenario("AssetsPage", "ReportsPage", "DashboardPage", Order = 1)]
        //public void takeScreenShot()
        //{
        //    Screenshot shot = new Screenshot();
        //    var status = TestContext.CurrentContext.Result.State.ToString();
        //    if (status != "Success")
        //    {
        //        shot.TakeScreenshot(driver, "");
        //        TestsLogger.Log("ScreenShot has been Taked");
        //    }
        //    else
        //    {
        //        TestsLogger.Log("ScreenShot has not been Taked");
        //    }
        //}

        [AfterScenario("AssetsPage", "ReportsPage", "DashboardPage", Order = 2)]
        public void logOut()
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
            pleaseWaitSignDissapear();
            ignoreAllExceptions();
            Thread.Sleep(2500);
            clickNotVisualizedElement(wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//li[@id='userMenu']/button"))));
            Thread.Sleep(2500);
            clickNotVisualizedElement(wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//li/a[@id='login-logout']"))));
            Thread.Sleep(2500);
            //Assert.True(wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//div[@class[contains(.,'logoContainer small-11 small-centered medium-5 large-6 columns')]]"))).Displayed);
            //TestsLogger.Log("Logout Completed");
            pleaseWaitSignDissapear();
        }

        [BeforeScenario("DeleteAllAssetsFromCase2374")]
        [AfterScenario("DeleteAllAssetsFromCase2374", Order = 3)]
        public void deleteAllAssets()
        {
            DataTable results = new DataTable();

            using (SqlConnection conn = new SqlConnection(ConfigurationManager.AppSettings.Get("DBConnectionString")))
            using (SqlCommand command = new SqlCommand(Properties.Resources.deleteAllAssetsFromCase2374, conn))
            using (SqlDataAdapter dataAdapter = new SqlDataAdapter(command))
                dataAdapter.Fill(results);
            TestsLogger.Log("All Assets for Case 2374 were deleted!!!!");
        }

        [BeforeScenario("regenerateAsset1ForCase2391")]
        [AfterScenario("regenerateAsset1ForCase2391", Order = 4)]
        public void regenerateAsset1ForCase2391()
        {
            DataTable results = new DataTable();

            using (SqlConnection conn = new SqlConnection(ConfigurationManager.AppSettings.Get("DBConnectionString")))
            using (SqlCommand command = new SqlCommand(Properties.Resources.regenerateAsset1ForCase2391, conn))
            using (SqlDataAdapter dataAdapter = new SqlDataAdapter(command))
                dataAdapter.Fill(results);
            TestsLogger.Log("Asset 1 Regenerated for case 2391");
        }

        [BeforeScenario("regenerateAsset8ForCase1378")]
        [AfterScenario("regenerateAsset8ForCase1378", Order = 5)]
        public void regenerateAsset8ForCase1378()
        {
            DataTable results = new DataTable();

            using (SqlConnection conn = new SqlConnection(ConfigurationManager.AppSettings.Get("DBConnectionString")))
            using (SqlCommand command = new SqlCommand(Properties.Resources.regenerateAsset8ForCase1378, conn))
            using (SqlDataAdapter dataAdapter = new SqlDataAdapter(command))
                dataAdapter.Fill(results);
            TestsLogger.Log("Asset 8 Regenerated for case 1378");
        }

        [BeforeScenario("regenerateFailReport")]
        public void regenerateFailReport()
        {
            DataTable results = new DataTable();

            using (SqlConnection conn = new SqlConnection(ConfigurationManager.AppSettings.Get("DBConnectionString")))
            using (SqlCommand command = new SqlCommand(Properties.Resources.regenerateFailReport, conn))
            using (SqlDataAdapter dataAdapter = new SqlDataAdapter(command))
                dataAdapter.Fill(results);
            TestsLogger.Log("Fail Report Regenerated");
        }

        [AfterScenario("deleteTestReports", Order = 6)]
        public void deleteTestReports()
        {
            DataTable results = new DataTable();

            using (SqlConnection conn = new SqlConnection(ConfigurationManager.AppSettings.Get("DBConnectionString")))
            using (SqlCommand command = new SqlCommand(Properties.Resources.deleteTestReports, conn))
            using (SqlDataAdapter dataAdapter = new SqlDataAdapter(command))
                dataAdapter.Fill(results);
            TestsLogger.Log("Test Reports Deleted");
        }

        [BeforeScenario("ResetMissingTaxIdForTesting")]
        [AfterScenario("ResetMissingTaxIdForTesting", Order = 7)]
        public void ResetMissingTaxIdForTesting()
        {
            DataTable results = new DataTable();

            using (SqlConnection conn = new SqlConnection(ConfigurationManager.AppSettings.Get("DBConnectionString")))
            using (SqlCommand command = new SqlCommand(Properties.Resources.ResetMissingTaxIdForTesting, conn))
            using (SqlDataAdapter dataAdapter = new SqlDataAdapter(command))
                dataAdapter.Fill(results);
            TestsLogger.Log("ResetMissingTaxIdForTesting Successfully executed!!");
        }

        [BeforeScenario("regenerateAsset2ForCase2391")]
        [AfterScenario("regenerateAsset2ForCase2391", Order = 8)]
        public void regenerateAsset2ForCase2391()
        {
            DataTable results = new DataTable();

            using (SqlConnection conn = new SqlConnection(ConfigurationManager.AppSettings.Get("DBConnectionString")))
            using (SqlCommand command = new SqlCommand(Properties.Resources.regenerateAsset2ForCase2391, conn))
            using (SqlDataAdapter dataAdapter = new SqlDataAdapter(command))
                dataAdapter.Fill(results);
            TestsLogger.Log("Asset 2 Regenerated for case 2391");
        }

        [BeforeScenario("deleteDepositForCase1960", Order = 0)]
        public void deleteDepositForSpecificCase()
        {
            /////////// Query to DB and validations between UI and DB ///////////
            DataRowCollection rows = null;
            Dictionary<string, string> parameters = new Dictionary<string, string>();
            parameters.Clear();
            parameters.Add("depositName", "My New Deposit");
            rows = ExecuteQueryOnDBWithString(Properties.Resources.deleteDepositByCaseIdAndDepositName, parameters);
            TestsLogger.Log("Deposit deleted for case 1960");
        }

        [BeforeScenario("regenerateDepositNumber1ForCaseId1960")]
        [AfterScenario("regenerateDepositNumber1ForCaseId1960")]
        public void regenerateDepositNumber1ForCaseId1960()
        {
            /////////// Query to DB and validations between UI and DB ///////////
            DataRowCollection rows = null;
            rows = ExecuteQueryOnDBWithString(Properties.Resources.regenerateDepositNumber1ForCaseId1960);
            TestsLogger.Log("Deposit # 1 regenerated for case 1960");
        }

        [BeforeScenario("createDepositWithAllLinksForCaseId1960")]
        public void createDepositWithAssetLinksForCaseId1960()
        {
            DataTable results = new DataTable();
            using (SqlConnection conn = new SqlConnection(ConfigurationManager.AppSettings.Get("DBConnectionString")))
            using (SqlCommand command = new SqlCommand(Properties.Resources.createDepositWithAllLinksForCaseId1960, conn))
            using (SqlDataAdapter dataAdapter = new SqlDataAdapter(command))
                dataAdapter.Fill(results);
            TestsLogger.Log("Deposit #9999 created for case 1960");
        }

        [AfterScenario("deleteDepositAndLinksForTransactionId", Order = 1)]
        public void deleteDepositAndLinksForTransactionId()
        {
            /////////// Query to DB and validations between UI and DB ///////////
            DataRowCollection rows1 = null;
            DataRowCollection rows2 = null;
            Dictionary<string, int> parameters = new Dictionary<string, int>();
            parameters.Clear();
            rows1 = ExecuteQueryOnDBWithString(Properties.Resources.getLastCreatedTransactionId);
            parameters.Add("transactionIdFrank", Convert.ToInt32(rows1[0].ItemArray[0].ToString()));
            rows2 = ExecuteQueryOnDBWithInt(Properties.Resources.deleteDepositAndLinksForTransactionId, parameters);
            TestsLogger.Log("Deposit and Links deleted for case 1960");
        }

        [AfterScenario("deleteLastGeneratedTransactionForCase1960", Order = 1)]
        public void deleteLastGeneratedTransactionCase1960()
        {
            /////////// Query to DB and validations between UI and DB ///////////
            DataRowCollection rows1 = null;
            DataRowCollection rows2 = null;
            Dictionary<string, int> parameters = new Dictionary<string, int>();
            parameters.Clear();
            rows1 = ExecuteQueryOnDBWithString(Properties.Resources.getLastGeneratedTransacionIdForCase1960);
            parameters.Add("transactionIdFrank", Convert.ToInt32(rows1[0].ItemArray[0].ToString()));
            rows2 = ExecuteQueryOnDBWithInt(Properties.Resources.deleteDepositAndLinksForTransactionId, parameters);
            TestsLogger.Log("Last Generated Transaction For Case 1960 Deleted");
        }

        [BeforeScenario("deleteAllTransactionsForCase1960", Order = 1)]
        [AfterScenario("deleteAllTransactionsForCase1960", Order = 1)]
        public void deleteAllTransactionsCase1960()
        {
            /////////// Query to DB and validations between UI and DB ///////////
            DataRowCollection rows1 = null;
            Dictionary<string, int> parameters = new Dictionary<string, int>();
            parameters.Clear();
            rows1 = ExecuteQueryOnDBWithString(Properties.Resources.deleteAllTransactionsForCase1960);
            TestsLogger.Log("All Transactions For Case 1960 were Deleted");
        }

        [AfterScenario("deleteLastGeneratedTransactionForCase1378", Order = 1)]
        public void deleteLastGeneratedTransactionCase1378()
        {
            /////////// Query to DB and validations between UI and DB ///////////
            DataRowCollection rows1 = null;
            DataRowCollection rows2 = null;
            Dictionary<string, int> parameters = new Dictionary<string, int>();
            parameters.Clear();
            rows1 = ExecuteQueryOnDBWithString(Properties.Resources.getLastGeneratedTransacionIdForCase1378);
            parameters.Add("transactionIdFrank", Convert.ToInt32(rows1[0].ItemArray[0].ToString()));
            rows2 = ExecuteQueryOnDBWithInt(Properties.Resources.deleteDepositAndLinksForTransactionId, parameters);
            TestsLogger.Log("Last Generated Transaction For Case 1378 Deleted");
        }

        [BeforeScenario("regenerateDeposit1ForCaseId1378")]
        [AfterScenario("regenerateDeposit1ForCaseId1378")]
        public void regenerateDeposit1ForCaseId1378()
        {
            DataTable results = new DataTable();
            using (SqlConnection conn = new SqlConnection(ConfigurationManager.AppSettings.Get("DBConnectionString")))
            using (SqlCommand command = new SqlCommand(Properties.Resources.regenerateDepositNumber1ForCaseId1960, conn))
            using (SqlDataAdapter dataAdapter = new SqlDataAdapter(command))
                dataAdapter.Fill(results);
            TestsLogger.Log("Deposit # 1 regenerated for case 1378");
        }

        [Given(@"Verify error message for User without Unity Access")]
        [When(@"Verify error message for User without Unity Access")]
        [Then(@"Verify error message for User without Unity Access")]
        public void errorMessageNoUnityAccess()
        {

            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(50));
            pleaseWaitSignDissapear();
            IWebElement errorMessage = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//div/p[@id='errorMessage']")));
            Assert.That(errorMessage.Text.Contains("Access not granted for this application, please contact Epiq"));
        }
    }
}
