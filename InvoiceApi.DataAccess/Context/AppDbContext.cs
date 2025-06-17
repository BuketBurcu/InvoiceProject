using InvoiceApi.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace InvoiceApi.DataAccess.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<InvoiceHeader> InvoiceHeaders { get; set; }
        public DbSet<InvoiceLine> InvoiceLines { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<InvoiceHeader>()
             .HasKey(i => i.InvoiceId);

            modelBuilder.Entity<InvoiceLine>()
                .HasKey(i => i.Id);

            modelBuilder.Entity<InvoiceLine>()
                .HasOne(il => il.InvoiceHeader)
                .WithMany(ih => ih.InvoiceLines)
                .HasForeignKey(il => il.InvoiceId);
        }
    }
}