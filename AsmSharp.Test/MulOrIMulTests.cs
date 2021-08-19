using Xunit;

namespace AsmSharp.Test
{
    public class MulOrIMulTests
    {
        private delegate int AsmRetInt32();

        [Fact]
        public void MulTest()
        {
            using var _asm = Asm.BeginScope();
            _asm.Push(Register.EBP)
                .Mov(Register.EAX, 0x7fffffff)
                .Mov(Register.ECX, 0xff)
                .Mul(Register.ECX)
                .Mov(Register.EAX, Register.EDX)
                .Pop(Register.EBP)
                .Ret();
            var number = _asm.Execute<AsmRetInt32, int>();
            Assert.Equal(0x7f, number);
        }

    }
}
