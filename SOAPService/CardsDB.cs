using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace SOAPService
{
    public partial class CardsDB : DbContext
    {
        public CardsDB()
            : base("name=CardsDB")
        {
        }

        public virtual DbSet<CardsTable> CardsTable { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CardsTable>()
                .Property(e => e.cardId)
                .IsUnicode(false);

            modelBuilder.Entity<CardsTable>()
                .Property(e => e.cardName)
                .IsUnicode(false);

            modelBuilder.Entity<CardsTable>()
                .Property(e => e.cmc)
                .IsUnicode(false);

            modelBuilder.Entity<CardsTable>()
                .Property(e => e.type)
                .IsUnicode(false);

            modelBuilder.Entity<CardsTable>()
                .Property(e => e.subTypes)
                .IsUnicode(false);

            modelBuilder.Entity<CardsTable>()
                .Property(e => e.rarity)
                .IsUnicode(false);

            modelBuilder.Entity<CardsTable>()
                .Property(e => e.cardText)
                .IsUnicode(false);
        }
    }
}
