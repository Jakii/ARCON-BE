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
        public int PerfilId { get; set; }

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


    }
  
}