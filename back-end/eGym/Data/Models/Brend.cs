using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace eGym.Data.Models
{
    [Table("Brend")]
    public class Brend
    {
        [Key]
        public int BrendId { get; set; }
        public string NazivBrenda { get; set; }
    }
}
