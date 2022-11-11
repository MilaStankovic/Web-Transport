using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Models
{
    public class Kompanija
    {
        [Key]
        public int ID { get; set; }

        public string Naziv { get; set; }

        public int ProsecnaZarada { get; set; }

        [JsonIgnore]
        public List<PrevoznoSredstvo> Vozila { get; set; }

        [JsonIgnore]
        public List<Isporuka> ListaIsporuka { get; set; }
    }
}
