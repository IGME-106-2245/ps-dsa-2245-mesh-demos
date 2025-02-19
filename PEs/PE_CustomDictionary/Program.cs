namespace PE_CustomDictionary
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Test our dictionary with a few different types of keys and values.

            Console.WriteLine("\n*** int to string ***");
            MyDictionary<int, string> intToString = new MyDictionary<int, string>();
            intToString.Add(1, "one");
            intToString.Add(2, "two");
            intToString.Add(3, "three");
            intToString.Add(4, "four");
            try
            {
                intToString.Add(4, "FOUR");
                Console.WriteLine(" * No error!");
            }
            catch (ArgumentException e)
            {
                Console.WriteLine(e.Message);
            }
            Console.WriteLine("Contains key 3: " + intToString.ContainsKey(3));
            Console.WriteLine("Contains value 'two': " + intToString.ContainsValue("two"));
            Console.WriteLine("Contains key 5: " + intToString.ContainsKey(5));
            Console.WriteLine("Contains value 'five': " + intToString.ContainsValue("five"));
            intToString.Print();


            Console.WriteLine("\n*** string to string ***");
            MyDictionary<string, string> stringToString = new MyDictionary<string, string>();
            stringToString.Add("one", "uno");
            stringToString.Add("two", "dos");
            stringToString.Add("three", "tres");
            stringToString.Add("four", "cuatro");
            try
            {
                stringToString.Add("four", "CUATRO");
                Console.WriteLine(" * No error!");
            }
            catch (ArgumentException e)
            {
                Console.WriteLine(e.Message);
            }
            Console.WriteLine("Contains key 'three': " + stringToString.ContainsKey("three"));
            Console.WriteLine("Contains value 'dos': " + stringToString.ContainsValue("dos"));
            Console.WriteLine("Contains key 'five': " + stringToString.ContainsKey("five"));
            Console.WriteLine("Contains value 'cinco': " + stringToString.ContainsValue("cinco"));
            stringToString.Print();


            Console.WriteLine("\n*** Pet to string ***");
            MyDictionary<Pet, string> petToString = new MyDictionary<Pet, string>();
            petToString.Add(new Pet("Aiden", 100), "Horse");
            petToString.Add(new Pet("Lacy", 200), "Cat");
            petToString.Add(new Pet("Pax", 300), "Dog");
            try
            {
                petToString.Add(new Pet("Pax", 300), "DOG");
                Console.WriteLine(" * No error!");
            }
            catch (ArgumentException e)
            {
                Console.WriteLine(e.Message);
            }
            Console.WriteLine("Contains key 'Lacy': " + petToString.ContainsKey(new Pet("Lacy", 200)));
            Console.WriteLine("Contains value 'Cat': " + petToString.ContainsValue("Cat"));
            Console.WriteLine("Contains key 'Rex': " + petToString.ContainsKey(new Pet("Rex", 400)));
            Console.WriteLine("Contains value 'Parrot': " + petToString.ContainsValue("Parrot"));
            petToString.Print();


            Console.WriteLine("\n*** string to Pet ***");
            MyDictionary<string, Pet> stringToPet = new MyDictionary<string, Pet>();
            stringToPet.Add("Horse", new Pet("Aiden", 100));
            stringToPet.Add("Cat", new Pet("Lacy", 200));
            stringToPet.Add("Dog", new Pet("Pax", 300));
            try
            {
                stringToPet.Add("Dog", new Pet("PAX", 300));
                Console.WriteLine(" * No error!");
            }
            catch (ArgumentException e)
            {
                Console.WriteLine(e.Message);
            }
            Console.WriteLine("Contains key 'Cat': " + stringToPet.ContainsKey("Cat"));
            Console.WriteLine("Contains value 'Lacy': " + stringToPet.ContainsValue(new Pet("Lacy", 200)));
            Console.WriteLine("Contains key 'Parrot': " + stringToPet.ContainsKey("Parrot"));
            Console.WriteLine("Contains value 'Rex': " + stringToPet.ContainsValue(new Pet("Rex", 400)));
            stringToPet.Print();

            // Test with a key type that does NOT override Equals and GetHashCode.
            // This will not work as expected!
            Console.WriteLine("\n*** Player to string ***");
            MyDictionary<Player, string> playerToString = new MyDictionary<Player, string>();
            playerToString.Add(new Player("Aiden", 100), "Horse");
            playerToString.Add(new Player("Lacy", 200), "Cat");
            playerToString.Add(new Player("Pax", 300), "Dog");
            try
            {
                playerToString.Add(new Player("Pax", 300), "DOG");
                Console.WriteLine(" * No error!");
            }
            catch (ArgumentException e)
            {
                Console.WriteLine(e.Message);
            }
            Console.WriteLine("Contains key 'Lacy': " + playerToString.ContainsKey(new Player("Lacy", 200)));
            Console.WriteLine("Contains value 'Cat': " + playerToString.ContainsValue("Cat"));
            Console.WriteLine("Contains key 'Rex': " + playerToString.ContainsKey(new Player("Rex", 400)));
            Console.WriteLine("Contains value 'Parrot': " + playerToString.ContainsValue("Parrot"));
            playerToString.Print();

        }
    }
}
