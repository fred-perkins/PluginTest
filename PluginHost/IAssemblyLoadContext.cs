using System;
using System.Reflection;

namespace PluginHost
{
    public interface IAssemblyLoadContext : IDisposable
    {
        Assembly Load(string name);

        Assembly Load(AssemblyName name);

        Assembly Load(byte[] assemblyBinary, byte[] pdbBinary = null);
    }
}
