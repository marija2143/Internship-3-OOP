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
        static Dictionary<Project, List<Task>> GetStarted() 
        {
            var start_dict = new Dictionary<Project, List<Task>>();
            var list_p1 = new List<Task>();
            var list_p2 = new List<Task>();

            var proj1 = new Project("Titula 1", "Opis 1", DateTime.Parse("01/11/2024"), DateTime.Parse("15/07/2025"), "active");
            var proj2 = new Project("Titula 2", "Opis 2", DateTime.Parse("02/11/2024"), DateTime.Parse("25/012/2025"), "active");

            var task1 = new Task("Titula 1 1", "Opis 1 1", DateTime.Parse("11/5/2025"), 150, "aktivan", proj1);
            var task2 = new Task("Titula 1 2", "Opis 1 2", DateTime.Parse("25/11/2024"), 130, "aktivan", proj1);
            var task3 = new Task("Titula 1 3", "Opis 1 3", DateTime.Parse("12/12/2024"), 120, "aktivan", proj1);
            list_p1.Add(task1);
            list_p1.Add(task2);
            list_p1.Add(task3);

            var task4 = new Task("Titula 2 1", "Opis 2 1", DateTime.Parse("15/12/2024"), 111, "aktivan", proj2);
            var task5 = new Task("Titula 2 2", "Opis 2 2", DateTime.Parse("25/5/2025"), 250, "aktivan", proj2);
            list_p2.Add(task4);
            list_p2.Add(task5);

            start_dict.Add(proj1, list_p1);
            start_dict.Add(proj2, list_p2);

            return start_dict;
        }
        static void Functions_Choice(int main_choice,string[] sub_menu_6, string[] sub_menu_7)
        {
            //starting dictionary , key project, value tasklist
            var dict = GetStarted();

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
                        Console.WriteLine($"{i + 1}) {sub_menu_6[i]}");
                    }
                    var sub_6_choice = Check_Menu(sub_menu_6.Length);
                    Console.WriteLine("opcija 6");
                    break;
                case 7:
                    //option 7 - editing specific task
                    Console.WriteLine("Podizbornik: ");
                    for (int i = 0; i < sub_menu_7.Length; i++)
                    {
                        Console.WriteLine($"{i + 1}) {sub_menu_7[i]}");
                    }
                    var sub_7_choice = Check_Menu(sub_menu_7.Length);
                    Console.WriteLine("opcija 7");
                    break;
                case 8:
                    Console.Clear();
                    Console.WriteLine("Dovidenja! Pritisnite bilo koju tipku za izlaz.");
                    Environment.Exit(0);
                    break;
                default:
                    break;
            }
        }
        static void Start() 
        {
            //declaring string arrays for (sub)menus
            string[] main_menu = {"Projekti i zadaci","Dodaj novi projekt","Izbrisi projekt","Zadaci s rokom u sljedecih 7 dana",
                "Projekti prema statusu","Uredi specificni projekt","Uredi specificni zadatak" };
            string[] sub_menu_6 = { "Prikazi zadatke", "Prikazi detalje", "Uredi status", "Dodaj zadatak", "Izbrisi zadatak", "Prikazi predvideno vrijeme do kraja" };
            string[] sub_menu_7 = { "Prikazi detalje", "Uredi status" };


            //MAIN MENU
            Console.WriteLine("Izbornik: ");
            for (int i = 0; i < main_menu.Length; i++)
            {
                Console.WriteLine($"{i + 1} - {main_menu[i]}");
            }
            Console.WriteLine((main_menu.Length+1)+" - Izlaz");
            var main_choice = Check_Menu(main_menu.Length+1);

            Functions_Choice(main_choice, sub_menu_6, sub_menu_7);
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

        static void Main(string[] args)
        {
            Start();
        }
    }
}
