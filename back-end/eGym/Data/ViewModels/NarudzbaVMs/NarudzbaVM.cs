﻿using eGym.Data.Models;
using eGym.Data.ViewModels.ProizvodVMs;

namespace eGym.Data.ViewModels.NarudzbaVMs
{
    public class NarudzbaVM
    {
        public int Id { get; set; }
        public DateTime DatumKreiranja { get; set; }
        public bool isOdobrena { get; set; }
        public bool isPoslana { get; set; }
        public double Vrijednost { get; set; }
        public double? Popust { get; set; }
        public int KorisnikID { get; set; }
        public string NacinPlacanja { get; set; }
        public string NacinDostave { get; set; }
        public string? ImePrimaoca { get; set; }
        public string? PrezimePrimaoca { get; set; }
        public string? Adresa { get; set; }
        public Grad Grad { get; set; }
        public string Telefon { get; set; }
        public string Email { get; set; }

        public List<NarudzbaProizvodVM> Proizvodi { get; set; }

    }
    public class NarudzbaProizvodVM
    {
        public Proizvod Proizvod { get; set; }
        public int Kolicina { get; set; }
    }
}
