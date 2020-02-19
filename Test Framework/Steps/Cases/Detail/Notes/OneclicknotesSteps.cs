using System;
using TechTalk.SpecFlow;
using Epiq.ETS.TCMS.Anywhere.Testing.E2ETest.TestFramework.Pages.Cases.Detail;
using Epiq.ETS.TCMS.Anywhere.Testing.E2ETest.Test_Framework.Core;
using Epiq.ETS.TCMS.Anywhere.Testing.E2ETest.Test_Framework.Pages;
using Epiq.ETS.TCMS.Anywhere.Testing.E2ETest.Test_Framework.Pages.Common;
using FluentAssertions;
using System.Collections.Generic;
using System.Configuration;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System.Threading;

namespace Epiq.ETS.TCMS.Anywhere.Testing.E2ETest.Test_Framework.Steps.Cases.Detail.Notes
{
    [Binding]
    public class OneclicknotesSteps : StepBase
    {
        private CaseDetailPage caseDetailPage = ((CaseDetailPage)GetSharedPageObjectFromContext("Case Detail"));

        [When(@"I Go To Oneclicknotes Tab")]
        public void WhenIGoToOneclicknotesTab()
        {
            caseDetailPage.Notes.GoToOneclicknotesTab();
        }

        [When(@"I Enter the Label text in the Label menu")]
        public void WhenIEnterTheLabelTextInTheLabelMenu()
        {
            
            driver.FindElement(By.CssSelector("input[id=oneClickNoteLabel]")).SendKeys("EPIQ cases");
        }

        [When(@"Oneclick type is (.*) meeting in the list")]
        public void WhenOneclickTypeIsMeetingInTheList(int p0)
        {
            new SelectElement(driver.FindElement(By.CssSelector("select[id=oneClickNoteType]"))).SelectByText("341 Meeting");
        }

        [When(@"I Enter the content text in content area")]
        public void WhenIEnterTheContentTextInContentArea()
        {
            Thread.Sleep(1500);
            driver.FindElement(By.TagName("textarea")).SendKeys("Unity QA Testing");
        }
        [When(@"I Click on Save button in the Oneclicknote")]
        public void WhenIClickOnSaveButtonInTheOneclicknote()
        {
            driver.FindElement(By.Id("saveButton")).Click();
        }

        [When(@"Oneclick type is Trustee in the list")]
        public void WhenOneclickTypeIsTrusteeInTheList()
        {
            new SelectElement(driver.FindElement(By.CssSelector("select[id=oneClickNoteType]"))).SelectByText("Trustee");
        }

        [When(@"Oneclick type is office in the list")]
        public void WhenOneclickTypeIsOfficeInTheList()
        {

            new SelectElement(driver.FindElement(By.CssSelector("select[id=oneClickNoteType]"))).SelectByText("Office");
        }

        [When(@"I Click on Cancel button in the Oneclicknote")]
        public void WhenIClickOnCancelButtonInTheOneclicknote()
        {
            driver.FindElement(By.Id("cancelButton")).Click();
        }

        [Then(@"I could see Manage one click notes on the header")]
        public void ThenICouldSeeManageOneClickNotesOnTheHeader()
        {
           string text = driver.FindElement(By.XPath("//*[@id='notesWindow']/div[2]/div/compose/ul/li[1]/div/h4")).Text;
        }

        [Then(@"I could able to see Label in view section")]
        public void ThenICouldAbleToSeeLabelInViewSection()
        {
            string label = driver.FindElement(By.TagName("label")).Text;label.Contains("LABEL:");

        }
        [Then(@"I Could able to see Type section")]
        public void ThenICouldAbleToSeeTypeSection()
        {
            string type = driver.FindElement(By.TagName("label")).Text; type.Contains("TYPE:");

        }

        [Then(@"I Could able to see Content section")]
        public void ThenICouldAbleToSeeContentSection()
        {
            string content = driver.FindElement(By.TagName("label")).Text;content.Contains("CONTENT:");

        }
        [When(@"I Clcik on Edit button on the window")]
        public void WhenIClcikOnEditButtonOnTheWindow()
        {
            Thread.Sleep(2500);
            driver.FindElement(By.XPath("//div[3]/i/span")).Click();
            Thread.Sleep(1500);
        }

        [When(@"I Clear the text in the Label area")]
        public void WhenIClearTheTextInTheLabelArea()
        {
            Thread.Sleep(1500);
            driver.FindElement(By.CssSelector("input[id=oneClickNoteLabel]")).Clear();
        }

        [When(@"I change the type to Trustee in the type section")]
        public void WhenIChangeTheTypeToTrusteeInTheTypeSection()
        {
            Thread.Sleep(1500);
            new SelectElement(driver.FindElement(By.CssSelector("select[id=oneClickNoteType]"))).SelectByText("Trustee");
            Thread.Sleep(1500);
        }

        [When(@"I clear the text in content area")]
        public void WhenIClearTheTextInContentArea()
        {
            Thread.Sleep(1500);
            driver.FindElement(By.XPath("html/body/main/div/router-view/case-notes-windows/note-windows/div/div/div[3]/div[2]/div/compose/ul/li[2]/div/div[2]/div[1]/div[4]/div/my-textarea/label/textarea")).Clear();
        }

    }
}
