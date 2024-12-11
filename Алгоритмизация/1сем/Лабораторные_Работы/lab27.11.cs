using System;

class Numbers {
    public int Number1;
    public int Number2;

    public Numbers() {
        Number1 = 0;
        Number2 = 0; 
    }

    public Numbers(int number1) {
        Number1 = number1;
        Number2 = 0; 
    }

    public Numbers(int number1, int number2) {
        Number1 = number1;
        Number2 = number2;
    }

    public void Sum() {
        Console.WriteLine("Сумма: " + (Number1 + Number2));
    }

    public void Def() {
        Console.WriteLine("Разность: " + (Number1 - Number2));
    }

    public void Mult() {
        Console.WriteLine("Произведение: " + (Number1 * Number2));
    }

    public void Div() {
        if (Number2 == 0) {
            Console.WriteLine("На ноль делить нельзя");
        } else {
            Console.WriteLine("Деление: " + (Number1 / Number2));
        }
    }
}

class Lab {
    static void Main() {
        Numbers num = new Numbers();
        num.Sum();
        num.Def();
        num.Mult();
        num.Div();
    Console.WriteLine("----------------------");
        Numbers num2 = new Numbers(1);
        num2.Sum();
        num2.Def();
        num2.Mult();
        num2.Div();
    Console.WriteLine("----------------------");

        Numbers num3 = new Numbers(12, 4);
        num3.Sum(); 
        num3.Def();
        num3.Mult();
        num3.Div();
    }
}
