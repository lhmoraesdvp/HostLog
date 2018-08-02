namespace ChatServidor.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("centroDeCusto")]
    public partial class centroDeCusto
    {
        [Key]
        public int ccId { get; set; }

        [StringLength(50)]
        public string ccName { get; set; }

        public int? ccIdentity { get; set; }

        [StringLength(150)]
        public string ccDescription { get; set; }

        [StringLength(50)]
        public string ccState { get; set; }

        [StringLength(50)]
        public string ccCity { get; set; }

        public long? ccPostalCode { get; set; }

        [StringLength(50)]
        public string ccRegion { get; set; }

        public int? ccNumber { get; set; }

        public int ccSubGroup { get; set; }
    }
}
