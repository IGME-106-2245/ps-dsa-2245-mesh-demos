namespace PE_CustomDictionary
{
    // A simple class to represent a player in a game
    // and test the dictionary with a type that does
    // NOT override GetHashCode and Equals.
    internal class Player
    {
        public string Name { get; set; }
        public int Score { get; set; }

        public Player(string name, int score)
        {
            Name = name;
            Score = score;
        }

        public override string ToString()
        {
            return $"Player [{Name},{Score}]";
        }

    }
}
