using System.Numerics;

namespace Dictionaries
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<String, Player> playersDictionary =
               new Dictionary<String, Player>();

            // Create Player objects
            Player pax = new Player("Pax the Dog");
            Player shiro = new Player("Shiro the Cat");

            // Add via Add method
            playersDictionary.Add("Pax", pax);

            // Add via direct index
            playersDictionary["Shiro"] = shiro;

            // Create a new dictionary that maps
            // strings to other strings
            Dictionary<String, String> dict = new Dictionary<String, String>();

            // Add some data
            dict.Add("Pax", "123-4567");
            dict.Add("Pax?", "cell number");
            dict.Add("Shiro", "555-5555");
            dict["Jenny"] = "867-5309";

            // BAD dict.Add("Pax", "?????");
            dict["Pax"] = "!!!!!!";

            Console.WriteLine("Pax’s number: " + dict["Pax"]);

            // Check to see if the key "Jenny" is in
            // the dictionary before attempting to
            // retrieve it
            if (dict.ContainsKey("Jenny"))
            {
                Console.WriteLine(dict["Jenny"]);
            }


        }
    }
}
