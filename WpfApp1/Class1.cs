using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace WpfApp1
{
    public class AppContext : DbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<Employee> Employees { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=MyHW;Trusted_Connection=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Technology>().ToTable("Technologies");
            modelBuilder.Entity<Clothing>().ToTable("Clothings");
            modelBuilder.Entity<Buyer>().ToTable("Buyers");
            modelBuilder.Entity<Supplier>().ToTable("Suppliers");
            modelBuilder.Entity<Manager>().ToTable("Managers");
            modelBuilder.Entity<Consultant>().ToTable("Consultants");

            modelBuilder.Entity<Manager>()
                .HasMany(m => m.Goods)
                .WithOne(p => p.Manager)
                .HasForeignKey(p => p.ManagerId);

            modelBuilder.Entity<Consultant>()
                .HasMany(c => c.Clients)
                .WithOne(c => c.Consultant)
                .HasForeignKey(c => c.ConsultantId);

            modelBuilder.Entity<Supplier>()
                .HasOne(s => s.Manager)
                .WithMany()
                .HasForeignKey(s => s.ManagerId);

            modelBuilder.Entity<Product>()
                .HasOne(p => p.Manager)
                .WithMany(m => m.Goods)
                .HasForeignKey(p => p.ManagerId);

            modelBuilder.Entity<Employee>()
                .Property(e => e.Salary)
                .HasColumnType("decimal(18, 2)");

            modelBuilder.Entity<Product>()
                .Property(p => p.Price)
                .HasColumnType("decimal(18, 2)");
        }
    }


    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int? ManagerId { get; set; } // Добавляем внешний ключ для связи с Manager
        public Manager Manager { get; set; } // Навигационное свойство к Manager
    }

    public class Technology : Product
    {
        public string TechProperty { get; set; }
    }

    public class Clothing : Product
    {
        public string ClothingProperty { get; set; }
    }

    public class Client
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int? ConsultantId { get; set; } // Добавляем внешний ключ для связи с Consultant
        public Consultant Consultant { get; set; } // Навигационное свойство к Consultant
    }

    public class Buyer : Client { }

    public class Supplier : Client
    {
        public int? ManagerId { get; set; } // Добавляем внешний ключ для связи с Manager
        public Manager Manager { get; set; } // Навигационное свойство к Manager
    }

    public class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Position { get; set; }
        public decimal Salary { get; set; }
    }

    public class Manager : Employee
    {
        public List<Product> Goods { get; set; }
    }

    public class Consultant : Employee
    {
        public List<Client> Clients { get; set; }
    }
}