using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ArconApi.Data.Models{
    
    public class Goal
    {
        [Key]
        public int GoalId { get; set; }
        
        [ForeignKey("UserProfile")]
        public int ProfileId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        [Column(TypeName = "decimal(9, 2)")]
        public decimal Amount { get; set; }
        [Column(TypeName = "decimal(9, 2)")]
        public decimal Progress { get; set; }

        [ForeignKey("Status")]
        public int StatusId { get; set; }
        public DateTime TransactionDate { get; set; }
        public DateTime UpdateDate { get; set; }
        public DateTime CompleteDate { get; set; }
        public DateTime TransferDate { get; set; }

        public UserProfile UserProfile { get; set; }
        public Status Status { get; set; }
        public ICollection<GoalDetail> GoalDetail { get; set; }

        internal void SetTitle(string title)
        {
            this.Title=title;
        }
        internal void SetDescription(string description)
        {
            this.Description=description;
        }
        internal void SetAmount(decimal amount){
            this.Amount=amount;
        }
        internal void SetProgress(decimal progress)
        {
            this.Progress=progress;
        }
        internal void SetStatusId(int statusId)
        {
            this.StatusId=statusId;
        }
        internal void SetTransactionDate(DateTime transactionDate)
        {
            this.TransactionDate=transactionDate;
        }
        internal void SetUpdateDate(DateTime updateDate)
        {
            this.UpdateDate=updateDate;
        }
        internal void SetCompleteDate(DateTime completeDate)
        {
            this.CompleteDate=completeDate;
        }
        internal void SetTransferDate(DateTime transferDate)
        {
            this.TransferDate=transferDate;
        }
        public sealed class Builder
        {
            private readonly Goal _goal;
            public Builder(int profileId, string title, decimal amount, decimal progress)
            {
                _goal= new Goal
                {
                    ProfileId=profileId,
                    Title=title,
                    Amount=amount,
                    Progress=progress
                };
            }
            public Builder WithDescription(string description)
            {
                _goal.Description=description;
                return this;
            }
            public Builder WithStatusId(int statusId)
            {
                _goal.StatusId=statusId;
                return this;
            }
            public Builder WithTransactionDate(DateTime transactionDate)
            {
                _goal.TransactionDate=transactionDate;
                return this;
            }
            public Builder WithUpdateDate(DateTime updateDate)
            {
                _goal.UpdateDate=updateDate;
                return this;
            }
            public Builder WithCompleteDate(DateTime completeDate)
            {
                _goal.CompleteDate=completeDate;
                return this;
            }
           public Builder WithTransferDate(DateTime transferDate)
           {
               _goal.TransferDate=transferDate;
               return this;
           }
           public Goal Build(){
               return _goal;
           }
        }
    }
  
}