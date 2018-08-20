namespace HostMonitor.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("SubGroup")]
    public partial class SubGroup
    {
        [Key]
        public int subgId { get; set; }

        [StringLength(50)]
        public string subgroupName { get; set; }

        [StringLength(150)]
        public string subgroupDescription { get; set; }

        [StringLength(150)]
        public string subgroupIdentity { get; set; }

        public int sGroup { get; set; }
    }
}
