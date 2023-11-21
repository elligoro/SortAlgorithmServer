using FileUtils;
using Sort;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.WebSockets;
using System.Threading.Tasks;

namespace Api.Business
{
    public class SortBusiness : ISortBusiness
    {
        private async Task<string[]> Sort(SortBase<string> sort, 
                                          Action<string[]> action,
                                          string fileName = "tiny.txt")
        {
            var fileLines = await ReadFile.Read(fileName ?? "");
            int.TryParse(fileLines[0], out int n);

            string[] lineVals = null;

            for (var i = 0; fileLines.Length > i; i++)
            {
                lineVals = fileLines[i].Split(" ");
                lineVals = sort.Sort(lineVals,action);
            }
            return lineVals;
        }

        public async Task<string[]> OperationTypeBy(string opType, 
                                                    Action<string[]> action)
        {
            string[] lineVals = null;
            switch (opType)
            {
                case "basic_sort":
                    lineVals = await Sort(new BasicSort<string>(), action);
                    break;
                case "insertion_sort":
                    lineVals = await Sort(new InsertionSort<string>(), action);
                    break;
                case "shell_sort":
                    lineVals = await Sort (new ShellSort<string>(), action);
                    break;
            }

            return lineVals;
        }
    }

    public interface ISortBusiness
    {
        Task<string[]> OperationTypeBy(string opType, Action<string[]> action);
    }
}
