

using MedicineInventory.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace MedicineInventory.Infrastructure.Data;

public class MedicineDbContext : DbContext
{
    public MedicineDbContext(DbContextOptions<MedicineDbContext> options)
        : base(options)
    {
    }

    public DbSet<Medicine> Medicines => Set<Medicine>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Medicine>(entity =>
        {
            entity.ToTable("Medicines");

            entity.HasKey(x => x.Id);

            entity.Property(x => x.FullName)
                .IsRequired()
                .HasMaxLength(200);

            entity.Property(x => x.Notes)
                .HasMaxLength(1000);

            entity.Property(x => x.Brand)
                .IsRequired()
                .HasMaxLength(100);

            entity.Property(x => x.Price)
                .HasPrecision(10, 2);

            entity.Property(x => x.Quantity)
                .IsRequired();

            entity.Property(x => x.ExpiryDate)
                .IsRequired();
        });

        modelBuilder.Entity<Medicine>().HasData(
            new Medicine
            {
                Id = 1,
                FullName = "Paracetamol 500mg",
                Notes = "Used for fever and pain relief",
                ExpiryDate = new DateTime(2026, 7, 10),
                Quantity = 50,
                Price = 25.50m,
                Brand = "Cipla"
            },
            new Medicine
            {
                Id = 2,
                FullName = "Azithromycin 250mg",
                Notes = "Antibiotic medicine",
                ExpiryDate = new DateTime(2026, 8, 20),
                Quantity = 5,
                Price = 120.00m,
                Brand = "Sun Pharma"
            },
            new Medicine
            {
                Id = 3,
                FullName = "Vitamin D3",
                Notes = "Supplement",
                ExpiryDate = new DateTime(2027, 1, 15),
                Quantity = 100,
                Price = 180.75m,
                Brand = "Himalaya"
            }
        );
    }
}
