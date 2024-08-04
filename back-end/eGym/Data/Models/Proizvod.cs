using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace eGym.Data.Models
{
    [Table("Proizvod")]
    public class Proizvod
    {
        [Key]
        public int ProizvodID { get; set; }
        public string Naziv {  get; set; }
        public string Opis {  get; set; }
        public double Cijena { get; set; }

        [ForeignKey(nameof(Kategorija))]
        public int KategorijaID {  get; set; }

        public Kategorija Kategorija { get; set; }
        public int KolicinaNaSkladistu { get; set; }
        public string? Boja {  get; set; }
        [ForeignKey(nameof(Brend))]
        public int BrendID { get; set; }
        public Brend Brend { get; set; }
        public string? Velicina { get; set; }
        public DateTime DatumObjave { get; set; }
        public List<Slika> Slike { get; set; } = new List<Slika>();
        public bool Izbrisan {  get; set; }
        public double? popust {  get; set; }
        public bool isIzdvojen { get; set; }
    }
}
