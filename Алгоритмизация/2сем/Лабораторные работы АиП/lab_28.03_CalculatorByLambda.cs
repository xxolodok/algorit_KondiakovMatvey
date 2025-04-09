using System;

delegate int Add(int x, int y);
delegate int Subtract(int x, int y);
delegate int Multipy(int x, int y);
delegate int Divide(int x, int y);

class program{
    static void Main(){
        Add add = (x, y) => x + y;
        Subtract subtract = (x, y) => x - y;
        Multipy multipy = (x, y) => x * y;
        Divide divide = (x, y) => y != 0? x / y:-1;
    }
}
