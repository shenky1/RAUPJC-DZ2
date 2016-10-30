using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zad3_4_5
{
    public class Student
    {
        public string Name { get; set; }
        public string Jmbag { get; set; }
        public Gender Gender { get; set; }
        public Student(string name, string jmbag, Gender gender)
        {
            Name = name;
            Jmbag = jmbag;
            Gender = gender;
        }

        public override string ToString()
        {
            return "Person: " + Jmbag + " " + Name + " " + Gender;
        }

        public override bool Equals(Object stud)
        {
            if (this.Jmbag == ((Student)stud).Jmbag) return true;
            else return false;
        }

        public override int GetHashCode()
        {
            int hashName = Name == null ? 0 : Name.GetHashCode();
            int hashJmbag = Jmbag == null ? 0 : Jmbag.GetHashCode();

            int hash = hashName ^ hashJmbag;
            return hash;

        }
    }
  
    public enum Gender
    {
        Male, Female
    }

    
}
