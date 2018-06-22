namespace Entity_Framework
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("watched")]
    public partial class watched
    {
        public int id { get; set; }

        public TimeSpan currentTime { get; set; }

        public int profile_id { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime date { get; set; }

        public int source_id { get; set; }

        public int? subtitles_id { get; set; }

        public int audio_id { get; set; }

        public virtual audio audio { get; set; }

        public virtual profile profile { get; set; }

        public virtual source source { get; set; }

        public virtual subtitle subtitle { get; set; }
    }
}
