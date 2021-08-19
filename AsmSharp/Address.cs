namespace AsmSharp
{
    public enum Address
    {
        // Mod = 0b_00
        EAXv = 0b_00_000_000,
        ECXv = 0b_00_000_001,
        EDXv = 0b_00_000_010,
        EBXv = 0b_00_000_011,
        SIB = 0b_00_000_100,
        Disp32 = 0b_00_000_101,
        ESIv = 0b_00_000_110,
        EDIv = 0b_00_000_111,

        // Mod = 0b_01
        EAXv_pDisp8 = 0b_01_000_000,
        ECXv_pDisp8 = 0b_01_000_001,
        EDXv_pDisp8 = 0b_01_000_010,
        EBXv_pDisp8 = 0b_01_000_011,
        SIB_pDisp8 = 0b_01_000_100,
        EBPv_pDisp8 = 0b_01_000_101,
        ESIv_pDisp8 = 0b_01_000_110,
        EDIv_pDisp8 = 0b_01_000_111,

        // Mod = 0b_10
        EAXv_pDisp32 = 0b_10_000_000,
        ECXv_pDisp32 = 0b_10_000_001,
        EDXv_pDisp32 = 0b_10_000_010,
        EBXv_pDisp32 = 0b_10_000_011,
        SIB_pDisp32 = 0b_10_000_100,
        EBPv_pDisp32 = 0b_10_000_101,
        ESIv_pDisp32 = 0b_10_000_110,
        EDIv_pDisp32 = 0b_10_000_111,

        // Mod = 0b_11
        EAX = 0b_11_000_000,
        ECX = 0b_11_000_001,
        EDX = 0b_11_000_010,
        EBX = 0b_11_000_011,
        ESP = 0b_11_000_100,
        EBP = 0b_11_000_101,
        ESI = 0b_11_000_110,
        EDI = 0b_11_000_111,
    }
}
