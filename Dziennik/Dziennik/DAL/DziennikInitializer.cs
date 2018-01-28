using Dziennik.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Diagnostics;
using System.Linq;
using System.Web;

namespace Dziennik.DAL
{
    public class DziennikInitializer : DropCreateDatabaseIfModelChanges<DziennikContext>
    {
        protected override void Seed(DziennikContext context)
        {
            var roleManager = new RoleManager<IdentityRole>(
                new RoleStore<IdentityRole>(new ApplicationDbContext()));
            var userManager = new UserManager<ApplicationUser>(
                new UserStore<ApplicationUser>(new ApplicationDbContext()));

            roleManager.Create(new IdentityRole("Admin"));
            roleManager.Create(new IdentityRole("Student"));
            roleManager.Create(new IdentityRole("Wykładowca"));

            var user = new ApplicationUser { UserName = "Administrator" };
            string passwd = "admin1";
            userManager.Create(user, passwd);
            userManager.AddToRole(userManager.FindByName("Administrator").Id, "Admin");

            user = new ApplicationUser { UserName = "akolkowicz" };
            passwd = "wykladowca";

            userManager.Create(user, passwd);
            userManager.AddToRole(user.Id, "Wykładowca");

            user = new ApplicationUser { UserName = "mpilski" };
            passwd = "wykladowca";

            userManager.Create(user, passwd);
            userManager.AddToRole(user.Id, "Wykładowca");

            user = new ApplicationUser { UserName = "pswitalski" };
            passwd = "wykladowca";

            userManager.Create(user, passwd);
            userManager.AddToRole(user.Id, "Wykładowca");

            user = new ApplicationUser { UserName = "tboczoroszwili" };
            passwd = "wykladowca";

            userManager.Create(user, passwd);
            userManager.AddToRole(user.Id, "Wykładowca");

            user = new ApplicationUser { UserName = "aniewiadomski" };
            passwd = "wykladowca";

            userManager.Create(user, passwd);
            userManager.AddToRole(user.Id, "Wykładowca");

            user = new ApplicationUser { UserName = "abarczak" };
            passwd = "wykladowca";

            userManager.Create(user, passwd);
            userManager.AddToRole(user.Id, "Wykładowca");

            user = new ApplicationUser { UserName = "msienkiewicz" };
            passwd = "student";
            userManager.Create(user, passwd);
            userManager.AddToRole(user.Id, "Student");

            user = new ApplicationUser { UserName = "jkowalski" };
            passwd = "student";
            userManager.Create(user, passwd);
            userManager.AddToRole(user.Id, "Student");

            var user4 = new ApplicationUser { UserName = "anowak" };
            passwd = "student";
            userManager.Create(user4, passwd);
            userManager.AddToRole(user.Id, "Student");


            var wykładowcy = new List<Wykładowca>
            {
                new Wykładowca { Imię = "Anna", Nazwisko = "Kołkowicz"},
                new Wykładowca { Imię = "Marek", Nazwisko = "Pilski"},
                new Wykładowca { Imię = "Piotr", Nazwisko = "Świtalski"},
                new Wykładowca { Imię = "Tengiz", Nazwisko = "Boczoroszwili"},
                new Wykładowca { Imię = "Artur", Nazwisko = "Niewiadomski"},
                new Wykładowca { Imię = "Andrzej", Nazwisko = "Barczak"}
            };
            wykładowcy.ForEach(w => context.Wykładowcy.Add(w));
            context.SaveChanges();
            
            var przedmioty = new List<Przedmiot>
            {
                new Przedmiot { Nazwa = "Multimedialne Interfejsy Użytkownika", Skrót = "MIU", PunktyECTS = 30, Wykładowca = wykładowcy[0]},
                new Przedmiot { Nazwa = "Hurtownie Danych", Skrót = "HD",PunktyECTS = 35, Wykładowca = wykładowcy[5]},
                new Przedmiot { Nazwa = "Zaawansowane Technologie Programistyczne", Skrót = "ZTP",PunktyECTS = 40, Wykładowca = wykładowcy[4]},
                new Przedmiot { Nazwa = "Sieci i Systemy Wirtualne", Skrót = "SSW",PunktyECTS = 30, Wykładowca = wykładowcy[3]},
                new Przedmiot { Nazwa = "Projektowanie zinntegrowanych systemów informatycznych", Skrót = "PZSI",PunktyECTS = 35, Wykładowca = wykładowcy[1]},
                new Przedmiot { Nazwa = "Technologie i systemy bezpieczeństwa komputerowego", Skrót = "TBSK",PunktyECTS = 25, Wykładowca = wykładowcy[2]},
            };
            przedmioty.ForEach(p => context.Przedmioty.Add(p));
            context.SaveChanges();


            var studenci = new List<Student>
            {
                new Student { Imię = "Marek", Nazwisko = "Sienkiewicz",RokStudnów = 1, StopieńStudiów = 2, Kierunek = "informatyka", NrAlbumu = 1234, DataPrzyjęcia = DateTime.Parse("2013-07-22") },
                new Student { Imię = "Jan", Nazwisko = "Kowalski",RokStudnów = 1, StopieńStudiów = 2, Kierunek = "informatyka", NrAlbumu = 4321, DataPrzyjęcia = DateTime.Parse("2013-07-22") },
                new Student { Imię = "Anna", Nazwisko = "Nowak",RokStudnów = 1, StopieńStudiów = 2, Kierunek = "informatyka", NrAlbumu = 2314, DataPrzyjęcia = DateTime.Parse("2013-07-22") }
            };
            studenci.ForEach(s => context.Studenci.Add(s));
            context.SaveChanges();

            var wyniki = new List<Wynik>
            {
                new Wynik { Ocena = Ocena.B, Student = studenci[0], Przedmiot = przedmioty[0]},
                new Wynik { Ocena = Ocena.C, Student = studenci[1], Przedmiot = przedmioty[2]},
                new Wynik { Ocena = Ocena.A, Student = studenci[2], Przedmiot = przedmioty[1]},
                new Wynik { Ocena = Ocena.D, Student = studenci[0], Przedmiot = przedmioty[2]},
            };
            wyniki.ForEach(w => context.Wyniki.Add(w));
            context.SaveChanges();

            base.Seed(context);
        }
    }
}