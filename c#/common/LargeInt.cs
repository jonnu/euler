﻿using System;
using System.Text;
using System.Linq;
using System.Collections.Generic;

namespace Euler
{
    class LargeInt : IComparable
    {
        private const int radix = 10;
        private List<int> digit = new List<int>();

        public int Length { get; private set; }

        private LargeInt() { }

        public LargeInt(long initialValue)
        {
            createDigitList(initialValue);
        }

        public LargeInt(List<int> initialList)
        {
            Length = initialList.Count;
            digit = initialList;
        }

        public LargeInt(LargeInt initialValue)
        {
            for (int i = 0; i < initialValue.Length; i++)
            {
                SetDigitAt(i, initialValue.GetDigitAt(i));
            }
        }

        private void createDigitList(long value)
        {
            Length = (int)Math.Log10(value) + 1;
            for (int i = 0; i < Length; i++)
            {
                digit.Insert(i, (int)(value % radix));
                value /= radix;
            }
        }

        public int GetDigitAt(int index)
        {
            return digit.ElementAtOrDefault(index);
        }

        private void SetDigitAt(int index, int value)
        {
            if (digit.Count > index) {
                digit[index] = value;
                return;
            }

            digit.Insert(index, value);
            if (value > 0 && (index + 1 > Length))
            {
                Length = index + 1;
            }
        }

        public static LargeInt Add(LargeInt x, LargeInt y)
        {
            int carry = 0;
            int loopLength = Math.Max(x.Length, y.Length) + 1;
            LargeInt newInt = new LargeInt();

            for (int i = 0; i < loopLength; i++)
            {
                int xDigit = 0, yDigit = 0, zDigit = 0;

                xDigit = x.GetDigitAt(i);
                yDigit = y.GetDigitAt(i);
                zDigit = xDigit + yDigit + carry;

                if (zDigit >= radix)
                {
                    zDigit %= radix;
                    carry = 1;
                }
                else
                {
                    carry = 0;
                }

                newInt.SetDigitAt(i, zDigit);
            }

            return newInt;
        }

        public static LargeInt Multiply(LargeInt x, LargeInt y)
        {
            LargeInt newInt = new LargeInt();

            for (int i = 0; i < y.Length; i++)
            {
                int carry = 0;
                for (int j = 0; j < x.Length; j++)
                {
                    int zDigit = (y.GetDigitAt(i) * x.GetDigitAt(j)) + newInt.GetDigitAt(i + j) + carry;
                    
                    newInt.SetDigitAt(i + j, zDigit % 10);
                    carry = zDigit / 10;
                }

                newInt.SetDigitAt(i + x.Length, carry);
            }

            return newInt;
        }

        public static LargeInt Multiply(LargeInt x, int y)
        {
            LargeInt integer = new LargeInt(x);
            for (int i = 1; i < y; i++)
            {
                integer += x;                
            }

            return integer;
        }

        public static LargeInt Pow(int x, int y)
        {
            LargeInt integer = new LargeInt(x);
            for (int i = 1; i < y; i++)
            {
                integer = LargeInt.Multiply(integer, x);
            }

            return integer;
        }

        public static LargeInt Pow(LargeInt x, int y)
        {
            for (int i = 1; i < y; i++)
            {
                x *= x;
            }

            return x;
        }

        public bool Palindrome()
        {
            for (int i = 0, j = (Length - 1) - i; i < (Length - 1) / 2; i++, j--)
            {
                if (GetDigitAt(i) != GetDigitAt(j))
                    return false;
            }

            return true;
        }

        public LargeInt Reverse()
        {
            List<int> temp = digit;
            for (int i = 0; i <= (Length - 1) / 2; i++)
            {
                int j = (Length - 1) - i;
                int temporary = digit[i];
                digit[i] = digit[j];
                digit[j] = temporary;
            }

            return this;
        }

        public int DigitSum()
        {
            int sum = 0;
            for (int i = 0; i < Length; i++)
            {
                sum += digit[i];
            }

            return sum;
        }

        public int CompareTo(object obj)
        {
            if (obj == null)
                return 1;

            LargeInt compare = obj as LargeInt;
            if (compare.Length == Length)
            {
                for (int i = 0; i < Length; i++)
                {
                    if (compare.GetDigitAt(i) == GetDigitAt(i))
                        continue;

                    if (compare.GetDigitAt(i) < GetDigitAt(i))
                        return 1;

                    return -1;
                }

                return 0;
            }

            return compare.Length < Length ? 1 : -1;
        }

        public override bool Equals(Object obj)
        {
            if (!(obj is LargeInt))
                return false;

            return CompareTo(obj) == 0;
        }

        public static bool operator ==(LargeInt x, LargeInt y)
        {
            return x.Equals(y);
        }

        public static bool operator !=(LargeInt x, LargeInt y)
        {
            return !(x == y);
        }

        public static bool operator <(LargeInt x, LargeInt y)
        {
            return x.CompareTo(y) < 0;
        }

        public static bool operator >(LargeInt x, LargeInt y)
        {
            return x.CompareTo(y) > 0;
        }

        public static LargeInt operator +(LargeInt x, LargeInt y)
        {
            return LargeInt.Add(x, y);
        }

        public static LargeInt operator *(LargeInt x, int y)
        {
            return LargeInt.Multiply(x, y);
        }

        public static LargeInt operator *(LargeInt x, LargeInt y)
        {
            return LargeInt.Multiply(x, y);
        }

        public static explicit operator long(LargeInt largeInt)
        {
            long integer = 0;
            for (int i = largeInt.Length - 1, power = 1; i >= 0; i--, power *= radix)
            {
                integer += largeInt.GetDigitAt(i * power);
            }

            return integer;
        }

        public static implicit operator LargeInt(long value)
        {
            return new LargeInt(value);
        }

        public override int GetHashCode()
        {
            int hashCode = 0;
            for (int i = Length - 1; i >= 0; i--)
            {
                hashCode += digit[i];
            }

            return hashCode;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            for (int i = Length - 1; i >= 0; i--)
            {
                sb.Append(digit[i]);
            }

            return sb.ToString();
        }
    }
}
