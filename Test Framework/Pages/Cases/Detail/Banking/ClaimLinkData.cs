using System;

namespace Epiq.ETS.TCMS.Anywhere.Testing.E2ETest.Test_Framework.Pages.Cases.Detail.Banking
{
    public class ClaimLinkData
    {
        public string Amount { get; internal set; }
        public decimal BalanceAmount { get; set; }
        public string Code { get; set; }
        public string Description { get; set; }
        public string Id { get; set; }
        public string Name { get; set; }
        public bool NonCompensable { get; set; }
        public string Number { get; set; }
        public string OriginalClaimCode { get; set; }
        public Decimal PaidAmount { get; set; }

    }
}