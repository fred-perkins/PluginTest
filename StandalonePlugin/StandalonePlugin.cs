using System;
using PluginHost;

namespace StandalonePlugin
{
    public class StandalonePlugin : IPlugin
    {
        public void Dispose()
        {
            Console.WriteLine($"[{nameof(StandalonePlugin)}]{nameof(Dispose)}");
        }

        public void Initialise()
        {
            Console.WriteLine($"[{nameof(StandalonePlugin)}]{nameof(Initialise)}");
        }
    }
}
