using System;

class Animal
{
    public string Name ;

    public Animal(string name)
    {
        Name = name;
    }
}

class Bird : Animal
{
    public string Habitat ;
    public string WinteringPlace ;

    public Bird(string name, string habitat, string winteringPlace) : base(name)
    {
        Habitat = habitat;
        WinteringPlace = winteringPlace;
    }
}

class Mammal : Animal
{
    public string Habitat ;
    public double Weight ;

    public Mammal(string name, string habitat, double weight) : base(name)
    {
        Habitat = habitat;
        Weight = weight;
    }
}

class Program
{
    static void Main()
    {
        Bird[] birds = new Bird[]
        {
            new Bird("Синица", "Лес", "Южные страны"),
            new Bird("Ласточка", "Город", "Южные страны"),
            new Bird("Орёл", "Горы", "Не мигрирует"),
        };

        Mammal[] mammals = new Mammal[]
        {
            new Mammal("Лев", "Саванна", 190),
            new Mammal("Тигр", "Лес", 220),
            new Mammal("Слон", "Саванна", 6000),
        };

        string selectedHabitat = "Лес";
        string selectedWinteringPlace = "Южные страны";
        Console.WriteLine("Отфильтрованные птицы:");

        Console.WriteLine("По месту обитания");
        foreach (var bird in birds)
        {
            if (bird.Habitat == selectedHabitat)
            {
                Console.WriteLine($"\nНазвание: {bird.Name},\nОбитание: {bird.Habitat},\nМесто зимовки: {bird.WinteringPlace}");
            }
        }

        Console.WriteLine("По месту Зимовки");
        foreach (var bird in birds)
        {
            if ( bird.WinteringPlace == selectedWinteringPlace)
            {
                Console.WriteLine($"\nНазвание: {bird.Name},\nОбитание: {bird.Habitat},\nМесто зимовки: {bird.WinteringPlace}");
            }
        }
        double maxWeight = 200;
        Console.WriteLine("\nОтфильтрованные млекопитающие:");
        foreach (var mammal in mammals)
        {
            if (mammal.Weight <= maxWeight)
            {
                Console.WriteLine($"\nНазвание: {mammal.Name},\nОбитание: {mammal.Habitat},\nВес: {mammal.Weight} кг");
            }
        }
    }
}
