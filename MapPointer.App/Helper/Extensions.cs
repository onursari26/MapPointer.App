using System.Collections.Generic;
using System.Linq;

namespace MapPointer.App.Helper
{
    public static class Extensions
    {
        public static void Resize<T>(this List<T> list, int count, T c)
        {
            if (count < list.Count)
                list.RemoveRange(count, list.Count - count);

            else if (count > list.Count)
            {
                if (count > list.Capacity)
                    list.Capacity = count;

                list.AddRange(Enumerable.Repeat(c, count - list.Count));
            }
        }

        public static void Resize<T>(this List<T> list, int sz) where T : new()
        {
            Resize(list, sz, new T());
        }
    }
}
