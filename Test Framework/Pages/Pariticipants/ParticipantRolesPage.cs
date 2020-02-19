using Epiq.ETS.TCMS.Anywhere.Testing.E2ETest.Test_Framework.Pages.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using System.Threading;
using NUnit.Framework;

namespace Epiq.ETS.TCMS.Anywhere.Testing.E2ETest.Test_Framework.Pages.Pariticipants
{
    public class ParticipantRolesPage : UnityPageBase
    {
        private static string pageTitle = "UNITY";

        //Add Participant Input Locators
        private By firstNameLocator = By.XPath("//div[@class='row epiq-no-divider']/div[label[text()='FIRST NAME']]/input");
        private By middleNameLocator = By.XPath("//div[@class='row epiq-no-divider']/div[label[text()='MIDDLE NAME']]/input");
        private By lastNameLocator = By.XPath("//div[@class='row epiq-no-divider']/div[label[text()='LAST NAME']]/input");
        // private By SUFFIX_LOCATOR = By.XPath("//div[@class='row epiq-no-divider']//div[label[text()='SUFFIX']]/div/div");
        private By suffixLocator = By.XPath("//div[label[text()='SUFFIX']]//div[input[@name='suffix']]/div");
        private By genderLocator = By.XPath("//div[@class='row epiq-no-divider']/div[label[text()='GENDER']]/div");
        private By stateBarIdLocator = By.XPath("//div[@class='row epiq-no-divider']//div[label[text()='STATE BAR ID']]/input");
        private By ssnLocator = By.XPath("//div[@class='row epiq-no-divider']//div[label[text()='SSN']]/input");
        private By taxIdLocator = By.XPath("//div[@class='row epiq-no-divider']//div[label[text()='TAX ID']]/input");
        private By driverLicenseLocator = By.XPath("//div[@class='row epiq-no-divider']//div/input[@name='driversLicenseNumber']");
        private By aliasNameLocator = By.XPath("//div[@class='row']//div[label[text()='NAME']]/input");
        private By phoneNumberLocator = By.XPath("//div[@class='row']//div[label[text()='PHONE #']]/input");
        private By emailAddressLocator = By.XPath("//div[@class='row']//div[label[text()='EMAIL']]/input");
        private By addressSectionLocator = By.XPath("//div[@class='row']//div[label[text()='ADDRESS']]/textarea[@name='addAddressListItem.street']");
        private By cityLocator = By.XPath("//div[@class='row']//div[label[text()='CITY']]/input");
        private By stateLocator = By.XPath("//div[@class='row']//div[label[text()='STATE / PROVINCE']]/div/div");
        private By zipLocator = By.XPath("//div[@class='row']//div[label[text()='ZIP']]/input");
        private By rolesLocator = By.XPath("//div[@class='row']//div[label[text()='POSSIBLE ROLES']]/div/div");
        private By notesLocator = By.XPath("//div[@class='row']/div[label[text()='NOTES']]/textarea");
        private By saveButtonLocator = By.XPath("//div[@class='modal-footer']/div/button[text()='SAVE']");
        private By participantSaveLocator = By.XPath("//button[text()='SAVE']");
        //private By ALIAS_REMOVE_LOCATOR = By.XPath("//div[@class='form-group']/div[4]/div/div/div/div/div[2]/div/div[1]/i");
        private By aliasRemoveLocator = By.XPath("//div[@class='epiq-form-items']//i");
        private By emailRemoveLocator = By.XPath("//div[@class='form-group']/div[5]/div/div/div/div/div[2]/div/div[1]/i");
        private By rolesTextLocator = By.XPath("//div[@class='row'][3]/div[1]/h3");
        private By addAddressLocator = By.XPath("//div[@class='row']//button[text()='ADDRESS']");
        private By addressTypeLocator = By.XPath("//div[@class='row']//div[label[text()='TYPE']]//div[@class='Select-control']/span/div[1]");
        private By addEmailLocator = By.XPath("//div[@class='row']//button[text()='EMAIL']");
        private By emailTypeLocator = By.XPath("//div[@class='row']//div[label[text()='TYPE']]//div[@class='Select-control']/span/div[1]");
        private By addPhoneLocator = By.XPath("//div[@class='row']//button[text()='PHONE']");
        private By phoneTypeLocator = By.XPath("//div[@class='row']//div[label[text()='TYPE']]//div[@class='Select-control']/span/div[1]");
        private By addAliasLocator = By.XPath("//div[@class='row epiq-no-divider']//button[text()='ALIAS']");
        private By aliasTypeLocator = By.XPath("//div[@class='row']//div[label[text()='TYPE']]//div[@class='Select-control']/span/div[1]");
        private By titleLocator = By.XPath("//div[label[text()='TITLE']]//div[input[@name='title']]/div");
        
        //Filter Input Locator
        private By participantLocator = By.XPath("//div[label[text()='PARTICIPANT NAME']]/input");
        private By participantTypeLocator = By.XPath("//div[label[text()='TYPE']]//span/div[1]");

        //Participants page Locator
        private By caseTableRowsLocator = By.XPath("//table[contains(@class,'epiq-table table')]/tbody/tr");
        private By addParticipantLocator = By.XPath("//*[@id='epiq-main-page-wrap']/div/div[3]/div/div[2]/div/button");
        private By closeRolesLocator = By.XPath("//div[@class='modal-header']/button/span[1]");
        private By rolesListLocator = By.XPath("//div[@class='modal-content']/div[2]//table[@class='epiq-table table table-condensed']/tbody/tr");
        private By participantColumnLocator = By.XPath("//div[@class='epiq-table-wrapper clearfix ']//td[2]");

        public ParticipantRolesPage(IWebDriver driver) : base(driver, pageTitle)
        {
        }
        public void AddParticipant()
        {
            this.Pause(4);
            WaitForElementToBeVisible(addParticipantLocator,3).Click();
        }
        public void PariticipantsPage(string title)
        {
            var pageTitle = WaitForElementToBeVisible(By.XPath($"//div[@class='epiq-page-header']//h2[text()='{title}']")).Text;
            Assert.IsTrue(pageTitle.Equals(title, StringComparison.OrdinalIgnoreCase));
        }
        public void InputTitle(string title, string participantType)
        {
            if (participantType == "Individual")
            {
                WaitForElementToBeClickeable(titleLocator,2).Click();
                ScrollDown();
                WaitForElementToBeClickeable(By.XPath($"//div[text()='{title}']"),2).Click();
            }
        }
        public void InputNames(string firstName, string middleName, string lastName, string suffix)
        {
            this.Pause(3);
            ClearAndType(WaitForElementToBeVisible(firstNameLocator), firstName);
            ClearAndType(WaitForElementToBeVisible(middleNameLocator), middleName);
            ClearAndType(WaitForElementToBeVisible(lastNameLocator), lastName);
            //// ScrollUpToPageTop();
            // this.WaitForElementToBeClickeable(SUFFIX_LOCATOR).Click();
            // this.Pause(3);
            //var text =WaitForElementToBeVisible(By.XPath($"//div[@class='Select-menu']//div[aria-label()='{suffix}']"));
            // ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].scrollIntoView(true)", text,3);
            // ScrollUpToPageTop();
            // text.Click();
            WaitForElementToBeClickeable(suffixLocator, 2).Click();
            ScrollDown();
            WaitForElementToBeClickeable(By.XPath($"//div[text()='{suffix}']"), 2).Click();

        }
        public void EnterDetails(string gender, string barId, string ssn, string taxId, string license)
        {
            this.WaitForElementToBeClickeable(genderLocator).Click();
            //WaitForElementToBeClickeable(GENDER_LOCATOR,2).Click();
            ScrollDown();
            //WaitForElementToBeClickeable(By.XPath($"//div[@class='Select-menu-outer']//div[text()='{gender}']"),2).Click();         
            WaitForElementToBeClickeable(By.XPath($"//div[@class='Select-menu']//div[text()='{gender}']"), 2).Click();
            ClearAndType(WaitForElementToBeVisible(stateBarIdLocator,3), barId);
            ClearAndType(WaitForElementToBeVisible(ssnLocator), ssn);
            ClearAndType(WaitForElementToBeVisible(taxIdLocator), taxId);
            ClearAndType(WaitForElementToBeVisible(driverLicenseLocator), license);
        }
        public void InputAliasDetails(string alias, string type, string name)
        {
            this.Pause(3);
            if(alias == "ALIAS")
            {
                WaitForElementToBeClickeable(addAliasLocator).Click();
            }
            var title = WaitForElementToBeVisible(By.XPath("//div[@class='modal-content']/div/h4")).Text;
            if(title == "Add Alias")
            {
                WaitForElementToBeClickeable(aliasTypeLocator).Click();
                var aliasType = driver.FindElement(By.XPath($"//div[@class='Select-menu-outer']/div/div[text()='{type}']"));
                ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].click();", aliasType);
                this.Pause(1);
                aliasType.Click();
                this.TypeIn(WaitForElementToBeVisible(aliasNameLocator), name);
                this.WaitForElementToBeClickeable(saveButtonLocator,2).Click();
            }
        }
        public void InputPhoneDetails(string phone, string type, string phoneNumber)
        {
            this.Pause(3);
            this.ScrollWindowBy(500,250);
            if(phone == "PHONE")
            {
                WaitForElementToBeClickeable(addPhoneLocator).Click();
            }
            this.Pause(2);
            var title = WaitForElementToBeVisible(By.XPath("//div[@class='modal-content']/div/h4")).Text;
            if (title == "Add Phone")
            {
                WaitForElementToBeClickeable(phoneTypeLocator).Click();
                var PhoneType = driver.FindElement(By.XPath($"//div[@class='Select-menu-outer']/div/div[text()='{type}']"));
                ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].click();", PhoneType);
                this.Pause(1);
                PhoneType.Click();
                this.TypeIn(WaitForElementToBeVisible(phoneNumberLocator,2), phoneNumber);
                this.WaitForElementToBeClickeable(saveButtonLocator,2).Click();
            }
        }
        public void InputEmailDetails(string email, string type, string emailAddress)
        {
            this.Pause(3);
            this.ScrollWindowBy(500, 250);
            if (email == "EMAIL")
            {
                WaitForElementToBeClickeable(addEmailLocator).Click();
            }
            this.Pause(2);
            var title = WaitForElementToBeVisible(By.XPath("//div[@class='modal-content']/div/h4")).Text;
            if (title == "Add Email")
            {
                WaitForElementToBeClickeable(emailTypeLocator).Click();
                var emailType = driver.FindElement(By.XPath($"//div[@class='Select-menu-outer']/div/div[text()='{type}']"));
                ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].click();", emailType);
                this.Pause(1);
                emailType.Click();
                this.TypeIn(WaitForElementToBeVisible(emailAddressLocator,2), emailAddress);
                this.WaitForElementToBeClickeable(saveButtonLocator,2).Click();
            }
        }
        public void InputAddressDetails(string address, string type, string addressLine1, string addressLine2, string city, string state, string zip)
        {
            ScrollDownToPageBottom();
            this.Pause(3);
            if (address == "ADDRESS")
            {
                WaitForElementToBeClickeable(addAddressLocator).Click();
            }
            this.Pause(2);
            var title = WaitForElementToBeVisible(By.XPath("//div[@class='modal-content']/div/h4")).Text;
            if (title == "Add Address")
            {
                WaitForElementToBeClickeable(addressTypeLocator).Click();
                var addressType = driver.FindElement(By.XPath($"//div[@class='Select-menu-outer']/div/div[text()='{type}']"));
                ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].click();", addressType);
                this.Pause(1);
                addressType.Click();
                this.TypeIn(WaitForElementToBeVisible(addressSectionLocator,2), addressLine1);
                WaitForElementToBeVisible(addressSectionLocator).SendKeys(Keys.Enter);
                this.TypeIn(WaitForElementToBeVisible(addressSectionLocator), addressLine2);
                this.TypeIn(WaitForElementToBeVisible(cityLocator), city);
                WaitForElementToBeClickeable(stateLocator).Click();
                this.Pause(3);
                ScrollWindowBy(952,960);
                var states = driver.FindElement(By.XPath($"//div[@class='Select-menu-outer']/div/div[text()='{state}']"));
                ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].scrollIntoView(true)", states);
                states.Click();
                this.TypeIn(WaitForElementToBeVisible(zipLocator,2), zip);
                WaitForElementToBeClickeable(saveButtonLocator,2).Click();
            }
        }
        public void AddRoles(string role, string role1, string role2, string role3, string role4)
        {
            this.ScrollWindowBy(500, 250);
            var roles = WaitForElementToBeVisible(rolesTextLocator).Text;
            if (roles == role)
            {
                WaitForElementToBeClickeable(rolesLocator).Click();
                var rolesType1 = WaitForElementToBeClickeable(By.XPath($"//div[@class='Select-menu-outer']/div/div[text()='{role1}']"));
                ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].scrollIntoView(true)", rolesType1);
                this.Pause(1);
                rolesType1.Click();

                WaitForElementToBeClickeable(rolesLocator,2).Click();
                var rolesType2 = WaitForElementToBeClickeable(By.XPath($"//div[@class='Select-menu-outer']/div/div[text()='{role2}']"));
                ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].scrollIntoView(true)", rolesType2);
                rolesType2.Click();

                WaitForElementToBeClickeable(rolesLocator,2).Click();
                var rolesType3 = WaitForElementToBeClickeable(By.XPath($"//div[@class='Select-menu-outer']/div/div[text()='{role3}']"));
                ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].scrollIntoView(true)", rolesType3);
                rolesType3.Click();

                WaitForElementToBeClickeable(rolesLocator,2).Click();
                var rolesType4 = WaitForElementToBeClickeable(By.XPath($"//div[@class='Select-menu-outer']/div/div[text()='{role4}']"));
                ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].scrollIntoView(true)", rolesType4);
                rolesType4.Click();
            }
        }
        public void EnterNotes(string notes)
        {
            ClearAndType(WaitForElementToBeVisible(notesLocator,2), notes);
        }
        public void ClickSave()
        {
            WaitForElementToBeClickeable(participantSaveLocator,3).Click();
        }
        public void EnterParticipantName(string participantName)
        {
            TypeIn(WaitForElementToBeVisible(participantLocator,3), participantName);
        }
        public void VerifySavedParticipant(string participantName)
        {
            this.Pause(3);
            IList<IWebElement> rows = driver.FindElements(caseTableRowsLocator);
            int caseRows = rows.Count;
            bool isFound = false;
            for (int row = 1; row <= caseRows; row++)
            {
                IWebElement debtor = driver.FindElement(By.XPath("//div[@class='epiq-table-wrapper clearfix ']//tr[" + row + "]//td[2]"));
                var debtorName = debtor.Text;
                if (debtorName == participantName)
                {
                    isFound = true;
                    Assert.AreEqual(participantName, debtorName);
                }
                row++;
            }
            Assert.IsTrue(isFound);
        }
        public void EditParticipant(string name)
        {
            this.Pause(3);
            IList<IWebElement> rows = driver.FindElements(caseTableRowsLocator);
            int caseRows = rows.Count;
            bool isFound = false;
            for (int row = 1; row <= caseRows; row++)
            {
                IWebElement participantName = driver.FindElement(By.XPath("//div[@class='epiq-table-wrapper clearfix ']//tr[" + row + "]//td[2]"));
                string ParticipantList = participantName.Text;
                if (ParticipantList == name)
                {
                    var edit = WaitForElementToBeClickeable(By.XPath("//div[@class='epiq-table-wrapper clearfix ']//tbody/tr[" + row + "]/td[12]/a"));
                    ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].click();", edit);
                    isFound = true;
                    break;
                }
                row++;
            }
            Assert.IsTrue(isFound);
        }
        public void RemoveAliasAndEmail()
        {
            this.Pause(3);
            WaitForElementToBeClickeable(aliasRemoveLocator).Click();
            ScrollWindowBy(500,350);
            //WaitForElementToBeClickeable(EMAIL_REMOVE_LOCATOR).Click();
        }
        public void ParticipantMultipleRoles(string name, string roleType)
        {
            this.Pause(3);
            IList<IWebElement> rows = driver.FindElements(caseTableRowsLocator);
            int caseRows = rows.Count;
            bool isFound = false;
            for (int row = 1; row <= caseRows; row++)
            {
                IWebElement participantName = driver.FindElement(By.XPath("//div[@class='epiq-table-wrapper clearfix ']//tr[" + row + "]//td[2]"));
                string participantList = participantName.Text;

                if (participantList == name)
                {
                    var type = WaitForElementToBeVisible(By.XPath("//div[@class='epiq-table-wrapper clearfix ']//tr[" + row + "]//td[3]")).Text;
                    if (type == roleType)
                    {
                        var multipleRole = driver.FindElement(By.XPath("//div[@class='epiq-table-wrapper clearfix ']//tr[" + row + "]//td[3]/div/a"));
                        ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].click();", multipleRole);
                        isFound = true;
                        break;
                    }
                }
                row++;
            }
            Assert.IsTrue(isFound);
        }
        public void RolesModalTitle(string modalTitle)
        {
            var title = WaitForElementToBeVisible(By.XPath($"//div[@class='modal-content']//h4[text()='{modalTitle}']"),2).Text;
            Assert.AreEqual(title.ToLower(), modalTitle.ToLower());
        }
        public void CloseRolesModal()
        {
            WaitForElementToBeClickeable(closeRolesLocator,3).Click();
        }
        public void VerifyAlphabeticalOrder()
        {
            this.Pause(2);
            IList<IWebElement> rolesList = driver.FindElements(By.XPath("ROLES_LIST_LOCATOR"));
            var x = rolesList.Select(item => item.Text.Replace(System.Environment.NewLine, ""));
            var sorted = new List<string>();
            sorted.AddRange(x.OrderBy(o => o));
            Assert.IsTrue(x.SequenceEqual(sorted));
        }

       public void SelectType(string type)
        {
            WaitForElementToBeClickeable(participantTypeLocator,2).Click();
            var dr = driver.FindElement(By.XPath($"//div[text()='{type}']"));
            ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].scrollIntoView(true)", dr);
            this.Pause(2);
            dr.Click();
        }
    }
}
