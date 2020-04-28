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
        private string type;
        private string food;
        private int dateRelease;
        private string color;
        private static int instances = 0; //счетчик
        public Car(int date, string food, string color)
        {
            this.type = "Автомобиль";
            this.food = food;
            this.dateRelease = date;
            this.color = color;
            instances++;
        }
        public Car(int date, string color)
        {
            this.type = "Автомобиль";
            this.food = "Бензин";
            this.dateRelease = date;
            this.color = color;
            instances++;
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
            set { dateRelease = value; }
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
        public static void HowManyCars()
        {
            Console.WriteLine("Количество автомобилей разных марок: {0}", instances);
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
    public class BMW : Car
    {
        private string model; //номер модели
        public BMW(int date, string food, string color, string model) : base(date, food, color)//конструктор
        {
            this.model = model;
        }
        public BMW(int date, string color, string model) : base(date, color)//конструктор
        {
            this.model = model;
        }
        public string Model
        {
            get { return "BMW " + model; }
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
            Honda honda = new Honda(2013, "Черный", "CR-V IV");
            honda.ShowInfo();
            Console.WriteLine();
            Console.WriteLine();
            Opel opel = new Opel(2012, "Черный", "Insignia I (рестайлинг) COSMO SPORT");
            opel.ShowInfo();
            Console.WriteLine();
            BMW bMW = new BMW(2001, "Дизель", "Синий", "5 серия E39 E39 525D Restyling");
            bMW.ShowInfo();
            Console.WriteLine();
            Car.HowManyCars();
            Console.WriteLine();
            Honda honda1 = new Honda(2013, "Черный", "CR-V IV");
            honda1.ShowInfo();
            Console.WriteLine();
            Console.WriteLine("Сравнение объектов honda и honda1. Результат:");
            if (honda.Equals(honda1))
                Console.WriteLine("  Автомобили одной марки одинаковы по характеристикам");
            else Console.WriteLine("  Автомобили одной марки разные по характеристикам");
            Console.WriteLine();
            Console.WriteLine("Сравнение объектов honda и opel. Результат:");
            if (Car.Equals(honda, opel))
                Console.WriteLine("  Автомобили разных марок одинаковы по характеристикам");
            else Console.WriteLine("  Автомобили разных марок разные по характеристикам");
            Console.ReadLine();
        }
    }
}
