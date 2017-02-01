using System;
using System.Runtime.InteropServices;

namespace tgacutil {
    internal static class NativeMethods {
        [DllImport( "fusion.dll" )]
        public static extern int CreateAssemblyCache( out IAssemblyCache ppAsmCache, int reserved );
    }
}
