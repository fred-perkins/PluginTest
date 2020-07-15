using System;

namespace PluginHost
{
    [PluginLoader]
    public interface IPlugin : IDisposable
    {
        void Initialise();
    }

    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Interface, AllowMultiple = false, Inherited = true)]
    public class PluginLoaderAttribute : Attribute
    {
        public PluginLoaderAttribute()
        {
        }
    }
}
