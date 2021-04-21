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
        private const uint DefaultWeightConnection = 1;
        private const uint StartFindCountConnection = 1;

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

                uint[,] matrix = new uint[nodes[0].Item1, nodes[0].Item2];
                nodes.Remove(nodes[0]);
                Task<int[]> taskCreateIndexList = Task.Run(() => GetIndexList((uint)matrix.GetLength(0)));

                CreateMatrixConnection();
                string[] str = GetResultOutput(taskCreateIndexList.Result);

                return str;

#region LocalMethod

                void CreateMatrixConnection()
                {
                    uint indexCount = default;

                    foreach ((uint, uint) valueTuple in nodes)
                    {
                        matrix[valueTuple.Item1 - 1, indexCount] = DefaultWeightConnection;
                        matrix[valueTuple.Item2 - 1, indexCount] = DefaultWeightConnection;
                        indexCount++;
                    }
                }

                Task<int[]> GetIndexList(uint maxIndexMatrix)
                {
                    int[] listIndex = new int[maxIndexMatrix];
                    for (int index = 0; index < maxIndexMatrix; index++)
                        listIndex[index] = index;

                    return Task.FromResult(listIndex);
                }

                string[] GetResultOutput(IList<int> indexColumn)
                {
                    List<int> localIterationCountConnection = new();
                    uint countIteration = StartFindCountConnection;
                    int maxIndex = indexColumn[^1];
                    RecursiveFindValue(indexColumn);
                    if (localIterationCountConnection.Count != maxIndex + 1)
                        Logger.Logger.Instance.OnPrintWarring("Количество не сошлось...");

                    return GetResultStringArray(localIterationCountConnection);

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
                        }
                        
                        list = list.Except(localIterationCountConnection).ToList();
                        if (list.Count == default) return;

                        countIteration++;
                        RecursiveFindValue(list);
                    }

                    string[] GetResultStringArray(IList<int> listResult)
                    {
                        string[] result = new string[listResult.Count];

                        for (int index = 0; index < listResult.Count; index++)
                        {
                            result[index] = (listResult[index] + 1).ToString();
                        }

                        return result;
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