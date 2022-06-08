/*
Задача 58: Задайте две матрицы. Напишите программу, которая будет находить произведение двух матриц.
*/

//вставил на всякий случай возможность изменения рандомности чисел
int[,] RandomArrayCreation(int rows , int colums , int minRandom , int maxRandom)
{
    Random rnd = new Random();
    int[,] array = new int[rows,colums];
    for ( int i = 0 ; i < rows ; i ++)
        for ( int j = 0 ; j < colums ; j ++)
            array[i,j] = rnd.Next(minRandom,maxRandom+1);
return array;
}

//Метод ввода и проверки на число
int NumberInput(string text)
{
    bool isInputInt = true;
    int number =0;
    while (isInputInt)
    {
        Console.Write($"Введите {text} :");
        string numberSTR = Console.ReadLine();
        if (int.TryParse(numberSTR, out int numberInt))
        {
            if (numberInt <= 0) Console.WriteLine("Введите число больше нуля");
            else
            {
                number = numberInt;
                isInputInt = false;
            } 
        }
        else 
            Console.WriteLine("Ввели не число");
    }
    return number;
}

void ArrayPrint(int[,] array)
{
    Console.Write("\n");
    for ( int i = 0 ; i < array.GetLength(0) ; i ++)
    {
        for ( int j = 0 ; j < array.GetLength(1) ; j ++)
            Console.Write($"\t{array[i,j],3}"); 
        Console.Write("\n");
    }
}

//Внизу метод - проходи по каждому эллементу нового массива
//каждый эллемент - это сумма произведения строки массива А на столбец массива В
//Из-за этого - голова начинает кипеть и проблема в том , что бы проверить - нужно это всё на калькуляторе просчитать 

int[,] ProductArray(int[,] arrayA, int[,] arrayB)
{
    int rowsArrayA = arrayA.GetLength(0);
    int columsArrayA = arrayA.GetLength(1);
    int rowsArrayB = columsArrayA;
    int columsArrayB = arrayB.GetLength(1);
    int[,] productArray = new int[rowsArrayA,columsArrayB];
    for ( int i = 0 ; i < rowsArrayA ; i++)
        for ( int j = 0 ; j < columsArrayB ; j++)
            for ( int n = 0 ; n < columsArrayA ; n++)
                productArray[i,j] += arrayA[i,n]*arrayB[n,j];
    return productArray;
}

Console.Write("Задача 58:"+
"\nЗадайте две матрицы.."+
"\nНапишите программу, которая будет находить произведение двух матриц..\n\n");

int rowsArrayA = NumberInput("кол-во строк массива А");
int columsArrayA = NumberInput("кол-во столбцов массива А");
Console.WriteLine($"По теории, количество строк массива В равно количеству столбцов массива А, в нашем случае ({columsArrayA})");
int rowsArrayB = columsArrayA;
int columsArrayB = NumberInput("кол-во столбцов массива В");

int[,] arrayA= RandomArrayCreation( rows:rowsArrayA,
                                    colums:columsArrayA,
                                    minRandom:0,
                                    maxRandom:9);
Console.Write("\nМассив А: \n");
ArrayPrint(arrayA);
int[,] arrayB= RandomArrayCreation( rows:rowsArrayB,
                                    colums:columsArrayB,
                                    minRandom:0,
                                    maxRandom:9);
Console.Write("\nМассив B: \n");
ArrayPrint(arrayB);
int[,] productArray = ProductArray(arrayA,arrayB);
Console.Write("\nМассив произведения: \n");
ArrayPrint(productArray);