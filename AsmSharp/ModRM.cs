using System;

namespace AsmSharp
{
    public struct ModRM
    {
        public int Mod => (byte)((Value & 0b_11_000_000) >> 6);
        public RM RM => (RM)(Value & 0b_00_000_111);
        public Address Address => (Address)(Value & 0b_11_000_111);
        public Register Reg => (Register)((Value & 0b_00_111_000) >> 3);
        public byte Value { get; }

        public ModRM(byte regOrOpcode, Pointer effective)
        {
            if (effective.Register.HasValue)
            {
                var address = effective.Register switch
                {
                    Register.EAX => Address.EAXv,
                    Register.ECX => Address.ECXv,
                    Register.EDX => Address.EDXv,
                    Register.EBX => Address.EBXv,
                    Register.ESP => throw new NotSupportedException(),
                    Register.EBP => throw new NotSupportedException(),
                    Register.ESI => Address.ESIv,
                    Register.EDI => Address.EDIv,
                    _ => throw new NotImplementedException(),
                };
                Value = (byte)((int)address | regOrOpcode << 3);
            }
            else Value = (byte)((int)Address.Disp32 | regOrOpcode << 3);
        }

        public ModRM(byte regOrOpcode, Register effective)
        {
            var address = effective switch
            {
                Register.EAX => Address.EAX,
                Register.ECX => Address.ECX,
                Register.EDX => Address.EDX,
                Register.EBX => Address.EBX,
                Register.ESP => Address.ESP,
                Register.EBP => Address.EBP,
                Register.ESI => Address.ESI,
                Register.EDI => Address.EDI,
                _ => throw new NotImplementedException(),
            };
            Value = (byte)((int)address | regOrOpcode << 3);
        }

        public ModRM(byte value)
        {
            Value = value;
        }

        public bool Disp32Follows => Mod == 0b_00 && RM == RM.About_EBP_Disp32;
        public bool SIBFollows => Mod != 0b_11 && RM == RM.About_ESP_SIB;

    }
}
