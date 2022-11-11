using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace Models
{
    public class Isporuka
    {
        [Key]
        public int ID { get; set; }

        public Kompanija Kompanija { get; set; }

        public PrevoznoSredstvo Prevoz { get; set; }
    } 
}