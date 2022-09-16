using System;
using System.Threading.Tasks;

namespace BaiTap2
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var doThi = new DoThi();
            await doThi.DocFileAsync("../../../input.txt");
            Console.WriteLine("{0} {1}", doThi.start, doThi.goal);
            Console.ReadKey();
        }
    }
}
