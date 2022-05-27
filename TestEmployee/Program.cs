
class Programm
{
    static Company company = new Company("Сompany inc.", new Director("Попов", "Егор", "Аркадьевич", new DateOnly(1999, 12, 30), Gender.Мужской));
    static public void Main()
    {
        //каждый рабочий прикреплен к отделу и содержит фио управляющего отделом
        //к каждому отделу прикреплен управляющий отделом, содержащий название отдела
        //каждый контроллер прикреплен к отделу и содержащий процент успешно выполненных задач(возможно не лучшее св-во тк ни к чему не привязано) и фио управляющего
        //директор обособлен от отделов и содержит имя компании

        //создаем условную компанию
        company.AddDepartment(new Department("отдел по набору кадров", new DepartmentLead("Сидоров", "Даниил", "Эдуардович", new DateOnly(1999, 12, 30), Gender.Мужской)));
        company.AddDepartment(new Department("отдел по управлению кадрами", new DepartmentLead("Иванов", "Иван", "Иванович", new DateOnly(1966, 12, 22), Gender.Мужской)));
        
        var dep = company.GetDepartment("отдел по набору кадров");
        dep.AddEmployee(new Controller("Девятаев", "Илья", "Александрович", new DateOnly(1999, 12, 30), Gender.Мужской, dep.DepartmentLead.GetFullName()));
        dep.AddEmployee(new Worker("Иванов", "Евгений", "Юрьевич", new DateOnly(1999, 12, 30), Gender.Мужской, dep.DepartmentLead.GetFullName()));
        dep.AddEmployee(new Worker("Семенов", "Денис", "Петрович", new DateOnly(2001, 6, 12), Gender.Мужской, dep.DepartmentLead.GetFullName()));
        dep.AddEmployee(new Worker("Иванова", "София", "Петровна", new DateOnly(1995, 10, 3), Gender.Женский, dep.DepartmentLead.GetFullName()));

        dep = company.GetDepartment("отдел по управлению кадрами");
        dep.AddEmployee(new Controller("Герасимов", "Максим", "Сергеевич", new DateOnly(1998, 1, 3), Gender.Мужской, dep.DepartmentLead.GetFullName()));
        dep.AddEmployee(new Worker("Нечипоренко", "Олег", "Юрьевич", new DateOnly(1999, 12, 30), Gender.Мужской, dep.DepartmentLead.GetFullName()));
        dep.AddEmployee(new Worker("Петров", "Петр", "Петрович", new DateOnly(1993, 11, 2), Gender.Мужской, dep.DepartmentLead.GetFullName()));
        dep.AddEmployee(new Worker("Тишина", "Екатерина", "Олеговна", new DateOnly(2000, 10, 13), Gender.Женский, dep.DepartmentLead.GetFullName()));

        Console.WriteLine(">>> Вас приветствует консольное приложение управления персооналом <<<");
        Console.WriteLine(">>> Чтобы начать пользоваться, введите /start. Чтобы выйти, введите любую клавишу <<<");

        while (true)
        {
            Start(Console.ReadLine());

            Console.WriteLine("Выберите тип операции (0 - Показать информацию о сотрудниках отдела, 1 - Поменять должность сотрудника, 2 - Получить информацию о директоре компании)");

            ChooseOperation(Console.ReadLine());

            Console.WriteLine("Чтобы продолжить, введите /start");
        }
    }

    private static void Start(string msg)
    {
        switch (msg)
        {
            case "/start":
                Console.Clear();
                break;
            default:
                Environment.Exit(0);
                break;
        }
    }

    private static void ChooseOperation(string operation)
    {
        switch (operation)
        {
            case "0":
                Console.Clear();
                ShowInfo();
                break;
            case "1":
                Console.Clear();
                RaiseEmployee();
                break;
            case "2":
                company.GetDirector();
                break;
            default:
                ChooseOperation(Console.ReadLine());
                break;
        }
    }

    private static Department ChooseDepartment()
    {
        Console.WriteLine("Введите название отдела. Cписок отделов:\n");
        company.ShowDepartments();

        var name = Console.ReadLine();
        return company.GetDepartment(name.ToLower());
    }
    private static void ShowInfo()
    {
        var department = ChooseDepartment();

        Console.WriteLine("\nВведите позиции (рабочий, контроллер, руководитель отдела) через запятую\n");

        var positions = Console.ReadLine();
        var position = positions.Split(",");
        Console.Clear();
        department.ShowEmployees(position);
    }

    private static void RaiseEmployee()
    {
        var department = ChooseDepartment();

        Console.WriteLine("Введите фамилию сотрудника:");
        var name = Console.ReadLine();
        Console.WriteLine("Введите имя сотрудника:");
        var surname = Console.ReadLine();

        var employee = department.GetEmployee(name, surname);

        if (employee != null)
        {
            Console.WriteLine($"Найден сотрудник: {employee}\nНа какую должность меняем (рабочий, контроллер, руководитель отдела)?");
            var position = Console.ReadLine();
            
            department.UpdateEmployeePosition(employee, position);
        }
        else
            Console.WriteLine("Сотрудник не найден");
    }
}
