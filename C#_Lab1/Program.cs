using System;

class Program
{
    static void Main()
    {
        //Последнее введенное значение
        double currentValue = 0;
        //Предыдущее введенное значение
        double lastValue = 0;
        //Вводимый оператор
        char operation = ' ';
        //Переменная обозначающая ввод нового числа или оператора
        bool isNewInput = true;

        Console.WriteLine("=======Калькулятор=======");

        while (true)
        {
            //Console.SetCursorPosition(0, 2);
            Console.Write($"Текущая сумма: {currentValue} ");
            Console.WriteLine("\nВведите число или операцию:");

            ConsoleKeyInfo keyInfo = Console.ReadKey(true);
            char input = keyInfo.KeyChar;

            //Ввод числа
            if (char.IsDigit(input))
            {
                int digit = input - '0';
                if (isNewInput)
                {
                    currentValue = digit;
                    isNewInput = false;
                }
                else
                {
                    currentValue = currentValue * 10 + digit;
                }
            }
            //Очищение калькулятора
            else if (input == 'C')
            {
                currentValue = 0;
                lastValue = 0;
                operation = ' ';
                isNewInput = true;
            }
            //Ввод оператора
            else if (input == '+' || input == '-' || input == '*' || input == '/')
            {
                if (operation != ' ')
                {
                    Calculate(ref lastValue, ref currentValue, operation);
                }
                lastValue = currentValue;
                operation = input;
                currentValue = 0;
                isNewInput = true;
            }
            // Выполнение опрации
            else if (input == '=')
            {
                Calculate(ref lastValue, ref currentValue, operation);
                operation = ' ';
                isNewInput = true;
            }

            Console.Clear();
        }
    }

    static void Calculate(ref double lastValue, ref double currentValue, char operation)
    {
        /*
        Основная логика калькулятора
        */
        switch (operation)
        {
            case '+':
                currentValue = lastValue + currentValue;
                break;
            case '-':
                currentValue = lastValue - currentValue;
                break;
            case '*':
                currentValue = lastValue * currentValue;
                break;
            case '/':
                if (currentValue != 0)
                {
                    currentValue = lastValue / currentValue;
                }
                else
                {
                    Console.WriteLine("Ошибка: деление на ноль!");
                }
                break;
        }
    }
}
