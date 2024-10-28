using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class ProgramsPatients:DbContext
    {
        public ProgramsPatients(DbContextOptions<ProgramsPatients> options) : base(options)
        {

        }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Lend> Lends { get; set; }
        public DbSet<Programs> Programs { get; set; }
        public DbSet<Users> Users { get; set; }

    }
}
