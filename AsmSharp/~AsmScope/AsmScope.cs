using NStandard;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;

namespace AsmSharp
{
    public partial class AsmScope : Scope<AsmScope>
    {
        private const int EXECUTE_READWRITE = 0x40;
        [DllImport("kernel32.dll")] private static extern bool VirtualProtectEx(IntPtr hProcess, IntPtr lpAddress, uint dwSize, uint flNewProtect, out uint lpflOldProtect);

        private static readonly InvalidOperationException ImproperOperandTypeException = new("Improper operand type.");
        private static readonly InvalidOperationException OperandSizeConflictException = new("Operand size conflict.");

        internal AsmScope() { }

        private readonly MemoryStream Memory = new();
        private readonly Dictionary<string, int> LabelOffsets = new();
        private readonly Dictionary<int, string> Placeholders = new();

        private int MemoryLengthInt32
        {
            get
            {
                var length = (int)Memory.Length;
                if (length < 0) throw new InvalidOperationException("Failed to get memory length (Int32).");
                return length;
            }
        }

        public TReturn Execute<TAsmFunc, TReturn>() where TAsmFunc : Delegate => (TReturn)InnerExecute<TAsmFunc>();
        public void Execute<TAsmFunc>() where TAsmFunc : Delegate => InnerExecute<TAsmFunc>();

        private object InnerExecute<TAsmFunc>() where TAsmFunc : Delegate
        {
            var asmLength = MemoryLengthInt32;
            var ptr = Marshal.AllocHGlobal(asmLength);

            FillPlaceholders();
            var asmBytes = Memory.ToArray();

            Marshal.Copy(asmBytes, 0, ptr, asmLength);
            var handle = Process.GetCurrentProcess().Handle;
            try
            {
                var length = (uint)asmLength;
                if (VirtualProtectEx(handle, ptr, length, EXECUTE_READWRITE, out var oldProtect))
                {
                    var func = Marshal.GetDelegateForFunctionPointer<TAsmFunc>(ptr);
                    var ret = func.DynamicInvoke();
                    VirtualProtectEx(handle, ptr, length, oldProtect, out _);
                    return ret;
                }
                else throw new Win32Exception();
            }
            finally
            {
                Marshal.FreeHGlobal(ptr);
            }
        }

        private void FillPlaceholders()
        {
            var undefinedLabel = Placeholders.Values.FirstOrDefault(label => !LabelOffsets.Keys.Contains(label));
            if (undefinedLabel is not null) throw new InvalidOperationException($"Label is undefined. ({undefinedLabel})");

            foreach (var holder in Placeholders)
            {
                Memory.Seek(holder.Key, SeekOrigin.Begin);
                var address = LabelOffsets[holder.Value];
                var bytes = BitConverter.GetBytes(address);
                Memory.Write(bytes, 0, bytes.Length);
            }
            Memory.Seek(0, SeekOrigin.End);
        }

        public byte[] GetBytes() => Memory.ToArray();

        private void Append(byte op)
        {
            Memory.WriteByte(op);
        }
        private void Append(byte op0, byte op1)
        {
            Memory.WriteByte(op0);
            Memory.WriteByte(op1);
        }

        private void Append(ModRM modRM)
        {
            Memory.WriteByte(modRM.Value);
        }

        private void Append(byte[] bs0)
        {
            Memory.Write(bs0, 0, bs0.Length);
        }

        private void AppendIf(bool condition, byte[] bs0)
        {
            if (condition)
            {
                Memory.Write(bs0, 0, bs0.Length);
            }
        }

        private void Append(bool condition, byte[] bs0, byte[] bs1)
        {
            if (condition)
            {
                Memory.Write(bs0, 0, bs0.Length);
                Memory.Write(bs1, 0, bs1.Length);
            }
        }

    }
}
