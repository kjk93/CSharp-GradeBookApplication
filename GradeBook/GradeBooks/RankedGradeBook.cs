using GradeBook.Enums;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GradeBook.GradeBooks
{
    public class RankedGradeBook : BaseGradeBook
    {
        public RankedGradeBook(string name) : base(name)
        {
            this.Type = GradeBookType.Ranked;
        }

        public override char GetLetterGrade(double averageGrade)
        {
            if (Students.Count < 5)
            {
                throw new InvalidOperationException("Ranked grading requires at least 5 students");
            }

            int threshold = (int)Math.Ceiling(Students.Count * 0.2);
            List<double> grades = Students.OrderByDescending(student => student.AverageGrade).Select(student => student.AverageGrade).ToList();
            
            if (grades[threshold - 1] <= averageGrade)
            {
                return 'A';
            } else if (grades[threshold*2 - 1] <= averageGrade)
            {
                return 'B';
            } else if (grades[threshold * 3 - 1] <= averageGrade)
            {
                return 'C';
            } else if (grades[threshold * 4 - 1] <= averageGrade)
            {
                return 'D';
            }

            return 'F';
        }
    }
}
