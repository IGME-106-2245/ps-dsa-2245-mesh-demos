namespace Exam1Review
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /*
            for(int n=0; n<20; n++)
            {
                Console.Write(Fib(n) + " ");
            }
            Console.WriteLine();

            int x = 0;
            while(true)
            {
                Console.WriteLine(x + ": " + Fib(x));
                x++;
            }
            */
            Fib(10);


            IndexerDemo demo = new IndexerDemo(5);
            demo[0] = 'A';
            demo[2] = 'B';
            demo[4] = 'C';
            demo.Display();

            Console.WriteLine(demo[0]);

            Console.WriteLine(demo['F']);
        }

        // https://en.wikipedia.org/wiki/Fibonacci_sequence
        static int Fib(int n)
        {
            // base cases - n = 0 or 1
            if(n == 0)
            {
                Console.WriteLine(0);
                return 0;
            }
            else if(n == 1)
            {
                Console.WriteLine(1);
                return 1;
            }

            // recursive case
            {
                // state change == n goes down
                // F(n) = F(n-1) + F(n-2)
                int result = Fib(n - 1) + Fib(n - 2);
                Console.WriteLine(result);
                return result;
            }
        }
    }
}
