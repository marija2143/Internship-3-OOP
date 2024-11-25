﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using dr_3_dump_int_mk.enums;
namespace dr_3_dump_int_mk
{
    class Program
    {
        static void Go_Back(Dictionary<Project, List<Task>> dict)
        {
            Console.WriteLine("Pritisnite bilo koju tipku za nastavak");
            Console.ReadKey();
            Console.Clear();
            Start(dict);
        }
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

            var proj1 = new Project("Titula 1", "Opis 1", DateTime.Parse("01/11/2024"), DateTime.Parse("15/07/2025"), Status.aktivan);
            var proj2 = new Project("Titula 2", "Opis 2", DateTime.Parse("02/11/2024"), DateTime.Parse("25/12/2025"), Status.naCekanju);

            var task1 = new Task("Titula 1 1", "Opis 1 1", DateTime.Parse("11/5/2025"), 150, Status.aktivan, proj1);
            var task2 = new Task("Titula 1 2", "Opis 1 2", DateTime.Parse("25/11/2024"), 130, Status.aktivan, proj1);
            var task3 = new Task("Titula 1 3", "Opis 1 3", DateTime.Parse("12/12/2024"), 120, Status.aktivan, proj1);
            list_p1.Add(task1);
            list_p1.Add(task2);
            list_p1.Add(task3);

            var task4 = new Task("Titula 2 1", "Opis 2 1", DateTime.Parse("27/11/2024"), 111, Status.aktivan, proj2);
            var task5 = new Task("Titula 2 2", "Opis 2 2", DateTime.Parse("25/5/2025"), 250, Status.zavrsen, proj2);
            list_p2.Add(task4);
            list_p2.Add(task5);

            start_dict.Add(proj1, list_p1);
            start_dict.Add(proj2, list_p2);

            return start_dict;
        }
        static void Function_1(Dictionary<Project, List<Task>> dict)
        {
            Console.Clear();
            foreach (var item in dict)
            {
                Console.WriteLine(item.Key.title);
                foreach (var val in item.Value)
                {
                    Console.WriteLine("\t" + val.title);
                }
            }
            Go_Back(dict);
        }
        static Project Function_2(Dictionary<Project, List<Task>> dict)
        {
            Console.Clear();
            bool incorrectInput = true;
            string title = "";
            string desc = "";
            DateTime start = new();
            DateTime end = new();
            string status = "";
            Status stat_ = Status.aktivan;

            while (incorrectInput)
            {
                Console.WriteLine("Unesite titulu: ");
                title = Console.ReadLine();
                try
                {
                    if (title.Trim()=="")
                    {
                        var ex1 = new Exception("Neispravan unos, ne smije biti prazno polje");
                        throw ex1;
                    }
                    bool in_dict=false;
                    foreach (var item in dict.Keys)
                    {
                        if (item.title==title)
                        {
                            in_dict = true; break;

                        }
                    }
                    if (in_dict)
                    {
                        var ex2 = new Exception("Neispravan unos, projekt vec postoji");
                        throw ex2;
                    }
                    incorrectInput = false;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }

            incorrectInput = true;
            while (incorrectInput)
            {
                Console.WriteLine("Unesite opis: ");
                desc = Console.ReadLine();
                try
                {
                    if (desc.Trim() == "")
                    {
                        var ex1 = new Exception("Neispravan unos, ne smije biti prazno polje");
                        throw ex1;
                    }
                    incorrectInput = false;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }

            incorrectInput = true;
            while (incorrectInput)
            {
                Console.WriteLine("Unesite datum pocetka (DD/MM/GGGG): ");
                var s = DateTime.TryParse(Console.ReadLine(), out start);
                try
                {
                    if (s==false)
                    {
                        var ex1 = new Exception("Neispravan unos, nije tocan format datuma");
                        throw ex1;
                    }
                    incorrectInput = false;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }

            incorrectInput = true;
            while (incorrectInput)
            {
                Console.WriteLine("Unesite datum kraja (DD/MM/GGGG): ");
                var e_ = DateTime.TryParse(Console.ReadLine(), out end);
                try
                {
                    if (e_ == false)
                    {
                        var ex1 = new Exception("Neispravan unos, nije tocan format datuma");
                        throw ex1;
                    }
                    incorrectInput = false;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }

            incorrectInput = true;
            while (incorrectInput)
            {
                Console.WriteLine("Unesite status (aktivan, zavrsen, na cekanju): ");
                status = Console.ReadLine().Trim();
                try
                {
                    if (status == "")
                    {
                        var ex1 = new Exception("Neispravan unos, ne smije biti prazno polje");
                        throw ex1;
                    }
                    if (status!="aktivan" && status != "zavrsen" && status != "na cekanju")
                    {
                        var ex2 = new Exception("Neispravan unos, status mora biti aktivan, zavrsen ili na cekanju");
                        throw ex2;
                    }
                    if (status=="na cekanju")
                    {
                        stat_ = Status.naCekanju;
                    }
                    if (status == "zavrsen")
                    {
                        stat_ = Status.zavrsen;
                    }
                    incorrectInput = false;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }

            var new_project = new Project(title, desc, start, end, stat_);
            return new_project;
        }
        static Project Function_3(Dictionary<Project, List<Task>> dict)
        {
            Console.Clear();
            Console.WriteLine("Projekti: ");
            int idx = 1;
            foreach (var item in dict)
            {
                Console.WriteLine(idx + " - " + item.Key.title);
                idx++;
            }
            var delete = Check_Menu(dict.Count)-1;
            Project proj_ = new();
            int idx2 = 0;
            foreach (var item in dict)
            {
                if (idx2 == delete)
                {
                    proj_ = item.Key;
                    break;
                }
                else idx2++;
            }
            bool incorrectInput = true;
            bool safety = true;
            while (incorrectInput)
            {
                try 
                {
                    Console.WriteLine($"Jeste li sigurni da zelite izbrisati projekt {proj_.title} ? (Y/N)");
                    var response = Console.ReadLine().Trim();
                    if (response.ToLower()!="y" && response.ToLower()!="n")
                    {
                        var ex = new Exception("Odaberite Y za da ili N za ne");
                        throw ex;
                    }
                    if (response.ToLower()=="y")
                    {
                        safety = false;
                    }
                    incorrectInput = false;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
            if (safety)
            {
                proj_ = new();
            }
            return proj_;
        }
        static void Function_4(Dictionary<Project, List<Task>> dict)
        {
            Console.Clear();
            Console.WriteLine("Zadaci kojima je rok u sljedecih 7 dana: ");
            foreach (var item in dict)
            {
                foreach (var val in item.Value)
                {
                    var days = val.deadline - DateTime.Now;
                    if (days.TotalDays< 7 && item.Key.status == Status.aktivan)
                    {
                        Console.WriteLine($"{item.Key.title} - {val.title}  => {days.ToString()}");
                    }
                }
            }
        }
        static void Function_5(Dictionary<Project, List<Task>> dict)
        {
            Console.Clear();
            Console.WriteLine("---Prikaz projekta po statusu---");
            bool incorrectInput = true;
            var status = "";
            Status stat_=Status.aktivan;
            while (incorrectInput)
            {
                Console.WriteLine("Unesite status (aktivan, zavrsen, na cekanju) koji zelite pregledati: ");
                status = Console.ReadLine().Trim();
                try
                {
                    if (status == "")
                    {
                        var ex1 = new Exception("Neispravan unos, ne smije biti prazno polje");
                        throw ex1;
                    }
                    if (status != "aktivan" && status != "zavrsen" && status != "na cekanju")
                    {
                        var ex2 = new Exception("Neispravan unos, status mora biti aktivan, zavrsen ili na cekanju");
                        throw ex2;
                    }
                    if (status == "na cekanju")
                    {
                        stat_ = Status.naCekanju;
                    }
                    if (status == "zavrsen")
                    {
                        stat_ = Status.zavrsen;
                    }
                    incorrectInput = false;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
            foreach (var item in dict)
            {
                if (item.Key.status==stat_)
                {
                    Console.WriteLine(item.Key.title + " - " + item.Key.status);
                }
            }

        }
        static Task Add_Task(List<Task> tasklist, Project proj) 
        {
            bool incorrectInput = true;
            string title = "";
            string desc = "";
            DateTime deadline = new();
            int work_ = 0;
            string status = "";
            Status stat_ = Status.aktivan;

                while (incorrectInput)
                {
                    Console.WriteLine("Unesite titulu: ");
                    title = Console.ReadLine();
                    try
                    {
                        if (title.Trim() == "")
                        {
                            var ex1 = new Exception("Neispravan unos, ne smije biti prazno polje");
                            throw ex1;
                        }
                        bool in_list = false;
                        foreach (var item in tasklist)
                        {
                            if (item.title == title)
                            {
                                in_list = true; break;

                            }
                        }
                        if (in_list)
                        {
                            var ex2 = new Exception("Neispravan unos, projekt vec postoji");
                            throw ex2;
                        }
                        incorrectInput = false;
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.Message);
                    }
                }

                incorrectInput = true;
                while (incorrectInput)
                {
                    Console.WriteLine("Unesite opis: ");
                    desc = Console.ReadLine();
                    try
                    {
                        if (desc.Trim() == "")
                        {
                            var ex1 = new Exception("Neispravan unos, ne smije biti prazno polje");
                            throw ex1;
                        }
                        incorrectInput = false;
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.Message);
                    }
                }

                incorrectInput = true;
                while (incorrectInput)
                {
                    Console.WriteLine("Unesite datum roka (DD/MM/GGGG): ");
                    var d = DateTime.TryParse(Console.ReadLine(), out deadline);
                    try
                    {
                        if (d == false)
                        {
                            var ex1 = new Exception("Neispravan unos, nije tocan format datuma");
                            throw ex1;
                        }
                        incorrectInput = false;
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.Message);
                    }
                }

                incorrectInput = true;
                while (incorrectInput)
                {
                    Console.WriteLine("Unesite trajanje u minutama: ");
                    var mins = int.TryParse(Console.ReadLine(), out work_);
                    try
                    {
                        if (mins == false)
                        {
                            var ex1 = new Exception("Neispravan unos, nije tocan format, treba biti cijeli broj");
                            throw ex1;
                        }
                    if (work_<=0)
                    {
                        var ex2 = new Exception("Neispravan unos, nije tocan format, treba biti NENEGATIVAN cijeli broj, odnosno prirodni broj");
                        throw ex2;

                    }
                        incorrectInput = false;
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.Message);
                    }
                }

                incorrectInput = true;
                while (incorrectInput)
                {
                    Console.WriteLine("Unesite status (aktivan, zavrsen, na cekanju): ");
                    status = Console.ReadLine().Trim();
                    try
                    {
                        if (status == "")
                        {
                            var ex1 = new Exception("Neispravan unos, ne smije biti prazno polje");
                            throw ex1;
                        }
                        if (status != "aktivan" && status != "zavrsen" && status != "na cekanju")
                        {
                            var ex2 = new Exception("Neispravan unos, status mora biti aktivan, zavrsen ili na cekanju");
                            throw ex2;
                        }
                        if (status == "na cekanju")
                        {
                            stat_ = Status.naCekanju;
                        }
                        if (status == "zavrsen")
                        {
                            stat_ = Status.zavrsen;
                        }
                        incorrectInput = false;
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.Message);
                    }
                }

                var new_task = new Task(title, desc, deadline ,work_, stat_,proj);
                return new_task;
            
        }
        static void Function_6(Dictionary<Project, List<Task>> dict, int choice) 
        {
            Console.Clear();

            Console.WriteLine("Odaberite projekt: ");
            var idx = 1;
            foreach (var item in dict)
            {
                Console.WriteLine(idx + " - " + item.Key.title);
                idx++;
            }
            var show = Check_Menu(dict.Count) - 1;
            int idx2 = 0;
            switch (choice)
            {
                case 1:
                    //show tasks
                    foreach (var item in dict)
                    {
                        if (idx2 == show)
                        {
                            foreach (var val in item.Value)
                            {
                                Console.WriteLine(val.title+" - "+val.description+" - "+val.status);
                            }
                            break;
                        }
                        else idx2++;
                    }
                    break;
                case 2:
                    //show details
                    foreach (var item in dict)
                    {
                        if (idx2 == show)
                        {
                            var key = item.Key;
                            Console.WriteLine($"Naslov: {key.title}\n" +
                                $"Opis: {key.description}\nPocetak: {key.start_time}\n" +
                                $"Kraj: {key.end_time}\nStatus: {key.status}");
                            break;
                        }
                        else idx2++;
                    }
                    break;
                case 3:
                    //edit status
                    foreach (var item in dict)
                    {
                        if (idx2 == show)
                        {
                            Console.WriteLine("Odaberite novi status: ");
                            var key = item.Key;
                            switch (key.status)
                            {
                                case Status.aktivan:
                                    Console.WriteLine("1) Na cekanju\n2) Zavrsen");
                                    var s = Check_Menu(2);
                                    if (s==1)
                                    {
                                        key.status = Status.naCekanju;
                                    }
                                    else {
                                        key.status = Status.zavrsen;
                                        foreach (var val in item.Value)
                                        {
                                            val.status = Status.zavrsen;
                                        }
                                    }
                                    break;
                                case Status.naCekanju:

                                    Console.WriteLine("1) Aktivan\n2) Zavrsen");
                                    s= Check_Menu(2);
                                    if (s == 1)
                                    {
                                        key.status = Status.aktivan;
                                    }
                                    else {
                                        key.status = Status.zavrsen;
                                        foreach (var val in item.Value)
                                        {
                                            val.status = Status.zavrsen;
                                        }
                                    }
                                    break;
                                case Status.zavrsen:
                                    Console.WriteLine("Projekt je zavrsen. Status se ne moze mijenjati.");
                                    break;
                                default:
                                    break;
                            }
                            break;
                        }
                        else idx2++;
                    }
                    break;
                case 4:
                    //add task
                    foreach (var item in dict)
                    {
                        if (idx2 == show)
                        {
                            var new_task = Add_Task(item.Value,item.Key);
                            item.Value.Add(new_task);
                            break;
                        }
                        else idx2++;
                    }
                    break;
                case 5:
                    //delete task
                    foreach (var item in dict) 
                    {
                        if (idx2 == show)
                        {
                            Console.WriteLine("Odaberite zadatak po broju: ");
                            for (int i = 0; i < item.Value.Count; i++)
                            {
                                Console.WriteLine($"{i + 1}) {item.Value[i].title}");
                            }
                            var ind = Check_Menu(item.Value.Count) - 1;
                            item.Value.RemoveAt(ind);
                            break;
                        }
                        else idx2++;
                    }
                    break;
                case 6:
                    //show time needed to finish all active tasks
                    foreach (var item in dict)
                    {
                        if (idx2 == show)
                        {
                            var time_left = 0;
                            foreach (var val in item.Value)
                            {
                                if (val.status == Status.aktivan)
                                {
                                    time_left += val.workload;
                                }
                            }
                            Console.WriteLine("Vrijeme potrebna za dovrsavanje zadataka: " + time_left + " minuta");
                            break;
                        }
                        else idx2++;
                    }
                    break;
                default:
                    break;
            }
        }
        static void Function_7(Dictionary<Project, List<Task>> dict, int choice)
        {

            Console.Clear();

            Console.WriteLine("Odaberite projekt: ");
            var idx = 1;
            foreach (var item in dict)
            {
                Console.WriteLine(idx + " - " + item.Key.title);
                idx++;
            }
            var show = Check_Menu(dict.Count) - 1;
            int idx2 = 0;
            List<Task> tasklist = new();
            var idx3 = 1;
            foreach (var item in dict)
            {
                if (idx2 == show)
                {
                    tasklist = item.Value;
                    foreach (var val in item.Value)
                    {
                        Console.WriteLine(idx3 +" - "+ val.title);
                        idx3++;
                    }
                    break;
                }
                else idx2++;
            }
            int choice_task = Check_Menu(tasklist.Count)-1;
            var task = tasklist[choice_task];
            switch (choice)
            {
                case 1:
                    Console.WriteLine($"Naslov: {task.title}\n" +
                    $"Opis: {task.description}\nRok: {task.deadline}\n" +
                    $"Trajanje: {task.workload} minuta\nStatus: {task.status.ToString()}");
                    break;
                case 2:
                    Console.WriteLine("Odaberite novi status: ");
                    switch (task.status)
                    {
                        case Status.aktivan:
                            Console.WriteLine("1) Na cekanju\n2) Zavrsen");
                            var s = Check_Menu(2);
                            if (s == 1)
                            {
                                task.status = Status.naCekanju;
                            }
                            else
                            {
                                task.status = Status.zavrsen;
                            }
                            break;
                        case Status.naCekanju:

                            Console.WriteLine("1) Aktivan\n2) Zavrsen");
                            s = Check_Menu(2);
                            if (s == 1)
                            {
                                task.status = Status.aktivan;
                            }
                            else
                            {
                                task.status = Status.zavrsen;
                            }
                            break;
                        case Status.zavrsen:
                            Console.WriteLine("Ovaj zadatak je zavrsen. Status se ne moze mijenjati.");
                            break;
                        default:
                            break;
                    }
                    for (int i = 0; i < dict.Count; i++)
                    {
                        if (i == show)
                        {
                            var title_ = dict.ElementAt(i).Key;
                            dict[title_] = tasklist;
                            for(int j = 0; j < tasklist.Count; j++)
                            {
                                if (tasklist[j].status!=Status.zavrsen)
                                {
                                    break;
                                }
                                else
                                {
                                    if (j==tasklist.Count-1 && tasklist[j].status==Status.zavrsen)
                                    {
                                        title_.status = Status.zavrsen;
                                    }
                                }
                            }
                            break;
                        }
                        else continue;
                    }
                    break;
                default:
                    break;
            }
        }

        static void Functions_Choice(int main_choice,string[] sub_menu_6, string[] sub_menu_7, Dictionary<Project, List<Task>> dict_)
        {
            switch (main_choice)
            {
                case 1:
                    //option 1 - list projects + related tasks
                    Function_1(dict_);
                    break;
                case 2:
                    //option 2 - add new project
                    var new_project=Function_2(dict_);
                    var task_list = new List<Task>();
                    dict_.Add(new_project, task_list);
                    Go_Back(dict_);
                    break;
                case 3:
                    //option 3 - delete project
                    var project_delete=Function_3(dict_);
                    dict_.Remove(project_delete);
                    Go_Back(dict_);
                    break;
                case 4:
                    //option 4 - show all tasks with deadline within the next 7 days
                    Function_4(dict_);
                    Go_Back(dict_);
                    break;
                case 5:
                    //option 5 - show projects filtered by status
                    Function_5(dict_);
                    Go_Back(dict_);
                    break;
                case 6:
                    //option 6 - editing specific project
                    Console.WriteLine("Podizbornik: ");
                    for (int i = 0; i < sub_menu_6.Length; i++)
                    {
                        Console.WriteLine($"{i + 1}) {sub_menu_6[i]}");
                    }
                    var sub_6_choice = Check_Menu(sub_menu_6.Length);
                    Function_6(dict_,sub_6_choice);
                    Go_Back(dict_);
                    break;
                case 7:
                    //option 7 - editing specific task
                    Console.WriteLine("Podizbornik: ");
                    for (int i = 0; i < sub_menu_7.Length; i++)
                    {
                        Console.WriteLine($"{i + 1}) {sub_menu_7[i]}");
                    }
                    var sub_7_choice = Check_Menu(sub_menu_7.Length);
                    Function_7(dict_, sub_7_choice);
                    Go_Back(dict_); 
                    break;
                case 8:
                    Console.BackgroundColor = ConsoleColor.Yellow;
                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.Clear();
                    Console.WriteLine("Dovidenja! Pritisnite bilo koju tipku za izlaz.");
                    Environment.Exit(0);
                    break;
                default:
                    break;
            }
        }
        static void Start(Dictionary<Project, List<Task>> dict_start) 
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

            Functions_Choice(main_choice, sub_menu_6, sub_menu_7,dict_start);
        }

        static void Main(string[] args)
        {
            //loading starting dictionary
            var dict_start = GetStarted();
            Start(dict_start);
        }
    }
}
