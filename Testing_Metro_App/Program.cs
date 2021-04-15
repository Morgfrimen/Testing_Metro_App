using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace Testing_Metro_App
{
	class Program
	{
        static Program()
        {
			Logger.Logger.Instance.PrintErrorEvents += Instance_PrintErrorEvents;
			Console.ResetColor();
        }

		private static void Instance_PrintErrorEvents(Exception obj)
		{
			Console.Clear();
            Console.Beep();
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.BackgroundColor = ConsoleColor.White;
			Console.WriteLine(obj.Message);
        }

		static async Task Main(string[] args)
		{
			Console.WriteLine("Hello World!");
            IList<(uint, uint)> readerList = await ReaderFile.ReaderTxtFile.ReadFile(Path.Combine("InputFile","InputDefault.txt"));
        }
	}
}
