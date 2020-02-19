using Epiq.ETS.TCMS.Anywhere.Testing.E2ETest.Test_Framework.Core;
using Epiq.ETS.TCMS.Anywhere.Testing.E2ETest.Test_Framework.Pages;
using Epiq.ETS.TCMS.Anywhere.Testing.E2ETest.Test_Framework.Pages.Common;
using Epiq.ETS.TCMS.Anywhere.Testing.E2ETest.TestFramework.Pages.Cases.Detail;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Configuration;
using TechTalk.SpecFlow;

namespace Epiq.ETS.TCMS.Anywhere.Testing.E2ETest.Test_Framework.Steps.Cases.Detail
{
    [Binding]
    public class CaseNotesSteps:StepBase
    {

        //REFACTORED
        private CaseDetailPage caseDetailPage = ((CaseDetailPage)GetSharedPageObjectFromContext("Case Detail"));

        [When(@"I Click on the Notes Icon")]
        public void WhenIClickOnTheNotesIcon()
        {
            caseDetailPage.Notes.ClickOnNotesIcon();
        }

        [When(@"I Open Notes Window")]
        public void WhenIOpenNotesWindow()
        {

            caseDetailPage.Notes.Open();
        }

        [When(@"I Close Notes Window")]
        public void WhenICloseNotesWindow()
        {
            caseDetailPage.Notes.Close();
        }

        [When(@"I Navigate to Case List Page")]
        public void WhenINavigateToCaseListPage()
        {
            //Navigate to Case List and Save CaseListPage on current context
            caseDetailPage.Pause(3);
            NavigationBar navBar = caseDetailPage.NavigationBar;
            SetSharedPageObjectInCurrentContext("Case List", navBar.GoToCasesList());
        }


        [When(@"I See the Notes Window is Open")]
        [Then(@"I See the Notes Window is Open")]
        public void WhenISeeTheNotesWindowIsOpen()
        {
            caseDetailPage.Notes.WindowIsOpen().Should().BeTrue("Notes Window is Open");
        }

        
        [Then(@"I See Note Type Title is '(.*)'")]
        public void ThenISeeNoteTypeTitleIs(string title)
        {
            caseDetailPage.Notes.NoteTypeTitle.Should().Be(title, "Note navigation bar title is "+title);
        }


        [Then(@"I See Staff Notes Tab Title is '(.*)'")]
        public void ThenISeeStaffNotesTab(string title)
        {
            caseDetailPage.Notes.StaffNotesTabTitle.Should().Be(title, "Staff Notes Tab title is "+title);
        }


        [Then(@"I See At Least '(.*)' Notes for the Case")]
        public void ThenISeeAtLeastNotesForTheCase(int count)
        {
            caseDetailPage.Notes.GetNotesText().Count.Should().BeGreaterOrEqualTo(count, "There are at least "+count+" notes for this Case");
        }

        [Then(@"I See Exactly '(.*)' Notes for the Case")]
        public void ThenISeeAtLeastExactlyNotesForTheCase(int count)
        {
            caseDetailPage.Notes.GetNotesText().Count.Should().Be(count, "There are " + count + " notes for this Case");
        }

        [When(@"I See the Notes Window is Closed")]
        [Then(@"I See the Notes Window is Closed")]
        public void WhenISeeTheNotesWindowIsClosed()
        {
            caseDetailPage.Notes.WindowIsClosed().Should().BeTrue("Notes Window is Closed");
        }
        

        [When(@"I Create a Note with Random Text")]
        public void WhenICreateANoteWithRandomText()
        {
            this.CreateANoteWithRandomText();
        }

        [When(@"I Create a Trustee Note with Random Text")]
        public void WhenICreateATrusteeNoteWithRandomText()
        {
            caseDetailPage.Notes.GoToTrusteeTab();
            this.CreateANoteWithRandomText();
        }

        private void CreateANoteWithRandomText()
        {
            //Generate note text
            string text = GetRandomTextForNote();

            //Wait 1 second to make sure this note goes after the previous one that could have just been created
            caseDetailPage.Pause(1);

            //Create the note 
            TestsLogger.Log("Creating note with text '" + text + "'");
            caseDetailPage.Notes.CreateNote(text);

            ScenarioContext.Current.Add("Note Text Create", text);
        }
        

        [When(@"I Create A Note with Text '(.*)'")]
        public void WhenICreateANoteWithText(String text)
        {
            if (text.Contains("Very Long Note Text"))
                this.CreateANoteWithText("Lorem ipsum ad his scripta blandit partiendo, eum fastidii accumsan euripidis in, eum liber hendrerit an.Qui ut wisi vocibus suscipiantur, quo dicit ridens inciderint id.Quo mundi lobortis reformidans eu, legimus senserit definiebas an eos.Eu sit tincidunt incorrupte definitionem, vis mutat affert percipit cu, eirmod consectetuer signiferumque eu per.In usu latine equidem dolores.Quo no falli viris intellegam, ut fugit veritus placerat per.Ius id vidit volumus mandamus, vide veritus democritum te nec, ei eos debet libris consulatu.No mei ferri graeco dicunt, ad cum veri accommodare. Sed at malis omnesque delicata, usu et iusto zzril meliore.Dicunt maiorum eloquentiam cum cu, sit summo dolor essent te.Ne quodsi nusquam legendos has, ea dicit voluptua eloquentiam pro, ad sit quas qualisque. Eos vocibus deserunt quaestio ei.Blandit incorrupte quaerendum in quo, nibh impedit id vis, vel no nullam semper audiam. Ei populo graeci consulatu mei, has ea stet modus phaedrum.Inani oblique ne has, duo et veritus detraxit.");
            else
                this.CreateANoteWithText(text);            
        }
               

        [When(@"I Create A Trustee Note with Text '(.*)'")]
        public void WhenICreateTrusteeANoteWithText(String text)
        {
            caseDetailPage.Notes.GoToTrusteeTab();
            this.CreateANoteWithText(text);
        }

        private void CreateANoteWithText(string text)
        {
            //Wait 1 second to make sure this note goes after the previous one that could have just been created
            caseDetailPage.Pause(3);

            //Create the note with the given text
            TestsLogger.Log("Creating note with text '" + text + "'");
            caseDetailPage.Notes.CreateNote(text);

            //Save created note's text  
            ScenarioContext.Current.Add("Note Text Create", text);
        }


        [When(@"I Click on New Notes Button")]
        public void WhenIClickOnNewNoteButton()
        {
            caseDetailPage.Notes.ClickNewButton();
        }


        [When(@"I Enter a Random Text on the Notes Text Area and Click On Cancel")]
        public void WhenIEnterARandomTextOnNotesAreaAndClickOnCancel()
        {
            string text = GetRandomTextForNote();
            caseDetailPage.Notes.TypeNoteContent(text);
            caseDetailPage.Notes.ClickCancelButton();
            ScenarioContext.Current.Add("Note Text Cancel", text);
        }


        [When(@"I Enter '(.*)' Text on the Notes Text Area")]
        public void WhenIEnterTextOnNotesArea(string text)
        {
            caseDetailPage.Notes.TypeNoteContent(text);
            ScenarioContext.Current.Add("Note Text Enter", text);
        }


        [Then(@"I See the New Note at the Top of Notes Historical View Displaying Correct Data")]
        public void ThenISeeTheNewNoteAtTheTopOfNotesHistoricalView()
        {
            //Set expected data for the note
            string noteText = ScenarioContext.Current.Get<string>("Note Text Create");
            string user = ConfigurationManager.AppSettings.Get("User");
            string date = DateTime.Now.ToString("MM-dd-yyyy");

            //Give the notes historical window time to Refresh
            caseDetailPage.Pause(2);

            //Get the first note and verify all data is the expected
            CaseNoteData note = caseDetailPage.Notes.GetFirstNote();
            note.Text.Should().Be(noteText, "Created Note appears on top of HIstorical View");
            note.CreatedBy.Should().Be(user, "Because Note was created with current user as Created By: " + user);
            note.CreatedDate.Should().Be(date, "Because Note was created with current date as Created Date: " + date);
            note.EditedBy.Should().Be(user, "Because Note was created with current user as Edited By: " + user);
            note.EditedDate.Should().Be(date, "Because Note was created with current date as Edited Date: " + date);
        }        

        [Then(@"I See New Note Form has Dissapeared")]
        public void ThenISeeNewNoteFormHasDissapeared() {
            caseDetailPage.Notes.NewFormNoteDissapeared().Should().BeTrue("New Note Form closes on Cancel");
            caseDetailPage.Notes.IsNewNoteButtonVisible().Should().BeTrue("New note Button comes back after Cancel ");
        }

        [Then(@"I See the Canceled Note is not Present")]
        public void ISeeTheCanceledNoteIsNotPresent()
        {
            string canceledNoteText = ScenarioContext.Current.Get<string>("Note Text Cancel");
            caseDetailPage.Notes.GetFirstNote().Text.Should().NotBe(canceledNoteText, "Canceled notes are not saved");

        }

        [When(@"I See the Save Note Button is Inactive")]
        public void ISeeTheSaveNoteButtonIsInactive()
        {
            caseDetailPage.Pause(1);
            caseDetailPage.Notes.IsSaveButtonActive().Should().BeFalse("Save button is Inactive");
        }

        [Then(@"I See the Save Note Button Is Active")]
        public void ISeeTheSaveNoteButtonIsActive()
        {
            caseDetailPage.Pause(1);
            caseDetailPage.Notes.IsSaveButtonActive().Should().BeTrue("Save Button is Active");
        }

        [When(@"I See Notes With Some Data and Ordered By Edited Date on the Historical View")]
        public void WhenISeeNotesWithSomeDataAndOrderedByEditedDateOnTheHistoricalView()
        {
            List<CaseNoteData> notes = caseDetailPage.Notes.GetNotes();

            DateTime previousDate = Convert.ToDateTime(DateTime.Now.ToString("MM-dd-yyyy"));

            foreach (CaseNoteData note in notes)
            {
                //Check all notes show some data in each field
                note.Text.Should().NotBeEmpty();
                note.CreatedBy.Should().NotBeEmpty();
                note.CreatedDate.Should().NotBeEmpty();
                note.EditedBy.Should().NotBeEmpty();
                note.EditedDate.Should().NotBeEmpty();
                note.CreatedByLabel.Should().Be("Created By:");
                note.EditedByLabel.Should().Be("Edited By:");

                //Verify Date ordering
                DateTime editedDate = Convert.ToDateTime(note.EditedDate);
                editedDate.Should().BeOnOrBefore(previousDate, "Notes Historical View is Ordered by Edited Date, descending.");
                previousDate = editedDate;
            }
        }

        //Generate some random text for test data
        private string GetRandomTextForNote()
        {
            Random rnd = new Random();
            int randomID = rnd.Next(1, 987654);
            return "Test Automation " + randomID;
        }


        [Then(@"I See a Note with Text '(.*)'")]
        public void ThenISeeANoteWithText(string noteText)
        {
            caseDetailPage.Pause(1);
            caseDetailPage.Notes.GetNoteByText(noteText).Text.Should().Be(noteText, " Note with text " + noteText + " displays on Historical View");
        }

        [When(@"I See the Note Displays with Wrapped Text and the Read More Link")]
        [Then(@"I See the Note Displays with Wrapped Text and the Read More Link")]
        public void ThenISeeTheNoteDisplaysWithAReadMoreLink()
        { 
            //Get original text for created note
            String originalText = ScenarioContext.Current.Get<String>("Note Text Create");

            //Get the note to verify visible text and read more link
            caseDetailPage.Notes.Open();
            CaseNoteData note = caseDetailPage.Notes.GetFirstNote();

            //Note visible text should be part of the original text with "..." at the end
            //note.Text.Should().NotBe(originalText);
            originalText.Should().StartWith(note.Text.Replace("...",""), "Note visible text displays wrapped and followed by '...' ");

            //Read More Link should be active for this note
            note.ReadMoreLinkText.Should().Be("READ MORE", "Read More Link has the correct text");
            note.ReadMoreLinkPresentAndActive.Should().BeTrue("Read More Link is Active for this note");

            try { ScenarioContext.Current.Add("Created Note ID", note.Id); }
            catch (Exception) { } //do nothing, could be already there

        }

        [When(@"Clicking on Read More Expands the view And Read Less Link Displays")]
        [Then(@"Clicking on Read More Expands the view And Read Less Link Displays")]
        public void ThenClickingOnReadMoreExpandsTheViewAndReadLessLinkDisplays()
        {
            // Get context data for created note
            String originalText = ScenarioContext.Current.Get<String>("Note Text Create");
            int id = ScenarioContext.Current.Get<int>("Created Note ID");

            //click on read more
            caseDetailPage.Notes.ClickReadMoreOnNoteById(id);            

            //verify the text now is complete
            CaseNoteData expandedNote = caseDetailPage.Notes.GetFirstNote();
            expandedNote.Text.Should().Be(originalText, "When clicking on Read More the note displays the whole text");

            //Verify Read Less link
            expandedNote.ReadMoreLinkText.Should().Be("READ LESS", "Read Less Link has the correct text");
            expandedNote.ReadMoreLinkPresentAndActive.Should().BeTrue("Read Less Link is Active when Note is expanded");

            //caseDetailPage.Pause(10);
        }

        [Then(@"Clicking on Read Less Closes the Expanded View")]
        public void ThenClickingOnReadLessClosesTheExpandedView()
        {
            // Get context data for created note
            String originalText = ScenarioContext.Current.Get<String>("Note Text Create");
            int id = ScenarioContext.Current.Get<int>("Created Note ID");

            //Click on Read Less link - Close Expanded view
            caseDetailPage.Notes.ClickReadLessOnNoteById(id);

            //Verify text wraps again and read more link comes back
            CaseNoteData note = caseDetailPage.Notes.GetFirstNote();
            originalText.Should().StartWith(note.Text.Replace("...", ""), "Note visible text displays wrapped and followed by '...' ");
            note.ReadMoreLinkText.Should().Be("READ MORE", "Read More Link has the correct text");
            note.ReadMoreLinkPresentAndActive.Should().BeTrue("Read More Link is Active for this note");
        }

        [When(@"I Edit Note with Text '(.*)' to Have Text '(.*)'")]
        public void WhenIEditNoteWithTextToHaveText(string originalText, string newText)
        {
            this.EditNotByText(originalText, newText);
        }

        [When(@"I Edit Trustee Note with Text '(.*)' to Have Text '(.*)'")]
        public void WhenIEditTrusteeNoteWithTextToHaveText(string originalText, string newText)
        {
            caseDetailPage.Notes.GoToTrusteeTab();
            this.EditNotByText(originalText, newText);
        }

        private void EditNotByText(string originalText, string newText)
        {
            //edit note and save the texts
            caseDetailPage.Notes.EditNoteByText(originalText, newText);
            ScenarioContext.Current.Add("Original Note Text", originalText);
            ScenarioContext.Current.Add("Edited Note Text", newText);
        }

        [Then(@"I See the Note Displays At Top Of The List With the Correct Edited Text and Date")]
        public void ThenISeeTheNoteDisplaysAtTopOfThListWithTheCorrectEditedTextAndDate()
        {
            //Wait 2 seconds for the notes list to refresh before seeking for the note
            caseDetailPage.Notes.Pause(2);

            //expected values
            string editedNoteText = ScenarioContext.Current.Get<string>("Edited Note Text");
            string date = DateTime.Now.ToString("MM-dd-yyyy");

            //actual values
            CaseNoteData firstNote = caseDetailPage.Notes.GetFirstNote();

            //verify
            firstNote.Text.Should().Be(editedNoteText, "Edited Note displays at top of the list");
            firstNote.EditedDate.Should().Be(date, "Edited Date becomes Today Date");

            //restore edited note text
            string originalNoteText = ScenarioContext.Current.Get<string>("Original Note Text");
            caseDetailPage.Notes.EditNoteByText(editedNoteText, originalNoteText);
        }

        [When(@"I Go To Trustee Tab")]
        public void IGoToTrusteeTab()
        {
            caseDetailPage.Notes.GoToTrusteeTab();
        }

        public void IGoToOneclicknotesTab()
        {
            caseDetailPage.Notes.GoToOneclicknotesTab();
        }


        [AfterScenario("@TC76133", Order=0)]
        public void AfterEditNoteScenario()
        {
            try
            {
                string editedNoteText = ScenarioContext.Current.Get<string>("Edited Note Text");
                string originalNoteText = ScenarioContext.Current.Get<string>("Original Note Text");
                caseDetailPage.Notes.EditNoteByText(editedNoteText, originalNoteText);
            }
            catch (Exception)
            {
                //do nothing, could be already reverted
            }
            
        }

        //TODO BeforeScenario to add data on DB for ShowTrusteeAndStaffNotes
        //TODO after feature remove all data generated on DB - this will make trustee note have an older date than "today"
    }
}
