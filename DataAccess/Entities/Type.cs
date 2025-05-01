using Data;

namespace DataAccess.Entities
{
    public class UserType
    {
        public int Id { get; set; }
        public string Name { get; set; }

        // Navigation property - One-to-Many (Users)
        public ICollection<User>? Users { get; set; }

        public override string ToString()
        {
            return $"UserType: {Id}, Name: {Name}";
        }
    }
}
