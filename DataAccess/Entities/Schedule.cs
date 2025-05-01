using Data;

namespace DataAccess.Entities
{
    public class Schedule
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public DateTime Time { get; set; }

        // Foreign Keys
        public int TrainingId { get; set; }
        public Training Training { get; set; }

        public int CoachId { get; set; }
        public Coach Coach { get; set; }

        public int HallId { get; set; }
        public Hall Hall { get; set; }

        public int AvailableSpots { get; set; }

        public override string ToString()
        {
            return $"Schedule: {Id}, Date: {Date.ToShortDateString()}, Time: {Time.ToShortTimeString()}, Training: {Training?.Name}, Coach: {Coach?.Name}, Hall: {Hall?.Number}, Available Spots: {AvailableSpots}";
        }
    }
}
