/*
Задача 58: Задайте две матрицы. Напишите программу, 
которая будет находить произведение двух матриц.
*/

int[,] Get2DArrayRandomNumbers(int rowNumber, int colNumber)
{
    int[,] result = new int[rowNumber, colNumber];
    for (int i = 0; i < rowNumber; i++)
    {
        for (int j = 0; j < colNumber; j++)
        {
            result[i, j] = new Random().Next(1, 10);
        }
    }
    return result;
}

int[,] ProductMatrices(int[,] firstMatrix, int[,] secondMatrix)
{
    int[,] result = new int[firstMatrix.GetLength(0), secondMatrix.GetLength(1)];
    for (int i = 0; i < result.GetLength(0); i++)
    {
        for (int j = 0; j < result.GetLength(1); j++)
        {
            for (int k = 0; k < firstMatrix.GetLength(1); k++)
            {
                result[i,j] = result[i,j] + firstMatrix[i,k]*secondMatrix[k,j];
            }
        }
    }
    return result;
}

void Print2DArray(int[,] arrayToPrint, string name = "")
{
    if (!string.IsNullOrEmpty(name))
    {
        Console.WriteLine($"\n--{name}--");
    }
    Console.Write($"[X]\t");
    for (int i = 0; i < arrayToPrint.GetLength(1); i++)
    {
        Console.Write($"[{i}]\t");
    }
    Console.WriteLine();
    for (int i = 0; i < arrayToPrint.GetLength(0); i++)
    {
        Console.Write($"[{i}]\t");
        for (int j = 0; j < arrayToPrint.GetLength(1); j++)
        {
            Console.Write($"{arrayToPrint[i, j]}\t");
        }
        Console.WriteLine();
    }
}

int arrayRow = new Random().Next(2,6);
int arrayColumn = new Random().Next(2,6);
int arrayRowOrColumn = new Random().Next(2,6);

int[,] firstMatrix = Get2DArrayRandomNumbers(arrayRow,arrayRowOrColumn);
int[,] secondMatrix = Get2DArrayRandomNumbers(arrayRowOrColumn,arrayColumn);
int[,] resultMatrix = ProductMatrices(firstMatrix,secondMatrix);

Print2DArray(firstMatrix, "Первая матрица");
Print2DArray(secondMatrix, "Вторая матрица");
Print2DArray(resultMatrix, "Произведение первой и второй матрицы");