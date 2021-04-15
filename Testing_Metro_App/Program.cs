using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

using Testing_Metro_App.Model;

namespace Testing_Metro_App
{
	class Program
	{
        static Program()
        {
			Logger.Logger.Instance.PrintErrorEvents += Instance_PrintErrorEvents;
			Logger.Logger.Instance.PrintWarring += Instance_PrintWarring;
			Console.ResetColor();
        }

		private static void Instance_PrintWarring(string obj)
		{
            Console.WriteLine(obj);
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
			try
			{
				IList<(uint, uint)> readerList = await ReaderFile.ReaderTxtFile.ReadFile(Path.Combine("InputFile", "InputDefault.txt"));

                var test = Wood.CreateWood(readerList);
            }
			catch
			{
                Console.WriteLine("Произошла ошибка");
			}
        }
	}
}
