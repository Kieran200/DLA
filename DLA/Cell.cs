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

        public void Neighbor(int [,] field, out int stop, int N, int M)
        {
            stop = 0;
            for (int j = 0; j < 1; j++)
            {
                stop = 0;
                if (field[_x, _y + 1] == 1 && _y + 1 < M)
                {
                    stop++;
                    break;
                }
                if (field[_x, _y - 1] == 1 && _y - 1 > 0)
                {
                    stop++;
                    break;
                }
                if (field[_x + 1, _y] == 1 && _x + 1 < N)
                {
                    stop++;
                    break;
                }
                if (field[_x - 1, _y] == 1 && _x - 1 > 0)
                {
                    stop++;
                    break;
                }
                if (field[_x + 1, _y + 1] == 1 && _y + 1 < M && _x + 1 <N)
                {
                    stop++;
                    break;
                }
                if (field[_x + 1, _y - 1] == 1 && _y - 1 > 0 && _x + 1 < N)
                {
                    stop++;
                    break;
                }
                if (field[_x - 1, _y + 1] == 1 && _y + 1 <M && _x - 1 > 0)
                {
                    stop++;
                    break;
                }
                if (field[_x - 1, _y - 1] == 1 && _y - 1 > 0 && _x - 1 >0)
                {
                    stop++;
                    break;
                }
            }
        }

    }
}
