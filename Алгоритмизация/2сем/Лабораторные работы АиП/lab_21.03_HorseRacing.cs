using System;

delegate void horseWins();

class Program{
    static void Main(){
        Horse[] horseList = new Horse[10];

        for(int i = 0; i<10; i++){
            horseList[i] = new Horse();
        }

        HorseRacing racing = new HorseRacing(100, horseList);

        racing.horseWinEvent += () => {Console.WriteLine("Есть победитель");};        

        racing.Start();
    }
}


class Horse{
    public int horsePosition;

    public Horse(){
        horsePosition = 0;
    }

    public void Move()
    {

        var r = new Random();

        horsePosition += r.Next(5, 10);

    }}


class HorseRacing{

    public int finishPosition;
    public Horse[] horseList;
    public bool isHorseWins;

    public event horseWins horseWinEvent;

    public HorseRacing(int finishposition, Horse[] horselist){
        horseList = horselist;
        finishPosition = finishposition;
        isHorseWins = false;
    }


    public void Start(){
        while(!isHorseWins){
            foreach(var horse in horseList){
                horse.Move();
                if(horse.horsePosition <= finishPosition){
                    
                    Console.WriteLine($"{horse.horsePosition}");

                }else{
                    horseWinEvent();
                    isHorseWins = true;
                    break;
                }
            }
            Console.WriteLine("-----------");
        }
    }
}

