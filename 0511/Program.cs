using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace _0511
{
    class Program
    {
        static void Main(string[] args)
        {
            var stu1 = new Student { ID = 1, PenColor = ConsoleColor.Yellow };
            var stu2 = new Student { ID = 2, PenColor = ConsoleColor.Green };
            var stu3 = new Student { ID = 3, PenColor = ConsoleColor.Red };

            // 直接同步调用
            //stu1.DoHomework();
            //stu2.DoHomework();
            //stu3.DoHomework();

            var action1 = new Action(stu1.DoHomework);
            var action2 = new Action(stu2.DoHomework);
            var action3 = new Action(stu3.DoHomework);

            // 间接同步调用
            //action1.invoke();
            //action2.invoke();
            //action3.invoke();

            // 多播委托，同步调用
            action1 += action2;
            action1 += action3;

            action1.Invoke();

            // 主线程模拟在做某些事情。
            for (var i = 0; i < 10; i++)
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("Main thread {0}", i);
                Thread.Sleep(500);
            }
            
        }
    }

    class Student
    {
        public int ID { get; set; }
        public ConsoleColor PenColor { get; set; }

        public void DoHomework()
        {
            for (int i = 0; i < 5; i++)
            {
                Console.ForegroundColor = PenColor;
                Console.WriteLine("Student {0} doing homework {1} hour(s)", ID, i);
                Thread.Sleep(500);
            }
        }
    }
}

