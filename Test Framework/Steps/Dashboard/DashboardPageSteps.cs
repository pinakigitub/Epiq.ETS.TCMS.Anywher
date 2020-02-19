using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System.Collections.ObjectModel;
using System.Threading;
using TechTalk.SpecFlow;
using Epiq.ETS.TCMS.Anywhere.Testing.E2ETest.Test_Framework.Steps.Common;

namespace Epiq.ETS.TCMS.Anywhere.Testing.E2ETest.Test_Framework.Core
{
    [Binding]
    public class DashboardPageSteps : CommonMethodsUnityStepBase
    {
        [Given(@"Search and select Case by text (.*)")]
        [When(@"Search and select Case by text (.*)")]
        [Then(@"Search and select Case by text (.*)")]
        public void searchAndSelectTrusteeByName(string text)
        {
            ScenarioContext.Current.Add("searchedText", text);
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
            pleaseWaitSignDissapear();
            Thread.Sleep(1500);
            IWebElement searchBar = createExistentWebElementByXpath("//*[contains(@class,'universalSearchDashboardContainer')]//span[@id='select2-universalSearchBoxInput-container']");
            searchBar.Click();
            Thread.Sleep(500);
            IWebElement typeBar = createExistentWebElementByXpath("//span[@class[contains(.,'select2-container--open')]]//input[@class='select2-search__field']");
            clickNotVisualizedElement(typeBar);
            typeStringByChar(text, typeBar);
            Thread.Sleep(1000);
            ReadOnlyCollection<IWebElement> results = createVisibleElementsCollectionByXpath("//ul[@id='select2-universalSearchBoxInput-results']/li");
            selectResultContainsSearchedText(results, text);
            pleaseWaitSignDissapear();
            IWebElement caseNameLbl = createVisibleWebElementByXpath("//span[@id='debtorName']");
        }
    }
}
