using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using TextThePeople.Models;

namespace TextThePeople.DAL
{
    public class TextThePeopleContext : DbContext
    {
        public DbSet<UserProfile> UserProfiles { get; set; }
        public DbSet<Logs> Logs { get; set; }
        public DbSet<Persons> Persons { get; set; }
    }
}