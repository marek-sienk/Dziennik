using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Dziennik.Models
{
    public class Wykładowca
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

        public virtual ICollection<Przedmiot> Przedmioty { get; set; }
    }
}