using System;
using System.Runtime.InteropServices;
using System.Security.Permissions;

namespace tgacutil {
    [ComImport, Guid( "e707dcde-d1cd-11d2-bab9-00c04f8eceae" ), InterfaceType( ComInterfaceType.InterfaceIsIUnknown )]
    public interface IAssemblyCache {
        [PreserveSig]
        int UninstallAssembly(
            uint dwFlags,
            [MarshalAs( UnmanagedType.LPWStr )] string pszAssemblyName,
            [MarshalAs( UnmanagedType.LPArray )] FUSION_INSTALL_REFERENCE[] pRefData,
            out UninstallStatus pulDisposition
        );

        [PreserveSig]
        int QueryAssemblyInfo(
            QueryAsmInfoFlag dwFlags,
            [MarshalAs( UnmanagedType.LPWStr )] string pszAssemblyName,
            ref ASSEMBLY_INFO pAsmInfo
        );

        [PreserveSig]
        int Dummy1();

        [PreserveSig]
        int Dummy2();

        [PreserveSig]
        int InstallAssembly(
            uint dwFlags,
            [MarshalAs( UnmanagedType.LPWStr )] string pszManifestFilePath,
            [MarshalAs( UnmanagedType.LPArray )] FUSION_INSTALL_REFERENCE[] pRefData
        );
    }

    [StructLayout( LayoutKind.Sequential, CharSet = CharSet.Unicode )]
    public struct FUSION_INSTALL_REFERENCE {
        public uint cbSize;
        public uint dwFlags;
        public Guid guidScheme;
        public string szIdentifier;
        public string szNonCannonicalData;
    }

    [StructLayout( LayoutKind.Sequential )]
    public struct ASSEMBLY_INFO {
        public int cbAssemblyInfo;
        public int assemblyFlags;
        public long assemblySizeInKB;

        [MarshalAs( UnmanagedType.LPWStr )]
        public String currentAssemblyPath;

        public int cchBuf;
    }

    public enum QueryAsmInfoFlag {
        Validate = 1,
        GetSize = 2
    }

    public enum UninstallStatus {
        None = 0,
        Uninstalled = 1,
        StillInUse = 2,
        AlreadyUninstalled = 3,
        DeletePending = 4,
        HasInstallReferences = 5,
        ReferenceNotFound = 6
    }
}
