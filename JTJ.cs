using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MathNet.Numerics.LinearAlgebra;
using MathNet.Numerics.LinearAlgebra.Double;
using System.IO;
using System.Text.RegularExpressions;
namespace JtJ
{
    class Program
    {
        static void Main(string[] args)
        {
            Matrix<double> J = Matrix<double>.Build.Dense(125, 8);
            string[] all = File.ReadAllLines("in.txt");
            for (int i = 0; i < all.Length; i++)
            {
                string[] eachline = all[i].Split(new string[] { "  " }, StringSplitOptions.RemoveEmptyEntries);
                for (int j = 0; j < eachline.Length - 1; j++)
                {
                    J[i, j] = double.Parse(eachline[j]);
                }
            }
            //方法1：
            Matrix<double> Jt = J.Transpose();
            Matrix<double> JtJ = Jt * J;
            File.WriteAllText("out.txt", JtJ.ToString());
            Console.WriteLine(JtJ);
            Console.WriteLine(JtJ.Inverse());



            //方法2：
            double[,] result = new double[8, 8];
            int N = 125;
            //result[0,0]=J[0,0]*J[0,0]+J[1,0]*J[1,0]+...J[125,0]*J[125,0];
            //for (int i = 0; i <N; i++)
            //{
            //    result[0, 0] += J[i, 0] * J[i, 0];
            //    result[0, 1] += J[i, 0] * J[i, 1];
            //    result[0, 2] += J[i, 0] * J[i, 2];
            //    result[0, 3] += J[i, 0] * J[i, 3];
            //    result[0, 4] += J[i, 0] * J[i, 4];
            //    result[0, 5] += J[i, 0] * J[i, 5];
            //    result[0, 6] += J[i, 0] * J[i, 6];
            //    result[0, 7] += J[i, 0] * J[i, 7];
            //    result[1, 1] += J[i, 1] * J[i, 1];
            //    result[1, 2] += J[i, 1] * J[i, 2];
            //    result[1, 3] += J[i, 1] * J[i, 3];
            //    result[1, 4] += J[i, 1] * J[i, 4];
            //    result[1, 5] += J[i, 1] * J[i, 5];
            //    result[1, 6] += J[i, 1] * J[i, 6];
            //    result[1, 7] += J[i, 1] * J[i, 7];
            //    result[2, 2] += J[i, 2] * J[i, 2];     
            //    result[2, 3] += J[i, 2] * J[i, 3];     
            //    result[2, 4] += J[i, 2] * J[i, 4];     
            //    result[2, 5] += J[i, 2] * J[i, 5];            
            //    result[2, 6] += J[i, 2] * J[i, 6];     
            //    result[2, 7] += J[i, 2] * J[i, 7];            
            //    result[3, 3] += J[i, 3] * J[i, 3];     
            //    result[3, 4] += J[i, 3] * J[i, 4];                 
            //    result[3, 5] += J[i, 3] * J[i, 5];     
            //    result[3, 6] += J[i, 3] * J[i, 6];                           
            //    result[3, 7] += J[i, 3] * J[i, 7];        
            //    result[4, 4] += J[i, 4] * J[i, 4];               
            //    result[4, 5] += J[i, 4] * J[i, 5];    
            //    result[4, 6] += J[i, 4] * J[i, 6];               
            //    result[4, 7] += J[i, 4] * J[i, 7];    
            //    result[5, 5] += J[i, 5] * J[i, 5];    
            //    result[5, 6] += J[i, 5] * J[i, 6];               
            //    result[5, 7] += J[i, 5] * J[i, 7];    
            //    result[6, 6] += J[i, 6] * J[i, 6];               
            //    result[6, 7] += J[i, 6] * J[i, 7];    
            //    result[7, 7] += J[i, 7] * J[i, 7];    
            //}


            //for (int i = 0; i <N; i++)
            //{
            ////    result[0, 0] += J[i, 0] * J[i, 0];
            ////}

            //for (int i = 0; i < N; i += 32)
            //{
            //    result[0, 0] += J[i, 0] * J[i, 0];
            //    result[0, 0] += J[i + 1, 0] * J[i + 1, 0];
            //    result[0, 0] += J[i + 2, 0] * J[i + 2, 0];
            //    result[0, 0] += J[i + 3, 0] * J[i + 3, 0];
            //    result[0, 0] += J[i + 4, 0] * J[i + 4, 0];
            //    result[0, 0] += J[i + 5, 0] * J[i + 5, 0];
            //    result[0, 0] += J[i + 6, 0] * J[i + 6, 0];
            //    result[0, 0] += J[i + 7, 0] * J[i + 7, 0];
            //    result[0, 0] += J[i + 8, 0] * J[i + 8, 0];
            //    result[0, 0] += J[i + 9, 0] * J[i + 9, 0];
            //    result[0, 0] += J[i + 10, 0] * J[i + 10, 0];
            //    result[0, 0] += J[i + 11, 0] * J[i + 11, 0];
            //    result[0, 0] += J[i + 12, 0] * J[i + 12, 0];
            //    result[0, 0] += J[i + 13, 0] * J[i + 13, 0];
            //    result[0, 0] += J[i + 14, 0] * J[i + 14, 0];
            //    result[0, 0] += J[i + 15, 0] * J[i + 15, 0];
            //    result[0, 0] += J[i + 16, 0] * J[i + 16, 0];
            //    result[0, 0] += J[i + 17, 0] * J[i + 17, 0];
            //    result[0, 0] += J[i + 18, 0] * J[i + 18, 0];
            //    result[0, 0] += J[i + 19, 0] * J[i + 19, 0];
            //    result[0, 0] += J[i + 20, 0] * J[i + 20, 0];
            //    result[0, 0] += J[i + 21, 0] * J[i + 21, 0];
            //    result[0, 0] += J[i + 22, 0] * J[i + 22, 0];
            //    result[0, 0] += J[i + 23, 0] * J[i + 23, 0];
            //    result[0, 0] += J[i + 24, 0] * J[i + 24, 0];
            //    result[0, 0] += J[i + 25, 0] * J[i + 25, 0];
            //    result[0, 0] += J[i + 26, 0] * J[i + 26, 0];
            //    result[0, 0] += J[i + 27, 0] * J[i + 27, 0];
            //    result[0, 0] += J[i + 28, 0] * J[i + 28, 0];
            //    result[0, 0] += J[i + 29, 0] * J[i + 29, 0];
            //    result[0, 0] += J[i + 30, 0] * J[i + 30, 0];
            //    result[0, 0] += J[i + 31, 0] * J[i + 31, 0];
            //}

            //int threadIdx = 0;
            //for (int i = threadIdx; i < N; i += 32)
            //{
            //    result[0, 0] += J[i, 0] * J[i, 0];
            //    result[0, 1] += J[i, 0] * J[i, 1];
            //    result[0, 2] += J[i, 0] * J[i, 2];
            //    result[0, 3] += J[i, 0] * J[i, 3];
            //    result[0, 4] += J[i, 0] * J[i, 4];
            //    result[0, 5] += J[i, 0] * J[i, 5];
            //    result[0, 6] += J[i, 0] * J[i, 6];
            //    result[0, 7] += J[i, 0] * J[i, 7];

            //    result[1, 1] += J[i, 1] * J[i, 1];
            //    result[1, 2] += J[i, 1] * J[i, 2];
            //    result[1, 3] += J[i, 1] * J[i, 3];
            //    result[1, 4] += J[i, 1] * J[i, 4];
            //    result[1, 5] += J[i, 1] * J[i, 5];
            //    result[1, 6] += J[i, 1] * J[i, 6];
            //    result[1, 7] += J[i, 1] * J[i, 7];

            //    result[2, 2] += J[i, 2] * J[i, 2];
            //    result[2, 3] += J[i, 2] * J[i, 3];
            //    result[2, 4] += J[i, 2] * J[i, 4];
            //    result[2, 5] += J[i, 2] * J[i, 5];
            //    result[2, 6] += J[i, 2] * J[i, 6];
            //    result[2, 7] += J[i, 2] * J[i, 7];

            //    result[3, 3] += J[i, 3] * J[i, 3];
            //    result[3, 4] += J[i, 3] * J[i, 4];
            //    result[3, 5] += J[i, 3] * J[i, 5];
            //    result[3, 6] += J[i, 3] * J[i, 6];
            //    result[3, 7] += J[i, 3] * J[i, 7];

            //    result[4, 4] += J[i, 4] * J[i, 4];
            //    result[4, 5] += J[i, 4] * J[i, 5];
            //    result[4, 6] += J[i, 4] * J[i, 6];
            //    result[4, 7] += J[i, 4] * J[i, 7];

            //    result[5, 5] += J[i, 5] * J[i, 5];
            //    result[5, 6] += J[i, 5] * J[i, 6];
            //    result[5, 7] += J[i, 5] * J[i, 7];

            //    result[6, 6] += J[i, 6] * J[i, 6];
            //    result[6, 7] += J[i, 6] * J[i, 7];

            //    result[7, 7] += J[i, 7] * J[i, 7];
            //}


            //for (int i = threadIdx; i < N; i += 32)
            //{

                //result[0, 0] += J[i*8] * J[i*8 + 0];
                //result[0, 1] += J[i*8] * J[i*8 + 1];
                //result[0, 2] += J[i*8] * J[i*8 + 2];
                //result[0, 3] += J[i*8] * J[i*8 + 3];
                //result[0, 4] += J[i*8] * J[i*8 + 4];
                //result[0, 5] += J[i*8] * J[i*8 + 5];
                //result[0, 6] += J[i*8] * J[i*8 + 6];
                //result[0, 7] += J[i*8] * J[i*8 + 7];


                //result[1, 1] += J[i*8 + 1] * J[i*8 + 1];
                //result[1, 2] += J[i*8 + 1] * J[i*8 + 2];
                //result[1, 3] += J[i*8 + 1] * J[i*8 + 3];
                //result[1, 4] += J[i*8 + 1] * J[i*8 + 4];
                //result[1, 5] += J[i*8 + 1] * J[i*8 + 5];
                //result[1, 6] += J[i*8 + 1] * J[i*8 + 6];
                //result[1, 7] += J[i*8 + 1] * J[i*8 + 7];

                //result[2, 2] += J[i*8 + 2] * J[i*8 + 2];
                //result[2, 3] += J[i*8 + 2] * J[i*8 + 3];
                //result[2, 4] += J[i*8 + 2] * J[i*8 + 4];
                //result[2, 5] += J[i*8 + 2] * J[i*8 + 5];
                //result[2, 6] += J[i*8 + 2] * J[i*8 + 6];
                //result[2, 7] += J[i*8 + 2] * J[i*8 + 7];

                //result[3, 3] += J[i*8 + 3] * J[i*8 + 3];
                //result[3, 4] += J[i*8 + 3] * J[i*8 + 4];
                //result[3, 5] += J[i*8 + 3] * J[i*8 + 5];
                //result[3, 6] += J[i*8 + 3] * J[i*8 + 6];
                //result[3, 7] += J[i*8 + 3] * J[i*8 + 7];

                //result[4, 4] += J[i*8 + 4] * J[i*8 + 4];
                //result[4, 5] += J[i*8 + 4] * J[i*8 + 5];
                //result[4, 6] += J[i*8 + 4] * J[i*8 + 6];
                //result[4, 7] += J[i*8 + 4] * J[i*8 + 7];

                //result[5, 5] += J[i*8 + 5] * J[i*8 + 5];
                //result[5, 6] += J[i*8 + 5] * J[i*8 + 6];
                //result[5, 7] += J[i*8 + 5] * J[i*8 + 7];

                //result[6, 6] += J[i*8 + 6] * J[i*8 + 6];
                //result[6, 7] += J[i*8 + 6] * J[i*8 + 7];

                //result[7, 7] += J[i*8 + 7] * J[i*8 + 7];
            //}

            double t=0;
            for (int i = 0; i < 125; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    t += J[i, j]* J[i, j];
                }
            }

            for (int i = 0; i < 125; i ++)
            {

                result[0, 0] += J[i, 0] * J[i, 0];
                //for (int j = 0; j < 8; j++)
                //{
                //    result[0, j] += J[i, 0] * J[i, j];
                    //if (j > 0)
                    //    result[1, j] += J[i, 1] * J[i, j];
                    //if (j > 1)
                    //    result[2, j] += J[i, 2] * J[i, j];
                    //if (j > 2)
                    //    result[3, j] += J[i, 3] * J[i, j];
                    //if (j > 3)
                    //    result[4, j] += J[i, 4] * J[i, j];
                    //if (j > 4)
                    //    result[5, j] += J[i, 5] * J[i, j];
                    //if (j > 5)
                    //    result[6, j] += J[i, 6] * J[i, j];
                    //if (j > 6)
                    //    result[7, j] += J[i, 7] * J[i, j];
                //}
            }






        }
    }
}
