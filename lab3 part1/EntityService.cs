using System;
using System.Collections.Generic;

namespace lab3_part1
{
    class EntityService
    {

        public void AddStudent(List<Student> students)
        {
            Console.WriteLine("Count of persons: ");
            int value = Convert.ToInt32(Console.ReadLine());
            for (int i = 0; i < value; i++)
            {
                Console.WriteLine("Lastname");
                string lastname = Console.ReadLine();
                Console.WriteLine("Name:");
                string name = Console.ReadLine();
                Console.WriteLine("ID:");
                int id = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Birthday:");
                string birthday = Console.ReadLine();
                Console.WriteLine("Course:");
                int course = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Group:");
                int group = Convert.ToInt32(Console.ReadLine());

                DateTime birth = DateTime.Parse(birthday);
                DateTime today = DateTime.Today;
                int age = today.Year - birth.Year;

                students.Add(new Student(id, lastname, name, birthday, age, course, group));
            }
        }
        public void DeleteStudent(List<Student> students)
        {
            Console.WriteLine("ID of student:");
            int key = int.Parse(Console.ReadLine());
            students.Remove(students.Find(r => r.ID == key));
        }
        public void ShowInfo(List<Student> students)
        {
            foreach (Student s in students)
            {
                Console.WriteLine("ID: " + s.ID);
                Console.WriteLine("Lastname: " + s.LastName);
                Console.WriteLine("Firstname: " + s.Name);
                Console.WriteLine("Birthday: " + s.Birthday);
                Console.WriteLine("Age: " + s.Age);
                Console.WriteLine("Course: " + s.Course);
                Console.WriteLine("Group: " + s.Group);
                Console.WriteLine();
            }
        }
        public void UpdateStudent(List<Student> students)
        {
            Console.WriteLine("ID of student:");
            var key = int.Parse(Console.ReadLine());
            if (students.Contains(students.Find(r => r.ID == key)))
            {
                Console.WriteLine("New course:");
                var NewCourse = int.Parse(Console.ReadLine());
                students[students.FindIndex(r => r.ID == key)].Course = NewCourse;
            }
            else
            {
                Console.WriteLine("Not exist");
            }
        }
    }
}

