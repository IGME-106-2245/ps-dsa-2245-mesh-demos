namespace PE_CustomDictionary
{
    /// <summary>
    /// A simple custom dictionary implementation.
    /// </summary>
    internal class MyDictionary<TKey, TValue> : ISimpleDictionary<TKey, TValue>
    {
        // The number of buckets in the hash table.
        private const int HashCapacity = 2; // Intentionally small so we get collisions.

        // The hash table -- an array of lists of key/value pairs.
        private List<KeyValuePair<TKey, TValue>>[] _hashTable;

        /// <summary>
        /// Gets the number of key/value pairs contained in the dictionary.
        /// </summary>
        // Implemented as an auto-property where the public get meets the interface requirement
        // and the private set is used internally to update the count.
        public int Count { get; private set; }

        /// <summary>
        /// The constructor initializes the hash table to the specified capacity
        /// with an empty list at each index.
        /// </summary>
        public MyDictionary()
        {
            // Initialize the hash table with empty lists
            _hashTable = new List<KeyValuePair<TKey, TValue>>[HashCapacity];
            for (int i = 0; i < HashCapacity; i++)
            {
                _hashTable[i] = new List<KeyValuePair<TKey, TValue>>();
            }

            // Reset the count
            Count = 0;
        }

        /// <summary>
        /// Get the bucket for a key based on its hash code and our hash table capacity.
        /// </summary>
        private int GetBucket(TKey key)
        {
            // GetHashCode can return a negative value, so we take the absolute value!
            return Math.Abs(key.GetHashCode()) % HashCapacity;
        }

        /// <summary>
        /// Gets or sets the value associated with the specified key.
        /// The key must already exist in the dictionary when setting the value.
        /// </summary>
        public TValue this[TKey key]
        {
            get
            {
                // TODO: Implement the get accessor for the indexer.
                // Find the bucket for this key.
                // Search the list in that bucket for the key.
                // Return the value if found

                // Throw an exception if not found
                throw new KeyNotFoundException($"{key} not found.");
            }

            set
            {
                // TODO: Implement the set accessor for the indexer.
                // Find the bucket for this key.
                // Search the list in that bucket for the key.
                // Update that element in the bucket with a new pair
                // (Because KeyValuePair instances are immutable, we can't change the value
                // in place. We have to replace the old pair with a new one.)

                // If the key was not found, throw an exception
                throw new KeyNotFoundException($"{key} not found.");
            }
        }

        /// <summary>
        /// Adds a key/value pair to the dictionary. If this key already exists in 
        /// the dictionary, an exception is thrown.
        /// </summary>
        public void Add(TKey key, TValue value)
        {
            // TODO: Implement the Add method.
            // Find the bucket for this key.
            // Search the list in that bucket for the key.
            // Throw an exception if the key already exists
            // Add the key/value pair to the list in the bucket
            // Increment the count
        }

        /// <summary>
        /// Determines whether the dictionary contains the specified key.
        /// </summary>
        public bool ContainsKey(TKey key)
        {
            // TODO: Implement the ContainsKey method.
            // Find the bucket for this key.
            // Search the list in that bucket for the key.
            // Return true if found

            // Return false if not found
            return false;
        }

        /// <summary>
        /// Determines whether the dictionary contains the specified value.
        /// </summary>
        public bool ContainsValue(TValue value)
        {
            // TODO: Implement the ContainsValue method.
            // Search each list in the hash table for the value.
            // Return true if found

            // Return false if not found
            return false;
        }

        /// <summary>
        /// Prints all key/value pairs in the dictionary.
        /// </summary>
        public void Print()
        {
            // Print each key/value pair in the hash table
            for(int bucket = 0; bucket < HashCapacity; bucket++)
            {
                Console.WriteLine($" - Bucket {bucket}:");
                foreach (KeyValuePair<TKey, TValue> pair in _hashTable[bucket])
                {
                    Console.WriteLine($"\t{pair.Key}, {pair.Value}");
                }
            }
        }
    }
}
