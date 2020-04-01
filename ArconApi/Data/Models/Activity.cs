using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ArconApi.Data.Models{
    public class Activity{
        [Key]
        public int ActivityId { get; set; }
        public string  Name { get; set; }

        public ICollection<GoalDetail> GoalDetail { get; set; }

    }
}