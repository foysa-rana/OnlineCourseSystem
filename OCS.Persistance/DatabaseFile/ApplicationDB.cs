using OCS.Core.Model.Course;
using OCS.Core.Model.Seminar;
using OCS.Core.Model.SignUp;
using OCS.Core.Model.Trainer;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OCS.Persistance.DatabaseFile
{
    public class ApplicationDB : DbContext
    {
        public DbSet<Course> Courses { get; set; }
        public DbSet<Seminar> Seminars { get; set; }
        public DbSet<Trainer> Trainers { get; set; }
        public DbSet<UserSignUp> Users { get; set; }
    }
}
