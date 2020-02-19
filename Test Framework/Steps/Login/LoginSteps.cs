using Epiq.ETS.TCMS.Anywhere.Testing.E2ETest.Test_Framework.Core;
using Epiq.ETS.TCMS.Anywhere.Testing.E2ETest.Test_Framework.Pages;
using Epiq.ETS.TCMS.Anywhere.Testing.E2ETest.Test_Framework.Pages.Common;
using Epiq.ETS.TCMS.Anywhere.Testing.E2ETest.Test_Framework.Steps.Common;
using FluentAssertions;
using System.Collections.Generic;
using TechTalk.SpecFlow;

namespace Epiq.ETS.TCMS.Anywhere.Testing.E2ETest.Test_Framework.Steps.Login
{
    [Binding]
    public class LoginSteps:StepBase
    {
        //REFACTORED
        private LoginPage loginPage = null;
        private DashboardPage dashboardPage = null;

        [Given(@"I enter to Unity Login page")]
        public void GivenIEnterToUnityLoginPage()
        {
            try {      
                          
                //If user is not logged in, login page is loaded by default                               
                loginPage = new LoginPage(driver);
                SetSharedPageObjectInCurrentContext("Dashboard",new DashboardPage(driver));
                //TODO Added this until we know the correct behevior of logout action
                //the test need to make sure the page loaded fresh.
               loginPage.Reload();

            }

            catch (MissingElementException)
            {
                //if user is already logged in then dashboard is loaded, so Logout and go to login page
                UnityPageBase navigationBar = new UnityPageBase(driver, null);
                loginPage = navigationBar.Logout();
                //dashboardPage = null;
            }

        }


        //Login page display steps

        [Then(@"I see the '(.*)' field with label '(.*)'")]
        public void ThenISeeTheUsernameFieldWithLabelAndTheInputValueIs(string fieldName, string labelText) {
            switch (fieldName)
            {
                case "username":
                    loginPage.UsernameLabel.Should().Be(labelText);
                    break;
                case "password":
                    loginPage.PasswordLabel.Should().Be(labelText);
                    break;
                case "office":
                    loginPage.OfficeNameLabel.Should().Be(labelText);
                    break;

                default:
                    ScenarioContext.Current.Pending();
                    break;
            }
        }

        [Then(@"I see the '(.*)' field input value is '(.*)'")]
        public void ThenISeeTheFieldInputValueIs(string fieldName, string value)
        {
            switch (fieldName)
            {
                case "username":
                    loginPage.UsernameValue.Trim().Should().Be(value);
                    break;
                case "password":
                    loginPage.PasswordValue.Trim().Should().Be(value);
                    break;
                case "office":
                    loginPage.OfficeNameValue.Trim().Should().Be("");
                    break;

                default:
                    ScenarioContext.Current.Pending();
                    break;
            }
        }

        [When(@"I remove the value from (.*)")]
        public void WhenIRemoveTheValueFromUsername(string field)
        {
            switch (field) { 
            case "username":
                loginPage.ClearUsernameField();
                break;

            case "password":
                loginPage.ClearPasswordField();
                break;

            case "office":
                loginPage.ClearOfficeNameField();
                break;

           default:
               ScenarioContext.Current.Pending();
               break;
            }
        }


        [Then(@"I see the login button is (.*)")]
        public void ThenISeeTheLoginButtonIs(string status)
        {
            if (status == "inactive") {
                loginPage.IsLoginButtonInactive().Should().Be(true);
                
                try{ 
                    //in case the button is clickeable, should not actually grant access
                    loginPage.ClickOnLoginButton();
                    loginPage.IsNavigationBarVisible().Should().Be(false);
                    loginPage.IsUniversalApplicationBarVisible().Should().Be(false);

                }
                catch (MissingElementException) {
                    //do nothing, is ok if not clickable
                }
                
            }
            else if (status == "active") { 
                loginPage.IsLoginButtonActive().Should().Be(true);
            }
            else { 
                ScenarioContext.Current.Pending();
            }
        }


        [Then(@"I see the '(.*)' link with reference to URL '(.*)'")]
        private void ThenISeeTheLinkWithReferenceTo(string linkText, string linkURL)
        {
            loginPage.GetLinkByExactTextAndURL(linkText, linkURL).Should().NotBeNull();
        }
        
        [Then(@"I see the Version and Copyright information is '(.*)'")]
        public void ThenISeeTheVersionAndCopyrightInformation(string copyrightInfo)
        {
            loginPage.VersionAndCopyrightInfo.Should().Be(copyrightInfo);
        }
        

        [Then(@"I cannot see the Universal App Bar and the Main Nav Region")]
        public void ThenICannotSeeTheUniversalAppBarAndTheMainNavRegion()
        {
            loginPage.IsUniversalApplicationBarVisible().Should().Be(false);
            loginPage.IsNavigationBarVisible().Should().Be(false);

        }
               
        //Login Form actions

        [When(@"I fill in all fields with (.*), (.*) and (.*)")]
        public void WhenIFillInAllFieldsWithAnd(string username, string password, string office)
        {
            loginPage.FillOutLoginForm(username, password, office);            
        }

        [When(@"I try to login with credentials (.*), (.*) and (.*)")]

        public void WhenITryToLoginWithCredentials(string username, string password, string office)
        {
                loginPage.Reload();
                loginPage.FillOutLoginForm(username, password, office);
                loginPage.ClickOnLoginButton();
        }


        [When(@"I try to login with view credentials '(.*)', '(.*)' and '(.*)'")]
        public void WhenITryToLoginWithViewCredentialsAnd(string username, string password, string office)
        {
            loginPage.Reload();
            loginPage.FillOutLoginForm(username, password, office);
            loginPage.ClickOnLoginButton();
        }

        [When(@"Login Page displays an error message reading '(.*)'")]
        [Then(@"Login Page displays an error message reading '(.*)'")]
        public void ThenLoginPageDisplaysAnErrorMessageReading(string errorMsg)
        {
            loginPage.IsPresentErrorMessage(errorMsg).Should().Be(true);
        }


        [Then(@"I can see the Universal App Bar and the Main Nav Region")]
        public void ThenICanSeeTheUniversalAppBarAndTheMainNavRegion()
        {
            UniversalAppBar appBar = dashboardPage.UniversalApplicationBar;
            NavigationBar nav = dashboardPage.NavigationBar;
        }               

        [Then(@"I see the Dashboard page")]
        public void ThenISeeDashboardPage()
        {
            dashboardPage = new DashboardPage(driver);
        }       

    }
}
