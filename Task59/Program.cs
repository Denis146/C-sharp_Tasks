﻿// 59. Задайте двумерный массив из целых чисел
// Напишите программу, которая удалит (пропускает) строку и столбец,
// на пересечении которых расположен наименьший элемент массива.
// Например, задан массив:
// 1 4 7 2
// 5 9 2 3 
// 8 4 2 4 
// 5 2 6 7 
// наименьший элемент 1
// на выходе получим массив:
// 9 2 3
// 4 2 4
// 2 6 7

int[,] CreateMatrixRndInt(int rows, int colums, int min, int max)
{
    int[,] matrix = new int[rows, colums];
    Random rnd = new Random();

    for (int i = 0; i < matrix.GetLength(0); i++)
    {
        for (int j = 0; j < matrix.GetLength(1); j++)
        {
            matrix[i, j] = rnd.Next(min, max + 1);
        }
    }
    return matrix;
}

void PrintMatrix(int[,] matrix)
{
    for (int i = 0; i < matrix.GetLength(0); i++)
    {
        for (int j = 0; j < matrix.GetLength(1); j++)
        {
            Console.Write($"{matrix[i, j],5}");
        }
        Console.WriteLine();
    }
}

// находим элемент с минимальным значением
int[] MinElem(int[,] matrix)
{
    int row = 0;
    int column = 0;

    for (int i = 0; i < matrix.GetLength(0); i++)
    {
        for (int j = 0; j < matrix.GetLength(1); j++)
        {
            if (matrix[i, j] <= matrix[row, column])
            {
                row = i;
                column = j;
            }
        }
    }
    return new int[] { row, column };
}

int[,] DeleteRowColumn(int[,] matrix, int[] array)
{
    int[,] newMatrix = new int [matrix.GetLength(0) - 1, matrix.GetLength(1) - 1];
    int m = 0, n = 0;
    for (int i = 0; i < newMatrix.GetLength(0); i++)
    {
        if (m == array[0]) m++;

        for (int j = 0; j < newMatrix.GetLength(1); j++)
        {
            if (n == array[1]) n++;
            newMatrix[i, j] = newMatrix[m, n];
            n++;
        }
        m++;
        n = 0;
    }
    return newMatrix;
}


int[,] array2d = CreateMatrixRndInt(3, 3, -5, 10);
PrintMatrix(array2d);
Console.WriteLine();


int[] minElem = MinElem(array2d);
int [,] delRowColumn = DeleteRowColumn (array2d, minElem);

PrintMatrix(delRowColumn);

// комментарий учителя:
// В задаче 59 новую матрицу нужно заполнять из исходной, сейчас в коде новая заполняется из новой.
// Нужно испраить
