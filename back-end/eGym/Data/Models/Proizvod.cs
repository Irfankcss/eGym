using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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

        [ForeignKey(nameof(kategorija))]
        public int KategorijaID {  get; set; }

        public Kategorija kategorija { get; set; }
        public int KolicinaNaSkladistu { get; set; }
        public string? Boja {  get; set; }
        [ForeignKey(nameof(brend))]
        public int BrendID { get; set; }
        public Brend brend { get; set; }
        public string? Velicina { get; set; }
        public DateTime DatumObjave {  get; set; }
        public bool Izbrisan {  get; set; }
        public double? popust {  get; set; }
        public bool isIzdvojen { get; set; }
    }
}
