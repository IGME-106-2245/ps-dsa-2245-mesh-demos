namespace IndexersAndGenerics
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> testList = new List<string>();
            // testList[0] = "?";

            MyStringList names = new MyStringList();
            names.Add("Shiro");
            names.Add("Pax");
            names.Add("Lacey");

            Console.WriteLine("names[2]: " + names[2]);
            names[2] = "Lacy";
            Console.WriteLine("names[2]: " + names[2]);

            try
            {
                Console.WriteLine("names[3]: " + names[3]);
                names[3] = "New Name";
                Console.WriteLine("names[3]: " + names[3]);
            }
            catch(IndexOutOfRangeException e)
            {
                Console.WriteLine(e.Message);
            }

            MyGenericList<string> extraNames = new MyGenericList<string>();
            extraNames.Add("Ben");
            extraNames.Add("Chris");
            extraNames.Add("Erika");
            Console.WriteLine(extraNames[1]);
            extraNames[1] = "Chris E.";
            Console.WriteLine(extraNames[1]);

            MyGenericList<double> nums = new MyGenericList<double>();
            for(int i = 0; i<5; i++)
            {
                nums.Add(i);
                nums[i] = Math.Pow(2, nums[i]);
                Console.WriteLine(nums[i]);
            }

            MyGenericList<Player> plList = new MyGenericList<Player>();
            plList.Add(new Player());
            plList.Add(new Player());
            plList.Add(new Player());
            plList.Add(new Player());

        }
    }
}
