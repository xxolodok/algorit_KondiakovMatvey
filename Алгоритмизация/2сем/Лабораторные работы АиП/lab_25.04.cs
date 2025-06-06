using System;
using System.Collections.Generic;
using System.Linq;

class Phone
{
    public string Brand { get; set; }
    public int Year { get; set; }
    public string Country { get; set; }
    
    public override string ToString()
    {
        return $"{Brand} ({Year}), страна: {Country}";
    }
}

class Program
{
    static List<Phone> database = new List<Phone>();
    
    static void Main()
    {
        FillTestData();
        
        while (true)
        {
            Console.WriteLine("\nМеню:");
            Console.WriteLine("1. Добавить телефон в базу");
            Console.WriteLine("2. Группировка по стране");
            Console.WriteLine("3. Поиск по году выпуска");
            Console.WriteLine("4. Группировка по бренду");
            Console.WriteLine("5. Выход");
            Console.Write("Выберите действие: ");
            
            string choice = Console.ReadLine();
            
            switch (choice)
            {
                case "1":
                    AddPhone();
                    break;
                case "2":
                    GroupByCountry();
                    break;
                case "3":
                    FindByYear();
                    break;
                case "4":
                    GroupByBrand();
                    break;
                case "5":
                    return;
                default:
                    Console.WriteLine("Неверный выбор, попробуйте еще раз.");
                    break;
            }
        }
    }
    
    static void FillTestData()
    {
        database.Add(new Phone { Brand = "Samsung", Year = 2020, Country = "Россия" });
        database.Add(new Phone { Brand = "iPhone", Year = 2021, Country = "США" });
        database.Add(new Phone { Brand = "Xiaomi", Year = 2020, Country = "Китай" });
        database.Add(new Phone { Brand = "Huawei", Year = 2019, Country = "Китай" });
        database.Add(new Phone { Brand = "Samsung", Year = 2021, Country = "Казахстан" });
        database.Add(new Phone { Brand = "Nokia", Year = 2018, Country = "Россия" });
        database.Add(new Phone { Brand = "iPhone", Year = 2020, Country = "США" });
    }
    
    static void AddPhone()
    {
        Phone phone = new Phone();
        
        Console.Write("Введите бренд телефона: ");
        phone.Brand = Console.ReadLine();
        
        Console.Write("Введите год выпуска: ");
        if (!int.TryParse(Console.ReadLine(), out int year))
        {
            Console.WriteLine("Неверный год!");
            return;
        }
        phone.Year = year;
        
        Console.Write("Введите страну использования: ");
        phone.Country = Console.ReadLine();
        
        database.Add(phone);
        Console.WriteLine("Телефон добавлен в базу данных.");
    }
    
    static void GroupByCountry()
    {
        if (database.Count == 0)
        {
            Console.WriteLine("База данных пуста.");
            return;
        }
        
        var grouped = from phone in database
                     group phone by phone.Country into countryGroup
                     orderby countryGroup.Key
                     select countryGroup;
        
        Console.WriteLine("\nТелефоны, сгруппированные по странам:");
        foreach (var group in grouped)
        {
            Console.WriteLine($"\nСтрана: {group.Key}");
            foreach (var phone in group)
            {
                Console.WriteLine($"  {phone}");
            }
        }
    }
    
    static void FindByYear()
    {
        if (database.Count == 0)
        {
            Console.WriteLine("База данных пуста.");
            return;
        }
        
        Console.Write("Введите год для поиска: ");
        if (!int.TryParse(Console.ReadLine(), out int year))
        {
            Console.WriteLine("Неверный год");
            return;
        }
        
        var phones = from phone in database
                     where phone.Year == year
                     select phone;
        
        if (!phones.Any())
        {
            Console.WriteLine($"Не найдено телефонов за {year} год.");
            return;
        }
        
        Console.WriteLine($"\nТелефоны {year} года выпуска:");
        foreach (var phone in phones)
        {
            Console.WriteLine(phone);
        }
    }
    
    static void GroupByBrand()
    {
        if (database.Count == 0)
        {
            Console.WriteLine("База данных пуста.");
            return;
        }
        
        var grouped = from phone in database
                     group phone by phone.Brand into brandGroup
                     orderby brandGroup.Key
                     select brandGroup;
        
        Console.WriteLine("\nТелефоны по брендам:");
        foreach (var group in grouped)
        {
            Console.WriteLine($"\nБренд: {group.Key}");
            foreach (var phone in group)
            {
                Console.WriteLine($"  Год: {phone.Year}, страна: {phone.Country}");
            }
        }
    }
}