using Xunit;

namespace AsmSharp.Test
{
    public class MovTests
    {
        private delegate void AsmRetVoid();

        [Fact]
        public unsafe void Test()
        {
            int n1 = 1, n10 = 0;
            int eax = 0, ebx = 0, ecx = 0;

            using var _asm = Asm.BeginScope();
            _asm
                .Push(Register.EBP)
                .Mov(Register.EAX, 0x1)
                .Mov(Register.EBX, Register.EAX)
                .Mov(Register.ECX, Pointer.DwordPtr(&n1))
                .Mov(Pointer.DwordPtr(&n10), 0x10)
                .Mov(Pointer.DwordPtr(&eax), Register.EAX)
                .Mov(Pointer.DwordPtr(&ebx), Register.EBX)
                .Mov(Pointer.DwordPtr(&ecx), Register.ECX)
                .Pop(Register.EBP)
                .Ret();

            _asm.Execute<AsmRetVoid>();

            Assert.Equal(0x10, n10);
            Assert.Equal(0x01, eax);
            Assert.Equal(0x01, ebx);
            Assert.Equal(0x01, ecx);
        }

    }
}
