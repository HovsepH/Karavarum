using Karavarum;

List<List<int>> FirstMatrix = new List<List<int>> {
            new List<int> { 1, 2, 3},
            new List<int> { 5, 6, 4}
};

List<List<int>> SecondMatrix = new List<List<int>> {
            new List<int> { 1, 2, 3, 4 },
            new List<int> { 1, 2, 3, 4 },
            new List<int> { 5, 6, 7, 8 }
};


var result = OperationsWithMatrices.Multiplay(FirstMatrix, SecondMatrix);

foreach (var vector in result)
{
    foreach (var item2 in vector)
    {
        Console.Write(item2 + " ");
    }
    Console.WriteLine();
}

List<List<int>> examople = new List<List<int>> {
         new List<int> { 1, 2, 3, 4},
         new List<int> { 1, 2, 3, 5},
         new List<int> { 5, 6, 4, 8},
         new List<int> { 5, 6, 4, 3}
};

var r = OperationsWithMatrices.TraceOfSquare(examople);

Console.WriteLine("\n" + r);

double[,] matrix = {
            { 1, 2, 3 },
            { 4, 50, 6 },
            { 7, 8, 922 }
        };

int n = matrix.GetLength(0);

double determinant = OperationsWithMatrices.CalculateDeterminant(matrix, n);

Console.WriteLine($"Determinant: {determinant}");