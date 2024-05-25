using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace Лаба_6
{
    internal class Program
    {
        static double InputDoubleElement() // проверка на число (тип double)
        {
            bool isCorrert;
            double number;
            do
            {
                isCorrert = double.TryParse(Console.ReadLine(), out number);
                if (!isCorrert) Console.WriteLine("Пожалуйста, введите целое число");
            } while (!isCorrert);
            return number;
        }
        static int InputIntNumber() // проверка на целое число
        {
            bool isCorrert;
            int number;
            do
            {
                isCorrert = int.TryParse(Console.ReadLine(), out number);
                if (!isCorrert) Console.WriteLine("Пожалуйста, введите целое число");
            } while (!isCorrert);
            return number;
        }
        static void CreateMatr(ref double[,] matr) //создание двумерного массива вручную
        {
            int str = 0;
            int col = 0;
            do
            {
                Console.WriteLine("Введите количество строк");
                str = InputIntNumber();
            } while (str < 0);
            do
            {
                Console.WriteLine("Введите количество столбцов");
                col = InputIntNumber();
            } while (col < 0);
            matr = new double[str, col];
            for (int i = 0; i < str; i++)
            {
                for (int j = 0; j < col; j++)
                {
                    Console.WriteLine($"Введите элемент массива под номером: ({i + 1}; {j + 1})");
                    matr[i, j] = InputDoubleElement();
                }
            }
            Console.WriteLine("Массив сформирован");
        }
        static void CreateMatrRnd(ref double[,] matr) //создание двумерного массива с помощью ДСЧ
        {
            int str = 0;
            int col = 0;
            do
            {
                Console.WriteLine("Введите количество строк");
                str = InputIntNumber();
            } while (str < 0);
            do
            {
                Console.WriteLine("Введите количество столбцов");
                col = InputIntNumber();
            } while (col < 0);
            matr = new double[str, col];
            Random rnd = new Random();
            for (int i = 0; i < str; i++)
            {
                for (int j = 0; j < col; j++)
                {
                    matr[i, j] = rnd.Next(-10, 10);
                }
            }
            Console.WriteLine("Массив сформирован");
        }
        static void PrintMatr(double[,] matr) // печать двумерного массива
        {
            if (IsEmptyMatr(matr)) Console.WriteLine("Массив пуст");
            else
            {
                Console.WriteLine("Ваш массив:");
                for (int i = 0; i < matr.GetLength(0); i++)
                {
                    for (int j = 0; j < matr.GetLength(1); j++)
                    {
                        Console.Write(matr[i, j] + " ");
                    }
                    Console.WriteLine();
                }
            }
        }
        static bool IsEmptyMatr(double[,] matr) // проверка длины двумерного массива 
        {
            if (matr == null || matr.Length == 0) return true;
            else return false;
        }
        static void Commands1() // пункты меню 1.
        {
            Console.WriteLine("1) Действие с двумерным массивом.");
            Console.WriteLine("2) Действие со строкой.");
            Console.WriteLine("3) Выход");
        }
        static void Commands2() //пункты меню 1.1.
        {
            Console.WriteLine("1) Создать двумерный массив вручную");
            Console.WriteLine("2) Создать двумерный массив при помощи ДСЧ");
            Console.WriteLine("3) Напечатать двумерный массив");
            Console.WriteLine("4) Удалить из двумерного массива первую строку, в которой есть хотя бы один элемент равный 0");
            Console.WriteLine("5) Назад");
        }
        static void Commands3() //пункты меню 1.2.
        {
            Console.WriteLine("1) Ввести текст вручную");
            Console.WriteLine("2) Сгенерировать строку из массива заранее сформированных тестовых строк");
            Console.WriteLine("3) Напечатать текст");
            Console.WriteLine("4) Перевернуть каждое четное слово");
            Console.WriteLine("5) Назад");
        }
        static void DeleteFirstStrWith0(ref double[,] matr) //удаление первой строки с 0
        {
            int ind = -1;
            for (int i = 0; i < matr.GetLength(0); i++)
            {
                for (int j = 0; j < matr.GetLength(1); j++)
                {
                    if (matr[i, j] == 0 && ind == -1)
                    {
                        ind = i;
                    }
                }
            }
            if (ind != -1)
            {
                double[,] temp = new double[matr.GetLength(0) - 1, matr.GetLength(1)];
                for (int i = 0; i < matr.GetLength(0); i++)
                {
                    for(int j = 0; j < temp.GetLength(1); j++)
                    {
                        if (i < ind)
                        {
                            temp[i,j] = matr[i, j];
                        }
                        else if (i > ind)
                        {
                            temp[i-1,j] = matr[i, j];
                        }
                    }
                }
                matr = temp;
                Console.WriteLine("Первая строка с 0 удалена.");
            }
            else Console.WriteLine("В двумерном массиве нет строки с 0");
        }
        static string InputStr(ref string str) // ввод строки
        {
            Console.WriteLine("Напишите ниже свой текст:");
            str = Console.ReadLine().ToString();
            Console.WriteLine("Текст введён");
            return str;
        }
        static string InputStrRnd(ref string str) // генерация случайной строки из имеющихся
        {
            string[] strRnd = { "Следует отметить, что глубокий уровень погружения напрямую зависит от инновационных методов управления процессами. Лишь активно развивающиеся страны третьего мира, которые представляют собой яркий пример континентально - европейского типа политической культуры, будут объявлены нарушающими общечеловеческие нормы этики и морали.", "А также независимые государства представляют собой не что иное, как квинтэссенцию победы маркетинга над разумом и должны быть преданы социально - демократической анафеме.", "Внезапно, независимые государства представляют собой не что иное, как квинтэссенцию победы маркетинга над разумом и должны быть разоблачены.", "Ясность нашей позиции очевидна: высокое качество позиционных исследований напрямую зависит от поставленных обществом задач." };
            Random rnd = new Random();
            str = strRnd[rnd.Next(strRnd.Length)];
            Console.WriteLine("Выбран случайный текст из имеющегося списка");
            return str;
        }
        static void ReverseEvenWord(ref string str) // переворот каждого чётного слова
        {
            if (string.IsNullOrWhiteSpace(str) == true) Console.WriteLine("Текста нет(");
            else
            {
                str = str.Trim(); //убрать пробелы в начале и в конце предложения, если они есть
                string[] sent = str.Split(' ');
                for (int i = 0; i < sent.Length; i++)
                {
                    if (i % 2 == 1)  
                    {
                        string t = sent[i];
                        char[] chars = t.ToCharArray();
                        if (t.All(c => char.IsLetterOrDigit(c))) // проверка последнего символа слова
                        {
                            Array.Reverse(chars);
                            sent[i] = new string(chars);
                        }
                        else
                        {
                            string sign = t[t.Length - 1].ToString(); // сохранение символа, если он есть, в отдельную переменную
                            t = t.Substring(0, t.Length - 1);
                            chars = t.ToCharArray();
                            Array.Reverse(chars);
                            sent[i] = new string(chars) + sign;
                        }
                    }
                }
                string msg = ""; // восстанавливаем строку из массива 
                for(int i = 0; i < sent.Length; i++)
                {
                    msg += sent[i] + " "; 
                }
                str = msg;
                Console.WriteLine("Чётные слова перевёрнуты");
            }
        }
        static void PrintStr(ref string str) //печать строки
        {
            if (string.IsNullOrWhiteSpace(str) == true) Console.WriteLine("Текста нет(");
            else
            {
                Console.WriteLine("Ваш текст:");
                Console.WriteLine(str);
            }
        }
        static void Main(string[] args)
        {
            int ans = 0;
            do
            {
                Commands1();
                ans = InputIntNumber();
                switch (ans)
                {
                    case 1:
                        {
                            double[,] matr = new double[0, 0];
                            do
                            {
                                Commands2();
                                ans = InputIntNumber();
                                switch (ans)
                                {
                                    case 1:
                                        {
                                            CreateMatr(ref matr);
                                            break;
                                        }
                                    case 2:
                                        {
                                            CreateMatrRnd(ref matr);
                                            break;
                                        }
                                    case 3:
                                        {
                                            PrintMatr(matr);
                                            break;
                                        }
                                    case 4:
                                        {
                                            DeleteFirstStrWith0(ref matr);
                                            break;
                                        }
                                }
                            } while (ans != 5);
                            break;
                        }
                    case 2:
                        {
                            string str = "";
                            do
                            {
                                Commands3();
                                ans = InputIntNumber();
                                switch (ans)
                                {
                                    case 1:
                                        {
                                            InputStr(ref str);
                                            break;
                                        }
                                    case 2:
                                        {
                                            InputStrRnd(ref str);
                                            break;
                                        }
                                    case 3:
                                        {
                                            PrintStr(ref str); 
                                            break;
                                        }
                                    case 4:
                                        {
                                            ReverseEvenWord(ref str);
                                            break;
                                        }
                                }
                            } while (ans != 5);
                            break;
                        }
                }
            } while (ans !=3); 
        }
    }
}
