# tgacutil
Tiny version of gacutil.exe which can only install and uninstall assemblies into/from GAC.

## Usage
tgacutil {/i|/u} Assembly [Assembly]...  
/i : Install assemblies into GAC. Specify assemblies by full-path.  
/u : Uninstall assemblies from GAC. Specify assemblies by assembly name.

## Example
tgacutil /i C:\foo\bar\bin\MyDLL.dll  
tgacutil /u MyDLL
