namespace Testing_Metro_App.Model
{
    internal sealed class Node : INodeData
    {
#region Fields

        private readonly INodeData _nodeDataLast;
        private readonly INodeData _nodeDataNextLeft;
        private readonly INodeData _nodeDataNextRight;

#endregion

#region Constructors

        internal Node(INodeData nodeDataLast) => _nodeDataLast = nodeDataLast;

        internal Node(INodeData nodeDataLast, INodeData nodeDataNextLeft, INodeData nodeDataNextRight) : this(nodeDataLast)
        {
            _nodeDataNextLeft = nodeDataNextLeft;
            _nodeDataNextRight = nodeDataNextRight;
        }

#endregion

#region Properties

        INodeData INodeData.NodeDataLast
        {
            get => _nodeDataLast;
        }

        INodeData INodeData.NodeDataNextLeft
        {
            get => _nodeDataNextLeft;
        }

        INodeData INodeData.NodeDataNextRight
        {
            get => _nodeDataNextRight;
        }

        uint INodeData.Index { get; init; }

#endregion
    }
}