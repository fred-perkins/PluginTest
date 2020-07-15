using System;
using System.Linq;
using System.Reflection;

namespace PluginHost
{
    public class PluginLoader
    {
        private readonly IAssemblyLoadContext assemblyLoadContext;

        public PluginLoader(IAssemblyLoadContext assemblyLoadContext)
        {
            this.assemblyLoadContext = assemblyLoadContext;
        }

        public IPlugin LoadPlugin(string name)
        {
            AssemblyName assemblyName = new AssemblyName(name);
            var assembly = assemblyLoadContext.Load(assemblyName);
            return InitialisePlugin(assembly);
        }

        public IPlugin LoadPlugin(Assembly assembly)
        {
            return InitialisePlugin(assembly);
        }

        public IPlugin LoadPlugin(byte[] assemblyBinary, byte[] pdbBinary = null)
        {
            var assembly = assemblyLoadContext.Load(assemblyBinary, pdbBinary);
            return InitialisePlugin(assembly);
        }

        private static IPlugin InitialisePlugin(Assembly assembly)
        {
            if (assembly == null)
                return null;

            foreach(var pluginType in assembly.GetExportedTypes())
            {
                if(typeof(IPlugin).IsAssignableFrom(pluginType))
                {
                    var plugin = (IPlugin)Activator.CreateInstance(pluginType);
                    //plugin?.Initialise();
                    return plugin;
                }
            }

            return null;
        }
    }
}
