using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ArconApi.Data.Models
{
    public class Rol{
        [Key]
        public int RolId { get; set; }
        public string Name { get; set; }
        public ICollection<UserProfile> Profiles { get; set; }
    
        internal void SetName(string name)
        {
            this.Name=name;
        }
        public sealed class Builder 
        {
            private readonly Rol _rol;
            public Builder(string name)
            {
                _rol= new Rol{
                    Name=name
                };
            }

            public Rol Build(){
                return _rol;
            }
        }
    }
}