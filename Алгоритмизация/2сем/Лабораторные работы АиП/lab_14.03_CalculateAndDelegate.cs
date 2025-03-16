using System;

class Calculator
{

    public int FirstNumber;
    public int SecondNumber;

    public Calculator(int firstNumber, int secondNumber)
    {

        FirstNumber = firstNumber;
        SecondNumber = secondNumber;

    }

    public int Add()
    {

        int sum = FirstNumber + SecondNumber;
        return sum;

    }
    public int difference()
    {

        int difference = FirstNumber - SecondNumber;
        return difference;

    }

    public int multiply()
    {

        int multiply = FirstNumber * SecondNumber;
        return multiply;

    }

    public int divide()
    {
        if (SecondNumber == 0)
        {
            throw new Exception("Деление на 0 невозможно");
        }
        else
        {

            int devide = FirstNumber / SecondNumber;
            return devide;

        }
    }
}

class Program
{
    public delegate int CalculatorAction(Calculator calc);

    static void Main()
    {
        Calculator calculatorObj_1 = new Calculator(10, 5);
        Calculator calculatorObj_2 = new Calculator(20, 0);

        CalculatorAction delegateFirst = new CalculatorAction(FirstFunctionForDelegate);
        CalculatorAction delegateSecond = new CalculatorAction(SecondFunctionForDelegate);

        int resultFirstdelegate = delegateFirst(calculatorObj_1);
        Console.WriteLine("\nРезультат первого делегата: " + resultFirstdelegate + "\n");

        Console.WriteLine("\nРезультат второго делегата: \n");
        int resultSeconddelegate = delegateSecond(calculatorObj_2);
    }

    static int FirstFunctionForDelegate(Calculator calc)
    {
        int sum = calc.Add();
        int multiplied = sum * calc.SecondNumber;
        int divided = multiplied / calc.SecondNumber;
        return divided;
    }
    static int SecondFunctionForDelegate(Calculator calc)
    {
        int division = calc.divide();
        int subtracted = division - calc.SecondNumber;
        int multiplied = subtracted * calc.SecondNumber;
        return multiplied;
    }
}