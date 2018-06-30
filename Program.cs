using System;

namespace operatorPractice
{
    class Program
    {
        public static void Main(string[] args)
        {
            Point ptOne = new Point(100, 100);
            Point ptTwo = new Point(40, 40);
            Point ptThree = new Point(90, 5);
            Console.WriteLine($"ptOne = {ptOne}");
            Console.WriteLine($"ptTwo = {ptTwo}");

            Console.WriteLine($"ptOne + ptTwo: {ptOne + ptTwo}");
            Console.WriteLine($"ptOne + ptTwo: {ptOne - ptTwo}");
            Console.WriteLine($"ptOne + 20: {ptOne + 20}");
            Console.WriteLine($"20 + ptTwo: {20 + ptTwo}");

            // you don't have to add operator for += -= 
            Console.WriteLine($"ptThree : {ptThree}");
            Console.WriteLine($"ptThree - 20: {ptThree -= 20}");

            Console.WriteLine($"ptThree++: {ptThree++}");
            Console.WriteLine($"ptThree--: {ptThree--}");

            Console.WriteLine($"ptOne == ptTwo: {ptOne == ptTwo}");
            Console.WriteLine($"ptOne != ptTwo: {ptOne != ptTwo}");

            Console.WriteLine($"ptOne < ptTwo : {ptOne < ptTwo}");
            Console.WriteLine($"ptOne > ptTwo : {ptOne > ptTwo}");

            Console.ReadLine();
        }
    }

    public class Point : IComparable<Point>
    {
        // Overload operator +
        public static Point operator + (Point p1, Point p2) => new Point(p1.X + p2.X, p1.Y + p2.Y);

        public static Point operator + (int change, Point p1) => new Point(p1.X + change, p1.Y + change);
        public static Point operator + (Point p1, int change) => new Point(p1.X + change, p1.Y + change);

        public static Point operator - (int change, Point p1) => new Point(p1.X - change, p1.Y - change);
        public static Point operator - (Point p1, int change) => new Point(p1.X - change, p1.Y - change);


        // Add 1 to the X/Y values for the incoming Point
        public static Point operator ++(Point p1) => new Point(p1.X+1, p1.Y+1);
        // Subtract 1 to the X/Y values for the incoming Point
        public static Point operator --(Point p1) => new Point(p1.X-1, p1.Y-1);

        public static Point operator - (Point p1, Point p2) => new Point(p1.X - p2.X, p1.Y - p2.Y);



        public static bool operator <(Point p1, Point p2) => p1.CompareTo(p2) < 0;
        public static bool operator >(Point p1, Point p2) => p1.CompareTo(p2) > 0;


        public static bool operator <=(Point p1, Point p2) => p1.CompareTo(p2) <= 0;
        public static bool operator >=(Point p1, Point p2) => p1.CompareTo(p2) >= 0;


        public override bool Equals(object obj) => obj.ToString() == this.ToString();
        public override int GetHashCode() => this.ToString().GetHashCode();

        // == and != needs to be declared at same time.
        public static bool operator ==(Point p1, Point p2) => p1.Equals(p2);
        public static bool operator !=(Point p1, Point p2) => !p1.Equals(p2);



        public int X {get; set;}
        public int Y {get; set;}

        public Point(int xPos, int yPos)
        {
            X = xPos;
            Y = yPos;
        }
        public override string ToString() => $"[{this.X}, {this.Y}]";

        public int CompareTo(Point other)
        {
            if (this.X > other.X && this.Y > other.Y)
                return 1;
            if (this.X < other.X && this.Y < other.Y)
                return -1;
            else
                return 0;
        }
    }
}



