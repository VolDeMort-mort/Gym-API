using Data;

namespace DataAccess.Entities
{
    public class Subscription
    {
        public int Id { get; set; }
        public string UserType { get; set; }
        public decimal Price { get; set; }
        public int DurationInDays { get; set; }
        public string AvailableServices { get; set; }

        public override string ToString()
        {
            return $"Subscription: {Id}, UserType: {UserType}, Price: {Price}, Duration: {DurationInDays} days, Available Services: {AvailableServices}";
        }
    }
}
