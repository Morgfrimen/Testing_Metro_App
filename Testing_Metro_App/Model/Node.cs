namespace Testing_Metro_App.Model
{
    internal sealed class Node : INodeData
    {
#region Fields

        private readonly INodeData _nodeDataLast;
        private readonly INodeData[] _nodeDataChild;

#endregion

#region Constructors

        internal Node(INodeData nodeDataLast) => _nodeDataLast = nodeDataLast;

        internal Node(INodeData nodeDataLast, INodeData[] nodeDataChild) : this(nodeDataLast) => _nodeDataChild = nodeDataChild;

#endregion

#region Properties

        INodeData INodeData.NodeDataLast
        {
            get => _nodeDataLast;
        }

        INodeData[] INodeData.NodeDataChild
        {
            get => _nodeDataChild;
        }

        uint INodeData.Index { get; init; }

#endregion
    }
}