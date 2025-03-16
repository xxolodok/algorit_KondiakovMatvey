using System;
using System.Collections.Generic;

// Класс "Машина"
public class Car
{
    public int Year;
    public string Model;
    public string Color;
    public bool IsDirty; 

    public Car(int year, string model, string color, bool isDirty)
    {
        Year = year;
        Model = model;
        Color = color;
        IsDirty = isDirty;
    }

}

public delegate void CarWasher(Car car);

public class Garage
{
    private List<Car> cars;

    public Garage()
    {
        cars = new List<Car>();
    }

    public void AddCar(Car car)
    {
        cars.Add(car);
    }

    public List<Car> GetCars()
    {
        return cars;
    }
}

public class CarWash
{
    public void WashCar(Car car)
    {
        if (car.IsDirty)
        {
            car.IsDirty = false;
            Console.WriteLine($"{car.Model} отмыта от вековой грязи");
        }
        else
        {
            Console.WriteLine($"{car.Model} уже чиста");
        }
    }
}

public class Program
{
    public static void Main()
    {
        Garage garage = new Garage();
        garage.AddCar(new Car(2020, "Тайота", "Синий", true));
        garage.AddCar(new Car(2018, "Ока", "Черный", false));
        garage.AddCar(new Car(2021, "тачка", "Красный", true));

        CarWash carWash = new CarWash();

        CarWasher washDelegate = new CarWasher(carWash.WashCar);

        foreach (var car in garage.GetCars())
        {
            washDelegate(car);
        }
    }
}
