using System;
using System.Collections.Generic;

class TelePhone
{
    public string FullName;
    public string Number;
    public string Operator;

    public TelePhone(string fullName, string number, string operatorName)
    {
        FullName = fullName;
        Number = number;
        Operator = operatorName;
    }
}

class Program
{
    static void Main()
    {
        List<TelePhone> telePhoneList = new List<TelePhone>
        {
            new TelePhone("Иванов Иван Иванович", "89001234567", "МТС"),
            new TelePhone("Петров Петр Петрович", "89007654321", "Билайн"),
            new TelePhone("Сидоров Сидор Сидорович", "89001234567", "МТС"),
            new TelePhone("Кузнецова Анна Сергеевна", "89009876543", "Теле2"),
            new TelePhone("Смирнова Ольга Владимировна", "89004567890", "Билайн"),
            new TelePhone("Семенов Семен Семенович", "89001234567", "МТС"),
        };

        Dictionary<string, int> operators = new Dictionary<string, int>();

        foreach (var telePhone in telePhoneList)
        {
            if (operators.TryGetValue(telePhone.Operator, out int count))
            {
                operators[telePhone.Operator] = count + 1;
            }
            else
            {
                operators[telePhone.Operator] = 1;
            }
        }

        var mostFrequentOperator = operators.OrderByDescending(o => o.Value).First();

    }
}
