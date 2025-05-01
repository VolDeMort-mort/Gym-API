using Data;

namespace DataAccess.Entities
{
    public class Coach
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Specialization { get; set; }
        public int Experience { get; set; }
        public string Schedule { get; set; }
        public double Rating { get; set; }

        // Navigation property - One-to-Many relationship with Schedule
        public ICollection<Schedule>? Schedules { get; set; }

        public override string ToString()
        {
            return $"Coach: {Id}, Name: {Name}, Specialization: {Specialization}, Experience: {Experience} years, Schedule: {Schedule}, Rating: {Rating}";
        }
    }
}
