using System;
using LabWork2;

namespace testNetLinux
{
    internal class Program
    {

        static void Main(string[] args)
        {
            Console.WriteLine("Робота виконана студенткою Волкович А.В. 41КН");
            Console.WriteLine("Enter a number:");
            double someNumber = WindowsClass. inputValidator();
            Console.WriteLine("Entered number is " + someNumber);
            Console.WriteLine("Also our magic number from dll is " + 
            WindowsClass.testData);
        }
    }
}