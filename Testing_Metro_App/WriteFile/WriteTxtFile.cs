using System;
using System.IO;
using System.Threading.Tasks;

namespace Testing_Metro_App.WriteFile
{
    internal static class WriteTxtFile
    {
        private const string DefaultNameFolder = "OutputFile";
        private const string DefaultNameFile = "Output.txt";
        internal static async Task WriteInFile(string[] array)
        {
            try
            {
                if (!Directory.Exists(DefaultNameFolder))
                    Directory.CreateDirectory(DefaultNameFolder);
                await using StreamWriter streamWriter = new(Path.Combine(DefaultNameFolder, DefaultNameFile));
				foreach (string str in array)
				{
					await streamWriter.WriteLineAsync(str);
				}
			}
            catch (Exception e)
            {
                Logger.Logger.Instance.OnPrintError(e);
            }
        }
    }
}