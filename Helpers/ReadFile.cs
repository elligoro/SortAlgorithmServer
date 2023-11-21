using System;
using System.IO;
using System.Threading.Tasks;

namespace FileUtils
{
    public static class ReadFile
    {

        public async static Task<string[]> Read(string path)
        {
            return await File.ReadAllLinesAsync(path);
        }
    }
}

