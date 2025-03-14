using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3
{
    public static class MakscoldSolution
    {
        public static void Foo(int[][] stack)
        {
            Console.WriteLine("Makscold Solution");
            foreach (var arr in stack)
            {
                Console.WriteLine(String.Join(' ', arr));
            }
        }
    }
}
