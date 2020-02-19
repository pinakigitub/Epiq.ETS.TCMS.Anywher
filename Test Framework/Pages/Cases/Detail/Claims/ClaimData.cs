using System;

namespace Epiq.ETS.TCMS.Anywhere.Testing.E2ETest.Test_Framework.Steps.Cases.Detail
{
    public class ClaimData
    {

        //1st row values
        public int Id { get; set; }
        public string ClaimNumber { get; set; }
        public string CreditorName{ get; set; }
        public string Status { get; set; }
        public string StatusColor { get; set; }
        public string Class { get; set; }
        public string Category { get; set; }
        public string CornerTagColor { get; set; }
        public string CornerTagLetter { get; set; }
        public string CircleIndicatorColor { get; set; }

        //2nd row labels
        public string CodeLabel { get; set; }
        public string PaySequenceLabel { get; set; }
        public string ClaimedLabel { get; set; }
        public string AllowedLabel { get; set; }
        public string PaidLabel { get; set; }
        public string ReservedLabel { get; set; }
        public string InterestLabel { get; set; }
        public string BalanceLabel { get; set; }

        //2nd row values
        public string Code { get; set; }
        public string PaySequence { get; set; }
        public string Claimed { get; set; }
        public string Allowed { get; set; }
        public string Paid { get; set; }
        public string Reserved { get; set; }
        public string Interest { get; set; }
        public string Balance { get; set; }

    }
}