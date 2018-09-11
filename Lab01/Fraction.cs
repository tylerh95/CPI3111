using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab01
{
    public struct Fraction
    {
        private int numerator;
        private int denominator;

        public Fraction(int n = 0, int d = 1)
        {
            numerator = n;
            if (d == 0)
            {
                d = 1;
            }
            denominator = d;
        }

        public override string ToString()
        {
            return numerator + "/" + denominator;
        }

        private void Simplify()
        {
            if (denominator < 0)
            {
                denominator *= -1;
                numerator *= -1;
            }
            int gcd = GCD(numerator, denominator);
            numerator /= gcd;
            denominator /= gcd;
        }

        public static Fraction Multiply(Fraction lhs, Fraction rhs)
        {
            return new Lab01.Fraction(lhs.numerator * rhs.numerator, lhs.denominator * rhs.denominator);
        }

        public static Fraction operator +(Fraction lhs, Fraction rhs)
        {
            return new Fraction((lhs.numerator*rhs.denominator) + (rhs.numerator*lhs.denominator), lhs.denominator * rhs.denominator);
        }

        public static Fraction operator -(Fraction lhs, Fraction rhs)
        {
            return new Fraction((lhs.numerator * rhs.denominator) - (rhs.numerator * lhs.denominator), lhs.denominator * rhs.denominator);
        }

        public static Fraction operator *(Fraction lhs, Fraction rhs)
        {
            return new Fraction(lhs.numerator * rhs.numerator, lhs.denominator * rhs.denominator);
        }

        public static Fraction operator /(Fraction lhs, Fraction rhs)
        {
            return new Fraction(lhs.numerator * rhs.denominator, lhs.denominator * rhs.numerator);
        }

        public static int GCD(int a, int b)
        {
            while(a != 0 && b != 0)
            {
                if (a > b)
                {
                    a %= b;
                } else
                {
                    b %= a;
                }
            }

            return Math.Max(a, b);
        }

        public int Numerator
        {
            get { return numerator; }
            set { numerator = value;  Simplify(); }
        }
    }
}
