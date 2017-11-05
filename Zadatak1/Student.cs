using System;
using System.Collections.Generic;
using System.Linq;

namespace Zadatak1
{
    public class Student
    {
        protected bool Equals(Student other)
        {
            return string.Equals(Name, other.Name) && string.Equals(Jmbag, other.Jmbag);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((Student) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return ((Name != null ? Name.GetHashCode() : 0) * 397) ^ (Jmbag != null ? Jmbag.GetHashCode() : 0);
            }
        }

        public string Name { get; set; }
        public string Jmbag { get; set; }

        public Gender Gender { get; set; }

        public Student(string name, string jmbag)
        {
            Name = name;
            Jmbag = jmbag;
        }

        public static bool operator==(Student student1, Student student2)
        {
            return student1.Name == student2.Name && student1.Jmbag == student2.Jmbag;
        }

        public static bool operator !=(Student student1, Student student2)
        {
            return !(student1.Name == student2.Name && student1.Jmbag == student2.Jmbag);
        }

        public static void Case1()
        {
            var topStudents = new List<Student>
            {
                new Student (" Ivan ", jmbag :" 001234567 ") ,
                new Student (" Luka ", jmbag :" 3274272 ") ,
                new Student ("Ana", jmbag :" 9382832 ")
            };
            var ivan = new Student(" Ivan ", jmbag: " 001234567 ");
            // false :(
            bool isIvanTopStudent = topStudents.Contains(ivan);
            Console.WriteLine(isIvanTopStudent);
        }
        public static void Case2()
        {
            var list = new List<Student>
            {
                new Student (" Ivan ", jmbag :" 001234567 ") ,
                new Student (" Ivan ", jmbag :" 001234567 ")
            };
            // 2 :(
            var distinctStudentsCount = list.Distinct().Count();
            Console.WriteLine(distinctStudentsCount);
        }
        public static void Case3()
        {
            var topStudents = new List<Student>
            {
                new Student (" Ivan ", jmbag :" 001234567 ") ,
                new Student (" Luka ", jmbag :" 3274272 ") ,
                new Student ("Ana", jmbag :" 9382832 ")
            };
            var ivan = new Student(" Ivan ", jmbag: " 001234567 ");
            // false :(
            // == operator is a different operation from . Equals ()
            // Maybe it isn ’t such a bad idea to override it as well
            bool isIvanTopStudent = topStudents.Any(s => s == ivan);
            Console.WriteLine(isIvanTopStudent);
        }
    }
    public enum Gender
    {
        Male, Female
    }
    


}
