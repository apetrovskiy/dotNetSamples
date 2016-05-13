namespace impersonateItForService.Runners.Helpers
{
    using Microsoft.Win32.SafeHandles;

    public sealed class SafeTokenHandle : SafeHandleZeroOrMinusOneIsInvalid
    {
        SafeTokenHandle()
            : base(true)
        {
        }

        protected override bool ReleaseHandle()
        {
            return NativeMethods.CloseHandle(handle);
        }
    }
}