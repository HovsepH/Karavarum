using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Karavarum
{
    public static class AnalysisOfGraphs
    {
        public static void GetAllInfo(int[,] arr)
        {

            List<List<int>> A = OperationsWithMatrices.GetAMatrice(arr);
            List<double> K_m_o_list = new List<double>();
            if (OperationsWithMatrices.TraceOfSquare(A) != 0)
            {
                throw new InvalidDataException();
            }
            Console.WriteLine("A............. ");
            OperationsWithMatrices.PrintMatrice(A);

            List<int> T1 = OperationsWithMatrices.GetT1(arr);

            Console.Write("\nT1............ ");
            foreach (var item in T1)
            {
                Console.Write(item + " ");
            }

            List<int> T2 = OperationsWithMatrices.GetT2(arr);

            Console.Write("\nT2............ ");
            foreach (var item in T2)
            {
                Console.Write(item + " ");
            }

            List<int> T3 = OperationsWithMatrices.GetT3(arr);

            Console.Write("\nT3............ ");
            foreach (var item in T3)
            {
                Console.Write(item + " ");
            }

            Console.WriteLine($"\nT4............ {OperationsWithMatrices.GetT4(A)}");
            int N = 1;
            int T7 = OperationsWithMatrices.GetT4(A) - N;
            Console.WriteLine($"T7............ {T7}");
            K_m_o_list.Add(OperationsWithMatrices.GetK_m_o(A, T7));
            Console.WriteLine($"K(m,o)........ {K_m_o_list[N - 1]}");
            List<List<int>> ApowN = A.ToList();
            List<List<int>> HasaneliutyanMatrice = A.ToList();

            while (OperationsWithMatrices.FindGreatestNumber(ApowN) != 0)
            {
                if (OperationsWithMatrices.TraceOfSquare(ApowN) != 0)
                    throw new InvalidDataException();
                N++;
                Console.WriteLine($"\nA pow.        {N}");
                Console.WriteLine($"T4............{OperationsWithMatrices.GetT4(ApowN)}");
                T7 = OperationsWithMatrices.GetT4(ApowN) - N;
                Console.WriteLine($"T7............{T7}");
                K_m_o_list.Add(OperationsWithMatrices.GetK_m_o(A, T7));
                Console.WriteLine($"K(m,o)........ {K_m_o_list[N - 1]}");
                ApowN = OperationsWithMatrices.Multiplay(ApowN, A);
                OperationsWithMatrices.PrintMatrice(ApowN);
                HasaneliutyanMatrice = OperationsWithMatrices.Sum(ApowN, HasaneliutyanMatrice);
            }

            Console.WriteLine($"\nHasaneliutyanMatrice......");
            OperationsWithMatrices.PrintMatrice(HasaneliutyanMatrice);
            Console.WriteLine($"\nT5...........{OperationsWithMatrices.GetT5(arr)}");
            Console.WriteLine($"N - 1 = {N - 1}");
            Console.WriteLine($"R............{OperationsWithMatrices.GetR(arr)}");
            Console.WriteLine($"K(n,k).......{OperationsWithMatrices.GetK_n_k(arr)}");
            Console.WriteLine($"T6...........{OperationsWithMatrices.GetT6(arr)}");
            Console.WriteLine($"K............{OperationsWithMatrices.GetK(A)}");

            double k_m = OperationsWithMatrices.GetK_m(A, arr);
            Console.WriteLine($"K(m).........{k_m}");

            double k_m_o_avg = K_m_o_list.Average();
            Console.WriteLine($"K(m,o,mij).........{k_m_o_avg}");
            if (k_m - k_m_o_avg < 0.01)
            {
                Console.WriteLine("Racional e kazmakerpvac!!!");
            }
            else
            {
                Console.WriteLine("Racional che kazmakerpvac!!!");
            }







        }



    }
}
