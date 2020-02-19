using System;
using System.Collections.Generic;
using OpenQA.Selenium;
using Epiq.ETS.TCMS.Anywhere.Testing.E2ETest.Test_Framework.Pages.Common;
using System.Threading;
using NUnit.Framework;
using System.Linq;

namespace Epiq.ETS.TCMS.Anywhere.Testing.E2ETest.Test_Framework.Pages.Assets
{
    public class EditAsset : UnityPageBase
    {
        #region Edit Asset Page Fields

        By backToAssetListLink = By.XPath("//a[@class='epiq-prev-page-link']");
        By editPencilButton = By.XPath("//a[@class='btn btn-info']//i[@class='fa fa-pencil']");

        public EditAsset(IWebDriver driver) : base(driver, null)
        {
        }

        public bool BackToAssets { get { return this.WaitForElementToBePresent(backToAssetListLink).Displayed; } }

        #endregion

        #region Methods

        public void ClickEditPencilButton()
        {
            IList<IWebElement> EditPencils = this.WaitForElementsToBeVisible(editPencilButton).ToList();
            int btnCount = EditPencils.Count();
            EditPencils[btnCount - 1].Click();
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
