
using System.ComponentModel.DataAnnotations;

namespace IndexersAndGenerics
{

    class MyStringList
    {
        // The data for the list and a constant for the initial size
        private String[] data;
        private const int InitCapacity = 2;

        // auto-property where the get is public, but not the set
        public int Count { get; private set; }

        // indexer
        public string this[int index] // the indexer param can be any type or name
        {
            get 
            {
                if (index >= 0 && index < Count)
                {
                    return data[index];
                }
                else
                {
                    throw new IndexOutOfRangeException($"Bad index: {index}");
                }
            }
            set
            {
                if (index >= 0 && index < Count)
                {
                    data[index] = value;
                }
                else
                {
                    throw new IndexOutOfRangeException($"Bad index: {index}");
                }
            }
        }

        // Creates a basic list
        public MyStringList()
        {
            data = new String[InitCapacity];
            Count = 0;
        }

        // Adds an item to the list
        public void Add(String item)
        {
            // If we're out of space, make a bigger array,
            // copy the data over, then make our data field refer
            // to the new, bigger array
            if (Count == data.Length)
            {
                string[] newData = new string[data.Length * 2];
                for (int i = 0; i < data.Length; i++)
                {
                    newData[i] = data[i];
                }
                data = newData;
            }

            // Add the new element & increment the count
            data[Count] = item;
            Count++;
        }
    }
}
