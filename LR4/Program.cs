using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyLib;

namespace lr4
{
    class Program
    {
        static void Main(string[] args)
        {
            Processes process = new Processes();
            process.GetInfo();
            int choice;
            Console.WriteLine("Желаете остановить процесс? (1 - да, 0 - нет)");
            choice = Convert.ToInt32(Console.ReadLine());
            if (choice == 1)
            {
                Console.WriteLine("Остановить по ID или по имени? (1 - ID, 2 - имя)");
                choice = Convert.ToInt32(Console.ReadLine());
                if (choice == 1)
                {
                    int ID;
                    Console.WriteLine("Введите ID процесса: ");
                    ID = Convert.ToInt32(Console.ReadLine());
                    process.KillProcess(ID);
                }
                else if (choice == 2)
                {
                    string name; ;
                    Console.WriteLine("Введите имя процесса: ");
                    name = Console.ReadLine();
                    process.KillProcess(name);
                }
            }
            process.GetInfo();
            Console.ReadLine();
        }
    }
}
