using System;
using System.Data;

class Program
{
    public class Abonent
    {
        public string Fullname;
        public string Number; 
        public string Operator;
        public int YearSubs;
        public string CityOfSubs;

        public Abonent(string fullname, string number, string operatorName, int yearSubs, string cityOfSubs)
        {
            Fullname = fullname;
            Number = number;
            Operator = operatorName;
            YearSubs = yearSubs;
            CityOfSubs = cityOfSubs;
        }

        public override string ToString()
        {
            return $"{Fullname}, {Number}, {Operator}, {YearSubs}, {CityOfSubs}";
        }
    }

    public class Base
    {
        public Abonent[] Abonents = new Abonent[1024];
        private int countSubs = 0;

        public void AddAbonent_Test() //Добваляются тестовые записи, так же присутствует добавление вручную
        {
            string[,] testAbonents = new string[,]
            {
                {"Иванов Иван Иванович", "89001234567", "МТС", "2020", "Москва"},
                {"Петров Петр Петрович", "89001234567", "Билайн", "2019", "Санкт-Петербург"},
                {"Сидоров Сидор Сидорович", "89003456789", "МегаФон", "2021", "Екатеринбург"},
                {"Кузнецов Николай Николаевич", "89004567890", "Теле2", "2022", "Казань"},
                {"Смирнов Алексей Алексеевич", "89005678901", "МТС", "2018", "Новосибирск"},
                {"Попов Василий Васильевич", "89006789012", "Билайн", "2020", "Нижний Новгород"},
                {"Васильев Виктор Викторович", "89007890123", "МегаФон", "2021", "Челябинск"},
                {"Зайцев Дмитрий Дмитриевич", "89008901234", "Теле2", "2022", "Волгоград"},
                {"Дмитриев Антон Антонович", "89009012345", "МТС", "2023", "Ростов-на-Дону"},
                {"Соловьев Сергей Сергеевич", "89010123456", "Билайн", "2020", "Краснодар"}
            };

            for (int i = 0; i < testAbonents.GetLength(0); i++)
            {
                Abonents[countSubs] = new Abonent(testAbonents[i, 0], testAbonents[i, 1], testAbonents[i, 2], Convert.ToInt32(testAbonents[i, 3]), testAbonents[i, 4]);
                countSubs++;
            }
        }

        public void AddAbonent()
        {
            Console.WriteLine("Введите ФИО: ");
            string fullname = Console.ReadLine();
            Console.WriteLine("Введите номер в формате: '8xxxxxxxxxx' : ");
            string number = Console.ReadLine();
            Console.WriteLine("Введите оператора: ");
            string operatorName = Console.ReadLine();
            Console.WriteLine("Введите год регистрации номера: ");
            int yearSubs = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Введите город регистрации: ");
            string cityOfSubs = Console.ReadLine();

            if (countSubs < Abonents.Length)
            {
                Abonents[countSubs] = new Abonent(fullname, number, operatorName, yearSubs, cityOfSubs);
                Console.WriteLine(Abonents[countSubs].ToString());
                countSubs++;
                Console.WriteLine("Абонент добавлен.");
            }
            else
            {
                Console.WriteLine("База абонентов заполнена.");
            }
        }
        public void SearchByOperator()
        {
            Console.WriteLine("По какому оператору искать?");
            string OperatorForSearch = Console.ReadLine();
            for (int i = 0; i < countSubs; i++)
            {
                if (Abonents[i].Operator == OperatorForSearch)
                {
                    Console.WriteLine(Abonents[i].ToString());
                }
            }
        }
        public void SearchByYear()
        {
            Console.WriteLine("По какому году искать?");
            int YearForSearch = Convert.ToInt32(Console.ReadLine());
            for (int i = 0; i < countSubs; i++)
            {
                if (Abonents[i].YearSubs == YearForSearch)
                {
                    Console.WriteLine(Abonents[i].ToString());
                }
            }
        }
        public void SearchByNumber()
        {
            Console.WriteLine("По какому номеру искать?");
            string NumberForSearch = Console.ReadLine();
            for (int i = 0; i < countSubs; i++)
            {
                if (Abonents[i].Number == NumberForSearch)
                {
                    Console.WriteLine(Abonents[i].ToString());
                }
            }
        }

    }

    static void Main()
    {
        Base phoneBase = new Base();
        phoneBase.AddAbonent_Test();
        string action;
        bool end = false;
        while (!end)
        {
            Console.WriteLine("Выберите действие: \n\t1. Заполнить базу номеров\n\t2. Выборка по Оператору\n\t3. Выборка по номеру\n\t4. Выборка по году\n\t5. Выход");
            action = Console.ReadLine();
            switch (action)
            {
                case "1":
                    phoneBase.AddAbonent();
                    break;
                case "2":
                    phoneBase.SearchByOperator();
                    break;
                case "3":
                    phoneBase.SearchByNumber();
                    break;
                case "4":
                    phoneBase.SearchByYear();
                    break;
                case "5":
                    end = true;
                    break;
            }
        }
    }
}
