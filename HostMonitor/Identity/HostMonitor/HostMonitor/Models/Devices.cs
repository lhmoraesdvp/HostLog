namespace HostMonitor.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Devices
    {
        [Key]
        public int deviceId { get; set; }

        [StringLength(50)]
        public string deviceType { get; set; }

        [StringLength(50)]
        public string deviceName { get; set; }
    }
}
