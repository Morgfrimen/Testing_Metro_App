namespace Testing_Metro_App.Model
{
    internal interface INodeData
    {
        internal uint Index { get; init; }
        internal INodeData NodeDataLast { get; }
        internal INodeData NodeDataNextLeft { get; }
        internal INodeData NodeDataNextRight { get; }
    }
}