using System;
using System.Collections.Generic;

namespace Testing_Metro_App.Model
{
	internal sealed class Wood
	{
		private readonly INodeData _firstNode;
		private Wood(INodeData firstNode) { _firstNode = firstNode; }

        internal static Wood CreateWood<T1, T2>(IList<(T1, T2)> nodes)
        {
			try
			{
				throw new NotImplementedException();
			}
			catch (Exception e)
			{
			    Logger.Logger.Instance.OnPrintError(e);

                throw;
            }
        }
	}
}