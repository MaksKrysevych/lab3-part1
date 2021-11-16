using System;
using System.Runtime.Serialization;

namespace lab3_part1
{
    [Serializable] [DataContract]
    public class Student
    {
        [DataMember]
        public int ID { get; set; }
        [DataMember]
        public string LastName { get; set; }
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public string Birthday { get; set; }
        [DataMember]
        public int Age { get; set; }
        [DataMember]
        public int Course { get; set; }
        [DataMember]
        public int Group { get; set; }

        public Student(int id, string lastname, string name, string birthday, int age, int course, int group)
        {
            ID = id;
            LastName = lastname;
            Name = name;
            Birthday = birthday;
            Age = age;
            Course = course;
            Group = group;
        }

        public Student()
        {
        }
    }
}
