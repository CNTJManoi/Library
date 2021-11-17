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
                                  + "\n0 - Выйти");
                Console.Write("Ваш выбор: ");
                byte Action = byte.MaxValue;
                while (Action == byte.MaxValue)
                {
                    try
                    {
                        Action = byte.Parse(Console.ReadLine());
                        if (Action > 9) throw new Exception();
                    }
                    catch
                    {
                        Action = byte.MaxValue;
                        Console.WriteLine("Введите корректное значение!");
                        Console.Write("Ваш выбор: ");
                    }
                }

                Console.WriteLine();

                switch (Action)
                {
                    case 1:
                        Console.Clear();
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
                        Console.Clear();
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
