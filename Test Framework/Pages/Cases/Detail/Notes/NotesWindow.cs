using Epiq.ETS.TCMS.Anywhere.Testing.E2ETest.Test_Framework.Pages;
using Epiq.ETS.TCMS.Anywhere.Testing.E2ETest.Test_Framework.Pages.Common;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using System;
using System.Collections.Generic;
using System.Threading;

namespace Epiq.ETS.TCMS.Anywhere.Testing.E2ETest.TestFramework.Pages.Cases.Detail
{
    public class NotesWindow:PageObject
    {
        //NOTES ICON
        private By NOTES_ICON_LOCATOR = By.Id("noteIcon");

        //GENERAL
        private By NOTES_WINDOW_OPEN_LOCATOR = By.Id("notesWindow");
        private By NOTE_TYPE_TITLE_LOCATOR = By.Id("noteLabel");
        private By STAFF_NOTES_LOCATOR = By.Id("officeLink");               

        //NEW NOTE
        private By NEW_NOTE_BUTTON_LOCATOR = By.XPath("//div[@id='newNote']/a");
        private By NEW_NOTE_INPUT_LOCATOR = By.Id("noteArea");
        private By NEW_LABELNOTE_INPUT_LOCATOR = By.Id("oneClickNoteLabel");                                   
        private By SAVE_BUTTON_LOCATOR = By.Id("saveButton");
        private By CANCEL_BUTTON_LOCATOR = By.Id("cancelButton"); 

        //HISTORICAL VIEW
        private By GENERAL_NOTE_TEXT_LOCATOR = By.XPath("//p[contains(@id, 'note')]");
        private By GENERAL_NOTE_CONTAINER_LOCATOR = By.XPath("//div[contains(@id, 'regularContainerForNote')]");
        private By NOTE_TEXT_LOCATOR = By.XPath(".//p[contains(@id, 'note')]");

        private By NOTE_EDITED_BY_LABEL_LOCATOR = By.XPath(".//div[@class='noteDetailBox'][1]/label");
        private By NOTE_CREATED_BY_LABEL_LOCATOR = By.XPath(".//div[@class='noteDetailBox'][2]/label");

        private By NOTE_CREATED_BY_VALUE_LOCATOR = By.XPath(".//div[contains(@class,'createdBy')]/span[1]");
        private By NOTE_CREATED_DATE_VALUE_LOCATOR = By.XPath(".//div[contains(@class,'createdBy')]/span[2]");
        private By NOTE_EDITED_BY_VALUE_LOCATOR= By.XPath(".//div[contains(@class,'editedBy')]/span[1]");
        private By NOTE_EDITED_DATE_VALUE_LOCATOR= By.XPath(".//div[contains(@class,'editedBy')]/span[2]");
        private string NOTE_BY_TEXT_LOCATOR_TEMPLATE = "//p[contains(@id, 'note') and contains(text(), '{0}')]";
        private string NOTE_BY_ID_LOCATOR_TEMPLATE = "regularContainerForNote{0}";
        private By NOTE_READ_MORE_LINK_LOCATOR = By.CssSelector("i.readMoreIcon");
        private By NOTE_READ_MORE_TEXT_LOCATOR = By.CssSelector("i.readMoreIcon > span");
        private By NOTE_EDIT_BUTTON_LOCATOR = By.XPath(".//i[contains(@class,'editIcon')]");
        private By TRUSTEE_TAB_LINK_OCATOR = By.Id("trusteeLink");
        private By ONECLICKADDNOTES_TAB_LINK_OCATOR = By.LinkText("One Click Notes");


        //Block UI Overlay locator - wait please message and IU blocker
        protected By BLOCK_OVERLAY_LOCATOR = By.CssSelector("div.blockUI.blockOverlay");
        protected int BLOCK_OVERLAY_WAIT_TIMEOUT = 30;

        //341 notes
        private By SELECTED_TAB_TITLE_LOCATOR = By.XPath("//*[@id='typeList']/li[contains(@class,'selected')]/a");
        private By HEADER_CASE_INFO_LOCATOR = By.CssSelector(".caseDisplayInfo");
        private By NOTE_TEXT_341_MEETING_LOCATOR = By.Id("note341Meeting");
        private By NOTE_TEMPLATE_LINK_LOCATOR = By.CssSelector(".noteTemplateOption");
        private string NOTE_TEMPLATE_LINK_BY_LABEL_LOCATOR_TEMPLATE = "//*[contains(@class,'noteTemplateOption') and contains(text(),'{0}')]";

        public NotesWindow(IWebDriver driver):base(driver, null)
        {
            this.WaitForBlockOverlayToDissapear();
        }


        public string NoteTypeTitle
        {
            get
            {
                return this.WaitForElementToBeVisible(NOTE_TYPE_TITLE_LOCATOR).Text;
            }
        }

        public void ClickOnNotesIcon()
        {
            Thread.Sleep(1500);
            this.WaitForElementToBeVisible(NOTES_ICON_LOCATOR).Click();
        }

        public void Open()
        {
            if (this.WindowIsClosed())
                this.ClickOnNotesIcon();
                
        }

        public void Close()
        {
            if(!this.WindowIsClosed())
                this.ClickOnNotesIcon();
        }

        public object StaffNotesTabTitle
        {
            get
            {
                return this.WaitForElementToBeVisible(ONECLICKADDNOTES_TAB_LINK_OCATOR).Text;
            }
        }


        public object SelectedTabTitle {
            get {
                return this.WaitForElementToBeVisible(SELECTED_TAB_TITLE_LOCATOR).Text;
            }
        }

        public string CaseInforDisplayedOnWindowHeader {
            get {
                return this.WaitForElementToBeVisible(HEADER_CASE_INFO_LOCATOR).Text;
            }
        }

        public bool WindowIsOpen()
        {
            try
            {
                this.WaitForElementToBeVisible(NOTES_WINDOW_OPEN_LOCATOR);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool WindowIsClosed()
        {
            try
            {
                this.WaitForElementToDissapear(NOTES_WINDOW_OPEN_LOCATOR, 5);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public List<CaseNoteData> GetNotes()
        {
            List<CaseNoteData> retNotes = new List<CaseNoteData>();
           
            IReadOnlyCollection<IWebElement> notes = this.WaitForElementsToBeVisible(GENERAL_NOTE_CONTAINER_LOCATOR, 2);

            foreach (IWebElement note in notes)
            {
                retNotes.Add(CreateNoteFromWebElement(note));
            }
            

            return retNotes;
        }

        public List<string> GetNotesText()
        {
            List<string> retNotes = new List<string>();

            try
            {
                IReadOnlyCollection<IWebElement> notes = this.WaitForElementsToBeVisible(GENERAL_NOTE_TEXT_LOCATOR, 2);

                foreach (IWebElement note in notes)
                {
                    retNotes.Add(note.Text);
                }
            }
            catch (Exception)
            {

                //do nothing, reutrn a empty list
            }

            return retNotes;
        }

        public void ClickNewButton()
        {
            this.WaitForElementToBeVisible(NEW_NOTE_BUTTON_LOCATOR).Click();
        }

        public void ClickSaveButton() {
            this.WaitForElementToBeClickeable(SAVE_BUTTON_LOCATOR).Click();
            this.WaitForBlockOverlayToDissapear();
        }

        public void ClickCancelButton()
        {
            this.WaitForElementToBeClickeable(CANCEL_BUTTON_LOCATOR).Click();
        }

        public bool IsNewNoteInputVisible()
        {           
           return this.IsElementVisible(NEW_NOTE_INPUT_LOCATOR);           
        }

        public bool IsNewNoteButtonVisible()
        {
            return this.IsElementVisible(NEW_NOTE_BUTTON_LOCATOR);
        }

       

        public bool IsSaveButtonActive() {

            return this.WaitForElementToBeVisible(SAVE_BUTTON_LOCATOR).Enabled;
            
        }

        public bool NewFormNoteDissapeared()
        {
            try
            {
                this.WaitForElementToDissapear(NEW_NOTE_INPUT_LOCATOR);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public void TypeNoteContent(string note)
        {
            this.ClearAndType(this.WaitForElementToBeVisible(NEW_NOTE_INPUT_LOCATOR), note);
        }
        
        public void CreateNote(string note) {
            this.Open();
            this.ClickNewButton();
            this.TypeNoteContent(note);
            this.ClickSaveButton();
        }

        public CaseNoteData GetFirstNote()
        {
            IWebElement noteWE = this.WaitForElementToBeVisible(GENERAL_NOTE_CONTAINER_LOCATOR);
            return CreateNoteFromWebElement(noteWE); 
        }

        private CaseNoteData CreateNoteFromWebElement(IWebElement noteWE)
        {
            CaseNoteData note = new CaseNoteData();

            note.Id = Convert.ToInt32(noteWE.GetAttribute("id").Replace("regularContainerForNote",""));

            note.Text = noteWE.FindElement(NOTE_TEXT_LOCATOR).Text;

            note.CreatedByLabel = noteWE.FindElement(NOTE_CREATED_BY_LABEL_LOCATOR).Text;
            note.CreatedBy = noteWE.FindElement(NOTE_CREATED_BY_VALUE_LOCATOR).Text;
            note.CreatedDate = noteWE.FindElement(NOTE_CREATED_DATE_VALUE_LOCATOR).Text;

            note.EditedByLabel = noteWE.FindElement(NOTE_EDITED_BY_LABEL_LOCATOR).Text;
            note.EditedBy = noteWE.FindElement(NOTE_EDITED_BY_VALUE_LOCATOR).Text;
            note.EditedDate = noteWE.FindElement(NOTE_EDITED_DATE_VALUE_LOCATOR).Text;

            note.ReadMoreLinkPresentAndActive = noteWE.FindElement(NOTE_READ_MORE_LINK_LOCATOR).Enabled;
            note.ReadMoreLinkText = noteWE.FindElement(NOTE_READ_MORE_TEXT_LOCATOR).Text;
            
            return note;
        }
        
        public void ClickReadMoreOnNoteById(int id)
        {
            this.WaitForElementToBeVisible(By.Id(""+id)).Click();
        }

        public void ClickReadLessOnNoteById(int id)
        {
            this.WaitForElementToBeVisible(By.Id(""+id)).Click();
        }

        public CaseNoteData GetNoteByText(string noteText)
        {
            IWebElement note = this.FocusAndGetNoteWEByText(noteText);
            return this.CreateNoteFromWebElement(note);
        }

        public void EditNoteByText(string originalText, string editionText)
        {
            this.Open();
            IWebElement note = this.FocusAndGetNoteWEByText(originalText);
            note.FindElement(NOTE_EDIT_BUTTON_LOCATOR).Click();
            TypeNoteContent(editionText);
            Pause(1);
            ClickSaveButton();
        }

        private IWebElement FocusAndGetNoteWEByText(string noteText)
        {
            //locate note and scroll to get it on view
            By noteByTextLocator = By.XPath(String.Format(NOTE_BY_TEXT_LOCATOR_TEMPLATE, noteText));
            IWebElement noteTextWE = this.WaitForElementToBePresent(noteByTextLocator);
            Actions actions = new Actions(driver);
            actions.MoveToElement(noteTextWE);
            actions.Perform();
            //get ntoe id to get container
            string noteId = noteTextWE.GetAttribute("id").Replace("note", "");
            IWebElement note = this.WaitForElementToBePresent(By.Id(String.Format(NOTE_BY_ID_LOCATOR_TEMPLATE, noteId)));

            //return note container
            return note;
        }

        public void GoToTrusteeTab()
        {
            this.Open();
            this.WaitForElementToBeVisible(TRUSTEE_TAB_LINK_OCATOR).Click();
            this.WaitForBlockOverlayToDissapear();
        }

        public void GoToOneclicknotesTab()
        {
            this.Open();
            this.WaitForElementToBeVisible(ONECLICKADDNOTES_TAB_LINK_OCATOR).Click();
            this.WaitForBlockOverlayToDissapear();
        }
        private void WaitForBlockOverlayToDissapear()
        {
            this.WaitForElementToDissapear(BLOCK_OVERLAY_LOCATOR, BLOCK_OVERLAY_WAIT_TIMEOUT);
        }
        
        public string Note341MeetingText
        {
            get
            {
                return this.WaitForElementToBeVisible(NOTE_TEXT_341_MEETING_LOCATOR).Text.TrimStart().TrimEnd();
            }            
        }        

        public void ClickEdit341NoteButton()
        {
            this.ScrollDownToPageBottom();
            this.WaitForElementToBeVisible(NOTE_EDIT_BUTTON_LOCATOR).Click();
        }

        public List<string> NoteTemplates
        {
            get
            {

                IReadOnlyCollection<IWebElement> noteTemplates = this.WaitForElementsToBeVisible(NOTE_TEMPLATE_LINK_LOCATOR);

                List<string> templates = new List<string>();
                foreach (IWebElement template in noteTemplates)
                {
                    templates.Add(template.Text);
                }

                return templates;
            }
        }

        public void SelectNoteTemplateByLabel(string label)
        {
            this.ScrollDownToPageBottom();
            this.WaitForElementToBeVisible(By.XPath(String.Format(NOTE_TEMPLATE_LINK_BY_LABEL_LOCATOR_TEMPLATE,label))).Click();
        }

        public void ClearNoteText()
        {
            this.ScrollDownToPageBottom();
            this.WaitForElementToBeVisible(NEW_NOTE_INPUT_LOCATOR).Clear();
            this.Pause(2);
        }
    }
}