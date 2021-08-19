namespace AsmSharp
{
    public partial class AsmScope
    {
        public AsmScope PushFD() { Append(0x9C); return this; }
        public AsmScope Ret() { Append(0xC3); return this; }

    }
}
