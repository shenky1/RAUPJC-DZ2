using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zad3_4_5
{
    class Program
    {
        static void Main(string[] args)
        {
            var integers = new[] { 1, 2, 2, 2, 3, 3, 4, 5 };
            var data = integers.GroupBy(x => x).Distinct().ToArray();
            var strings = new string[data.Length];
            foreach (var n in data)
            {
                strings[n.Key - 1] = $"Broj {n.Key} ponavlja se {n.Count()} puta";
                Console.Out.WriteLine(strings[n.Key - 1]);
            }

            Example1();
            Example2();

            var universities = GetAllCroatianUniversities();

            var allCroatianStudents = universities.SelectMany(b => b.Students).Distinct().ToArray();
            var croatianStudentsOnMultipleUniversities = universities.SelectMany(b => b.Students)
                .GroupBy(s => s)
                .Where(sG => sG.Count() > 1)
                .Select(sG => sG.Key).ToArray();
            var studentsOnMaleOnlyUniversities = universities.Where(u => u.Students.All(s => s.Gender != Gender.Female))
                .SelectMany(b => b.Students).Distinct().ToArray();

            Console.Out.WriteLine("All Croatian students :");
            foreach (var student in allCroatianStudents)
                if ((bool)(student != null)) Console.Out.WriteLineAsync(student.ToString());
            Console.Out.WriteLine();

            Console.Out.WriteLine("Croatian students on multiple universities :");
            foreach (var student in croatianStudentsOnMultipleUniversities)
                if ((bool)(student != null)) Console.Out.WriteLineAsync(student.ToString());
            Console.Out.WriteLine();

            Console.Out.WriteLine("Students on male only universities :");
            foreach (var student in studentsOnMaleOnlyUniversities)
                if ((bool)(student != null)) Console.Out.WriteLineAsync(student.ToString());

            Console.ReadLine();
        }

        private static void Example1()
        {
            var list = new List<Student>()
            {
            new Student ("Ivan","001234567", Gender.Male)
            };
            var ivan = new Student("Ivan", "001234567", Gender.Male);
            // false :(
            bool anyIvanExists = list.Any(s => s.Equals(ivan));
            Console.Out.WriteLine(anyIvanExists);
        }

        private static void Example2()
        {
            var list = new List<Student>
            {
                new Student("Ivan", "001234567", Gender.Male),
                new Student("Ivan", "001234567", Gender.Male),
                new Student("Ivan", "001234567", Gender.Male)
            };
            var distinctStudents = list.Distinct().Count();
            Console.Out.WriteLine(distinctStudents);
        }



        private static IEnumerable<University> GetAllCroatianUniversities()
        {
            var zagreb = new University { Name = "Zagreb" };
            var rijeka = new University { Name = "Rijeka" };
            var split = new University { Name = "Split" };

            var matija = new Student("Matija", "23", Gender.Male);
            var karlo = new Student("Karlo", "26", Gender.Male);
            var josipa = new Student("Josipa", "22", Gender.Female);
            var martin = new Student("Martin", "19", Gender.Male);
            var stefica = new Student("Štefica", "20", Gender.Female);
            var antonio = new Student("Antonio", "22", Gender.Male);

            zagreb.Students = new[] { matija, karlo, josipa };
            rijeka.Students = new[] { stefica, martin };
            split.Students = new[] { antonio, martin };

            return new[] { zagreb, rijeka, split };
        }
    }
}