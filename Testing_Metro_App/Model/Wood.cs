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
                uint maxIndexMatrix;
                uint[,] matrix;
                CreateMatrixConnection();
                string[] str = GetResultOutput(taskCreateIndexList.Result, maxIndexMatrix);

                return str;

#region LocalMethod

                void CreateMatrixConnection()
                {
                    uint maxValueT1 = nodes.Max(item => item.Item1);
                    uint maxValueT2 = nodes.Max(item => item.Item2);
                    maxIndexMatrix = new[] {maxValueT1, maxValueT2}.Max();
                    matrix = new uint[maxIndexMatrix, maxIndexMatrix];
                    maxIndexMatrix -= 1;
                    taskCreateIndexList = Task.Run(() => GetList(maxIndexMatrix));

                    foreach ((uint, uint) valueTuple in nodes)
                    {
                        if (valueTuple.Item1 == valueTuple.Item2)
                            throw new ArgumentException
                                ("Строка в input.txt не может быть одинакова");

                        uint index1 = valueTuple.Item1 - 1;
                        uint index2 = valueTuple.Item2 - 1;

                        if (matrix[index1, index2] != 0 || matrix[index2, index1] != 0)
                            throw new InvalidOperationException
                                ("В строке есть повторяющиеся соединения");

                        matrix[index1, index2] = 1;
                        matrix[index2, index1] = 1;
                    }
                }

                Task<IList<int>> GetList(uint maxIndexMatrix)
                {
                    IList<int> listIndex = new List<int>();
                    for (int index = 0; index <= maxIndexMatrix; index++) listIndex.Add(index);

                    return Task.FromResult(listIndex);
                }

                string[] GetResultOutput(IList<int> indexColumn, uint maxIndex)
                {
                    List<string> result = new();
                    List<int> localIterationCountConnection = new();
                    uint countIteration = 1;
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
                        list = list.Union(localIterationCountConnection).ToList();
                        if (countIteration != maxIndexMatrix + 1) RecursiveFindValue(list);
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