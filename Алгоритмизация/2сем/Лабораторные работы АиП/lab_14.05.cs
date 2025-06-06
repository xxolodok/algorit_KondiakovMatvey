public class Computer
{
    public int Id { get; set; }
    public string Brand { get; set; }
    public string Model { get; set; }
}

public class OperatingSystem
{
    public int Id { get; set; }
    public string Name { get; set; }
}

public class User
{
    public int UserId { get; set; }
    public string FullName { get; set; }
    public bool HasLaptop { get; set; }
    public string LaptopBrand { get; set; }
    public string OperatingSystem { get; set; }
}

class Program
{
    static void Main()
    {
        var usersGroupedByLaptop = users
    .GroupBy(u => u.HasLaptop)
    .Select(g => new
    {
        HasLaptop = g.Key ? "Да" : "Нет",
        Users = g.Select(u => new { u.FullName }).ToList()
    })
    .ToList();


        var usersGroupedByLaptopBrand = users
            .Where(u => u.HasLaptop)
            .GroupBy(u => u.LaptopBrand)
            .Select(g => new
            {
                LaptopBrand = g.Key,
                Users = g.Select(u => new { u.FullName }).ToList()
            })
            .ToList();


        var usersGroupedByOperatingSystem = users
            .GroupBy(u => u.OperatingSystem ?? "Нет")
            .Select(g => new
            {
                OperatingSystem = g.Key,
                Users = g.Select(u => new { u.FullName }).ToList()
            })
            .ToList();


        var userDetails = users
            .Select(u => new
            {
                u.FullName,
                HasLaptop = u.HasLaptop ? "Да" : "Нет",
                LaptopBrand = u.LaptopBrand,
                LaptopModel = u.HasLaptop,
                OperatingSystem = u.OperatingSystem ?? "Нет"
            })
            .ToList();

    }
}