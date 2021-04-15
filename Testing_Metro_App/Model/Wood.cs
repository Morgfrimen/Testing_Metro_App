using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Testing_Metro_App.Model
{
    internal sealed class Wood
    {
#region Methods

        internal static string[] CreateWood(IList<(uint, uint)> nodes)
        {
            try
            {
                Task<IList<int>> taskCreateIndexList;
                uint[,] matrix;
                CreateMatrixConnection();
                string[] str = GetResultOutput(taskCreateIndexList.Result);

                return str;

#region LocalMethod

                void CreateMatrixConnection()
                {
                    matrix = new uint[nodes[0].Item1, nodes[0].Item2];
                    taskCreateIndexList = Task.Run(() => GetList(nodes[0].Item1 - 1));
                    nodes.Remove(nodes[0]);
                    
                    uint indexCount = default;
                    foreach ((uint, uint) valueTuple in nodes)
                    {
                        matrix[valueTuple.Item1 - 1, indexCount] = 1;
                        matrix[valueTuple.Item2 - 1, indexCount] = 1;
                        indexCount++;
                    }
                }

                Task<IList<int>> GetList(uint maxIndexMatrix)
                {
                    IList<int> listIndex = new List<int>();
                    for (int index = 0; index <= maxIndexMatrix; index++) listIndex.Add(index);

                    return Task.FromResult(listIndex);
                }

                string[] GetResultOutput(IList<int> indexColumn)
                {
                    List<string> result = new();
                    List<int> localIterationCountConnection = new();
                    uint countIteration = 1;
                    int maxIndex = indexColumn.Last() - 1;
                    RecursiveFindValue(indexColumn);
                    if (localIterationCountConnection.Count != maxIndex)
                        Logger.Logger.Instance.OnPrintWarring("Количество не сошлось...");

                    return result.ToArray();

#region LocalMethod

                    void RecursiveFindValue(IList<int> list)
                    {
                        foreach (int columnIndex in list)
                        {
                            uint localCount = 0;

                            for (int indexRow = 0; indexRow < maxIndex; indexRow++)
                            {
                                if (matrix[columnIndex, indexRow] != default) localCount++;
                            }

                            if (localCount != countIteration) continue;

                            localIterationCountConnection.Add(columnIndex);
                            result.Add((columnIndex + 1).ToString());
                        }

                        countIteration++;
                        list = list.Except(localIterationCountConnection).ToList();
                        if (countIteration != maxIndex + 1 || list.Count != default)
                            RecursiveFindValue(list);
                    }

#endregion
                }

#endregion
            }
            catch (Exception e)
            {
                Logger.Logger.Instance.OnPrintError(e);

                throw;
            }
        }

#endregion
    }
}