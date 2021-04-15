using System;

namespace Testing_Metro_App.Logger
{
    internal sealed class Logger
    {
        private Logger(){}

        private static Logger _instance;

        internal static Logger Instance
        {
            get => _instance ??= new Logger();
        }


        private event Action<Exception> PrintError;
    }
}