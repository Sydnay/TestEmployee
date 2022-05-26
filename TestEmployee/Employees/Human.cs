enum Gender
{
    Мужской = 0,
    Женский = 1
}
class Human
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string MiddleName { get; set; }
    public DateOnly Birthday { get; set; }
    public Gender Gender { get; set; }
    public string Position { get; set; } = string.Empty;
    public Human(string firstName, string lastName, string middleName, DateOnly birthday, Gender gender)
    {
        FirstName = firstName;
        LastName = lastName;
        MiddleName = middleName;
        Birthday = birthday;
        Gender = gender;
    }
    public override string ToString()
    {
        return $"{Position} || {FirstName} {LastName} {MiddleName}, дата рождения: {Birthday}, пол: {Gender}";
    }
}
