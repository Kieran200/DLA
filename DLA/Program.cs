using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DLA
{
    //Поле некорректно расширяется - появляются промежутки между ячейками
    class Program
    {
        static void Main()
        {
            int stop=0;//Вроде, не должно ломаться
            int number = 0;
            Random rnd = new Random();
            int N = 6; 
            int M = 6;
            Random random = new Random();
            List<Cell> cList = new List<Cell>();
            int[,] field = new int[N + 100, M + 100];//Почему 100?))

            while (true)
            {
                if (number == 0)
                {
                    Cell cell = new Cell(field, N/2, M/2);
                    cList.Add(cell);
                    number++;
                }
                //Учитесь писать без указателей)
                int x = 0; 
                int y = 0;
                do
                {
                    x = rnd.Next(1, N);
                    y = rnd.Next(1, M);
                } while (field[x, y] != 0); 
                DrawField();
                if (field[x, y] == 0)
                {
                    Cell cell = new Cell(field, x, y);
                    cList.Add(cell);
                }                
                while (stop <=0)
                {
                    cList[number].Move(rnd.Next(0, 4), field, N, M);
                    DrawField();
                    Console.ReadKey();
                    cList[number].Neighbor(field, out stop, N, M);
                    if (stop > 0)
                    {
                        break;
                    }
                }
                Console.ReadKey();
                number++;        
                Central();
            }

            void Central()  //централизация кристалла после увеличения поля
            {
                N += 2;
                M += 2;
                for (int i = 0; i < cList.Count; i++)
                {
                    cList[i].NewCord(out field);
                }
            }

            void DrawField()        //метод вырисовки поля
            {
                Console.Clear();
                for (int j = 1; j < N; j++)
                {
                    for (int i = 1; i < M; i++)
                    {
                        if (field[i, j] == 1)
                            Console.ForegroundColor = ConsoleColor.Blue;
                        Console.Write(field[i, j]);
                        Console.ResetColor();
                    }
                    Console.WriteLine();//Можно просто пустые скобки оставить
                }
            }
        }

    }
}
