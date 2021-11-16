using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace lab3_part1
{
    class BinaryProvider
    {
        public void BinarySerialization(List<Student> students)
        {
            BinaryFormatter binFormatter = new BinaryFormatter();
            using (var file = new FileStream("students.bin", FileMode.OpenOrCreate))
            {
                binFormatter.Serialize(file, students);
            }

            using (var file = new FileStream("students.bin", FileMode.OpenOrCreate))
            {
                var newStudents = binFormatter.Deserialize(file) as List<Student>;

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
