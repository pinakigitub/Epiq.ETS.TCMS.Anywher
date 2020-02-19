using OpenQA.Selenium;
using System.Threading;
using System;
using Epiq.ETS.TCMS.Anywhere.Testing.E2ETest.Test_Framework.Pages.Common;
using Epiq.ETS.TCMS.Anywhere.Testing.E2ETest.Test_Framework.Core;
using Epiq.ETS.TCMS.Anywhere.Testing.E2ETest.Test_Framework.Steps.Common;
using OpenQA.Selenium.IE;

namespace Epiq.ETS.TCMS.Anywhere.Testing.E2ETest.Test_Framework.Pages
{
    public class LoginPage:UnityPageBase
    {
        //Page title
        private static string pageTitle = "UNITY";

        //UI Elements locators
        private By usernameLabel = By.XPath("//label[text()='USERNAME']");
        private By usernameInput= By.XPath("//div[label[text()='USERNAME']]//input");
        private By passwordLabel = By.XPath("//label[text()='PASSWORD']");
        private By passwordInput = By.XPath("//div[label[text()='PASSWORD']]//input");
        private By officeLabel = By.XPath("//label[text()='Office']");
        private By officeInput = By.XPath("//div[label[text()='OFFICE']]//input");
        private By loginButton = By.XPath("//button[text()='LOG IN']");
        private By inactiveLoginButton = By.XPath("//button[@id='btnLogin' and @disabled='']");

        private By passwordHelplink = By.Id("passwordHelp");
        private By helpAndTrainingLink = By.Id("helpAndTraining");        

        private By errorMessage = By.XPath("//div[@class='epiq-react-components-login-container_center-block_B7l6x']//form/div[1]");

        private By universalAppBar = By.XPath("//header-bar/nav/section/ul[@class='right']");
        private By navigationBarMenu = By.XPath("//header-bar/nav/section/ul[@class='left']");



        public LoginPage(IWebDriver driver) :base(driver, pageTitle)
        {
            try
            {
                this.WaitForBlockOverlayToDissapear();
                this.WaitForElementToBeVisible(usernameInput).Click();
            }
            catch (Exception)
            {
                this.Reload();
                this.WaitForBlockOverlayToDissapear();
                this.WaitForElementToBeVisible(usernameInput).Click();
            }
        }
                
        protected void ScrollDownToAvoidStickyHeadersOnClick()
        {
            //Move by offset of the sticky headers height....
            IWebElement topBar = this.WaitForElementToBeVisible(By.Id("top-bar"));            
            int Y = topBar.Size.Height;
            ScrollWindowBy(0, Y);
        }

        public string UsernameValue {
            get {
                return WaitForElementToBeVisible(usernameInput).Text;
            }
        }

        public string UsernameLabel
        {
            get {
                return WaitForElementToBeVisible(usernameLabel).Text;
            }
        }

        public string PasswordValue {
            get {
                return WaitForElementToBeVisible(passwordInput).Text;
            }
        }

        public string PasswordLabel {
            get {
                return WaitForElementToBeVisible(passwordLabel).Text;
            }
        }

        public string OfficeNameValue {
            get {
                return WaitForElementToBeVisible(officeInput).Text;
            }
        }

        public string OfficeNameLabel {
            get {
                return WaitForElementToBeVisible(officeLabel).Text;
            }
        }

        public Link PasswordHelpLink
        {
            get
            {
                return GetLink(passwordHelplink);
            }
        }


        public Link HelpAndTrainingLink
        {
            get
            {
                return GetLink(helpAndTrainingLink);
            }
        }


        public string ErrorMessages
        {
            get
            {
                return WaitForElementToBeVisibleAndHaveSomeText(errorMessage).Text;
            }
        }

        public bool IsPresentErrorMessage(string text)
        {
            try {
                WaitForElementToHaveText(errorMessage, text);
                return true;
            }catch (MissingElementException) { return false; }
        }

        public void ClearPasswordField()
        {
            WaitForElementToBeVisible(passwordInput).Clear();
        }

        public void ClearUsernameField()
        {
            WaitForElementToBeVisible(usernameInput).Clear();
        }

        public void ClearOfficeNameField()
        {
           WaitForElementToBeVisible(officeInput).Clear();
        }               

        public bool IsLoginButtonInactive()
        {
            try
            {
                WaitForElementToBeVisible(inactiveLoginButton);
                return true;
            }
            catch (MissingElementException)
            {
                return false;
            }
        }


        public bool IsLoginButtonActive()
        {
            try
            {
                WaitForElementToBeClickeable(loginButton);
                return true;
            }
            catch (MissingElementException)
            {
                return false;
            }
        }
                       

        public bool IsUniversalApplicationBarVisible()
        {
            try
            {
                WaitForElementToBeVisible(universalAppBar, 5);
                return true;
            }
            catch (Exception) { return false; }
        }


        public bool IsNavigationBarVisible()
        {
            try
            {
                WaitForElementToBeVisible(navigationBarMenu, 5);
                return true;
            }
            catch (Exception) { return false; }
        }


        public DashboardPage Login(string username, string password, string office)
        {
            FillOutLoginForm(username, password, office);
            ClickOnLoginButton();
            return new DashboardPage(driver);
        }


        public void FillOutLoginForm(string username, string password, string office)
        {

            IWebElement usernameWE = this.WaitForElementToBeVisible(usernameInput);            
            usernameWE.Click();
            ClearAndType(usernameWE, username);

            //WORKAROUND for IE retry on failure - commonly happens
            if (usernameWE.GetAttribute("value") != username)
            {
                usernameWE.Click();
                ClearAndType(usernameWE, username);
            }

            ClearAndType(WaitForElementToBeVisible(passwordInput), password);
            ClearAndType(WaitForElementToBeVisible(officeInput), office);
        }

        public void ClickOnLoginButton()
        {
            WaitForElementToBeClickeable(loginButton).Click();
        }
                
    }
}