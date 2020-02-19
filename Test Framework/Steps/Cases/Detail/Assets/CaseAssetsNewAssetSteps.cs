using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading;
using TechTalk.SpecFlow;
using System.Linq;
using Epiq.ETS.TCMS.Anywhere.Testing.E2ETest.Test_Framework.Steps.Common;
using System.Data;

namespace Epiq.ETS.TCMS.Anywhere.Testing.E2ETest.Test_Framework.Core
{
    [Binding]
    public class NewAssetsPageStepDefinitions : CommonMethodsUnityStepBase
    {

        [Given(@"Verify New Assets page layout")]
        [When(@"Verify New Assets page layout")]
        [Then(@"Verify New Assets page layout")]
        public void ThenVerifyNewAssetsPageLayout()
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(50));
            Thread.Sleep(1500);
            WaitForBlockOverlayToDissapear();

            IWebElement newAssetTitle = wait.Until(ExpectedConditions.ElementIsVisible(By.Id("newClaimTitle")));
            IWebElement descLbl = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//div/label[@id='searchLabelassetDescriptionValue']")));
            IWebElement descriptionInput = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//span/input[@class='select2-search__field']")));
            IWebElement addToListCbxLbl = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//div[@class='left']/label")));
            IWebElement grayNumberContainer = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//div/p[@id='newAssetNumber']/..")));
            IWebElement newAssetNumber = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//div/p[@id='newAssetNumber']")));
            IWebElement codesTitle = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//*[@id='newAsset']/div[2]/div[1]/div[3]/span")));
            IWebElement codeSearchLbl = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//label[@id='codeSearchLabel']")));
            IWebElement codeSearchInput = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//span[@id='select2-assetCodeTextBox-container']")));
            IWebElement petitionLbl = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//div[@id='petitionGroup']/label")));
            IWebElement petitionResult = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//div/label[@id='lblPetition']")));
            IWebElement petitionValuesStatusLbl = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//label[@id='petitionValueStatus-Label']")));
            IWebElement trusteeValuesStatusLbl = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//label[@id='valueStatus-Label']")));
            IWebElement trusteeKnownStatusRbtn = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//my-radiobutton/div/div/div[1]/input[@id='valueStatus-Known']/../../div[1]")));
            IWebElement trusteeUnknownStatusRbtn = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//my-radiobutton/div/div/div[1]/input[@id='valueStatus-Unknown']/../../div[1]")));
            IWebElement trusteeNAStatusRbtn = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//my-radiobutton/div/div/div[1]/input[@id='valueStatus-NA']/../../div[1]")));
            IWebElement trusteeKnownLbl = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//my-radiobutton/div/div/div[1]/input[@id='valueStatus-Known']/../../div[2]/span")));
            IWebElement trusteeUnknownLbl = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//my-radiobutton/div/div/div[1]/input[@id='valueStatus-Unknown']/../../div[2]/span")));
            IWebElement trusteeNALbl = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//my-radiobutton/div/div/div[1]/input[@id='valueStatus-NA']/../../div[2]/span")));
            IWebElement petitionKnownStatusRbtn = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//my-radiobutton/div/div/div[1]/input[@id='petitionValueStatus-Known']/../../div[1]")));
            IWebElement petitionUnknownStatusRbtn = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//my-radiobutton/div/div/div[1]/input[@id='petitionValueStatus-Unknown']/../../div[1]")));
            IWebElement petitionKnownLbl = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//my-radiobutton/div/div/div[1]/input[@id='petitionValueStatus-Known']/../../div[2]/span")));
            IWebElement petitionUnknownLbl = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//my-radiobutton/div/div/div[1]/input[@id='petitionValueStatus-Unknown']/../../div[2]/span")));
            IWebElement subCodeSearchLbl = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//div[@id='codeSearchContainer']/label[contains(text(),'SUB CODE')]")));
            IWebElement subCodeSearchInput = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//span[@id='select2-subcodeDesktop-container']")));
            IWebElement moreOptionsExpandableTitle = wait.Until(ExpectedConditions.ElementIsVisible(By.Id("moreOptions-expandableTitle")));
            IWebElement moreOptionsExpandableArrow = wait.Until(ExpectedConditions.ElementIsVisible(By.Id("moreOptions-expandableArrow")));
            IWebElement saveAndAddButton = wait.Until(ExpectedConditions.ElementIsVisible(By.Id("saveAndAddAnotherAsset")));
            IWebElement saveButton = wait.Until(ExpectedConditions.ElementIsVisible(By.Id("saveNewAsset")));
            IWebElement cancelButton = wait.Until(ExpectedConditions.ElementIsVisible(By.Id("cancelNewAsset")));
            IWebElement descPlaceHolder = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//span[@id='select2-assetDescriptionValue-container']/span")));
            IWebElement codePlaceHolder = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//span[@id='select2-assetCodeTextBox-container']/span")));
            IWebElement subCodePlaceHolder = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//span[@id='select2-subcodeDesktop-container']/span")));

            Assert.True(newAssetTitle.Text.Contains("New Asset"));
            Assert.True(descLbl.Text.Contains("DESCRIPTION"));
            Assert.True(addToListCbxLbl.Text.Contains("Add to List"));
            Assert.True(codesTitle.Text.Contains("Codes"));
            Assert.True(codeSearchLbl.Text.Contains("CODE"));
            Assert.True(petitionLbl.Text.Contains("PETITION"));
            Assert.True(petitionResult.Text.Contains("- -"));
            Assert.True(petitionValuesStatusLbl.Text.Contains("PETITION VALUE STATUS"));
            Assert.True(trusteeValuesStatusLbl.Text.Contains("TRUSTEE VALUE STATUS"));
            Assert.True(trusteeKnownLbl.Text.Contains("Known"));
            Assert.True(trusteeUnknownLbl.Text.Contains("Unknown"));
            Assert.True(trusteeNALbl.Text.Contains("NA"));
            Assert.True(petitionKnownLbl.Text.Contains("Known"));
            Assert.True(petitionUnknownLbl.Text.Contains("Unknown"));
            Assert.True(subCodeSearchLbl.Text.Contains("SUB CODE"));
            Assert.True(saveAndAddButton.Text.Contains("SAVE AND ADD ANOTHER"));
            Assert.True(saveButton.Text.Contains("SAVE"));
            Assert.True(cancelButton.Text.Contains("CANCEL"));
            Assert.True(moreOptionsExpandableTitle.Text.Contains("More Options"));
            Assert.True(descPlaceHolder.Text.Contains("Enter Description..."));
            Assert.True(codePlaceHolder.Text.Contains("Search..."));
            Assert.True(subCodePlaceHolder.Text.Contains("Search..."));
        }

        [Given(@"Verify New Assets Calculations section layout")]
        [When(@"Verify New Assets Calculations section layout")]
        [Then(@"Verify New Assets Calculations section layout")]
        public void ThenVerifyNewAssetsCalculationsSectionLayout()
        {

            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(50));
            Thread.Sleep(1000);
            WaitForBlockOverlayToDissapear();

            IWebElement calculationsTitle = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//div[@id='assetCalculationsTitle']/span")));
            IWebElement petitionValLbl = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//my-numericbox[@id='assetPetition']/label")));
            IWebElement petitionValInput = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//input[@id='assetPetition']")));
            IWebElement trusteeValLbl = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//my-numericbox[@id='assetTrustee']/label")));
            IWebElement trusteeValInput = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//input[@id='assetTrustee']")));
            IWebElement netValReduLbl = wait.Until(ExpectedConditions.ElementIsVisible(By.Id("assetNetValueReductionsLabel")));
            IWebElement liensLbl = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//my-numericbox[@id='assetLiens']/label")));
            IWebElement liensInput = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//input[@id='assetLiens']")));
            IWebElement estCostSalLbl = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//my-numericbox[@id='assetEstimatedCostValue']/label")));
            IWebElement estCostSalInput = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//input[@id='assetEstimatedCostValue']")));
            IWebElement exemptionsLbl = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//my-numericbox[@id='assetExemption']/label")));
            IWebElement exemptionsInput = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//input[@id='assetExemption']")));
            IWebElement totalRedLbl = wait.Until(ExpectedConditions.ElementIsVisible(By.Id("assetTotalReductionsLabel")));
            IWebElement netValRedLbl = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//div[@id='assetNetValueReductions']/label")));
            IWebElement initEstValLbl = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//div[@id='assetInitialEstateValue']/label")));
            IWebElement currentEstSaleLbl = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//div[@id='assetCurrentEstateValue']/label")));
            IWebElement netValRedNumLbl = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//div[@id='assetNetValueReductions']/span")));
            IWebElement initEstValNumLbl = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//div[@id='assetInitialEstateValue']/span")));
            IWebElement currentEstSaleNumLbl = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//div[@id='assetCurrentEstateValue']/span")));
            IWebElement form1PreviewTitle = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//div[@class='formOnePreviewTitle']/strong")));
            IWebElement assetPetitionPosition = wait.Until(ExpectedConditions.ElementIsVisible(By.Id("assetPetitionPosition")));
            IWebElement assetPetitionLabel = wait.Until(ExpectedConditions.ElementIsVisible(By.Id("assetPetitionLabel")));
            IWebElement assetNetPosition = wait.Until(ExpectedConditions.ElementIsVisible(By.Id("assetNetPosition")));
            IWebElement assetNetLabel = wait.Until(ExpectedConditions.ElementIsVisible(By.Id("assetNetLabel")));
            IWebElement assetPetitionValue = wait.Until(ExpectedConditions.ElementIsVisible(By.Id("assetPetitionValue")));
            IWebElement assetNetValue = wait.Until(ExpectedConditions.ElementIsVisible(By.Id("assetNetValue")));
            IWebElement assetAbandonedValue = wait.Until(ExpectedConditions.ElementIsVisible(By.Id("assetAbandonedValue")));
            IWebElement assetSalesValue = wait.Until(ExpectedConditions.ElementIsVisible(By.Id("assetSalesValue")));
            IWebElement assetRemainingValue = wait.Until(ExpectedConditions.ElementIsVisible(By.Id("assetRemainingValue")));
            IWebElement assetAbandonedPosition = wait.Until(ExpectedConditions.ElementIsVisible(By.Id("assetAbandonedPosition")));
            IWebElement assetAbandonedLabel = wait.Until(ExpectedConditions.ElementIsVisible(By.Id("assetAbandonedLabel")));
            IWebElement assetSalesPosition = wait.Until(ExpectedConditions.ElementIsVisible(By.Id("assetSalesPosition")));
            IWebElement assetSalesLabel = wait.Until(ExpectedConditions.ElementIsVisible(By.Id("assetSalesLabel")));
            IWebElement assetRemainingPosition = wait.Until(ExpectedConditions.ElementIsVisible(By.Id("assetRemainingPosition")));
            IWebElement assetRemainingLabel = wait.Until(ExpectedConditions.ElementIsVisible(By.Id("assetRemainingLabel")));

            Assert.True(calculationsTitle.Text.Contains("Calculations"));
            Assert.True(petitionValLbl.Text.Contains("PETITION VALUE"));
            Assert.True(trusteeValLbl.Text.Contains("TRUSTEE VALUE"));
            Assert.True(netValReduLbl.Text.Contains("Net Value Reductions"));
            Assert.True(liensLbl.Text.Contains("LIENS"));
            Assert.True(estCostSalLbl.Text.Contains("EST. COST OF SALE"));
            Assert.True(exemptionsLbl.Text.Contains("EXEMPTIONS"));
            Assert.True(totalRedLbl.Text.Contains("Total Reductions: $ 0.00"));
            Assert.True(netValRedLbl.Text.Contains("NET VALUE REDUCTIONS"));
            Assert.True(netValRedNumLbl.Text.Contains("$0.00"));
            Assert.True(initEstValLbl.Text.Contains("INITIAL ESTATE VALUE"));
            Assert.True(initEstValNumLbl.Text.Contains("$0.00"));
            Assert.True(currentEstSaleLbl.Text.Contains("CURRENT ESTATE VALUE"));
            Assert.True(currentEstSaleNumLbl.Text.Contains("$0.00"));
            Assert.True(form1PreviewTitle.Text.Contains("Form 1 Preview"));
            Assert.True(assetPetitionPosition.Text.Contains("2"));
            Assert.True(assetPetitionLabel.Text.Contains("Petition/Unsched Value"));
            Assert.True(assetPetitionValue.Text.Contains("$0.00"));
            Assert.True(assetNetPosition.Text.Contains("3"));
            Assert.True(assetNetLabel.Text.Contains("Net Value"));
            Assert.True(assetNetValue.Text.Contains("$0.00"));
            Assert.True(assetAbandonedPosition.Text.Contains("4"));
            Assert.True(assetAbandonedLabel.Text.Contains("Abandoned"));
            Assert.True(assetAbandonedValue.Text.Contains("No"));
            Assert.True(assetSalesPosition.Text.Contains("5"));
            Assert.True(assetSalesLabel.Text.Contains("Sales"));
            Assert.True(assetSalesValue.Text.Contains("$0.00"));
            Assert.True(assetRemainingPosition.Text.Contains("6"));
            Assert.True(assetRemainingLabel.Text.Contains("Remaining Value/FA"));
            Assert.True(assetRemainingValue.Text.Contains("$0.00"));
        }

        [Given(@"Verify Assets Summary section layout")]
        [When(@"Verify Assets Summary section layout")]
        [Then(@"Verify Assets Summary section layout")]
        public void ThenVerifyAssetsSummarySectionLayout()
        {

            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
            Thread.Sleep(1000);

            WaitForBlockOverlayToDissapear();
            IReadOnlyCollection<IWebElement> totalListedAssets = wait.Until(ExpectedConditions.PresenceOfAllElementsLocatedBy(By.XPath("//li[@class='assetListItem']")));
            IReadOnlyCollection<IWebElement> scheduledListedAssets = wait.Until(ExpectedConditions.PresenceOfAllElementsLocatedBy(By.XPath("//div/span[1][contains(text(),'Scheduled')]")));
            IReadOnlyCollection<IWebElement> unscheduledListedAssets = wait.Until(ExpectedConditions.PresenceOfAllElementsLocatedBy(By.XPath("//div/span[1][contains(text(),'Unscheduled')]")));
            IReadOnlyCollection<IWebElement> fullyAdmnListedAssets = wait.Until(ExpectedConditions.PresenceOfAllElementsLocatedBy(By.XPath("//span[@class='assetStatusGreen au-target']")));
            string assetsTotal = "(" + totalListedAssets.Count.ToString() + ")";
            string scheduledAssets = "(" + scheduledListedAssets.Count.ToString() + ")";
            string unscheduledAssets = "(" + unscheduledListedAssets.Count.ToString() + ")";
            string fullyAdmnAssets = "(" + fullyAdmnListedAssets.Count.ToString() + ")";
            string notAdmAssets = "(" + (totalListedAssets.Count - fullyAdmnListedAssets.Count).ToString() + ")";
            IWebElement assetsDetailTitle = wait.Until(ExpectedConditions.ElementIsVisible(By.Id("detailTabTitle-Asset Detail")));
            IWebElement assetSummaryTitle = wait.Until(ExpectedConditions.ElementIsVisible(By.Id("assetSummaryTitle")));
            IWebElement assetsSummaryCard = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//card[1]")));
            IWebElement allAssetsMiniCard = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//div/article[1]/header/h1[contains(text(),'All Assets')]/../../../article")));
            IWebElement allAssetsTitle = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//div/article[1]/header/h1[contains(text(),'All Assets')]")));
            IWebElement allAssetsRVLblLeft = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//header/h1[contains(text(),'All Assets')]/../../div/div[1]/div[1]/p")));
            IWebElement allAssetsRVLblRight = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//header/h1[contains(text(),'All Assets')]/../../div/div[1]/div[2]/p")));
            IWebElement allAssetsPVLblLeft = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//header/h1[contains(text(),'All Assets')]/../../div/div[2]/div[1]/p")));
            IWebElement allAssetsPVLblRight = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//header/h1[contains(text(),'All Assets')]/../../div/div[2]/div[2]/p")));
            IWebElement allAssetsExLblLeft = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//header/h1[contains(text(),'All Assets')]/../../div/div[3]/div[1]/p")));
            IWebElement allAssetsExLblRight = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//header/h1[contains(text(),'All Assets')]/../../div/div[3]/div[2]/p")));
            IWebElement allAssetsSalesLblLeft = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//header/h1[contains(text(),'All Assets')]/../../div/div[4]/div[1]/p")));
            IWebElement allAssetsSalesLblRight = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//header/h1[contains(text(),'All Assets')]/../../div/div[4]/div[2]/p")));
            IWebElement scheduledMiniCard = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//div/article[1]/header/h1[contains(text(),'Scheduled')]/../../../article")));
            IWebElement scheduledAssetsTitle = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//div/article[1]/header/h1[contains(text(),'Scheduled')]")));
            IWebElement scheduledRVLblLeft = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//header/h1[contains(text(),'Scheduled')]/../../div/div[1]/div[1]/p")));
            IWebElement scheduledRVLblRight = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//header/h1[contains(text(),'Scheduled')]/../../div/div[1]/div[2]/p")));
            IWebElement scheduledPVLblLeft = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//header/h1[contains(text(),'Scheduled')]/../../div/div[2]/div[1]/p")));
            IWebElement scheduledPVLblRight = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//header/h1[contains(text(),'Scheduled')]/../../div/div[2]/div[2]/p")));
            IWebElement scheduledExLblLeft = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//header/h1[contains(text(),'Scheduled')]/../../div/div[3]/div[1]/p")));
            IWebElement scheduledExLblRight = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//header/h1[contains(text(),'Scheduled')]/../../div/div[3]/div[2]/p")));
            IWebElement scheduledSalesLblLeft = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//header/h1[contains(text(),'Scheduled')]/../../div/div[4]/div[1]/p")));
            IWebElement scheduledSalesLblRight = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//header/h1[contains(text(),'Scheduled')]/../../div/div[4]/div[2]/p")));
            IWebElement unscheduledMiniCard = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//div/article[1]/header/h1[contains(text(),'Unscheduled')]/../../../article")));
            IWebElement unscheduledAssetsTitle = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//div/article[1]/header/h1[contains(text(),'Unscheduled')]")));
            IWebElement unscheduledRVLblLeft = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//header/h1[contains(text(),'Unscheduled')]/../../div/div[1]/div[1]/p")));
            IWebElement unscheduledRVLblRight = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//header/h1[contains(text(),'Unscheduled')]/../../div/div[1]/div[2]/p")));
            IWebElement unscheduledPVLblLeft = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//header/h1[contains(text(),'Unscheduled')]/../../div/div[2]/div[1]/p")));
            IWebElement unscheduledPVLblRight = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//header/h1[contains(text(),'Unscheduled')]/../../div/div[2]/div[2]/p")));
            IWebElement unscheduledExLblLeft = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//header/h1[contains(text(),'Unscheduled')]/../../div/div[3]/div[1]/p")));
            IWebElement unscheduledExLblRight = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//header/h1[contains(text(),'Unscheduled')]/../../div/div[3]/div[2]/p")));
            IWebElement unscheduledSalesLblLeft = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//header/h1[contains(text(),'Unscheduled')]/../../div/div[4]/div[1]/p")));
            IWebElement unscheduledSalesLblRight = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//header/h1[contains(text(),'Unscheduled')]/../../div/div[4]/div[2]/p")));
            IWebElement fullyAdmMiniCard = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//div/article[1]/header/h1[contains(text(),'Fully Administered')]/../../../article")));
            IWebElement fullyAdmAssetsTitle = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//div/article[1]/header/h1[contains(text(),'Fully Administered')]")));
            IWebElement fullyAdmRVLblLeft = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//header/h1[contains(text(),'Fully Administered')]/../../div/div[1]/div[1]/p")));
            IWebElement fullyAdmRVLblRight = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//header/h1[contains(text(),'Fully Administered')]/../../div/div[1]/div[2]/p")));
            IWebElement fullyAdmPVLblLeft = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//header/h1[contains(text(),'Fully Administered')]/../../div/div[2]/div[1]/p")));
            IWebElement fullyAdmPVLblRight = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//header/h1[contains(text(),'Fully Administered')]/../../div/div[2]/div[2]/p")));
            IWebElement fullyAdmExLblLeft = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//header/h1[contains(text(),'Fully Administered')]/../../div/div[3]/div[1]/p")));
            IWebElement fullyAdmExLblRight = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//header/h1[contains(text(),'Fully Administered')]/../../div/div[3]/div[2]/p")));
            IWebElement fullyAdmSalesLblLeft = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//header/h1[contains(text(),'Fully Administered')]/../../div/div[4]/div[1]/p")));
            IWebElement fullyAdmSalesLblRight = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//header/h1[contains(text(),'Fully Administered')]/../../div/div[4]/div[2]/p")));

            Assert.True(assetsDetailTitle.Text.Contains("Asset Detail"));
            Assert.True(assetSummaryTitle.Text.Contains("Asset Summary"));
            Assert.True(allAssetsTitle.Text.Contains("All Assets " + assetsTotal));
            Assert.True(scheduledAssetsTitle.Text.Contains("Scheduled " + scheduledAssets));
            Assert.True(unscheduledAssetsTitle.Text.Contains("Unscheduled " + unscheduledAssets));
            Assert.True(fullyAdmAssetsTitle.Text.Contains("Fully Administered " + fullyAdmnAssets));
            Assert.True(allAssetsRVLblLeft.Text.Contains("Remaining Value"));
            Assert.True(allAssetsRVLblRight.Text.Contains("$0.00"));
            Assert.True(allAssetsPVLblLeft.Text.Contains("Petition Value"));
            Assert.True(allAssetsExLblLeft.Text.Contains("Exemptions"));
            Assert.True(allAssetsSalesLblLeft.Text.Contains("Sales"));
            Assert.True(scheduledRVLblLeft.Text.Contains("Remaining Value"));
            Assert.True(scheduledRVLblRight.Text.Contains("$0.00"));
            Assert.True(scheduledPVLblLeft.Text.Contains("Petition Value"));
            Assert.True(scheduledExLblLeft.Text.Contains("Exemptions"));
            Assert.True(scheduledSalesLblLeft.Text.Contains("Sales"));
            Assert.True(unscheduledRVLblLeft.Text.Contains("Remaining Value"));
            Assert.True(unscheduledRVLblRight.Text.Contains("$0.00"));
            Assert.True(unscheduledPVLblLeft.Text.Contains("Petition Value"));
            Assert.True(unscheduledExLblLeft.Text.Contains("Exemptions"));
            Assert.True(unscheduledSalesLblLeft.Text.Contains("Sales"));
            Assert.True(fullyAdmRVLblLeft.Text.Contains("Remaining Value"));
            Assert.True(fullyAdmRVLblRight.Text.Contains("$0.00"));
            Assert.True(fullyAdmPVLblLeft.Text.Contains("Petition Value"));
            Assert.True(fullyAdmExLblLeft.Text.Contains("Exemptions"));
            Assert.True(fullyAdmSalesLblLeft.Text.Contains("Sales"));



            IWebElement slider = createExistentWebElementByXpath("//div[@class='swiper-wrapper']/div[5]");
            IWebElement assetsNavItem = createExistentWebElementByXpath("//a[@id='navItem-Assets']");

            drapAndDropElementOrWindow(slider, 30, 0);
            drapAndDropElementOrWindow(assetsNavItem, 0, 100);

            IWebElement notAdmMiniCard = createExistentWebElementByXpath("//div/article[1]/header/h1[contains(text(),'Not Administered')]/../../../article");
            IWebElement notAdmAssetsTitle = createExistentWebElementByXpath("//div/article[1]/header/h1[contains(text(),'Not Administered')]");
            IWebElement notAdmRVLblLeft = createExistentWebElementByXpath("//header/h1[contains(text(),'Not Administered')]/../../div/div[1]/div[1]/p");
            IWebElement notAdmRVLblRight = createExistentWebElementByXpath("//header/h1[contains(text(),'Not Administered')]/../../div/div[1]/div[2]/p");
            IWebElement notAdmPVLblLeft = createExistentWebElementByXpath("//header/h1[contains(text(),'Not Administered')]/../../div/div[2]/div[1]/p");
            IWebElement notAdmPVLblRight = createExistentWebElementByXpath("//header/h1[contains(text(),'Not Administered')]/../../div/div[2]/div[2]/p");
            IWebElement notAdmExLblLeft = createExistentWebElementByXpath("//header/h1[contains(text(),'Not Administered')]/../../div/div[3]/div[1]/p");
            IWebElement notAdmExLblRight = createExistentWebElementByXpath("//header/h1[contains(text(),'Not Administered')]/../../div/div[3]/div[2]/p");
            IWebElement notAdmSalesLblLeft = createExistentWebElementByXpath("//header/h1[contains(text(),'Not Administered')]/../../div/div[4]/div[1]/p");
            IWebElement notAdmSalesLblRight = createExistentWebElementByXpath("//header/h1[contains(text(),'Not Administered')]/../../div/div[4]/div[2]/p");

            Assert.True(notAdmAssetsTitle.Text.Contains("Not Administered " + notAdmAssets));
            Assert.True(notAdmRVLblLeft.Text.Contains("Remaining Value"));
            Assert.True(notAdmRVLblRight.Text.Contains("$0.00"));
            Assert.True(notAdmPVLblLeft.Text.Contains("Petition Value"));
            Assert.True(notAdmExLblLeft.Text.Contains("Exemptions"));
            Assert.True(notAdmSalesLblLeft.Text.Contains("Sales"));
        }

        [Given(@"I count listed Assets")]
        [When(@"I count listed Assets")]
        [Then(@"I count listed Assets")]
        public void GivenICountListedAssets()
        {

            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(50));
            Thread.Sleep(1000);
            WaitForBlockOverlayToDissapear();
            IReadOnlyCollection<IWebElement> totalListedAssets = wait.Until(ExpectedConditions.PresenceOfAllElementsLocatedBy(By.XPath("//li[@class='assetListItem']")));
            int assetsTotal = totalListedAssets.Count;
            AddDataToScenarioContextOverridingExistentKey("totalListedAssets", assetsTotal);
        }

        [Given(@"I count (.*) listed Assets")]
        [When(@"I count (.*) listed Assets")]
        [Then(@"I count (.*) listed Assets")]
        public void countNeededListedAssets(string assetType)
        {

            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(50));
            Thread.Sleep(1000);
            WaitForBlockOverlayToDissapear();
            string collectionXpath = "//div/span[1][contains(text(),'" + assetType + "')]";
            IReadOnlyCollection<IWebElement> listedAssetsPerType = null;
            IReadOnlyCollection<IWebElement> totalListedAssets = wait.Until(ExpectedConditions.PresenceOfAllElementsLocatedBy(By.XPath("//li[@class='assetListItem']")));
            int assetsTotalInt = 0;
            string assetsTotalString = "";


            if (assetType == "Scheduled")
            {
                listedAssetsPerType = wait.Until(ExpectedConditions.PresenceOfAllElementsLocatedBy(By.XPath(collectionXpath)));
                assetsTotalInt = listedAssetsPerType.Count;
                assetsTotalString = Convert.ToString(assetsTotalInt);
            }
            else if (assetType == "Unscheduled")
            {
                listedAssetsPerType = wait.Until(ExpectedConditions.PresenceOfAllElementsLocatedBy(By.XPath(collectionXpath)));
                assetsTotalInt = listedAssetsPerType.Count;
                assetsTotalString = Convert.ToString(assetsTotalInt);
            }
            else if (assetType == "Fully Administered")
            {
                listedAssetsPerType = wait.Until(ExpectedConditions.PresenceOfAllElementsLocatedBy(By.XPath("//span[@class='assetStatusGreen au-target']")));
                assetsTotalInt = listedAssetsPerType.Count;
                assetsTotalString = Convert.ToString(assetsTotalInt);
            }
            else
            {
                listedAssetsPerType = wait.Until(ExpectedConditions.PresenceOfAllElementsLocatedBy(By.XPath("//span[@class='assetStatusGreen au-target']")));
                assetsTotalInt = totalListedAssets.Count - listedAssetsPerType.Count;
                assetsTotalString = Convert.ToString(assetsTotalInt);
            }


            AddDataToScenarioContextOverridingExistentKey("assetsTotalPerTypeInt", assetsTotalInt);
            AddDataToScenarioContextOverridingExistentKey("assetsTotalPerTypeString", assetsTotalString);
            AddDataToScenarioContextOverridingExistentKey("allAssetsInt", totalListedAssets.Count);
            AddDataToScenarioContextOverridingExistentKey("allAssetsString", totalListedAssets.Count.ToString());
        }

        [Given(@"Verify New Asset number is next in sequence")]
        [When(@"Verify New Asset number is next in sequence")]
        [Then(@"Verify New Asset number is next in sequence")]
        public void ThenVerifyNewAssetNumberIsNextInSequence()
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(50));
            WaitForBlockOverlayToDissapear();
            string nextSeqNumber = Convert.ToString(ScenarioContext.Current.Get<int>("totalListedAssets") + 1);
            IWebElement newAssetNumber = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//div/p[@id='newAssetNumber']")));
            Assert.True(newAssetNumber.Text == nextSeqNumber);
        }

        [Given(@"Verify first New Asset number is 1")]
        [When(@"Verify first New Asset number is 1")]
        [Then(@"Verify first New Asset number is 1")]
        public void ThenVerifyFirstNewAssetNumberIs()
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(50));
            WaitForBlockOverlayToDissapear();
            IWebElement newAssetNumber = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//div/p[@id='newAssetNumber']")));
            Assert.True(newAssetNumber.Text == "1");
        }

        [Given(@"Click New Asset button")]
        [When(@"Click New Asset button")]
        [Then(@"Click New Asset button")]
        public void GivenClickNewAssetButton()
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(50));
            WaitForBlockOverlayToDissapear();
            Thread.Sleep(500);
            IWebElement newAssetButton = wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//ul/li/a[@id='navItem-New']")));
            IWebElement selectionSummaryCard = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//span[@id='assetMenuTitle']/../../../..")));
            scrollToElement(selectionSummaryCard);
            clickNotVisualizedElement(newAssetButton);
            WaitForBlockOverlayToDissapear();
        }

        [Given(@"Search Description by text (.*)")]
        [When(@"Search Description by text (.*)")]
        [Then(@"Search Description by text (.*)")]
        public void WhenSearchDescriptionByText(string text)
        {

            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(50));
            AddDataToScenarioContextOverridingExistentKey("searchedDesc", text);
            WaitForBlockOverlayToDissapear();
            IWebElement typeBar = wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//span/input[@class='select2-search__field']")));
            Thread.Sleep(500);
            char[] trustee = text.ToCharArray();

            foreach (char a in trustee)
            {
                typeBar.SendKeys(a.ToString());
                Thread.Sleep(50);
            }
        }

        [Given(@"Search Code by text '(.*)'")]
        [When(@"Search Code by text '(.*)'")]
        [Then(@"Search Code by text '(.*)'")]
        public void WhenSearchCodeByText(string text)
        {

            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(50));
            WaitForBlockOverlayToDissapear();
            IWebElement searchBar = wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//span[@id='select2-assetCodeTextBox-container']/../span[2]")));
            searchBar.Click();
            Thread.Sleep(500);
            IWebElement typeBar = wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//span/input[@class='select2-search__field']")));
            Thread.Sleep(500);
            typeStringByChar(text, typeBar);
         }

        [Given(@"Verify dropdown results from '(.*)' field are sorted ascending")]
        [When(@"Verify dropdown results from '(.*)' field are sorted ascending")]
        [Then(@"Verify dropdown results from '(.*)' field are sorted ascending")]
        public void verifyDropDownResultsSorAsc(string text)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(25));
            ReadOnlyCollection<IWebElement> columnSelected = null;
            var columnSelected2 = (IOrderedEnumerable<IWebElement>)null;
            bool equal = false;

            //string columnNumber = null;
            if (text == "Description")
            {
                columnSelected = wait.Until(ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.XPath("//ul[@id='select2-assetDescriptionValue-results']/li")));
                columnSelected2 = columnSelected.OrderBy(a => a.Text);
                equal = columnSelected.SequenceEqual(columnSelected2);
            }
            else if (text == "Code")
            {
                columnSelected = wait.Until(ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.XPath("//ul[@id='select2-assetCodeTextBox-results']/li")));
                columnSelected2 = columnSelected.OrderBy(a => a.Text);
                equal = columnSelected.SequenceEqual(columnSelected2);
            }
            else if (text == "Sub Code")
            {
                columnSelected = wait.Until(ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.XPath("//ul[@id='select2-subcodeDesktop-results']/li")));
                columnSelected2 = columnSelected.OrderBy(a => a.Text);
                equal = columnSelected.SequenceEqual(columnSelected2);
            }

        }

        [Given(@"Search subCode by text '(.*)'")]
        [When(@"Search subCode by text '(.*)'")]
        [Then(@"Search subCode by text '(.*)'")]
        public void WhenSearchSubCodeByText(string text)
        {
            Actions builder = new Actions(driver);
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(50));
            WaitForBlockOverlayToDissapear();
            IWebElement searchBar = wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//span[@id='select2-subcodeDesktop-container']/../span[2]")));
            searchBar.Click();
            Thread.Sleep(500);
            IWebElement typeBar = wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//span/input[@class='select2-search__field']")));
            typeStringByChar(text, typeBar);
        }

        [Given(@"I display and count all predictive results in field (.*)")]
        [When(@"I display and count all predictive results in field (.*)")]
        [Then(@"I display and count all predictive results in field (.*)")]
        public void countListedSubCodes(string text)
        {
            WaitForBlockOverlayToDissapear();
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
            IWebElement typeBar = wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//span/input[@class='select2-search__field']")));
            ReadOnlyCollection<IWebElement> listedCodes = null;

            if (text == "Code")
            {
                listedCodes = createPresentElementsCollectionByXpath("//ul[@id[contains(.,'select2-assetCodeTextBox-results')]]/li/div[@id[not(contains(.,'-1'))]]");
                scrollListDown(listedCodes, 24, typeBar, "//ul[@id[contains(.,'select2-assetCodeTextBox-results')]]/li/div[@id[not(contains(.,'-1'))]]");
            }
            else if (text == "Sub Code")
            {
                 listedCodes = createPresentElementsCollectionByXpath("//ul[@id[contains(.,'select2-subcodeDesktop-results')]]/li/div[@id[not(contains(.,'-1'))]]");
                scrollListDown(listedCodes, 1, typeBar, "//ul[@id[contains(.,'select2-subcodeDesktop-results')]]/li/div[@id[not(contains(.,'-1'))]]");
            }
        }

        [Given(@"Verify displayed predictive results are correct in field (.*)")]
        [When(@"Verify displayed predictive results are correct in field (.*)")]
        [Then(@"Verify displayed predictive results are correct in field (.*)")]
        public void verifyDisplayedCodesCorrect(string text)
        {
            Thread.Sleep(1000);
            /////////// Query to DB and validations between UI and DB ///////////
            DataRowCollection rows = null;
            rows = ExecuteQueryOnDBWithString(Properties.Resources.getCodesAndSubCodesRelationList);
            ReadOnlyCollection<IWebElement> results = null;

            if (text == "Code")
            {
                results = createPresentElementsCollectionByXpath("//ul[@id[contains(.,'select2-assetCodeTextBox-results')]]/li/div[@id[not(contains(.,'-1'))]]");
                assertCollectionSortAscending(results);
                assertEachElementTextInUIIsContainedInDB(results, rows, 1);
                assertEachElementTextInUIIsContainedInDB(results, rows, 2);
            }
            else if (text == "Sub Code")
            {
                results = createPresentElementsCollectionByXpath("//ul[@id[contains(.,'select2-subcodeDesktop-results')]]/li/div[@id[not(contains(.,'-1'))]]");
                assertCollectionSortAscending(results);
                assertEachElementTextInUIIsContainedInDB(results, rows, 4);
                assertEachElementTextInUIIsContainedInDB(results, rows, 5);
            }
        }

        [Given(@"Verify New Asset Description predictive search results")]
        [When(@"Verify New Asset Description predictive search results")]
        [Then(@"Verify New Asset Description predictive search results")]
        public void ThenVerifyNewAssetDescriptionPredictiveSearchResults()
        {
            var searchedDesc = ScenarioContext.Current.Get<string>("searchedDesc");
            Thread.Sleep(1500);

            ReadOnlyCollection<IWebElement> predictiveSearchResults = driver.FindElements(By.XPath("//ul[@id='select2-assetDescriptionValue-results']/li"));
            bool wasFound = false;


            foreach (var result in predictiveSearchResults)
            {
                string searchResult = result.Text;
                wasFound = false;
                if (searchResult.Contains(searchedDesc))
                {
                    wasFound = true;
                    break;
                }
            }
            if (!wasFound)
            {
                Assert.Fail("Element " + searchedDesc + " was not Found");
            }
        }

        [Given(@"Click Cancel New Asset button")]
        [When(@"Click Cancel New Asset button")]
        [Then(@"Click Cancel New Asset button")]
        public void WhenClickCancelNewAssetButton()
        {

            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(50));
            WaitForBlockOverlayToDissapear();
            Thread.Sleep(500);
            scrollToElement(driver.FindElement(By.XPath("//div[@class='formOnePreview']")));
            clickNotVisualizedElement(driver.FindElement(By.Id("cancelNewAsset")));
            ignoreNoSuchElementException();
            wait.Until(ExpectedConditions.InvisibilityOfElementLocated(By.Id("formOneNote-expandableSection")));
            IWebElement newAssetButton = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//ul/li/a[@id='navItem-New']")));
            WaitForBlockOverlayToDissapear();
        }

        [Given(@"Click More Options button in New Asset page")]
        [When(@"Click More Options button in New Asset page")]
        [Then(@"Click More Options button in New Asset page")]
        public void WhenClickMoreOptionsNewAssetButton()
        {
            WaitForBlockOverlayToDissapear();
            Thread.Sleep(2000);
            scrollToElement(driver.FindElement(By.XPath("//div[@class='formOnePreview']")));
            clickNotVisualizedElement(driver.FindElement(By.Id("moreOptions-expandableTitle")));
            WaitForBlockOverlayToDissapear();
        }

        [Given(@"Click Less Options button in New Asset page")]
        [When(@"Click Less Options button in New Asset page")]
        [Then(@"Click Less Options button in New Asset page")]
        public void ClickLessOptionsNewAssetButton()
        {

            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(50));
            WaitForBlockOverlayToDissapear();
            Thread.Sleep(500);
            IWebElement lessOptionsButton = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//div[@id='moreOptions-expandableSectionBottom']/span")));
            Assert.True(lessOptionsButton.Text == "Less Options");
            clickNotVisualizedElement(lessOptionsButton);
            ignoreNoSuchElementException();
            wait.Until(ExpectedConditions.InvisibilityOfElementLocated(By.Id("formOneNote-expandableSection")));
            wait.Until(ExpectedConditions.InvisibilityOfElementLocated(By.Id("optionsAndDatesSection-expandableSection")));
            wait.Until(ExpectedConditions.InvisibilityOfElementLocated(By.Id("reservedStatus-expandableSection")));
            WaitForBlockOverlayToDissapear();
        }

        [Given(@"Verify New Assets More Options section layout")]
        [When(@"Verify New Assets More Options section layout")]
        [Then(@"Verify New Assets More Options section layout")]
        public void ThenVerifyNewAssetsMoreOptionsSectionLayout()
        {

            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(50));
            WaitForBlockOverlayToDissapear();
            Thread.Sleep(1000);

            IWebElement formOneNoteExpandableTitle = wait.Until(ExpectedConditions.ElementIsVisible(By.Id("formOneNote-expandableTitle")));
            IWebElement formOneNoteTitle = wait.Until(ExpectedConditions.ElementIsVisible(By.Id("formOneNoteTitle")));
            IWebElement formOneNoteTextArea = wait.Until(ExpectedConditions.ElementIsVisible(By.Id("formOneNoteTextArea")));
            IWebElement charCounter1 = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//div[@id='textContainer']//label[@class='remainingCharacters']")));
            IWebElement optionsAndDatesSectionExpandableTitle = wait.Until(ExpectedConditions.ElementIsVisible(By.Id("optionsAndDatesSection-expandableTitle")));
            IWebElement fullyAdministeredDatebox = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//my-datebox[@id='fullyAdministeredDatebox']/div/label")));
            IWebElement fullyAdministeredDateboxInput = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//my-datebox[@id='fullyAdministeredDatebox']/div/label/input[contains(@placeholder, 'MM/DD/YYYY')]")));
            IWebElement fullyAdministeredDateboxCalendar = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//my-datebox[@id='fullyAdministeredDatebox']/div/label/i")));
            IWebElement firstUSTReportDatebox = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//my-datebox[@id='firstUSTReportDatebox']/div/label")));
            IWebElement firstUSTReportDateboxInput = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//my-datebox[@id='firstUSTReportDatebox']/div/label/input[contains(@placeholder, 'MM/DD/YYYY')]")));
            IWebElement firstUSTReportDateboxCalendar = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//my-datebox[@id='firstUSTReportDatebox']/div/label/i")));
            IWebElement abandonedStatusLabel = wait.Until(ExpectedConditions.ElementIsVisible(By.Id("abandonedStatus-Label")));
            IWebElement abandStatusNoChkBox = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//div/input[@id='abandonedStatus-No']/..")));
            IWebElement abandStatusYesChkBox = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//div/input[@id='abandonedStatus-Yes']/..")));
            IWebElement abandStatusUnknownChkBox = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//div/input[@id='abandonedStatus-Unknown']/..")));
            IWebElement abandStatusNoChkLbl = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//div[@id='radio-buton-text-abandonedStatus']/span[contains(text(),'No')]")));
            IWebElement abandStatusYesChkLbl = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//div[@id='radio-buton-text-abandonedStatus']/span[contains(text(),'Yes')]")));
            IWebElement abandStatusUnknownChkLbl = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//div[@id='radio-buton-text-abandonedStatus']/span[contains(text(),'Unknown')]")));
            IWebElement ownershipStatusLabel = wait.Until(ExpectedConditions.ElementIsVisible(By.Id("ownershipStatus-Label")));
            IWebElement ownerStatusUnkChkBox = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//div/input[@id='ownershipStatus-0']/..")));
            IWebElement ownerStatusUnkChkLbl = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//div[@id='radio-buton-text-ownershipStatus']/span[contains(text(),'Unknown')]")));
            IWebElement ownerStatusHusbChkBox = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//div/input[@id='ownershipStatus-1']/..")));
            IWebElement ownerStatusHusbChkLbl = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//div[@id='radio-buton-text-ownershipStatus']/span[contains(text(),'Husband')]")));
            IWebElement ownerStatusWifeChkBox = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//div/input[@id='ownershipStatus-2']/..")));
            IWebElement ownerStatusWifeChkLbl = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//div[@id='radio-buton-text-ownershipStatus']/span[contains(text(),'Wife')]")));
            IWebElement ownerStatusJointChkBox = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//div/input[@id='ownershipStatus-3']/..")));
            IWebElement ownerStatusJointChkLbl = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//div[@id='radio-buton-text-ownershipStatus']/span[contains(text(),'Joint')]")));
            IWebElement ownerStatusCommChkBox = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//div/input[@id='ownershipStatus-4']/..")));
            IWebElement ownerStatusCommChkLbl = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//div[@id='radio-buton-text-ownershipStatus']/span[contains(text(),'Community')]")));
            IWebElement ownerStatusNAChkBox = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//div/input[@id='ownershipStatus-5']/..")));
            IWebElement ownerStatusNAChkLbl = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//div[@id='radio-buton-text-ownershipStatus']/span[contains(text(),'N/A')]")));
            IWebElement reservedStatusExpandableTitle = wait.Until(ExpectedConditions.ElementIsVisible(By.Id("reservedStatus-expandableTitle")));
            IWebElement reservedNote = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//span[@class='reservedNote']")));
            IWebElement reservedStatusLabel = wait.Until(ExpectedConditions.ElementIsVisible(By.Id("reservedStatus-Label")));
            IWebElement reservedStatusNoChkBox = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//input[@id='reservedStatus-No']/..")));
            IWebElement reservedStatusNoChkLbl = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//div[@id='radio-buton-text-reservedStatus']/span[contains(text(),'No')]")));
            IWebElement reservedStatusYesChkBox = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//input[@id='reservedStatus-Yes']/..")));
            IWebElement reservedStatusYesChkLbl = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//div[@id='radio-buton-text-reservedStatus']/span[contains(text(),'Yes')]")));
            IWebElement reservedStatusNote = wait.Until(ExpectedConditions.ElementIsVisible(By.Id("reservedStatusNote")));
            IWebElement charCounter2 = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//div/remaining-characters/textarea[@id='reservedStatusNote']/../label[@class='remainingCharacters']")));

            Assert.True(formOneNoteExpandableTitle.Text.Contains("Form 1 Note"));
            Assert.True(formOneNoteTitle.Text.Contains("FORM 1 NOTE"));
            Assert.True(charCounter1.Text.Contains("Remaining Characters: 32000"));
            Assert.True(optionsAndDatesSectionExpandableTitle.Text.Contains("Options and Dates"));
            Assert.True(fullyAdministeredDatebox.Text.Contains("FULLY ADMINISTERED DATE"));
            Assert.True(firstUSTReportDatebox.Text.Contains("1ST UST REPORT DATE"));
            Assert.True(abandonedStatusLabel.Text.Contains("ABANDONED"));
            Assert.True(abandStatusNoChkLbl.Text.Contains("No"));
            Assert.True(abandStatusYesChkLbl.Text.Contains("Yes (OA)"));
            Assert.True(abandStatusUnknownChkLbl.Text.Contains("Unknown"));
            Assert.True(ownershipStatusLabel.Text.Contains("OWNERSHIP"));
            Assert.True(ownerStatusUnkChkLbl.Text.Contains("Unknown"));
            Assert.True(ownerStatusHusbChkLbl.Text.Contains("Husband"));
            Assert.True(ownerStatusWifeChkLbl.Text.Contains("Wife"));
            Assert.True(ownerStatusJointChkLbl.Text.Contains("Joint"));
            Assert.True(ownerStatusCommChkLbl.Text.Contains("Community"));
            Assert.True(ownerStatusNAChkLbl.Text.Contains("N/A"));
            Assert.True(reservedStatusExpandableTitle.Text.Contains("Reserved Status"));
            Assert.That(reservedNote.Text.Contains("\"Note: Marking an asset as reserved, allows a trustee to submit a final report. When selected, additional language will be added to the TFR asserting the Trustee's right to administer this asset at a later date, even if the case has been closed.\""));
            Assert.True(reservedStatusLabel.Text.Contains("RESERVED"));
            Assert.True(reservedStatusNoChkLbl.Text.Contains("No"));
            Assert.True(reservedStatusYesChkLbl.Text.Contains("Yes"));
            Assert.True(charCounter2.Text.Contains("Remaining Characters: 1024"));
        }

        [Given(@"Click New Asset button on Summary section")]
        [When(@"Click New Asset button on Summary section")]
        [Then(@"Click New Asset button on Summary section")]
        public void GivenClickNewAssetButtonOnSummarySection()
        {

            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(100));
            WaitForBlockOverlayToDissapear();
            Thread.Sleep(1000);
            IWebElement newAssetButton = wait.Until(ExpectedConditions.ElementToBeClickable(By.Id("btn-newAssetSummary")));
            newAssetButton.Click();
            WaitForBlockOverlayToDissapear();
        }

        [Given(@"Search and select Code by text (.*)")]
        [When(@"Search and select Code by text (.*)")]
        [Then(@"Search and select Code by text (.*)")]
        public void AssetSearchAndSelectCodeByText(string text)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(50));
            WaitForBlockOverlayToDissapear();
            Thread.Sleep(1000);
            if (text != "")
            {
                IWebElement searchBar = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//span[@id='select2-assetCodeTextBox-container']/../span[2]")));
                searchBar.Click();
                Thread.Sleep(500);
                IWebElement typeBar = wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//span/input[@class='select2-search__field']")));
                char[] description = text.ToCharArray();

                foreach (char a in description)
                {
                    typeBar.SendKeys(a.ToString());
                    Thread.Sleep(50);
                }

                Thread.Sleep(1000);

                ReadOnlyCollection<IWebElement> results = wait.Until(ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.XPath("//ul[@id='select2-assetCodeTextBox-results']/li")));
                foreach (var result in results)
                {
                    if (result.Text.Contains(text))
                    {
                        result.Click();
                        break;
                    }
                }
            }
            else
            {
                TestsLogger.Log("No Code was selected on purpose.");
            }
            WaitForBlockOverlayToDissapear();
        }

        [Given(@"Select Code by text '(.*)' using '(.*)'")]
        [When(@"Select Code by text '(.*)' using '(.*)'")]
        [Then(@"Select Code by text '(.*)' using '(.*)'")]
        public void SelectCodeWithTextUsingX(string text, string selectMethod)
        {
            Thread.Sleep(1500);
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
            Actions builder = new Actions(driver);
            WaitForBlockOverlayToDissapear();
            IWebElement searchBar = createVisibleWebElementByXpath("//span[@id='select2-assetCodeTextBox-container']/..//span[@class='select2-selection__arrow']");
            searchBar.Click();
            IWebElement typeBar = wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//span/input[@class='select2-search__field']")));
            typeStringByChar(text, typeBar);
            Thread.Sleep(2000);
            ReadOnlyCollection<IWebElement> results = createVisibleElementsCollectionByXpath("//ul[@id='select2-assetCodeTextBox-results']/li/div");
            Thread.Sleep(1000);
            selectResultInDifferentWaysInSelect2(results, text, selectMethod, typeBar);
            Thread.Sleep(1000);
            IWebElement placeholder = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//span[@id[contains(.,'select2-assetCodeTextBox-container')]]")));
            Assert.True(placeholder.Text.Contains(text));
            WaitForBlockOverlayToDissapear();
        }

        [Given(@"Select Sub Code by text '(.*)' using '(.*)'")]
        [When(@"Select Sub Code by text '(.*)' using '(.*)'")]
        [Then(@"Select Sub Code by text '(.*)' using '(.*)'")]
        public void SelectSubCodeWithTextUsingX(string text, string selectMethod)
        {
            Thread.Sleep(2500);
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(25));
            Actions builder = new Actions(driver);
            WaitForBlockOverlayToDissapear();

            if (TestContext.CurrentContext.Test.Name.ToString().Contains("NewAsset") && selectMethod == "Tab")
            {
                if (wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//span/input[@class='select2-search__field']"))).Displayed)
                {
                    createVisibleWebElementByXpath("//span/input[@class='select2-search__field']").SendKeys(Keys.Escape);
                }
            }
            else
            {
                TestsLogger.Log("No Need to Escape typeBar field. Test will continue");
            }
            IWebElement searchBar = createExistentWebElementByXpath("//span[@id[contains(.,'select2-subcodeDesktop-container')]]/..//span[@class='select2-selection__arrow']");
            searchBar.Click();
            IWebElement typeBar = wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//span/input[@class='select2-search__field']")));
            typeStringByChar(text, typeBar);
            Thread.Sleep(1000);

            ReadOnlyCollection<IWebElement> results = createPresentElementsCollectionByXpath("//ul[@id[contains(.,'select2-subcodeDesktop-results')]]/li/div[@id[not(contains(.,'-1'))]]");
            Thread.Sleep(500);
            selectResultInDifferentWaysInSelect2(results, text, selectMethod, typeBar);
            IWebElement placeholder = createVisibleWebElementByXpath("//span[@id[contains(.,'select2-subcodeDesktop-container')]]");
            Assert.True(placeholder.Text.Contains(text));
            WaitForBlockOverlayToDissapear();
        }

        [Given(@"Search and select SubCode by text (.*)")]
        [When(@"Search and select SubCode by text (.*)")]
        [Then(@"Search and select SubCode by text (.*)")]
        public void AssetSearchAndSelectSubCodeByText(string text)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));

            WaitForBlockOverlayToDissapear();
            Thread.Sleep(1000);
            if (text != "")
            {
                IWebElement searchBar = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//span[@id='select2-subcodeDesktop-container']/../span[2]")));
                searchBar.Click();
                Thread.Sleep(500);
                IWebElement typeBar = wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//span/input[@class='select2-search__field']")));

                char[] description = text.ToCharArray();

                foreach (char a in description)
                {
                    typeBar.SendKeys(a.ToString());
                    Thread.Sleep(50);
                }

                Thread.Sleep(1000);

                ReadOnlyCollection<IWebElement> results = wait.Until(ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.XPath("//ul[@id='select2-subcodeDesktop-results']/li")));
                foreach (var result in results)
                {
                    if (result.Text.Contains(text))
                    {
                        result.Click();
                        break;
                    }
                }
            }
            else
            {
                TestsLogger.Log("No Sub Code was selected on purpose.");
            }
            WaitForBlockOverlayToDissapear();
        }

        [Given(@"Search and select Description by text (.*)")]
        [When(@"Search and select Description by text (.*)")]
        [Then(@"Search and select Description by text (.*)")]
        public void GivenSearchAndSelectDescriptionByText(string text)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(50));
            AddDataToScenarioContextOverridingExistentKey("searchedDescription", text);

            WaitForBlockOverlayToDissapear();
            Thread.Sleep(1000);
            IWebElement typeBar = wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//span/input[@class='select2-search__field']")));
            char[] description = text.ToCharArray();

            foreach (char a in description)
            {
                typeBar.SendKeys(a.ToString());
                Thread.Sleep(50);
            }

            Thread.Sleep(1500);

            ReadOnlyCollection<IWebElement> results = wait.Until(ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.XPath("//ul[@id='select2-assetDescriptionValue-results']/li")));
            foreach (var result in results)
            {
                if (result.Text.Contains(text))
                {
                    result.Click();
                    break;
                }
            }

            WaitForBlockOverlayToDissapear();
        }

        [Given(@"I Lose focus from field")]
        [When(@"I Lose focus from field")]
        [Then(@"I Lose focus from field")]
        public void loseFocusFromField()
        {
            WaitForBlockOverlayToDissapear();
            driver.FindElement(By.XPath("//html/body")).Click();
            WaitForBlockOverlayToDissapear();
        }

        [Given(@"Click on Description field")]
        [When(@"Click on Description field")]
        [Then(@"Click on Description field")]
        public void clickDescriptionField()
        {
            WaitForBlockOverlayToDissapear();
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(50));
            Thread.Sleep(500);
            IWebElement descriptionField = createVisibleWebElementByXpath("//span[@id='select2-assetDescriptionValue-container']/..//span[@class='select2-selection__arrow']");
            Thread.Sleep(1000);
            descriptionField.Click();
            Thread.Sleep(1000);
            WaitForBlockOverlayToDissapear();
        }

        [Given(@"Click Save New Asset button")]
        [When(@"Click Save New Asset button")]
        [Then(@"Click Save New Asset button")]
        public void GivenClickSaveNewAssetButton()
        {
            WaitForBlockOverlayToDissapear();
            Thread.Sleep(500);
            clickNotVisualizedElement(driver.FindElement(By.XPath("//div/button[@id='saveNewAsset']")));
            Thread.Sleep(2500);
            WaitForBlockOverlayToDissapear();
        }

        [Given(@"Click Read More button on Card number (.*)")]
        [When(@"Click Read More button on Card number (.*)")]
        [Then(@"Click Read More button on Card number (.*)")]
        public void clickReadMoreButton(string text)
        {
            WaitForBlockOverlayToDissapear();
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(50));
            scrollToElement(wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//li[@class='assetListItem']/article/header/div/p[contains(text(),'" + text + "')]"))));
            clickNotVisualizedElement(driver.FindElement(By.XPath("//li[@class='assetListItem']/article/header/div/p[contains(text(),'" + text + "')]/../../../../article//div[@class='noteActions']/i")));
            IWebElement readMoreLbl = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//li[@class='assetListItem']/article/header/div/p[contains(text(),'" + text + "')]/../../../../article//div[@class='noteActions']/i/span")));
            Assert.True(readMoreLbl.Text.Contains("READ MORE") || readMoreLbl.Text.Contains("READ LESS"));
            Thread.Sleep(500);
            WaitForBlockOverlayToDissapear();
        }

        [Given(@"Click Save and Add Another New Asset button")]
        [When(@"Click Save and Add Another New Asset button")]
        [Then(@"Click Save and Add Another New Asset button")]
        public void ClickSaveAndAddNewAssetButton()
        {

            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(50));
            WaitForBlockOverlayToDissapear();
            IWebElement saveButton = wait.Until(ExpectedConditions.ElementIsVisible(By.Id("saveAndAddAnotherAsset")));
            clickNotVisualizedElement(saveButton);
            WaitForBlockOverlayToDissapear();
            IWebElement typeBar = wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//span/input[@class='select2-search__field']")));
            Assert.True(typeBar.Equals(driver.SwitchTo().ActiveElement()));
            WaitForBlockOverlayToDissapear();
        }

        [Given(@"Click radio button with Trustee Status Value (.*)")]
        [When(@"Click radio button with Trustee Status Value (.*)")]
        [Then(@"Click radio button with Trustee Status Value (.*)")]
        public void clickTrusteeStatusValueRbtn(string text)
        {

            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(50));
            WaitForBlockOverlayToDissapear();
            IWebElement statusValueRbtn = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//my-radiobutton/div/div/div[1]/input[@id='valueStatus-" + text + "']/../../div[1]")));
            statusValueRbtn.Click();
            Assert.True(statusValueRbtn.GetAttribute("class").ToString().Contains("checked"));
            WaitForBlockOverlayToDissapear();
        }

        [Given(@"Click radio button with Petition Status Value (.*)")]
        [When(@"Click radio button with Petition Status Value (.*)")]
        [Then(@"Click radio button with Petition Status Value (.*)")]
        public void clickPetitionStatusValueRbtn(string text)
        {

            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(50));
            WaitForBlockOverlayToDissapear();
            Thread.Sleep(1000);
            IWebElement statusValueRbtn = createExistentWebElementByXpath("//my-radiobutton/div/div/div[1]/input[@id='petitionValueStatus-" + text + "']");
            statusValueRbtn.Click();
            IWebElement checkedStatusValueRbtn = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//my-radiobutton/div/div/div[1]/input[@id='petitionValueStatus-" + text + "']/../../div[@class[contains(.,'radio-button-container')]]")));
            Assert.True(checkedStatusValueRbtn.GetAttribute("class").ToString().Contains("checked"));
            WaitForBlockOverlayToDissapear();
        }

        [Given(@"Click radio button with Abandoned Value (.*)")]
        [When(@"Click radio button with Abandoned Value (.*)")]
        [Then(@"Click radio button with Abandoned Value (.*)")]
        public void clickAbandonedValueRbtn(string text)
        {

            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
            Actions builder = new Actions(driver);
            WaitForBlockOverlayToDissapear();
            IWebElement areaToScroll = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//span[@id='formOneNoteTitle']")));
            scrollToElement(areaToScroll);
            IWebElement abandonedValueRbtn = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//div/input[@id='abandonedStatus-" + text + "']/..")));
            abandonedValueRbtn.Click();
            clickNotVisualizedElement(abandonedValueRbtn);
            Assert.True(abandonedValueRbtn.GetAttribute("class").ToString().Contains("checked"));
            WaitForBlockOverlayToDissapear();
        }

        [Given(@"Click radio button with Ownership Value (.*)")]
        [When(@"Click radio button with Ownership Value (.*)")]
        [Then(@"Click radio button with Ownership Value (.*)")]
        public void clickOwnershipValueRbtn(string text)
        {

            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(50));
            Actions builder = new Actions(driver);
            WaitForBlockOverlayToDissapear();
            string rbtnNumber = null;
            if (text == "Unknown")
            { rbtnNumber = "0"; }
            else if (text == "Husband")
            { rbtnNumber = "1"; }
            else if (text == "Wife")
            { rbtnNumber = "2"; }
            else if (text == "Joint")
            { rbtnNumber = "3"; }
            else if (text == "Community")
            { rbtnNumber = "4"; }
            else { rbtnNumber = "5"; }
            IWebElement ownershipLabel = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//*[@id='ownershipStatus-Label']")));
            IWebElement ownershipValueRbtn = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//div/input[@id='ownershipStatus-" + rbtnNumber + "']/..")));
            scrollToElement(ownershipLabel);            
            ownershipValueRbtn.Click();
            clickNotVisualizedElement(ownershipValueRbtn);
            string RbtnClass = ownershipValueRbtn.GetAttribute("class").ToString();
            Assert.True(RbtnClass.Contains("checked"));
        }

        [Given(@"Verify tile (.*) exist in Summary section")]
        [When(@"Verify tile (.*) exist in Summary section")]
        [Then(@"Verify tile (.*) exist in Summary section")]
        public void ThenVerifyExistInSummarySection(string text)
        {

            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(50));
            WaitForBlockOverlayToDissapear();
            IWebElement scrollToMe = createExistentWebElementByXpath("//a[@id='navItem-Assets']");
            scrollToElement(scrollToMe);
            IWebElement miniCard = wait.Until(ExpectedConditions.ElementExists(By.XPath("//header/h1[contains(text(),'" + text + "')]")));
            Assert.True(miniCard.Displayed);
        }

        [Given(@"Verify error message for invalid 2nd UST Report Date")]
        [When(@"Verify error message for invalid 2nd UST Report Date")]
        [Then(@"Verify error message for invalid 2nd UST Report Date")]
        public void errorMessageWrong2ndDate()
        {

            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(50));
            WaitForBlockOverlayToDissapear();
            IWebElement errorMessage = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//div/small[@id='errorMessage']")));
            Assert.That(errorMessage.Text.Contains("Date must be after the 1ST UST REPORT Date") || errorMessage.Text.Contains("Required entry format: MM/DD/YYYY"));
        }

        [Given(@"Verify error message for Not Matching Predictive results")]
        [When(@"Verify error message for Not Matching Predictive results")]
        [Then(@"Verify error message for Not Matching Predictive results")]
        public void errorMessagePredictiveResults()
        {

            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(50));
            WaitForBlockOverlayToDissapear();
            IWebElement errorMessage = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//ul/li[@class='select2-results__option select2-results__message']")));
            Assert.That(errorMessage.Text.Contains("No Results Available Matching Search Criteria"));
        }

        [Given(@"Verify Status Value (.*) is correct for saved Asset")]
        [When(@"Verify Status Value (.*) is correct for saved Asset")]
        [Then(@"Verify Status Value (.*) is correct for saved Asset")]
        public void VerifyStatusValueIsCorrectForSavedAsset(string text)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(50));
            Thread.Sleep(500);

            WaitForBlockOverlayToDissapear();
            IWebElement statusValueOnList = null;
            if (text == "Known" || text == "Unknown")
            {
                statusValueOnList = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//div[@class='addAssetBreakLine']/span[3]")));
                Assert.True(statusValueOnList.Text == text);
            }
            else
            {
                ignoreNoSuchElementException();
                wait.Until(ExpectedConditions.InvisibilityOfElementLocated(By.XPath("//div[@class='addAssetBreakLine'][0]/span[3]")));
            }
        }

        [Given(@"Verify Abandoned Value (.*) is correct for saved Asset")]
        [When(@"Verify Abandoned Value (.*) is correct for saved Asset")]
        [Then(@"Verify Abandoned Value (.*) is correct for saved Asset")]
        public void VerifyAbandonedValueIsCorrectForSavedAsset(string text)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(50));
            Thread.Sleep(500);

            WaitForBlockOverlayToDissapear();
            IWebElement abandonedValueOnList = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//li[1]/article/div/div[3]/div[3]/p[3]")));
            Assert.AreEqual((abandonedValueOnList.Text), (text));
        }

        [Given(@"Verify Fully Administered Date Value (.*) is correct for saved Asset")]
        [When(@"Verify Fully Administered Date Value (.*) is correct for saved Asset")]
        [Then(@"Verify Fully Administered Date Value (.*) is correct for saved Asset")]
        public void VerifyFADateValueIsCorrectForSavedAsset(string text)
        {
            WaitForBlockOverlayToDissapear();
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(50));
            Thread.Sleep(500);
            IWebElement FADValueOnList = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//li[1]/article/header//div/p/span[@class='assetStatusGreen au-target']")));
            Assert.True(FADValueOnList.Text.Contains(text));
        }

        [Given(@"Enter Fully Administered Date (.*)")]
        [When(@"Enter Fully Administered Date (.*)")]
        [Then(@"Enter Fully Administered Date (.*)")]
        public void enterFAD(string text)
        {
            WaitForBlockOverlayToDissapear();            
            IWebElement optionsTitle = createExistentWebElementById("optionsAndDatesSection-expandableTitle");
            IWebElement inputField = createVisibleWebElementByXpath("//input[@id='fullyAdministeredDatebox']");
            scrollToElement(optionsTitle);
            inputField.Click();
            typeStringByChar(text, inputField);
            ignoreNoSuchElementException();
            IWebElement clickMe = createExistentWebElementById("abandonedStatus-Label");
            clickMe.Click();
        }

        [Given(@"Enter Form 1 Note text (.*)")]
        [When(@"Enter Form 1 Note text (.*)")]
        [Then(@"Enter Form 1 Note text (.*)")]
        public void enterFormOneNoteText(string text)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(25));
            WaitForBlockOverlayToDissapear();
            Actions builder = new Actions(driver);
            IWebElement areaToScroll = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//div[@class='formOnePreviewTitle']/strong")));
            scrollToElement(areaToScroll);
            IWebElement inputField = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//textarea[@id='formOneNoteTextArea']")));
            inputField.Click();
            inputField.SendKeys(Keys.Control + "a");
            if (text == "32000")
            {
                for (int i = 1; i <= 16; i++)
                {
                    typeLongStringsByChar(Properties.Resources._32000Characters, inputField);
                }
            }
            else if (text == "32001")
            {
                for (int i = 1; i <= 16; i++)
                {
                    typeLongStringsByChar(Properties.Resources._32000Characters, inputField);
                }
                inputField.SendKeys("W");
            }
            else if (text == "482")
            {
                typeLongStringsByChar(Properties.Resources._482Characters, inputField);
            }
            else if (text == "483")
            {
                typeLongStringsByChar(Properties.Resources._483Characters, inputField);
            }
            else if (text == "600")
            {
                typeLongStringsByChar(Properties.Resources._600Characters, inputField);
            }
            else
            {
                typeLongStringsByChar(text, inputField);
            }
        }

        [Given(@"I count Form 1 Note entered characters")]
        [When(@"I count Form 1 Note entered characters")]
        [Then(@"I count Form 1 Note entered characters")]
        public void countCharactersFormOneNote()
        {
            WaitForBlockOverlayToDissapear();
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(50));
            IWebElement inputField = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//textarea[@id='formOneNoteTextArea']")));
            string enteredText = inputField.GetAttribute("value").ToString();
            int textLenght = enteredText.Length;
            AddDataToScenarioContextOverridingExistentKey("formOneNoteOnlyString", enteredText);
            AddDataToScenarioContextOverridingExistentKey("formOneNoteText", textLenght);
        }

        [Given(@"Verify Form 1 Note has only 32000 characters")]
        [When(@"Verify Form 1 Note has only 32000 characters")]
        [Then(@"Verify Form 1 Note has only 32000 characters")]
        public void CharactersFormOneNoteLimit()
        {
            WaitForBlockOverlayToDissapear();
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(50));
            IWebElement inputField = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//textarea[@id='formOneNoteTextArea']")));
            string enteredText = inputField.GetAttribute("value").ToString();
            int textLenght = enteredText.Length;
            Assert.True(textLenght == 32000);
        }


        [Given(@"Verify Form 1 Note character counter is correct")]
        [When(@"Verify Form 1 Note character counter is correct")]
        [Then(@"Verify Form 1 Note character counter is correct")]
        public void verifyCharacterCounterFormOneNote()
        {
            WaitForBlockOverlayToDissapear();
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(50));
            Thread.Sleep(500);
            int enteredCharacters = ScenarioContext.Current.Get<int>("formOneNoteText");
            IWebElement charCounter1 = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//div[@id='textContainer']//label[@class='remainingCharacters']")));
            Assert.True(charCounter1.Text.Contains("Remaining Characters: " + (32000 - enteredCharacters) + ""));
        }

        [Given(@"Verify Form 1 Note text remains")]
        [When(@"Verify Form 1 Note text remains")]
        [Then(@"Verify Form 1 Note text remains")]
        public void verifyFormOneNoteTextRemains()
        {
            WaitForBlockOverlayToDissapear();
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(50));
            Thread.Sleep(500);
            IWebElement inputField = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//textarea[@id='formOneNoteTextArea']")));
            string typedText = ScenarioContext.Current.Get<string>("formOneNoteOnlyString");
            string remainingText = inputField.GetAttribute("value").ToString();
            Assert.True(remainingText == typedText);
        }

        [Given(@"Verify Form 1 Note on listed Assets is complete")]
        [When(@"Verify Form 1 Note on listed Assets is complete")]
        [Then(@"Verify Form 1 Note on listed Assets is complete")]
        public void checkFOrmOneNoteTextIsComplete()
        {
            WaitForBlockOverlayToDissapear();
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(50));
            Thread.Sleep(2500);
            IWebElement formNotePreview = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//li[1]/article//div[@class='noteContent']/p")));
            string typedText = ScenarioContext.Current.Get<string>("formOneNoteOnlyString");
            string remainingText = formNotePreview.Text;
            Assert.True(remainingText == typedText);
            WaitForBlockOverlayToDissapear();
        }

        [Given(@"Verify Form 1 Note on listed Assets has 3 dots at the end")]
        [When(@"Verify Form 1 Note on listed Assets has 3 dots at the end")]
        [Then(@"Verify Form 1 Note on listed Assets has 3 dots at the end")]
        public void checkFormOneNoteTextHas3Dots()
        {
            WaitForBlockOverlayToDissapear();
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(50));
            Thread.Sleep(1000);
            IWebElement formNotePreview = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//li[1]/article//div[@class='noteContent']/p")));
            Assert.True(formNotePreview.Text.Contains("..."));
            WaitForBlockOverlayToDissapear();
        }

        [Given(@"Enter Reserved Status text (.*)")]
        [When(@"Enter Reserved Status text (.*)")]
        [Then(@"Enter Reserved Status text (.*)")]
        public void enterReservedStatusText(string text)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(25));
            WaitForBlockOverlayToDissapear();
            Actions builder = new Actions(driver);
            IWebElement areaToScroll = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//div[@id='reservedStatus-expandableSection']")));
            scrollToElement(areaToScroll);
            IWebElement inputField = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//textarea[@id='reservedStatusNote']")));
            inputField.Click();
            inputField.SendKeys(Keys.Control + "a");
            if (text == "1024")
            {
                inputField.SendKeys(Properties.Resources._1024Characters);
            }
            else if (text == "1025")
            {
                inputField.SendKeys(Properties.Resources._1024Characters);
                inputField.SendKeys("W");
            }
            else
            {
                char[] x = text.ToCharArray();
                foreach (char a in x)
                { inputField.SendKeys(a.ToString()); }
            }
        }

        [Given(@"I count Reserved Status entered characters")]
        [When(@"I count Reserved Status entered characters")]
        [Then(@"I count Reserved Status entered characters")]
        public void countCharactersReservedStatus()
        {
            WaitForBlockOverlayToDissapear();
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(50));
            IWebElement inputField = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//textarea[@id='reservedStatusNote']")));
            string enteredText = inputField.GetAttribute("value").ToString();
            int textLenght = enteredText.Length;
            AddDataToScenarioContextOverridingExistentKey("reservedStatusNoteOnlyString", enteredText);
            AddDataToScenarioContextOverridingExistentKey("reservedStatusNoteTextLenght", textLenght);
        }

        [Given(@"Verify Reserved Status has only 1024 characters")]
        [When(@"Verify Reserved Status has only 1024 characters")]
        [Then(@"Verify Reserved Status has only 1024 characters")]
        public void CharactersReservedStatusLimit()
        {
            WaitForBlockOverlayToDissapear();
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(50));
            IWebElement inputField = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//textarea[@id='reservedStatusNote']")));
            string enteredText = inputField.GetAttribute("value").ToString();
            int textLenght = enteredText.Length;
            Assert.True(textLenght == 1024);
        }


        [Given(@"Verify Reserved Status character counter is correct")]
        [When(@"Verify Reserved Status character counter is correct")]
        [Then(@"Verify Reserved Status character counter is correct")]
        public void verifyCharacterCounterReservedStatus()
        {
            WaitForBlockOverlayToDissapear();
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(50));
            Thread.Sleep(500);
            int enteredCharacters = ScenarioContext.Current.Get<int>("reservedStatusNoteTextLenght");
            IWebElement charCounter1 = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//remaining-characters/textarea[@id='reservedStatusNote']/../label[@class='remainingCharacters']")));
            Assert.True(charCounter1.Text.Contains("Remaining Characters: " + (1024 - enteredCharacters) + ""));
        }

        [Given(@"Verify Reserved Status text remains")]
        [When(@"Verify Reserved Status text remains")]
        [Then(@"Verify Reserved Status text remains")]
        public void verifyReservedStatusTextRemains()
        {
            WaitForBlockOverlayToDissapear();
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(50));
            Thread.Sleep(500);
            IWebElement inputField = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//textarea[@id='reservedStatusNote']")));
            string typedText = ScenarioContext.Current.Get<string>("reservedStatusNoteOnlyString");
            string remainingText = inputField.GetAttribute("value").ToString();
            Assert.True(remainingText == typedText);
        }

        [Given(@"Enter 1st UST Report Date (.*)")]
        [When(@"Enter 1st UST Report Date (.*)")]
        [Then(@"Enter 1st UST Report Date (.*)")]
        public void enter1USTRD(string text)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(50));
            WaitForBlockOverlayToDissapear();
            Actions builder = new Actions(driver);
            IWebElement inputField = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//input[@id='firstUSTReportDatebox']")));
            IWebElement areaToScroll = createExistentWebElementByXpath("//span[@id='formOneNote-expandableTitle']");
            scrollToElement(areaToScroll);
            inputField.Click();
            inputField.SendKeys(Keys.Control + "a");
            char[] x = text.ToCharArray();
            foreach (char a in x)
            { inputField.SendKeys(a.ToString()); }
            ignoreNoSuchElementException();
            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//label[@id='abandonedStatus-Label']"))).Click();
            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//input[@id='secondUSTReportDatebox']")));
        }

        [Given(@"Enter 2nd UST Report Date (.*)")]
        [When(@"Enter 2nd UST Report Date (.*)")]
        [Then(@"Enter 2nd UST Report Date (.*)")]
        public void enter2USTRD(string text)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(50));
            WaitForBlockOverlayToDissapear();
            Actions builder = new Actions(driver);
            IWebElement inputField = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//input[@id='secondUSTReportDatebox']")));
            IWebElement areaToScroll = createExistentWebElementByXpath("//span[@id='formOneNote-expandableTitle']");
            scrollToElement(areaToScroll);
            inputField.Click();
            inputField.SendKeys(Keys.Control + "a");
            char[] x = text.ToCharArray();
            foreach (char a in x)
            { inputField.SendKeys(a.ToString()); }
            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//label[@id='abandonedStatus-Label']"))).Click();
        }

        [Given(@"Type (.*) Value (.*) for New Asset")]
        [When(@"Type (.*) Value (.*) for New Asset")]
        [Then(@"Type (.*) Value (.*) for New Asset")]
        public void typeCalculationsValue(string input, string value)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(50));
            WaitForBlockOverlayToDissapear();
            Actions builder = new Actions(driver);
            ScrollPageUpOrDown("-5000");
            ScrollPageUpOrDown("600");
            createVisibleWebElementByXpath("//input[@id='assetLiens']").SendKeys(Keys.Control+"a");
            createVisibleWebElementByXpath("//input[@id='assetLiens']").SendKeys(Keys.Backspace);
            createVisibleWebElementByXpath("//input[@id='assetEstimatedCostValue']").SendKeys(Keys.Control+"a");
            createVisibleWebElementByXpath("//input[@id='assetEstimatedCostValue']").SendKeys(Keys.Backspace);
            createVisibleWebElementByXpath("//input[@id='assetExemption']").SendKeys(Keys.Control+"a");
            createVisibleWebElementByXpath("//input[@id='assetExemption']").SendKeys(Keys.Backspace);
            createVisibleWebElementByXpath("//input[@id='assetTrustee']").SendKeys(Keys.Control+"a");
            createVisibleWebElementByXpath("//input[@id='assetTrustee']").SendKeys(Keys.Backspace);
            createVisibleWebElementByXpath("//input[@id='assetPetition']").SendKeys(Keys.Control+"a");
            createVisibleWebElementByXpath("//input[@id='assetPetition']").SendKeys(Keys.Backspace);
            Thread.Sleep(50);

            IWebElement inputField = wait.Until(ExpectedConditions.ElementExists(By.XPath("//input[@id='asset" + input + "']")));
            inputField.Click();
            typeStringByChar(value, inputField);
            inputField.SendKeys(Keys.Tab);
            AddDataToScenarioContextOverridingExistentKey("moneyValue", value);
        }

        [Given(@"Verify (.*) input field Value for New Asset updates proper fields and labels")]
        [When(@"Verify (.*) input field Value for New Asset updates proper fields and labels")]
        [Then(@"Verify (.*) input field Value for New Asset updates proper fields and labels")]
        public void verifyCalculationsValuesOnNewAsset(string input)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(50));
            WaitForBlockOverlayToDissapear();
            Actions builder = new Actions(driver);
            string inputField = driver.FindElement(By.XPath("//input[@id='asset" + input + "']")).GetAttribute("value").ToString();
            string moneyValue = ScenarioContext.Current.Get<string>("moneyValue");
            IWebElement trusteeValInput = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//input[@id='assetTrustee']")));
            IWebElement totalRedLbl = wait.Until(ExpectedConditions.ElementIsVisible(By.Id("assetTotalReductionsLabel")));
            IWebElement netValRedNumLbl = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//div[@id='assetNetValueReductions']/span")));
            IWebElement initEstValNumLbl = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//div[@id='assetInitialEstateValue']/span")));
            IWebElement currentEstSaleNumLbl = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//div[@id='assetCurrentEstateValue']/span")));
            IWebElement assetPetitionValue = wait.Until(ExpectedConditions.ElementIsVisible(By.Id("assetPetitionValue")));
            IWebElement assetNetValue = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//p[@id='assetNetValue']")));
            IWebElement assetAbandonedValue = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//p[@id='assetAbandonedValue']")));
            IWebElement assetSalesValue = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//p[@id='assetSalesValue']")));
            IWebElement assetRemainingValue = wait.Until(ExpectedConditions.ElementIsVisible(By.Id("assetRemainingValue")));

            if (input == "Petition")
            {
                Assert.True(trusteeValInput.GetAttribute("value").ToString() == inputField);
                Assert.True(netValRedNumLbl.Text == "$0.00");
                Assert.True(initEstValNumLbl.Text == "$" + moneyValue);
                Assert.True(currentEstSaleNumLbl.Text == "$" + moneyValue);
                Assert.True(assetPetitionValue.Text == "$" + moneyValue);
                Assert.True(assetNetValue.Text == "$" + moneyValue);
                Assert.True(assetAbandonedValue.Text == "No");
                Assert.True(assetSalesValue.Text == "$0.00");
                Assert.True(assetRemainingValue.Text == "$" + moneyValue);
                Assert.True(totalRedLbl.Text == "Total Reductions: $ 0.00");
            }
            else if (input == "Trustee")
            {
                Assert.True(netValRedNumLbl.Text == "$0.00");
                Assert.True(initEstValNumLbl.Text == "$" + moneyValue);
                Assert.True(currentEstSaleNumLbl.Text == "$" + moneyValue);
                Assert.True(assetPetitionValue.Text == "$0.00");
                Assert.True(assetNetValue.Text == "$" + moneyValue);
                Assert.True(assetAbandonedValue.Text == "No");
                Assert.True(assetSalesValue.Text == "$0.00");
                Assert.True(assetRemainingValue.Text == "$" + moneyValue);
                Assert.True(totalRedLbl.Text == "Total Reductions: $ 0.00");
            }
            else
            {
                Assert.True(netValRedNumLbl.Text == "$" + moneyValue);
                Assert.True(initEstValNumLbl.Text == "$0.00");
                Assert.True(currentEstSaleNumLbl.Text == "$0.00");
                Assert.True(assetPetitionValue.Text == "$0.00");
                Assert.True(assetNetValue.Text == "$0.00");
                Assert.True(assetAbandonedValue.Text == "No");
                Assert.True(assetSalesValue.Text == "$0.00");
                Assert.True(assetRemainingValue.Text == "$0.00");
                Assert.True(totalRedLbl.Text == "Total Reductions: $ " + moneyValue);
            }
        }

        [Given(@"Collapse (.*) area in New Asset page")]
        [When(@"Collapse (.*) area in New Asset page")]
        [Then(@"Collapse (.*) area in New Asset page")]
        public void collapseForm1NoteArea(string text)
        {

            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(50));
            WaitForBlockOverlayToDissapear();
            Thread.Sleep(500);
            Actions builder = new Actions(driver);
            IWebElement areaToScroll = null;
            IWebElement areaToCollapse = null;

            if (text == "Form 1 Note")
            {
                areaToScroll = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//div[@class='formOnePreview']")));
                scrollToElement(areaToScroll);
                areaToCollapse = wait.Until(ExpectedConditions.ElementIsVisible(By.Id("formOneNote-expandableSection")));
                clickNotVisualizedElement(areaToCollapse);
                ignoreNoSuchElementException();
                wait.Until(ExpectedConditions.InvisibilityOfElementLocated(By.Id("formOneNoteTextArea")));
                wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//div[@id='formOneNote-expandableArrow']/i[@class='au-target fa fa-chevron-down']")));
            }
            else if (text == "Options and Dates")
            {
                areaToScroll = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//div[@id='reservedStatus-expandableSection']")));
                scrollToElement(areaToScroll);
                areaToCollapse = wait.Until(ExpectedConditions.ElementIsVisible(By.Id("optionsAndDatesSection-expandableSection")));
                clickNotVisualizedElement(areaToCollapse);
                ignoreNoSuchElementException();
                wait.Until(ExpectedConditions.InvisibilityOfElementLocated(By.Id("ownershipStatus-Label")));
                wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//div[@id='optionsAndDatesSection-expandableArrow']/i[@class='au-target fa fa-chevron-down']")));
            }
            else
            {
                areaToScroll = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//div[@id='moreOptions-expandableSectionBottom']")));
                scrollToElement(areaToScroll);
                areaToCollapse = wait.Until(ExpectedConditions.ElementIsVisible(By.Id("reservedStatus-expandableSection")));
                clickNotVisualizedElement(areaToCollapse);
                ignoreNoSuchElementException();
                wait.Until(ExpectedConditions.InvisibilityOfElementLocated(By.Id("reservedStatus-Label")));
                wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//div[@id='reservedStatus-expandableArrow']/i[@class='au-target fa fa-chevron-down']")));
            }
            WaitForBlockOverlayToDissapear();
        }

        [Given(@"Expand (.*) area in New Asset page")]
        [When(@"Expand (.*) area in New Asset page")]
        [Then(@"Expand (.*) area in New Asset page")]
        public void expandForm1NoteArea(string text)
        {

            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(50));
            WaitForBlockOverlayToDissapear();
            Thread.Sleep(500);
            Actions builder = new Actions(driver);
            IWebElement areaToScroll = null;
            IWebElement areaToExpand = null;

            if (text == "Form 1 Note")
            {
                areaToScroll = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//div[@class='formOnePreview']")));
                scrollToElement(areaToScroll);
                areaToExpand = wait.Until(ExpectedConditions.ElementIsVisible(By.Id("formOneNote-expandableSection")));
                clickNotVisualizedElement(areaToExpand);
                ignoreNoSuchElementException();
                wait.Until(ExpectedConditions.ElementIsVisible(By.Id("formOneNoteTextArea")));
                wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//div[@id='formOneNote-expandableArrow']/i[@class='au-target fa fa-chevron-up']")));
            }
            else if (text == "Options and Dates")
            {
                areaToScroll = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//div[@id='reservedStatus-expandableSection']")));
                scrollToElement(areaToScroll);
                areaToExpand = wait.Until(ExpectedConditions.ElementIsVisible(By.Id("optionsAndDatesSection-expandableSection")));
                clickNotVisualizedElement(areaToExpand);
                ignoreNoSuchElementException();
                wait.Until(ExpectedConditions.ElementIsVisible(By.Id("ownershipStatus-Label")));
                wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//div[@id='optionsAndDatesSection-expandableArrow']/i[@class='au-target fa fa-chevron-up']")));
            }
            else
            {
                areaToScroll = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//div[@id='moreOptions-expandableSectionBottom']")));
                scrollToElement(areaToScroll);
                areaToExpand = wait.Until(ExpectedConditions.ElementIsVisible(By.Id("reservedStatus-expandableSection")));
                clickNotVisualizedElement(areaToExpand);
                ignoreNoSuchElementException();
                wait.Until(ExpectedConditions.ElementIsVisible(By.Id("reservedStatus-Label")));
                wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//div[@id='reservedStatus-expandableArrow']/i[@class='au-target fa fa-chevron-up']")));
            }
            WaitForBlockOverlayToDissapear();
        }

        [Given(@"Asset input field '(.*)' is in '(.*)' state")]
        [When(@"Asset input field '(.*)' is in '(.*)' state")]
        [Then(@"Asset input field '(.*)' is in '(.*)' state")]
        public void assetInputFieldIsEnabledOrDisabled(string field, string state)
        {
            Thread.Sleep(1500);
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
            Actions builder = new Actions(driver);
            WaitForBlockOverlayToDissapear();
            IWebElement codeField = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//select[@id='assetCodeTextBox']/../span")));
            IWebElement subCodeField = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//select[@id='subcodeDesktop']/../span")));

            if (field == "Code" && state == "Enabled")
            {
                string className = codeField.GetAttribute("class").ToString();
                Assert.False(className.Contains("disabled"));
            }
            else if (field == "Code" && state == "Disabled")
            {
                string className = codeField.GetAttribute("class").ToString();
                Assert.True(className.Contains("disabled"));
            }
            else if (field == "Sub Code" && state == "Enabled")
            {
                string className = subCodeField.GetAttribute("class").ToString();
                Assert.False(className.Contains("disabled"));
                IWebElement subCodePlaceHolder = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//span[@id='select2-subcodeDesktop-container']/span")));
                Assert.True(subCodePlaceHolder.Text.Contains("Search..."));
            }
            else if (field == "Sub Code" && state == "Disabled")
            {
                string className = subCodeField.GetAttribute("class").ToString();
                Assert.True(className.Contains("disabled"));
                IWebElement subCodePlaceHolder = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//span[@id='select2-subcodeDesktop-container']/span")));
                Assert.True(subCodePlaceHolder.Text.Contains("Search..."));
            }
            WaitForBlockOverlayToDissapear();
        }

        [Given(@"Clear drowpdown field (.*) on New Assets page")]
        [When(@"Clear drowpdown field (.*) on New Assets page")]
        [Then(@"Clear drowpdown field (.*) on New Assets page")]
        public void clearDropDownFieldOnNewAssetPage(string field)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(50));
            WaitForBlockOverlayToDissapear();
            Thread.Sleep(1000);
            if (field == "Code")
            {
                IWebElement codeDropDown = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//span[@id='select2-assetCodeTextBox-container']")));
                codeDropDown.Click();
                Thread.Sleep(500);
                IWebElement emptyResult = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//div[@id='-1']")));
                emptyResult.Click();
            }
            else if (field == "Sub Code")
            {
                IWebElement subCodeDropDown = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//span[@id='select2-subcodeDesktop-container']")));
                subCodeDropDown.Click();
                Thread.Sleep(500);
                IWebElement emptyResult = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//div[@id='-1']")));
                emptyResult.Click();
            }
            WaitForBlockOverlayToDissapear();
        }
    }
}
