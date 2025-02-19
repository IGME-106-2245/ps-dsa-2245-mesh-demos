using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dictionaries
{
    internal class Player
    {
        public string Name { get; private set; }
        private int score;

        public Player(string name, int score)
        {
            this.Name = name;
            this.score = score;
        }

        public override string ToString()
        {
            return Name;
        }

        public override bool Equals(object? obj)
        {
            if(obj is Player)
            {
                return ((Player)obj).Name == this.Name;
            }
            return base.Equals(obj);
        }

        public override int GetHashCode()
        {
            return Name.GetHashCode();
        }
    }
}
