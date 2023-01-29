using Labb_3_Anropa_Databasen_SQL_och_ORM.Models;
using System.Linq;

namespace Labb_3_Anropa_Databasen_SQL_och_ORM
{
    internal class Program
    {
        static void Main(string[] args)
        {
            RunProgram();


            //SchoolDbContext context = new SchoolDbContext();

            // 1:
            //Hämta alla elever (ska lösas med Entity framwork)
            //Användaren får välja om de vill se eleverna sorterade på för- eller efternamn
            //och om det ska vara stigande eller fallande sortering.

            //var allStudents = context.Students
            //    .Where(p => p.StudentId > 0)
            //    .OrderBy(p => p.FirstName);

            //foreach (Student item in allStudents)
            //{
            //    Console.WriteLine($"Name: {item.FirstName} {item.LastName}");
            //}

            //Console.ReadLine();

            /* 2 : 
            - [ ]  Hämta alla elever i en viss klass (ska lösas med Entity framework)
            Användaren ska först få se en lista med alla klasser som finns, 
            sedan får användaren välja en av klasserna och då skrivs alla elever i den klassen ut.
            Extra utmaning: låt användaren även få välja sortering på eleverna som i punkten ovan.
            */

            //var allClasses = context.Students
            //    .Where(p => p.StudentId > 0)
            //    .OrderBy(p => p.Class);

            //Student lastItem = new Student();

            ////Skriver ut alla existerande klasser
            //foreach (Student item in allClasses)
            //{
            //    if (lastItem.Class != item.Class)
            //    {
            //        lastItem = item;
            //        Console.WriteLine($"klasser: {lastItem.Class} ");
            //    }
            //}


            /*
             - [ ]  Lägga till ny personal (ska lösas genom Entity framework)
            Användaren får möjlighet att mata in uppgifter om en ny anställd och den datan sparas då ner i databasen.
            */
            //Exempel
            //Staff S1 = new Staff()
            //{
            //    FirstName = "Majje",
            //    LastName = "Karlsson",
            //    PersonalId = "921102-4511",
            //    Adress = "Eftra pl517",
            //    City = "Slange",
            //    Phone = "0708491827",
            //    Email = "Maj@gmail.com",

            //};

            //context.Staff.Add(S1);

            //context.SaveChanges();

        }

        public static void RunProgram()
        {
            RunMenu();

        }

        public static void RunMenu()
        {
            Console.WriteLine("Choose an option:");
            Console.WriteLine("1. List all students");
            Console.WriteLine("2. List all students of a certain class");
            Console.WriteLine("3. Add new staff");

            int choice = Convert.ToInt32(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    GetAllStudents();
                    break;
                case 2:
                    Console.WriteLine("You chose Option 2");
                    break;
                case 3:
                    Console.WriteLine("You chose Option 3");
                    break;
                default:
                    Console.WriteLine("Invalid option. Please try again.");
                    break;
            }
        }

        public static void GetAllStudents()
        {
            SchoolDbContext context = new SchoolDbContext();

            //var allStudents = context.Students
            //    .Where(p => p.StudentId > 0)
            //    .OrderBy(p => p.FirstName);


            var allStudents = context.Students
                .Where(p => p.StudentId > 0);

            Console.WriteLine("Sort by first name (1) or last name (2)?");
            int sortBy = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Sort by ascending (1) or descending (2) order?");
            int sortOrder = Convert.ToInt32(Console.ReadLine());


            switch (sortBy)
            {
                case 1:
                    switch (sortOrder)
                    {
                        case 1:
                            allStudents = allStudents.OrderBy(p => p.FirstName);
                            break;
                        case 2:
                            allStudents = allStudents.OrderByDescending(p => p.FirstName);
                            break;
                        default:
                            Console.WriteLine("Invalid option. Sorting by ascending order by default.");
                            allStudents = allStudents.OrderBy(p => p.FirstName);
                            break;
                    }
                    break;
                case 2:
                    switch (sortOrder)
                    {
                        case 1:
                            allStudents = allStudents.OrderBy(p => p.LastName);
                            break;
                        case 2:
                            allStudents = allStudents.OrderByDescending(p => p.LastName);
                            break;
                        default:
                            Console.WriteLine("Invalid option. Sorting by ascending order by default.");
                            allStudents = allStudents.OrderBy(p => p.LastName);
                            break;
                    }
                    break;
                default:
                    Console.WriteLine("Invalid option. Sorting by first name in ascending order by default.");
                    allStudents = allStudents.OrderBy(p => p.FirstName);
                    break;


            }
            foreach (Student item in allStudents)
            {
                Console.WriteLine($"Name: {item.FirstName} {item.LastName}");
            }

        }
    }
}