using System.Diagnostics;

[assembly: CLSCompliant(true)] // Перевірка на відповідність CLS
namespace LabWork4
{
    class Program
    {
        private static IEnumerable<BusStop> _stops1 = [
            new ("Червона", "Кольоровий Ланцюг", true, 100),
            new ("Синя", "Кольоровий Ланцюг", false, 55),
            new ("Гор", "Трав'яний", false, 130),
            new ("Бор", "Трав'яний", true, 65),
            new ("Жовта", "Кольоровий Ланцюг", true, 200),
        ];

        private static IEnumerable<BusStop> _stops2 = [
            new("Центральний вокзал", "Кільцевий", true, 150),
            new ("Університет", "Кільцевий", true, 205),
            new ("Медичний центр", "Трав'яний", true, 49),
            new ("Торгівельний центр", "Західний Експрес", true, 15),
            new ("Залізничний міст", "Західний Експрес", false, 178),
            _stops1.ElementAt(2),
            _stops1.ElementAt(2),
            new("Парк Культури", "Трав'яний", true, 104),
            ];

        private static void Out<T>(IEnumerable<T> sequence) {
            if (sequence != null)
                foreach (var elem in sequence) Console.WriteLine($"{elem}\n");
        }


        private static void WhereActive(){ // 6.1
            var activeStops = _stops1.Where(stop => stop.IsActive);
            Console.WriteLine("\nАктивні зупинки зі списку:");
            Out(activeStops);
        }

        private static void IntersectOnID(){ // 6.2
            _stops2.ElementAt(1).ID = _stops1.First().ID; // та ці методи також
            var intersectedStops = _stops1.Intersect(_stops2);

            Console.WriteLine("\nСписок I:");
            Out(_stops1);

            Console.WriteLine("\nСписок II:");
            Out(_stops2);

            Console.WriteLine("\nЗупинки, мають однаковий ID у обоих списках:");
            Out(intersectedStops);

        }

        private static void TakeWhileJule(){ // 6.3
            var stopsWhileJule = _stops2.TakeWhile(stop => stop.AddingDate.Month != 7);

            Console.WriteLine("\nУвесь список II:");
            Out(_stops2);

            Console.WriteLine("\nЗупинки з початку списку, поки місяць додавання не є липнем:");
            Out(stopsWhileJule);

        }

        private static void AppendSingleLast(){ // 7.1
            Console.WriteLine("\nОстання зупинка зі списку I до змін: \n" + $"{_stops1.Last()}");
            _stops1 = _stops1.Append( _stops2.Single(stop => stop.Name == "Університет"));
            Console.WriteLine("\nОстання зупинка після додавання через Append (та Single):\n" + $"{_stops1.Last()}");
        }

        private static void OrderAndThen(){ // 7.2
            var sortedStops = _stops2.OrderBy(stop => stop.BusRoute) 
                                     .ThenByDescending(stop => stop.AddingDate);

            Console.WriteLine("\nСписок II до сортування");
            Out(_stops2);
            Console.WriteLine("\nСписок II після сортування:");
            Out(sortedStops);
        }

        private static void ConcatAndReverse(){ // 7.3
            var unitedAndReversed = _stops1.Concat(_stops2).Reverse();
            Console.WriteLine("Отриманий список: ");
            Out(unitedAndReversed);
        }

        private static void AggregateColorsAmount(){ // 8.1
            int stopsCount = _stops1.Aggregate(0, (count, stop) =>
            {
                if (stop.BusRoute == "Кольоровий Ланцюг") count++;
                return count;
            });
            Console.WriteLine($"\nКількість зупинок (список I) з маршруту \"Кольоровий Ланцюг\": {stopsCount}");
        }

        private static void AverageCost(){ // 8.2
            double averageCost = _stops2.Average(stop => stop.Cost);
            Console.WriteLine($"\nСередня вартість (список II): {averageCost:F2}$");
        }

        private static void ParallelWork(){ // 9
            Random rnd = new();

            Console.WriteLine("\nСписок II після роботи методу:");
            _stops2.AsParallel().ForAll(stop =>
            {
                stop.Cost = rnd.Next(10, 301);
                Console.WriteLine($"\n{stop}\nThread під номером {Environment.CurrentManagedThreadId}");
            });
        }

    
        enum MenuOptions : byte {
            WhereActive = 1,
            IntersectOnID,
            TakeWhileJule,
            AppendSingleLast,
            OrderAndThen,
            ConcatAndReverse,
            AggregateColorsAmount,
            AverageCost,
            ParallelWork,
            Exit,
        }

        static void Menu()
        {
            Console.WriteLine("Оберіть пункт меню:" +
                "\n1) Показати лише активні зупинки з першої колекції [Where];" +
                "\n2) Залишити тільки зупинки, які є (мають однаковий ID) у обоих списках [Intersect];" +
                "\n3) Відображати зупинки до моменту першої з датою створення у липні [TakeWhile];" +
                "\n4) Додати у кінець списку зупинку з назвою \"Університет\" [Append & Single];" +
                "\n5) Відсортувати зупинки по маршрутам (за зростанням), а потім по датам створення (за спаданням) [OrderBy & ThenByDescending];" +
                "\n6) Об'єднати два списка та розвернути результат [Concat & Reverse];" +
                "\n7) Порахувати кількість зупинок з маршруту \"Кольоровий Ланцюг\" [Aggregate];" +
                "\n8) Знайти середню суму вартості зупинок [Average];" +
                "\n9) Змінити вартість зупинок на рандомне значення через багатопоточність [AsParallel & ForAll];" +

                "\n10) Завершити роботу;");

            byte menuOption;
            while (!byte.TryParse(Console.ReadLine(), out menuOption)) {
                Console.WriteLine("Введено неправильні дані, перевірте та спробуйте знову");
            }
            MenuOptions selectedOption = (MenuOptions)menuOption;

            switch (selectedOption)
            {
                case MenuOptions.WhereActive:
                    WhereActive(); break;

                case MenuOptions.IntersectOnID:
                    IntersectOnID(); break;

                case MenuOptions.TakeWhileJule:
                    TakeWhileJule(); break;

                case MenuOptions.AppendSingleLast:
                    AppendSingleLast(); break;

                case MenuOptions.OrderAndThen:
                    OrderAndThen(); break;

                case MenuOptions.ConcatAndReverse:
                    ConcatAndReverse(); break;

                case MenuOptions.AggregateColorsAmount:
                    AggregateColorsAmount(); break;

                case MenuOptions.AverageCost:
                    AverageCost(); break;

                case MenuOptions.ParallelWork:
                    ParallelWork(); break;

                case MenuOptions.Exit:
                    Environment.Exit(0); break;

                default: break;
            }
        }


        static void Main(string[] args)
        {
            // Підтримка кириличних символів
            Console.OutputEncoding = System.Text.Encoding.Unicode;
            Console.InputEncoding = System.Text.Encoding.Unicode;
            Menu();
            while (true) {
                Console.WriteLine("\n");
                Menu();
            }
        }
    }
}
