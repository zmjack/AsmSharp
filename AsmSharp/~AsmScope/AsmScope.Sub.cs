using System;

namespace AsmSharp
{
    public partial class AsmScope
    {
        public AsmScope Sub(Register reg, int value)
        {
            Append(0x81);
            Append(new ModRM(OpCode.s5, reg));
            Append(BitConverter.GetBytes(value));
            return this;
        }

        public AsmScope Sub(Register reg, Pointer ptr)
        {
            if (ptr.SegLength != IntPtr.Size) throw OperandSizeConflictException;

            Append(0x2B);
            Append(new ModRM(reg, ptr));
            AppendIf(ptr.IntPtr.HasValue, ptr.GetIntPtrBytes());
            return this;
        }

        public AsmScope Sub(Register reg0, Register reg1)
        {
            Append(0x2B);
            Append(new ModRM(reg0, reg1));
            return this;
        }

        public AsmScope Sub(Pointer ptr, int value)
        {
            if (ptr.SegLength != IntPtr.Size) throw OperandSizeConflictException;

            Append(0x81);
            Append(new ModRM(OpCode.s5, ptr));
            AppendIf(ptr.IntPtr.HasValue, ptr.GetIntPtrBytes());
            Append(BitConverter.GetBytes(value));
            return this;
        }

        public AsmScope Sub(Pointer ptr, Register reg)
        {
            if (ptr.SegLength != IntPtr.Size) throw OperandSizeConflictException;

            Append(0x29);
            Append(new ModRM(reg, ptr));
            AppendIf(ptr.IntPtr.HasValue, ptr.GetIntPtrBytes());
            return this;
        }

    }
}
