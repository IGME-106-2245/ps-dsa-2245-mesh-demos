using System.ComponentModel;

namespace EventsAndDelegates
{
    internal class Program
    {

        public delegate int UseTwoNumbersDelegate(int a, int b);

        static void Main(string[] args)
        {
            UseTwoNumbersDelegate myMathMethod;

            int choice = SmartConsole.Prompt("Do you want to add (1), multiply (2), or subtract (3)?", 1, 3);
            myMathMethod = null;
            switch (choice)
            {
                case 1:
                    myMathMethod = AddTwoNumbers;
                    break;
                case 2:
                    myMathMethod = MultiplyTwoNumbers;
                    break;
                case 3:
                    myMathMethod = SubtractTwoNumbers;
                    break;
            }

            //if (myMathMethod != null)
            //{
                Console.WriteLine(myMathMethod(2, 3));
            //}
        }

        public static int AddTwoNumbers(int num1, int num2)
        {
            return num1+num2;
        }

        public static int MultiplyTwoNumbers(int num1, int num2)
        {
            return num1 * num2;
        }

        public static int SubtractTwoNumbers(int num1, int num2)
        {
            return num1 - num2;
        }

    }
}
