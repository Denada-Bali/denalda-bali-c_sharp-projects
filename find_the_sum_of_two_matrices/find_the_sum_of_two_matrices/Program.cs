using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/*
Lab Exercises-4
Exercise 4
*/
namespace find_the_sum_of_two_matrices
{
    class Program
    {
        static void Main(string[] args)
        {
            
            int[,] AArray = new int[50, 50];
            int[,] BArray = new int[50, 50];
            int[,] CArray = new int[50, 50];

            Console.Write("Input the size of the matrix : ");
           int  n = int.Parse(Console.ReadLine());

            Console.Write("Input elements in the first matrix :\n");
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    Console.Write("element - [{0},{1}] : ", i, j);  
                    AArray[i, j] = int.Parse(Console.ReadLine());
                }
            }

            Console.Write("Input elements in the second matrix :\n");
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    Console.Write("element - [{0},{1}] : ", i, j);
                    BArray[i, j] = int.Parse(Console.ReadLine());
                }
            }
            Console.Write("\nThe First matrix is :\n");   
            for (int i = 0; i < n; i++)
            {
                Console.Write("\n");
                for (int j = 0; j < n; j++)
                    Console.Write("{0}\t", AArray[i, j]);
            }

            Console.Write("\nThe Second matrix is :\n");
            for (int i = 0; i < n; i++)
            {
                Console.Write("\n");
                for (int j = 0; j < n; j++)
                    Console.Write("{0}\t", BArray[i, j]);
            }                                   

            for (int i = 0; i < n; i++)
                for (int j = 0; j < n; j++)
                    CArray[i, j] = AArray[i, j] + BArray[i, j];

            Console.Write("\nThe Addition of two matrix is : \n");
            for (int i = 0; i < n; i++)
            {
                Console.Write("\n");
                for (int j = 0; j < n; j++)
                    Console.Write("{0}\t", CArray[i, j]);
            }
            Console.ReadKey();
        }
            
    }
}
