using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lr3
{

    public class Transport
    {
        private int date_release; //дата выпуска
        private string type; //тип транспорта
        private string food; //тип питания
        public Transport (string type,int date, string food)//конструктор с 3 аргументами
        { 
            this.type = type;
            this.date_release = date;
            this.food = food;
        }

        public Transport(int date, string food)//конструктор с двумя аргументами
        {
            this.date_release = date;
            type = "Автомобиль";
            this.food = food;
        }

        public Transport(int date) //конструктор с одним аргументом
        {
            this.date_release = date;
            type = "Автомобиль";
            food = "Бензин";
        }

    
        public string Type
        {
            get
            {
                return type;
            }
            set
            {
                type = value;
            }
        }

        public int Date_release
        {
            get
            {
                return date_release;
            }
            set
            {
                date_release = value;
            }
        }

        public string Food
        {
            get
            {
                return food;
            }
            set
            {
                food = value;
            }
        }

        public void ShowInfo()
        {
            Console.WriteLine("Класс: Транспорт");
            Console.WriteLine("Тип транспорта: {0}", type);
            Console.WriteLine("Дата выпуска: {0}", Convert.ToString(date_release));
            Console.WriteLine("Тип питания: {0}",food);
        }
    }

    public class Car : Transport
    {
        private string color; //цвет автомобиля
        private static int instances = 0; //счетчик
        public Car(int date, string food, string color) : base(date,food)//конструктор
        {
            
            this.color = color;
            instances++;
        }

        public Car(int date, string color) : base(date)//конструктор
        {

            this.color = color;
            instances++;
        }

        public string Color
        {
            get
            {
                return color;
            }
            set
            {
                color = value;
            }
        }

        public new void ShowInfo()
        {
            base.ShowInfo();
            Console.WriteLine("Класс: Автомобиль");
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
            get
            {
                return model;
            }
            set
            {
                model = value;
            }
        }
        public new void ShowInfo()
        {
            base.ShowInfo();
            Console.WriteLine("Класс: Honda");
            Console.WriteLine("Номер модели Honda: {0}", model);

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
            get
            {
                return model;
            }
            set
            {
                model = value;
            }
        }

        public new void ShowInfo()
        {
            base.ShowInfo();
            Console.WriteLine("Класс: Opel");
            Console.WriteLine("Номер модели Opel: {0}", model);

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
            get
            {
                return model;
            }
            set
            {
                model = value;
            }
        }

        public new void ShowInfo()
        {
            base.ShowInfo();
            Console.WriteLine("Класс: BMW");
            Console.WriteLine("Номер модели BMW: {0}", model);

        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Transport transp = new Transport("Поезд",1998, "Электричество");
            transp.ShowInfo();
            Console.WriteLine();
            Car.HowManyCars();
            Console.WriteLine();
            Car avto = new Car(2014, "Белый");
            avto.ShowInfo();
            Console.WriteLine();
            Honda honda = new Honda(2013, "Черный", "CR-V IV");
            honda.ShowInfo();
            Console.WriteLine();
            Car.HowManyCars();
            Console.WriteLine();
            Opel opel = new Opel(2012, "Черный", "Insignia I (рестайлинг) COSMO SPORT");
            opel.ShowInfo();
            Console.WriteLine();
            BMW bMW = new BMW(2001, "Дизель", "Синий", "5 серия E39 E39 525D Restyling");
            bMW.ShowInfo();
            Console.WriteLine();
            Car.HowManyCars();
            Console.ReadLine();
        }

    }
}
