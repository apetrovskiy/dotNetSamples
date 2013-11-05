Error reading content from C:\Program Files (x86)\SharpDevelop\4.3\data\templates\project\PowerShell\DefaultAssemblyInfo.cs:
System.IO.FileNotFoundException: Could not find file 'C:\Program Files (x86)\SharpDevelop\4.3\data\templates\project\PowerShell\DefaultAssemblyInfo.cs'.
File name: 'C:\Program Files (x86)\SharpDevelop\4.3\data\templates\project\PowerShell\DefaultAssemblyInfo.cs'
   at System.IO.__Error.WinIOError(Int32 errorCode, String maybeFullPath)
   at System.IO.FileStream.Init(String path, FileMode mode, FileAccess access, Int32 rights, Boolean useRights, FileShare share, Int32 bufferSize, FileOptions options, SECURITY_ATTRIBUTES secAttrs, String msgPath, Boolean bFromProxy, Boolean useLongPath, Boolean checkHost)
   at System.IO.FileStream..ctor(String path, FileMode mode, FileAccess access, FileShare share, Int32 bufferSize, FileOptions options, String msgPath, Boolean bFromProxy, Boolean useLongPath, Boolean checkHost)
   at System.IO.StreamReader..ctor(String path, Encoding encoding, Boolean detectEncodingFromByteOrderMarks, Int32 bufferSize, Boolean checkHost)
   at System.IO.File.InternalReadAllText(String path, Encoding encoding, Boolean checkHost)
   at System.IO.File.ReadAllText(String path)
   at ICSharpCode.SharpDevelop.Internal.Templates.FileDescriptionTemplate..ctor(XmlElement xml, String hintPath)