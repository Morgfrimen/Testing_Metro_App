using System;

namespace Testing_Metro_App.Logger
{
    internal sealed class Logger
    {
#region Static Fields and Constants

        private static Logger _instance;

#endregion

#region Events

        internal event Action<Exception> PrintErrorEvents;
        internal event Action<string> PrintWarringEvents;

#endregion

#region Constructors

        private Logger() { }

#endregion

#region Properties

        internal static Logger Instance
        {
            get => _instance ??= new Logger();
        }

#endregion

#region Methods

        internal void OnPrintError(Exception obj)
        {
            this.PrintErrorEvents?.Invoke(obj);
        }


        internal void OnPrintWarring(string obj)
        {
            this.PrintWarringEvents?.Invoke(obj);
        }

#endregion
    }
}