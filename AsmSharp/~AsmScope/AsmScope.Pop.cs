using System;

namespace AsmSharp
{
    public partial class AsmScope
    {
        public AsmScope Pop(Register reg)
        {
            switch (reg)
            {
                case Register.EAX: Append(0x58); break;
                case Register.ECX: Append(0x59); break;
                case Register.EDX: Append(0x5A); break;
                case Register.EBX: Append(0x5B); break;
                case Register.ESP: Append(0x5C); break;
                case Register.EBP: Append(0x5D); break;
                default: throw new NotImplementedException();
            };
            return this;
        }

        public AsmScope Pop(SegRegister reg)
        {
            switch (reg)
            {
                case SegRegister.CS: throw ImproperOperandTypeException;
                case SegRegister.DS: Append(0x1F); break;
                case SegRegister.SS: Append(0x17); break;
                case SegRegister.ES: Append(0x07); break;
                case SegRegister.FS: Append(0x0F, 0xA1); break;
                case SegRegister.GS: Append(0x0F, 0xA9); break;
                default: throw new NotImplementedException();
            };
            return this;
        }

    }
}
