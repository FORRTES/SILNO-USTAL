using System;

namespace PointApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Point Operations Tool");
            Console.WriteLine("Enter point coordinates (X Y), or 'q' to quit.");
            Console.WriteLine("X and Y should be decimal numbers.");

            Point? currentPoint = null;

            while (true)
            {
                Console.Write("\nEnter coordinates (double X, double Y): ");
                string? input = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(input))
                {
                    Console.WriteLine("Input is empty. Try again.");
                    continue;
                }

                if (input.Trim().ToLower() == "q")
                {
                    Console.WriteLine("Exiting program...");
                    break;
                }

                string[] parts = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                if (parts.Length != 2)
                {
                    Console.WriteLine("You must enter exactly two values: X and Y.");
                    continue;
                }

                if (!double.TryParse(parts[0], out double x))
                {
                    Console.WriteLine("X must be a decimal number.");
                    continue;
                }

                if (!double.TryParse(parts[1], out double y))
                {
                    Console.WriteLine("Y must be a decimal number.");
                    continue;
                }

                currentPoint = new Point(x, y);
                Console.WriteLine($"\nCreated point: {currentPoint}");

                ShowOperations(currentPoint);

                Console.Write("\nAnalyze another point? (y/n): ");
                string? again = Console.ReadLine()?.Trim().ToLower();
                if (again != "y" && again != "yes")
                {
                    Console.WriteLine("Goodbye!");
                    break;
                }
            }

            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }

        static void ShowOperations(Point point)
        {
            Console.WriteLine("\nAvailable operations:");
            Console.WriteLine("1. Increment X (++)");
            Console.WriteLine("2. Decrement X (--)");
            Console.WriteLine("3. Cast to int (integer part of X)");
            Console.WriteLine("4. Cast to double (Y coordinate)");
            Console.WriteLine("5. Distance to another point");
            Console.WriteLine("6. Add integer to X (point + int)");
            Console.WriteLine("7. Subtract integer from X (point - int)");
            Console.Write("Select operation (1–7): ");

            string? choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    Console.WriteLine($"Result: {++point}");
                    break;

                case "2":
                    Console.WriteLine($"Result: {--point}");
                    break;

                case "3":
                    Console.WriteLine($"(int) point → {(int)point}");
                    break;

                case "4":
                    double y = point;
                    Console.WriteLine($"(double) point → {y}");
                    break;

                case "5":
                    Console.Write("Enter second point (X Y): ");
                    string? second = Console.ReadLine();
                    if (string.IsNullOrWhiteSpace(second)) break;

                    string[] coords = second.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                    if (coords.Length != 2 ||
                        !double.TryParse(coords[0], out double x2) ||
                        !double.TryParse(coords[1], out double y2))
                    {
                        Console.WriteLine("Invalid input.");
                        break;
                    }

                    var other = new Point(x2, y2);
                    double distance = point + other;
                    Console.WriteLine($"Distance: {distance:F2}");
                    break;

                case "6":
                    Console.Write("Enter integer to add to X: ");
                    string? add = Console.ReadLine();
                    if (!int.TryParse(add, out int valAdd))
                    {
                        Console.WriteLine("Must be an integer.");
                        break;
                    }
                    Console.WriteLine($"Result: {point + valAdd}");
                    break;

                case "7":
                    Console.Write("Enter integer to subtract from X: ");
                    string? sub = Console.ReadLine();
                    if (!int.TryParse(sub, out int valSub))
                    {
                        Console.WriteLine("Must be an integer.");
                        break;
                    }
                    Console.WriteLine($"Result: {point - valSub}");
                    break;

                default:
                    Console.WriteLine("Invalid operation.");
                    break;
            }
        }
    }
}