using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace Lab0
{
    internal class Lab0
    {
        /// <summary>
        /// Журнал студентов
        /// </summary>
        public class StudentJournal
        {
            /// <summary>
            /// Фамилии студентов
            /// </summary>
            public static readonly string[] FirstNames = { "Борис", "Григорий","Данил"};
            /// <summary>
            /// Имена студентов
            /// </summary>
            public static readonly string[] LastNames = { "Иванов", "Сидоров"};
            /// <summary>
            /// Литеры класса
            /// </summary>
            public static readonly string[] Letters = { "А", "Б"};
            /// <summary>
            /// Информация о студенте
            /// </summary>
            public struct Student
            {
                public string FirstName;
                public string LastName;
                public string Class;

                public override string ToString()
                {
                    return $"{LastName} {FirstName}, {Class} класс";
                }
            }
            /// <summary>
            /// Создание журнала
            /// </summary>
            /// <param name="n">Количество студентов</param>
            /// <returns>Журнал студентов</returns>
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