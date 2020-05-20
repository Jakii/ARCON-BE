using System;

namespace ArconApi.Features.Goals.GoalDetails
{
    public class GoalDetailDto
    {
        public int GoalDetailId { get; set; }
        public int GoalId { get; set; }
        public int ActivityId { get; set; }
        public bool IsComplete { get; set; }
        public DateTime TransactionDate { get; set; }
    }
}