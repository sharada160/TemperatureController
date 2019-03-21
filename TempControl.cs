using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tempcontrol
{

    public class Program
    {
        static void Main(string[] args)
        {
            temp t = new temp();
            Console.WriteLine("enter min and max threshold");
            int min = Convert.ToInt32(Console.ReadLine());
            int max = Convert.ToInt32(Console.ReadLine());
            t.RandomNumber(min, max);
        }
    }


    public class temp
    {

        public delegate void controlDelegate(int val);
        public event controlDelegate ControlEvent;
        public temp()
        {
            this.ControlEvent += Date;
           

        }

        //public void RandomNumber(int min, int max)
        //{
        //    int[] a = new int[100];
        //    int temp;
        //    for (int i = 0; i < 10; i++)
        //    {
        //        Random random = new Random();
        //        temp = random.Next(min, max);
        //        a[i] = temp;

        //    }
        public void RandomNumber(int min, int max)
        {

            int[] a = new int[100];
            int b;
            for (int i = 0; i < 10; i++)
            {
                Random random = new Random();
                b = random.Next(min-5, max+5);
                a[i] = b;

            }
            for (int i = 0; i < 10; i++)
            {
                if (a[i] <= min || a[i] >= max)
                {
                    using (TemperatureEntities context = new TemperatureEntities())
                    {
                        Temptable tmp = new Temptable
                        {
                            Temp = a[i],
                            Time = DateTime.Now.ToLocalTime()
                        };
                        context.Temptables.Add(tmp);
                        context.SaveChanges();
                    }
                    b = a[i];
                    ControlEvent(b);
                }


                else
                {
                    Console.WriteLine("Enter correct input");
                }


                    Console.ReadKey();

                }
            }
        private static void Date(int b)
        {

            Console.WriteLine("temerature {0},time{1}", b, DateTime.Now);
        }

        }
}



    

