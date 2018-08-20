namespace HostMonitor.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class Db : DbContext
    {
        public Db()
            : base("name=Db")
        {
        }

        public virtual DbSet<centroDeCusto> centroDeCusto { get; set; }
        public virtual DbSet<Devices> Devices { get; set; }
        public virtual DbSet<Host> Host { get; set; }
        public virtual DbSet<HostGroup> HostGroup { get; set; }
        public virtual DbSet<SubGroup> SubGroup { get; set; }
        public virtual DbSet<sysdiagrams> sysdiagrams { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}
