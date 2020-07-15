using System;
using System.Diagnostics;
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
            //Running Debugger.Break(); throws the following exception in WASM
            //dotnet.3.2.0.js:1 Uncaught (in promise) RuntimeError: abort(undefined). Build with -s ASSERTIONS=1 for more info.
            //    at abort (https://localhost:5001/_framework/wasm/dotnet.3.2.0.js:1:16061)
            //    at _abort (https://localhost:5001/_framework/wasm/dotnet.3.2.0.js:1:112430)
            //    at stub_debugger_agent_user_break (<anonymous>:wasm-function[4142]:0xb7d23)
            //    at do_debugger_tramp (<anonymous>:wasm-function[1897]:0x50b9f)
            //    at interp_exec_method (<anonymous>:wasm-function[1120]:0x250f6)
            //    at interp_runtime_invoke (<anonymous>:wasm-function[5655]:0xf7391)
            //    at mono_jit_runtime_invoke (<anonymous>:wasm-function[5109]:0xddb3d)
            //    at do_runtime_invoke (<anonymous>:wasm-function[1410]:0x3ba85)
            //    at mono_runtime_try_invoke (<anonymous>:wasm-function[418]:0xcfdb)
            //    at mono_runtime_invoke (<anonymous>:wasm-function[1610]:0x44b39)
            Console.WriteLine($"[{nameof(StandalonePlugin)}]{nameof(Initialise)}");
        }
    }
}
