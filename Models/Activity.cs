using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessTracker.Models
{
    public class Activity
    {
        [PrimaryKey, AutoIncrement]
        public int ActivityId { get; set; }
        public int UserId { get; set; }
        public string ActivityName { get; set; }
        public string Description { get; set; }
        public double Duration { get; set; }
        public double CaloriesBurned {  get; set; } 
        public DateTime Date {  get; set; }
    }
}
