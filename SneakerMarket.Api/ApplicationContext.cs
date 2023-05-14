using Microsoft.EntityFrameworkCore;
using SneakerMarket.Api.Models;

namespace SneakerMarket.Api;

public partial class ApplicationContext : DbContext
{
    public ApplicationContext(DbContextOptions options)
        : base(options)
    {
    }

    public virtual DbSet<Account> Accounts { get; set; }

    public virtual DbSet<AccountRole> AccountRoles { get; set; }

    public virtual DbSet<Category> Categories { get; set; }

    public virtual DbSet<Contact> Contacts { get; set; }

    public virtual DbSet<Contract> Contracts { get; set; }

    public virtual DbSet<CustomerInfo> CustomerInfos { get; set; }

    public virtual DbSet<CustomerOrder> CustomerOrders { get; set; }

    public virtual DbSet<Feedback> Feedbacks { get; set; }

    public virtual DbSet<OrderShoesInfoMap> OrderShoesInfoMaps { get; set; }

    public virtual DbSet<ShoesAdditionalInfo> ShoesAdditionalInfos { get; set; }

    public virtual DbSet<ShoesMain> ShoesMains { get; set; }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.UseCollation("Ukrainian_100_CI_AS");

        modelBuilder.Entity<Account>(entity =>
        {
            entity.ToTable("Account");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Email)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Password)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.HasOne(d => d.Role).WithMany(p => p.Accounts)
                .HasForeignKey(d => d.RoleId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Account_AccountRole");
        });

        modelBuilder.Entity<AccountRole>(entity =>
        {
            entity.ToTable("AccountRole");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Role)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Category>(entity =>
        {
            entity.ToTable("Category");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Category1)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Category");
        });

        modelBuilder.Entity<Contact>(entity =>
        {
            entity.ToTable("Contact");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.PhoneNumber)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Surname)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.HasOne(d => d.Account).WithMany(p => p.Contacts)
                .HasForeignKey(d => d.AccountId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Contact_Account");
        });

        modelBuilder.Entity<Contract>(entity =>
        {
            entity.ToTable("Contract");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.DateStamp).HasColumnType("date");
            entity.Property(e => e.PmcontactId).HasColumnName("PMContactId");

            entity.HasOne(d => d.Pmcontact).WithMany(p => p.ContractPmcontacts)
                .HasForeignKey(d => d.PmcontactId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Contract_Contact");

            entity.HasOne(d => d.SupplierContact).WithMany(p => p.ContractSupplierContacts)
                .HasForeignKey(d => d.SupplierContactId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Contract_Contact1");
        });

        modelBuilder.Entity<CustomerInfo>(entity =>
        {
            entity.HasKey(e => e.CustomerAccountId);

            entity.ToTable("CustomerInfo");

            entity.Property(e => e.CustomerAccountId).ValueGeneratedNever();
            entity.Property(e => e.City)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.HasOne(d => d.CustomerAccount).WithOne(p => p.CustomerInfo)
                .HasForeignKey<CustomerInfo>(d => d.CustomerAccountId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_CustomerInfo_Contact");
        });

        modelBuilder.Entity<CustomerOrder>(entity =>
        {
            entity.ToTable("CustomerOrder");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.CustomerAccountId)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.DateStamp).HasColumnType("date");
        });

        modelBuilder.Entity<Feedback>(entity =>
        {
            entity.ToTable("Feedback");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Date).HasColumnType("date");
            entity.Property(e => e.Feedback1)
                .HasMaxLength(2000)
                .IsUnicode(false)
                .HasColumnName("Feedback");

            entity.HasOne(d => d.CustomerContact).WithMany(p => p.Feedbacks)
                .HasForeignKey(d => d.CustomerContactId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Feedback_Contact");

            entity.HasOne(d => d.CustomerOrder).WithMany(p => p.Feedbacks)
                .HasForeignKey(d => d.CustomerOrderId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Feedback_CustomerOrder");
        });

        modelBuilder.Entity<OrderShoesInfoMap>(entity =>
        {
            entity.ToTable("OrderShoesInfoMap");

            entity.Property(e => e.Id).ValueGeneratedNever();

            entity.HasOne(d => d.AdditionalInfo).WithMany(p => p.OrderShoesInfoMaps)
                .HasForeignKey(d => d.AdditionalInfoId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_OrderShoesInfoMap_AdditionalInfo");

            entity.HasOne(d => d.CustomerOrder).WithMany(p => p.OrderShoesInfoMaps)
                .HasForeignKey(d => d.CustomerOrderId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_OrderShoesInfoMap_CustomerOrder");
        });

        modelBuilder.Entity<ShoesAdditionalInfo>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_AdditionalInfo");

            entity.ToTable("ShoesAdditionalInfo");

            entity.Property(e => e.Id).ValueGeneratedNever();

            entity.HasOne(d => d.ShoesMain).WithMany(p => p.ShoesAdditionalInfos)
                .HasForeignKey(d => d.ShoesMainId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_AdditionalInfo_ShoesMain");
        });

        modelBuilder.Entity<ShoesMain>(entity =>
        {
            entity.ToTable("ShoesMain");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.ShoesName)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.HasOne(d => d.Category).WithMany(p => p.ShoesMains)
                .HasForeignKey(d => d.CategoryId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ShoesMain_Category");

            entity.HasOne(d => d.Contract).WithMany(p => p.ShoesMains)
                .HasForeignKey(d => d.ContractId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ShoesMain_ShoesMain");
        });
    }
}
