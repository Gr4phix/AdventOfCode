using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day3
{
    class Program
    {
        static void Main(string[] args)
        {
            Stream inputStream = Console.OpenStandardInput(10000);
            Console.SetIn(new StreamReader(inputStream, Console.InputEncoding, false, 10000));
            char[] input = Console.ReadLine().ToCharArray();

            bool[,] matrix = new bool[1000, 1000];
            int x = 500;
            int y = 500;
            matrix[x, y] = true;
            int count = 0;

            for (int i = 0; i < input.Length; i++)
            {
                if (input[i] == '^') y -= 1;
                else if (input[i] == '>') x += 1;
                else if (input[i] == 'v') y += 1;
                else if (input[i] == '<') x -= 1;

                matrix[x, y] = true;
            }

            for (int i = 0; i < 1000; i++)
            {
                for (int l = 0; l < 1000; l++)
                {
                    if (matrix[i, l] == true) count++;
                }
            }
            Console.Write("{0} Kids became more than one present. \n\nNew input: ", count);

            char[] input2 = Console.ReadLine().ToCharArray();

            bool[,] matrix2 = new bool[1000, 1000];
            int x21 = 500;
            int y21 = 500;
            int x22 = 500;
            int y22 = 500;
            matrix2[x, y] = true;
            int count2 = 0;
            bool robo = false;

            for (int i = 0; i < input2.Length; i++)
            {
                if (robo)
                {
                    if (input2[i] == '^') y22 -= 1;
                    else if (input2[i] == '>') x22 += 1;
                    else if (input2[i] == 'v') y22 += 1;
                    else if (input2[i] == '<') x22 -= 1;

                    matrix2[x22, y22] = true;
                    robo = false;
                }
                else
                {
                    if (input2[i] == '^') y21 -= 1;
                    else if (input2[i] == '>') x21 += 1;
                    else if (input2[i] == 'v') y21 += 1;
                    else if (input2[i] == '<') x21 -= 1;

                    matrix2[x21, y21] = true;
                    robo = true;
                }             
            }

            for (int i = 0; i < 1000; i++)
            {
                for (int l = 0; l < 1000; l++)
                {
                    if (matrix2[i, l] == true) count2++;
                }
            }
            Console.Write("{0} Kids became more than one present. ", count2);

            Console.ReadKey();
        }
    }
}
