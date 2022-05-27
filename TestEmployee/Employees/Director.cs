class Director : Human
{
    public string CompanyName { get; set; } = string.Empty;
    public Director(string firstName, string lastName, string middleName, DateOnly birthday, Gender gender)
        : base(firstName, lastName, middleName, birthday, gender)
    {
        Position = Roles.Director;
    }
    public override string ToString()
    {
        return $"{Position} || {FirstName} {LastName} {MiddleName}, дата рождения: {Birthday}, пол: {Gender}, директор компании {CompanyName}";
    }
}
