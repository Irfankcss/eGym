using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace eGym.Data.Models
{
    public class Obavjesti
    {
        [Key]
        public int ID { get; set; }
        public DateTime DatumObjave { get; set; }
        public string Naslov {  get; set; }
        public string Text {  get; set; }
        public byte[] Slika { get; set; }
        [ForeignKey(nameof(Admin))]
        public int AdminID { get; set; }
        public Admin Admin { get; set; }
    }
}
