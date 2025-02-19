namespace PE_CustomDictionary
{
    /// <summary>
    /// This is a minimal version of the .NET IDictionary<TKey, TValue> interface
    /// https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.idictionary-2
    /// </summary>
    internal interface ISimpleDictionary<TKey, TValue>
    {
        /// <summary>
        /// Gets or sets the value associated with the specified key.
        /// The key must already exist in the dictionary when setting the value.
        /// </summary>
        TValue this[TKey key] { get; set; }

        /// <summary>
        /// Gets the number of key/value pairs contained in the dictionary.
        /// </summary>
        int Count { get; }

        /// <summary>
        /// Adds a key/value pair to the dictionary. If this key already exists in 
        /// the dictionary, an exception is thrown.
        /// </summary>
        void Add(TKey key, TValue value);

        /// <summary>
        /// Determines whether the dictionary contains the specified key.
        /// </summary>
        bool ContainsKey(TKey key);

        /// <summary>
        /// Determines whether the dictionary contains the specified value.
        /// </summary>
        bool ContainsValue(TValue value);

        /// <summary>
        /// Prints all key/value pairs in the dictionary.
        /// </summary>
        void Print();
    }
}
