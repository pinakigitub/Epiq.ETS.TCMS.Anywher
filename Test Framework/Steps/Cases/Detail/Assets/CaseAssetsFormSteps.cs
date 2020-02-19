using Epiq.ETS.TCMS.Anywhere.Testing.E2ETest.Test_Framework.Pages.Cases.Detail;
using Epiq.ETS.TCMS.Anywhere.Testing.E2ETest.TestFramework.Pages.Cases.Detail;
using FluentAssertions;
using System;
using TechTalk.SpecFlow;

namespace Epiq.ETS.TCMS.Anywhere.Testing.E2ETest.Test_Framework.Steps.Cases.Detail.Assets
{
    [Binding]
    public class CaseAssetsFormSteps:StepBase
    {
        //REFACTORED
        private AssetsDetailTab assetsTab = ((AssetsDetailTab)GetSharedPageObjectFromContext("Assets Tab"));

        //Tabbing
        [Given(@"I Click on New Asset Button")]
        public void GivenIClickOnNewAssetButton()
        {
            AssetForm assetForm = assetsTab.ClickNewAssetButton();
            ScenarioContext.Current.Add("Asset Form", assetForm);
        }

        [Given(@"I Click on Edit Button For The First Asset On Assets List")]
        public void GivenIClickOnEditButtonForTheFirstAssetOnAssetsList()
        {
            AssetForm assetForm = assetsTab.ClickQuickEditButtonOnFirstAsset();
            ScenarioContext.Current.Add("Asset Form", assetForm);
        }

        [Given(@"I See Asset Default Cursor Position Is Description Field")]
        public void GivenISeeAssetDefaultCursorPositionIsDescriptionField()
        {            
            AssetForm assetForm = ScenarioContext.Current.Get<AssetForm>("Asset Form");
            assetForm.Pause(2);
            assetForm.IsFocusOnField("Description");
        }   
        
        [Given(@"I Click On New Asset Form Description Field")]
        public void GivenIClickOnNewAssetFormDescriptionField()
        {
            AssetForm assetForm = ScenarioContext.Current.Get<AssetForm>("Asset Form");
            assetForm.Pause(2);
            assetForm.ClickOnField("Description");
            assetForm.Pause(2);
        }


        [Then(@"I See Asset Cursor Position Is '(.*)' Field")]
        public void ThenISeeAssetCursorPositionIsField(string field)
        {
            AssetForm assetForm = ScenarioContext.Current.Get<AssetForm>("Asset Form");                  
            assetForm.IsFocusOnField(field).Should().BeTrue("Focus is on field "+field);
        }

        [Then(@"I See Asset Cursor Position Is '(.*)' Button")]
        public void ThenISeeAssetCursorPositionIsButton(string button)
        {
            AssetForm assetForm = ScenarioContext.Current.Get<AssetForm>("Asset Form");
            assetForm.IsFocusOnButton(button).Should().BeTrue("Focus is on button " + button);
        }

        [Given(@"I Click On Asset More Options")]
        [When(@"I Click On Asset More Options")]
        [Then(@"I Click On Asset More Options")]
        public void WhenIClickOAssetnMoreOptions()
        {
            AssetForm assetForm = ScenarioContext.Current.Get<AssetForm>("Asset Form");
            assetForm.ClickMoreOptionsLink();
        }

        [Then(@"I See Asset More Options Is Open")]
        public void ThenISeeAssetMoreOptionsIsOpen()
        {
            AssetForm assetForm = ScenarioContext.Current.Get<AssetForm>("Asset Form");
            assetForm.IsMoreOptionsVisible().Should().BeTrue("More Options Section is Open");
        }

        [Then(@"I See Asset More Options Is Closed")]
        public void ThenISeeAssetMoreOptionsIsClosed()
        {
            AssetForm assetForm = ScenarioContext.Current.Get<AssetForm>("Asset Form");
            assetForm.IsMoreOptionsVisible().Should().BeFalse("More Options Section is Closed");
        }

        //Value Fields
        [Given(@"I See Asset '(.*)' Field Value is '(.*)'")]
        [Then(@"I See Asset '(.*)' Field Value is '(.*)'")]
        public void GivenISeeAssetFieldValueIs(string field, string expValue)
        {
            AssetForm assetForm = ScenarioContext.Current.Get<AssetForm>("Asset Form");
            assetForm.GetFieldValue(field).Should().Be(expValue, field + " is " + expValue);
        }

        [Given(@"I See Asset '(.*)' Field Placeholder is '(.*)'")]
        public void GivenISeeAssetFieldPlaceholderIs(string field, string placeholder)
        {
            AssetForm assetForm = ScenarioContext.Current.Get<AssetForm>("Asset Form");
            assetForm.GetFieldPlaceholder(field).Should().Be(placeholder, field + " is " + placeholder);
        }


        [Then(@"I Enter Asset '(.*)' Field Value '(.*)'")]
        public void ThenIEnterAssetFieldValue(string field, string value)
        {
            AssetForm assetForm = ScenarioContext.Current.Get<AssetForm>("Asset Form");
            assetForm.SetFieldValue(field,value);
        }

        [Then(@"I Can Select Two Digits From Asset '(.*)' Value '(.*)' And Delete With DELETE Key Getting '(.*)'")]
        public void ThenICanSelectTwoDigitsFromAssetValueAndDeleteWithDELETEKey(string field, string value, string expected)
        {
            AssetForm assetForm = ScenarioContext.Current.Get<AssetForm>("Asset Form");
            //set value from scratch
            assetForm.SetFieldValue(field, value);                        
            
            //save for verification
            string original = assetForm.GetFieldValue(field);

            //select, delete and loose focus            
            assetForm.DeleteFirstFourDigitsFromField(field, "delete");

            //verify result after losing focus from field
            assetForm.GetFieldValue(field).Should().Be(expected, "User can delete a value partially highlighting and pressing DELETE key");
        }

        [Then(@"I Can Select Two Digits From Asset '(.*)' Value '(.*)' And Delete With BACKSPACE Key Getting '(.*)'")]
        public void ThenICanSelectTwoDigitsFromAssetValueAndDeleteWithBACKSPACEKey(string field, string value, string expected)
        {
            AssetForm assetForm = ScenarioContext.Current.Get<AssetForm>("Asset Form");
            //set value from scratch
            assetForm.SetFieldValue(field, value);            

            //save for verification
            string original = assetForm.GetFieldValue(field);

            //select, delete and loose focus
            assetForm.DeleteFirstFourDigitsFromField(field,"backspace");        

            //verify result after losing focus from field           
            assetForm.GetFieldValue(field).Should().Be(expected, "User can delete a value partially highlighting and pressing BACKSPACE key");
        }

        [Then(@"I Can Select All Digits From Asset '(.*)' Value '(.*)' And Delete With DELETE Key")]
        public void ThenICanSelectAllDigitsFromAssetValueAndDeleteWithDELETEKey(string field, string value)
        {
            AssetForm assetForm = ScenarioContext.Current.Get<AssetForm>("Asset Form");

            //set value from scratch
            assetForm.SetFieldValue(field, value);

            //select, delete and loose focus
            assetForm.DeleteAllDigitsFromField(field, "delete");

            //verify result after losing focus from field           
            assetForm.GetFieldValue(field).Should().Be("", "User can delete a value completely highlighting and pressing DELETE key");
        }

        [Then(@"I Can Select All Digits From Asset '(.*)' Value '(.*)' And Delete With BACKSPACE Key")]
        public void ThenICanSelectAllDigitsFromAssetValueAndDeleteWithBACKSPACEKey(string field, string value)
        {
            AssetForm assetForm = ScenarioContext.Current.Get<AssetForm>("Asset Form");

            //set value from scratch
            assetForm.SetFieldValue(field, value);

            //select, delete and loose focus
            assetForm.DeleteAllDigitsFromField(field, "backspace");

            //verify result after losing focus from field           
            assetForm.GetFieldValue(field).Should().Be("", "User can delete a value completely highlighting and pressing BACKSPACE key");
        }

        [Given(@"I Click On Asset Field '(.*)'")]
        [When(@"I Click On Asset Field '(.*)'")]
        public void WhenIClickOnAssetField(string field)
        {
            AssetForm assetForm = ScenarioContext.Current.Get<AssetForm>("Asset Form");
            assetForm.ClickOnField(field);
        }

    }
}
