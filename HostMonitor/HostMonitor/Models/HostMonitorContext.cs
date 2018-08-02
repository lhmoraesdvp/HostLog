using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace HostMonitor.Models
{
    public class HostMonitorContext : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx
    
        public HostMonitorContext() : base("name=HostMonitorContext")
        {
        }

        public System.Data.Entity.DbSet<HostMonitor.Models.HostGroup> HostGroups { get; set; }

        public System.Data.Entity.DbSet<HostMonitor.Models.SubGroup> SubGroups { get; set; }

        public System.Data.Entity.DbSet<HostMonitor.Models.centroDeCusto> centroDeCustoes { get; set; }

        public System.Data.Entity.DbSet<HostMonitor.Models.Devices> Devices { get; set; }

        public System.Data.Entity.DbSet<HostMonitor.Models.Host> Hosts { get; set; }
    }
}
