using Mutsuki.Extension;

namespace Mutsuki.Lib.OpCodes;

// One byte entry count, the selector Value, then that many 32-bit targets.
[OpControl(0x1e, "Goto Table")]
public class Op1E : IOpControl
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

        return $"Goto Table, Jump, Command: 1E, Count: {count}, Arguments: {selector}, Ptrs: {string.Join(", ", targets)}";
    }
}
