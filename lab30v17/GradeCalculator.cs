using System;
using System.Collections.Generic;
using System.Linq;

namespace lab30v17
{
    public class GradeCalculator
    {
        public double CalculateGPA(List<int>? grades)
{
    if (grades == null)
        throw new ArgumentNullException(nameof(grades));

    if (grades.Count == 0)
        throw new ArgumentException("Список оцінок не може бути порожнім.");

    if (grades.Any(g => g < 0 || g > 100))
        throw new ArgumentOutOfRangeException(nameof(grades), "Оцінки мають бути в межах від 0 до 100.");

    double average = grades.Average();

    if (average >= 90) return 4.0;
    if (average >= 80) return 3.0;
    if (average >= 70) return 2.0;
    if (average >= 60) return 1.0;
    return 0.0;
}
        public string GetLetterGrade(int grade)
        {
            if (grade < 0 || grade > 100)
                throw new ArgumentOutOfRangeException(nameof(grade), "Оцінка має бути в межах від 0 до 100.");

            if (grade >= 90) return "A";
            if (grade >= 80) return "B";
            if (grade >= 70) return "C";
            if (grade >= 60) return "D";
            return "F";
        }
    }
}