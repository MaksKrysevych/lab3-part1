using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;

namespace lab3_part1
{
    class XMLProvider
    {
        public void XMLSerialization(List<Student> students)
        {
            XmlSerializer xmlFormatter = new XmlSerializer(typeof(List<Student>));
            using (var file = new FileStream("students.xml", FileMode.OpenOrCreate))
            {
                xmlFormatter.Serialize(file, students);
            }

            using (var file = new FileStream("students.xml", FileMode.OpenOrCreate))
            {
                var newStudents = xmlFormatter.Deserialize(file) as List<Student>;

                if (newStudents != null)
                {
                    foreach (var student in newStudents)
                    {
                        Console.WriteLine(student);
                    }
                }
            }
        }
    }
}
