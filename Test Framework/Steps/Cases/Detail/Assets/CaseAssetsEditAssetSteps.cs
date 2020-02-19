using Epiq.ETS.TCMS.Anywhere.Testing.E2ETest.Test_Framework.Steps.Common;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.ObjectModel;
using System.Threading;
using TechTalk.SpecFlow;

namespace Epiq.ETS.TCMS.Anywhere.Testing.E2ETest.Test_Framework.Core
{
    public class EditAssetsPageStepDefinitions : CommonMethodsUnityStepBase
    {
        [Given(@"Verify Edit Assets page layout")]
        [When(@"Verify Edit Assets page layout")]
        [Then(@"Verify Edit Assets page layout")]
        public void verifyEditAssetsPageLayout()
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(50));
            Thread.Sleep(1500);
            pleaseWaitSignDissapear();

            IWebElement newAssetTitle = wait.Until(ExpectedConditions.ElementIsVisible(By.Id("newClaimTitle")));
            IWebElement descLbl = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//div/label[@id='searchLabelassetDescriptionValue']")));
            IWebElement addToListCbxLbl = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//div[@class='left']/label")));
            IWebElement grayNumberContainer = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//div/p[@id='newAssetNumber']/..")));
            IWebElement newAssetNumber = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//div/p[@id='newAssetNumber']")));
            IWebElement codesTitle = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//*[@id='newAsset']/div[2]/div[1]/div[3]/span")));
            IWebElement codeSearchLbl = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//label[@id='codeSearchLabel']")));
            IWebElement codeSearchInput = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//span[@id='select2-assetCodeTextBox-container']")));
            IWebElement petitionLbl = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//div[@id='petitionGroup']/label")));
            IWebElement petitionResult = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//div/label[@id='lblPetition']")));
            IWebElement petitionValuesStatusLbl = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//label[@id='petitionValueStatus-Label']")));
            IWebElement petitionKnownStatusRbtn = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//my-radiobutton/div/div/div[1]/input[@id='petitionValueStatus-Known']/../../div[1]")));
            IWebElement petitionUnknownStatusRbtn = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//my-radiobutton/div/div/div[1]/input[@id='petitionValueStatus-Unknown']/../../div[1]")));
            IWebElement petitionKnownLbl = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//my-radiobutton/div/div/div[1]/input[@id='petitionValueStatus-Known']/../../div[2]/span")));
            IWebElement petitionUnknownLbl = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//my-radiobutton/div/div/div[1]/input[@id='petitionValueStatus-Unknown']/../../div[2]/span")));
            IWebElement trusteeValuesStatusLbl = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//label[@id='valueStatus-Label']")));
            IWebElement trusteeKnownStatusRbtn = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//my-radiobutton/div/div/div[1]/input[@id='valueStatus-Known']/../../div[1]")));
            IWebElement trusteeUnknownStatusRbtn = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//my-radiobutton/div/div/div[1]/input[@id='valueStatus-Unknown']/../../div[1]")));
            IWebElement trusteeNAStatusRbtn = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//my-radiobutton/div/div/div[1]/input[@id='valueStatus-NA']/../../div[1]")));
            IWebElement trusteeKnownLbl = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//my-radiobutton/div/div/div[1]/input[@id='valueStatus-Known']/../../div[2]/span")));
            IWebElement trusteeUnknownLbl = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//my-radiobutton/div/div/div[1]/input[@id='valueStatus-Unknown']/../../div[2]/span")));
            IWebElement trusteeNALbl = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//my-radiobutton/div/div/div[1]/input[@id='valueStatus-NA']/../../div[2]/span")));
            IWebElement subCodeSearchLbl = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//div[@id='codeSearchContainer']/label[contains(text(),'SUB CODE')]")));
            IWebElement subCodeSearchInput = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//span[@id='select2-subcodeDesktop-container']")));
            IWebElement moreOptionsExpandableTitle = wait.Until(ExpectedConditions.ElementIsVisible(By.Id("moreOptions-expandableTitle")));
            IWebElement moreOptionsExpandableArrow = wait.Until(ExpectedConditions.ElementIsVisible(By.Id("moreOptions-expandableArrow")));
            IWebElement saveButton = wait.Until(ExpectedConditions.ElementIsVisible(By.Id("saveNewAsset")));
            IWebElement cancelButton = wait.Until(ExpectedConditions.ElementIsVisible(By.Id("cancelNewAsset")));

            Assert.AreEqual((newAssetTitle.Text), ("Edit Asset"));
            Assert.AreEqual((descLbl.Text), ("DESCRIPTION"));
            Assert.AreEqual((addToListCbxLbl.Text), ("Add to List"));
            Assert.AreEqual((codesTitle.Text), ("Codes"));
            Assert.AreEqual((codeSearchLbl.Text), ("CODE"));
            Assert.AreEqual((petitionLbl.Text), ("PETITION"));
            Assert.AreEqual((petitionResult.Text), ("Scheduled"), (petitionResult.Text), ("Unscheduled"), (petitionResult.Text), ("- -"));
            Assert.AreEqual((petitionValuesStatusLbl.Text), ("PETITION VALUE STATUS"));
            Assert.AreEqual((trusteeValuesStatusLbl.Text), ("TRUSTEE VALUE STATUS"));
            Assert.AreEqual((trusteeKnownLbl.Text), ("Known"));
            Assert.AreEqual((trusteeUnknownLbl.Text), ("Unknown"));
            Assert.AreEqual((trusteeNALbl.Text), ("NA"));
            Assert.AreEqual((subCodeSearchLbl.Text), ("SUB CODE"));
            Assert.AreEqual((saveButton.Text), ("SAVE"));
            Assert.AreEqual((cancelButton.Text), ("CANCEL"));
            Assert.AreEqual((moreOptionsExpandableTitle.Text), ("More Options"));
            Assert.AreEqual((petitionKnownLbl.Text), ("Known"));
            Assert.AreEqual((petitionUnknownLbl.Text), ("Unknown"));
        }

        [Given(@"Verify Edit Assets Calculations section layout")]
        [When(@"Verify Edit Assets Calculations section layout")]
        [Then(@"Verify Edit Assets Calculations section layout")]
        public void verifyEditAssetsCalculationsSectionLayout()
        {

            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(50));
            Thread.Sleep(1000);
            pleaseWaitSignDissapear();

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

            Assert.AreEqual((calculationsTitle.Text), ("Calculations"));
            Assert.AreEqual((petitionValLbl.Text), ("PETITION VALUE"));
            Assert.AreEqual((petitionValInput.GetAttribute("value").ToString()), ("$ 50,000.00"));
            Assert.AreEqual((trusteeValLbl.Text), ("TRUSTEE VALUE"));
            Assert.AreEqual((trusteeValInput.GetAttribute("value").ToString()), ("$ 50,000.00"));
            Assert.AreEqual((netValReduLbl.Text), ("Net Value Reductions"));
            Assert.AreEqual((liensLbl.Text), ("LIENS"));
            Assert.AreEqual((liensInput.GetAttribute("value").ToString()), ("$ 0.00"));
            Assert.AreEqual((estCostSalLbl.Text), ("EST. COST OF SALE"));
            Assert.AreEqual((estCostSalInput.GetAttribute("value").ToString()), ("$ 0.00"));
            Assert.AreEqual((exemptionsLbl.Text), ("EXEMPTIONS"));
            Assert.AreEqual((exemptionsInput.GetAttribute("value").ToString()), ("$ 0.00"));
            Assert.AreEqual((totalRedLbl.Text), ("Total Reductions: $ 0.00"));
            Assert.AreEqual((netValRedLbl.Text), ("NET VALUE REDUCTIONS"));
            Assert.AreEqual((netValRedNumLbl.Text), ("$0.00"));
            Assert.AreEqual((initEstValLbl.Text), ("INITIAL ESTATE VALUE"));
            Assert.AreEqual((initEstValNumLbl.Text), ("$50,000.00"));
            Assert.AreEqual((currentEstSaleLbl.Text), ("CURRENT ESTATE VALUE"));
            Assert.AreEqual((currentEstSaleNumLbl.Text), ("$50,000.00"));
            Assert.AreEqual((form1PreviewTitle.Text), ("Form 1 Preview"));
            Assert.AreEqual((assetPetitionPosition.Text), ("2"));
            Assert.AreEqual((assetPetitionLabel.Text), ("Petition/Unsched Value"));
            Assert.AreEqual((assetPetitionValue.Text), ("$50,000.00"));
            Assert.AreEqual((assetNetPosition.Text), ("3"));
            Assert.AreEqual((assetNetLabel.Text), ("Net Value"));
            Assert.AreEqual((assetNetValue.Text), ("Unknown"));
            Assert.AreEqual((assetAbandonedPosition.Text), ("4"));
            Assert.AreEqual((assetAbandonedLabel.Text), ("Abandoned"));
            Assert.AreEqual((assetAbandonedValue.Text), ("Unknown"));
            Assert.AreEqual((assetSalesPosition.Text), ("5"));
            Assert.AreEqual((assetSalesLabel.Text), ("Sales"));
            Assert.AreEqual((assetSalesValue.Text), ("$0.00"));
            Assert.AreEqual((assetRemainingPosition.Text), ("6"));
            Assert.AreEqual((assetRemainingLabel.Text), ("Remaining Value/FA"));
            Assert.AreEqual((assetRemainingValue.Text), ("$50,000.00"));
        }

        [Given(@"Verify Edit Assets More Options section layout")]
        [When(@"Verify Edit Assets More Options section layout")]
        [Then(@"Verify Edit Assets More Options section layout")]
        public void verifyEditAssetsMoreOptionsSectionLayout()
        {

            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(50));
            pleaseWaitSignDissapear();
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
            IWebElement secondUSTReportDatebox = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//my-datebox[@id='secondUSTReportDatebox']/div/label")));
            IWebElement secondUSTReportDateboxInput = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//my-datebox[@id='secondUSTReportDatebox']/div/label/input[contains(@placeholder, 'MM/DD/YYYY')]")));
            IWebElement secondUSTReportDateboxCalendar = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//my-datebox[@id='secondUSTReportDatebox']/div/label/i")));
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
            scrollToElement(fullyAdministeredDatebox);
            IWebElement debtorOwnedTbx = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//input[@id='debtorOwnedValueTextbox']")));
            IWebElement reservedStatusExpandableTitle = wait.Until(ExpectedConditions.ElementIsVisible(By.Id("reservedStatus-expandableTitle")));
            IWebElement reservedNote = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//span[@class='reservedNote']")));
            IWebElement reservedStatusLabel = wait.Until(ExpectedConditions.ElementIsVisible(By.Id("reservedStatus-Label")));
            IWebElement reservedStatusNoChkBox = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//input[@id='reservedStatus-No']/..")));
            IWebElement reservedStatusNoChkLbl = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//div[@id='radio-buton-text-reservedStatus']/span[contains(text(),'No')]")));
            IWebElement reservedStatusYesChkBox = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//input[@id='reservedStatus-Yes']/..")));
            IWebElement reservedStatusYesChkLbl = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//div[@id='radio-buton-text-reservedStatus']/span[contains(text(),'Yes')]")));
            IWebElement reservedStatusNote = wait.Until(ExpectedConditions.ElementIsVisible(By.Id("reservedStatusNote")));
            IWebElement charCounter2 = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//div/remaining-characters/textarea[@id='reservedStatusNote']/../label[@class='remainingCharacters']")));

            Assert.AreEqual((formOneNoteExpandableTitle.Text), ("Form 1 Note"));
            Assert.AreEqual((formOneNoteTitle.Text), ("FORM 1 NOTE"));
            Assert.AreEqual((formOneNoteTextArea.GetAttribute("value").ToString()), ("Something in the Form"));
            Assert.AreEqual((charCounter1.Text), ("Remaining Characters: 31979"));
            Assert.AreEqual((optionsAndDatesSectionExpandableTitle.Text), ("Options and Dates"));
            Assert.AreEqual((fullyAdministeredDatebox.Text), ("FULLY ADMINISTERED DATE"));
            Assert.AreEqual((fullyAdministeredDateboxInput.GetAttribute("value").ToString()), ("09/01/2020"));
            Assert.AreEqual((firstUSTReportDatebox.Text), ("1ST UST REPORT DATE"));
            Assert.AreEqual((firstUSTReportDateboxInput.GetAttribute("value").ToString()), ("09/01/2030"));
            Assert.AreEqual((secondUSTReportDatebox.Text), ("2ND UST REPORT DATE"));
            Assert.AreEqual((secondUSTReportDateboxInput.GetAttribute("value").ToString()), ("09/01/2040"));
            Assert.AreEqual((abandonedStatusLabel.Text), ("ABANDONED"));
            Assert.AreEqual((abandStatusNoChkLbl.Text), ("No"));
            Assert.AreEqual((abandStatusYesChkLbl.Text), ("Yes (OA)"));
            Assert.AreEqual((abandStatusUnknownChkLbl.Text), ("Unknown"));
            Assert.AreEqual((ownershipStatusLabel.Text), ("OWNERSHIP"));
            Assert.AreEqual((ownerStatusUnkChkLbl.Text), ("Unknown"));
            Assert.AreEqual((ownerStatusHusbChkLbl.Text), ("Husband"));
            Assert.AreEqual((ownerStatusWifeChkLbl.Text), ("Wife"));
            Assert.AreEqual((ownerStatusJointChkLbl.Text), ("Joint"));
            Assert.AreEqual((ownerStatusCommChkLbl.Text), ("Community"));
            Assert.AreEqual((ownerStatusNAChkLbl.Text), ("N/A"));
            Assert.AreEqual((debtorOwnedTbx.GetAttribute("value").ToString()), ("$ 600.00"));
            Assert.AreEqual((reservedStatusExpandableTitle.Text), ("Reserved Status"));
            Assert.That(reservedNote.Text.Contains("\"Note: Marking an asset as reserved, allows a trustee to submit a final report. When selected, additional language will be added to the TFR asserting the Trustee's right to administer this asset at a later date, even if the case has been closed.\""));
            Assert.AreEqual((reservedStatusLabel.Text), ("RESERVED"));
            Assert.AreEqual((reservedStatusNoChkLbl.Text), ("No"));
            Assert.AreEqual((reservedStatusYesChkLbl.Text), ("Yes"));
            Assert.AreEqual((reservedStatusNote.GetAttribute("value").ToString()), ("I am so reserved right now."));
            Assert.AreEqual((charCounter2.Text), ("Remaining Characters: 997"));
        }

        [Given(@"Click Edit button for asset with Description (.*)")]
        [When(@"Click Edit button for asset with Description (.*)")]
        [Then(@"Click Edit button for asset with Description (.*)")]
        public void clickEditButtonForAssets(string text)
        {

            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(50));
            pleaseWaitSignDissapear();
            AddDataToScenarioContextOverridingExistentKey("toEditElementDesc", text);
            IWebElement editButton = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//div[@class='row']/div/h4[contains(text(),'" + text + "')]/../..//div/a")));
            scrollToElement(driver.FindElement(By.XPath("//span[@id='assetTileName']")));
            clickNotVisualizedElement(editButton);
            pleaseWaitSignDissapear();
        }

        [Given(@"Edit Description field with text (.*)")]
        [When(@"Edit Description field with text (.*)")]
        [Then(@"Edit Description field with text (.*)")]
        public void editDescription(string text)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(50));
            ScenarioContext.Current.Get<string>("toEditElementDesc");
            pleaseWaitSignDissapear();
            Thread.Sleep(2000);
            IWebElement typeBar = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//span/input[@class='select2-search__field']")));
            typeStringByChar(text, typeBar);
            typeBar.SendKeys(" " + createRandomNumber());
            Thread.Sleep(1500);

            ReadOnlyCollection<IWebElement> results = createVisibleElementsCollectionByXpath("//ul[@id='select2-assetDescriptionValue-results']/li");
            selectResultContainsSearchedText(results, text);
            pleaseWaitSignDissapear();
        }

        [Given(@"Verify (.*) input field Value for Edited Asset updates proper fields and labels")]
        [When(@"Verify (.*) input field Value for Edited Asset updates proper fields and labels")]
        [Then(@"Verify (.*) input field Value for Edited Asset updates proper fields and labels")]
        public void verifyCalculationsValuesOnEditedAsset(string input)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(50));
            pleaseWaitSignDissapear();
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
                string trusteeInputValue = trusteeValInput.GetAttribute("value").ToString();
                Assert.AreEqual(trusteeInputValue == inputField, "TRUSTEE VALUE input field value '" + trusteeInputValue + "' is not equal to PETITION VALUE input field value '" + inputField + "'");
                Assert.AreEqual((netValRedNumLbl.Text), ("$" + moneyValue), (netValRedNumLbl.Text), ("$0.00"), "NET VALUE REDUCTIONS label value '" + netValRedNumLbl.Text + "' is not equal to entered value '$" + moneyValue + "' nor default value '$0.00'");
                Assert.AreEqual((initEstValNumLbl.Text), ("$" + moneyValue), (initEstValNumLbl.Text), ("$0.00"), "INITIAL STATE VALUE label value '" + initEstValNumLbl.Text + "' is not equal to entered value '$" + moneyValue + "' nor default value '$0.00'");
                Assert.AreEqual((currentEstSaleNumLbl.Text), ("$" + moneyValue), (currentEstSaleNumLbl.Text), ("$0.00"), "CURRENT STATE VALUE label value '" + currentEstSaleNumLbl.Text + "' is not equal to entered value '$" + moneyValue + "' nor default value '$0.00'");
                Assert.AreEqual((assetPetitionValue.Text), ("$" + moneyValue), (assetPetitionValue.Text), ("$0.00"), "Petition/Unsched Value label value '" + assetPetitionValue.Text + "' is not equal to entered value '$" + moneyValue + "' nor default value '$0.00'");
                Assert.AreEqual((assetNetValue.Text), ("$" + moneyValue), (assetNetValue.Text), ("$0.00"), "Net Value label value '" + assetNetValue.Text + "' is not equal to entered value '$" + moneyValue + "' nor default value '$0.00'");
                Assert.AreEqual((assetAbandonedValue.Text), ("Yes (OA)"), (assetAbandonedValue.Text), ("$0.00"), "Abandoned label value '" + assetAbandonedValue.Text + "' is not equal to entered value '$" + moneyValue + "' nor default value '$0.00'");
                Assert.AreEqual((assetSalesValue.Text), ("$" + moneyValue), (assetSalesValue.Text), ("$0.00"), "Sales label value '" + assetSalesValue.Text + "' is not equal to entered value '$" + moneyValue + "' nor default value '$0.00'");
                Assert.AreEqual((assetRemainingValue.Text), ("$" + moneyValue), (assetRemainingValue.Text), ("$0.00"), "Remaining Value/FA label value '" + assetRemainingValue.Text + "' is not equal to entered value '$" + moneyValue + "' nor default value '$0.00'");
            }
            else if (input == "Trustee")
            {
                Assert.AreEqual((netValRedNumLbl.Text), ("$" + moneyValue), (netValRedNumLbl.Text), ("$0.00"));
                Assert.AreEqual((initEstValNumLbl.Text), ("$" + moneyValue), (initEstValNumLbl.Text), ("$0.00"));
                Assert.AreEqual((currentEstSaleNumLbl.Text), ("$" + moneyValue), (currentEstSaleNumLbl.Text), ("$0.00"));
                Assert.AreEqual((assetPetitionValue.Text), ("$" + moneyValue), (assetPetitionValue.Text), ("$0.00"));
                Assert.AreEqual((assetNetValue.Text), ("$" + moneyValue), (assetNetValue.Text), ("$0.00"));
                Assert.AreEqual((assetAbandonedValue.Text), ("Yes (OA)"), (assetAbandonedValue.Text), ("$0.00"));
                Assert.AreEqual((assetSalesValue.Text), ("$" + moneyValue), (assetSalesValue.Text), ("$0.00"));
                Assert.AreEqual((assetRemainingValue.Text), ("$" + moneyValue), (assetRemainingValue.Text), ("$0.00"));
            }
            else
            {
                wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//input[@id='assetEstimatedCostValue']"))).SendKeys(Keys.Tab);
                Assert.AreEqual((totalRedLbl.Text == "Total Reductions: $ " + moneyValue), (totalRedLbl.Text == "Total Reductions: $ 0.00"));
                Assert.AreEqual((netValRedNumLbl.Text == "$" + moneyValue), (netValRedNumLbl.Text == "$0.00"));
                Assert.AreEqual((initEstValNumLbl.Text), ("$" + moneyValue), (initEstValNumLbl.Text), ("$0.00"));
                Assert.AreEqual((currentEstSaleNumLbl.Text), ("$" + moneyValue), (currentEstSaleNumLbl.Text), ("$0.00"));
                Assert.AreEqual((assetPetitionValue.Text), ("$" + moneyValue), (assetPetitionValue.Text), ("$0.00"));
                Assert.AreEqual((assetNetValue.Text), ("$" + moneyValue), (assetNetValue.Text), ("$0.00"));
                Assert.AreEqual((assetAbandonedValue.Text), ("Yes (OA)"), (assetAbandonedValue.Text), ("$0.00"));
                Assert.AreEqual((assetSalesValue.Text), ("$" + moneyValue), (assetSalesValue.Text), ("$0.00"));
                Assert.AreEqual((assetRemainingValue.Text), ("$" + moneyValue), (assetRemainingValue.Text), ("$0.00"));
            }
        }

        [Given(@"I save Code and Sub Code values from input fields")]
        [When(@"I save Code and Sub Code values from input fields")]
        [Then(@"I save Code and Sub Code values from input fields")]
        public void saveCodeValue()
        {
            pleaseWaitSignDissapear();
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
            IWebElement codeField = wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//span[@id='select2-assetCodeTextBox-container']")));
            IWebElement subCodeField = wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//span[@id='select2-subcodeDesktop-container']")));

            string codeWithbar = codeField.Text.Insert(5, "/ ");
            string subCodeWithbar1 = subCodeField.Text.Insert(2, "/ ");
            string subCodeWithbar2 = subCodeWithbar1.Insert(0, "0");
            AddDataToScenarioContextOverridingExistentKey("savedCode", codeWithbar);
            AddDataToScenarioContextOverridingExistentKey("savedSubCode", subCodeWithbar2);
            pleaseWaitSignDissapear();
        }

        [Given(@"Verify edit Code or Sub Code is highlighted at the top of the list")]
        [When(@"Verify edit Code or Sub Code is highlighted at the top of the list")]
        [Then(@"Verify edit Code or Sub Code is highlighted at the top of the list")]
        public void verifyDisplayedCodesCorrect()
        {
            pleaseWaitSignDissapear();
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
            ReadOnlyCollection<IWebElement> listedCodes = wait.Until(ExpectedConditions.PresenceOfAllElementsLocatedBy(By.XPath("//span[@class='select2-results']/ul/li/div[not(@id='-1')]/..")));
            ReadOnlyCollection<IWebElement> listedCodesLbl = wait.Until(ExpectedConditions.PresenceOfAllElementsLocatedBy(By.XPath("//span[@class='select2-results']/ul/li/div[not(@id='-1')]")));
            string savedCode = ScenarioContext.Current.Get<string>("savedCode");
            string savedSubCode = ScenarioContext.Current.Get<string>("savedSubCode");
            string ariaSelected = listedCodes[0].GetAttribute("aria-selected").ToString();
            Assert.AreEqual((ariaSelected),("true"));

            Assert.True(listedCodesLbl[0].Text.Replace(" Chapter 7 -", "").Contains(savedCode) || listedCodes[0].Text.Contains(savedSubCode));
            pleaseWaitSignDissapear();
        }
    }
}
