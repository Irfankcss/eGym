﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using eGym.Data;

#nullable disable

namespace eGym.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20231214170031_proizvod-slike2")]
    partial class proizvodslike2
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("eGym.Data.Models.Brend", b =>
                {
                    b.Property<int>("BrendId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("BrendId"));

                    b.Property<string>("NazivBrenda")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("BrendId");

                    b.ToTable("Brend");
                });

            modelBuilder.Entity("eGym.Data.Models.Clan", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<int>("BrojClana")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.ToTable("Clan");
                });

            modelBuilder.Entity("eGym.Data.Models.Clanarina", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<DateTime>("DatumIsteka")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DatumUplate")
                        .HasColumnType("datetime2");

                    b.HasKey("ID");

                    b.ToTable("Clanarina");
                });

            modelBuilder.Entity("eGym.Data.Models.Drzava", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<string>("Naziv")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Skracenica")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("Drzava");
                });

            modelBuilder.Entity("eGym.Data.Models.Grad", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<int>("DrzavaID")
                        .HasColumnType("int");

                    b.Property<string>("Naziv")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PostanskiBroj")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.HasIndex("DrzavaID");

                    b.ToTable("Grad");
                });

            modelBuilder.Entity("eGym.Data.Models.Kategorija", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("NazivKategorije")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Opis")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Kategorija");
                });

            modelBuilder.Entity("eGym.Data.Models.KorisnickiNalog", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("KorisnickoIme")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Lozinka")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Slika")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("isAdmin")
                        .HasColumnType("bit");

                    b.Property<bool>("isKorisnik")
                        .HasColumnType("bit");

                    b.Property<bool>("isRadnik")
                        .HasColumnType("bit");

                    b.HasKey("ID");

                    b.ToTable("KorisnickiNalog");

                    b.UseTptMappingStrategy();
                });

            modelBuilder.Entity("eGym.Data.Models.Korpa", b =>
                {
                    b.Property<int>("KorpaID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("KorpaID"));

                    b.Property<int>("KorisnikID")
                        .HasColumnType("int");

                    b.Property<double>("Vrijednost")
                        .HasColumnType("float");

                    b.HasKey("KorpaID");

                    b.HasIndex("KorisnikID");

                    b.ToTable("Korpa");
                });

            modelBuilder.Entity("eGym.Data.Models.KorpaProizvod", b =>
                {
                    b.Property<int>("KorpaProizvodID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("KorpaProizvodID"));

                    b.Property<int>("Kolicina")
                        .HasColumnType("int");

                    b.Property<int>("KorpaID")
                        .HasColumnType("int");

                    b.Property<int>("ProizvodID")
                        .HasColumnType("int");

                    b.HasKey("KorpaProizvodID");

                    b.HasIndex("KorpaID");

                    b.HasIndex("ProizvodID");

                    b.ToTable("KorpaProizvod");
                });

            modelBuilder.Entity("eGym.Data.Models.KreditnaKartica", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<string>("BrojKartice")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DatumIsteka")
                        .HasColumnType("datetime2");

                    b.Property<int>("KorisnikID")
                        .HasColumnType("int");

                    b.Property<int>("SigurnosniBroj")
                        .HasColumnType("int");

                    b.Property<string>("TipKartice")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.HasIndex("KorisnikID");

                    b.ToTable("KreditnaKartica");
                });

            modelBuilder.Entity("eGym.Data.Models.Narudzba", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("DatumKreiranja")
                        .HasColumnType("datetime2");

                    b.Property<int>("KorisnikID")
                        .HasColumnType("int");

                    b.Property<string>("NacinPlacanja")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double?>("Popust")
                        .HasColumnType("float");

                    b.Property<double>("Vrijednost")
                        .HasColumnType("float");

                    b.Property<bool>("isOdobrena")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.HasIndex("KorisnikID");

                    b.ToTable("Narudzba");

                    b.UseTptMappingStrategy();
                });

            modelBuilder.Entity("eGym.Data.Models.NarudzbaProizvod", b =>
                {
                    b.Property<int>("NarudzbaProizvodID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("NarudzbaProizvodID"));

                    b.Property<int>("Kolicina")
                        .HasColumnType("int");

                    b.Property<int>("NarudzbaId")
                        .HasColumnType("int");

                    b.Property<int>("ProizvodId")
                        .HasColumnType("int");

                    b.HasKey("NarudzbaProizvodID");

                    b.HasIndex("NarudzbaId");

                    b.HasIndex("ProizvodId");

                    b.ToTable("NarudzbaProizvod");
                });

            modelBuilder.Entity("eGym.Data.Models.Obavjesti", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<int>("AdminID")
                        .HasColumnType("int");

                    b.Property<DateTime>("DatumObjave")
                        .HasColumnType("datetime2");

                    b.Property<string>("Naslov")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<byte[]>("Slika")
                        .IsRequired()
                        .HasColumnType("varbinary(max)");

                    b.Property<string>("Text")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.HasIndex("AdminID");

                    b.ToTable("Obavjesti");
                });

            modelBuilder.Entity("eGym.Data.Models.Proizvod", b =>
                {
                    b.Property<int>("ProizvodID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ProizvodID"));

                    b.Property<string>("Boja")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("BrendID")
                        .HasColumnType("int");

                    b.Property<double>("Cijena")
                        .HasColumnType("float");

                    b.Property<DateTime>("DatumObjave")
                        .HasColumnType("datetime2");

                    b.Property<bool>("Izbrisan")
                        .HasColumnType("bit");

                    b.Property<int>("KategorijaID")
                        .HasColumnType("int");

                    b.Property<int>("KolicinaNaSkladistu")
                        .HasColumnType("int");

                    b.Property<string>("Naziv")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Opis")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Velicina")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("isIzdvojen")
                        .HasColumnType("bit");

                    b.Property<double?>("popust")
                        .HasColumnType("float");

                    b.HasKey("ProizvodID");

                    b.HasIndex("BrendID");

                    b.HasIndex("KategorijaID");

                    b.ToTable("Proizvod");
                });

            modelBuilder.Entity("eGym.Data.Models.Slika", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("ProizvodID")
                        .HasColumnType("int");

                    b.Property<string>("Putanja")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("ProizvodID");

                    b.ToTable("Slika");
                });

            modelBuilder.Entity("eGym.Data.Models.Admin", b =>
                {
                    b.HasBaseType("eGym.Data.Models.KorisnickiNalog");

                    b.Property<string>("AdminKod")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.ToTable("Admin");
                });

            modelBuilder.Entity("eGym.Data.Models.Korisnik", b =>
                {
                    b.HasBaseType("eGym.Data.Models.KorisnickiNalog");

                    b.Property<string>("BrojTelefona")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DatumRodjenja")
                        .HasColumnType("datetime2");

                    b.Property<string>("Ime")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("OpstinaRodjenjaID")
                        .HasColumnType("int");

                    b.Property<string>("Prezime")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Spol")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("isClan")
                        .HasColumnType("bit");

                    b.HasIndex("OpstinaRodjenjaID");

                    b.ToTable("Korisnik");
                });

            modelBuilder.Entity("eGym.Data.Models.Radnik", b =>
                {
                    b.HasBaseType("eGym.Data.Models.KorisnickiNalog");

                    b.Property<string>("BrojTelefona")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DatumRodjenja")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DatumZaposlenja")
                        .HasColumnType("datetime2");

                    b.Property<int>("GradID")
                        .HasColumnType("int");

                    b.Property<string>("Ime")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Prezime")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Spol")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasIndex("GradID");

                    b.ToTable("Radnik");
                });

            modelBuilder.Entity("eGym.Data.Models.PoslanaNarudzba", b =>
                {
                    b.HasBaseType("eGym.Data.Models.Narudzba");

                    b.Property<DateTime>("DatumIsporuke")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DatumSlanja")
                        .HasColumnType("datetime2");

                    b.Property<int>("RadnikID")
                        .HasColumnType("int");

                    b.Property<bool>("isIsporucena")
                        .HasColumnType("bit");

                    b.Property<bool>("isPreuzeta")
                        .HasColumnType("bit");

                    b.HasIndex("RadnikID");

                    b.ToTable("PoslanaNarudzba");
                });

            modelBuilder.Entity("eGym.Data.Models.Grad", b =>
                {
                    b.HasOne("eGym.Data.Models.Drzava", "Drzava")
                        .WithMany()
                        .HasForeignKey("DrzavaID")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Drzava");
                });

            modelBuilder.Entity("eGym.Data.Models.Korpa", b =>
                {
                    b.HasOne("eGym.Data.Models.Korisnik", "korisnik")
                        .WithMany()
                        .HasForeignKey("KorisnikID")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("korisnik");
                });

            modelBuilder.Entity("eGym.Data.Models.KorpaProizvod", b =>
                {
                    b.HasOne("eGym.Data.Models.Korpa", "Korpa")
                        .WithMany("Proizvodi")
                        .HasForeignKey("KorpaID")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("eGym.Data.Models.Proizvod", "Proizvod")
                        .WithMany()
                        .HasForeignKey("ProizvodID")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Korpa");

                    b.Navigation("Proizvod");
                });

            modelBuilder.Entity("eGym.Data.Models.KreditnaKartica", b =>
                {
                    b.HasOne("eGym.Data.Models.Korisnik", "Korisnik")
                        .WithMany()
                        .HasForeignKey("KorisnikID")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Korisnik");
                });

            modelBuilder.Entity("eGym.Data.Models.Narudzba", b =>
                {
                    b.HasOne("eGym.Data.Models.Korisnik", "korisnik")
                        .WithMany()
                        .HasForeignKey("KorisnikID")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("korisnik");
                });

            modelBuilder.Entity("eGym.Data.Models.NarudzbaProizvod", b =>
                {
                    b.HasOne("eGym.Data.Models.Narudzba", "Narudzba")
                        .WithMany("NarudzbaProizvodi")
                        .HasForeignKey("NarudzbaId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("eGym.Data.Models.Proizvod", "Proizvod")
                        .WithMany()
                        .HasForeignKey("ProizvodId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Narudzba");

                    b.Navigation("Proizvod");
                });

            modelBuilder.Entity("eGym.Data.Models.Obavjesti", b =>
                {
                    b.HasOne("eGym.Data.Models.Admin", "Admin")
                        .WithMany()
                        .HasForeignKey("AdminID")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Admin");
                });

            modelBuilder.Entity("eGym.Data.Models.Proizvod", b =>
                {
                    b.HasOne("eGym.Data.Models.Brend", "Brend")
                        .WithMany()
                        .HasForeignKey("BrendID")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("eGym.Data.Models.Kategorija", "Kategorija")
                        .WithMany()
                        .HasForeignKey("KategorijaID")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Brend");

                    b.Navigation("Kategorija");
                });

            modelBuilder.Entity("eGym.Data.Models.Slika", b =>
                {
                    b.HasOne("eGym.Data.Models.Proizvod", null)
                        .WithMany("Slike")
                        .HasForeignKey("ProizvodID")
                        .OnDelete(DeleteBehavior.NoAction);
                });

            modelBuilder.Entity("eGym.Data.Models.Admin", b =>
                {
                    b.HasOne("eGym.Data.Models.KorisnickiNalog", null)
                        .WithOne()
                        .HasForeignKey("eGym.Data.Models.Admin", "ID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("eGym.Data.Models.Korisnik", b =>
                {
                    b.HasOne("eGym.Data.Models.KorisnickiNalog", null)
                        .WithOne()
                        .HasForeignKey("eGym.Data.Models.Korisnik", "ID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("eGym.Data.Models.Grad", "OpstinaRodjenja")
                        .WithMany()
                        .HasForeignKey("OpstinaRodjenjaID")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("OpstinaRodjenja");
                });

            modelBuilder.Entity("eGym.Data.Models.Radnik", b =>
                {
                    b.HasOne("eGym.Data.Models.Grad", "grad")
                        .WithMany()
                        .HasForeignKey("GradID")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("eGym.Data.Models.KorisnickiNalog", null)
                        .WithOne()
                        .HasForeignKey("eGym.Data.Models.Radnik", "ID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("grad");
                });

            modelBuilder.Entity("eGym.Data.Models.PoslanaNarudzba", b =>
                {
                    b.HasOne("eGym.Data.Models.Narudzba", null)
                        .WithOne()
                        .HasForeignKey("eGym.Data.Models.PoslanaNarudzba", "Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("eGym.Data.Models.Radnik", "radnik")
                        .WithMany()
                        .HasForeignKey("RadnikID")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("radnik");
                });

            modelBuilder.Entity("eGym.Data.Models.Korpa", b =>
                {
                    b.Navigation("Proizvodi");
                });

            modelBuilder.Entity("eGym.Data.Models.Narudzba", b =>
                {
                    b.Navigation("NarudzbaProizvodi");
                });

            modelBuilder.Entity("eGym.Data.Models.Proizvod", b =>
                {
                    b.Navigation("Slike");
                });
#pragma warning restore 612, 618
        }
    }
}
