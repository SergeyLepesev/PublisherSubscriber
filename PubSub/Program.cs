using System;

namespace PubSub
{
    class Program
    {
        static void Main(string[] args)
        {
            var stack = new Stack<int>();
            var sub = new Sub<int>(stack);
            stack.Push(1);
            stack.Pop();
            Console.ReadKey();

        }

        public class Sub<T>
        {
            public Sub(Stack<T> stack)
            {
                stack.NotifyPop += ConsoleNotifyPop;
                stack.NotifyPush += ConsoleNotifyPush;
            }

            public static void ConsoleNotifyPop(object sender, EventArgs e)
            {
                Console.WriteLine("Use pop");
            }

            public static void ConsoleNotifyPush(object sender, EventArgs e)
            {
                Console.WriteLine("Use push");
            }
        }
    }
}
