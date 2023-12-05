using OCS.Core.Model.Course;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OCS.Persistance.DatabaseFile
{
    public class DB : DbContext
    {
        public DbSet<Course> Courses { get; set; }
    }
}
