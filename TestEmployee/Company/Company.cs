class Company
{
    public string Name { get; set; }
    public Director Director { get; set; }
    public List<Department> Departments { get; set; } = new List<Department>();
    public Company(string companyName, Director director)
    {
        Name = companyName;
        Director = director;
    }
    public void GetDirector()
    {
        Console.WriteLine(Director.ToString());
    }
    public Department GetDepartment(string departmentName)
    {
        var department = Departments.FirstOrDefault(x => x.Name == departmentName);

        //не уверен что здесь можно использовать рекурсию
        if (department is null)
        {
            Console.WriteLine("Проверьте правильность ввода");
            department = GetDepartment(Console.ReadLine());
        }

        return department;
    }
    public void AddDepartment(Department department)
    {
        Departments.Add(department);
    }
    public void ShowDepartments()
    {
        foreach (var department in Departments)
        {
            Console.WriteLine(department.Name);
        }
    }
}
