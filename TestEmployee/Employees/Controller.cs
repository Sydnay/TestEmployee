class Controller : Human
{
    public string LeadFullName { get; set; }
    public double SuccessPercent { get; set; }
    public Controller(string firstName, string lastName, string middleName, DateOnly birthday, Gender gender, string leadFullName)
        : base(firstName, lastName, middleName, birthday, gender)
    {
        LeadFullName = leadFullName;
        Position = Roles.Controller;
    }
    public void UpdateSuccessPercent(double value)
    {
        SuccessPercent = value;
    }
}
