using Data;

namespace DataAccess.Entities
{
    public class Hall
    {
        public int Id { get; set; }
        public int Number { get; set; }
        public string Equipment { get; set; }
        public int Capacity { get; set; }
        public bool Availability { get; set; }

        // Navigation property - One-to-Many (Trainings & Schedules)
        public ICollection<Training>? Trainings { get; set; }
        public ICollection<Schedule>? Schedules { get; set; }

        public override string ToString()
        {
            return $"Hall: {Id}, Number: {Number}, Equipment: {Equipment}, Capacity: {Capacity}, Availability: {Availability}";
        }
    }
}
