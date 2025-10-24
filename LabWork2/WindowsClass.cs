using System;

namespace LabWork2
{
    public class WindowsClass
    {
        static public int testData = 18;

        static public double inputValidator()
        {
            string input;
            double validInput = 0;
            bool verified = false;

            while (!verified)
            {
                input = Console.ReadLine();
                verified = Double.TryParse(input, out validInput);
                if (!verified) Console.WriteLine("Данi введено неправильно, спробуйте ще раз.");
            }

            return validInput;
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Робота виконана студенткою Волкович А.В. 41КН");
            double side1, side2, side3, height, perimeter, area, apothem, radius, result;

            Console.WriteLine("Оберiть пункт меню для обчислення: " +
                "\n 1) Площi паралелограма [a * h]; " +
                "\n 2) Площi трикутника за формулою Герона [(a + b + c) / 2];" +
                "\n 3) Площi бiчної поверхнi пiрамiди [1/2 * P * l]; " +
                "\n 4) Об'єм пiрамiди [1/3 * S * h];" +
                "\n 5) Об'єм сфери [4/3 * pi * r^3].");

            double select = inputValidator();
            switch (select)
            {
                case 1:
                    Console.WriteLine("Введiть значення сторони a:");
                    side1 = inputValidator();

                    Console.WriteLine("Введiть значення висоти h:");
                    height = inputValidator();

                    result = side1 * height;
                    Console.WriteLine("Площа заданного паралелограма дорiвнює " + result);
                    break;

                case 2:
                    Console.WriteLine("Введiть значення сторони a:");
                    side1 = inputValidator();

                    Console.WriteLine("Введiть значення сторони b:");
                    side2 = inputValidator();

                    Console.WriteLine("Введiть значення сторони c:");
                    side3 = inputValidator();

                    result = (side1 + side2 + side3) / 2;
                    Console.WriteLine("Площа заданного трикутника дорiвнює " + result);
                    break;

                case 3:
                    Console.WriteLine("Введiть значення периметру основи P:");
                    perimeter = inputValidator();

                    Console.WriteLine("Введiть значення апофеми l:");
                    apothem = inputValidator();

                    result = 0.5 * perimeter * apothem;
                    Console.WriteLine("Площа бiчної поверхнi заданої пiрамiди дорiвнює " + result);
                    break;

                case 4:
                    Console.WriteLine("Введiть значення площi основи S:");
                    area = inputValidator();

                    Console.WriteLine("Введiть значення висоти h:");
                    height = inputValidator();


                    result = 1.0 / 3.0 * area * height;
                    Console.WriteLine("Об'єм заданої пiрамiди дорiвнює " + result);
                    break;

                case 5:
                    Console.WriteLine("Введiть значення радiусу r:");
                    radius = inputValidator();

                    result = (4.0 / 3.0) * Math.PI * Math.Pow(radius, 3);
                    Console.WriteLine("Об'єм заданої сфери дорiвнює " + result);
                    break;

                default:
                    Console.WriteLine("Невiдоме значення, програма завершує роботу.");
                    return;
            }
        }
    }
}
