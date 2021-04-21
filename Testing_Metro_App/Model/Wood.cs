using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Testing_Metro_App.Model
{
    internal static class Wood
    {
#region Static Fields and Constants

        private const uint MaxCountNodes = 1000;
        private const uint MinCountNodes = 1;

#endregion

#region Methods

        internal static string[] CreateWood(IList<(uint, uint)> nodes)
        {
            try
            {
                if (!DataIsValidity(nodes[0].Item1))
                    throw new InvalidDataException
                    (
                        $"Количество узлов не входит в ограничения {MinCountNodes} <= N <= {MaxCountNodes}"
                    );

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
                    int maxIndex = indexColumn.Last();
                    RecursiveFindValue(indexColumn);
                    if (localIterationCountConnection.Count != maxIndex + 1)
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
                        if (list.Count != default) RecursiveFindValue(list);
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

        private static bool DataIsValidity(uint countNodes) =>
            countNodes is >=MinCountNodes and <=MaxCountNodes;

#endregion
    }
}