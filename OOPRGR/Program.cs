namespace OOPRGR
{
    class Program
    {
        static void Main(string[] args)
        {
            Library l = new Library("Хорошее место", "Каждый день с 8:00 до 22:00", "Не шуметь...", new Catalog());
            Employee director1 = new Director("Иванченко Владислав Антонович", "5004-354956", 85000);
            l.GetCatalog.AddBooks(new Book("В царстве животных", "Иванов И.И.", "Москва-Река", 2021, "Фантастика", 254, 
                "12312-12312-12312", "2 полка в 3 ряду", 20));
        }
    }
}
