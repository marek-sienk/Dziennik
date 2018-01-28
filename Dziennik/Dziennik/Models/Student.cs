using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Dziennik.Models
{
    public class Student
    {
        public int ID { get; set; }
        [Required]
        [RegularExpression(@"^[A-ZŻŹŃĄŚŁĘÓ]+[a-zA-ZŻŹŃĄŚŁĘÓżźćńąśłęó''-'\s]*$", ErrorMessage = "Zacznij z dużej litery i używaj wyłącznie liter")]
        [StringLength(15, ErrorMessage = "Imię nie może być dłuższe niż 15 znaków.")]
        public string Imię { get; set; }
        [Required]
        [StringLength(20, ErrorMessage = "Nazwisko nie może być dłuższe niż 20 znaków.")]
        [RegularExpression(@"^[A-ZŻŹŃĄŚŁĘÓ]+[a-zA-ZŻŹŃĄŚŁĘÓżźćńąśłęó''-'\s]*$", ErrorMessage = "Zacznij z dużej litery i używaj wyłącznie liter")]
        public string Nazwisko { get; set; }
        [Display(Name="Rok studiów")]
        public int RokStudnów { get; set; }
        [Display(Name="Stopień studiów")]
        public int StopieńStudiów { get; set; }
        [StringLength(35, ErrorMessage = "Kierunek nie może być dłuższy niż 35 znaków.")]
        [Required]
        public string Kierunek { get; set; }
        [Display(Name="Nr albumu")]
        public int NrAlbumu { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        [Display(Name="Data przyjęcia")]
        public DateTime DataPrzyjęcia { get; set; }

        [Display(Name="Oceny")]
        public virtual ICollection<Wynik> Wyniki { get; set; }
    }
}