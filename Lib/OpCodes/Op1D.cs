using Mutsuki.Extension;

namespace Mutsuki.Lib.OpCodes;

// One byte entry count, the selector Value, then that many 32-bit targets.
[OpControl(0x1d, "Gosub Table")]
public class Op1D : IOpControl
{
    public static string ToCommand(BinaryReader reader, StringMessage message)
    {
        var count = reader.ReadByte();
        var selector = reader.ReadValue();
        var targets = new int[count];
        for (var i = 0; i < count; i++)
        {
            targets[i] = reader.ReadInt32Le();
        }

        return $"Gosub Table, Jump, Command: 1D, Count: {count}, Arguments: {selector}, Ptrs: {string.Join(", ", targets)}";
    }
}
