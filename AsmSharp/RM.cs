namespace AsmSharp
{
    public enum RM
    {
        About_EAX = 0b_000,
        About_ECX = 0b_001,
        About_EDX = 0b_010,
        About_EBX = 0b_011,
        About_ESP_SIB = 0b_100,
        About_EBP_Disp32 = 0b_101,
        About_ESI = 0b_110,
        About_EDI = 0b_111,
    }
}
