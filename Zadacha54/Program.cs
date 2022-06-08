/*
Задача 54: Задайте двумерный массив. Напишите программу, которая упорядочит по убыванию элементы каждой строки двумерного массива.
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

void SortArray(int[,] array) // по ощущение - тут могла бы быть рекурсия, но что-то как-то не заходит =)
{
    int max;
    int maxRow;
    int maxColum;
    for ( int n = 0 ; n < array.GetLength(0) ; n++)
    {
        for ( int m = 0 ; m < array.GetLength(1) ; m ++)
        {
            max = array[n,m];
            maxRow = n;
            maxColum = m;
            for ( int i = m ; i < array.GetLength(1) ; i ++)
            {
                if (max <= array[n,i] )
                {
                        max = array[n,i];
                        maxRow = n;
                        maxColum = i;
                }
            }
            array[maxRow,maxColum] = array[n,m];
            array[n,m] = max;
        }
    }
}

Console.Write("Задача 54:"+
"\nЗадайте двумерный массив."+
"\nНапишите программу, которая упорядочит по убыванию элементы"+
"\nкаждой строки двумерного массива.\n\n");

int rows = NumberInput("кол-во строк");
int colums = NumberInput("кол-во столбцов");

int[,] array= RandomArrayCreation( rows,colums,0,9); // в предыдущих заданиях были именые атрибуты, пока убрал что бы было в строчку
Console.Write("\nИзначальный массив : \n");
ArrayPrint(array);
SortArray(array);
Console.Write("\nОтсортированный массив : \n");
ArrayPrint(array);