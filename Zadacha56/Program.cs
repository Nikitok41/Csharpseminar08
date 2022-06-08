/*
Задача 56: Задайте прямоугольный двумерный массив. Напишите программу, которая будет находить строку с наименьшей суммой элементов.
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

void ArrayPrintFancy(int[,] array,int[] laneArray,int laneIndex)
{
    Console.Write("\n");
    Console.WriteLine($"В строке {laneIndex+1} самая маленькая сумма ( {laneArray[laneIndex]} ) *index этой строки ({laneIndex})");
    for ( int i = 0 ; i < array.GetLength(0) ; i ++)
    {
        Console.Write($"Строка {i+1}");
        for ( int j = 0 ; j < array.GetLength(1) ; j ++)
            Console.Write($"\t{array[i,j],3}"); 
        Console.Write($"\t Сумма эллементов : {laneArray[i]}");
        Console.Write("\n");
    }
}

(int[],int) LookUpLaneWithMinSum(int[,] array)
{
    int[] laneSumArray = new int[array.GetLength(0)];
    for ( int i = 0 ; i < array.GetLength(0) ; i++)
        for ( int j = 0 ; j < array.GetLength(1) ; j++)
            laneSumArray[i] += array[i,j];
    int min = laneSumArray[0];
    int minLaneIndex = 0;
    for (int i = 0 ; i < laneSumArray.Length ; i ++)
        if (laneSumArray[i] < min )
        {
            min = laneSumArray[i];
            minLaneIndex = i;
        }
    return (laneSumArray,minLaneIndex);
}

Console.Write("Задача 56:"+
"\nЗадайте прямоугольный двумерный массив."+
"\nНапишите программу, которая будет находить строку с наименьшей суммой элементов.\n\n");

int rows = NumberInput("кол-во строк");
int colums = NumberInput("кол-во столбцов");

int[,] array= RandomArrayCreation( rows:rows,
                                    colums:colums,
                                    minRandom:0,
                                    maxRandom:9);
Console.Write("\nИзначальный массив : \n");
ArrayPrint(array);
( int[] lanesSumArray, int minLaneSumIndex ) = LookUpLaneWithMinSum(array);
Console.Write("\nОформленный результат : \n");
ArrayPrintFancy(array,lanesSumArray,minLaneSumIndex);