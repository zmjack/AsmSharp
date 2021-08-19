using System;

namespace AsmSharp
{
    public partial class AsmScope
    {
        public AsmScope Push(Register reg)
        {
            switch (reg)
            {
                case Register.EAX: Append(0x50); break;
                case Register.ECX: Append(0x51); break;
                case Register.EDX: Append(0x52); break;
                case Register.EBX: Append(0x53); break;
                case Register.ESP: Append(0x54); break;
                case Register.EBP: Append(0x55); break;
                default: throw new NotImplementedException();
            };
            return this;
        }

        public AsmScope Push(SegRegister reg)
        {
            switch (reg)
            {
                case SegRegister.CS: Append(0x0E); break;
                case SegRegister.DS: Append(0x1E); break;
                case SegRegister.SS: Append(0x16); break;
                case SegRegister.ES: Append(0x06); break;
                case SegRegister.FS: Append(0x0F, 0xA0); break;
                case SegRegister.GS: Append(0x0F, 0xA8); break;
                default: throw new NotImplementedException();
            };
            return this;
        }

    }
}
