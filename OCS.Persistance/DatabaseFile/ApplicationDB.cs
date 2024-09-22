using OCS.Core.Model.CourseModel;
using OCS.Core.Model.SeminarModel;
using OCS.Core.Model.SignUpModel;
using OCS.Core.Model.TrainerModel;
using OCS.Core.Model.VideoModel;
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
        public DbSet<Videos> Videos { get; set; }
    }
}
