using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

using static Testing_Metro_App.Logger.Logger;

namespace Testing_Metro_App.ReaderFile
{
    internal static class ReaderTxtFile
    {
        internal static async Task<IList<(uint, uint)>> ReadFile(string path)
        {
            IList<(uint, uint)> result = new List<(uint, uint)>();

            try
            {
                using (StreamReader streamReader = new(path))
                {
                    uint numberLine = default;

                    while (true)
                    {
                        string line = await streamReader.ReadLineAsync();
                        line = line.Trim(' ');

                        if (line is null) break;

                        string[] stringArray = line.Split(" ");
                        numberLine++;

                        if (!uint.TryParse(stringArray[0], out uint item1) 
                            && !uint.TryParse(stringArray[1], out uint item2))
                            throw new ArgumentException
                            (
                                $"В чтении строки произошла ошибка: невозможно преобразовать строку в целое число (номер строки {numberLine})"
                            );
                    }
                }

                return result;
            }
            catch (Exception e)
            {
                Instance.OnPrintError(e);

                return null;
            }
        }
    }
}