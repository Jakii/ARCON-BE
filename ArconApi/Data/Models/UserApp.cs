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

        internal void SetName(string name)
        {
            this.Name=name;
        }
         internal void SetEmail(string email)
        {
            this.Email=email;
        }
        internal void SetBirthDate(DateTime birthDate)
        {
            this.BirthDate=birthDate;
        }
         internal void SetIsActive(bool isActive)
        {
            this.IsActive=isActive;
        }
        public sealed class Builder 
        {
            private readonly UserApp _userapp;
            public Builder(string userName, string name, bool isActive)
            {
                _userapp= new UserApp 
                {
                    UserName=userName,
                    Name=name,
                    IsActive=isActive
                };
            }

            public Builder WhithEmail(string email)
            {
                _userapp.Email=email;
                return this;
            }
            public Builder WhithBirthDate(DateTime birthDate)
            {
                _userapp.BirthDate=birthDate;
                return this;
            }

            public UserApp Build()
            {
                return _userapp;
            }
        }    
    }
}