using System;

namespace Testing_Metro_App
{
	class Program
	{
        static Program()
        {
			Logger.Logger.Instance.PrintErrorEvents += Instance_PrintErrorEvents;
        }

		private static void Instance_PrintErrorEvents(Exception obj)
		{
			Console.Clear();
            Console.Beep();
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            Console.BackgroundColor = ConsoleColor.White;
			Console.WriteLine(obj.Message);
        }

		static void Main(string[] args)
		{
			Console.WriteLine("Hello World!");
		}
	}
}
