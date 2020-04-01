
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ArconApi.Data.Models
{
    public class GoalDetail{
         [Key]
        public int GoalDetailId { get; set; }
        
        [ForeignKey("Goal")]
        public int GoalId { get; set; }
        
        [ForeignKey("Activity")]
        public int ActivityId { get; set; }
        public bool IsComplete { get; set; }
        public DateTime TransactionDate { get; set; }
        public Goal Goal { get; set; }
        public Activity Activity { get; set; }
    }
}