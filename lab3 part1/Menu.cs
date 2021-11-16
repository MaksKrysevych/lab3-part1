using System;
using System.Collections.Generic;
using System.IO;

namespace lab3_part1
{
    class Menu
    {
        List<Student> students = new List<Student>();
        Object s = null;

        public void MainMenu()
        {
            Console.WriteLine("Main menu:");
            Console.WriteLine("1. Actions with class");
            Console.WriteLine("2. Actions with serealization");
            Console.WriteLine("3. Close menu");

            int option = Convert.ToInt32(Console.ReadLine());
            switch (option)
            {
                case 1:
                    {
                        Console.Clear();
                        FirstMenu();
                        break;
                    }
                case 2:
                    {
                        Console.Clear();
                        SecondMenu();
                        break;
                    }
                case 3:
                    {
                        break;
                    }
                default:
                    break;
            }
        }
        public void FirstMenu()
        {
            bool WorkingOfMenu = true;
            while (WorkingOfMenu)
            {
                Console.WriteLine("Operations:");
                Console.WriteLine("1. Add student");
                Console.WriteLine("2. Delete student");
                Console.WriteLine("3. Show students");
                Console.WriteLine("4. Update course of student");
                Console.WriteLine("5. Close menu");
                EntityContext ec = new EntityContext();
                EntityService es = new EntityService();
                int option = Convert.ToInt32(Console.ReadLine());
                switch (option)
                {
                    case 1:
                        {
                            es.AddStudent(students);
                            ec.AddInfo(students);
                            break;
                        }
                    case 2:
                        {
                            es.DeleteStudent(students);
                            ec.DeleteAllInfo();
                            ec.AddInfo(students);
                            break;
                        }
                    case 3:
                        {
                            es.ShowInfo(students);
                            break;
                        }
                    case 4:
                        {
                            es.UpdateStudent(students);
                            ec.DeleteAllInfo();
                            ec.AddInfo(students);
                            break;
                        }
                    case 5:
                        {
                            WorkingOfMenu = false;
                            Console.Clear();
                            MainMenu();
                            break;
                        }
                    default:
                        break;
                }
            }
        }
        public void SecondMenu()
        {
            bool WorkingOfMenu = true;
            while (WorkingOfMenu)
            {
                Console.WriteLine("Operations:");
                Console.WriteLine("1. Binary serealization");
                Console.WriteLine("2. XML-serealization");
                Console.WriteLine("3. JSON serealization");
                Console.WriteLine("4. Custom serealization");
                Console.WriteLine("5. Close menu");
                int option = Convert.ToInt32(Console.ReadLine());
                switch (option)
                {
                    case 1:
                        {
                            BinaryProvider binary = new BinaryProvider();
                            binary.BinarySerialization(students);
                            break;
                        }
                    case 2:
                        {
                            XMLProvider xml = new XMLProvider();
                            xml.XMLSerialization(students);
                            break;
                        }
                    case 3:
                        {
                            JSONProvider json = new JSONProvider();
                            json.JSONSerialization(students);
                            break;
                        }
                    case 4:
                        {
                            CustomProvider custom = new CustomProvider();
                            custom.CustomSerialize(typeof(Student), students, "custom.txt");
                            s = custom.CustomDeserialize(typeof(Student), "custom.txt") as Student;

                            break;
                        }
                    case 5:
                        {
                            WorkingOfMenu = false;
                            Console.Clear();
                            MainMenu();
                            break;
                        }
                    default:
                        break;
                }
            }
        }
    }
}
