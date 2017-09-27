using System;
using System.IO;

namespace BlackbirdCs
{
    class Program
    {
        static void Main(string[] args)
        {
            var fileName = Path.Combine(AppContext.BaseDirectory, "blackbird.json");
            var parameters = Parameters.CreateParametersFromJsonFile(fileName);
        }
    }
}