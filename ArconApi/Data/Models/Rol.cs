using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ArconApi.Data.Models
{
    public class Rol{
        [Key]
        public int RolId { get; set; }
        public string Name { get; set; }
        public ICollection<UserProfile> Profiles { get; set; }
    }
}