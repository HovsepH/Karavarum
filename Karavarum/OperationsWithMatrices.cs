using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Karavarum
{
    public static class OperationsWithMatrices
    {
        public static List<List<int>> Sum(List<List<int>> first, List<List<int>> second)
        {
            int n = first.Count;
            List<List<int>> result = new List<List<int>>();

           for (int i = 0; i < n; i++)
            {
                List<int> newRow = new List<int>();

                for (int j = 0; j < n; j++)
                {
                    int sum = first[i][j] + second[i][j];
                    newRow.Add(sum);
                }

                result.Add(newRow);
            }

            return result;
        }
        public static List<List<int>> Multiplay(List<List<int>> first, List<List<int>> second)
        {
            if (first[0].Count != second.Count)
            {
                throw new InvalidOperationException();
            }

            int count = first[0].Count;

            foreach (var item in first)
            {
                if (item.Equals(first[0]))
                    continue;
                if (item.Count != count)
                {
                    throw new InvalidOperationException();
                }
            }

            count = second[0].Count;

            foreach (var item in second)
            {
                if (item.Equals(second[0]))
                    continue;
                if (item.Count != count)
                {
                    throw new InvalidOperationException();
                }
            }

            int sum = 0;

            List<List<int>> result = new List<List<int>>(first.Count);

            for (int i = 0; i < result.Capacity; i++)
            {
                result.Add(new List<int>(second[0].Count));
            }

            for (int i = 0; i < first.Count; i++)
            {

                for (int j = 0; j < second[0].Count; j++)
                {
                    sum = 0;

                    for (int q = 0; q < first[0].Count; q++)
                    {
                        sum += first[i][q] * second[q][j];
                    }

                    result[i].Add(sum);
                }
            }

            return result;
        }

        public static int TraceOfSquare(List<List<int>> matrice)
        {
            int trace = 0;

            for (int i = 0; i < matrice.Count; i++)
            {
                trace += matrice[i][i];
            }

            return trace;
        }

        public static double CalculateDeterminant(double[,] matrix, int n)
        {
            if (n == 1)
            {
                return matrix[0, 0];
            }

            if (n == 2)
            {
                return matrix[0, 0] * matrix[1, 1] - matrix[0, 1] * matrix[1, 0];
            }

            double det = 0;

            for (int i = 0; i < n; i++)
            {
                det += matrix[0, i] * Cofactor(matrix, n, 0, i);
            }

            return det;
        }

        static double Cofactor(double[,] matrix, int n, int row, int col)
        {
            double[,] minorMatrix = new double[n - 1, n - 1];
            int minorRow = 0, minorCol = 0;

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (i != row && j != col)
                    {
                        minorMatrix[minorRow, minorCol++] = matrix[i, j];

                        if (minorCol == n - 1)
                        {
                            minorCol = 0;
                            minorRow++;
                        }
                    }
                }
            }

            return Math.Pow(-1, row + col) * matrix[row, col] * CalculateDeterminant(minorMatrix, n - 1);
        }

        public static void PrintMatrice(List<List<int>> A)
        {
            foreach (var vector in A)
            {
                foreach (var item2 in vector)
                {
                    if (item2 !=0 )
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                    }
                    Console.Write(item2 + " ");
                    Console.ForegroundColor = ConsoleColor.Gray;

                }
                Console.WriteLine();
            }
         
        }

        public static int FindGreatestNumber(List<List<int>> listOfLists)
        {
           int maxNumber = 0;

            foreach (var innerList in listOfLists)
            {
                int innerMax = innerList.Max();

                if (innerMax > maxNumber)
                {
                    maxNumber = innerMax;
                }
            }

            return maxNumber;
        }


        public static int[,] To2DArray(this List<List<int>> listOfLists)
        {
            int rows = listOfLists.Count;
            int cols = listOfLists[0].Count;

            int[,] array2D = new int[rows, cols];

            for (int i = 0; i < rows; i++)
            {
                if (listOfLists[i].Count != cols)
                {
                    throw new ArgumentException("Inner lists must have the same length.");
                }

                for (int j = 0; j < cols; j++)
                {
                    array2D[i, j] = listOfLists[i][j];
                }
            }

            return array2D;
        }

        public static List<List<int>> GetAMatrice(int[,] arr)
        {
            int greatestNumber = 0;

            for (int i = 0; i < arr.GetLength(0); i++)
            {
                for (int j = 0; j < 2; j++)
                {
                    if (arr[i, j] > greatestNumber)
                    {
                        greatestNumber = arr[i, j];
                    }
                }
            }
            List<List<int>> A = new List<List<int>>(greatestNumber);

            for (int i = 0; i < greatestNumber; i++)
            {
                A.Add(new List<int>(greatestNumber));
            }

            for (int i = 0; i < greatestNumber; i++)
            {
                for (int j = 0; j < greatestNumber; j++)
                {
                    A[i].Add(0);
                }
            }

            for (int i = 0; i < arr.GetLength(0); i++)
            {
                if (arr[i, 1] != 0)
                {
                    A[arr[i, 0] - 1][arr[i, 1] - 1] = 1;
                }
            }

            return A;
        }

        public static List<int> GetT1(int[,] C)
        {

            List<int> T1 = new List<int>();
            bool f = false;
            for (int i = 0; i < C.GetLength(0); i++)
            {
                f = false;
                for (int j = 0; j < C.GetLength(0); j++)
                {
                    if (C[i, 0] == C[j, 1])
                    {
                        f = true;
                    }
                }
                if (f == false)
                {
                    T1.Add(C[i, 0]);
                }
            }
            return T1.Distinct().ToList();
        }

        public static List<int> GetT2(int[,] C)
        {
            List<int> T2 = new List<int>();

            for (int i = 0; i < C.GetLength(0); i++)
            {
                if (C[i, 1] == 0)
                {
                    continue;
                }
                for (int j = 0; j < C.GetLength(0); j++)
                {
                    if (C[i, 1] == C[j, 0] && C[j, 1] != 0)
                    {
                        T2.Add(C[i, 1]);
                    }
                }
            }
                
            return T2.OrderBy(x => x).Distinct().ToList();
        }

        public static List<int> GetT3(int[,] C)
        {
            List<int> T3 = new List<int>();

            for (int i = 0; i < C.GetLength(0); i++)
            {
                if (C[i,1]==0)
                {
                    T3.Add(C[i, 0]);
                }
            }

            return T3.OrderBy(x => x).Distinct().ToList();
        }

        public static int GetT4(List<List<int>> listOflists)
        {
            int T4 = 0;
            bool isAllColumnIs_0 = true;
            for (int i = 0; i < listOflists.Count; i++)
            {
                for (int j = 0; j < listOflists.Count; j++)
                {
                    if (listOflists[j][i]!=0)
                    {
                        isAllColumnIs_0=false;
                        break;
                    }
                }
                if (isAllColumnIs_0)
                {
                    T4++;
                }
            }
            return T4;
        }

        public static int GetT5(int[,] C)
        {
            List<int> T2 = GetT2(C);
            int T5 = 0;
            for (int i = 0; i < T2.Count; i++)
            {
                for (int j = 0; j < C.GetLength(0); j++)
                {
                    if (T2[i] == C[j, 0])
                    {
                        for (int k = 0; k < T2.Count; k++)
                        {
                            if (C[j, 1] == T2[k])
                            {
                                T5++;
                            }
                        }
                    }
                }

            }

            return T5;
        }

        public static int GetT6(int[,] C)
        {
            List<int> T3 = GetT3(C);
            int T6 = 0;
            for (int i = 0; i < T3.Count; i++)
            {
                for (int j = 0; j < C.GetLength(0); j++)
                {
                    if (T3[i] == C[j, 0])
                    {
                        for (int k = 0; k < T3.Count; k++)
                        {
                            if (C[j, 1] == T3[k])
                            {
                                T6++;
                            }
                        }
                    }
                }

            }

            return T6;
        }

        public static int GetR(int[,] C)
        {
            int R = 0;
            for (int i = 0; i < C.GetLength(0); i++)
            {
                if (C[i,1]==0)
                {
                    continue;
                }
                R++;
            }
            return R;
        }

        public static int GetK(List<List<int>> A)
        {
            return A.Count;
        }

        public static double GetK_m(List<List<int>> A, int[,]arr)
        {
            return GetT2(arr).Count / (double)GetK(A);
        }
        public static double GetK_n_k(int[,] C)
        {
            return GetT5(C) / (double)GetR(C);
        }


        public static double GetK_m_o(List<List<int>> listOfLists, int t7)
        {
            return t7 / (double)GetT4(listOfLists);
        }

    }
}


