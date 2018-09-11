namespace HostMonitor.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Menssagem")]
    public partial class Menssagem
    {
        [Key]
        public int idMenssagem { get; set; }

        public int idGrupo { get; set; }

        public int? idSubgrupo { get; set; }

        public int? idCentro { get; set; }

        [StringLength(50)]
        public string usuario { get; set; }

        [StringLength(50)]
        public string dataHora { get; set; }

        [Column("menssagem")]
        [StringLength(350)]
        public string menssagem1 { get; set; }

        public int? status { get; set; }

        [StringLength(50)]
        public string c0 { get; set; }

        [StringLength(50)]
        public string c01 { get; set; }

        [StringLength(50)]
        public string c02 { get; set; }

        public int? i0 { get; set; }

        public int? i01 { get; set; }

        public int? i02 { get; set; }


        public List<HostGroup> groups = new List<HostGroup>();
        public List<SubGroup> subgrupos = new List<SubGroup>();
        public List<centroDeCusto> centros = new List<centroDeCusto>();
    }
}
