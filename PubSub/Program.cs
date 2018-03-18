using System;

namespace PubSub
{
    class Program
    {
        static void Main(string[] args)
        {
            var stack = new Stack<int>();
            new Sub().Subscribe(stack);
            stack.Push(1);
            stack.Pop();
            Console.ReadKey();

        }

        public class Sub
        {
            public void Subscribe<T>(Stack<T> stack)
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
