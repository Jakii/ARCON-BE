namespace ArconApi.Features.Users.UserProfiles
{
    public class UserProfileDto
    {
         public int UserProfileId {get; set;} 
         public int RolId {get; set;} 
         public int UserAppId {get; set;} 
         public string Name { get; set; }
         public bool IsActive { get; set; }

    }
}