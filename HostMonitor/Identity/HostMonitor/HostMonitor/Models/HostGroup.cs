namespace HostMonitor.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("HostGroup")]
    public partial class HostGroup
    {
        [Key]
        public int groupId { get; set; }

        [StringLength(50)]
        public string groupName { get; set; }

        [StringLength(150)]
        public string groupDescription { get; set; }

        [StringLength(150)]
        public string groupIdentity { get; set; }
    }
}
