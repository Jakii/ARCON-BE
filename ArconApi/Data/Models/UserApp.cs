using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ArconApi.Data.Models
{
    public class UserApp{
        [Key]
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public DateTime BirthDate { get; set; }
        public bool IsActive { get; set; }
        public ICollection<UserProfile> Profiles { get; set; }

    }
}