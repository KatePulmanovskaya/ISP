using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lr6
{
    public interface IMovable
    {
        string Type { get; set; }
        string Food { get; set; }
        int DateRelease { get; set; }
        string Color { get; set; }
        void ShowInfo();
    }

    public class Car : IMovable, IEquatable<Car>
    {
        public delegate void CarHandler(int val);
        public event CarHandler NegativeValueSet;

        private string type;
        private string food;
        private int dateRelease;
        private string color;

        public Car(int date, string food, string color)
        {
            this.type = "Автомобиль";
            this.food = food;               
            if (DateTime.Now.Year < date)
                throw new ArgumentOutOfRangeException("Дата выпуска указывает на будущее время!");
            else
                this.dateRelease = date;
            this.color = color;
        }

        public Car(int date, string color)
        {
            this.type = "Автомобиль";
            this.food = "Бензин";
            if (DateTime.Now.Year < date)
                throw new ArgumentOutOfRangeException("Дата выпуска указывает на будущее время!");
            else
                this.dateRelease = date;
            this.color = color;
        }

        public string Type
        {
            get { return type; }
            set { type = value; }
        }

        public string Food
        {
            get { return food; }
            set { food = value; }
        }

        public int DateRelease
        {
            get { return dateRelease; }
            set
            {
                if (DateTime.Now.Year < value)
                {
                    NegativeValueSet?.Invoke(value);
                    dateRelease = 0;
                }
                else
                    dateRelease = value;
            }
        }

        public string Color
        {
            get { return color; }
            set { color = value; }
        }

        public virtual void ShowInfo()
        {
            Console.WriteLine("Тип транспорта: {0}", type);
            Console.WriteLine("Тип питания: {0}", food);
            Console.WriteLine("Дата выпуска: {0}", Convert.ToString(dateRelease));
            Console.WriteLine("Цвет автомобиля: {0}", color);
        }
        
        public bool Equals(Car other)
        {
            if (other == null)
                return false;
            if (this.food == other.food && this.dateRelease == other.dateRelease && this.color == other.color)
                return true;
            else
                return false;
        }

        public override bool Equals(Object obj)
        {
            if (obj == null)
                return false;
            Car carObj = obj as Car;
            if (carObj == null)
                return false;
            else
                return Equals(carObj);
        }

        public override int GetHashCode()
        {
            return Food.GetHashCode() ^ DateRelease.GetHashCode() ^ Color.GetHashCode();
        }

        public static bool operator ==(Car car1, Car car2)
        {
            if (((object)car1) == null || ((object)car2) == null)
                return Object.Equals(car1, car2);
            return car1.Equals(car2);
        }

        public static bool operator !=(Car car1, Car car2)
        {
            if (((object)car1) == null || ((object)car2) == null)
                return !Object.Equals(car1, car2);
            return !(car1.Equals(car2));
        }
    }

    public class Honda : Car
    {
        private string model; //номер модели

        public Honda(int date, string food, string color, string model) : base(date, food, color) //конструктор
        {
            this.model = model;
        }

        public Honda(int date, string color, string model) : base(date, color) //конструктор
        {
            this.model = model;
        }

        public string Model
        {
            get { return "Honda " + model; }
            set { model = value; }
        }

        public override void ShowInfo()
        {
            base.ShowInfo();
            Console.WriteLine("Номер модели: {0}", Model);
        }
    }

    public class Opel : Car
    {
        private string model; //номер модели

        public Opel(int date, string food, string color, string model) : base(date, food, color)//конструктор
        {
            this.model = model;
        }

        public Opel(int date, string color, string model) : base(date, color)//конструктор
        {
            this.model = model;
        }

        public string Model
        {
            get { return "Opel " + model; }
            set { model = value; }
        }

        public override void ShowInfo()
        {
            base.ShowInfo();
            Console.WriteLine("Номер модели: {0}", Model);
        }

    }
    
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Honda honda = new Honda(2013, "Черный", "CR-V IV");
                Opel opel = new Opel(2012, "Черный", "Insignia I (рестайлинг) COSMO SPORT");
                honda.ShowInfo();
                Console.WriteLine();
                honda.NegativeValueSet += i => Console.WriteLine($"Некорректное значение: {i}");
                honda.NegativeValueSet += delegate (int i)
                {
                    Console.WriteLine("Дата выпуска указывает на будущее время!");
                    Console.WriteLine($"Дата {i} будет обнулена");
                    Console.WriteLine();
                };
                honda.DateRelease = 2025;
                honda.ShowInfo();
                Console.WriteLine();
                opel.ShowInfo();
                Console.WriteLine();
                Console.WriteLine("Сравнение объектов honda и opel. Результат:");
                if (Car.Equals(honda, opel))
                    Console.WriteLine("  Автомобили разных марок одинаковы по характеристикам");
                else Console.WriteLine("  Автомобили разных марок разные по характеристикам");
            }
            catch (ArgumentOutOfRangeException ex)
            {
                Console.WriteLine(ex.Message);
            }
            Console.ReadLine();
        }
    }
}
