using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeworkTest
{
    class QuickSort
     {
         public static void sorting(int[] mass, int first, int last)
         {
            int i = first;
            int j = last;
            int middle = mass[(i + j) / 2];
            int buffer;
            while (i <= j)
             {
                 while (mass[i] < middle && i <= last)
                 {
                 ++i;
                 }
                 while (mass[j] > middle && j >= first) 
                 {
                 --j;
                 }
                 if (i <= j)
                 {
                     buffer = mass[i];
                     mass[i] = mass[j];
                     mass[j] = buffer;
                     ++i;
                     --j;
                 }
             }
            if (j > first)
            {
                sorting(mass, first, j);
            }
            if (i < last)
            {
                sorting(mass, i, last);
            }
         }
     }
     class Program
     {
         static void Main(string[] args)
         {
             Console.WriteLine("Enter size of massive: ");
             int massSize = Convert.ToInt16(Console.ReadLine());
             int[] mass = new int[massSize];
             Random randNum = new Random();
             for (int i = 0; i < massSize; ++i)
             {
                 mass[i] = randNum.Next(1, 20);
             }
             System.Console.WriteLine("\n\n The array of numbers before sorting:");
             foreach (double i in mass)
             {
                 System.Console.Write(i + " ");
             }
             QuickSort.sorting(mass, 0, --massSize);
             System.Console.WriteLine("\n\n The array of numbers after quick sorting:");
             foreach (int i in mass)
             {
                 System.Console.Write(i + " ");
             }
             System.Console.WriteLine("\n\n End of sorting, good luck Boss!");
             System.Console.ReadLine();
         }
     } 
}

