using System;
using System.Collections.Generic;
using System.IO;

namespace Testing_Metro_App.ReaderFile
{
	internal static class ReaderTxtFile
    {
        internal static bool ReadFile(string path, out IList<(uint, uint)> result)
        {
            result = new List<(uint, uint)>();
            try
            {
                
                using (StreamReader streamReader = new(path))
                {
                    
                }

                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }
    }
}