using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using MySql.Data.EntityFramework;

namespace CFI_App.Models
{
    [DbConfigurationType(typeof(MySql.Data.Entity.MySqlEFConfiguration))]
    public class DatabaseContext : DbContext
    {
        public DatabaseContext() : base("DBConnection")
        {

        }
        public DbSet<Subjects> Subjects { get; set; }
        public DbSet<CRNDetail> CRNDetail { get; set; }
        public DbSet<Campus> Campus { get; set; }
        public DbSet<Subject> Subject { get; set; }
        public DbSet<DayOfWeek> DayOfWeek { get; set; }
        public DbSet<Lecturer> Lecturer { get; set; }
    }

}