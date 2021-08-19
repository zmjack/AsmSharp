namespace AsmSharp
{
    public partial class AsmScope
    {
        public AsmScope Label(string label)
        {
            LabelOffsets[label] = MemoryLengthInt32;
            return this;
        }

    }
}
