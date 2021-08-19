namespace AsmSharp
{
    public partial class AsmScope
    {
        public AsmScope Mul(Register reg)
        {
            Append(0xF7);
            Append(new ModRM(OpCode.s4, reg));
            return this;
        }

    }
}
