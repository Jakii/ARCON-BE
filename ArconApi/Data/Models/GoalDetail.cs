
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ArconApi.Data.Models
{
    public class GoalDetail
    {
        
        [Key]
        public int GoalDetailId { get; set; }
        
        [ForeignKey("Goal")]
        public int GoalId { get; set; }
        
        [ForeignKey("Activity")]
        public int ActivityId { get; set; }
        public bool IsComplete { get; set; }
        public DateTime TransactionDate { get; set; }
        public Goal Goal { get; set; }
        public GoalActivity Activity { get; set; }

        internal void SetIsComplete(bool isComplete)
        {
            this.IsComplete=isComplete;
        }
         internal void SetTransactionDate(DateTime transactionDate)
        {
            this.TransactionDate=transactionDate;
        }
        public sealed class Builder 
        {
            private readonly GoalDetail _goalDetail;
            public Builder(int goalId, int activityId, bool isComplete, 
            DateTime transactionDate)
            {
                _goalDetail = new GoalDetail
                {
                    GoalId=goalId,
                    ActivityId=activityId,
                    TransactionDate=transactionDate,
                    IsComplete=isComplete
                };
            }
            public GoalDetail Build()
            {
                return _goalDetail;
            }
        }
    }
}