using System;

namespace OOPRGR
{
    internal class Program
    {
        private static ConsoleColor _defaultForeground;
        private static ConsoleColor _defaultBackground;

        private static void Main(string[] args)
        {
            _defaultForeground = Console.ForegroundColor;
            _defaultBackground = Console.BackgroundColor;

            #region Тестовые данные

            //Тестовые данные
            var l = new Library("Хорошее место", "Каждый день с 8:00 до 22:00", "Не шуметь...");
            l.GetCatalog.RegisterHandler(new NotificationHandler(Print_Message));
            Employee director1 = new Director("Иванченко Владислав Антонович", "5004-354956", 85000);
            l.GetCatalog.AddBooks(new Book("В царстве животных", "Иванов И.И.", "Москва-Река", 2021, "Фантастика", 254,
                "12312-12312-12312", "2 полка в 3 ряду", 20));
            l.GetCatalog.AddJournal(new Journal("Лучшая газета", "Печатногазета", 2021, "полка на входе", 32));
            var v = new Visitor("Степанов Илья Владимирович", 5004, 354904,
                "г. Новосибирск Ул. Ленина дом 32 кв 14"
                , 79132930955, 8922314523);
            l.AddVisitor(v);
            l.AddEmployee(director1);
            //Тестовые данные

            #endregion

            var stopAll = false;
            while (!stopAll)
            {
                Console.Clear();
                SetConsoleNotificationColor();
                Console.WriteLine("Добро пожаловать в библиотеку " + l.Name);
                Console.WriteLine("График работы библиотеки: " + l.TimeTable);
                Console.WriteLine("Правила: " + l.Rules);
                if (l.OpenOrClose) Console.WriteLine("Библиотека открыта");
                else Console.WriteLine("Библиотека закрыта");
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
                var action = byte.MaxValue;
                while (action == byte.MaxValue)
                    try
                    {
                        action = byte.Parse(Console.ReadLine());
                        if (action > 11) throw new Exception();
                    }
                    catch
                    {
                        action = byte.MaxValue;
                        Console.WriteLine("Введите корректное значение!");
                        Console.Write("Ваш выбор: ");
                    }

                Console.Clear();

                switch (action)
                {
                    case 1:

                        SetConsoleNotificationColor();
                        Console.WriteLine("Добавление нового посетителя");
                        SetConsoleDefaultColor();
                        Console.WriteLine("Введите полное имя посетителя: ");
                        var fullname = Console.ReadLine();
                        Console.WriteLine("Введите серию паспорта посетителя: ");
                        uint seriesP, numberP;
                        while (!uint.TryParse(Console.ReadLine(), out seriesP))
                            Console.WriteLine("Введено неверное значение!");
                        Console.WriteLine("Введите номер паспорта посетителя: ");
                        while (!uint.TryParse(Console.ReadLine(), out numberP))
                            Console.WriteLine("Введено неверное значение!");
                        Console.WriteLine("Введите адрес: ");
                        var adr = Console.ReadLine();
                        Console.WriteLine("Введите номер телефона (Пример: 79994561234): ");
                        ulong phone;
                        while (!ulong.TryParse(Console.ReadLine(), out phone))
                            Console.WriteLine("Введено неверное значение!");
                        Console.WriteLine("Введите номер читательского билета (8 цифр): ");
                        ulong ticket;
                        while (!ulong.TryParse(Console.ReadLine(), out ticket))
                            Console.WriteLine("Введено неверное значение!");
                        l.AddVisitor(new Visitor(fullname, seriesP, numberP, adr, phone, ticket));
                        break;
                    case 2:
                        SetConsoleNotificationColor();
                        Console.WriteLine("Добавление нового рабочего");
                        SetConsoleDefaultColor();
                        Console.WriteLine("Кого вы хотите добавить?"
                                          + "\n1 - Директор"
                                          + "\n2 - Уборщик"
                                          + "\n3 - Библиотекарь"
                                          + "\n0 - Отмена действия");
                        Console.Write("Ваш выбор: ");
                        var action2 = byte.MaxValue;
                        while (action2 == byte.MaxValue)
                            try
                            {
                                action2 = byte.Parse(Console.ReadLine());
                                if (action2 > 3) throw new Exception();
                            }
                            catch
                            {
                                action2 = byte.MaxValue;
                                Console.WriteLine("Введите корректное значение!");
                                Console.Write("Ваш выбор: ");
                            }

                        if (action2 == 0) break;
                        Console.WriteLine("Введите полное имя рабочего: ");
                        var fulln = Console.ReadLine();
                        Console.WriteLine("Введите серию и номер диплома (Пример: 5004-354956):");
                        var diplomNumb = Console.ReadLine();
                        Console.WriteLine("Введите зарплату: ");
                        uint salary;
                        while (!uint.TryParse(Console.ReadLine(), out salary))
                            Console.WriteLine("Введено неверное значение!");
                        switch (action2)
                        {
                            case 1:
                                l.AddEmployee(new Director(fulln, diplomNumb, salary));
                                break;
                            case 2:
                                l.AddEmployee(new Cleaner(fulln, salary, diplomNumb));
                                break;
                            case 3:
                                l.AddEmployee(new Librarian(fulln, diplomNumb, salary));
                                break;
                        }

                        break;
                    case 3:
                        SetConsoleNotificationColor();
                        Console.WriteLine("Меню посетителя");
                        SetConsoleDefaultColor();
                        if (!l.OpenOrClose)
                        {
                            Console.WriteLine("Библиотека закрыта!");
                            break;
                        }

                        if (l.Visitors.Count == 0)
                        {
                            Console.WriteLine("Посетители отсутствуют.");
                            break;
                        }

                        Console.WriteLine("Введите номер посетителя за которого вы хотите сделать действие");
                        l.VisitorsList();
                        Console.Write("Ваш выбор: ");
                        var action3 = uint.MaxValue;
                        while (action3 == uint.MaxValue)
                            try
                            {
                                action3 = uint.Parse(Console.ReadLine());
                                if (action3 > l.Visitors.Count) throw new Exception();
                            }
                            catch
                            {
                                action3 = uint.MaxValue;
                                Console.WriteLine("Введите корректное значение!");
                                Console.Write("Ваш выбор: ");
                            }

                        var number = action3 - 1;
                        var stop = false;
                        while (!stop)
                        {
                            Console.Clear();
                            SetConsoleNotificationColor();
                            Console.WriteLine("Посетитель " + l.Visitors[(int) number].Name);
                            Console.Write("Состояние: ");
                            if (l.Visitors[(int) number].InLibrary) Console.WriteLine("в библиотеке");
                            else Console.WriteLine("не в библиотеке");
                            SetConsoleDefaultColor();
                            Console.WriteLine("Выберите действие:"
                                              + "\n1 - Взять книгу"
                                              + "\n2 - Взять журнал"
                                              + "\n3 - Походить по библиотеке"
                                              + "\n4 - Посмотреть каталог"
                                              + "\n5 - Войти в библиотеку"
                                              + "\n6 - Выйти из библиотеки"
                                              + "\n0 - Отмена действия");
                            Console.Write("Ваш выбор: ");
                            var action31 = byte.MaxValue;
                            while (action31 == byte.MaxValue)
                                try
                                {
                                    action31 = byte.Parse(Console.ReadLine());
                                    if (action31 > 6) throw new Exception();
                                }
                                catch
                                {
                                    action31 = byte.MaxValue;
                                    Console.WriteLine("Введите корректное значение!");
                                    Console.Write("Ваш выбор: ");
                                }

                            Console.Clear();

                            switch (action31)
                            {
                                case 1:
                                    SetConsoleNotificationColor();
                                    Console.WriteLine("Взять книгу");
                                    SetConsoleDefaultColor();
                                    if (!l.Visitors[(int) number].InLibrary)
                                    {
                                        Console.WriteLine("Посетитель " + l.Visitors[(int) number].Name +
                                                          " не в библиотеке!");
                                        Console.WriteLine("Нажмите любую клавишу...");
                                        Console.ReadKey();
                                        break;
                                    }

                                    Console.WriteLine("Введите id книги, которую хотите взять");
                                    l.BooksList();
                                    Console.Write("Ваш выбор: ");
                                    var selectedBook = uint.MaxValue;
                                    while (selectedBook == uint.MaxValue)
                                        try
                                        {
                                            selectedBook = uint.Parse(Console.ReadLine());
                                            if (selectedBook > l.GetCatalog.BookList.Count) throw new Exception();
                                        }
                                        catch
                                        {
                                            selectedBook = uint.MaxValue;
                                            Console.WriteLine("Введите корректное значение!");
                                        }

                                    Console.WriteLine();
                                    if (l.GetCatalog.RemoveBooks(l.GetCatalog.BookList[(int)(selectedBook - 1)]))
                                    {
                                        l.Visitors[(int)number]
                                            .TakeBook(l.GetCatalog.BookList[(int)(selectedBook - 1)]);
                                    }
                                    else
                                    {
                                        Console.WriteLine("Этой книги нет в наличии");
                                        break;
                                    }

                                    Console.WriteLine("Успешно!");
                                    Console.WriteLine("Нажмите любую клавишу...");
                                    Console.ReadKey();
                                    break;
                                case 2:
                                    SetConsoleNotificationColor();
                                    Console.WriteLine("Взять журнал");
                                    SetConsoleDefaultColor();
                                    if (!l.Visitors[(int) number].InLibrary)
                                    {
                                        Console.WriteLine("Посетитель " + l.Visitors[(int) number].Name +
                                                          " не в библиотеке!");
                                        Console.WriteLine("Нажмите любую клавишу...");
                                        Console.ReadKey();
                                        break;
                                    }

                                    Console.WriteLine("Введите id журнала, который хотите взять");
                                    l.JournalList();
                                    Console.Write("Ваш выбор: ");
                                    var selectedJournal = uint.MaxValue;
                                    while (selectedJournal == uint.MaxValue)
                                        try
                                        {
                                            selectedJournal = uint.Parse(Console.ReadLine());
                                            if (selectedJournal > l.GetCatalog.JournalList.Count) throw new Exception();
                                        }
                                        catch
                                        {
                                            selectedJournal = uint.MaxValue;
                                            Console.WriteLine("Введите корректное значение!");
                                        }

                                    Console.WriteLine();
                                    if (l.GetCatalog.RemoveJounal(l.GetCatalog.JournalList[(int)(selectedJournal - 1)]))
                                    {
                                        l.Visitors[(int) number]
                                            .TakeJournal(l.GetCatalog.JournalList[(int) (selectedJournal - 1)]);
                                    }
                                    else
                                    {
                                        Console.WriteLine("Этого журнала нет в наличии");
                                        break;
                                    }

                                    Console.WriteLine("Успешно!");
                                    Console.WriteLine("Нажмите любую клавишу...");
                                    Console.ReadKey();
                                    break;
                                case 3:
                                    SetConsoleNotificationColor();
                                    Console.WriteLine("Оповещение");
                                    SetConsoleDefaultColor();
                                    l.Visitors[(int) number].Walk();
                                    Console.WriteLine("Нажмите любую клавишу...");
                                    Console.ReadKey();
                                    break;
                                case 4:
                                    SetConsoleNotificationColor();
                                    Console.WriteLine("Список книг и журналов");
                                    SetConsoleDefaultColor();
                                    l.BooksList();
                                    l.JournalList();
                                    Console.WriteLine("Нажмите любую клавишу...");
                                    Console.ReadKey();
                                    break;
                                case 5:
                                    SetConsoleNotificationColor();
                                    Console.WriteLine("Оповещение");
                                    SetConsoleDefaultColor();
                                    l.Visitors[(int) number].Enter();
                                    Console.WriteLine("Нажмите любую клавишу...");
                                    Console.ReadKey();
                                    break;
                                case 6:
                                    SetConsoleNotificationColor();
                                    Console.WriteLine("Оповещение");
                                    SetConsoleDefaultColor();
                                    l.Visitors[(int) number].Leave();
                                    Console.WriteLine("Нажмите любую клавишу...");
                                    Console.ReadKey();
                                    break;
                                case 0:
                                    stop = true;
                                    break;
                            }
                        }

                        break;
                    case 4:
                        SetConsoleNotificationColor();
                        Console.WriteLine("Меню рабочего");
                        SetConsoleDefaultColor();
                        if (!l.OpenOrClose)
                        {
                            Console.WriteLine("Библиотека закрыта!");
                            break;
                        }

                        if (l.Employees.Count == 0)
                        {
                            Console.WriteLine("Рабочие отсутствуют.");
                            break;
                        }

                        Console.WriteLine("Введите номер рабочего за которого вы хотите сделать действие");
                        l.ListEmployees();
                        Console.Write("Ваш выбор: ");
                        var action4 = uint.MaxValue;
                        while (action4 == uint.MaxValue)
                            try
                            {
                                action4 = uint.Parse(Console.ReadLine());
                                if (action4 > l.Employees.Count) throw new Exception();
                            }
                            catch
                            {
                                action4 = uint.MaxValue;
                                Console.WriteLine("Введите корректное значение!");
                                Console.Write("Ваш выбор: ");
                            }

                        var numberEmp = action4 - 1;
                        var stopEmp = false;
                        while (!stopEmp)
                        {
                            Console.Clear();
                            SetConsoleNotificationColor();
                            Console.WriteLine("Рабочий " + l.Employees[(int) numberEmp].Name);
                            Console.Write("Состояние: ");
                            if (l.Employees[(int) numberEmp].InLibrary) Console.WriteLine("в библиотеке");
                            else Console.WriteLine("не в библиотеке");
                            Console.WriteLine("Должность: " + l.Employees[(int) numberEmp].Position);
                            Console.Write("В данный момент ");
                            if (l.Employees[(int) numberEmp].DoJob) Console.WriteLine("работает");
                            else Console.WriteLine("не работает");
                            SetConsoleDefaultColor();
                            Console.WriteLine("Выберите действие:"
                                              + "\n1 - Приступить к рабочим обязаностям"
                                              + "\n2 - Походить по библиотеке"
                                              + "\n3 - Посмотреть каталог"
                                              + "\n4 - Уйти с работы"
                                              + "\n5 - Войти в библиотеку"
                                              + "\n6 - Выйти из библиотеки"
                                              + "\n7 - Сделать одно рабочее действие"
                                              + "\n0 - Отмена действия");
                            Console.Write("Ваш выбор: ");
                            var action41 = byte.MaxValue;
                            while (action41 == byte.MaxValue)
                                try
                                {
                                    action41 = byte.Parse(Console.ReadLine());
                                    if (action41 > 7) throw new Exception();
                                }
                                catch
                                {
                                    action41 = byte.MaxValue;
                                    Console.WriteLine("Введите корректное значение!");
                                }

                            Console.Clear();
                            switch (action41)
                            {
                                case 1:
                                    SetConsoleNotificationColor();
                                    Console.WriteLine("Начало работы");
                                    SetConsoleDefaultColor();
                                    if (l.Employees[(int) numberEmp].DoJob)
                                        Console.WriteLine("Рабочий " + l.Employees[(int) numberEmp].Name +
                                                          " уже исполняет свои рабочие обязанности");
                                    else if (!l.Employees[(int) numberEmp].InLibrary)
                                        Console.WriteLine("Рабочий " + l.Employees[(int) numberEmp].Name +
                                                          " не в библиотеке");
                                    else
                                        l.Employees[(int) numberEmp].Action();
                                    Console.WriteLine("Нажмите любую клавишу...");
                                    Console.ReadKey();
                                    break;
                                case 2:
                                    SetConsoleNotificationColor();
                                    Console.WriteLine("Оповещение");
                                    SetConsoleDefaultColor();
                                    l.Employees[(int) numberEmp].Walk();
                                    Console.WriteLine("Нажмите любую клавишу...");
                                    Console.ReadKey();
                                    break;
                                case 3:
                                    SetConsoleNotificationColor();
                                    Console.WriteLine("Список книг и журналов");
                                    SetConsoleDefaultColor();
                                    l.BooksList();
                                    l.JournalList();
                                    Console.WriteLine("Нажмите любую клавишу...");
                                    Console.ReadKey();
                                    break;
                                case 4:
                                    SetConsoleNotificationColor();
                                    Console.WriteLine("Конец работы");
                                    SetConsoleDefaultColor();
                                    if (!l.Employees[(int) numberEmp].DoJob)
                                        Console.WriteLine("Рабочий и так не на работе");
                                    else
                                        l.Employees[(int) numberEmp].Action();
                                    Console.WriteLine("Нажмите любую клавишу...");
                                    Console.ReadKey();
                                    break;
                                case 5:
                                    SetConsoleNotificationColor();
                                    Console.WriteLine("Оповещение");
                                    SetConsoleDefaultColor();
                                    l.Employees[(int) numberEmp].Enter();
                                    Console.WriteLine("Нажмите любую клавишу...");
                                    Console.ReadKey();
                                    break;
                                case 6:
                                    SetConsoleNotificationColor();
                                    Console.WriteLine("Оповещение");
                                    SetConsoleDefaultColor();
                                    l.Employees[(int) numberEmp].Leave();
                                    Console.WriteLine("Нажмите любую клавишу...");
                                    Console.ReadKey();
                                    break;
                                case 7:
                                    SetConsoleNotificationColor();
                                    Console.WriteLine("Рабочие обязанности");
                                    SetConsoleDefaultColor();
                                    l.Employees[(int) numberEmp].DoOneJob();
                                    Console.WriteLine("Нажмите любую клавишу...");
                                    Console.ReadKey();
                                    break;
                                case 0:
                                    stopEmp = true;
                                    break;
                            }
                        }

                        break;
                    case 5:
                        SetConsoleNotificationColor();
                        Console.WriteLine("Список посетителей");
                        SetConsoleDefaultColor();
                        l.VisitorsList();
                        break;
                    case 6:
                        SetConsoleNotificationColor();
                        Console.WriteLine("Список рабочих");
                        SetConsoleDefaultColor();
                        l.ListEmployees();
                        break;
                    case 7:
                        SetConsoleNotificationColor();
                        Console.WriteLine("Добавление книги");
                        SetConsoleDefaultColor();
                        Console.WriteLine("Введите наименование книги: ");
                        var name = Console.ReadLine();
                        Console.WriteLine("Введите автора книги: ");
                        var author = Console.ReadLine();
                        Console.WriteLine("Введите издательство книги: ");
                        var publication = Console.ReadLine();
                        Console.WriteLine("Введите год публикации книги: ");
                        ushort yearPublication;
                        while (!ushort.TryParse(Console.ReadLine(), out yearPublication))
                            Console.WriteLine("Введено неверное значение!");
                        Console.WriteLine("Введите жанр книги: ");
                        var genre = Console.ReadLine();
                        Console.WriteLine("Введите количество страниц: ");
                        ushort numberPage;
                        while (!ushort.TryParse(Console.ReadLine(), out numberPage))
                            Console.WriteLine("Введено неверное значение!");
                        Console.WriteLine("Введите ISBN код: ");
                        var ISBN = Console.ReadLine();
                        Console.WriteLine("Введите местоположение книги в библиотеке: ");
                        var location = Console.ReadLine();
                        Console.WriteLine("Введите количество доступных экземпляров: ");
                        uint count;
                        while (!uint.TryParse(Console.ReadLine(), out count))
                            Console.WriteLine("Введено неверное значение!");
                        l.GetCatalog.AddBooks(new Book(name, author, publication, yearPublication, genre, numberPage,
                            ISBN, location, count));
                        break;
                    case 8:
                        SetConsoleNotificationColor();
                        Console.WriteLine("Добавление журнала");
                        SetConsoleDefaultColor();
                        Console.WriteLine("Введите наименование журнала: ");
                        var nameJ = Console.ReadLine();
                        Console.WriteLine("Введите издательство журнала: ");
                        var authorJ = Console.ReadLine();
                        Console.WriteLine("Введите год публикации журнала: ");
                        ushort yearPublicationJ;
                        while (!ushort.TryParse(Console.ReadLine(), out yearPublicationJ))
                            Console.WriteLine("Введено неверное значение!");
                        Console.WriteLine("Введите местоположение журнала в библиотеке: ");
                        var locationJ = Console.ReadLine();
                        Console.WriteLine("Введите количество доступных экземпляров: ");
                        uint countJ;
                        while (!uint.TryParse(Console.ReadLine(), out countJ))
                            Console.WriteLine("Введено неверное значение!");
                        l.GetCatalog.AddJournal(new Journal(nameJ, authorJ, yearPublicationJ, locationJ, countJ));
                        break;
                    case 9:
                        l.BooksList();
                        l.JournalList();
                        break;
                    case 10:
                        SetConsoleNotificationColor();
                        Console.WriteLine("Библиотека открылась");
                        SetConsoleDefaultColor();
                        if (l.OpenOrClose)
                        {
                            Console.WriteLine("Библиотека уже открыта");
                            break;
                        }

                        Console.WriteLine("Рабочие начинают свой рабочий день");
                        foreach (IPerson people in l.Employees)
                        {
                            people.Enter();
                            people.Action();
                        }

                        foreach (IPerson people in l.Visitors) people.Enter();
                        l.OpenOrClose = true;
                        break;
                    case 11:
                        SetConsoleNotificationColor();
                        Console.WriteLine("Библиотека закрывается");
                        SetConsoleDefaultColor();
                        if (!l.OpenOrClose)
                        {
                            Console.WriteLine("Библиотека уже закрыта");
                            break;
                        }

                        Console.WriteLine("Рабочие заканчивают свой рабочий день");
                        foreach (IPerson people in l.Employees)
                        {
                            people.Action();
                            people.Leave();
                        }

                        foreach (IPerson people in l.Visitors) people.Leave();
                        l.OpenOrClose = false;
                        break;
                    case 0:
                        stopAll = true;
                        break;
                }

                if (stopAll) Console.WriteLine("Завершение программы...");
                Console.WriteLine("Нажмите любую клавишу...");
                Console.ReadKey();
            }
        }

        /// <summary>
        /// Установка цвета текста в консоли на режим "Служебный"
        /// </summary>
        private static void SetConsoleNotificationColor()
        {
            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.Red;
        }
        /// <summary>
        /// Установка цвета текста в консоли на режим "Обычный"
        /// </summary>
        private static void SetConsoleDefaultColor()
        {
            Console.BackgroundColor = _defaultBackground;
            Console.ForegroundColor = _defaultForeground;
        }

        public static void Print_Message(string message)
        {
            SetConsoleNotificationColor();
            Console.Write("Новое оповещение:");
            SetConsoleDefaultColor();
            Console.WriteLine(" " + message);
        }
    }
}