namespace Epiq.ETS.TCMS.Anywhere.Testing.E2ETest.TestFramework.Pages.Cases.Detail
{
    public class AssetData
    {
        public string Id { get; set; }
        public string Number { get; set; }
        public string CornerTagText { get; set; }
        public string CornerTagColor { get; set; }
        public string Name { get; set; }
        public string FADate{ get; set; }
        public string Type { get; set; }
        public string ValueType { get; set; }
        public string CodeLabel { get; set; }
        public string Code { get; set; }
        public string PetitionLabel { get; set; }
        public string Petition { get; set; }
        public string NetValueLabel { get; set; }
        public string NetValue { get; set; }
        public string AbandonedLabel { get; set; }
        public string Abandoned { get; set; }
        public string SalesLabel { get; set; }
        public string Sales { get; set; }
        public string RemainingLabel { get; set; }
        public string Remaining { get; set; }
        public string TrusteeLabel { get; set; }
        public string Trustee { get; set; }
        public string LiensLabel { get; set; }
        public string Liens { get; set; }
        public string ExemptionsLabel { get; set; }
        public string Exemptions { get; set; }
        public string Form1NoteLabel { get; set; }
        public string Form1Note { get; set; }
        public object FADateColor { get; internal set; }
        public object PetitionPosition { get; internal set; }
        public object NetValuePosition { get; internal set; }
        public object AbandonedPosition { get; internal set; }
        public object SalesPosition { get; internal set; }
        public object RemainingPosition { get; internal set; }
        public string FADateLabel { get; internal set; }
    }
}