using System;

class Program
{
    static void Main()
    {
        
        AllTypesClass<string> StringArray = new AllTypesClass<string>(5);
        StringArray.Add("Мало");
        StringArray.Add("Мыло");
        StringArray.Add("Албом");
        

        AllTypesClass<int> intArray = new AllTypesClass<int>(3);
        intArray.Add(10);
        intArray.Add(20);
        intArray.Add(30);
        intArray.Add(40); 
        
        Console.WriteLine($"Элемент с индексом 1: {intArray.Get(1)}");
        intArray.RemoveAt(0);
        Console.WriteLine($"Теперь элемент с индексом 0: {intArray.Get(0)}");



    }
}

class AllTypesClass<T>
{
    private T[] Values;
    private int countOfValues;

    public AllTypesClass(int initLength)
    {
        if (initLength <= 0) throw new ArgumentException("Длина массива должна быть положительным числом", nameof(initLength));
        Values = new T[initLength];
        countOfValues = 0;
    }

    public void Add(T item)
    {
        if(countOfValues == Values.Length) throw new InvalidOperationException("Массив полон");        
        Values[countOfValues] = item;
        countOfValues++;
    }

    public T Get(int index)
    {
        if (index < 0 || index >= countOfValues)
        {
            throw new IndexOutOfRangeException($"Индекс {index} вне границ массива [0, {countOfValues - 1}]");
        }
        return Values[index];
    }

    public bool RemoveAt(int index)
    {
        if (index < 0 || index >= countOfValues)
        {
            return false;
        }

        for (int i = index; i < countOfValues - 1; i++)
        {
            Values[i] = Values[i + 1];
        }

        countOfValues--;
        Values[countOfValues] = default(T); 
        return true;
    }
}