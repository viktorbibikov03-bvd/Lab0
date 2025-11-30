using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace ConsoleApp111
{
    internal class Lab_7_1
    {
        public class StudentJournal
        {
            private static readonly string[] FirstNames = { "Борис", "Григорий", "Евгений", "Кирилл", "Михаил" };

            private static readonly string[] LastNames = { "Иванов", "Сидоров", "Смирнов", "Михайлов", "Николаев", "Морозов" };

            private static readonly string[] Letters = { "А", "Б", "В" };
            public struct Student
            {
                public string FirstName { get; set; }
                public string LastName { get; set; }
                public string Class { get; set; }

                public override string ToString()
                {
                    return $"{LastName} {FirstName}, {Class} класс";
                }
            }

            public static List<Student> GenerateJournal(int n)
            {
                var random = new Random();
                var journal = new List<Student>();

                for (int i = 0; i < n; i++)
                {
                    var student = new Student
                    {
                        FirstName = FirstNames[random.Next(FirstNames.Length)],
                        LastName = LastNames[random.Next(LastNames.Length)],
                        Class = $"{random.Next(1, 12)}{Letters[random.Next(Letters.Length)]}"
                    };

                    journal.Add(student);
                }

                return journal;
            }

            static void Main(string[] args)
            {
                Console.Write("Введите число учеников в классе: ");
                int n = int.Parse(Console.ReadLine());

                var journal = GenerateJournal(n);

                foreach (var student in journal)
                {
                    Console.WriteLine(student);
                }

                var duplicates = journal.GroupBy(p => new { p.LastName, p.FirstName }).Where(g => g.Count() > 1).Select(g => new { Student = g.Key, Count = g.Count() }).ToList();

                if (duplicates.Count < 1)
                    Console.WriteLine("Учеников с одинаковыми ФИ нет!");
                else
                    Console.WriteLine("Ученики с одинаковым ФИ:");
                foreach (var item in duplicates)
                {
                    string a = item.Student.FirstName + " " + item.Student.LastName;
                    Console.WriteLine($"Ученики: {a}, Количество учеников: {item.Count}");
                }
            }
        }
    }
}
