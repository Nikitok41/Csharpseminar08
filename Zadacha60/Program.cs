/*
Задача 60: Сформируйте трёхмерный массив из неповторяющихся двузначных чисел. 
Напишите программу, которая будет построчно выводить массив, добавляя индексы каждого элемента.
*/

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

int[,,] ArrayCreation(int xDem, int yDem, int zDem)
{
    Random rnd = new Random();
    int[,,] array = new int[xDem,yDem,zDem];
    for (int x = 0 ; x < xDem ; x++)
        for (int y = 0 ; y < yDem ; y++)
            for (int z = 0 ; z < zDem ; z++)
            {
                //Способ ввода случайного числа и проверки - если такое число уже есть , то пробует снова 
                bool uniqueNumber = true;
                while (uniqueNumber)
                {
                    array[x,y,z] = rnd.Next(10,100);
                    uniqueNumber = LookUpNumberInArray(array[x,y,z],array);
                }
            }
    return array;
}

void PrintArrayLine(int[,,] array)
{
    Console.Write($"\nx.y.z.\tNum\n");
    for (int x = 0 ; x < array.GetLength(0) ; x++)
        for (int y = 0 ; y < array.GetLength(1) ; y++)
            for (int z = 0 ; z < array.GetLength(2) ; z++)
                Console.Write($"{x}.{y}.{z}.\t{array[x,y,z]}\n");
}

//Метод проверки есть ли такое число в массиве
bool LookUpNumberInArray(int number, int[,,] array)
{
    bool result = true;
    for ( int x = 0 ; x < array.GetLength(0) ; x++)
        for ( int y = 0 ; y < array.GetLength(1) ; y++)
            for ( int z = 0 ; z < array.GetLength(2) ; z++)
                if ( number == array[x,y,z]) result = false;
    return result;
}

Console.Write("Задача 60:"+
"\nСформируйте трёхмерный массив из неповторяющихся двузначных чисел."+
"\nНапишите программу, которая будет построчно выводить массив,"+
"добавляя индексы каждого элемента.\n\n");

int xRows = NumberInput("кол-во эллементов по X");
int yColums = NumberInput("кол-во эллементов по Y");
int zAmmount = NumberInput("кол-во эллементов по Z");
//В условии прописанно что массив создан из "неповторяющихся двузначных чисел" - то есть от 10 до 99, по этому массив не может быть больше 90 символов. 
if (xRows*yColums*zAmmount > 90)
    Console.WriteLine("Количество цифр в массиве не позволяет использовать уникальные двухзначные числа");
else
{
    int[,,] array = ArrayCreation(xRows,yColums,zAmmount);
    PrintArrayLine(array);
}