using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DLA
{
    class Program
    {
        static void Main(string[] args)
        {
            int stop;
            Random rnd = new Random();
            Console.WriteLine("Enter the number of lines(odd): ");
            int N = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter the number of columns(odd): ");
            int M = Convert.ToInt32(Console.ReadLine());
            int[,] field = new int[N+1, M+1];
            Random random = new Random();

            field[N / 2, M / 2] = 1;

            while (true)
            {
                DrawField();
            S: Cell cell = new Cell(field, rnd.Next(0, N), rnd.Next(0, M));
                if (cell._x == N / 2 && cell._y == M / 2)
                    goto S;
                while (true)
                {
                    cell.Move(rnd.Next(0, 4), field, N, M);
                    DrawField();
                    Console.ReadKey();
                    cell.Neighbor(field, out stop, N, M);
                    if (stop > 0)
                    {
                        break;
                    }
                }

                Console.ReadKey();
            }


            void DrawField()        //метод вырисовки поля
            {
                Console.Clear();
                for (int j = 0; j < N; j++)
                {
                    for (int i = 0; i < M; i++)
                    {
                        if (field[i, j] == 1)
                            Console.ForegroundColor = ConsoleColor.Blue;
                        Console.Write(field[i, j]);
                        Console.ResetColor();
                    }
                    Console.WriteLine("");
                }

            }
        }

    }
}
