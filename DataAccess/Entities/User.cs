using Data;

namespace DataAccess.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }

        // Foreign Key for UserType
        public int UserTypeId { get; set; }
        public UserType? UserType { get; set; }

        public DateTime RegistrationDate { get; set; }
        public string SubscriptionStatus { get; set; }

        // Navigation properties
        public ICollection<TrainingRecord>? TrainingRecords { get; set; }
        public ICollection<Payment>? Payments { get; set; }

        public override string ToString()
        {
            return $"User: {Id}, Name: {Name}, Email: {Email}, Phone: {Phone}, UserType: {UserType?.Name}, RegistrationDate: {RegistrationDate}, SubscriptionStatus: {SubscriptionStatus}";
        }
    }
}
