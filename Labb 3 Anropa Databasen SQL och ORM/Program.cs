using Labb_3_Anropa_Databasen_SQL_och_ORM.Models;
using System.Linq;

namespace Labb_3_Anropa_Databasen_SQL_och_ORM
{
    internal class Program
    {
        static void Main(string[] args)
        {
            RunProgram();
        }

        public static void RunProgram()
        {
            RunMenu();
        }

        public static void RunMenu()
        {
            bool isLooping = true;

            while (isLooping)
            {
                Console.Clear();

                Console.WriteLine("Choose an option:");
                Console.WriteLine("1. List all students");
                Console.WriteLine("2. List all students of a certain class");
                Console.WriteLine("3. Add new staff");
                Console.WriteLine("4. View all staffmembers");
                Console.WriteLine("5. Exit program");

                int choice = Convert.ToInt32(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        GetAllStudents();
                        PressAnyKeyToContinue();
                        break;
                    case 2:
                        GetStudentsOfClass();
                        PressAnyKeyToContinue();
                        break;
                    case 3:
                        AddNewStaff();
                        PressAnyKeyToContinue();
                        break;
                    case 4:
                        GetAllStaff();
                        PressAnyKeyToContinue();
                        break;

                    case 5:
                        isLooping = false;
                        break;

                    default:
                        Console.WriteLine("Invalid option. Please try again.");
                        break;
                }

            }
        }

        public static void GetAllStudents()
        {
            SchoolDbContext context = new SchoolDbContext();

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
                Console.WriteLine($"{item.StudentId}. {item.FirstName} {item.LastName} | PersonalId: {item.PersonalId}" +
                    $" | Adress: {item.Adress} | City: {item.City} | Phone: {item.City} | Email: {item.Email}");
            }

        }

        public static void GetStudentsOfClass()
        {
            SchoolDbContext context = new SchoolDbContext();

            Console.WriteLine("Sort by first name (1) or last name (2)?");
            int sortBy = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Sort by ascending (1) or descending (2) order?");
            int sortOrder = Convert.ToInt32(Console.ReadLine());

            var allClasses = context.Students
                .Where(p => p.StudentId > 0)
                .OrderBy(p => p.Class);

            Student lastItem = new Student();

            //Skriver ut all existerande klasser på skolan
            Console.WriteLine("Existing Classes:");
            foreach (Student item in allClasses)
            {
                if (lastItem.Class != item.Class)
                {
                    lastItem = item;
                    Console.WriteLine($"{lastItem.Class}");
                }
            }

            Console.WriteLine("\nWhich class do you want to view?");
            string selectedClass = Console.ReadLine();

            var studentsInClass = context.Students
                .Where(p => p.Class == selectedClass);

            switch (sortBy)
            {
                case 1:
                    switch (sortOrder)
                    {
                        case 1:
                            studentsInClass = studentsInClass.OrderBy(p => p.FirstName);
                            break;
                        case 2:
                            studentsInClass = studentsInClass.OrderByDescending(p => p.FirstName);
                            break;
                        default:
                            Console.WriteLine("Invalid option. Sorting by ascending order by default.");
                            studentsInClass = studentsInClass.OrderBy(p => p.FirstName);
                            break;
                    }
                    break;
                case 2:
                    switch (sortOrder)
                    {
                        case 1:
                            studentsInClass = studentsInClass.OrderBy(p => p.LastName);
                            break;
                        case 2:
                            studentsInClass = studentsInClass.OrderByDescending(p => p.LastName);
                            break;
                        default:
                            Console.WriteLine("Invalid option. Sorting by ascending order by default.");
                            studentsInClass = studentsInClass.OrderBy(p => p.LastName);
                            break;
                    }
                    break;
                default:
                    Console.WriteLine("Invalid option. Sorting by first name in ascending order by default.");
                    studentsInClass = studentsInClass.OrderBy(p => p.FirstName);
                    break;
            }

            Console.WriteLine($"\nStudents in class {selectedClass}:");
            foreach (Student item in studentsInClass)
            {
                Console.WriteLine($"Name: {item.FirstName} {item.LastName}");
            }


        }

        public static void AddNewStaff()
        {
            SchoolDbContext context = new SchoolDbContext();

            Staff newStaff = new Staff()
            {
                FirstName = "",
                LastName = "",
                PersonalId = "",
                Adress = "",
                City = "",
                Phone = "",
                Email = "",
                Position = "",
            };

            Console.WriteLine("Enter first name: ");
            newStaff.FirstName = Console.ReadLine();
            Console.WriteLine("Enter last name: ");
            newStaff.LastName = Console.ReadLine();
            Console.WriteLine("Enter personal ID: ");
            newStaff.PersonalId = Console.ReadLine();
            Console.WriteLine("Enter address: ");
            newStaff.Adress = Console.ReadLine();
            Console.WriteLine("Enter city: ");
            newStaff.City = Console.ReadLine();
            Console.WriteLine("Enter phone: ");
            newStaff.Phone = Console.ReadLine();
            Console.WriteLine("Enter email: ");
            newStaff.Email = Console.ReadLine();

            context.Staff.Add(newStaff);
            context.SaveChanges();
            Console.WriteLine("New staff member added successfully.");

        }

        public static void GetAllStaff()
        {
            SchoolDbContext context = new SchoolDbContext();

            var allStaff = context.Staff
                .Where(p => p.StaffId > 0);

            foreach (Staff item in allStaff)
            {
                Console.WriteLine($"{item.StaffId}. {item.FirstName} {item.LastName} | PersonalId: {item.PersonalId}" +
                    $" | Adress: {item.Adress} | City: {item.City} | Phone: {item.City} | Email: {item.Email} | Position: {item.Position}");
            }

        }

        public static void PressAnyKeyToContinue()
        {
            Console.WriteLine();
            Console.WriteLine("Press any key to continue");
            
            Console.ReadLine();
        }


    }

}