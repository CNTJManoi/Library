using System;

namespace OOPRGR
{
    class Program
    {
        static private ConsoleColor _defaultForeground;
        static private ConsoleColor _defaultBackground;
        static void Main(string[] args)
        {
            _defaultForeground = Console.ForegroundColor;
            _defaultBackground = Console.BackgroundColor;
            
            Library l = new Library("Хорошее место", "Каждый день с 8:00 до 22:00", "Не шуметь...", new Catalog());
            l.OpenOrClose = true;
            Employee director1 = new Director("Иванченко Владислав Антонович", "5004-354956", 85000);
            l.GetCatalog.AddBooks(new Book("В царстве животных", "Иванов И.И.", "Москва-Река", 2021, "Фантастика", 254, 
                "12312-12312-12312", "2 полка в 3 ряду", 20));
            Visitor v = new Visitor("Степанов Илья Владимирович", 5004, 354904,
                "г. Новосибирск Ул. Ленина дом 32 кв 14"
                , 79132930955, 8922314523);
            l.AddVisitor(v);
            l.AddEmployee(director1);
            while (true)
            {
                Console.Clear();
                SetConsoleNotificationColor();
                Console.WriteLine("Добро пожаловать в библиотеку " + l.Name);
                Console.WriteLine("График работы библиотеки: " + l.TimeTable);
                Console.WriteLine("Правила: " + l.Rules);
                SetConsoleDefaultColor();
                Console.WriteLine("Выберите необходимое действие...");
                Console.WriteLine("1 - Добавить посетителя"
                                  + "\n2 - Добавить работника"
                                  + "\n3 - Перейти в меню посетителя"
                                  + "\n4 - Перейти в меню рабочего"
                                  + "\n5 - Вывести список посетителей"
                                  + "\n6 - Вывести список рабочих"
                                  + "\n7 - Добавить книгу"
                                  + "\n8 - Добавить публицистический материал"
                                  + "\n9 - Вывести список книг и публицистических материалов"
                                  + "\n10 - Открыть библиотеку"
                                  + "\n11 - Закрыть библиотеку"
                                  + "\n0 - Выйти");
                Console.Write("Ваш выбор: ");
                byte Action = byte.MaxValue;
                while (Action == byte.MaxValue)
                {
                    try
                    {
                        Action = byte.Parse(Console.ReadLine());
                        if (Action > 11) throw new Exception();
                    }
                    catch
                    {
                        Action = byte.MaxValue;
                        Console.WriteLine("Введите корректное значение!");
                        Console.Write("Ваш выбор: ");
                    }
                }

                Console.Clear();

                switch (Action)
                {
                    case 1:
                        
                        SetConsoleNotificationColor();
                        Console.WriteLine("Вы добавляете нового посетителя");
                        SetConsoleDefaultColor();
                        Console.WriteLine("Введите полное имя посетителя: ");
                        string fullname = Console.ReadLine();
                        Console.WriteLine("Введите серию паспорта посетителя: ");
                        uint seriesP, numberP;
                        while (!uint.TryParse(Console.ReadLine(), out seriesP)) Console.WriteLine("Введено неверное значение!");
                        Console.WriteLine("Введите номер паспорта посетителя: ");
                        while (!uint.TryParse(Console.ReadLine(), out numberP)) Console.WriteLine("Введено неверное значение!");
                        Console.WriteLine("Введите адрес: ");
                        string adr = Console.ReadLine();
                        Console.WriteLine("Введите номер телефона (Пример: 79994561234): ");
                        ulong phone;
                        while (!ulong.TryParse(Console.ReadLine(), out phone)) Console.WriteLine("Введено неверное значение!");
                        Console.WriteLine("Введите номер читательского билета (8 цифр): ");
                        ulong ticket;
                        while (!ulong.TryParse(Console.ReadLine(), out ticket)) Console.WriteLine("Введено неверное значение!");
                        l.AddVisitor(new Visitor(fullname, seriesP, numberP,adr,phone,ticket));
                        break;
                    case 2:
                        SetConsoleNotificationColor();
                        Console.WriteLine("Вы добавляете нового рабочего");
                        SetConsoleDefaultColor();
                        Console.WriteLine("Кого вы хотите добавить?" 
                                          + "\n1 - Директор"
                                          + "\n2 - Уборщик"
                                          + "\n3 - Библиотекарь"
                                          + "\n0 - Отмена действия");
                        byte Action2 = byte.MaxValue;
                        while (Action2 == byte.MaxValue)
                        {
                            try
                            {
                                Action2 = byte.Parse(Console.ReadLine());
                                if (Action2 > 3) throw new Exception();
                            }
                            catch
                            {
                                Action2 = byte.MaxValue;
                                Console.WriteLine("Введите корректное значение!");
                            }
                        }

                        if (Action2 == 0) break;
                        Console.WriteLine("Введите полное имя рабочего: ");
                        string fulln = Console.ReadLine();
                        Console.WriteLine("Введите серию и номер диплома (Пример: 5004-354956):");
                        string diplomNumb = Console.ReadLine();
                        Console.WriteLine("Введите зарплату: ");
                        uint salary;
                        while (!uint.TryParse(Console.ReadLine(), out salary)) Console.WriteLine("Введено неверное значение!");
                        switch (Action2)
                        {
                            case 1:
                                l.AddEmployee(new Director(fulln, diplomNumb, salary));
                                break;
                            case 2:
                                l.AddEmployee(new Cleaner(fulln, diplomNumb, salary));
                                break;
                            case 3:
                                l.AddEmployee(new Librarian(fulln, diplomNumb, salary));
                                break;
                            default:
                                break;
                        }
                        break;
                    case 3:
                        SetConsoleNotificationColor();
                        Console.WriteLine("Меню посетителя");
                        SetConsoleDefaultColor();
                        if (l.Visitors.Count == 0)
                        {
                            Console.WriteLine("Посетители отсутствуют.");
                            break;
                        }
                        Console.WriteLine("Введите номер посетителя за которого вы хотите сделать действие");
                        l.GetVisitors();
                        Console.Write("Ваш выбор: ");
                        uint Action3 = uint.MaxValue;
                        while (Action3 == uint.MaxValue)
                        {
                            try
                            {
                                Action3 = uint.Parse(Console.ReadLine());
                                if (Action3 > l.Visitors.Count) throw new Exception();
                            }
                            catch
                            {
                                Action3 = uint.MaxValue;
                                Console.WriteLine("Введите корректное значение!");
                            }
                        }

                        uint number = Action3 - 1;
                        bool Stop = false;
                        while (!Stop)
                        {
                            Console.Clear();
                            SetConsoleNotificationColor();
                            Console.WriteLine("Посетитель " + l.Visitors[(int) (number)].Name);
                            SetConsoleDefaultColor();
                            Console.WriteLine("Выберите действие:"
                                              + "\n1 - Взять книгу"
                                              + "\n2 - Взять журнал"
                                              + "\n3 - Походить по библиотеке"
                                              + "\n4 - Посмотреть каталог"
                                              + "\n5 - Посмотреть каталог"
                                              + "\n6 - Посмотреть каталог"
                                              + "\n0 - Отмена действия");
                            byte Action31 = byte.MaxValue;
                            while (Action31 == byte.MaxValue)
                            {
                                try
                                {
                                    Action31 = byte.Parse(Console.ReadLine());
                                    if (Action31 > 6) throw new Exception();
                                }
                                catch
                                {
                                    Action31 = byte.MaxValue;
                                    Console.WriteLine("Введите корректное значение!");
                                }
                            }

                            switch (Action31)
                            {
                                case 1:
                                    Console.WriteLine("Введите id книги, которую хотите взять");
                                    l.GetBooksList();
                                    Console.Write("Ваш выбор: ");
                                    uint SelectedBook = uint.MaxValue;
                                    while (SelectedBook == uint.MaxValue)
                                    {
                                        try
                                        {
                                            SelectedBook = uint.Parse(Console.ReadLine());
                                            if (SelectedBook > l.GetCatalog.CatalogList.Count) throw new Exception();
                                        }
                                        catch
                                        {
                                            SelectedBook = uint.MaxValue;
                                            Console.WriteLine("Введите корректное значение!");
                                        }
                                    }

                                    Console.WriteLine();
                                    if (l.GetCatalog.CatalogList[(int) (SelectedBook - 1)].Count > 0)
                                    {
                                        l.Visitors[(int) (number)].TakeBook(l.GetCatalog.CatalogList[(int)(SelectedBook - 1)]);
                                        l.GetCatalog.CatalogList[(int) (SelectedBook - 1)].Count -= 1;
                                    }
                                    else
                                    {
                                        Console.WriteLine("Этой книги нет в наличии");
                                    }

                                    break;
                                case 2:

                                    break;
                                case 3:

                                    break;
                                case 4:

                                    break;
                                case 5:
                                    l.Visitors[(int)(number)].Enter();
                                    break;
                                case 6:
                                    l.Visitors[(int)(number)].Leave();
                                    break;
                                case 0:
                                    Stop = true;
                                    break;
                            }
                            Console.WriteLine("Нажмите любую клавишу...");
                            Console.ReadKey();
                        }

                        break;
                    case 4:

                        break;
                    case 5:
                        l.GetVisitors();
                        break;
                    case 6:
                        l.GetListEmployees();
                        break;
                    case 7:

                        break;
                    case 8:

                        break;
                    case 9:
                        l.GetBooksList();
                        break;
                    case 10:
                        SetConsoleNotificationColor();
                        Console.WriteLine("Библиотека открылась");
                        SetConsoleDefaultColor();
                        foreach (IPerson people in l.Employees)
                        {
                            people.Enter();
                            people.Action();
                        }
                        foreach (IPerson people in l.Visitors)
                        {
                            people.Enter();
                        }
                        break;
                    case 11:
                        SetConsoleNotificationColor();
                        Console.WriteLine("Библиотека закрывается");
                        SetConsoleDefaultColor();
                        foreach (IPerson people in l.Employees)
                        {
                            people.Leave();
                        }
                        foreach (IPerson people in l.Visitors)
                        {
                            people.Leave();
                        }
                        break;
                }
                Console.WriteLine("Нажмите любую клавишу...");
                Console.ReadKey();
            }
        }

        private static void SetConsoleNotificationColor()
        {
            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.Red;
        }

        private static void SetConsoleDefaultColor()
        {
            Console.BackgroundColor = _defaultBackground;
            Console.ForegroundColor = _defaultForeground;
        }
    }
}
