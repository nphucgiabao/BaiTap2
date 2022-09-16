﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace BaiTap2
{
    public class DoThi
    {
        public int soDinh { get; set; }
        public int[,] maTran { get; set; }
        public int start { get; set; }
        public int goal { get; set; }
        public async Task DocFileAsync(string duongDan)
        {
            if (File.Exists(duongDan))
            {
                using (var stream = new StreamReader(duongDan))
                {
                    var content = await stream.ReadToEndAsync();
                    var lines = content.Split("\n");
                    soDinh = int.Parse(lines[0]);
                    start = int.Parse(lines[1].Split(" ")[0]);
                    goal = int.Parse(lines[1].Split(" ")[1]);
                    maTran = new int[soDinh, soDinh];
                    for (var i = 0; i < soDinh; ++i)
                    {
                        var values = lines[i + 2].Split(" ");
                        for (var j = 0; j < values.Length; ++j)
                        {
                            if (values != null)
                                maTran[i, j] = int.Parse(values[j]);
                        }
                    }
                }
            }
            else
            {
                Console.WriteLine("File not found!!!");
            }
        }
    }
}
