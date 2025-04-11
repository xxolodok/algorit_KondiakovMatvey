using System;
using Microsoft.VisualBasic;

delegate void horseWins();

class Program{
    static void Main(){
        Horse[] horseList = new Horse[10];

        for(int i = 0; i<10; i++){
            horseList[i] = new Horse();
        }

        HorseRacing racing = new HorseRacing(100, horseList);
        HorseFinish winsEvent = new HorseFinish();
        winsEvent.horseFinishEvent += () => {Console.WriteLine("Есть победитель");};        

        racing.Start(winsEvent);
    }
}

class HorseFinish{
    public event horseWins horseFinishEvent;

    public void Raisehorsefinish(){
        horseFinishEvent();
    }

}
class Horse{
    public Random r = new Random();

    public int horsePosition;

    public Horse(){
        horsePosition = 0;
    }

    public void Move()
    {


        horsePosition += r.Next(5, 10);

    }}


class HorseRacing{

    public int finishPosition;
    public Horse[] horseList;
    public bool isHorseWins;

    public HorseRacing(int finishposition, Horse[] horselist){
        horseList = horselist;
        finishPosition = finishposition;
        isHorseWins = false;
    }


    public void Start(HorseFinish e){
        while(!isHorseWins){
            foreach(var horse in horseList){
                horse.Move();
                if(horse.horsePosition < finishPosition){
                    
                    Console.WriteLine($"{horse.horsePosition}");

                }else{
                    e.Raisehorsefinish();          
                    isHorseWins = true;
                    break;
                }
            }
            Console.WriteLine("-----------");
        }
    }
}

