using System;
using System.Collections.Generic;
using OpenQA.Selenium;
using Epiq.ETS.TCMS.Anywhere.Testing.E2ETest.Test_Framework.Pages.Common;
using System.Threading;
using NUnit.Framework;
using System.Linq;

namespace Epiq.ETS.TCMS.Anywhere.Testing.E2ETest.Test_Framework.Pages.Assets
{
    public class ViewAsset : UnityPageBase
    {
        #region Edit Asset Page Fields

        By backToAssetListLink = By.XPath("//a[@class='epiq-prev-page-link']");
        By viewEyeButton = By.XPath("//a[@class='btn btn-info']//i[@class='fa fa-eye']");

        public ViewAsset(IWebDriver driver) : base(driver, null)
        {
        }

        public bool BackToAssets { get { return this.WaitForElementToBePresent(backToAssetListLink).Displayed; } }

        #endregion

        #region Methods

        public void ClickViewEyeButton()
        {
            IList<IWebElement> ViewEyeList = this.WaitForElementsToBeVisible(viewEyeButton).ToList();
            int btnCount = ViewEyeList.Count();
            ViewEyeList[btnCount - 1].Click();
        }

        public void HeaderTitle(string expectedTitle)
        {
            Thread.Sleep(3000);
            var actualTitle = driver.FindElement(By.XPath($"//div[@class='epiq-page-case-modify-title']//h2[text()='{expectedTitle}']"));
            var final = actualTitle.Text;
            expectedTitle = expectedTitle.Trim();
            Assert.AreEqual(final.ToLower(), expectedTitle.ToLower());
        }

        public void ClickBackToAssetsLink()
        {
            this.WaitForElementToBeVisible(backToAssetListLink).Click();
        }

        #endregion
    }
}
