using System;
using System.IO;

namespace TestApp
{
    class Start
    {
        static void Main(string[] args)
        {
            Program Monitor = new Program(args[0], args[1], args[2]);
            new System.Threading.Timer(Monitor.Test, null, TimeSpan.FromSeconds(0), TimeSpan.FromSeconds(Int32.Parse(Monitor.Count)));
            Console.ReadKey();

        }   
    }
}
