using System;
using System.Collections.Generic;
using System.Text;

namespace AsmSharp
{
    public struct Segment
    {
        public byte? RexPrefix { get; }
        public byte? OpCode { get; }
        public byte? ModRM { get; }
        public byte? SIB { get; }
        public byte[] Displacement { get; }
        public byte[] Immediate { get; }

        public Segment(byte opcode)
        {
            RexPrefix = null;
            OpCode = opcode;
            ModRM = null;
            SIB = null;
            Displacement = null;
            Immediate = null;
        }

        public Segment(byte opcode, ModRM modRM)
        {
            RexPrefix = null;
            OpCode = opcode;
            ModRM = modRM.Value;
            SIB = null;
            Displacement = null;
            Immediate = null;
        }

        public Segment(byte opcode, ModRM modRM, int immediate)
        {
            RexPrefix = null;
            OpCode = opcode;
            ModRM = modRM.Value;
            SIB = null;
            Displacement = null;
            Immediate = BitConverter.GetBytes(immediate);
        }

        public Segment(byte opcode, ModRM modRM, uint immediate)
        {
            RexPrefix = null;
            OpCode = opcode;
            ModRM = modRM.Value;
            SIB = null;
            Displacement = null;
            Immediate = BitConverter.GetBytes(immediate);
        }

        public Segment(byte opcode, ModRM modRM, float immediate)
        {
            RexPrefix = null;
            OpCode = opcode;
            ModRM = modRM.Value;
            SIB = null;
            Displacement = null;
            Immediate = BitConverter.GetBytes(immediate);
        }

        public Segment(byte opcode, ModRM modRM, IntPtr displacement)
        {
            RexPrefix = null;
            OpCode = opcode;
            ModRM = modRM.Value;
            SIB = null;
            Displacement = Environment.Is64BitProcess ? BitConverter.GetBytes(displacement.ToInt64()) : BitConverter.GetBytes(displacement.ToInt32());
            Immediate = null;
        }

        public Segment(byte opcode, ModRM modRM, IntPtr displacement, int immediate)
        {
            RexPrefix = null;
            OpCode = opcode;
            ModRM = modRM.Value;
            SIB = null;
            Displacement = Environment.Is64BitProcess ? BitConverter.GetBytes(displacement.ToInt64()) : BitConverter.GetBytes(displacement.ToInt32());
            Immediate = BitConverter.GetBytes(immediate);
        }

        public Segment(byte opcode, ModRM modRM, IntPtr displacement, uint immediate)
        {
            RexPrefix = null;
            OpCode = opcode;
            ModRM = modRM.Value;
            SIB = null;
            Displacement = Environment.Is64BitProcess ? BitConverter.GetBytes(displacement.ToInt64()) : BitConverter.GetBytes(displacement.ToInt32());
            Immediate = BitConverter.GetBytes(immediate);
        }

        public Segment(byte opcode, ModRM modRM, IntPtr displacement, float immediate)
        {
            RexPrefix = null;
            OpCode = opcode;
            ModRM = modRM.Value;
            SIB = null;
            Displacement = Environment.Is64BitProcess ? BitConverter.GetBytes(displacement.ToInt64()) : BitConverter.GetBytes(displacement.ToInt32());
            Immediate = BitConverter.GetBytes(immediate);
        }

    }
}
