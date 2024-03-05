using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Karavarum
{
    public class OperationsWithMatrices
    {
        public static List<List<int>> Multiplay(List<List<int>> first, List<List<int>> second)
        { 
            if (first[0].Count != second.Count)
            {
                throw new InvalidOperationException();
                return null;
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

            List < List<int>> result= new List<List<int>>(first.Count);

            for (int i=0; i<result.Capacity; i++)
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

    }
}


