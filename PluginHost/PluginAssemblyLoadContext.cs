using System;
using System.Reflection;

namespace PluginHost
{
    public class PluginAssemblyLoadContext : IAssemblyLoadContext
    {
        private AppDomain currentDomain;
        private bool disposedValue;

        public PluginAssemblyLoadContext()
        {
            try
            {
                currentDomain = AppDomain.CreateDomain(Guid.NewGuid().ToString());
            }
            catch
            {
                currentDomain = AppDomain.CurrentDomain;
            }
        }

        public Assembly Load(string name)
        {
            return currentDomain.Load(name);
        }

        public Assembly Load(byte[] assemblyBinary, byte[] pdbBinary = null)
        {
            if (pdbBinary is null)
            {
                return currentDomain.Load(assemblyBinary);
            }

            return currentDomain.Load(assemblyBinary, pdbBinary);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    AppDomain.Unload(currentDomain);
                }

                currentDomain = null;
                disposedValue = true;
            }
        }

        ~PluginAssemblyLoadContext()
        {
            // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
            Dispose(disposing: false);
        }

        public void Dispose()
        {
            // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }

        public Assembly Load(AssemblyName name)
        {
            return currentDomain.Load(name);
        }
    }
}
