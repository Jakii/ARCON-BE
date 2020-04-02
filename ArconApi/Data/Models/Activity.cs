using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ArconApi.Data.Models{
    public class Activity{
        [Key]
        public int ActivityId { get; set; }
        public string  Name { get; set; }
        public ICollection<GoalDetail> GoalDetail { get; set; }
        internal void SetName(string name)
        {
            this.Name=name;
        }
        public sealed class Buider
        {
            private readonly Activity _activity;
            public Buider(string name)
            {
                _activity= new Activity{
                    Name=name
                };              
            }
            public Activity Build(){
                return _activity;
            }
            
        }
    }
}