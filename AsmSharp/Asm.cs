using System;

namespace AsmSharp
{
    public static class Asm
    {
        public static AsmScope BeginScope()
        {
            if (Environment.Is64BitProcess) throw new PlatformNotSupportedException("Only x86 is supported.");
            return new();
        }
    }
}
