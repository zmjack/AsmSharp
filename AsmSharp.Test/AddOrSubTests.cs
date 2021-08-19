using Xunit;

namespace AsmSharp.Test
{
    public class AddOrSubTests
    {
        private delegate int AsmRetInt32();

        [Fact]
        public void AddTest()
        {
            using var _asm = Asm.BeginScope();
            _asm.Push(Register.EBP)
                .Mov(Register.EAX, 128)
                .Mov(Register.EBX, 256)
                .Add(Register.EAX, Register.EBX)
                .Add(Register.EAX, 16)
                .Pop(Register.EBP)
                .Ret();
            var number = _asm.Execute<AsmRetInt32, int>();
            Assert.Equal(400, number);
        }

        [Fact]
        public void SubTest()
        {
            using var _asm = Asm.BeginScope();
            _asm.Push(Register.EBP)
                .Mov(Register.EAX, 400)
                .Mov(Register.EBX, 256)
                .Sub(Register.EAX, Register.EBX)
                .Sub(Register.EAX, 16)
                .Pop(Register.EBP)
                .Ret();
            var number = _asm.Execute<AsmRetInt32, int>();
            Assert.Equal(128, number);
        }

    }
}
