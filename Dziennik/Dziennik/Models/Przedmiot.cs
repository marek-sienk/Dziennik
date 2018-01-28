using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Dziennik.Models
{
    public class Przedmiot
    {
        public int ID { get; set; }
        public int WykładowcaID { get; set; }
        [StringLength(80, ErrorMessage = "Nazwa nie może być dłuższa niż 35 znaków.")]
        [Required]
        [Display(Name="Nazwa przedmiotu")]
        public string Nazwa { get; set; }
        [StringLength(8, ErrorMessage = "Skrót nie może być dłuższy niż 8 znaków.")]
        [Required]
        public string Skrót { get; set; }
        [Display(Name="Punkty ECTS")]
        public int PunktyECTS { get; set; }

        public virtual ICollection<Wynik> Wyniki { get; set; }
        [Required]
        public virtual Wykładowca Wykładowca { get; set; }
    }
}