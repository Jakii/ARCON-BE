using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ArconApi.Data.Models{
    public class GoalActivity{
        [Key]
        public int ActivityId { get; set; }
        public string  Name { get; set; }
        public ICollection<GoalDetail> GoalDetail { get; set; }
        internal void SetName(string name)
        {
            this.Name=name;
        }
        public sealed class Builder
        {
            private readonly GoalActivity _activity;
            public Builder(string name)
            {
                _activity= new GoalActivity{
                    Name=name
                };              
            }
            public GoalActivity Build(){
                return _activity;
            }
            
        }
    }
}