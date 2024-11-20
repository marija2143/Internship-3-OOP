using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
namespace dr_3_dump_int_mk
{
    class Program
    {
        static int Check_Menu(int biggest_option)
        {
            bool incorrectInput = true;
            int first_choice = 0;

            while (incorrectInput)
            {
                Console.WriteLine("Unesite broj: ");
                var _choice = Console.ReadLine();
                var f_choice = int.TryParse(_choice, out first_choice);
                try
                {
                    if (!f_choice)
                    {
                        var ex1 = new Exception("Neispravan unos, nije broj");
                        throw ex1;
                    }
                    if (first_choice < 1 || first_choice > biggest_option)
                    {
                        var ex2 = new Exception("Neispravan unos, broj van ponuđenih");
                        throw ex2;
                    }
                    incorrectInput = false;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
            return first_choice;
        }

        static void Main(string[] args)
        {
            //declaring string arrays for (sub)menus
            string[] main_menu = {"Projekti i zadaci","Dodaj novi projekt","Izbrisi projekt","Zadaci s rokom u sljedecih 7 dana",
                "Projekti prema statusu","Uredi specificni projekt","Uredi specificni zadatak" };
            string[] sub_menu_6 = {"Prikazi zadatke","Prikazi detalje","Uredi status","Dodaj zadatak","Izbrisi zadatak","Prikazi predvideno vrijeme do kraja" };
            string[] sub_menu_7 = { "Prikazi detalje","Uredi status"};

            
            //dictionary , key project, value tasklist
            //MAIN MENU
            Console.WriteLine("Izbornik: ");
            for (int i = 0; i < main_menu.Length; i++)
            {
                Console.WriteLine($"{i+1} - {main_menu[i]}");
            }
            var main_choice=Check_Menu(main_menu.Length);

            switch (main_choice)
            {
                case 1:
                    //option 1 - list projects + related tasks
                    Console.WriteLine("opcija 1");
                    break;
                case 2:
                    //option 2 - add new project
                    Console.WriteLine("opcija 2");
                    break;
                case 3:
                    //option 3 - delete project
                    Console.WriteLine("opcija 3");
                    break;
                case 4:
                    //option 4 - show all tasks with deadline within the next 7 days
                    Console.WriteLine("opcija 4");
                    break;
                case 5:
                    //option 5 - show projects filtered by status
                    Console.WriteLine("opcija 5");
                    break;
                case 6:
                    //option 6 - editing specific project
                    Console.WriteLine("Podizbornik: ");
                    for (int i = 0; i < sub_menu_6.Length; i++)
                    {
                        Console.WriteLine($"{i+1}) {sub_menu_6[i]}");
                    }
                    var sub_6_choice = Check_Menu(sub_menu_6.Length);
                    Console.WriteLine("opcija 6");
                    break;
                case 7:
                    //option 7 - editing specific task
                    Console.WriteLine("Podizbornik: ");
                    for (int i = 0; i < main_menu.Length; i++)
                    {
                        Console.WriteLine($"{i+1}) {sub_menu_7[i]}");
                    }
                    var sub_7_choice = Check_Menu(sub_menu_7.Length);
                    Console.WriteLine("opcija 7");
                    break;
                default:
                    break;
            }

            //            Pri implementaciji je važno vodit računa da dva projekta ne smiju imat isti naziv,
            //            te unutar projekta dva zadatka ne smiju imat isti naziv.
            //
            //            Ukoliko je zadatak ili projekt “završen” ne mogu se mijenjati podaci,
            //            niti se u “završen” projekt može dodavat nove zadatke.
            //
            //            Kada se svi zadaci unutar projekta označe kao “završeni” projekt automatski postaje “završen”. 
            //
            //            Prilikom unosa novih zadataka i projekata bitno je validirati unos, npr. naziv zadatka ne može ostat prazan.
            //
            //            U slučaju pogrešnog unosa ispisati odgovarajuću poruku, te omogućiti ponovni unos. 
            //
            //            Pri brisanju zadatka ili projekta potrebno je prikazati potvrdni dijalog s pitanjem želi li zaista izbrisati taj zadatak, tj. projekt.
            //
            //          Potrebno je da prilikom pokretanja aplikacije postoje inicijalni podaci s kojima je moguće obavljati sve navedene funkcionalnosti koje aplikacija nudi.
            //          Isto tako aplikacije ne smije “pucati” prilikom korištenja.
        }
    }
}
