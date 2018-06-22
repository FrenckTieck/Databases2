namespace Entity_Framework
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class netflix : DbContext
    {
        public netflix()
        {
        }

        public virtual DbSet<acount> acounts { get; set; }
        public virtual DbSet<audio> audios { get; set; }
        public virtual DbSet<blocked> blockeds { get; set; }
        public virtual DbSet<episode> episodes { get; set; }
        public virtual DbSet<genre> genres { get; set; }
        public virtual DbSet<indicator> indicators { get; set; }
        public virtual DbSet<linkedAcount> linkedAcounts { get; set; }
        public virtual DbSet<membership> memberships { get; set; }
        public virtual DbSet<movie> movies { get; set; }
        public virtual DbSet<passwordReset> passwordResets { get; set; }
        public virtual DbSet<profile> profiles { get; set; }
        public virtual DbSet<quality> qualities { get; set; }
        public virtual DbSet<season> seasons { get; set; }
        public virtual DbSet<serie> series { get; set; }
        public virtual DbSet<source> sources { get; set; }
        public virtual DbSet<subtitle> subtitles { get; set; }
        public virtual DbSet<type_profile> type_profile { get; set; }
        public virtual DbSet<type> types { get; set; }
        public virtual DbSet<watched> watcheds { get; set; }
        public virtual DbSet<watchlist> watchlists { get; set; }
        public virtual DbSet<watchObject> watchObjects { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<acount>()
                .Property(e => e.email)
                .IsUnicode(false);

            modelBuilder.Entity<acount>()
                .Property(e => e.password)
                .IsUnicode(false);

            modelBuilder.Entity<acount>()
                .Property(e => e.joinDate)
                .HasPrecision(0);

            modelBuilder.Entity<acount>()
                .HasMany(e => e.blockeds)
                .WithRequired(e => e.acount)
                .HasForeignKey(e => e.acount_id);

            modelBuilder.Entity<acount>()
                .HasMany(e => e.linkedAcounts)
                .WithRequired(e => e.acount)
                .HasForeignKey(e => e.acount_id1);

            modelBuilder.Entity<acount>()
                .HasMany(e => e.passwordResets)
                .WithRequired(e => e.acount)
                .HasForeignKey(e => e.acount_id);

            modelBuilder.Entity<acount>()
                .HasMany(e => e.profiles)
                .WithRequired(e => e.acount)
                .HasForeignKey(e => e.acount_id);

            modelBuilder.Entity<audio>()
                .Property(e => e.link)
                .IsUnicode(false);

            modelBuilder.Entity<audio>()
                .Property(e => e.language)
                .IsUnicode(false);

            modelBuilder.Entity<audio>()
                .HasMany(e => e.watcheds)
                .WithRequired(e => e.audio)
                .HasForeignKey(e => e.audio_id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<blocked>()
                .Property(e => e.date)
                .HasPrecision(0);

            modelBuilder.Entity<episode>()
                .Property(e => e.name)
                .IsUnicode(false);

            modelBuilder.Entity<genre>()
                .Property(e => e.name)
                .IsUnicode(false);

            modelBuilder.Entity<genre>()
                .HasMany(e => e.profiles)
                .WithMany(e => e.genres)
                .Map(m => m.ToTable("genre_profile").MapLeftKey("genres_id"));

            modelBuilder.Entity<indicator>()
                .Property(e => e.indicators)
                .IsUnicode(false);

            modelBuilder.Entity<indicator>()
                .HasMany(e => e.profiles)
                .WithMany(e => e.indicators)
                .Map(m => m.ToTable("indicator_profile").MapLeftKey("indicators_id"));

            modelBuilder.Entity<membership>()
                .Property(e => e.membership1)
                .IsUnicode(false);

            modelBuilder.Entity<membership>()
                .HasMany(e => e.acounts)
                .WithRequired(e => e.membership)
                .HasForeignKey(e => e.membership_id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<passwordReset>()
                .Property(e => e.date)
                .HasPrecision(0);

            modelBuilder.Entity<passwordReset>()
                .Property(e => e.link)
                .IsUnicode(false);

            modelBuilder.Entity<profile>()
                .Property(e => e.name)
                .IsUnicode(false);

            modelBuilder.Entity<profile>()
                .Property(e => e.picture)
                .IsUnicode(false);

            modelBuilder.Entity<profile>()
                .Property(e => e.language)
                .IsUnicode(false);

            modelBuilder.Entity<profile>()
                .HasMany(e => e.watcheds)
                .WithRequired(e => e.profile)
                .HasForeignKey(e => e.profile_id);

            modelBuilder.Entity<profile>()
                .HasMany(e => e.watchlists)
                .WithRequired(e => e.profile)
                .HasForeignKey(e => e.profile_id);

            modelBuilder.Entity<quality>()
                .Property(e => e.quality1)
                .IsUnicode(false);

            modelBuilder.Entity<quality>()
                .HasMany(e => e.watchObjects)
                .WithRequired(e => e.quality)
                .HasForeignKey(e => e.quality_id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<season>()
                .HasMany(e => e.episodes)
                .WithRequired(e => e.season)
                .HasForeignKey(e => e.season_id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<serie>()
                .HasMany(e => e.seasons)
                .WithRequired(e => e.serie)
                .HasForeignKey(e => e.serie_id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<source>()
                .Property(e => e.duration)
                .HasPrecision(0);

            modelBuilder.Entity<source>()
                .Property(e => e.link)
                .IsUnicode(false);

            modelBuilder.Entity<source>()
                .HasMany(e => e.audios)
                .WithRequired(e => e.source)
                .HasForeignKey(e => e.source_id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<source>()
                .HasMany(e => e.episodes)
                .WithRequired(e => e.source)
                .HasForeignKey(e => e.source_id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<source>()
                .HasMany(e => e.movies)
                .WithRequired(e => e.source)
                .HasForeignKey(e => e.source_id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<source>()
                .HasMany(e => e.subtitles)
                .WithRequired(e => e.source)
                .HasForeignKey(e => e.source_id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<source>()
                .HasMany(e => e.watcheds)
                .WithRequired(e => e.source)
                .HasForeignKey(e => e.source_id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<subtitle>()
                .Property(e => e.link)
                .IsUnicode(false);

            modelBuilder.Entity<subtitle>()
                .Property(e => e.language)
                .IsUnicode(false);

            modelBuilder.Entity<subtitle>()
                .HasMany(e => e.watcheds)
                .WithOptional(e => e.subtitle)
                .HasForeignKey(e => e.subtitles_id);

            modelBuilder.Entity<type>()
                .Property(e => e.type1)
                .IsUnicode(false);

            modelBuilder.Entity<type>()
                .HasMany(e => e.type_profile)
                .WithRequired(e => e.type)
                .HasForeignKey(e => e.types_id);

            modelBuilder.Entity<watched>()
                .Property(e => e.currentTime)
                .HasPrecision(0);

            modelBuilder.Entity<watched>()
                .Property(e => e.date)
                .HasPrecision(0);

            modelBuilder.Entity<watchlist>()
                .Property(e => e.name)
                .IsUnicode(false);

            modelBuilder.Entity<watchlist>()
                .HasMany(e => e.watchObjects)
                .WithMany(e => e.watchlists)
                .Map(m => m.ToTable("watchlist_watchObject"));

            modelBuilder.Entity<watchObject>()
                .Property(e => e.name)
                .IsUnicode(false);

            modelBuilder.Entity<watchObject>()
                .Property(e => e.picture)
                .IsUnicode(false);

            modelBuilder.Entity<watchObject>()
                .HasMany(e => e.movies)
                .WithRequired(e => e.watchObject)
                .HasForeignKey(e => e.watchObject_id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<watchObject>()
                .HasMany(e => e.series)
                .WithRequired(e => e.watchObject)
                .HasForeignKey(e => e.watchObject_id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<watchObject>()
                .HasMany(e => e.genres)
                .WithMany(e => e.watchObjects)
                .Map(m => m.ToTable("genre_watchObject").MapRightKey("genres_id"));

            modelBuilder.Entity<watchObject>()
                .HasMany(e => e.indicators)
                .WithMany(e => e.watchObjects)
                .Map(m => m.ToTable("indicator_watchObject").MapRightKey("indicators_id"));
        }
    }
}
