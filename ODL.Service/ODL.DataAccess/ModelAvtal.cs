namespace ODL.DataAccess
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class ModelAvtal : DbContext
    {
        public ModelAvtal()
            : base("name=ModelAvtal")
        {
        }

        public virtual DbSet<Avtal> Avtal { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Avtal>()
                .Property(e => e.Avtalskod)
                .IsUnicode(false);

            modelBuilder.Entity<Avtal>()
                .Property(e => e.Avtalstext)
                .IsUnicode(false);

            modelBuilder.Entity<Avtal>()
                .Property(e => e.DeltidFranvaro)
                .IsFixedLength();

            modelBuilder.Entity<Avtal>()
                .Property(e => e.SjukP)
                .IsFixedLength();

            modelBuilder.Entity<Avtal>()
                .Property(e => e.LoneTyp)
                .IsFixedLength();
        }
    }
}
