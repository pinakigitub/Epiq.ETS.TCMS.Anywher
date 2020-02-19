using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;                                         
using System.Threading;
using OpenQA.Selenium.Interactions;
using TechTalk.SpecFlow;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using OpenQA.Selenium.Remote;
using System.Xml.Linq;
using NUnit.Framework;

namespace Epiq.ETS.TCMS.Anywhere.Testing.E2ETest.Test_Framework.Pages.Dashboard
{
    class Dashboard_EnhancementsPage : PageObject
    {
        private static string pageExpectedTitle = "UNITY";

        private By thisWeekTasks = By.XPath("//div[@class='col-sm-12 col-md-6']//h3");
        private By meeting341 = By.XPath("//div[@class='row epiq-upcoming-341-card epiq-panel-card']");
        private By preparationHeader = By.XPath(".//*[@id='headerTitle']");
        private By viewAllTasks = By.XPath("//a[@class='epiq-dashboard-view-all-button btn btn-default'][text()='VIEW ALL TASKS']");
        //favorites
        private By caseDebtorName = By.XPath("//a[@class='epiq-favorite-cases-link']");
        List<int> dbValues;
        List<string> dateList;
        List<int> uiValues;
        private By clickTask = By.XPath("//div[@class='row scrollableWrapper']//a[1]");
        private By logoHeader = By.XPath("//div[@class='navbar-header']/a/img");


        public Dashboard_EnhancementsPage(IWebDriver driver) : base(driver, pageExpectedTitle)
        {
            this.driver = driver;
            // driver.IntializePage<GlobalExtendNoDataPage>(this);
        }
        public void DashboardHeaders(string header)
        {
            if (header == "This Week's Tasks")
            {
                var thisweekheader = driver.FindElement(thisWeekTasks).Text;
                Assert.IsTrue(thisweekheader.Equals(header, StringComparison.OrdinalIgnoreCase));
            }
            else
            {
                var aHeader = driver.FindElement(By.XPath($"//div[contains(@class,'epiq-dashboard-tile')]//h3[text()='{header}']"));
                string actualHeader = aHeader.Text;
                Assert.IsTrue(actualHeader.Equals(header, StringComparison.OrdinalIgnoreCase));
            }
        }
        public void BankSummaryLinksClick(int link)
        {
            var links = driver.FindElement(By.XPath($"//div[@class='epiq-banking-summary']//div[@class='row'][{link}]//span[@class='total']//a"));
            links.Click();
        }
        public void Meeting341Click()
        {
            WaitForElementToBePresent(meeting341).Click();
        }
        public void VerifyHeaderOnPreperationPage(string header)
        {
            var actualHeader = driver.FindElement(preparationHeader).Text;
            Assert.IsTrue(actualHeader.Equals(header, StringComparison.OrdinalIgnoreCase));
        }
        public void ViewAllTasksClick(string buttonText)
        {
            driver.FindElement(By.XPath($"//div[@class='epiq-dashboard-tasks-tile']//div[@class='row']//div[contains(text(),'{buttonText}')]")).Click();
            WaitForElementToBePresent(clickTask, 3).Click();
        }
        public void ClickCaseDebtorName()
        {
            WaitForElementToBePresent(caseDebtorName).Click();
        }
        public void ClickDates()
        {
            IList<IWebElement> dropdownValues = driver.FindElements(By.XPath(".//*[@id='highcharts-khz1xuy-8']/div/span//a"));
            foreach (IWebElement date in dropdownValues)
            {
                JavaScriptClick(date);
            }
        }
        public void GetCasesCountFromUI()
        {
            try
            {
                dateList = new List<string>();
                uiValues = new List<int>();
                Dictionary<string, int> dict = new Dictionary<string, int>();
                var parent = driver.FindElement(By.XPath("//*[contains(@id,'highcharts')]"));
                var parentNumber = parent.FindElement(By.ClassName("highcharts-root "));
                var numbers = parentNumber.FindElements(By.XPath("//*[13]//*[text()][2]"));
                var dates = driver.FindElements(By.XPath("//div[@class='col-sm-12 col-md-4'][3]//div[@class='highcharts-axis-labels highcharts-xaxis-labels ']//span//a"));

                for (int count = 0; count < numbers.Count; count++)
                {
                    var ccValue = int.Parse(numbers[count].Text);
                    uiValues.Add(ccValue);
                }
            }

            catch { }
        }
        public void GetCasesCountFromDB()
        {
            DataTable results = new DataTable();
            var date = DateTime.Now.ToString("yyyy-MM-dd");
            dbValues = new List<int>();
            using (SqlConnection connection = new SqlConnection(ConfigurationManager.AppSettings.Get("DBConnectionString")))
            {
                SqlCommand command = new SqlCommand(@"SELECT TOP(6) convert(date, a341.StartDateTime) AS CurrentDate,
               sum(CASE WHEN cdt.DisplayName = 'Unexamined Chapter 7 Case' THEN 1 ELSE 0 END) AS TotalUnexaminedChapter7Case,
               count(1) AS TotalCases,
               sum(CASE WHEN c.AssetStatusId = 1 THEN 1 ELSE 0 END) AS TotalAssets,
               sum(CASE WHEN cd.ConvertTo7Date IS NULL THEN 0 ELSE 1 END) AS TotalConverted,
               sum(CASE WHEN c.ReadyFor341Meeting = 0 THEN 1 ELSE 0 END) AS TotalUnconverted,
               sum(CASE WHEN cd.ExaminedDate IS NULL THEN 0 ELSE 1 END) AS TotalExamined,               
               sum(CASE WHEN cdt.DisplayName = 'Unexamined Chapter 7 Case' AND cd.NDRDate IS NULL AND cd.Chapter7OpenDate < '" + date + @"' THEN 1 ELSE 0 END) AS TotalUndetermined
               FROM  dbo.[Case] AS c
               INNER JOIN dbo.vw_Appointment_33 a341
               ON a341.CaseId = c.CaseId
               AND a341.StartDateTime < '" + date + @"'        
               INNER JOIN tcms.vw_VisibleCases vc
               ON c.CaseId = vc.CaseId
               AND vc.UserId = 6200
              INNER JOIN vw_CaseDates cd
              ON cd.CaseId = c.CaseId
              INNER JOIN dbo.CaseDispositionType AS cdt
              ON c.CaseDispositionTypeId = cdt.CaseDispositionTypeId
              WHERE
              c.OfficeId = '215'
              AND c.IsDeleted = 0
              AND cd.Continued341Date IS NULL
              GROUP BY
              convert(date, a341.StartDateTime)
              ORDER BY  convert(date, a341.StartDateTime) DESC;", connection);
                connection.Open();
                if (connection.State != ConnectionState.Open)
                {
                    connection.Open();
                }
                SqlDataAdapter dataAdapter = new SqlDataAdapter(command);
                var totalCount = dataAdapter.Fill(results);
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    for (int counter = 0; counter <= totalCount; counter++)
                        if (reader.Read())
                        {
                            int countValue = (int)reader["TotalUnexaminedChapter7Case"];
                            dbValues.Add(countValue);
                        }
                }
                Assert.IsTrue(uiValues.SequenceEqual(dbValues));//linq method to compare two list values

            }
        }

        public void VerifyNewCasesLinkToPrefilteredInUpcoming341Page(string message)
        {
            var casesCountLinkText = WaitForElementToBeVisible(By.XPath("//div[1]/div[3]//div[@class='row epiq-upcoming-341-new']/a/span")).Text;
            String text = casesCountLinkText.Replace("NEW CASES", "");
            int num = Int16.Parse(text);
            if (num > 0)
            {
                WaitForElementToBeClickeable(By.XPath("//div[1]/div[3]//div[@class='row epiq-upcoming-341-new']/a/span")).Click();
            }
            else
            {
                WaitForElementToBeClickeable(By.XPath("//div[1]/div[3]//div[@class='row epiq-upcoming-341-new']/a/span")).Click();
                var templateText = WaitForElementToBeVisible(By.XPath("//div[@class='epiq-template-full']/div[3]/div/div/div")).Text;
                Assert.IsTrue(templateText.Equals(message, StringComparison.OrdinalIgnoreCase));
            }
        }

        public void VerifyContinuedCasesLinkToPrefilteredInUpcoming341Page(string message)
        {
            var casesCountLinkText = WaitForElementToBeVisible(By.XPath("//div[@class='epiq-dashboard-tile epiq-flex-child epiq-first-row-tile']/div[2]/div/div[1]/div[3]/div[3]/a/span")).Text;
            String text = casesCountLinkText.Replace("CONTINUED CASES", "");
            int num = Int16.Parse(text);
            if (num > 0)
            {
                WaitForElementToBeClickeable(By.XPath("//div[@class='epiq-dashboard-tile epiq-flex-child epiq-first-row-tile']/div[2]/div/div[1]/div[3]/div[3]/a/span")).Click();
            }
            else
            {
                WaitForElementToBeClickeable(By.XPath("//div[@class='epiq-dashboard-tile epiq-flex-child epiq-first-row-tile']/div[2]/div/div[1]/div[3]/div[3]/a/span")).Click();
                this.Pause(3);
                var templateText = WaitForElementToBeVisible(By.XPath("//div[@class='epiq-template-full']/div[3]/div/div/div")).Text;
                Assert.AreEqual(templateText, message);
            }
        }
        public void VerifyDetailsInCaseNavigationAndPageNavigation(string navigationDetails)
        {
            this.Pause(5);
            var details = WaitForElementToBeVisible(By.XPath($"//div[@class='container']/div[3]//div[contains(text(),'{navigationDetails}')]")).Text.Trim();
            Assert.IsTrue(details.Equals(navigationDetails, StringComparison.OrdinalIgnoreCase));
        }
        public void ClickOnEpiqUnityLogoInHeader()
        {
            WaitForElementToBePresent(logoHeader).Click();

        }

        public void RedirectedToAllCasesOrDashboardPage(string cases, string dashboard)
        {
            var dashboardText = WaitForElementToBeVisible(By.XPath("//div[text()='Dashboard']")).Text;
            Assert.AreEqual(dashboard, dashboardText);
            var allCasesText = WaitForElementToBeVisible(By.XPath("//div[text()='All Cases']")).Text;
            Assert.AreEqual(cases, allCasesText);

        }

    }
}
              
 




