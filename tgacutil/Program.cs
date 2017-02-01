using System;
using System.Linq;
using System.IO;
using System.Runtime.InteropServices;
using System.Security.Permissions;

namespace tgacutil {
    class Program {
        [SecurityPermission( SecurityAction.Demand, UnmanagedCode = true )]
        static void Main( string[] args ) {
            if ( args.Length < 2 ) {
                Console.WriteLine( "Usage:" );
                Console.WriteLine( " tgacutil {/i|/u} Assembly [Assembly]..." );
                Console.WriteLine( " /i : Install assemblies into GAC. Specify assemblies by full-path." );
                Console.WriteLine( " /u : Uninstall assemblies from GAC. Specify assemblies by assembly name." );
                return;
            }

            string mode = args[ 0 ].ToLower();
            string[] assemblies = args.Skip( 1 ).ToArray();

            IAssemblyCache ac = null;
            int hr = NativeMethods.CreateAssemblyCache( out ac, 0 );

            foreach ( string assembly in assemblies ) {
                if ( mode == "/i" ) {
                    hr = ac.InstallAssembly( 0, assembly, null );
                    if ( hr == 0 ) {
                        Console.WriteLine( string.Format( "{0}: Installed", System.IO.Path.GetFileNameWithoutExtension( assembly ) ) );
                    }

                } else if ( mode == "/u" ) {
                    UninstallStatus result = 0;
                    ac.UninstallAssembly( 0, assembly, null, out result );
                    Console.WriteLine( string.Format( "{0}: {1}", Path.GetFileNameWithoutExtension( assembly ), result.ToString() ) );
                }
            }
        }
    }
}
