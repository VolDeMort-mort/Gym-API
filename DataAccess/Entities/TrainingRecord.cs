using Data;

namespace DataAccess.Entities
{
    public class TrainingRecord
    {
        public int Id { get; set; }

        // Foreign Key for User (Client)
        public int ClientId { get; set; }
        public User Client { get; set; }

        // Foreign Key for Training
        public int TrainingId { get; set; }
        public Training Training { get; set; }

        public string Status { get; set; }

        public override string ToString()
        {
            return $"TrainingRecord: {Id}, Client: {Client?.Name}, Training: {Training?.Name}, Status: {Status}";
        }
    }
}
