using System;
using System.IO;
using System.Threading.Tasks;

namespace BlackbirdCs
{
    class Program
    {
        public static void Main(string[] args)
        {
            var fileName = Path.Combine(AppContext.BaseDirectory, "blackbird.json");

            var blackBird = new BlackBird();
            blackBird.Run(fileName).Wait();
        }
    }
}