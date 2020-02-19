using OpenQA.Selenium;

namespace Epiq.ETS.TCMS.Anywhere.Testing.E2ETest.TestFramework.Pages.Cases.Detail
{
    public class CaseNoteData
    {
        public string Text { get; internal set; }
        public string CreatedBy { get; internal set; }
        public string CreatedDate { get; internal set; }
        public string EditedBy { get; internal set; }
        public string EditedDate { get; internal set; }
        public object EditedByLabel { get; internal set; }
        public object CreatedByLabel { get; internal set; }
        public bool ReadMoreLinkPresentAndActive { get; internal set; }
        public string ReadMoreLinkText { get; internal set; }
        public int Id { get; internal set; }
    }
}