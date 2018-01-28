using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Dziennik.Models
{
    public class Wynik
    {
        public int ID { get; set; }
        public int StudentID { get; set; }
        public int PrzedmiotID { get; set; }
        [RegularExpression(@"^[A-F]*$", ErrorMessage = "Wpisz ocenę od A do F")]
        [Required]
        public Ocena? Ocena { get; set; }
        public virtual Student Student { get; set; }
        public virtual Przedmiot Przedmiot { get; set; }

    }

    public enum Ocena
    {
        A,B,C,D,E,F
    }
}