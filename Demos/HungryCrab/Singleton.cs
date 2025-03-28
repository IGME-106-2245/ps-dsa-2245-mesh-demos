using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HungryCrab
{
    internal class Singleton
    {
        // Static singleton info
        private static Singleton myInstance;
        public static Singleton Instance
        {
            get
            {
                if(myInstance == null)
                {
                    myInstance = new Singleton();
                }
                return myInstance;
            }
        }

        // Class info
        public string Name { get; private set; }

        private Singleton()
        {
            Name = DateTime.Now.ToString();
        }

        public override string ToString()
        {
            return Name;
        }
    }
}
