using GradeBook.Enums;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GradeBook.GradeBooks
{
    public class RankedGradeBook : BaseGradeBook
    {
        public RankedGradeBook(string name, bool weighted) : base(name, weighted)
        {
            Type = GradeBookType.Ranked;
            //IsWeighted = weighted;
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

        public override void CalculateStatistics()
        {
            if (Students.Count < 5)
            {
                Console.WriteLine("Ranked grading requires at least 5 students with grades in order to properly calculate a student's overall grade.");
                return;
            }
            else
            {
                base.CalculateStatistics();               
            }
        }

        public override void CalculateStudentStatistics(string name)
        {
            if (Students.Count < 5)
            {
                Console.WriteLine("Ranked grading requires at least 5 students with grades in order to properly calculate a student's overall grade.");
                return;
            }
            else
            {
                base.CalculateStudentStatistics(name);
            }
        }
    }
}
