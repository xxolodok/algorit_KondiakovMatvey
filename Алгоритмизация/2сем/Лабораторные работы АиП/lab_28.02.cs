using System;
using System.Diagnostics;


class Program{
    static void Main(){
        Console.WriteLine("Выберите задачу: \n\t1. Первая задача;\n\t2. Вторая задача;");
        string action = Console.ReadLine();
        switch(action){
            case "1":
                FirstTask();
            break;
            case "2":
                SecondTask();
            break;
        }
    }

    static void FirstTask(){
        Console.WriteLine("Введите выражение: ");

        string expression = Console.ReadLine();
        string[] expressionSplit = expression.Split(' ');
        Stack<double> OperandsStack = new Stack<double>();
        double result = 0;
        double firstOperand = 0;
        double secondOperand = 0;
        bool error = false; //добвлена переменная для запоминания статуса ошибки завершения программы
    
        foreach(string c in expressionSplit){
            if(result==-1){
                break;
            }
            if(double.TryParse(c, out double num)){
                OperandsStack.Push(Convert.ToDouble(c));
            }
            if(c == "*" || c == "+" || c == "-" || c == "/"){
                if(!(OperandsStack.Count() == 0)){
                    firstOperand = OperandsStack.Pop();

                    try{                                        //try-catch для отловки нехватки операторов
                        secondOperand = OperandsStack.Pop();
                    }catch{
                        error = true;
                        break;
                    }

                    switch(c){
                        case "*":
                            result = secondOperand * firstOperand;
                            OperandsStack.Push(result);
                        break;
                        case "+":
                            result = secondOperand + firstOperand;
                            OperandsStack.Push(result);
                        break;
                        case "-":
                            result = secondOperand - firstOperand;
                            OperandsStack.Push(result);
                        break;
                        case "/":
                            result = (firstOperand == 0) ? IsNullOperand() : secondOperand / firstOperand; OperandsStack.Push(result); ;
                        break;
                    }
                }else{
                    Console.WriteLine("Стэк пуст"); break;
                }
            }
        }
        if(!error){                                                 //обработка ошибок
             if(OperandsStack.Count() > 1){
            Console.WriteLine("Ошибка: Выражение некорректно");
        }else{
            Console.WriteLine($"Конечный результат: {OperandsStack.Pop()}");
        }
        }else{
            Console.WriteLine("Ошибка: Нехватка операндов для действия");

        }
       
    }
    static double IsNullOperand(){
        Console.WriteLine("Деление на 0 невозможно");
        return -1;
    }

    static void SecondTask(){
        List<int> numbers = new List<int> { 1, 2, 2, 3, 4, 4, 4, 5, 1, 6, 3, 12, 23, 12 };
        HashSet<int> uniqueElements = new HashSet<int>(numbers);
        Dictionary<int, int> frequency = new Dictionary<int, int>();
        foreach (var number in numbers)
        {
            if (frequency.ContainsKey(number))
            {
                frequency[number]++;
            }
            else
            {
                frequency[number] = 1;
            }
        }
        Console.WriteLine("Список состоит из::");
        foreach (var element in uniqueElements)
        {
            Console.WriteLine(element);
        }
        Console.WriteLine("\nЧастота появления элементов:");
        foreach (var element in frequency)
        {
            Console.WriteLine($"Элемент {element.Key} появляется {element.Value} раз(а).");
        }
    }
}
