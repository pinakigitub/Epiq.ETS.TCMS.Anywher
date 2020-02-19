using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Firefox;
using System;
using TechTalk.SpecFlow;
using System.Collections.Generic;
using System.Linq;
using System.Configuration;
using Epiq.ETS.TCMS.Anywhere.Testing.E2ETest.Test_Framework.Core;
using NUnit.Framework;
using System.Data;
using System.Data.SqlClient;
using OpenQA.Selenium.Interactions;
using Epiq.ETS.TCMS.Anywhere.Testing.E2ETest.Test_Framework.Pages;
using Epiq.ETS.TCMS.Anywhere.Testing.E2ETest.Test_Framework.Pages.Common;
using System.Drawing;

namespace Epiq.ETS.TCMS.Anywhere.Testing.E2ETest.Test_Framework.Steps
{
    /**
     *  This Class is the base for all Step classes in the test framework and encapsulates Selenium or Specflow 
     *  common operations that are going to be re-used  all over the Steps code.
     *
     *  Note that this class is site and application "agnostic": all code related to the specific application under test
     *  should go to a "<Project>StepBase" class.
     */
    [Binding]
    public class StepBase
    {
        //Setup common stuff
        private const string browserFireFox = "Firefox";
        private const string browserChrome = "Chrome";
        private const string browserIE = "IE";

        protected static IWebDriver driver;
        protected static Actions builder;

        [BeforeFeature]
        public static void Setup()
        {
            //Load settings from config file
            var portalURL = ConfigurationManager.AppSettings.Get("PortalURL");
            var browserName = ConfigurationManager.AppSettings.Get("Browser");

            //set drivers path and start port from App.config
            string driverPath = ConfigurationManager.AppSettings.Get("DriverPath");
            int driverPort = Convert.ToInt32(ConfigurationManager.AppSettings.Get("DriverPort"));

            //Instantiate the WebDriver according to the browser on the App.config
            switch (browserName)
            {
                case browserFireFox:
                    driver = new FirefoxDriver();
                    break;

                case browserChrome:
                    ///////////// Here I open Chrome in Incognito Mode ////////////
                    var optionsChrome = new ChromeOptions();

                    //Removing incognito, it does not clear cache
                    //bad side-effectes: causes failure with Chrome 57 and avoids window resizing-> click errors.
                    //¡¡¡DO NOT ACTIVATE THIS AGAIN!!! optionsChrome.AddArgument("incognito");

                    //These could be useful for any extension errors that prevent browser from launching
                    //optionsChrome.AddArgument("--aggressive-cache-discard");
                    optionsChrome.AddArgument("--disable-infobars");
                    optionsChrome.AddArgument("--disable-extensions");
                    driver = new ChromeDriver(optionsChrome);
                    //driver = new ChromeDriver();
                    break;

                case browserIE:
                    ////Ignore browser security warning
                    //var options = new InternetExplorerOptions();
                    //options.IntroduceInstabilityByIgnoringProtectedModeSettings = true;
                    //driver = new InternetExplorerDriver(options);
                    driver = GetNewInternetExplorerDriver(driverPath, driverPort);
                    break;

                default:
                    driver = new FirefoxDriver();
                    break;
            }

            //Configure driver basic settings

            //Unity doesn't handle cookies - does DeleteAllCookies clean anythign else?
            driver.Manage().Cookies.DeleteAllCookies();
            //driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(0));

            //driver.Manage().Window.Maximize();
            //IMPORTANT: Keep this size to avoid CLICK issues
            Size size = new Size(1920, 1080);
            driver.Manage().Window.Size = size;

            //Navigate to the portal portalURL
            driver.Navigate().GoToUrl(portalURL);

            TestsLogger.Log("Running Tests on " + browserName + " for " + portalURL);
        }

        [BeforeScenario]
        public static void BeforeScenario()
        {
            //Clear previous ScenarioContext data
            ScenarioContext.Current.Clear();
            driver.Navigate().Refresh();

            //Log test start to easily locate scenarios on the LOG
            TestsLogger.Log("[TEST START] " + ScenarioContext.Current.ScenarioInfo.Title);            
        }

        [StepArgumentTransformation]
        public static List<String> TransformToListOfString(string commaSeparatedList)
        {
            //Transform a string parameter received from Feature file 
            //that is a comma separated list into a List<string>
            return commaSeparatedList.Split(',').ToList();
        }

        [AfterStep]
        public static void CheckForExceptions()
        {
            //Checks for exceptions and, if there are any, 
            //asserts a failure with the corresponding log and Stack Trace
            var exception = ScenarioContext.Current.TestError;
            if (exception is Exception)
            {
                TestsLogger.Log(exception.StackTrace);
                Assert.Fail(exception.Message);
                ((IDisposable)ScenarioContext.Current).Dispose();               
            }
        }


        [AfterScenario(Order = 20)]
        public static void LogoutAndClearScenarioContext()
        {
            TestsLogger.Log("Cleaning Scenario data... ");
            try
            {                
                //Try to logout if Unity user is logged in, in any page of the App
                UnityPageBase navigationBar = new UnityPageBase(driver, null);                
                if ((navigationBar != null) && (navigationBar.Title =="UNITY"))
                    navigationBar.Logout();

            }
            catch{
                //do nothing, USER COULD NOT BE LOGGED depending on the scenario
            }

            //Clear driver cookies
            driver.Manage().Cookies.DeleteAllCookies();
            //Clear ScenarioContext data
            ScenarioContext.Current.Clear();
        }

        [AfterFeature]
        public static void Teardown()
        {
            TestsLogger.Log("Closing out browser (close, quit and dispose)... ");
            //driver.Close();
            driver.Quit();
            //driver.Dispose();
        }

        //DRIVERS SPECIAL CONSTRUCTORS FOR SPECIFIC PORTS ON HOST MACHINE
        //(NOT USING RIGHT NOW) 
        private static IWebDriver GetNewFirefoxDriver(int driverPort)
        {
            //setup driver's port
            FirefoxProfile profile = new FirefoxProfile();
            profile.Port = driverPort;

            TestsLogger.Debug("Attempting to start Firefox browser on port " + profile.Port);
            return new FirefoxDriver(profile);
        }

        private static IWebDriver GetNewChromeDriver(string driverPath, int driverPort)
        {
            //setup driver's folder and port
            var chromeDriverService = ChromeDriverService.CreateDefaultService(driverPath);
            chromeDriverService.Port = driverPort;

            TestsLogger.Debug("Attempting to start Chrome browser on port " + driverPort);
            return new ChromeDriver(chromeDriverService);
        }
       

        private static IWebDriver GetNewInternetExplorerDriver(string driverPath, int driverPort)
        {
            //setup driver's folder and port
            var IEDriverService = InternetExplorerDriverService.CreateDefaultService(driverPath);
            IEDriverService.Port = driverPort;

            //Ignore browser security warning
            var options = new InternetExplorerOptions();
            options.IntroduceInstabilityByIgnoringProtectedModeSettings = true;

            //This property could be useful to fix scroll issues
            //?options.ElementScrollBehavior = 1;

            options.RequireWindowFocus = false;            

            //ensure a clean session on browser startup and use private mode
            options.EnsureCleanSession = true;
            
            TestsLogger.Debug("Attempting to start IE browser on port " + (driverPort+1));
            return new InternetExplorerDriver(IEDriverService, options);
        }

        

        //SPECIFICS TO TEST - DB QUERIES AND COMMON STEPS
        //DB Queries
        protected static DataRowCollection ExecuteQueryOnDB(string query, Dictionary<string, string> parameters)
        {
            DataTable results = new DataTable();

            using (SqlConnection connection = new SqlConnection(ConfigurationManager.AppSettings.Get("DBConnectionString")))
            {
                //Prepare command to execute
                SqlCommand command = new SqlCommand(query,connection);

                //Add given parameters
                if(parameters != null) { 
                    foreach (KeyValuePair<string, string> param in parameters)
                    {
                        command.Parameters.AddWithValue("@" + param.Key, param.Value);
                    }
                }

                //Connect to DB and execute
                connection.Open();
                SqlDataAdapter dataAdapter = new SqlDataAdapter(command);
                dataAdapter.Fill(results);
                TestsLogger.Log("RowsAffected: " + results.Rows.Count);
            }

            return results.Rows;
        }
          
        protected static DataRowCollection ExecuteQueryOnDB(string query)
        {
            return ExecuteQueryOnDB(query, null);
        }
        [Given(@"I Press Tab Key")]
        [When(@"I Press Tab Key")]
        [Then(@"I Press Tab Key")]
        private void WhenIPressTabKey()
        {
            this.PressKeyOnActiveElement(Keys.Tab);

        }

        [Given(@"I Press Shift Tab Keys")]
        [When(@"I Press Shift Tab Keys")]
        [Then(@"I Press Shift Tab Keys")]
        private void WhenIPressShiftTabKeys()
        {
           this.PressKeyOnActiveElement(Keys.Shift+Keys.Tab);
        }

        [Given(@"I Press Space Bar")]
        [When(@"I Press Space Bar")]
        [Then(@"I Press Space Bar")]
        private void ThenIPressSpaceBar()
        {
            this.PressKeyOnActiveElement(Keys.Space);
        }        

        private void PressKeyOnActiveElement(string keys)
        {
            IWebElement activeElem = driver.SwitchTo().ActiveElement();
            Actions builder = new Actions(driver);
            builder.MoveToElement(activeElem).SendKeys(keys).Build().Perform();
        }

        protected static void AddDataToScenarioContextOverridingExistentKey(string key, object value)
        {
            try
            {
                ScenarioContext.Current.Add(key, value);
            }
            catch (Exception)
            {
                ScenarioContext.Current.Remove(key);
                ScenarioContext.Current.Add(key, value);
            }
        }

        protected static PageObject GetSharedPageObjectFromContext(string key)
        {
            return ScenarioContext.Current.Get<PageObject>(key);
        }

        protected static void SetSharedPageObjectInCurrentContext(string key, PageObject page)
        {
            //Save in Scenario Context - replace if already exists
            AddDataToScenarioContextOverridingExistentKey(key, page);
        }

        protected static void RemovedSharedPageObjectFromCurrentContext(string key)
        {
            //Remove from Scenario Context if exists
            try
            {
                ScenarioContext.Current.Remove(key);
            }
            catch (Exception)
            {
                //do nothing if it doesn't exist
            }
        }
    }   
}