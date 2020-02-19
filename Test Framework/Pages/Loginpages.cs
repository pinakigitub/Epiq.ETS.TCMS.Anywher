using OpenQA.Selenium;
using System.Threading;
using System;
using Epiq.ETS.TCMS.Anywhere.Testing.E2ETest.Test_Framework.Pages.Common;
using Epiq.ETS.TCMS.Anywhere.Testing.E2ETest.Test_Framework.Core;

namespace Epiq.ETS.TCMS.Anywhere.Testing.E2ETest.Test_Framework.Pages
{
    public class Loginpages: UnityPageBase
    {
    //    //Page title
     private static string pageTitle = "UNITY";


    //    //private By usernameInputs = By.XPath("//div[label[text()='USERNAME']]//input");
    //    private By PASSWORD_INPUT_LOCATOR = By.XPath("//div[label[text()='PASSWORD']]//input");
    //    private By OFFICE_LABEL_LOCATOR = By.XPath("//prefix-textbox[@id='officeName']");
    //    private By LOGIN_BUTTON_LOCATOR = By.XPath("//button[text()='LOG IN']");

        public Loginpages(IWebDriver driver, string pageTitle) : base(driver, pageTitle)
        {
        }
    }
}
