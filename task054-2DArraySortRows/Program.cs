/*
Задача 54: Задайте двумерный массив. Напишите программу, 
которая упорядочит по убыванию элементы каждой строки двумерного массива.
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

void SortSingleRow(int[,] arrayForSort, int currentRow)
{
    for (int i = 0; i < arrayForSort.GetLength(1) - 1; i++)
    {
        int maxIndex = i;
        for (int j = i + 1; j < arrayForSort.GetLength(1); j++)
        {
            if (arrayForSort[currentRow, j] > arrayForSort[currentRow, maxIndex])
            {
                maxIndex = j;
            }
        }
        int temp = arrayForSort[currentRow, i];
        arrayForSort[currentRow, i] = arrayForSort[currentRow, maxIndex];
        arrayForSort[currentRow, maxIndex] = temp;
    }
}

void SortRowsIn2DArray(int[,] arrayForSort)
{
    for (int i = 0; i < arrayForSort.GetLength(0); i++)
    {
        SortSingleRow(arrayForSort, i);
    }
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

int arrayRow = 5;
int arrayColumn = 5;
int[,] array = Get2DArrayRandomNumbers(arrayRow, arrayColumn);

Print2DArray(array, "Заданный массив");
SortRowsIn2DArray(array);
Print2DArray(array, "Отсортированный массив");