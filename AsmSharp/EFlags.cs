namespace AsmSharp
{
    public struct EFlags
    {
        public int Value { get; }

        public EFlags(int value)
        {
            Value = value;
        }

        /// <summary>
        /// Identification Flag. Support for CPUID instruction if can be set.
        /// </summary>
        public int ID => (Value & 0b_00000000_00100000_00000000_00000000) > 0 ? 1 : 0;

        /// <summary>
        /// Virtual Interrupt Pending flag. Set if an interrupt is pending.
        /// </summary>
        public int VIP => (Value & 0b_00000000_00010000_00000000_00000000) > 0 ? 1 : 0;

        /// <summary>
        /// Virtual Interrupt Flag. Virtual image of IF.
        /// </summary>
        public int VIF => (Value & 0b_00000000_00001000_00000000_00000000) > 0 ? 1 : 0;

        /// <summary>
        /// Alignment Check. Set if alignment checking of memory references is done.
        /// </summary>
        public int AC => (Value & 0b_00000000_00000100_00000000_00000000) > 0 ? 1 : 0;

        /// <summary>
        /// Virtual-8086 Mode. Set if in 8086 compatibility mode.
        /// </summary>
        public int VM => (Value & 0b_00000000_00000010_00000000_00000000) > 0 ? 1 : 0;

        /// <summary>
        /// Resume Flag. Response to debug exceptions.
        /// </summary>
        public int RF => (Value & 0b_00000000_00000001_00000000_00000000) > 0 ? 1 : 0;

        /// <summary>
        /// Nested Task flag. Controls chaining of interrupts. Set if the current process is linked to the next process.
        /// </summary>
        public int NT => (Value & 0b_00000000_00000000_01000000_00000000) > 0 ? 1 : 0;

        /// <summary>
        /// I/O Privilege Level field (2 bits). I/O Privilege Level of the current process.
        /// </summary>
        public int IOPL => (Value & 0b_00000000_00000000_00110000_00000000) > 0 ? 1 : 0;

        /// <summary>
        /// Overflow Flag. Set if signed arithmetic operations result in a value too large for the register to contain.
        /// </summary>
        public int OF => (Value & 0b_00000000_00000000_00001000_00000000) > 0 ? 1 : 0;

        /// <summary>
        /// Direction Flag. Stream direction. If set, string operations will decrement their pointer rather than incrementing it, reading memory backwards.
        /// </summary>
        public int DF => (Value & 0b_00000000_00000000_00000100_00000000) > 0 ? 1 : 0;

        /// <summary>
        /// Interruption Flag. Set if interrupts are enabled.
        /// </summary>
        public int IF => (Value & 0b_00000000_00000000_00000010_00000000) > 0 ? 1 : 0;

        /// <summary>
        /// Trap Flag. Set if step by step debugging.
        /// </summary>
        public int TF => (Value & 0b_00000000_00000000_00000001_00000000) > 0 ? 1 : 0;

        /// <summary>
        /// Sign Flag. Set if the result of an operation is negative.
        /// </summary>
        public int SF => (Value & 0b_00000000_00000000_00000000_10000000) > 0 ? 1 : 0;

        /// <summary>
        /// Zero Flag. Set if the result of an operation is Zero (0).
        /// </summary>
        public int ZF => (Value & 0b_00000000_00000000_00000000_01000000) > 0 ? 1 : 0;

        /// <summary>
        /// Adjust Flag. Carry of Binary Code Decimal (BCD) numbers arithmetic operations.
        /// </summary>
        public int AF => (Value & 0b_00000000_00000000_00000000_00010000) > 0 ? 1 : 0;

        /// <summary>
        /// Parity Flag. Set if the number of set bits in the least significant byte is a multiple of 2.
        /// </summary>
        public int PF => (Value & 0b_00000000_00000000_00000000_00000100) > 0 ? 1 : 0;

        /// <summary>
        /// Carry Flag. Set if the last arithmetic operation carried (addition) or borrowed (subtraction) a bit beyond the size of the register. 
        /// </summary>
        public int CF => (Value & 0b_00000000_00000000_00000000_00000001) > 0 ? 1 : 0;

    }
}
