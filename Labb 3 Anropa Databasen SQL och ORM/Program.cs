using Labb_3_Anropa_Databasen_SQL_och_ORM.Models;
using System.Linq;

namespace Labb_3_Anropa_Databasen_SQL_och_ORM
{
    internal class Program
    {
        static void Main(string[] args)
        {
            SchoolDbContext context = new SchoolDbContext();

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

            var allClasses = context.Students
                .Where(p => p.StudentId > 0)
                .OrderBy(p => p.Class);

            Student lastItem = new Student();

            //Skriver ut alla existerande klasser
            foreach (Student item in allClasses)
            {
                if (lastItem.Class != item.Class)
                {
                    lastItem = item;
                    Console.WriteLine($"klasser: {lastItem.Class} ");
                }
            }


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
    }
}