using System;

namespace PointApp
{
    internal class Point
    {
        private double _x;
        private double _y;

        public Point(double x, double y)
        {
            _x = x;
            _y = y;
        }

        public double GetX() => _x;
        public double GetY() => _y;

        public Point IncrementX() => new Point(_x + 1, _y);
        public Point DecrementX() => new Point(_x - 1, _y);

        public double DistanceTo(Point other)
        {
            double dx = _x - other._x;
            double dy = _y - other._y;
            return Math.Sqrt(dx * dx + dy * dy);
        }

        public static Point operator ++(Point p) => p.IncrementX();
        public static Point operator --(Point p) => p.DecrementX();

        public static explicit operator int(Point p) => (int)p._x;
        public static implicit operator double(Point p) => p._y;

        public static double operator +(Point a, Point b) => a.DistanceTo(b);

        public static Point operator +(Point p, int value) => new Point(p._x + value, p._y);
        public static Point operator +(int value, Point p) => new Point(p._x + value, p._y);

        public static Point operator -(Point p, int value) => new Point(p._x - value, p._y);
        public static Point operator -(int value, Point p) => new Point(p._x - value, p._y);

        public override string ToString() => $"(X: {_x:F2}, Y: {_y:F2})";
    }
}