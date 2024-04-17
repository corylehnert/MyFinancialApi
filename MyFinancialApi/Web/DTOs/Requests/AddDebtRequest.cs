namespace MyFinancialApi.Web.DTOs.Requests
{
    public class AddDebtRequest
    {
        public int  Id { get; set; }

        public float Amount { get; set; }

        public string Description { get; set; }

        public string Frequency { get; set; }

        public DateTime DateOfOccurrence { get; set; }

        public DateTime NextPaymentDate { get; set; }

        public DateTime LastPaymentDate { get; set; }

        public string Owner { get; set; }
    }
}
