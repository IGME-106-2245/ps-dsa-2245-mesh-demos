namespace LIFO_FIFO
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> nums = new List<int>();
            nums.Add(1);
            nums.Add(6);
            nums.Add(2);
            nums.Add(9); // adds to the end
            LIFO(nums);
            FIFO(nums);
        }

        static void LIFO(List<int> nums)
        {
            // last in first out
            for(int i = nums.Count-1; i>= 0; i-- )
            {
                Console.Write(nums[i]+" ");
            }
            Console.WriteLine();
        }

        static void FIFO(List<int> nums)
        {
            // first in first out
            foreach(int n in nums)
            {
                Console.Write(n + " ");
            }
            Console.WriteLine();
        }
    }
}
