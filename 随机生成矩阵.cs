using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
namespace 随机生成矩阵
{
    class Program
    {
        static void Main(string[] args)
        {
            Random r = new Random();
            StringBuilder a = new StringBuilder();
            for (int i = 0; i < 8*125; i+=8)
            {
               a.Append(r.Next(100).ToString()+"   ");   
               a.Append(r.Next(100).ToString()+"   ");
               a.Append(r.Next(100).ToString()+"   ");
               a.Append(r.Next(100).ToString()+"   ");
               a.Append(r.Next(100).ToString()+"   ");
               a.Append(r.Next(100).ToString()+"   ");
               a.Append(r.Next(100).ToString()+"   ");
               a.AppendLine(r.Next(100).ToString()+"   ");             
            }
            File.WriteAllText("d:\\1.txt",a.ToString());
        }
    }
}
