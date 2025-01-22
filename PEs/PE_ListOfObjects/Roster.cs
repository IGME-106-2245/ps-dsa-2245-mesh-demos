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
            // todo
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
