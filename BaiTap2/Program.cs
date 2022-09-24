using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BaiTap2
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var doThi = new DoThi();
            await doThi.DocFileAsync("../../../input.txt");
            Cau_A(doThi);
            Cau_B(doThi);
            Cau_C(doThi);
            Console.ReadKey();
        }

        static void Cau_B(DoThi doThi)
        {
            Queue<int> queue = new Queue<int>();
            bool[] visited = new bool[doThi.soDinh];
            int[] parent = new int[doThi.soDinh];
            for (var i = 0; i < parent.Length; i++)
            {
                parent[i] = -1;
            }
            string result = string.Empty;
            if (!visited[doThi.start])
            {
                visited[doThi.start] = true;
                queue.Enqueue(doThi.start);
                while (queue.Count > 0)
                {
                    var vertex = queue.Dequeue();
                    result += $"{vertex} ";
                    if (vertex != doThi.goal)
                    {
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
                    else
                    {
                        Console.WriteLine("Danh sach cac dinh da duyet theo thu tu:");
                        Console.WriteLine(result);
                        Console.WriteLine("Duong di in kieu nguoc:");
                        int cur = doThi.goal;
                        while (cur != doThi.start)
                        {
                            Console.Write("{0} <- ", cur);
                            cur = parent[cur];
                        }
                        Console.WriteLine(doThi.start);
                        return;
                    }
                }
                Console.WriteLine("Khong co duong di");
            }

        }

        static void Cau_C(DoThi doThi)
        {
            if (doThi.KiemTraMaTranDoiXung())
            {
                Queue<int> queue = new Queue<int>();
                bool[] visited = new bool[doThi.soDinh];
                int[] labels = new int[doThi.soDinh];               
                string result = string.Empty;
                int label = 0;
                for (var i = 0; i < doThi.soDinh; i++)
                {
                    if (!visited[i])
                    {
                        label = label + 1;
                        labels[i] = label;
                        visited[i] = true;
                        queue.Enqueue(i);
                        while (queue.Count > 0)
                        {
                            var vertex = queue.Dequeue();
                            result += $"{vertex} ";
                            var cacDinhKe = doThi.TimDinhKe(vertex);
                            if (cacDinhKe.Count > 0)
                            {
                                cacDinhKe.ForEach(x =>
                                {
                                    if (!visited[x])
                                    {
                                        visited[x] = true;
                                        labels[x] = labels[vertex];
                                        queue.Enqueue(x);
                                    }
                                });
                            }
                        }
                    }                    
                }
                var x = labels.GroupBy(x => x).Select(g => g.Key);

                Console.Write("So thanh phan lien thong: {0}", x.Count());
                for (var i = 0; i < x.Count(); i++)
                {
                    Console.Write("\nThanh phan lien thong thu {0}: ", x.ToList()[i]);
                    for (var j = 0; j < labels.Length; j++)
                    {
                        if (labels[j] == x.ToList()[i])
                            Console.Write("{0} ", j);
                    }
                }
            }
        }

        static void Cau_A(DoThi doThi)
        {
            Stack<int> stack = new Stack<int>();
            bool[] visited = new bool[doThi.soDinh];
             int[] parent = new int[doThi.soDinh];
            for (var i = 0; i < parent.Length; i++)
            {
                parent[i] = -1;
            }
            
            string result = string.Empty;
            if (!visited[doThi.start])
            {
                visited[doThi.start] = true;
                stack.Push(doThi.start);
                while (stack.Count > 0)
                {
                    var vertex = stack.Pop();
                    result += $"{vertex} ";
                    if (vertex != doThi.goal)
                    {
                        var cacDinhKe = doThi.TimDinhKe(vertex);
                        if (cacDinhKe.Count > 0)
                        {
                            cacDinhKe.ForEach(x =>
                            {
                                
                                if (!visited[x])
                                {
                                    visited[x] = true;
                                    parent[x] = vertex;
                                    stack.Push(x);
                                }
                            });
                        }
                    }
                    else
                    {
                        Console.WriteLine("Danh sach cac dinh da duyet theo thu tu:");
                        Console.WriteLine(result);
                        Console.WriteLine("Duong di in kieu nguoc:");
                        int cur = doThi.goal;
                        while (cur != doThi.start)
                        {
                            Console.Write("{0} <- ", cur);
                            cur = parent[cur];
                        }
                        Console.WriteLine(doThi.start);
                        return;
                    }
                }
                Console.WriteLine("Khong co duong di");
            }

        }
       

        

        

    }
}
