using System;

namespace WT.MiddlewareBasic
{
    class Program
    {
        static void Main(string[] args)
        {
           FunctionWrap("hellow world",msg=>FunctionTry(msg, FunctionOne));
            Console.ReadLine();
        }

        public static void FunctionOne(string msg)
        {
            Console.WriteLine($"Function One executed {msg}");
        }
        public static void FunctionTwo(string msg)
        {
            Console.WriteLine($"Function Two executed {msg}");
        }

        public static void FunctionWrap(string msg,Action<string> action)
        {
            Console.WriteLine("Wrap function Started");
            msg += " Wraped";
            action(msg);
            Console.WriteLine("Wrap function ends");
        }
        public static void FunctionTry(string msg,Action<string> action)
        {
            try
            {
                Console.WriteLine("Try");
                action(msg);

            }
            catch 
            {

                
            }
        }
    }
}
