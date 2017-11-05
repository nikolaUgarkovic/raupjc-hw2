using System;
using System.Linq;
using Zadatak1;

namespace Zadatak_4
{
    public class HomeworkLinqQueries
    {
        public static string[] Linq1(int[] intArray)
        {
            return intArray.GroupBy(s => s).OrderBy(s => s.Key).Select(s => $"broj {s.Key} ponavlja se {s.Count()} puta").ToArray();
        }
        public static University[] Linq2_1(University[] universityArray)
        {
            return universityArray.Where(u => !u.Students.Any(s => s.Gender.Equals(Gender.Female))).ToArray();
        }
        public static University[] Linq2_2(University[] universityArray)
        {
            double average = universityArray.Select(u => u.Students.Count()).Average();
            return universityArray.Where(u => u.Students.Count() < average).ToArray();
        }
        public static Student[] Linq2_3(University[] universityArray)
        {
            return universityArray.SelectMany(u => u.Students).Distinct().ToArray();
        }
        public static Student[] Linq2_4(University[] universityArray)
        {
            return universityArray.Where(u => !u.Students.Any(s => s.Gender.Equals(Gender.Female)) || !u.Students.Any(s => s.Gender.Equals(Gender.Male))).SelectMany(u => u.Students).Distinct().ToArray();
        }
        public static Student[] Linq2_5(University[] universityArray)
        {
            return universityArray.SelectMany(u => u.Students).GroupBy(s => s).Where(s => s.Count() > 1).Select(s => s.Key).ToArray();
        }
    }
}
