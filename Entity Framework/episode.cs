namespace Entity_Framework
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("episode")]
    public partial class episode
    {
        public int id { get; set; }

        [Column("episode")]
        public int episode1 { get; set; }

        [Required]
        [StringLength(45)]
        public string name { get; set; }

        [Column(TypeName = "date")]
        public DateTime dateOfRelease { get; set; }

        public int source_id { get; set; }

        public int season_id { get; set; }

        public virtual season season { get; set; }

        public virtual source source { get; set; }
    }
}
