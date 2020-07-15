using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PluginHost;

namespace PluginTests.Client
{
    public class InnerPlugin : IPlugin
    {
        public void Dispose()
        {
            Console.WriteLine($"[{nameof(InnerPlugin)}]{nameof(Dispose)}");
        }

        public void Initialise()
        {
            Console.WriteLine($"[{nameof(InnerPlugin)}]{nameof(Initialise)}");
        } 
    }
}
