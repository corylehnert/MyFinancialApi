namespace MyFinancialApi.Domain.DTOs
{
    public class DebtEntry
    {
        public int Id { get; set; }

        public float Amount { get; set; }

        public string Description { get; set; }

        public string Frequency { get; set; }

        public DateTime DateOfOccurrence { get; set; }

        public DateTime NextPaymentDate { get; set; }

        public DateTime LastPaymentDate { get; set; }

        /// <summary>
        /// Person who the has the pay the debt aka debtee
        /// </summary>
        public string Owner { get; set; }

        public DebtEntry(int id, float amount, string description, DateTime dateCreated, string frequency, DateTime nextPaymentDate, DateTime lastPaymentDate, string owner)
        {
            Id = id;
            Amount = amount;
            Description = description;
            DateOfOccurrence = dateCreated;
            Frequency = frequency;
            NextPaymentDate = nextPaymentDate;
            LastPaymentDate = lastPaymentDate;
            Owner = owner;
        }
    }
}
