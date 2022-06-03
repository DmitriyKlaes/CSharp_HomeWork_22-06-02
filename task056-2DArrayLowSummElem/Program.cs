/*
Задача 56: Задайте прямоугольный двумерный массив. 
Напишите программу, которая будет находить строку с наименьшей суммой элементов.
*/

int[,] GetArrayRandomNumbers(int rowNumber, int colNumber)
{
    int[,] result = new int[rowNumber, colNumber];
    for (int i = 0; i < rowNumber; i++)
    {
        for (int j = 0; j < colNumber; j++)
        {
            result[i, j] = new Random().Next(1, 4);
        }
    }
    return result;
}

int SummSingleRow(int[,] arrayForSort, int currentRow)
{
    int result = 0;
    for (int i = 0; i < arrayForSort.GetLength(1); i++)
    {
        result = result + arrayForSort[currentRow, i];
    }
    //System.Console.Write($" {result}");
    return result;
}

void FindLowerSummRowOfArray(int[,] arrayForFind)
{
    //int[] array = new int[arrayForFind.GetLength(0)];
    int tempSumm = 0;
    int lowerRow = 0;
    int lowerSumm = SummSingleRow(arrayForFind, lowerRow);
    System.Console.WriteLine(lowerSumm);
    int column = 1;
    for (int i = 1; i < arrayForFind.GetLength(0); i++)
    {
        tempSumm = SummSingleRow(arrayForFind, i);
        System.Console.WriteLine(tempSumm);
        if (tempSumm <= lowerSumm)
        {
            if (tempSumm == lowerSumm)
            {
                column = column + 1;
            }
            lowerRow = i;
            lowerSumm = tempSumm;
        }

        //lowerSumm = tempSumm;

        //column = i;
    }
    //string arr = string.Join(" ", array);
    if (column > 1)
    {
        System.Console.WriteLine($"таких строки {column}");
    }
    //System.Console.WriteLine(lowerSumm);
    System.Console.WriteLine($"{lowerRow + 1} строка с индексом {lowerRow}");
}

void Print2DArray(int[,] arrayToPrint)
{
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

int[,] test = GetArrayRandomNumbers(3, 3);
Print2DArray(test);
FindLowerSummRowOfArray(test);
