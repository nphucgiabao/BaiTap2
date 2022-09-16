using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BaiTap2
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var doThi = new DoThi();
            await doThi.DocFileAsync("../../../input.txt");
            Caub(doThi);
            Console.ReadKey();
        }

        static void Caub(DoThi doThi)
        {
            Queue<int> queue = new Queue<int>();
            bool[] visited = new bool[doThi.soDinh];
            int[] parent = new int[doThi.soDinh];
            for (var i = 0; i < parent.Length; i++)
            {
                parent[i] = -1;
            }
            for (var i = doThi.start; i < doThi.soDinh && !visited[i]; i++)
            {
                visited[i] = true;
                if (i != doThi.goal)
                {
                    queue.Enqueue(i);
                    while (queue.Count > 0)
                    {
                        var vertex = queue.Dequeue();
                        var cacDinhKe = doThi.TimDinhKe(vertex);
                        if (cacDinhKe.Count > 0)
                        {
                            cacDinhKe.ForEach(x =>
                            {
                                if (!visited[x])
                                {
                                    visited[x] = true;
                                    parent[x] = vertex;
                                    queue.Enqueue(x);
                                }
                            });
                        }
                    }
                }                
            }

            //int cur = doThi.start;
            //while (cur != doThi.goal)
            //{
            //    Console.Write("{0} ", cur);
            //    cur = parent[cur];
            //}
        }
    }
}
