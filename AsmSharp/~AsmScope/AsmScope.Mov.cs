using System;

namespace AsmSharp
{
    public partial class AsmScope
    {
        public AsmScope Mov(Register reg, int value)
        {
            switch (reg)
            {
                case Register.EAX: Append(0xB8); break;
                case Register.ECX: Append(0xB9); break;
                case Register.EDX: Append(0xBA); break;
                case Register.EBX: Append(0xBB); break;
                case Register.ESP: Append(0xBC); break;
                case Register.EBP: Append(0xBD); break;
                case Register.ESI: Append(0xBE); break;
                case Register.EDI: Append(0xBF); break;
                default: throw new NotImplementedException();
            };
            Append(BitConverter.GetBytes(value));
            return this;
        }

        public AsmScope Mov(Register reg, Pointer ptr)
        {
            if (ptr.SegLength != IntPtr.Size) throw OperandSizeConflictException;

            Append(0x8B);
            Append(new ModRM(reg, ptr));
            AppendIf(ptr.IntPtr.HasValue, ptr.GetIntPtrBytes());
            return this;
        }

        public AsmScope Mov(Register reg0, Register reg1)
        {
            Append(0x8B);
            Append(new ModRM(reg0, reg1));
            return this;
        }

        public AsmScope Mov(Pointer ptr, int value)
        {
            if (ptr.SegLength != IntPtr.Size) throw OperandSizeConflictException;

            Append(0xC7);
            Append(new ModRM(OpCode.s0, ptr));
            AppendIf(ptr.IntPtr.HasValue, ptr.GetIntPtrBytes());
            Append(BitConverter.GetBytes(value));
            return this;
        }

        public AsmScope Mov(Pointer ptr, Register reg)
        {
            if (ptr.SegLength != IntPtr.Size) throw OperandSizeConflictException;

            Append(0x89);
            Append(new ModRM(reg, ptr));
            AppendIf(ptr.IntPtr.HasValue, ptr.GetIntPtrBytes());
            return this;
        }

    }
}
