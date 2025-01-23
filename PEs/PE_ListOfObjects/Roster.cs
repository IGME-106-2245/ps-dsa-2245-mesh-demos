namespace PE_ListOfObjects
{
    internal class Roster
    {
        private List<Student> students;
        public string Name { private set; get; }

        public Roster(string name)
        {
            this.Name = name;
            students = new List<Student>();
        }

        public Student SearchByName(string name)
        {
            // todo
            return null;
        }

        public void AddStudent(Student student)
        {
            // todo - make sure this student isn't already in the roster & print confirmation message
            // implementing the rest here only to allow for testing with the adding file support demo later
            students.Add(student);
        }

        public Student AddStudent()
        {
            // todo
            return null;
        }

        public void DisplayRoster()
        {

        }
    }
}
