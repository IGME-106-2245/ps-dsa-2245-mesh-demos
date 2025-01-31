namespace PE_Recursion
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // local variables for testing our recursive methods
            const int NumElements = 5;
            int[] nums = new int[NumElements];
            int[] numsReverse = new int[NumElements];
            int[] numsRandom = new int[NumElements];
            Random rng = new Random();
            string word;

            // Setup 3 arrays - nums in order, nums in reverse order, nums with random values
            for (int i = 0; i < NumElements; i++)
            {
                nums[i] = i;
                numsReverse[i] = NumElements - i - 1;
                numsRandom[i] = rng.Next(0, NumElements * 3);
            }

            // Put the number 42 at a random location in the non-random arrays
            nums[rng.Next(NumElements)] = 42;
            numsReverse[rng.Next(NumElements)] = 42;

            // Print each array
            PrintArray("In order", nums);
            PrintArray("In reverse", numsReverse);
            PrintArray("Random", numsRandom);
            Console.WriteLine();

            // Calc the factorial of each random number
            for (int i = 0; i < NumElements; i++)
            {
                Console.WriteLine($"{numsRandom[i]}! = {Factorial(numsRandom[i])}");
            }
            Console.WriteLine($"42! = {Factorial(42)}"); // int overflow :)
            Console.WriteLine();

            /* for you to do :)
            // Sum the elements of each array
            Console.WriteLine($"Sum of nums is {Sum(nums)}");
            Console.WriteLine($"Sum of numsReverse is {Sum(numsReverse)}");
            Console.WriteLine($"Sum of numsRandom is {Sum(numsRandom)}");
            Console.WriteLine();
            */

            // Find if the number 3 is in each array
            Console.WriteLine($"Contains 3 in nums: {Contains(nums, 3)}");
            Console.WriteLine($"Contains 3 in numsReverse: {Contains(numsReverse, 3)}");
            Console.WriteLine($"Contains 3 in numsRandom: {Contains(numsRandom, 3)}");
            Console.WriteLine();

            // Find if the number 42 is in each array
            Console.WriteLine($"Contains 42 in nums: {Contains(nums, 42)}");
            Console.WriteLine($"Contains 42 in numsReverse: {Contains(numsReverse, 42)}");
            Console.WriteLine($"Contains 42 in numsRandom: {Contains(numsRandom, 42)}");
            Console.WriteLine();

            // Prompt the user for a word to test string methods
            Console.WriteLine("Enter a word:");
            word = Console.ReadLine();
//            Console.WriteLine($"Is {word} a palindrome? {IsPalindrome(word)}");
            Console.WriteLine($"Reverse of {word} is {Reverse(word)}");
        }

        /*
            *base case - 1 letter*
            Reverse(E)      ---> return E (i.e., the full word)

            *recursive case - +1 letter*
            *state change - call without the last letter*
            Reverse(EM)     ---> return M + Reverse(E)
            Reverse(EMP)    ---> return P + Reverse(EM)
            Reverse(EMPT)   ---> return T + Reverse(EMP)
            Reverse(EMPTY)  ---> return Y + Reverse(EMPT)
         */
        static string Reverse( string word )
        {
            // base case - 1 letter
            if(word == null || word.Length <= 1)
            {
                return word;
            }
            // recursive case - +1 letter
            else
            {
                // return last letter + Reverse(rest of the string)
                // state change - call without the last letter
                return word[word.Length - 1] + Reverse(word.Substring(0, word.Length - 1));
            }
        }


        static void PrintArray(string label, int[] nums)
        {
            Console.Write(label+": ");
            foreach(int n in nums)
            {
                Console.Write(n+" ");
            }
            Console.WriteLine();
        }

        static int Factorial(int n)
        {
            // Base case
            if(n <= 1)
            {
                return 1;
            }
            // Recursive case
            else
            {
                return n * Factorial(n-1); // State change: n-1
            }
        }

        static bool Contains(int[] nums, int target)
        {
            // Base Case - nums is null or totally empty
            if (nums == null || nums.Length == 0)
            {
                return false;
            }
            // Base Case - 1 element and n is there or not
            else if (nums.Length == 1) 
            { 
                // return whether or not the 1st (only) element
                // equals our target
                return nums[0] == target;
            }
            // Recursive Case
            else
            {
                // # # # # #
                // (check 1st) -- call contains on the rest
                return
                    (nums[0] == target) // 1st element matches
                    ||                  // OR
                                        // [1..] --- gets subarray from index 1 to the end
                    Contains(nums[1..], target);  // Something in the rest
                                                 // of the array matches (state change)
            }

        }
    }
}
