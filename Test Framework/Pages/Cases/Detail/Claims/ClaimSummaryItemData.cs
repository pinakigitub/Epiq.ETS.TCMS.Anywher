using Epiq.ETS.TCMS.Anywhere.Testing.E2ETest.Test_Framework.Pages;

namespace Epiq.ETS.TCMS.Anywhere.Testing.E2ETest.Test_Framework.Steps.Cases.Detail
{
    public class ClaimSummaryItemData
    {
        public string Title { get; set; }
        public string BalanceLabel { get; set; }
        public string Balance { get; set; }
        public string ClaimedLabel { get; set; }
        public string Claimed { get; set; }
        public string PaidLabel { get; set; }
        public string Paid { get; set; }
        public string ReservedLabel { get; set; }
        public string Reserved { get; set; }
        public object BalanceTextColor { get; set; }
        public object ClaimedTextColor { get; set; }
        public object PaidTextColor { get; set; }
        public object ReservedTextColor { get; set; }
    }
}