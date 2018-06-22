namespace Entity_Framework
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("movie")]
    public partial class movie
    {
        public int id { get; set; }

        [Column(TypeName = "date")]
        public DateTime dateOfRelease { get; set; }

        public int source_id { get; set; }

        public int watchObject_id { get; set; }

        public virtual source source { get; set; }

        public virtual watchObject watchObject { get; set; }
    }
}
