﻿class Department
{
    public DepartmentLead DepartmentLead { get; set; }
    public string Name { get; set; }
    public List<Human> Employees { get; set; } = new List<Human>();
    public void ShowEmployees(params string[] positions)
    {
        foreach (var position in positions)
        {
            var employees = Employees.Where(x => x.Position.Equals(position));

            if (employees.Any())
                foreach (var employee in employees)
                {
                    Console.WriteLine(employee.ToString());
                }
            else
                Console.WriteLine($"Кажется, сотрудников на позиции \"{position}\" просто нет");
            Console.WriteLine();
        }
    }
    public Department(string departmentName, DepartmentLead departmentLead)
    {
        Name = departmentName;

        DepartmentLead = departmentLead;
        DepartmentLead.DepartmentName = departmentName;

        Employees.Add(departmentLead);
    }

    public Human GetEmployee(string name, string surname)
    {
        var employee = Employees.FirstOrDefault(x => x.FirstName == name && x.LastName == surname);
        return employee;
    }

    public void UpdateEmployeePosition(Human employee, string position)//скорее всего не самая удачная реализация
    {
        bool console = true;
        switch (position)
        {
            case Roles.Worker:
                DeleteEmployee(employee.FirstName, employee.LastName);
                Employees.Add(new Worker(employee.FirstName, employee.LastName, employee.MiddleName, employee.Birthday, employee.Gender, DepartmentLead.GetFullName()));
                break;

            case Roles.Controller:
                DeleteEmployee(employee.FirstName, employee.LastName);
                Employees.Add(new Controller(employee.FirstName, employee.LastName, employee.MiddleName, employee.Birthday, employee.Gender, DepartmentLead.GetFullName()));
                break;

            case Roles.DepartmentLead:
                DeleteEmployee(DepartmentLead.FirstName, DepartmentLead.LastName);
                DeleteEmployee(employee.FirstName, employee.LastName);
                foreach (var human in Employees)
                {
                    var worker = human as Worker;
                    if (worker != null)
                        worker.LeadFullName = $"{employee.FirstName} {employee.LastName} {employee.MiddleName}";

                    var controller = human as Controller;
                    if (controller != null)
                        controller.LeadFullName = $"{employee.FirstName} {employee.LastName} {employee.MiddleName}";
                }
                Employees.Add(new DepartmentLead(employee.FirstName, employee.LastName, employee.MiddleName, employee.Birthday, employee.Gender));
                break;

            default:
                console = false;
                Console.WriteLine("Такой должности не найдено");
                break;
        }
        if (console)
            Console.WriteLine($"Теперь {employee.FirstName} {employee.LastName} {position}");
    }
    public void DeleteEmployee(string name, string surname)
    {
        var employee = Employees.FirstOrDefault(x => x.FirstName == name && x.LastName == surname);
        Employees.Remove(employee);
    }
    public void AddEmployee(Human employee)
    {
        Employees.Add(employee);
    }
}
