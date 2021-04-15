using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

using Testing_Metro_App.Model;
using Testing_Metro_App.ReaderFile;

namespace Testing_Metro_App
{
    internal class Program
    {
#region Constructors

        static Program()
        {
            Logger.Logger.Instance.PrintErrorEvents += Instance_PrintErrorEvents;
            Logger.Logger.Instance.PrintWarringEvents += Instance_PrintWarring;
            Console.ResetColor();
        }

#endregion

#region Methods

        private static void Instance_PrintErrorEvents(Exception obj)
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.BackgroundColor = ConsoleColor.White;
            Console.WriteLine(obj.Message);
        }

        private static void Instance_PrintWarring(string obj)
        {
            Console.WriteLine(obj);
        }

        private static async Task Main(string[] args)
        {
            try
            {
                IList<(uint, uint)> readerList = await ReaderTxtFile.ReadFile
                                                 (
                                                     Path.Combine("InputFile", "InputDefault.txt")
                                                 );
                await WriteFile.WriteTxtFile.WriteInFile(Wood.CreateWood(readerList));
            }
            catch
            {
                Console.WriteLine("Произошла ошибка");
            }
        }

#endregion
    }
}