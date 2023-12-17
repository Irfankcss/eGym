using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace eGym.Data.Models
{
    [Table("Kategorija")]
    public class Kategorija
    {
        [Key]
        public int Id { get; set; }
        public string NazivKategorije { get; set; }
        public string Opis {  get; set; }
    }
}
