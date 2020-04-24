using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lr3
{
    public enum Food
    {
        Benzin,
        Dizel,
        Electro,
        Gibrid
    }
    struct Transport
    {
        private int date_release; //год выпуска
        private string type; //тип транспорта
        Food food; //тип питания
        public Transport(string type, int date, Food f)
        {
            this.type = type;
            this.date_release = date;
            this.food = f;
        }
        public string Type
        {
            get { return type; }
            set { type = value; }
        }

        public int Date_release
        {
            get { return date_release; }
            set { date_release = value; }
        }
        
        public void DisplayInfo()
        {
            Console.WriteLine("Тип транспорта: {0}", type);
            Console.WriteLine("Дата выпуска: {0}", Convert.ToString(date_release));
            Console.WriteLine("Тип питания: {0}", food);
        }
    }

    public abstract class Car
    {
        private Transport transport;
        private string color; //цвет автомобиля
        private static int instances = 0; //счетчик
        public Car(int date, Food f, string color)
        {
            transport = new Transport("Автомобиль", date, f);
            this.color = color;
            instances++;
        }

        public Car(int date, string color)
        {
            transport = new Transport("Автомобиль", date, Food.Benzin);
            this.color = color;
            instances++;
        }

        public string Color
        {
            get { return color; }
            set { color = value; }
        }

        public abstract string Model
        {
            get;
            set;
        }

        public virtual void ShowInfo()
        {
            transport.DisplayInfo();
            Console.WriteLine("Цвет автомобиля: {0}", color);
        }
        public static void HowManyCars()
        {
            Console.WriteLine("Количество автомобилей разных марок: {0}", instances);
        }
    }

    public class Honda : Car
    {
        private string model; //номер модели
        public Honda(int date, Food food, string color, string model) : base(date, food, color) //конструктор
        {
            this.model = model;
        }

        public Honda(int date, string color, string model) : base(date, color) //конструктор
        {
            this.model = model;
        }

        public override string Model
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
        public Opel(int date, Food food, string color, string model) : base(date, food, color)//конструктор
        {
            this.model = model;
        }

        public Opel(int date, string color, string model) : base(date, color)//конструктор
        {
            this.model = model;
        }

        public override string Model
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
        public BMW(int date, Food food, string color, string model) : base(date, food, color)//конструктор
        {
            this.model = model;
        }

        public BMW(int date, string color, string model) : base(date, color)//конструктор
        {
            this.model = model;
        }

        public override string Model
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
            Car.HowManyCars();
            Console.WriteLine();
            Opel opel = new Opel(2012, "Черный", "Insignia I (рестайлинг) COSMO SPORT");
            opel.ShowInfo();
            Console.WriteLine();
            BMW bMW = new BMW(2001, Food.Dizel, "Синий", "5 серия E39 E39 525D Restyling");
            bMW.ShowInfo();
            Console.WriteLine();
            Car.HowManyCars();
            Console.ReadLine();
        }

    }
}
