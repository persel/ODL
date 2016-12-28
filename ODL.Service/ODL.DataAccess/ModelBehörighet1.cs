namespace ODL.DataAccess
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class ModelBehörighet1 : DbContext
    {
        public ModelBehörighet1()
            : base("name=ModelBehörighet1")
        {
        }

        public virtual DbSet<Anvandare> Anvandare { get; set; }
        public virtual DbSet<PersonVerksamhetsroll> PersonVerksamhetsroll { get; set; }
        public virtual DbSet<PersonVerksamhetsrollVerksamhetsdimensionvarde> PersonVerksamhetsrollVerksamhetsdimensionvarde { get; set; }
        public virtual DbSet<RelevantVerksamhetsdimension> RelevantVerksamhetsdimension { get; set; }
        public virtual DbSet<Systembegransning> Systembegransning { get; set; }
        public virtual DbSet<Verksamhetsroll> Verksamhetsroll { get; set; }
        public virtual DbSet<Person> Person { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PersonVerksamhetsroll>()
                .HasMany(e => e.PersonVerksamhetsrollVerksamhetsdimensionvarde)
                .WithRequired(e => e.PersonVerksamhetsroll)
                .HasForeignKey(e => e.PersonVerksamhetsrollFKId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<PersonVerksamhetsroll>()
                .HasMany(e => e.Systembegransning)
                .WithRequired(e => e.PersonVerksamhetsroll)
                .HasForeignKey(e => e.PersonVerksamhetsrollFKId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Verksamhetsroll>()
                .HasMany(e => e.PersonVerksamhetsroll)
                .WithRequired(e => e.Verksamhetsroll)
                .HasForeignKey(e => e.VerksamhetsrollFKId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Verksamhetsroll>()
                .HasMany(e => e.RelevantVerksamhetsdimension)
                .WithRequired(e => e.Verksamhetsroll)
                .HasForeignKey(e => e.VerksamhetsrollFKId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Person>()
                .HasOptional(e => e.Anvandare)
                .WithRequired(e => e.Person);

            modelBuilder.Entity<Person>()
                .HasMany(e => e.PersonVerksamhetsroll)
                .WithRequired(e => e.Person)
                .HasForeignKey(e => e.PersonFKId)
                .WillCascadeOnDelete(false);
        }
    }
}
