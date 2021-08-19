using System;

namespace AsmSharp
{
    public struct Pointer
    {
        /// <summary>
        /// Pointer of 1 byte data.
        /// </summary>
        /// <param name="ptr"></param>
        /// <returns></returns>
        public static Pointer BytePtr(IntPtr ptr) => new(ptr, 1);
        /// <summary>
        /// Pointer of 1 byte data.
        /// </summary>
        /// <param name="ptr"></param>
        /// <returns></returns>
        public static unsafe Pointer BytePtr(void* ptr) => new((IntPtr)ptr, 1);
        /// <summary>
        /// Pointer of 1 byte data.
        /// </summary>
        /// <param name="ptr"></param>
        /// <returns></returns>
        public static Pointer BytePtr(Register reg) => new(reg, 1);

        /// <summary>
        /// Pointer of 2 bytes data.
        /// </summary>
        /// <param name="ptr"></param>
        /// <returns></returns>
        public static Pointer WordPtr(IntPtr ptr) => new(ptr, 2);
        /// <summary>
        /// Pointer of 2 bytes data.
        /// </summary>
        /// <param name="ptr"></param>
        /// <returns></returns>
        public static unsafe Pointer WordPtr(void* ptr) => new((IntPtr)ptr, 2);
        /// <summary>
        /// Pointer of 2 bytes data.
        /// </summary>
        /// <param name="ptr"></param>
        /// <returns></returns>
        public static Pointer WordPtr(Register reg) => new(reg, 2);

        /// <summary>
        /// Pointer of 4 bytes data.
        /// </summary>
        /// <param name="ptr"></param>
        /// <returns></returns>
        public static Pointer DwordPtr(IntPtr ptr) => new(ptr, 4);
        /// <summary>
        /// Pointer of 4 bytes data.
        /// </summary>
        /// <param name="ptr"></param>
        /// <returns></returns>
        public static unsafe Pointer DwordPtr(void* ptr) => new((IntPtr)ptr, 4);
        /// <summary>
        /// Pointer of 4 bytes data.
        /// </summary>
        /// <param name="ptr"></param>
        /// <returns></returns>
        public static Pointer DwordPtr(Register reg) => new(reg, 4);

        /// <summary>
        /// Pointer of 8 bytes data.
        /// </summary>
        /// <param name="ptr"></param>
        /// <returns></returns>
        public static Pointer QwordPtr(IntPtr ptr) => new(ptr, 8);
        /// <summary>
        /// Pointer of 8 bytes data.
        /// </summary>
        /// <param name="ptr"></param>
        /// <returns></returns>
        public static unsafe Pointer QwordPtr(void* ptr) => new((IntPtr)ptr, 8);
        /// <summary>
        /// Pointer of 8 bytes data.
        /// </summary>
        /// <param name="ptr"></param>
        /// <returns></returns>
        public static unsafe Pointer QwordPtr(Register reg) => new(reg, 8);

        public Register? Register { get; }
        public IntPtr? IntPtr { get; }
        public int SegLength { get; }
        public byte[] GetIntPtrBytes() => IntPtr.HasValue ? BitConverter.GetBytes(IntPtr.Value.ToInt32()) : null;

        private Pointer(IntPtr ptr, int segLength)
        {
            Register = null;
            IntPtr = ptr;
            SegLength = segLength;
        }

        private Pointer(Register reg, int segLength)
        {
            Register = reg;
            IntPtr = null;
            SegLength = segLength;
        }

    }
}
