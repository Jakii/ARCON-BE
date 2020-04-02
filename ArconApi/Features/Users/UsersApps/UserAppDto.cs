using System;
namespace ArconApi.Features.Users.UsersApps{
    public class UserAppDto{
        public int UserId {get; set;} 
        public string UserName { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public DateTime BirthDate { get; set; }
        public bool IsActive { get; set; }
    }
}