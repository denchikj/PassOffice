namespace PassOfficeLibrary.Entity
{   
    public class Employee
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public int PassNumber { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Patronymic { get; set; }
        public int PassTypes { get; set; }
        public DateTime PassDate { get; set; }

        public Employee(Guid id, int passNumber, string firstName, string lastName, string patronymic, int passTypes, DateTime passDate)
        {
            Id = id;
            PassNumber = passNumber;
            FirstName = firstName;
            LastName = lastName;
            Patronymic = patronymic;
            PassTypes = passTypes;
            PassDate = passDate;
        }
    }
}