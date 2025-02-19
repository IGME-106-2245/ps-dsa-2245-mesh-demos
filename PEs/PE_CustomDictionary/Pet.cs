namespace PE_CustomDictionary
{
    // A simple class to represent a pet and test the dictionary with a type that
    // DOES override GetHashCode and Equals.
    internal class Pet
    {
        public string Name { get; set; }
        public int Weight { get; set; }

        public Pet(string name, int weight)
        {
            Name = name;
            Weight = weight;
        }

        public override string ToString()
        {
            return $"Pet [{Name},{Weight}]";
        }

        public override bool Equals(object obj)
        {
            if (obj is Pet other)
            {
                return Name == other.Name && Weight == other.Weight;
            }
            return false;
        }

        public override int GetHashCode()
        {
            return Name.GetHashCode() ^ Weight.GetHashCode();
        }

    }
}
