using System;
using System.Collections.Generic;
using OpenQA.Selenium;
using Epiq.ETS.TCMS.Anywhere.Testing.E2ETest.Test_Framework.Pages.Common;
using System.Threading;
using NUnit.Framework;

namespace Epiq.ETS.TCMS.Anywhere.Testing.E2ETest.Test_Framework.Pages.Assets
{
    public class AddAsset : UnityPageBase
    {
        #region Add Asset Page Fields

        By backToAssetManagement = By.XPath("//ol/li[1]/a");
        By save = By.XPath("//button[@type='submit']");
        By cancel = By.XPath("//button[text()='CANCEL']");
        By addAsset = By.XPath("//div[contains(@class,'epiq-page-control')]/button[contains(@class,'btn btn-info')]/i[contains(@class,'fa fa-plus-circle')]");

        By backToAssetListLink = By.XPath("//ol/li[1]/a");

        public AddAsset(IWebDriver driver) : base(driver, null)
        {
        }

        public bool VerifyAddAsset { get { return this.WaitForElementToBePresent(backToAssetManagement).Displayed; } }
        
        public bool BackToAssets { get { return this.WaitForElementToBePresent(backToAssetListLink).Displayed; } }

        #endregion

        #region Methods

        public void PopulateFields(List<string> inputs)
        {
            foreach(string input in inputs)
            {
                int separator = input.IndexOf('-');
                string xpathSuffix = input.Substring(0, separator);
                string value = input.Substring(separator + 1);
                // Find the element based on Label name
                By xpath = By.XPath($"//div[label[text()='{xpathSuffix}']]//input[not(@aria-hidden='true')] | //div[label[text()='{xpathSuffix}']]//textarea");
                try
                {
                    var control = this.WaitForElementToBePresent(xpath,4);
                    if (control.Text.Contains("0.00") || GetAttrubuteValue(control, "type").Contains("text"))
                    {
                        control.Clear();
                        control.SendKeys(value);
                        this.Pause(3);
                        if (xpathSuffix.Contains("CASE #"))
                        {
                             var caseno = driver.FindElement(By.XPath("//div[label[text()='CASE # / DEBTOR NAME']]//a[@class='dropdown-item']"));
                            ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].click();", caseno);
                            this.Pause(1);
                            caseno.Click();
                        }
                        control.SendKeys(Keys.ArrowDown);
                        MoveToViewElement(control);

                        if (!driver.FindElement(By.TagName("h3")).Text.Contains("Status & Codes"))
                            control.Click();

                        this.Pause(3);

                    }
                    else if (GetAttrubuteValue(control, "type").Contains("checkbox"))
                        control.Click();

                    else
                    {
                        SelectCustomList(control, value);
                    }
                    
                }
                catch(Exception e) { new Exception($"[Failure : Check input pattern (InputLabelName-InputValue)] OR \n {e.Message}"); }                
            }
        }
     
        public void ClickOnsave()
        {
            this.WaitForElementToBePresent(save, 5).Click();
            this.Pause(3);
        }

        private void SelectCustomList(IWebElement control,string value)
        {
            ScrollDown();
            MoveToViewElement(control);
            try
            {
                var a = (control.FindElement(By.XPath(".."))).FindElement(By.XPath(".."));
                if (a.TagName.ToString().Contains("span"))
                    a.FindElement(By.XPath("..")).Click();
                a.Click();
                this.WaitForElementToBePresent(By.XPath($"//div[text()='{value}']"), 2).Click();
            }
            catch (Exception e)
            {
                JSMoveToViewElement(control);
                MoveToViewElement(control);
                control.SendKeys(Keys.Enter);
                driver.FindElement(By.XPath($"//div[text()='{value}']")).Click();                
            }

        }

        public void ClickOnAddAsset()
        {
            this.WaitForElementToBePresent(addAsset).Click();
        }

        public void HeaderTitle(string title)
        {
            Thread.Sleep(3000);
            var headerTitle = driver.FindElement(By.XPath("//ol/li[2]/span")).Text;
            Assert.IsTrue(headerTitle.Equals(title, StringComparison.OrdinalIgnoreCase));
        }

        public void ClickBackToAssetsLink()
        {
            this.WaitForElementToBeVisible(backToAssetListLink).Click();
        }


        #endregion
    }
}
