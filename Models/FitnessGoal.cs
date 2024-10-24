using SQLite;

namespace FitnessTracker.Models
{
    public class FitnessGoal
    {
        [PrimaryKey, AutoIncrement]
        public int GoalId { get; set; }

        public int UserId { get; set; }  // Foreign key 

        public double TargetWeight { get; set; }

        public int WorkoutFrequencyPerWeek { get; set; }

        public DateTime GoalStartDate { get; set; }

        public DateTime GoalEndDate { get; set; }

        public string GoalDescription { get; set; }
    }

}
