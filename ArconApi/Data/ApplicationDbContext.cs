using System;
using System.Collections.Generic;
using System.Text;
using ArconApi.Data.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ArconApi.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {}
        public DbSet<Category> Categories { get; set;}
        public DbSet<Status> Statuses { get; set;}
        public DbSet<Rol> Rols { get; set;}
        public DbSet<UserApp> UsersApp { get; set;}
        public DbSet<UserProfile> UserProfiles { get; set;}
        public DbSet<GoalActivity> GoalActivities { get; set;}
        public DbSet<Goal> Goals { get; set;}
        public DbSet<GoalDetail> GoalDetails { get; set; }
        
    }
}
