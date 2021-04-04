using MapPointer.App.Helper;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MapPointer.App.Map
{
    class Map : MapInterface
    {
        private List<List<bool>> _map = new();

        public void ClearBorder(int x, int y)
        {
            _map[x][y] = false;
        }

        public void GetSize(out int width, out int height)
        {
            width = _map.Count() > 0 ? _map.Count() : 0;
            height = _map.Count() > 0 ? _map[0].Count() : 0;
        }

        public bool IsBorder(int x, int y)
        {
            return x >= 0 && x < _map.Count() && y >= 0 && y < _map[0].Count() ? _map[x][y] : true;
        }

        public void SetBorder(int x, int y)
        {
            if (x >= 0 && y >= 0 && x < _map.Count() && y < _map[0].Count())
                _map[x][y] = true;
        }

        public void SetSize(in int width, in int height)
        {
            _map.Clear();

            _map.Resize(width);

            for (int x = 0; x < width; ++x)
            {
                _map[x].Resize(height);

                for (int y = 0; y < height; ++y)
                    _map[x][y] = false;
            }
        }

        public void Show()
        {
            int width, height;

            GetSize(out width, out height);

            for (int y = 0; y < width + 2; ++y)
                Console.Write('*');

            Console.Write("\n");

            for (int x = 0; x < height; ++x)
            {
                Console.Write('*');

                for (int j = 0; j < width; ++j)
                    Console.Write((_map[j][x] ? '*' : ' '));

                Console.Write('*');
                Console.Write("\n");
            }

            for (int j = 0; j < width + 2; ++j)
                Console.Write('*');

            Console.Write("\n");
        }

    }
}
