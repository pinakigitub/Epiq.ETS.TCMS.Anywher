using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using Epiq.ETS.TCMS.Anywhere.Testing.E2ETest.Test_Framework.Pages.Common;
using NUnit.Framework;
using OpenQA.Selenium.Support.UI;
using System.Threading;
using OpenQA.Selenium.Interactions;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;


namespace Epiq.ETS.TCMS.Anywhere.Testing.E2ETest.Test_Framework.Pages.DashboardExtendNoData
{
    class TrusteeVisibilityPage:PageObject
    {       
        private static string pageExpectedTitle = "UNITY";
        private By counts= By.XPath("//div[@class='title-button-block']/h3/span/span");
        int actualCountValue;

        //claims Filter locators

        private By creditors = By.XPath("//div//label[contains(text(),'CREDITOR')]/following-sibling::input");
        private By closeButton = By.XPath("//div//button[text()='CLOSE']");
        private By filterIcon = By.XPath("//div[@class='epiq-page-control pull-right']//button//i[@class='fa fa-filter']");
        private By accounts = By.XPath("//div//label[contains(text(),'ACCOUNT #')]/following-sibling::input");
        

        public TrusteeVisibilityPage(IWebDriver driver): base(driver, pageExpectedTitle)
        {
            this.driver = driver;
        }

        public void VerifyDataonUIGrid(string search,string num)
        {
            if (search == "FINAL ANALYSIS INC.")  //claims condition
            {
                WaitForElementToBePresent(filterIcon).Click();
                WaitForElementToBeVisible(creditors).SendKeys(search);
                WaitForElementToBeVisible(closeButton).Click();               
            }
            else if(search== "9999924139")   //Banking Activity
             {
                WaitForElementToBePresent(filterIcon).Click();
                this.Pause(2);
                WaitForElementToBeVisible(accounts).SendKeys(search);
                WaitForElementToBeVisible(closeButton).Click();
            }
            else
            {
                actualCountValue = int.Parse(WaitForElementToBePresent(counts).Text);
                IWebElement table = driver.FindElement(By.XPath("//div[@class='epiq-table-wrapper clearfix ']//table//tbody"));
                IList<IWebElement> tableRows = table.FindElements(By.XPath("//tr"));                       
                for (int count = 1; count <= actualCountValue + 1; count++)
                {
                    String cellData = table.FindElement(By.XPath($"//tr[" + count + "]//td[" + num + "]//button[not(@aria-hidden='true')]|//tr[" + count + "]//td[" + num + "]//span//span[not(@aria-hidden='true')]|//tr[" + count + "]//td[" + num + "]//div")).Text;
                    Assert.AreNotEqual(cellData.ToLower().Trim(), search.ToLower().Trim());
                    count++;
                }
            }
        }
       
          public void DBQueryMethod(string page)
        {
            if (page== "DSO")
            {
                string query = @"select * from dbo.[case] c
                                                       inner join [Trustee] t on t.TrusteeId = c.TrusteeId
                                                       inner join [DsoClaimant] dc on dc.CaseId = c.CaseId
                                                       where dc.isdeleted=0 and t.Name = 'CHERYL E. ROSE, RECEIVER/TRUSTEE' or
                                                       t.name= 'CHERYL E. ROSE, CHAPTER 11 TRUSTEE'";
                DBandUIcount(query);
            }
            if (page== "CaseFavorites")
            {
                string query1 = @"DECLARE @userId INT DECLARE @tblTrustee TABLE(TrusteeId INT)
                                  SELECT @userId = au.UserId FROM aspnet_Users(NOLOCK) u INNER JOIN dbo.aspnetUserUser(NOLOCK) au ON u.UserId=au.aspnet_UserID WHERE UserName='CRose\AutoTest1' 
                                  INSERT INTO @tblTrustee SELECT TrusteeId FROM aspnet_Users(NOLOCK) u
	                              INNER JOIN AspnetUserTrustee(NOLOCK) t ON u.UserId = t.UserId
                                  WHERE UserName='CRose\AutoTest1'

	                            SELECT * FROM dbo.CaseFavorite(NOLOCK) f
	                               INNER JOIN dbo.[Case](NOLOCK) c ON f.CaseId = c.CaseI
                                   INNER JOIN dbo.[Trustee](NOLOCK) tr ON c.TrusteeId = tr.TrusteeId
	                               INNER JOIN dbo.[Office](NOLOCK) o ON c.OfficeId = o.OfficeID
	                               INNER JOIN @tblTrustee ut ON ut.TrusteeId = c.TrusteeId WHERE 	UserId = 11947";
                DBandUIcount(query1);

            }
            if (page == "Tasks")
            {
                string query2 = @"DECLARE @userId INT
                                  DECLARE @tblTrustee TABLE(TrusteeId INT)
                                  SELECT @userId = au.UserId FROM aspnet_Users(NOLOCK) u INNER JOIN dbo.aspnetUserUser(NOLOCK) au ON u.UserId=au.aspnet_UserID WHERE UserName='CRose\AutoTest1' 
                                  INSERT INTO @tblTrustee
                                  SELECT TrusteeId FROM  aspnet_Users(NOLOCK) u	                                   
	                              INNER JOIN AspnetUserTrustee(NOLOCK) t ON u.UserId = t.UserId
                                  WHERE  UserName='CRose\AutoTest1'
	                   
                                             SELECT * FROM dbo.Task(NOLOCK) t                                                       		                                            
	                                            INNER JOIN dbo.CaseTask(NOLOCK) ct ON t.TaskId = ct.TaskId
	                                            INNER JOIN dbo.[Case](NOLOCK) c ON ct.CaseId = c.CaseId
	                                            INNER JOIN dbo.[Trustee](NOLOCK) tr ON c.TrusteeId = tr.TrusteeId
	                                            INNER JOIN dbo.[Office](NOLOCK) o ON c.OfficeId = o.OfficeID
	                                            INNER JOIN @tblTrustee ut ON ut.TrusteeId = c.TrusteeId";
                 DBandUIcount(query2);
            }
        }
   
        private void DBandUIcount(string query)
        {
            DataTable results = new DataTable();
            using (System.Data.SqlClient.SqlConnection connection = new SqlConnection(ConfigurationManager.AppSettings.Get("DBConnectionString")))
            {
                SqlCommand command = new SqlCommand(query, connection);
                connection.Open();
                if (connection.State != ConnectionState.Open)
                {
                    connection.Open();
                }
                SqlDataAdapter dataAdapter = new SqlDataAdapter(command);
                var totalCount = dataAdapter.Fill(results);
                Assert.AreEqual(actualCountValue, totalCount);
            }
        }
        public void VerifyFavoriteCase(string Num)
        {
            Assert.False(IsElementVisible(By.XPath($"//span[text()='{Num}']")));
        }
        public void VerifyCaseSection(string CaseNum)
        {
            Assert.False(IsElementVisible(By.XPath($"//li[contains(text(),'{CaseNum}')]")));
        }

    }
}
