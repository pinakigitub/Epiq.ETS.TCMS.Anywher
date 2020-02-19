using Epiq.ETS.TCMS.Anywhere.Testing.E2ETest.Test_Framework.Pages.Common;
using Epiq.ETS.TCMS.Anywhere.Testing.E2ETest.Test_Framework.Utils;
using FluentAssertions;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using NUnit.Framework;



namespace Epiq.ETS.TCMS.Anywhere.Testing.E2ETest.Test_Framework.Pages.User
{
    public class AddRole : UnityPageBase
    {
        public AddRole(IWebDriver driver) : base(driver, "UNITY") { }

        private By header = By.XPath("//div[@class='epiq-page-header']//span");
        private By roleName = By.XPath("//input[@name='roleName']");
        private By description = By.XPath("//div[label[text()='DESCRIPTION']]//textarea");
        private By permissionsButton = By.XPath("//button[text()='PERMISSIONS']");
        private By permissionsAddButton = By.XPath("//button[text()='Add']");
        private By addRoleSaveButton = By.XPath("//div[@class='container']//button[text()='SAVE']");
        private By toastLocator = By.XPath("//div[@class='toastr animated rrt-success']");
        private By cancelButton = By.XPath("//div[@class='container']//button[text()='CANCEL']");
        private By deleteButton = By.XPath("//div/div/div/div/div/div/i");
        private By name = By.XPath("(//tr//td[@data-title='NAME'])[1]");


        public string GetPageHeader()
        {
           return WaitForElementToBeVisible(header).Text;
        }
        public void AddRoleName()
        {
            this.WaitForElementToBeVisible(roleName).SendKeys(FakeData.RandomUserName());
        }

        public void AddDescription()
        {
            this.WaitForElementToBeVisible(description).SendKeys(FakeData.Description());
        }
        public void SelectPermission(string permission)
        {
            ScrollDownToPageBottom();
            this.WaitForElementToBePresent(permissionsButton).Click();
            Pause(1);
            string permissionXpath = String.Format("//div[@class='row epiq-user-role-list-header']//div[text()='{0}']//div[@class='epiq-user-role-list-checkbox']", permission);
            var list = driver.FindElements(By.XPath(permissionXpath));
            foreach (IWebElement l in list)
            {
                if (l.Displayed == false)
                    ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].click();", l);
                else
                    l.Click();
            }
            this.WaitForElementToBePresent(permissionsAddButton).Click();

        }
        public void ClickOnSaveButton()
        {
            Pause(1);
            ScrollDownToPageBottom();
            this.WaitForElementToBeVisible(addRoleSaveButton).Click();
        }
        public void VerifyToastMessage()
        {
            this.WaitForElementToBeVisible(toastLocator).Displayed.Should().BeTrue();
        }
        public string GetRoleName()
        {
           return WaitForElementToBeVisible(roleName).GetAttribute("value"); 
        }
        public void EditRoleName()
        {
            SelectAndDeleteCompleteText(driver.FindElement(roleName));
            this.WaitForElementToBeVisible(roleName).SendKeys("EDIT " + FakeData.RandomUserName());
        }
        public void ClickOnCancel()
        {
            WaitForElementToBeVisible(cancelButton).Click();
        }
        public void ClickCancelAndVerifyRoleName()
        {
            string PriorEdit = GetRoleName();
            EditRoleName();
            ClickOnCancel();
            this.Pause(3);
            // string PostCancel = WaitForElementToBeVisible(Name).GetAttribute("value");
            // return PostCancel.Equals(PriorEdit);
            var PostCancel = WaitForElementToBeVisible(name).Text;
            Assert.IsTrue(PostCancel.Equals(PriorEdit, StringComparison.OrdinalIgnoreCase));

        }
         public void DeletePermissions()
        {
            WaitForElementToBeVisible(deleteButton).Click();
        }
    }
}
