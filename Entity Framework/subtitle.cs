namespace Entity_Framework
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class subtitle
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public subtitle()
        {
            watcheds = new HashSet<watched>();
        }

        public int id { get; set; }

        public int source_id { get; set; }

        [Required]
        [StringLength(45)]
        public string link { get; set; }

        [Required]
        [StringLength(45)]
        public string language { get; set; }

        public virtual source source { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<watched> watcheds { get; set; }
    }
}
