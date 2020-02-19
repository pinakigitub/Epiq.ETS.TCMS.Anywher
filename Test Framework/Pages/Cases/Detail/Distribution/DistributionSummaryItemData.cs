using Epiq.ETS.TCMS.Anywhere.Testing.E2ETest.Test_Framework.Pages;

namespace Epiq.ETS.TCMS.Anywhere.Testing.E2ETest.Test_Framework.Steps.Cases.Detail
{
    public class DistributionSummaryItemData
    {
        public string DistributionName { get; set; }
        public bool DistributionNameEllipsis { get; set; }
        public string Status { get; set; }
        public string ModifiedPayment { get; set; }
        public object ModifiedPaymentLabel { get; set; }
        public string CalculatedPayment { get; set; }
        public object CalculatedPaymentLabel { get; set; }
        public string Difference { get; set; }
        public object DifferenceLabel { get; set; }
        public string UpdatedDate { get; set; }
        public object UpdatedDateLabel { get; set; }
        public string CardUIStyle { get; set; }
        
    }
}