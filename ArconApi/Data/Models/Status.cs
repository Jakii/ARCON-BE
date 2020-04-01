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
        public ICollection<Goal> Goals { get; set; }

    }
}