namespace Entity_Framework
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("blocked")]
    public partial class blocked
    {
        public int id { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime date { get; set; }

        public short active { get; set; }

        public int acount_id { get; set; }

        public virtual acount acount { get; set; }
    }
}
