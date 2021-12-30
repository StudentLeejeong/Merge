using System;
using System.IO;
using System.Threading;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MergeRange
{
    class Program
    {

        static void Main(string[] args)
        {
            int[] testArray = new int[1000];
            for (int i = 0; i < testArray.Length; i++)
            {
                testArray[i] = testArray.Length - i;
            }
            //test data generator 
            //999 998 .... 0


            DateTime startTime = DateTime.Now;

            Merge_Sort(testArray, 0, testArray.Length - 1);

            DateTime endTime = DateTime.Now;

            TimeSpan elapsed = endTime - startTime;

            Console.WriteLine("Elapsed time : {0}", elapsed);

            Console.Write("\n");

        }

        static void Merge_Sort(int[] A, int p, int r)
        {

            if (p < r)
            {
                int q = (p + r) / 2;

                Merge_Sort(A, p, q);
                Merge_Sort(A, q + 1, r);
                Merge(A, p, q, r);

            }


        }

        static void Merge(int[] A, int p, int q, int r)
        {
            int n1 = q - p + 1;
            int n2 = r - q;
            int[] L = new int[n1];
            int[] R = new int[n2];
            int i;
            int j;




            for (i = 0; i < n1; i++)
            {
                L[i] = A[p + i];
            }
            for (j = 0; j < n2; j++)
            {
                R[j] = A[q + j + 1];
            }



            i = 0;
            j = 0;
            for (int k = p; k < r + 1; k++)
            {
                if (i == n1)
                {
                    A[k] = R[j];
                    j = j + 1;
                }
                else if (j == n2)
                {
                    A[k] = L[i];
                    i = i + 1;
                }
                else if (L[i] <= R[j])
                {
                    A[k] = L[i];
                    i = i + 1;
                }
                else
                {
                    A[k] = R[j];
                    j = j + 1;
                }
            }
        }


    }
}
