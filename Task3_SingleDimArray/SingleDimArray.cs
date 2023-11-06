// Команды:
// + create - создать новый массив
// + input - заполнить массив вводом с клавиатуры
// + inputRandom - заполнить массив случайными числами
// + print - вывести массив на консоль
// + search - найти вхождения элемента в массив
// + delete - удалить вхождения элемента в массив
// + max - максимальное значение элемента в массиве
// + add - сложение двух массивов
// + sort - сортировка массива по возрастанию элементов

namespace Task3_SingleDimArray;

using static System.Console;
internal class SingleDimArray
{
    static void Main(string[] args)
    {
        string? inputString = null;
        MyArray? array = null;
        MyArray? secondArray = null;

        do
        {
            WriteColor("Введите команду -> ", "Yellow", false);
            inputString = ReadLine();

            // переменные для проверки работы функций
            int[] paramsArray;
            bool flag = false;
            int intVal = 0;
            string? outputString = null;

            switch (inputString)
            {
                case "/stop":
                    break;
                case "create":
                    do
                    {
                        int num = 0;
                        WriteColor("Введите размер массива --> ", "Yellow", false);
                        inputString = ReadLine();
                        if (!int.TryParse(inputString,out num) || num < 0)
                        {
                            WriteColor("Ошибка при указании размеров массива", "Red", true);
                            continue;
                        }
                        array = new(num);
                        WriteColor("Новый массив успешно создан", "Green", true);
                        break;
                    } while (true);

                    break;
                case "input":
                    if (array == null)
                    {
                        WriteColor("Массив ещё не был создан", "Red", true);
                        break;
                    }

                    do
                    {
                        WriteColor("Введите данные для заполнения --> ", "Yellow", false);
                        inputString = ReadLine();

                        if (inputString == null)
                        {
                            WriteColor("Введена пустая строка", "Red", true);
                            continue;
                        }

                        switch(array.InputData(inputString))
                        {
                            case 0:
                                WriteColor("Данные успешно записаны", "Green", true);
                                flag = true;
                                break;
                            default:
                                WriteColor("Ошибка при вводе данных", "Red", true);
                                break;
                        }

                    } while (!flag);
                    flag = false;

                    break;
                case "inputRandom":
                    // Если массив ещё не был создан
                    if (array == null)
                    {
                        WriteColor("Массив ещё не был создан", "Red", true);
                        break;
                    }

                    do
                    {
                        WriteColor("Введите индексы массива, опционально - диапазон случайных значений --> ",
                            "Yellow", false);
                        inputString = ReadLine();

                        // попытка обработать пользовательский ввод
                        try
                        {
                            // если введена пустая строка
                            if (inputString == null)
                            {
                                throw new Exception();
                            }
                            // получение массива целых чисел из строки
                            paramsArray = inputString!.Split().Select(n => Convert.ToInt32(n)).ToArray();
                        }
                        catch
                        {
                            WriteColor("Ошибка при задании параметров", "Red", true);
                            continue;
                        }

                        // вызов функции для заполнения случайными числами
                        switch (paramsArray.Length) // в зависимости от числа аргументов
                        {
                            case 2:
                                intVal = array.InputDataRandom(paramsArray[0], paramsArray[1]);
                                break;
                            case 3:
                                intVal = array.InputDataRandom(paramsArray[0], paramsArray[1], paramsArray[2]);
                                break;
                            case 4:
                                intVal = array.InputDataRandom(paramsArray[0], paramsArray[1],
                                    paramsArray[2], paramsArray[3]);
                                break;
                            default:
                                WriteColor("Количество параметров меньше или больше необходимого",
                                    "Red", true);
                                break;
                        }

                        // обработка результатов работы функции заполнения случайными числами
                        switch (intVal) // в зависимости от возвращенного значения
                        {
                            case 0:
                                WriteColor("Массив успешно заполнен", "Green", true);
                                flag = true;
                                break;
                            case -1:
                                WriteColor("Неправильно заданы границы массива", "Red", true);
                                break;
                            case -2:
                                WriteColor("Неправильно заданы границы случайных чисел", "Red", true);
                                break;
                            default:
                                WriteColor("Ошибка при задании параметров", "Red", true);
                                break;
                        }

                    } while (!flag);
                    flag = false;
                    break;
                case "print":
                    // Если массив ещё не был создан
                    if (array == null)
                    {
                        WriteColor("Массив ещё не был создан", "Red", true);
                        break;
                    }

                    do
                    {
                        WriteColor("Введите от нуля до двух индексов массива --> ",
                            "Yellow", false);
                        inputString = ReadLine();

                        // попытка обработать пользовательский ввод
                        try
                        {
                            // если введена пустая строка
                            if (inputString == null)
                            {
                                throw new ArgumentNullException();
                            }
                            // получение массива целых чисел из строки
                            paramsArray = inputString!.Split().Select(n => Convert.ToInt32(n)).ToArray();
                        }
                        catch (ArgumentNullException)
                        {
                            WriteColor("Введена пустая строка", "Red", true);
                            continue;
                        }
                        catch (Exception)
                        {
                            WriteColor("Печатается весь массив целиком", "Blue", true);
                            paramsArray = new int[0];
                        }

                        // вызов функции для заполнения случайными числами
                        switch (paramsArray.Length) // в зависимости от числа аргументов
                        {
                            case 0:
                                intVal = array.Print();
                                break;
                            case 1:
                                intVal = array.Print(paramsArray[0]);
                                break;
                            case 2:
                                intVal = array.Print(paramsArray[0], paramsArray[1]);
                                break;
                            default:
                                WriteColor("Количество параметров больше необходимого",
                                    "Red", true);
                                break;
                        }

                        // обработка результатов работы функции заполнения случайными числами
                        switch (intVal) // в зависимости от возвращенного значения
                        {
                            case 0:
                                WriteColor("Массив успешно выведен на консоль", "Green", true);
                                flag = true;
                                break;
                            case -1:
                                WriteColor("Неправильно заданы границы массива", "Red", true);
                                break;
                            default:
                                WriteColor("Ошибка при задании параметров", "Red", true);
                                break;
                        }

                    } while (!flag);
                    flag = false;
                    break;
                case "search":
                    // Если массив ещё не был создан
                    if (array == null)
                    {
                        WriteColor("Массив ещё не был создан", "Red", true);
                        break;
                    }

                    do
                    {
                        WriteColor("Введите элемент для поиска --> ", "Yellow", false);
                        inputString = ReadLine();

                        if (inputString == null || !int.TryParse(inputString, out intVal))
                        {
                            WriteColor("Ошибка ввода", "Red",true);
                            continue;
                        }

                        // вызов функции поиска и обработка результата
                        switch(array.FindValue(intVal, out outputString))
                        {
                            case 0:
                                WriteLine(outputString);
                                WriteColor("Успешно найден искомый элемент массива",
                                    "Green", true);
                                flag = true;
                                break;
                            case -1:
                                WriteColor("Не удалось найти ни один такой элемент массива",
                                    "Blue", true);
                                break;
                            case -2:
                                WriteColor("Размер массива равен нулю", "Red", true);
                                break;
                            default:
                                WriteColor("Ошибка при задании параметров", "Red", true);
                                break;
                        }

                    } while (!flag);
                    flag = false;
                    break;
                case "delete":
                    // Если массив ещё не был создан
                    if (array == null)
                    {
                        WriteColor("Массив ещё не был создан", "Red", true);
                        break;
                    }

                    do
                    {
                        WriteColor("Введите элемент для удаления --> ", "Yellow", false);
                        inputString = ReadLine();

                        if (inputString == null || !int.TryParse(inputString, out intVal))
                        {
                            WriteColor("Ошибка ввода", "Red", true);
                            continue;
                        }

                        // вызов функции поиска и обработка результата
                        switch (array.DeleteValue(intVal))
                        {
                            case 0:
                                WriteColor("Элемент массива успешно удалён",
                                    "Green", true);
                                flag = true;
                                break;
                            case -1:
                                WriteColor("Не удалось найти ни один элемент массива для удаления",
                                    "Blue", true);
                                break;
                            case -2:
                                WriteColor("Размер массива равен нулю", "Red", true);
                                break;
                            default:
                                WriteColor("Ошибка при задании параметров", "Red", true);
                                break;
                        }
                    } while (!flag);
                    flag = false;
                    break;
                case "max":
                    // Если массив ещё не был создан
                    if (array == null)
                    {
                        WriteColor("Массив ещё не был создан", "Red", true);
                        break;
                    }

                    intVal = array.FindMax();
                    if (intVal != int.MinValue)
                    {
                        WriteLine(intVal);
                        WriteColor("Успешно найден максимальный элемент массива", "Green", true);
                    }
                    else
                    {
                        WriteColor("Ошибка при поиске максимального значения", "Red", true);
                    }
                    break;
                case "add":
                    if (array == null)
                    {
                        WriteColor("Массив ещё не был создан", "Red", true);
                        break;
                    }
                    
                    // Создание вспомогательного массива и заполнение его случайными значениями
                    secondArray = new(array.Size);
                    secondArray.InputDataRandom(0, secondArray.Size - 1);

                    WriteColor("Вспомогательный массив для демонстрации сложения:",
                        "Blue", true);
                    secondArray.Print();

                    if (array.Add(secondArray) == 0)
                    {
                        WriteColor("Успешно выполнено сложение двух массивов", "Green", true);
                    }
                    else
                    {
                        WriteColor("Ошибка при попытке сложить два массива", "Red", true);
                    }

                    break;
                case "sort":
                    // Если массив ещё не был создан
                    if (array == null)
                    {
                        WriteColor("Массив ещё не был создан", "Red", true);
                        break;
                    }

                    if (array.Sort() == 0)
                    {
                        WriteColor("Массив успешно отсортирован", "Green", true);
                    }
                    else
                    {
                        WriteColor("Размер массива равен нулю", "Red", true);
                    }

                    break;
                default:
                    WriteColor("Некорректная команда", "Red", true);
                    break;
                    
            }
        } while (inputString != "/stop");
    }

    /// <summary>
    /// Печать строки в каком-либо цвете.
    /// </summary>
    /// <param name="input">Строка для печати.</param>
    /// <param name="color">Цвет, в котором нужно напечатать строку.</param>
    /// <param name="newLine">Нужно ли переносить строку после печати.</param>
    static void WriteColor(string input, string color, bool newLine)
    {
        ConsoleColor consoleColor = ConsoleColor.White;
        if (Enum.TryParse(color, out consoleColor)) 
        {
            Console.ForegroundColor = consoleColor;
        }
        Write(input + (newLine ? "\n" : ""));
        Console.ForegroundColor = ConsoleColor.White;
    }
}

/// <summary>
/// Класс элемента массива.
/// </summary>
public class Elem
{
    private int _elemValue;
    private Elem? _nextElem;

    /// <summary>
    /// Констуктор по умолчанию.
    /// </summary>
    public Elem ()
    {
        _elemValue = default;
        _nextElem = null;
    }
    /// <summary>
    /// Констуктор с параметром.
    /// </summary>
    /// <param name="value">Значение, которое должен принять элемент массива.</param>
    public Elem(int value)
    {
        ElemValue = value;
        NextElem = null;
    }

    /// <summary>
    /// Свойство текущего элемента массива.
    /// </summary>
    public int ElemValue
    {
        get
        {
            return _elemValue;
        }
        set
        {
            _elemValue = value;
        }
    }
    /// <summary>
    /// Свойство следующего элемента массива.
    /// </summary>
    public Elem? NextElem
    {
        get
        {
            return _nextElem;
        }
        set
        {
            _nextElem = value;
        }
    }
}

/// <summary>
/// Класс массива целых чисел.
/// </summary>
public class MyArray
{
    private Elem? _firstElem;
    private int _size;

    /// <summary>
    /// Констуктор с параметром.
    /// </summary>
    /// <param name="size">Размер создаваемого массива.</param>
    public MyArray(int size)
    {
        Size = size;
        FirstElem = new Elem();
        Elem? curElem = FirstElem;

        for (int i = 1; i < Size; i++)
        {
            curElem!.NextElem = new();
            curElem = curElem.NextElem;
        }
    }

    /// <summary>
    /// Свойство первого элемента массива.
    /// </summary>
    public Elem FirstElem
    {
        get
        {
            return _firstElem!;
        }
        set
        {
            _firstElem = value;
        }
    }
    /// <summary>
    /// Свойство размера массива.
    /// </summary>
    public int Size
    {
        get
        {
            return _size;
        }
        init
        {
            _size = (value > 0 ? value : 0);
        }
    }

    /// <summary>
    /// Индексатор элементов массива.
    /// </summary>
    /// <param name="index">Индекс элемента массива.</param>
    /// <returns>int.MinValue, в случае возникновения ошибки;<br/>
    /// Значение элемента массива по индексу, в противном случае.</returns>
    public int this[int index]
    {
        get 
        {
            if (this.Size == 0 || index < 0 || index >= this.Size)
            {
                return int.MinValue;
            }

            Elem curElem = this.FirstElem;

            for (int i = 0; i < index; i++)
            {
                curElem = curElem.NextElem!;
            }

            return curElem.ElemValue;
        }
        set 
        {
            if (this.Size == 0 || index < 0 || index >= this.Size)
            {
                return;
            }

            Elem curElem = this.FirstElem;

            for (int i = 0; i < index; i++)
            {
                curElem = curElem.NextElem!;
            }

            curElem.ElemValue = value;
        }
    }

    /// <summary>
    /// Заполнение массива пользователем.
    /// </summary>
    /// <param name="arrElems">Строка чисел, которыми нужно заполнить массив.</param>
    /// <returns>-1, в случае ошибки ввода;<br/>
    /// 0, в случае успеха.</returns>
    public int InputData(string arrElems)
    {
        return InputData(this, arrElems);
    }
    /// <summary>
    /// Заполнение массива пользователем.
    /// </summary>
    /// <param name="array"></param>
    /// <param name="arrElems">Строка чисел, которыми нужно заполнить массив.</param>
    /// <returns>-1, в случае ошибки;<br/>
    /// 0, в случае успеха.</returns>
    public static int InputData(in MyArray array, string arrElems)
    {
        // если указатель на массив равен null или размер массива равен нулю
        if (array == null || array.Size == 0)
        {
            return -1;
        }

        // если указатель на строку равен null
        if (arrElems == null)
        {
            return -1;
        }

        Elem curElem = array.FirstElem;
        int curStrIndex = 0;
        int additStrIndex = 0;
        string number;

        while (curStrIndex < arrElems.Length && curElem != null)
        {
            // пока не встречена какая-либо цифра
            while (curStrIndex < arrElems.Length && !char.IsDigit(arrElems[curStrIndex]))
            {
                curStrIndex += 1;
            }
            additStrIndex = curStrIndex;
            // пока встречаются цифры
            while (additStrIndex < arrElems.Length && char.IsDigit(arrElems[additStrIndex]))
            {
                additStrIndex += 1;
            }

            // переписать число в массив
            number = arrElems.Substring(curStrIndex, additStrIndex - curStrIndex);
            curElem.ElemValue = int.Parse(number);

            // перевести указатель curElem на следующий элемент массива
            curElem = curElem.NextElem!;

            curStrIndex = additStrIndex;
        }

        return 0;
    }

    /// <summary>
    /// Заполнение части массива случайными значениями.
    /// </summary>
    /// <param name="firstIndex">Индекс элемента, с которого начинается заполнение.</param>
    /// <param name="secondIndex">Индекс элемента, на котором заканчивается заполнение.</param>
    /// <param name="bottomBorder">Минимальное случайное значение.</param>
    /// <param name="topBorder">Максимальное случайное значение.</param>
    /// <returns>-2, если неправильно заданы границы для генерации случайных чисел;<br/>
    /// -1, если неправильно заданы индексы массива;<br/>
    /// 0, если всё прошло успешно.</returns>
    public int InputDataRandom(int firstIndex, int secondIndex, int bottomBorder = 0, int topBorder = 10)
    {
        return InputDataRandom(this, firstIndex, secondIndex, bottomBorder, topBorder);
    }
    /// <summary>
    /// Заполнение части массива случайными значениями.
    /// </summary>
    /// <param name="array">Массив для заполнения.</param>
    /// <param name="firstIndex">Индекс элемента, с которого начинается заполнение.</param>
    /// <param name="secondIndex">Индекс элемента, на котором заканчивается заполнение.</param>
    /// <param name="bottomBorder">Минимальное случайное значение.</param>
    /// <param name="topBorder">Максимальное случайное значение.</param>
    /// <returns>-3, если указатель на массив равен null или если длина массива равна нулю;<br/>
    /// -2, если неправильно заданы границы для генерации случайных чисел;<br/>
    /// -1, если неправильно заданы индексы массива;<br/>
    /// 0, если всё прошло успешно.</returns>
    public static int InputDataRandom(MyArray array, int firstIndex, int secondIndex,
        int bottomBorder = 0, int topBorder = 10)
    {
        // проверка массива
        if (array == null || array.Size == 0)
        {
            return -3;
        }

        // проверка индексов
        if (firstIndex < 0 || array.Size <= secondIndex || secondIndex < firstIndex)
        {
            return -1;
        }
        // проверка диапазона для генерации случайных чисел
        if (topBorder <= bottomBorder)
        {
            return -2;
        }

        Elem? curElem = array.FirstElem;
        Random random = new();

        // дойти до элемента под нужным индексом
        for (int i = 0; i < firstIndex; i++)
        {
            curElem = curElem!.NextElem;
        }

        // заполнить элементы с firstIndex-а по secondIndex-й случайными значениями
        for (int i = firstIndex; i <= secondIndex; i++)
        {
            curElem!.ElemValue = random.Next(bottomBorder, topBorder);
            curElem = curElem.NextElem;
        }

        return 0;
    }

    /// <summary>
    /// Печатает элементы массива в промежутке между двумя индексами.
    /// </summary>
    /// <param name="firstIndex">Индекс первого для печати элемента массива.</param>
    /// <param name="secondIndex">Индекс последнего для печати элемента массива.</param>
    /// <returns>-1, если неправильно заданы индексы массива;<br/>
    /// 0, если всё прошло успешно.</returns>
    public int Print(int firstIndex, int secondIndex)
    {
        return Print(this, firstIndex, secondIndex);
    }
    /// <summary>
    /// Печатает элементы массива в промежутке от заданного индекса и до конца массива.
    /// </summary>
    /// <param name="firstIndex">Индекс первого для печати элемента массива.</param>
    /// <returns>-1, если неправильно заданы индексы массива;<br/>
    /// 0, если всё прошло успешно.</returns>
    public int Print(int firstIndex)
    {
        return Print(this, firstIndex, this.Size);
    }
    /// <summary>
    /// Печатает элементы массива.
    /// </summary>
    /// <returns>-1, в случае возникновения ошибки;<br/>
    /// 0, если всё прошло успешно.</returns>
    public int Print()
    {
        return Print(this, 0, this.Size-1);
    }
    /// <summary>
    /// Печатает элементы массива в промежутке между двумя индексами.
    /// </summary>
    /// <param name="array">Массив, элементы которого следует печатать.</param>
    /// <param name="firstIndex">Индекс первого для печати элемента массива.</param>
    /// <param name="secondIndex">Индекс последнего для печати элемента массива.</param>
    /// <returns>-2, если указатель на массив равен null или если длина массива равна нулю;<br/>
    /// -1, если неправильно заданы индексы массива;<br/>
    /// 0, если всё прошло успешно.</returns>
    public static int Print(in MyArray array, int firstIndex, int secondIndex)
    {
        if (array == null || array.Size == 0)
        {
            return -2;
        }

        // проверка индексов
        if (firstIndex < 0 || array.Size <= secondIndex || secondIndex < firstIndex)
        {
            return -1;
        }

        Elem? curElem = array.FirstElem;

        // дойти до элемента под нужным индексом
        for (int i = 0; i < firstIndex; i++)
        {
            curElem = curElem!.NextElem;
        }

        // Напечатать элементы массива с firstIndex-о по secondIndex-й
        for (int i = firstIndex; i <= secondIndex; i++)
        {
            WriteLine(curElem!.ElemValue);
            curElem = curElem!.NextElem;
        }

        return 0;
    }

    /// <summary>
    /// Поиск максимального значения в массиве.
    /// </summary>
    /// <returns>Максимальное значение в массиве, либо Int32.MinValue 
    /// в случае возникновения ошибки.</returns>
    public int FindMax()
    {
        return FindMax(this);
    }

    /// <summary>
    /// Поиск максимального значения в массиве.
    /// </summary>
    /// <param name="array">Массив, в котором осуществляется поиск.</param>
    /// <returns>Максимальное значение в массиве, либо Int32.MinValue 
    /// в случае возникновения ошибки.</returns>
    public static int FindMax(in MyArray array)
    {
        // если размер массива равен нулю
        if (array == null || array.Size == 0)
        {
            return int.MinValue; // вернуть наименьшее возможное значение int
        }

        int maxVal = int.MinValue;
        Elem? curElem = array.FirstElem;

        // нахождение максимума
        for (int i = 0; i < array.Size; i++)
        {
            maxVal = curElem.ElemValue > maxVal ? curElem.ElemValue : maxVal;
            curElem = curElem.NextElem!;
        }

        return maxVal;
    }

    /// <summary>
    /// Сложить два массива между собой.
    /// </summary>
    /// <param name="array">Массив, который нужно прибавить.</param>
    /// <returns>-1, в случае несовпадения размеров, пустого массива или указателя
    /// на массив, равного null.<br/>
    /// 0, в случае успешного сложения.</returns>
    public int Add(in MyArray array)
    {
        // если указатель на массив равен null, не совпадают размеры или передан массив нулевого размера
        if (array == null || array.Size == 0 || this.Size != array.Size)
        {
            return -1;
        }

        Elem? curElem = this.FirstElem;
        Elem? otherArrElem = array.FirstElem;

        // поэлементное сложение массивов
        for (int i = 0; i < this.Size; i++)
        {
            curElem!.ElemValue += otherArrElem!.ElemValue;
            curElem = curElem!.NextElem;
            otherArrElem = otherArrElem!.NextElem;

        }

        return 0;
    }
    /// <summary>
    /// Сложить два массива между собой.
    /// </summary>
    /// <param name="firstArray">Первый массив для сложения.</param>
    /// <param name="secondArray">Второй массив для сложения.</param>
    /// <returns>Новый массив, являющийся результатом сложения двух исходных,
    /// либо null в случае несовпадения размера массивов, передачи пустого массива
    /// или равенства одного из указателей значению null.</returns>
    public static MyArray? Add(in MyArray firstArray, in MyArray secondArray)
    {
        // если не совпадают размеры, передан нулевой массив иои один из указателей равен null
        if (firstArray == null || secondArray == null
            || firstArray.Size != secondArray.Size || firstArray.Size == 0)
        {
            return null;
        }

        MyArray tmpArr = new(firstArray.Size);
        Elem? curArrElem = tmpArr.FirstElem;
        Elem? firstArrElem = firstArray.FirstElem;
        Elem? secondArrElem = secondArray.FirstElem;

        // поэлементное сложение массивов
        for (int i = 0; i < tmpArr.Size; i++)
        {
            curArrElem!.ElemValue = firstArrElem!.ElemValue
                + secondArrElem!.ElemValue;

            curArrElem = curArrElem!.NextElem;
            firstArrElem = firstArrElem!.NextElem;
            secondArrElem = secondArrElem!.NextElem;
        }

        return tmpArr;
    }

    /// <summary>
    /// Удалить все вхождения значения в массив.
    /// </summary>
    /// <param name="value">Значение, которое необходимо удалить.</param>
    /// <returns>-2, если указатель на массив равен нулю или если размер
    /// массива равен нулю;<br/>
    /// -1, если ни один элемент не был удалён;<br/>
    /// 0, в случае успешного удаления.</returns>
    public int DeleteValue(int value)
    {
        // если указатель на массив равен нулю или размер массива равен нулю
        if (this == null || this.Size == 0)
        {
            return -2;
        }

        int delElems = 0;
        //int index = 0;
        Elem curElem = this.FirstElem;

        for (int i = 0; i < this.Size; i++)
        {
            if (curElem!.ElemValue == value)
            {
                curElem.ElemValue = 0;
                delElems += 1;
            }
            curElem = curElem.NextElem!;
        }

            /*
        while (index + delElems != this.Size)
        {
            // если текущий элемент массива не совпадает с элементом на удаление
            if (curElem.ElemValue != value)
            {
                index += 1; // инкрементировать индекс
            }
            // если совпадает
            else
            {
                // если индекс равен нулю
                if (index == 0)
                {
                    this.FirstElem = this.FirstElem!.NextElem!;
                }
                // в противном случае
                else
                {
                    curElem.NextElem = curElem.NextElem!.NextElem!;
                }

                // инкрементировать счетчик удаленных элементов
                delElems += 1;
            }

            curElem = curElem.NextElem!;
        }

        // если хотя бы один элемент был удалён
        if (delElems != 0)
        {
            curElem = this.FirstElem;
            for (int i = 0; i < this.Size - delElems; i++)
            {
                curElem = curElem.NextElem!;
            }
            // заполнить оставшиеся в конце массива ячейки нулями
            for (int i = this.Size - delElems; i < this.Size; i++)
            {
                curElem.NextElem = new();
                curElem = curElem.NextElem!;
            }
        }
            */

        return delElems == 0 ? -1 : 0;
    }
    /// <summary>
    /// Удалить все вхождения значения в массив.
    /// </summary>
    /// <param name="array">Массив, из которого производится удаление.</param>
    /// <param name="value">Значение, которое необходимо удалить.</param>
    /// <returns>-2, если указатель на массив равен нулю или если размер
    /// массива равен нулю;<br/>
    /// -1, если ни один элемент не был удалён;<br/>
    /// 0, в случае успешного удаления.</returns>
    public static int DeleteValue(ref MyArray array, int value)
    {
        return array.DeleteValue(value);
    }

    /// <summary>
    /// Поиск зачения в массиве.
    /// </summary>
    /// <param name="value">Значение, которое ищется в массиве.</param>
    /// <param name="indString">Выходная строка, содержащая индексы найденных элементов.
    /// Указатель на строку равен null, если не найден ни один элемент массива с нужным значением.</param>
    /// <returns>-2, если указатель на массив равен нулю или если размер массива равен нулю;<br/>
    /// -1, если не удалось найти ни один элемент массива;<br/>
    /// 0, если успешно найден хотя бы один элемент с совпадающим значением.</returns>
    public int FindValue(int value, out string? indString)
    {
        return FindValue(this, value, out indString);
    }
    /// <summary>
    /// Поиск зачения в массиве.
    /// </summary>
    /// <param name="array">Массив, в котором осуществляется поиск значения.</param>
    /// <param name="value">Значение, которое ищется в массиве.</param>
    /// <param name="indString">Выходная строка, содержащая индексы найденных элементов.
    /// Указатель на строку равен null, если не найден ни один элемент массива с нужным значением.</param>
    /// <returns>-2, если указатель на массив равен нулю или если размер массива равен нулю;<br/>
    /// -1, если не удалось найти ни один элемент массива;<br/>
    /// 0, если успешно найден хотя бы один элемент с совпадающим значением.</returns>
    public static int FindValue(in MyArray array, int value, out string? indString)
    {
        indString = null;
        bool flag = false;

        if (array == null || array.Size == 0)
        {
            return -2;
        }

        Elem curElem = array.FirstElem;

        for (int i = 0; i < array.Size; i++)
        {
            if (curElem.ElemValue == value)
            {
                indString += (flag ? "; " : "") + i;
                flag = true;
            }
            curElem = curElem.NextElem!;
        }

        return indString == null ? -1 : 0;
    }

    /// <summary>
    /// Выполнить сортировку элементов массива по возрастанию.
    /// </summary>
    /// <returns>-1, если если размер массива равен нулю;<br/>
    /// 0, в противном случае.</returns>
    public int Sort()
    {
        if (this.Size == 0)
        {
            return -1;
        }

        Elem curElem;
        int tmpVal;

        for (int i = 0; i < this.Size - 1; i++)
        {
            curElem = this.FirstElem;

            for (int j = 0; j < this.Size - i-1; j++)
            {
                if (curElem.ElemValue > curElem!.NextElem!.ElemValue)
                {
                    tmpVal = curElem.ElemValue;
                    curElem.ElemValue = curElem.NextElem!.ElemValue;
                    curElem.NextElem.ElemValue = tmpVal;
                }

                curElem = curElem.NextElem!;
            }
        }

        return 0;
    }
    /// <summary>
    /// Выполнить сортировку элементов массива по возрастанию.
    /// </summary>
    /// <param name="array">Массив, который нужно отсортировать.</param>
    /// <returns>-1, если указатель на массив равен нулю или если размер массива равен нулю;<br/>
    /// 0, в противном случае.</returns>
    public static int Sort(ref MyArray array)
    {
        return array == null ? -1 : array.Sort();
    }
}