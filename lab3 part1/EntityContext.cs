using System;
using System.Collections.Generic;
using System.IO;

namespace lab3_part1
{
    class EntityContext
    {
        public readonly string path;

        public EntityContext()
        {
            path = Directory.GetCurrentDirectory() + "\\text.txt";
        }

        public bool DeleteAllInfo()
        {
            try
            {
                StreamWriter sw = new StreamWriter(path, false, System.Text.Encoding.UTF8);
                sw.Close();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return true;
        }

        public bool AddInfo(List<Student> students)
        {
            try
            {
                FileInfo FileInfo = new FileInfo(path);
                if (!FileInfo.Exists)
                {
                    FileInfo.Create();
                }

                using (StreamWriter sw = new StreamWriter(path, true, System.Text.Encoding.Unicode))
                {
                    foreach (Student s in students)
                    {
                        sw.WriteLine("ID: " + s.ID);
                        sw.WriteLine("Lastname: " + s.LastName);
                        sw.WriteLine("Firstname: " + s.Name);
                        sw.WriteLine("Birthday: " + s.Birthday);
                        sw.WriteLine("Age: " + s.Age);
                        sw.WriteLine("Course: " + s.Course);
                        sw.WriteLine("Group: " + s.Group);
                        sw.WriteLine();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return true;

        }
    }
}
