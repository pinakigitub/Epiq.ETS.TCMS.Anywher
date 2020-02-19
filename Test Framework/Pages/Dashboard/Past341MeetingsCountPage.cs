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
using NUnit.Framework;

namespace Epiq.ETS.TCMS.Anywhere.Testing.E2ETest.Test_Framework.Pages.Dashboard
{
    class Past341MeetingsCountPage : PageObject
    {
        private static string pageExpectedTitle = "UNITY";
        List<int> DBvalues;
        List<string> dates;
        List<int> UIvalues;

        public Past341MeetingsCountPage(IWebDriver driver) : base(driver, pageExpectedTitle)
        {
        }

        public void UIcasescount()
        {
            try
            {
           dates = new List<string>();
                UIvalues = new List<int>();
                Dictionary<string, int> dict = new Dictionary<string, int>();
                var PARENT = driver.FindElement(By.XPath("//*[contains(@id,'highcharts')]"));
                var parentNUMBER = PARENT.FindElement(By.ClassName("highcharts-root "));
                var Numbers = parentNUMBER.FindElements(By.XPath("//*[13]//*[text()][2]"));
                var Dates = driver.FindElements(By.XPath("//div[@class='col-sm-12 col-md-4'][3]//div[@class='highcharts-axis-labels highcharts-xaxis-labels ']//span//a"));

                for (int i = 0; i < Numbers.Count; i++)
                {
                  //  dict.Add(Dates[i].Text, Numbers[i]);
                    var count = Numbers[i].Text;
                    var countvalue = int.Parse(count);
                    UIvalues.Add(countvalue);
                    Console.WriteLine(Dates[i].Text + "  " + Numbers[i].Text);
                }
            }

            catch { }
        }
        public void DBcount()
        {
            DataTable results = new DataTable();
            var date = DateTime.Now.ToString("yyyy-MM-dd");
            Console.WriteLine(date);
            DBvalues = new List<int>();
            using (SqlConnection connection = new SqlConnection(ConfigurationManager.AppSettings.Get("DBConnectionString")))
            {
                SqlCommand command = new SqlCommand(@"SELECT TOP(6) convert(date, a341.StartDateTime) AS CurrentDate,
              count(1) AS TotalCases,
              sum(CASE WHEN c.AssetStatusId = 1 THEN 1 ELSE 0 END) AS TotalAssets,
              sum(CASE WHEN cd.ConvertTo7Date IS NULL THEN 0 ELSE 1 END) AS TotalConverted,
              sum(CASE WHEN c.ReadyFor341Meeting = 0 THEN 1 ELSE 0 END) AS TotalUnconverted,
              sum(CASE WHEN cd.ExaminedDate IS NULL THEN 0 ELSE 1 END) AS TotalExamined,
              sum(CASE WHEN cdt.DisplayName = 'Unexamined Chapter 7 Case' THEN 1 ELSE 0 END) AS TotalUnexaminedChapter7Case,
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
             ORDER BY  convert(date, a341.StartDateTime) DESC;",  connection);
                connection.Open();
                if (connection.State != ConnectionState.Open)
                {
                    connection.Open();
                }
                SqlDataAdapter dataAdapter = new SqlDataAdapter(command);
                var totalcount = dataAdapter.Fill(results);
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    for (int i = 0; i <= totalcount; i++)
                        if (reader.Read())
                        {
                            int countvalue = (int)reader["TotalCases"];
                            Console.WriteLine(countvalue);
                            DBvalues.Add(countvalue);  
                                                    
                        }
                }
                Assert.IsTrue(UIvalues.SequenceEqual(DBvalues));//linq method to compare two list values       
            }
            
         }
    }
}