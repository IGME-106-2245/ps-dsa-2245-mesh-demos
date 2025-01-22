namespace PE_ListOfObjects
{
    internal class Student
    {
        // field + property
        private string name;
        public string Name { get { return name; } }

        // auto-properties
        public string Major { set; get; }
        public int Year { set; get; }
        
        public Student(string name, string major, int year)
        {
            this.name = name;
            this.Major = major;
            this.Year = year;
        }

        public override string ToString()
        {
            return name;
        }
    }
}
