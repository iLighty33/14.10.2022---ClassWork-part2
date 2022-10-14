using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// в шарпах нет множественного наследования от класса
// есть множественное наследование от интерфейсов

namespace _14._10._2022___Classwork
{
    public enum dayOfWeek
    {
        monday = 1,
        tuesday = 2,
        wednesday = 3,
        thursday = 4,
        friday = 5,
        saturday = 6,
        sunday = 7
    }


    class EmployerTime : ICounter, IWhenCreated//, IWorkToDisk
    {

        private DateTime CreatedTime;
        private string name;
        
        public DateTime Created
        {
            get
            {
                Console.WriteLine($"Объект {this.ToString()} был создан {CreatedTime.ToString("yyyy-MM-dd HH:mm:ss.fff")}");
                return CreatedTime;
            }
        }
        private int[] WorkTime;
        private int summOfHours;
        public int count
        {
            get
            {
                foreach (var item in WorkTime)
                {
                    summOfHours += item;
                }
                return summOfHours;
            }
        }

        //DateTime IWhenCreated.Created => throw new NotImplementedException();

        public static void TimeStamp(IWhenCreated obj)
        {
            Console.WriteLine(obj.Created.ToString());
        }
        public void BriefPrint()
        {
            foreach (var item in Enum.GetValues(typeof(DayOfWeek)))
            {
                Console.WriteLine($"{item} - {WorkTime[(int)item]}");
            }
        }
        public EmployerTime()
        {
            WorkTime = new int[7 + 1];
            summOfHours = 0;
            CreatedTime = DateTime.Now;
            this.name = "John Dow #" + CreatedTime.ToString();
        }

        public EmployerTime(string _name)
        {
            WorkTime = new int[7 + 1];
            summOfHours = 0;
            CreatedTime = DateTime.Now;
            this.name = _name;
        }
        public int this[int index]
        {
            set { WorkTime[index] = value; }
            get { return WorkTime[index]; }
        }
        /* public string PrintDayOfWeek(dayOfWeek dayOfWeek)
         {
             string MydayOfWeek = "";
             switch(dayOfWeek)
             {
                 case dayOfWeek.monday:
                     MydayOfWeek = "monday";
                     break;
                 case dayOfWeek.tuesday:
                     MydayOfWeek = "tuesday";
                      break;
                 case dayOfWeek.wednesday:
                     MydayOfWeek = "wednesday";
                       break;
                 case dayOfWeek.thursday:
                     MydayOfWeek = "thursday";
                     break;
                 case dayOfWeek.friday:
                     MydayOfWeek = "friday";
                     break;
                 case dayOfWeek.saturday:
                     MydayOfWeek = "saturday";
                     break;
                 case dayOfWeek.sunday:
                     MydayOfWeek = "sunday";
                     break;
                 default:
                     break;
             }
             return MydayOfWeek;
         }
        */
        public void Print()
        {
            foreach (var item in Enum.GetValues(typeof(dayOfWeek)))
            {
                Console.WriteLine($"В день {item}  отработано {WorkTime[(int)item]} часов");
            }
        }

    }

    interface ICounter
    {
        int count { get; }
        void BriefPrint()
        {

        }
        //string Title;
        //int Count;
    }
    interface IWhenCreated
    {
        //int count { get; }
        DateTime Created { get; }
    }

    interface IWorkToDisk
    {
        string FileName { get; }
        bool SaveToDisk();
        bool ReadFromDisk();

    }

    class Program
    {
        static void Main(string[] args)
        {

            for (int i = 0; i < args.Length; i++)
            {
                Console.WriteLine(args[i]);
            }

            Console.WriteLine("Введите количество часов:");
            int entrance = int.Parse(Console.ReadLine());

            try
            {

            }
            catch (Exception)
            {

            }

            if (entrance > 8 || entrance < 0)
            {
                Console.WriteLine("Ошибка ввода");
                entrance = 8;
            }

            var BobTime = new EmployerTime();
            var JohnTime = new EmployerTime();
            //BobTime.Print();
            BobTime[2] = entrance;
            BobTime.Print();
            BobTime.BriefPrint();
            Console.WriteLine($"\nОтработано {BobTime.count} часов");
            Console.WriteLine(BobTime.Created);

            JohnTime[0] = 7;
            Console.WriteLine(JohnTime.Created);
            IWhenCreated obj = new EmployerTime();
            EmployerTime.TimeStamp(obj);
            //Console.WriteLine(obj.Created.ToString());
            Console.ReadKey();
            //Console.WriteLine(BobTime.GetEnumerator().ToString());
        }
    }
}

