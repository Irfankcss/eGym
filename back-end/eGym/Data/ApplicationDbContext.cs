using eGym.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace eGym.Data
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Admin> Admin {  get; set; }
        public DbSet<Clan> Clan { get; set; }
        public DbSet<Clanarina> Clanarina { get; set; }
        public DbSet<Drzava> Drzava { get; set; }
        public DbSet<Grad> Grad { get; set; }
        public DbSet<KorisnickiNalog> KorisnickiNalog { get; set; }
        public DbSet<Korisnik> Korisnik { get; set; }
        public DbSet<KreditnaKartica> KreditnaKartica { get; set; }
        public DbSet<Obavjesti> Obavjesti { get; set; }

        public DbSet<Radnik> Radnik { get; set; }
        public DbSet<Brend> Brend { get; set; }
        public DbSet<Kategorija> Kategorija {  get; set; }

        public DbSet<Proizvod> Proizvod { get; set; }
        public DbSet <Narudzba> Narudzba { get; set; }
        public DbSet <NarudzbaProizvod> NarudzbaProizvod { get; set; }

        public DbSet <PoslanaNarudzba> PoslanaNarudzba { get; set; }

        public DbSet <Korpa> Korpa { get; set; }
        
        public ApplicationDbContext(
        DbContextOptions options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            foreach (var relationship in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
            {
                relationship.DeleteBehavior = DeleteBehavior.NoAction;
            }
        }
    }
}
