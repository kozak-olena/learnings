using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArrayList
{
    class Program
    {
        static void Main(string[] args)
        {
            ArrayList arrayList = new ArrayList();

            arrayList.Add(23);
            arrayList.Add(12);
            arrayList.Add(34);
            arrayList.Add(10);
            arrayList.Add(14);
            arrayList.Add(334);

            arrayList.Add(100);

            arrayList.RemoveAt(4);
            arrayList.RemoveAt(6);
        }
    }
}
