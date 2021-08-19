using Xunit;

namespace AsmSharp.Test
{
    public class EFlagsTests
    {
        private delegate int AsmRetInt32();

        [Fact]
        public void SFTest1()
        {
            using var _asm = Asm.BeginScope();
            _asm.Push(Register.EBP)
                .Mov(Register.EAX, 1)
                .Add(Register.EAX, -2)
                .PushFD()
                .Pop(Register.EAX)
                .Pop(Register.EBP)
                .Ret();
            var eflagsValue = _asm.Execute<AsmRetInt32, int>();
            var eflags = new EFlags(eflagsValue);
            Assert.Equal(1, eflags.SF);
        }

        [Fact]
        public void SFTest2()
        {
            using var _asm = Asm.BeginScope();
            _asm.Push(Register.EBP)
                .Mov(Register.EAX, 1)
                .Add(Register.EAX, 2)
                .PushFD()
                .Pop(Register.EAX)
                .Pop(Register.EBP)
                .Ret();
            var eflagsValue = _asm.Execute<AsmRetInt32, int>();
            var eflags = new EFlags(eflagsValue);
            Assert.Equal(0, eflags.SF);
        }
    }
}
