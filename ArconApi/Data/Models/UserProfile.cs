using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ArconApi.Data.Models
{
    public class UserProfile
    {
        [Key]
        public int UserProfileId { get; set; }
        
        [ForeignKey("Rol")]
        public int RolId { get; set; }

        [ForeignKey("UserApp")]
        public int UserAppId { get; set; }

        public bool IsActive { get; set; }
        
        public string Name { get; set; }
       
        public Rol Rol { get; set; }
        public UserApp UserApp { get; set; }
        public ICollection<Goal> Goals { get; set; }
      
        internal void SetRolId(int rolID)
        {
            this.RolId=rolID;
        }
        internal void SetName(string name)
        {
            this.Name=name;
        }
        internal void SetIsActive(bool isActive)
        {
            this.IsActive=isActive;
        }
        public sealed class Builder 
        {
            private readonly UserProfile _profile;
            public Builder(string name, int rolId, bool statusId, int userId)
            {
                _profile = new UserProfile 
                {
                Name=name,
                RolId=rolId,
                IsActive=statusId,
                UserAppId=userId
                };
            
            }
            public UserProfile Build(){
                return this._profile;
            }
        }
    }
}
