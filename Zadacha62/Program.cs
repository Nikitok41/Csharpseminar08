/*
Задача 62: Заполните спирально массив 4 на 4.
*/

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

int NumberInput(string text)//Метод ввода и проверки на число
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
//Метод создаёт массив из заданного количества строк / столбцов и заполняет его по спирали 
//Спираль идёт вправо , вниз , влево, вверх. 
int[,] SpiralArrayCreation(int rows , int colums)
{
    int[,] array = new int[rows,colums];
    int number = 1;
    int i = 0;
    int j = 0;
    int direction = 1;
    array[i,j] = number; //Схема внизу сразу движется - по этому самое первое значение пропускается *попробую исправить в следующем варианте.
    number++;
    while ( number <= rows*colums)
    {
        switch (direction) //Проверка - в какую сторону двигаться 1 - вправо. 2 - вниз. 3 - влево. 4 - вверх. 
        {
            case 1:
                (array,number,i,j) = RightFilling(i,j,number,array); // полностью заполняет массив по движению
                direction = 2;// меняет сторону
                break;
            case 2:
                (array,number,i,j) = DownFilling(i,j,number,array);
                direction = 3;
                break;
            case 3:
                (array,number,i,j) = LeftFilling(i,j,number,array);
                direction = 4;
                break;
            default:
                (array,number,i,j) = UpFilling(i,j,number,array);
                direction = 1;
                break;
        }
    }
    
    return array;
}
// на примере движения на права - опишу метод
// пока писал комментарии, понял что можно чуть упросить методы, по этому переделаю в варианте 2.
(int[,] , int , int , int) RightFilling(int row , int colum , int number , int[,] array)//Метод движения вправо
{
    while (array[row,colum+1] == 0) //изначально заходит в цикл с позиции 0.0 проверяет если следующая равно 0, тогда двигается на то место
    {
        colum++; //движение ( в зависимости куда двигается - прибавляет или отнимает столбец или строку )
        array[row,colum] = number; // меняет 0 на число
        number++; // увеличивает число
        if (colum+1 == array.GetLength(1)) break; // если следующее значение выходит за рамки массива - принудительный выброс иначе while ломал программу 
    }

    return (array,number,row,colum); // возвращает то что получилось
}
(int[,] , int , int , int) DownFilling(int row , int colum , int number , int[,] array)//Метод движения вниз
{
    while ( array[row+1,colum] == 0)
    {
        row++;
        array[row,colum] = number;
        number++;
        if (row+1 == array.GetLength(0)) break;
    }

    return (array,number,row,colum);
}
(int[,] , int , int , int) LeftFilling(int row , int colum , int number , int[,] array)//Метод движения влево
{
    while (array[row,colum-1] == 0)
    {
        colum--;
        array[row,colum] = number;
        number++;
        if (colum - 1 == -1) break;
    }

    return (array,number,row,colum);
}
(int[,] , int , int , int) UpFilling(int row , int colum , int number , int[,] array)//Метод движения вверх
{
    while (array[row-1,colum] == 0)
    {
        row--;
        array[row,colum] = number;
        number++;
        if (row - 1 == -1) break;
    }

    return (array,number,row,colum);
}


Console.Write("Задача 62:"+
"Заполните спирально массив 4 на 4.\n\n");

int rows = NumberInput("кол-во строк");
int colums = NumberInput("кол-во столбцов");
int[,] array = SpiralArrayCreation(rows,colums);
ArrayPrint(array);