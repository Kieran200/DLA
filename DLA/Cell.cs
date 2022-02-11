using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DLA
{
    class Cell
    {
        public int _x;
        public int _y;
        public int[,] _field;
        public int Type;
        public Cell (int [,] field, int x, int y)
        {
            Type = 1;
            _field = field;
            _x = x;
            _y = y;
            _field[_x, _y] = Type;
        }

        public void NewCord(out int[,] field)
        {
            _field[_x, _y] = 0;
            _x +=1;
            _y +=1;
            _field[_x, _y] = Type;
            field = _field;
        }

            public void Move(int direction, int[,] field, int N, int M)
        {
            _field[_x, _y] = 0;
            switch (direction)
            {
                case 0:
                    {
                        if (_x + 1 < N && field[_x + 1, _y] == 0)
                        {
                            _x = _x + 1;
                            break;
                        }
                        else break;
                    }
                case 1:
                    {
                        if (_x - 1 > 0  && field[_x - 1, _y] == 0)
                        {
                            _x = _x - 1;
                            break;
                        }
                        else break;
                    }
                case 2:
                    {
                        if (_y - 1 > 0 && field[_x, _y - 1] == 0)
                        {
                            _y = _y - 1;
                            break;
                        }
                        else break;
                    }
                case 3:
                    {
                        if (_y + 1 < M && field[_x, _y + 1] == 0)
                        {
                            _y = _y + 1;
                            break;
                        }
                        else break;
                    }
            }
            _field[_x, _y] = Type;
        }

        public void Neighbor(int [,] field, out int stop, int N, int M)//У N и M лучше бы названия поосмысленнее дать, а то сразу непонятно
        {            
            stop = 0;
            //К проверке границ я не буду придираться, потому что тут дело вкуса - я люблю в отдельный метод пихать, и потом просто его вызывать
            //Если этот цикл прокручивается один раз, и вы его стопите на любом ифе, то этот цикл не нужен))
            ////for (int j = 0; j < 1; j++)
            ////{
            //   // stop = 0;
            //    if (field[_x, _y + 1] == 1 && _y + 1 < M)
            //    {
            //        stop++;
            //        //break;
            //    }
            //    if (field[_x, _y - 1] == 1 && _y - 1 > 0)
            //    {
            //        stop++;
            //       // break;
            //    }
            //    if (field[_x + 1, _y] == 1 && _x + 1 < N)
            //    {
            //        stop++;
            //        //break;
            //    }
            //    if (field[_x - 1, _y] == 1 && _x - 1 > 0)
            //    {
            //        stop++;
            //        //break;
            //    }
            //    if (field[_x + 1, _y + 1] == 1 && _y + 1 < M && _x + 1 <N)
            //    {
            //        stop++;
            //        //break;
            //    }
            //    if (field[_x + 1, _y - 1] == 1 && _y - 1 > 0 && _x + 1 < N)
            //    {
            //        stop++;
            //       // break;
            //    }
            //    if (field[_x - 1, _y + 1] == 1 && _y + 1 <M && _x - 1 > 0)
            //    {
            //        stop++;
            //       // break;
            //    }
            //    if (field[_x - 1, _y - 1] == 1 && _y - 1 > 0 && _x - 1 >0)
            //    {
            //        stop++;
            //       // break;
            //    }
            ////}
            
            //Теперь, как еще можно прокручивать, раз уж занятие я отменил
            //Если у нас 8 клеток соседей с диагоналями, то можно просто сделать цикл и навесить исключение клетки на саму себя
            for (int x =_x-1;x<=_x+1;x++)
                for (int y = _y - 1; y <= _y + 1; y++)
                {
                    if (x>=0&&y>=0&&x<N&&y<M)//Проверка границы
                    {
                        if (x == _x && y == _y)
                            continue;//Пропускаем шаг, если наткнулись на саму клетку
                        if (field[_x, _y] == 1)
                        {
                            stop++;
                            return;//Досрочное завершение метода
                        }
                           
                    }
                }
            //Получается мы пускаем цикл по квадрату 3х3 с центром в текущей клетке
        }

    }
}
