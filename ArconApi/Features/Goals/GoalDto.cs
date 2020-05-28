using System;

namespace ArconApi.Features.Goals
{
    public class GoalDto
    {
        public int GoalId { get; set; }
        public int ProfileId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public decimal Amount { get; set; }
        public decimal Progress { get; set; }
        public int StatusId { get; set; }
        public DateTime TransactionDate { get; set; }
        public DateTime UpdateDate { get; set; }
        public DateTime CompleteDate { get; set; }
        public DateTime TransferDate { get; set; }
        public byte[] Image { get; set; }
    }
}