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

namespace Epiq.ETS.TCMS.Anywhere.Testing.E2ETest.Test_Framework.Pages.DSOCLAIMS
{
    class DSOClaimsPage : UnityPageBase
    {

        private static string pageExpectedTitle = "UNITY";
        private By DASHBOARD_BREADCRUMB = By.XPath("//div[contains(@class,'epiq-page-header')]//a[@href='/dashboard']");
        private By DSOClaimants_BREADCRUMB = By.XPath("//div[contains(@class,'epiq-page-header')]//span[contains(text(),'DSO Claimants')]");
        private By DSOClaimants_SUBHEADER = By.XPath("//div[contains(@class,'epiq-page-controls')]/div/h3");
        string actualbreadcrumb;
        string Expectedbreadcrumb;
        string actualsubheader;
        string expectedsubheader;
        private By FILTER_ICON = By.XPath("//button[@class='btn btn-info'][@title='View and change current filters.']");
        private By CASE_DEBTOR_FIELD = By.XPath("//div[contains(@class,'rbt open')]");
        private By CLOSE_BUTTON = By.XPath("//button[text()='CLOSE']");
        private By RESET_BUTTON = By.XPath("//button[text()='RESET']");


        //TRUSTEE VISIBILITY LOCATORS

        



        public DSOClaimsPage(IWebDriver driver) : base(driver, pageExpectedTitle)
        {
            this.driver = driver;
            // driver.IntializePage<GlobalExtendNoDataPage>(this);
        }
        public void BreadcrumbSubheaderVerify(string breadcrumb, string subheader)
        {
            actualbreadcrumb = (driver.FindElement(DASHBOARD_BREADCRUMB).Text).Trim() + " > " + driver.FindElement(DSOClaimants_BREADCRUMB).Text;
            Expectedbreadcrumb = breadcrumb.Trim();
            Assert.AreEqual(actualbreadcrumb.ToLower(), Expectedbreadcrumb.ToLower());

            actualsubheader = (driver.FindElement(DSOClaimants_SUBHEADER).Text);
            string finalsubheader = actualsubheader.Substring(0, 13).Trim();
            expectedsubheader = subheader.Trim();
            Assert.AreEqual(finalsubheader.ToLower(), expectedsubheader.ToLower());

        }
        public void searchInfo(string search, string casename)
        {
           
                driver.FindElement(FILTER_ICON).Click();
                Thread.Sleep(2000);
            //    driver.FindElement(CASE_DEBTOR_FIELD).SendKeys(search);
            //    driver.FindElement(CASE_DEBTOR_FIELD).Click();
            //    Thread.Sleep(2000);
            //try { 
            //    IList<IWebElement> dropdownValues = driver.FindElements(By.XPath("//div[contains(@class,'rbt open')]//ul//span"));
            //    foreach (IWebElement textBox in dropdownValues)
            //    {
            //        if ((textBox.Text) == casename)
            //        {
            //            Thread.Sleep(2000);
            //           // var element=dropdownValues.Where(e => e.Text == casename).FirstOrDefault();
            //    IJavaScriptExecutor ex = (IJavaScriptExecutor)driver;
            //    Thread.Sleep(3000);
            //    ex.ExecuteScript("arguments[0].click();", textBox);
            //            break;
            //        }
            //    }
            //}
            //catch (StaleElementReferenceException e)
            //{
               
            //}
        }
        public void dropdownfields(string casestatus, string dsoinitial, string dsonotice)
        {
           
         
            if (!string.IsNullOrEmpty(casestatus))
            {
                dropdowndata(2, casestatus);
            }
            if (!string.IsNullOrEmpty(dsoinitial)) 
            {
                dropdowndata(3, dsoinitial);

            }
            if (!string.IsNullOrEmpty(dsonotice))
            {
                dropdowndata(4, dsonotice);
            }
            driver.FindElement(CLOSE_BUTTON).Click();
            Thread.Sleep(5000);
        }

        private void dropdowndata(int i, string status)
        {
            try
            {
                driver.FindElement(By.XPath(".//*[@id='react-select-" + i + "--value-item']")).Click();
                IList<IWebElement> CASE_STATUS_OPTIONS = driver.FindElements(By.XPath("//div[@id='react-select-" + i + "--list']/div[contains(@class,'Select-option')]"));
                CASE_STATUS_OPTIONS.Where(e => e.Text == status).FirstOrDefault().Click();    
            }
            
            catch (StaleElementReferenceException e)
            {
               
            }
              
        }
        public void datefields(string fromdate, string todate)
        {
            //identify two date fields and storing in list
           
            if (!string.IsNullOrEmpty(fromdate))
            {
                datefieldsData("first",fromdate);
            }
            if (!string.IsNullOrEmpty(todate))
            {
                datefieldsData(null,todate);

            }
        }      
    private void datefieldsData(string xpath,string date)
    {
           
       
        IList<IWebElement> datepickerfields = driver.FindElements(By.XPath("//input[contains(@class,'form-control')][@placeholder='MM/DD/YY']"));

              var ele = (xpath=="first") ?datepickerfields.FirstOrDefault() : datepickerfields.LastOrDefault();
              ele.SendKeys(date);     
    }

    public void clickReset()
        {
            driver.FindElement(RESET_BUTTON);
        }
        public void VerifyDSOData(string claimantname)
        {
            IWebElement table = driver.FindElement(By.XPath("//div[@class='epiq-table-wrapper clearfix ']//table//tbody"));
            IList<IWebElement> tableRows = driver.FindElements(By.XPath("//div[@class='epiq-table-wrapper clearfix ']//table//tbody//tr"));
            int rowcount = tableRows.Count;
            //    IList<IWebElement> tableColumns = driver.FindElements(By.XPath("//div[@class='epiq-table-wrapper clearfix ']//table//tbody//tr//td"));
            //    int columncount = tableColumns.Count;                        
            for (int i = 1; i <= rowcount; i++)
            {
                String celldata = driver.FindElement(By.XPath("//div[@class='epiq-table-wrapper clearfix ']//table//tbody//tr["+i+"]//td[3]")).Text;
                Assert.AreNotEqual(celldata.ToLower().Trim(), claimantname.ToLower().Trim());
                i++;
            }
                        
        }
        public void DBandUIcount()
        {
            var actualcount=driver.FindElement(By.XPath("//div[@class='epiq-page-controls clearfix container row']//h3//span")).Text;
            var actualcountvalue = actualcount.Substring(1,1);
            Console.WriteLine(actualcountvalue);

            Console.WriteLine("actualcount is "+ actualcountvalue);
            DataTable results = new DataTable();
            using (System.Data.SqlClient.SqlConnection connection = new SqlConnection(ConfigurationManager.AppSettings.Get("DBConnectionString")))
            {
                SqlCommand command = new SqlCommand(@"select * from
     dbo.[case] c
    inner join [Trustee] t on t.TrusteeId = c.TrusteeId
    inner join [DsoClaimant] dc on dc.CaseId = c.CaseId
    where dc.isdeleted=0 and t.Name = 'CHERYL E. ROSE, RECEIVER/TRUSTEE' or t.name= 'CHERYL E. ROSE, CHAPTER 11 TRUSTEE';", connection);
                connection.Open();
                if (connection.State != ConnectionState.Open)
                {
                    connection.Open();
                }
                SqlDataAdapter dataAdapter = new SqlDataAdapter(command);                       
                var totalcount = dataAdapter.Fill(results);
                Console.WriteLine("total count is " + totalcount);
                Assert.AreEqual("+actualcountvalue+".Trim(), totalcount); 
                    
            }
        }
    }

    }