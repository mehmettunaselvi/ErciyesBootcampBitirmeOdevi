// <auto-generated />
using BitirmeOdev.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace BitirmeOdev.Migrations
{
    [DbContext(typeof(DatabaseContext))]
    [Migration("20230301233532_UrunListeModelEkleme")]
    partial class UrunListeModelEkleme
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.14")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("BitirmeOdev.Models.Kullanici", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Ad")
                        .IsRequired()
                        .HasMaxLength(25)
                        .HasColumnType("nvarchar(25)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(40)
                        .HasColumnType("nvarchar(40)");

                    b.Property<string>("Sifre")
                        .IsRequired()
                        .HasMaxLength(16)
                        .HasColumnType("nvarchar(16)");

                    b.Property<string>("Soyad")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("nvarchar(15)");

                    b.HasKey("Id");

                    b.ToTable("Kullanici");
                });

            modelBuilder.Entity("BitirmeOdev.Models.Liste", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Aciklama")
                        .IsRequired()
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("Ad")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<int>("KullaniciId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("KullaniciId");

                    b.ToTable("Liste");
                });

            modelBuilder.Entity("BitirmeOdev.Models.ListUrun", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("ListeId")
                        .HasColumnType("int");

                    b.Property<int>("Miktar")
                        .HasColumnType("int");

                    b.Property<int>("UrunId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ListeId");

                    b.HasIndex("UrunId");

                    b.ToTable("ListUrun");
                });

            modelBuilder.Entity("BitirmeOdev.Models.Urun", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Aciklama")
                        .IsRequired()
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("Ad")
                        .IsRequired()
                        .HasMaxLength(40)
                        .HasColumnType("nvarchar(40)");

                    b.Property<string>("Gorsel")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("Marka")
                        .IsRequired()
                        .HasMaxLength(40)
                        .HasColumnType("nvarchar(40)");

                    b.HasKey("Id");

                    b.ToTable("Urun");
                });

            modelBuilder.Entity("BitirmeOdev.Models.Liste", b =>
                {
                    b.HasOne("BitirmeOdev.Models.Kullanici", "Kullanici")
                        .WithMany("Listeler")
                        .HasForeignKey("KullaniciId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Kullanici");
                });

            modelBuilder.Entity("BitirmeOdev.Models.ListUrun", b =>
                {
                    b.HasOne("BitirmeOdev.Models.Liste", "Liste")
                        .WithMany("ListUrun")
                        .HasForeignKey("ListeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BitirmeOdev.Models.Urun", "Urun")
                        .WithMany()
                        .HasForeignKey("UrunId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Liste");

                    b.Navigation("Urun");
                });

            modelBuilder.Entity("BitirmeOdev.Models.Kullanici", b =>
                {
                    b.Navigation("Listeler");
                });

            modelBuilder.Entity("BitirmeOdev.Models.Liste", b =>
                {
                    b.Navigation("ListUrun");
                });
#pragma warning restore 612, 618
        }
    }
}
