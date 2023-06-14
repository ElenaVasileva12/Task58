//  Задайте две матрицы. Напишите программу, которая будет находить произведение
// двух матриц.
// Например, даны 2 матрицы:
// 2 4 | 3 4
// 3 2 | 3 3
//Результирующая матрица будет:
// 18 20
// 15 18

//двумерный массив с случайным вводом (универсальный)
int[,] CreateMatrixRndInt(int rows, int columns, int min, int max)
{
    int[,] matrix = new int[rows, columns];
    Random rnd = new Random();
    for (int i = 0; i < matrix.GetLength(0); i++)  //или rows
    {
        for (int j = 0; j < matrix.GetLength(1); j++)    //или columns
        {
            matrix[i, j] = rnd.Next(min, max + 1);
        }
    }
    return matrix;
}

//вывод массива на экран (универсальный)
void PrintMatrix(int[,] matrix)
{
    for (int i = 0; i < matrix.GetLength(0); i++)  //или rows
    {
        for (int j = 0; j < matrix.GetLength(1); j++)    //или columns
        {
            Console.Write($"{matrix[i, j],5}");  //5 это чтобы разделять числа
        }
        Console.WriteLine();
    }
}

//проверка на корректные матрицы
bool CheckFirstSecondMatrix (int[,] matrix1, int[,] matrix2)
{
   return matrix1.GetLength(1)==matrix2.GetLength(0);      
}


//произведение матриц
int[,] CompositionMatrix(int[,] matrix1, int[,] matrix2)
{
    int[,] matrix3 = new int[matrix1.GetLength(0), matrix2.GetLength(1)];
    for (int i = 0; i < matrix1.GetLength(0); i++)
    {
        for (int j = 0; j < matrix2.GetLength(1); j++)
        { 
            for (int k = 0; k < matrix1.GetLength(1); k++)
            {
                matrix3[i,j]+=matrix1[i,k]*matrix2[k,j];
            }
        }
    }
    return matrix3;
}


int[,] array2d1 = CreateMatrixRndInt(2, 4, 0, 10);
int[,] array2d2 = CreateMatrixRndInt(4, 3, 0, 10);
PrintMatrix(array2d1);
Console.WriteLine();
PrintMatrix(array2d2);



if (CheckFirstSecondMatrix(array2d1,array2d2))
{
    int[,] array2d3 = CompositionMatrix(array2d1,array2d2);
    Console.WriteLine();
    PrintMatrix(array2d3);
}
else
{
    Console.WriteLine($"Ошибка, количество столбцов/строк не корректно");
}
