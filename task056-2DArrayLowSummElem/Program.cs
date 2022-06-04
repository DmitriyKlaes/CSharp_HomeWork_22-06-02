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
            result[i, j] = new Random().Next(1, 5);
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
    return result;
}

int FindLowerSummRowOfArray(int[,] arrayForFind)
{
    int tempSumm = 0;
    int countRows = 1;
    int lowerRow = 0;
    int lowerSumm = SummSingleRow(arrayForFind, lowerRow);
    System.Console.WriteLine(lowerSumm);
    for (int i = 1; i < arrayForFind.GetLength(0); i++)
    {
        tempSumm = SummSingleRow(arrayForFind, i);
        System.Console.WriteLine(tempSumm);
        if (tempSumm <= lowerSumm)
        {
            if (tempSumm == lowerSumm)
            {
                countRows = countRows + 1;
            }
            else
            {
                countRows = 1;
            }
            lowerRow = i;
            lowerSumm = tempSumm;
        }
    }
    if (countRows > 1)
    {
        System.Console.WriteLine($"таких строки {countRows}");
    }
    System.Console.WriteLine($"{lowerRow + 1} строка с индексом {lowerRow} и суммой {lowerSumm}");
    return lowerSumm;
}

string PrintResultOfFind(int[,] arrayForRusult, int lowerSumm)
{
    int indexRow = 0;
    int tempSumm = 0;
    string result = string.Empty;
    for (int i = 0; i < arrayForRusult.GetLength(0); i++)
    {
        tempSumm = SummSingleRow(arrayForRusult, i);
        if(tempSumm == lowerSumm)
        {
            result = result + i;
        }
    }
    return result;
}

bool FindIndexLowerRows(int[,] arrayForFindIndex, int currentRow, int lowerSummOfArray)
{
    bool result = false;
    int tempSumm = SummSingleRow(arrayForFindIndex, currentRow);
    if (tempSumm == lowerSummOfArray)
    {
        return true;
    }
    return result;
}

void Print2DArray(int[,] arrayToPrint, int lowerSumm)
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
            bool color = FindIndexLowerRows(arrayToPrint, i, lowerSumm);
            if (color == true)
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
            }
                Console.Write($"{arrayToPrint[i, j]}\t");
        }
        Console.ResetColor();
        Console.WriteLine();
    }
}

int[,] test = GetArrayRandomNumbers(10, 3);
int lowerSumm = FindLowerSummRowOfArray(test);
Print2DArray(test, lowerSumm);
System.Console.WriteLine($"вернул это {lowerSumm}");
//int index = FindIndexLowerRows(test);
//System.Console.WriteLine($"вернул такой интекс {index}");
