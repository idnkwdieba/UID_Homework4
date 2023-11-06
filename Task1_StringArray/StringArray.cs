// Команды:
// set - задать двумерный массив
// print - вывести массив на консоль
// max - максимальный элемент в каждой строке
// min - минимальный элемент в каждой  строке
// sum - сумма всех элементов для каждой строки


namespace Task1_StringArray;

using static System.Console;

internal class StringArray
{
    static void Main(string[] args)
    {
        string? chosenOption = null;
        List<string> stringList = new();
        List<List<int>> doubleList = new();
        List<int>? resList;

        while (chosenOption != "/stop")
        {
            WriteColor("Введите команду -> ", "Yellow", false);
            chosenOption = ReadLine();

            if (chosenOption == null)
            {
                WriteColor("Введена пустая строка", "Red", true);
                continue;
            }

            switch(chosenOption)
            {
                case "set": // задать двумерный массив
                    WriteColor("Введите строки массива:", "Blue", true);
                    if (GetInput(out stringList) == 0 && ConvertToArray(stringList, out doubleList) == 0)
                    {
                        WriteColor("Массив успешно задан", "Green", true);
                    }
                    else
                    {
                        WriteColor("Задан пустой массив", "Red", true);
                    }
                    break;
                case "print":
                    // если массив пуст
                    if (stringList.Count == 0)
                    {
                        WriteColor("Массив пуст", "Red", true);
                        break;
                    }

                    Print(doubleList);
                    break;
                case "max": // найти максимум каждой строки массива
                    // если массив пуст
                    if (stringList.Count == 0)
                    {
                        WriteColor("Массив пуст", "Red", true);
                        break;
                    }

                    if (FindMax(doubleList, out resList) == 0)
                    {
                        WriteColor("Максимальные элементы в каждой строке:", "Blue", true);
                        Print(resList);
                        WriteColor("Максимальные элементы успешно найдены", "Green", true);
                    }
                    else
                    {
                        WriteColor("Ошибка при выполнении функции", "Red", true);
                    }
                    break;
                    case "min": // найти минимум каждой строки массива
                    // если массив пуст
                    if (stringList.Count == 0)
                    {
                        WriteColor("Массив пуст", "Red", true);
                        break;
                    }

                    if (FindMin(doubleList, out resList) == 0)
                    {
                        WriteColor("Минимальные элементы в каждой строке:", "Blue", true);
                        Print(resList);
                        WriteColor("Минимальные элементы успешно найдены", "Green", true);
                    }
                    else
                    {
                        WriteColor("Ошибка при выполнении функции", "Red", true);
                    }
                    break;
                case "sum": // найти сумму всех элементов каждой строки массива
                    // если массив пуст
                    if (stringList.Count == 0)
                    {
                        WriteColor("Массив пуст", "Red", true);
                        break;
                    }

                    if (FindSum(doubleList, out resList) == 0)
                    {
                        WriteColor("Сумма элементов в каждой строке:", "Blue", true);
                        Print(resList);
                        WriteColor("Суммы элементов успешно найдены", "Green", true);
                    }
                    else
                    {
                        WriteColor("Ошибка при выполнении функции", "Red", true);
                    }
                    break;
                case "/stop": // завершить работу программы
                    break;
                default: // все остальные случаи
                    WriteColor("Неизвестная команда", "Red", true);
                    break;
            }
        }
    }

    /// <summary>
    /// Считать массив строк, вводимый пользователем.
    /// </summary>
    /// <param name="list">Возвращаемый список со строками.</param>
    /// <returns>-1, если пользователь не ввёл ни одной строки;<br/>
    /// 0, в противном случае.</returns>
    static int GetInput(out List<string> list)
    {
        string? userInput = "";
        list = new();

        // пока пользователь не введёт пустую строку
        while (userInput != null)
        {
            userInput = ReadLine();

            if (userInput != null)
            {
                list.Add(userInput);
            }
        }

        // если не было введено ни одного значения
        if (list.Count == 0)
        {
            return -1;
        }

        // если была считана хотя бы одна строка
        return 0;
    }

    /// <summary>
    /// Превращение исходного массива строк в двумерный массив чисел.
    /// </summary>
    /// <param name="originalList">Исходный список строк.</param>
    /// <param name="list">Получаемый двумерный список чисел.</param>
    /// <returns></returns>
    static int ConvertToArray(in List<string> originalList, out List<List<int>> list)
    {
        list = new();
        string tmpStr;
        string elem;
        int tmpNum;
        int fstIndex = 0;
        int sndIndex = 0;

        // если передан пустой список
        if (originalList == null || originalList.Count == 0)
        {
            return -1;
        }

        for (int index = 0; index < originalList.Count; index++)
        {
            tmpStr = originalList[index];
            list.Add(new List<int>());

            // пока есть строки в исходном списке
            while (fstIndex < originalList[index].Length)
            {
                // пока не встречен символ
                while (fstIndex < originalList[index].Length 
                    && ((originalList[index])[fstIndex] == ' '))
                {
                    fstIndex += 1;
                }
                sndIndex = fstIndex;

                // пока встречаются символы
                while (sndIndex < originalList[index].Length 
                    && (originalList[index])[sndIndex] != ' ')
                {
                    sndIndex += 1;
                }

                // переписать число в список (либо ноль, если это не число)
                elem = tmpStr.Substring(fstIndex, sndIndex - fstIndex);
                list[index].Add((int.TryParse(elem, out tmpNum) ? tmpNum : 0));

                fstIndex = sndIndex;
            }

            fstIndex = 0;
            sndIndex = 0;
        }
        
        return 0;
    }

    /// <summary>
    /// Печать двумерного списка чисел на консоль.
    /// </summary>
    /// <param name="list">Двумерный список для печати.</param>
    /// <returns>-1, если список пуст;<br/>
    /// 0, в противном случае.</returns>
    static int Print(in List<List<int>>? list)
    {
        if (list == null || list.Count == 0)
        {
            return -1;
        }

        foreach (var subList in list)
        {
            if (Print(subList) == -1)
            {
                return -1;
            }
        }

        return 0;
    }

    /// <summary>
    /// Печать списка чисел на консоль.
    /// </summary>
    /// <param name="list">Список для печати.</param>
    /// <returns>-1, если список пуст;<br/>
    /// 0, в противном случае.</returns>
    static int Print(in List<int>? list)
    {
        if (list == null || list.Count == 0)
        {
            return -1;
        }

        foreach (var item in list)
        {
            Write($"{item,-5}");
        }
        WriteLine();

        return 0;
    }

    /// <summary>
    /// Нахождение максимума для каждой строки.
    /// </summary>
    /// <param name="list">Двумерный список, в котором осуществляется поиск.</param>
    /// <param name="max">Список максимальных значений в каждой строке.</param>
    /// <returns>-1, если указатель на список null или список пуст;<br/>
    /// 0, в противном случае.</returns>
    static int FindMax(in List<List<int>> list, out List<int>? max)
    {
        if (list == null || list.Count == 0)
        {
            max = null;
            return -1;
        }

        max = new();

        foreach(var subList in list)
        {
            max.Add(subList.Max());
        }

        return 0;
    }

    /// <summary>
    /// Нахождение минимума для каждой строки.
    /// </summary>
    /// <param name="list">Двумерный список, в котором осуществляется поиск.</param>
    /// <param name="max">Список минимальных значений в каждой строке.</param>
    /// <returns>-1, если указатель на список null или список пуст;<br/>
    /// 0, в противном случае.</returns>
    static int FindMin(in List<List<int>> list, out List<int>? min)
    {
        if (list == null || list.Count == 0)
        {
            min = null;
            return -1;
        }

        min = new();

        foreach (var subList in list)
        {
            min.Add(subList.Min());
        }

        return 0;
    }

    /// <summary>
    /// Нахождение суммы элементов каждой строки.
    /// </summary>
    /// <param name="list">Двумерный список, в котором складываются элементы строк.</param>
    /// <param name="max">Список сумм элементов каждой строки.</param>
    /// <returns>-1, если указатель на список null или список пуст;<br/>
    /// 0, в противном случае.</returns>
    static int FindSum(in  List<List<int>> list, out List<int>? sum)
    {
        if (list == null || list.Count == 0)
        {
            sum = null;
            return -1;
        }

        sum = new();

        foreach(var subList in list)
        {
            sum.Add(subList.Sum());
        }

        return 0;
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