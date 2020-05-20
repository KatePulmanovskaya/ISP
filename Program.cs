using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace lr7
{
    public class RationalNumber :IComparable, IEquatable<RationalNumber>
    {
        private int n;
        private int m;
        
        public RationalNumber()
        {
            n = 0;
            m = 1;
        }
        
        public RationalNumber(int n, int m)
        {
            this.n = n;
            if (m > 0)
                this.m = m;
            else
            {
                Console.WriteLine("Знаменатель не является натуральным числом.");
                this.m = 1;
            }
        }
        
        public RationalNumber(string str)
        {
            Regex regex = new Regex(@"/");
            string[] result = regex.Split(str);
            if (result.Length == 1)
            {
                bool succees = int.TryParse(result[0], out int res);
                if (succees)
                    this.n = res;
                else
                    this.n = 0;
                this.m = 1;
            }
            else if (result.Length == 2)
            {
                bool succees = int.TryParse(result[0], out int resN);
                if (succees)
                    this.n = resN;
                else
                    this.n = 0;
                succees = int.TryParse(result[1], out int resM);
                if (succees)
                    this.m = resM;
                else
                    this.m = 1;
            }
            else
            {
                Console.WriteLine("Неккоректный формат.");
                this.n = 0;
                this.m = 1;
            }
        }
        
        public int N
        {
            get { return n; }
            set { n = value; }
        }
        
        public int M
        {
            get { return m; }
            set
            {
                if (value > 0)
                    m = value;
                else
                {
                    Console.WriteLine("Знаменатель не является натуральным числом.");
                    this.m = 1;
                }
            }
        }
        
        public override string ToString()
        {
            Console.WriteLine("Рациональное число:");
            return $"{n}/{m}";
        }
        
        public void Show()
        {
            Console.WriteLine("Выберите формат представления числа: №1, №2, №3, №4");
            int format = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Рациональное число:");
            switch (format)
            {
                case 1:
                    Console.WriteLine($"  {n}/{m}");
                    break;
                case 2:
                    Console.WriteLine($"  {n}\n  ___\n \n  {m}");
                    break;
                case 3:
                    Console.WriteLine($"  Числитель равен {n}\n  Знаменатель равен {m}");
                    break;
                case 4:
                    Console.WriteLine("  Представление через десятичное число: " + (double)n / m);
                    break;
                default:
                    Console.WriteLine($"  {n}/{m}");
                    break;
            }
        }
        
        public static RationalNumber operator +(RationalNumber number)
        {
            return number;
        }
        
        public static RationalNumber operator -(RationalNumber number)
        {
           return new RationalNumber(-number.n, number.m);
        }
        
        public static RationalNumber operator +(RationalNumber numberA, RationalNumber numberB)
        {
            if (numberA.m == numberB.m)
                return new RationalNumber(numberA.n + numberB.n, numberA.m);
            else
                return new RationalNumber(numberA.n * numberB.m + numberB.n * numberA.m, numberA.m * numberB.m);
        }
        
        public static RationalNumber operator -(RationalNumber numberA, RationalNumber numberB)
        {
           return numberA + (-numberB);
        }
        
        public static RationalNumber operator *(RationalNumber numberA, RationalNumber numberB)
        {
            return new RationalNumber(numberA.n * numberB.n, numberA.m * numberB.m);
        }
        
        public static RationalNumber operator /(RationalNumber numberA, RationalNumber numberB)
        {
            if (numberB.n == 0)
            {
                Console.WriteLine("На 0 делить нельзя!");
                return new RationalNumber(0, 1);
            }
            return new RationalNumber(numberA.n * numberB.m, numberA.m * numberB.n);
        }
        
        public static bool operator >(RationalNumber numberA, RationalNumber numberB)
        {
            if (numberA.n * numberB.m > numberB.n * numberA.m)
                return true;
            else
                return false;
        }
        
        public static bool operator <(RationalNumber numberA, RationalNumber numberB)
        {
            if (numberA.n * numberB.m < numberB.n * numberA.m)
                return true;
            else
                return false;
        }
        
        public static bool operator >=(RationalNumber numberA, RationalNumber numberB)
        {
            if (numberA.n * numberB.m >= numberB.n * numberA.m)
                return true;
            else
                return false;
        }
        
        public static bool operator <=(RationalNumber numberA, RationalNumber numberB)
        {
            if (numberA.n * numberB.m <= numberB.n * numberA.m)
                return true;
            else
                return false;
        }
        
        public static explicit operator double(RationalNumber number)
        {
            return (double)number.N / number.M;
        }
        
        public static implicit operator int(RationalNumber number)
        {
            return number.N / number.M;
        }
        
        public int CompareTo(object obj)
        {
            if (obj == null) return 1;
            RationalNumber otherNumber = obj as RationalNumber;
            if (otherNumber != null)
                return (this.n / this.m).CompareTo(otherNumber.n / otherNumber.m);
            else
                throw new ArgumentException("Object is not a RationalNumber");
        }
        
        public bool Equals(RationalNumber otherNumber)
        {
            if (otherNumber == null)
                return false;
            if ( (this.n * otherNumber.m) == (otherNumber.n * this.m))
                return true;
            else
                return false;
        }
        
        public override bool Equals(Object obj)
        {
            if (obj == null)
                return false;
            RationalNumber number = obj as RationalNumber;
            if (number == null)
                return false;
            else
                return Equals(number);
        }
        
        public override int GetHashCode()
        {
            return n.GetHashCode() ^ m.GetHashCode();
        }
        
        public static bool operator ==(RationalNumber numberA, RationalNumber numberB)
        {
            if (((object)numberA) == null || ((object)numberB) == null)
                return Object.Equals(numberA, numberB);
            return numberA.Equals(numberB);
        }
        
        public static bool operator !=(RationalNumber numberA, RationalNumber numberB)
        {
            if (((object)numberA) == null || ((object)numberB) == null)
                return !Object.Equals(numberA, numberB);
            return !(numberA.Equals(numberB));
        }
    }
    
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите число A:");
            string str = Console.ReadLine();
            RationalNumber numberA = new RationalNumber(str);
            Console.WriteLine("Введите число B:");
            str = Console.ReadLine();
            RationalNumber numberB = new RationalNumber(str);
            int choice = 0;
            while (choice != 9)
            {
                Console.WriteLine("Меню:");
                Console.WriteLine(" 1. Вывести числа A и B");
                Console.WriteLine(" 2. Число A > B?");
                Console.WriteLine(" 3. Число A < B?");
                Console.WriteLine(" 4. Число A = B?");
                Console.WriteLine(" 5. A + B");
                Console.WriteLine(" 6. A * B");
                Console.WriteLine(" 7. Явное преобразование числа А в double");
                Console.WriteLine(" 8. Неявное преобразование числа А в int");
                Console.WriteLine(" 9. Выход");
                Console.WriteLine("Ваш выбор:");
                choice = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine();
                switch (choice)
                {
                    case 1:
                        Console.WriteLine("Число A");
                        numberA.Show();
                        Console.WriteLine("Число B");
                        numberB.Show();
                        break;
                    case 2:
                        if (numberA.CompareTo(numberB) < 0)
                            Console.WriteLine("Да");
                        else
                            Console.WriteLine("Нет");
                        break;
                    case 3:
                        if (numberA < numberB)
                            Console.WriteLine("Да");
                        else
                            Console.WriteLine("Нет");
                        break;
                    case 4:
                        if (RationalNumber.Equals(numberA, numberB))
                            Console.WriteLine("Да");
                        else
                            Console.WriteLine("Нет");
                        break;
                    case 5:
                        Console.WriteLine(numberA + numberB);
                        break;
                    case 6:
                        Console.WriteLine(numberA * numberB);
                        break;
                    case 7:
                        double numderDouble = (double)numberA;
                        Console.WriteLine(Convert.ToString(numderDouble));
                        break;
                    case 8:
                        int numderInt = numberA;
                        Console.WriteLine(Convert.ToString(numderInt));
                        break;
                    case 9:
                        break;
                    default:
                        Console.WriteLine("Выберите корректный пункт меню.");
                        break;
                }
                Console.WriteLine();
            }
            Console.ReadLine();
        }
    }
}
