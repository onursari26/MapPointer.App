using MapPointer.App.Map;

namespace MapPointer.App.ZoneCounter
{
    class ZoneCounter : ZoneCounterInterface
    {
        private MapInterface _mapInterface;
        public void Init(MapInterface map)
        {
            _mapInterface = map;
        }

        public int Solve()
        {
            if (_mapInterface == null)
                return 0;

            int count = 0;

            int width, height;

            _mapInterface.GetSize(out width, out height);

            bool[] visited = new bool[width * height];

            for (int i = 0; i < width; ++i)
                for (int j = 0; j < height; ++j)
                    visited[j * width + i] = false;

            for (int i = 0; i < width; ++i)
            {
                for (int j = 0; j < height; ++j)
                {
                    if (!_mapInterface.IsBorder(i, j) && !visited[j * width + i])
                    {
                        Search(i, j, width, height, visited);
                        count++;
                    }
                }
            }

            return count;
        }

        private void Search(int x, int y, int width, int height, bool[] visited)
        {
            if (!_mapInterface.IsBorder(x, y) && !visited[y * width + x] && x >= 0 && y >= 0 && x < width && y < height)
            {
                visited[y * width + x] = true;
                Search(x - 1, y, width, height, visited);
                Search(x + 1, y, width, height, visited);
                Search(x, y - 1, width, height, visited);
                Search(x, y + 1, width, height, visited);
            }
        }
    }
}
