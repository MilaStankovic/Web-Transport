using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.VisualBasic;
using Newtonsoft.Json;

namespace Models
{
    public class PrevoznoSredstvo
    {
        [Key]   
        public int ID { get; set; }

        public string Naziv { get; set; }

        public int Cena { get; set; }

        public int TezinaPaketa { get; set; }

        public int Zapremina { get; set; }

        public string Slika { get; set; }

        public Kompanija Kompanija { get; set; }
        public List<Isporuka> ListaIsporuka { get; set; }
    }
}
