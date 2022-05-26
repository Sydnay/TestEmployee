class Worker : Human
{
    public string LeadFullName { get; set; }
    public Worker(string firstName, string lastName, string middleName, DateOnly birthday, Gender gender, string leadFullName)
        : base(firstName, lastName, middleName, birthday, gender)
    {
        Position = Roles.Worker;
        LeadFullName = leadFullName;
    }
    public override string ToString()
    {
        return $"{Position} || {FirstName} {LastName} {MiddleName}, дата рождения: {Birthday}, пол: {Gender}, управляющий: {LeadFullName}";
    }
}
