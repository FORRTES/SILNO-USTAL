using System;

namespace PointApp
{
    internal class Point
    {
        private double _x;
        private double _y;

        // Конструктор инициализирует координаты точки
        public Point(double x, double y)
        {
            _x = x;
            _y = y;
        }

        public double GetX() => _x;

        public double GetY() => _y;

        // Метод увеличивает X на 1 и возвращает новую точку
        public Point IncrementX() => new Point(_x + 1, _y);

        // Метод уменьшает X на 1 и возвращает новую точку
        public Point DecrementX() => new Point(_x - 1, _y);

        // Метод вычисляет расстояние между текущей точкой и другой
        public double DistanceTo(Point other)
        {
            double dx = _x - other._x;
            double dy = _y - other._y;
            return Math.Sqrt(dx * dx + dy * dy);
        }

        // Перегрузка оператора ++
        public static Point operator ++(Point p) => p.IncrementX();

        // Перегрузка оператора --
        public static Point operator --(Point p) => p.DecrementX();

        // Явное приведение Point → int (целая часть X)
        public static explicit operator int(Point p) => (int)p._x;

        // Неявное приведение Point → double (значение Y)
        public static implicit operator double(Point p) => p._y;

        // Перегрузка + для двух точек — возвращает расстояние между ними
        public static double operator +(Point a, Point b) => a.DistanceTo(b);

        // Перегрузка + для точки и целого числа (X + value)
        public static Point operator +(Point p, int value) => new Point(p._x + value, p._y);
        public static Point operator +(int value, Point p) => new Point(p._x + value, p._y);

        // Перегрузка - для точки и целого числа (X - value)
        public static Point operator -(Point p, int value) => new Point(p._x - value, p._y);
        public static Point operator -(int value, Point p) => new Point(p._x - value, p._y);

        // Удобный вывод координат точки с двумя знаками после запятой
        public override string ToString() => $"(X: {_x:F2}, Y: {_y:F2})";
    }
}
