namespace ChatServidor
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Hosts
    {
        public int id { get; set; }

        [Required]
        [StringLength(15)]
        public string ip { get; set; }

        [Required]
        [StringLength(50)]
        public string hostname { get; set; }

        [Required]
        [StringLength(50)]
        public string lastuser { get; set; }

        public int conected { get; set; }
    }
}
