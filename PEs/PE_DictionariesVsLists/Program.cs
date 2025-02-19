namespace PE_DictionariesVsLists
{
    class Program
    {
        static void Main(string[] args)
        {
            // Creates a new file reader, which loads a file of words
            // into both a list and a dictionary
            WordLoader reader = new WordLoader();

            // Get the two data structures needed for the exercise
            List<String> wordList = reader.WordList;
            Dictionary<String, bool> wordDictionary = reader.WordDictionary;

            // word --- ha
            // double --> haha

            // list search
            System.Diagnostics.Stopwatch watch = new System.Diagnostics.Stopwatch();
            watch.Start();
            // Basically: get a word from the list,
            foreach (string word in reader.WordList)
            {
                // double it (doubleword = currentWord + currentWord)
                string doubleWord = word + word;

                // and see if that new word is also in the List.
                if(reader.WordList.Contains(doubleWord))
                {
                    Console.WriteLine(doubleWord);
                }
            }
            watch.Stop();
            Console.WriteLine(
                "List search for all double words took "
                + watch.Elapsed.TotalMilliseconds + "ms\n");
            // *********************
            // TODO: Put your code between here...

            // ...and here.
            // *********************
        }
    }
}
