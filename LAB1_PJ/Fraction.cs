namespace Lab1NS
{
    public class Fraction : IComparable<Fraction>, IEquatable<Fraction>
    {
        private int numerator { get; }
        private int denominator { get; }

        public Fraction()
        {
            this.numerator = 1;
            this.denominator = 2;
        }

        public Fraction(int numerator, int denominator)
        {
            this.numerator = numerator;
            this.denominator = denominator;
        }

        public Fraction(Fraction value)
        {
            this.numerator = value.numerator;
            this.denominator = value.denominator;
        }

        public int CompareTo(Fraction other)
        {
            if ((double)this.numerator / (double)this.denominator == (double)other.numerator / (double)other.denominator) return 0;
            if ((double)this.numerator / (double)this.denominator > (double)other.numerator / (double)other.denominator) return +1;
            if ((double)this.numerator / (double)this.denominator < (double)other.numerator / (double)other.denominator) return -1;

            return 0;
        }

        public bool Equals(Fraction other)
        {
            if (other != this) return false;
            if (other == this) return true;

            return Object.Equals(this.numerator, other.numerator) && Object.Equals(this.denominator, other.denominator);
        }

        public double RoundUp()
        {
            double result = (double)this.numerator / (double)this.denominator;
            double remainder = result % 1;
            result -= remainder;
            if (result >= 0) result += 1;
            else result -= 1;
            return result;
        }

        public double RoundDown()
        {
            double result = (double)this.numerator / (double)this.denominator;
            double remainder = result % 1;
            result -= remainder;
            return result;
        }

        public override string ToString()
        {
            return $"Numerator equals: {this.numerator} Denominator equals: {this.denominator}";
        }

        public static Fraction operator +(Fraction a) => a;
        public static Fraction operator -(Fraction a) => new Fraction(-a.numerator, a.denominator);
        public static Fraction operator +(Fraction a, Fraction b) => new Fraction(a.numerator * b.denominator + b.numerator * a.denominator, a.denominator * b.denominator);
        public static Fraction operator -(Fraction a, Fraction b) => a + (-b);
        public static Fraction operator *(Fraction a, Fraction b) => new Fraction(a.numerator * b.numerator, a.denominator * b.denominator);
        public static Fraction operator /(Fraction a, Fraction b)
        {
            if (b.numerator == 0)
            {
                throw new DivideByZeroException();
            }
            return new Fraction(a.numerator * b.denominator, a.denominator * b.numerator);
        }
    }
}
