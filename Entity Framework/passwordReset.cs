namespace Entity_Framework

{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("passwordReset")]
    public partial class passwordReset
    {
        public int id { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime date { get; set; }

        [Required]
        [StringLength(45)]
        public string link { get; set; }

        public int acount_id { get; set; }

        public virtual acount acount { get; set; }
    }
}
