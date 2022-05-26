class DepartmentLead : Human
{
    public string DepartmentName { get; set; } = string.Empty;
    public DepartmentLead(string firstName, string lastName, string middleName, DateOnly birthday, Gender gender)
        : base(firstName, lastName, middleName, birthday, gender)
    {
        Position = Roles.DepartmentLead;
    }
    public string GetFullName()
    {
        return $"{FirstName} {LastName} {MiddleName}";
    }
}
