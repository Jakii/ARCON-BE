using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ArconApi.Data.Models
{
    public class Status
    {

        [Key]
        public int StatusId { get; set; }
        public string StatusName { get; set; }
        public string Description { get; set; }
        public string Description2 { get; set; }
        public ICollection<Goal> Goals { get; set; }

        internal void SetStatusName(string statusName)
        {
            this.StatusName=statusName;
        }
        internal void SetDescription(string description)
        {
            this.Description=description;
        }
        public sealed class Builder
        {
            private readonly Status _status;
            public Builder (string statusName, string description)
            {
                _status= new Status 
                {
                    StatusName=statusName,
                    Description=description
                };
            }
            public Status Build(){
                return _status;
            }
        }

    }
}