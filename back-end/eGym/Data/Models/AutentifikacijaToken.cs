﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace eGym.Data.Models
{
    public class AutentifikacijaToken
    {
        [Key]
        public int id {  get; set; }
        public string vrijednost {  get; set; }
        [ForeignKey(nameof(korisnickiNalog))]
        public int KorisnickiNalogId {  get; set; }
        public KorisnickiNalog korisnickiNalog { get; set; }
        public DateTime vrijemeEvidentiranja {  get; set; }
        public string? ipAdresa {  get; set; }
    }
}
