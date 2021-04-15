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


        internal event Action<Exception> PrintErrorEvents;
        internal event Action<string> PrintWarring; 

        internal void OnPrintError(Exception obj)
        {
            this.PrintErrorEvents?.Invoke(obj);
        }


        internal void OnPrintWarring(string obj)
        {
            this.PrintWarring?.Invoke(obj);
        }
    }
}