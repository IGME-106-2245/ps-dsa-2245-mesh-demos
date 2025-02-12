using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam1Review
{
    internal class IndexerDemo
    {
        private char[] grades;

        public char this[int assignmentNum]
        {
            get
            {
                return grades[assignmentNum];
            }

            set
            {
                grades[assignmentNum] = value;
            }
        }

        // indexer to get the first index of a given grade
        public int this[char grade]
        {
            get
            {
                for(int i=0; i<grades.Length; i++)
                {
                    if (grades[i] == grade)
                    {
                        return i;
                    }
                }
                return -1;
            }
        }

        public IndexerDemo(int numAssignments)
        {
            grades = new char[numAssignments];
        }

        public void Display()
        {
            Console.WriteLine();
            foreach (char grade in grades)
            {
                if (grade == (char)0)
                {
                    Console.Write("-");
                }
                else
                {
                    Console.Write(grade);
                }
            }
            Console.WriteLine();
        }

    }
}
