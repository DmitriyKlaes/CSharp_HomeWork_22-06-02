/*
Задача 56: Задайте прямоугольный двумерный массив. 
Напишите программу, которая будет находить строку с наименьшей суммой элементов.
*/

// Получился объемный метод для печати массива. 
// Это из-за того, что строк с наименьшей суммой может быть не одна.
// Я попытался это учесь и у меня получилось.
// Может быть всё можно было сделать проще... всегда есть куда расти =))

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

int SummSingleRow(int[,] arrayForSummRow, int currentRow)
{
    int result = 0;
    for (int i = 0; i < arrayForSummRow.GetLength(1); i++)
    {
        result = result + arrayForSummRow[currentRow, i];
    }
    return result;
}

int FindLowerSummRowOfArray(int[,] arrayForFind)
{
    int tempSumm = 0;
    int lowerRow = 0;
    int lowerSumm = SummSingleRow(arrayForFind, lowerRow);
    for (int i = 1; i < arrayForFind.GetLength(0); i++)
    {
        tempSumm = SummSingleRow(arrayForFind, i);
        if (tempSumm < lowerSumm)
        {
            lowerSumm = tempSumm;
        }
    }
    return lowerSumm;
}

// Метод печатает массив, а так же результаты поиска, обозначенные в задаче.
void Print2DArrayAndRowResult(int[,] arrayToPrint, int lowerSumm)
{
    int tempSumm;
    int countRow = 0;
    string indexLower = string.Empty;
    Console.Write($"\n[X]\t");
    for (int i = 0; i < arrayToPrint.GetLength(1); i++)
    {
        Console.Write($"[{i}]\t");
    }
    Console.WriteLine();
    for (int i = 0; i < arrayToPrint.GetLength(0); i++)
    {
        Console.Write($"[{i}]\t");
        tempSumm = SummSingleRow(arrayToPrint, i);
        if (lowerSumm == tempSumm)
        {
            indexLower = indexLower + "[" + i + "] ";
            countRow++;
            Console.ForegroundColor = ConsoleColor.DarkCyan;
        }
        for (int j = 0; j < arrayToPrint.GetLength(1); j++)
        {
            Console.Write($"{arrayToPrint[i, j]}\t");
        }
        Console.ResetColor();
        Console.WriteLine();
    }
    if (countRow > 1)
    {
        Console.WriteLine($"\nВсего {countRow} строк(и) с наименьшей суммой" +
                                 $". Их индексы: {indexLower}");
    }
    else
    {
        Console.WriteLine($"\nИндекс строки с наименьшей суммой: {indexLower}");
    }
}

int arrayRow = 4;
int arrayColumn = 3;
int[,] array = Get2DArrayRandomNumbers(arrayRow, arrayColumn);

int lowerSumm = FindLowerSummRowOfArray(array);
Print2DArrayAndRowResult(array, lowerSumm);
Console.WriteLine($"Наименьшая сумма элементов строки = {lowerSumm}");