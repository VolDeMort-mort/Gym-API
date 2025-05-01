using Data;

namespace DataAccess.Entities
{
    public class Training
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Category { get; set; }

        // Foreign Key for Coach
        public int CoachId { get; set; }
        public Coach Coach { get; set; }

        // Foreign Key for Hall
        public int HallId { get; set; }
        public Hall Hall { get; set; }

        public DateTime Date { get; set; }
        public int Duration { get; set; }
        public int MaxParticipants { get; set; }

        // Navigation properties
        public ICollection<TrainingRecord>? TrainingRecords { get; set; }
        public ICollection<Schedule>? Schedules { get; set; }

        public override string ToString()
        {
            return $"Training: {Id}, Name: {Name}, Category: {Category}, Coach: {Coach?.Name}, Hall: {Hall?.Number}, Date: {Date}, Duration: {Duration} min, MaxParticipants: {MaxParticipants}";
        }
    }
}
