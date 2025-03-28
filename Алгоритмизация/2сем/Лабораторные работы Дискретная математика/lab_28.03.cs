using System;

class Program
{
    static void Main()
    {
        bool deadEnd = false;
        int step = 0;
        int[] endPoint = new int[2];

        

        string[,] labyrinth = new string[6, 6]{
            {"0", "x", "-", "x", "x", "x"},
            {"-", "x", "-", "x", "-", "-"},
            {"-", "x", "-", "-", "-", "-"},
            {"-", "-", "-", "-", "-", "-"},
            {"-", "x", "-", "-", "x", "-"},
            {"-", "x", "-", "-", "x", " "},
        };

        for(int i = 0; i<6; i++){
            for(int j = 0; j<6; j++){
                if(labyrinth[i,j] == " "){
                    endPoint[0] = i;
                    endPoint[1] = j;
                } 
            }
        }

        while (!deadEnd)
        {
            bool updatedByStep = false;

            for (int i = 0; i < 6; i++)
            {
                for (int j = 0; j < 6; j++)
                {
                    if (labyrinth[i, j] == step.ToString())
                    {
                        for (int k = 0; k < 4; k++)
                        {
                            int row = i;
                            int col = j;

                            switch (k)
                            {
                                case 0:
                                    row = i - 1;
                                    break;
                                case 1: 
                                    row = i + 1; 
                                    break;
                                case 2: 
                                    col = j - 1; 
                                    break;
                                case 3: 
                                    col = j + 1; 
                                    break;
                            }

                            if (row >= 0 && row < 6 && col >= 0 && col < 6)
                            {
                                if (labyrinth[row, col] == "-" || labyrinth[row, col] == " ")
                                {
                                    labyrinth[row, col] = (step + 1).ToString();
                                    updatedByStep = true;
                                }
                            }
                        }
                    }
                }
            }

            if (!updatedByStep)
            {
                deadEnd = true;
            }

            step++;
        }
        if(labyrinth[endPoint[0], endPoint[1]] == " "){
            Console.WriteLine($"Выхода нет");
            
        }else{
            Console.WriteLine($"Выход найден за {step} шагов");

        }

        Print2DArray(labyrinth);
    }

    static void Print2DArray(string[,] array)
    {
        int rows = array.GetLength(0);
        int cols = array.GetLength(1);

        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++)
            {
                Console.Write(array[i, j] + " ");
            }
            Console.WriteLine();
        }
    }
}
