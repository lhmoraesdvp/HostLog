namespace HostMonitor.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Host")]
    public partial class Host
    {
        public int hostId { get; set; }

        [StringLength(50)]
        public string hostName { get; set; }

        [StringLength(50)]
        public string hostIp { get; set; }

        public int hotDevice { get; set; }

        [StringLength(50)]
        public string hostSo { get; set; }

        [StringLength(50)]
        public string hostComunication { get; set; }

        [StringLength(50)]
        public string hostUser { get; set; }

        public int hostCc { get; set; }

        [StringLength(50)]
        public string hostSerial { get; set; }

        [StringLength(50)]
        public string hostHdMemory { get; set; }

        [StringLength(50)]
        public string hostHdMemoryFree { get; set; }

        [StringLength(50)]
        public string hostRam { get; set; }

        [StringLength(50)]
        public string hostProcessador { get; set; }

        [StringLength(50)]
        public string hostState { get; set; }

        [StringLength(50)]
        public string hostMac { get; set; }

        [StringLength(50)]
        public string hostCountry { get; set; }

        [StringLength(50)]
        public string hostLocal { get; set; }
    }
}
