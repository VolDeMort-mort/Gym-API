using Data;

namespace DataAccess.Entities
{
    public class Payment
    {
        public int Id { get; set; }

        // Foreign Key for User
        public int UserId { get; set; }
        public User User { get; set; }

        public decimal Amount { get; set; }
        public string UserType { get; set; }
        public DateTime Date { get; set; }

        public override string ToString()
        {
            return $"Payment: {Id}, User: {User?.Name}, Amount: {Amount}, UserType: {UserType}, Date: {Date.ToShortDateString()}";
        }
    }
}
