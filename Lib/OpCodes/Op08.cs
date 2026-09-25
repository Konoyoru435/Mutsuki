using Mutsuki.Extension;

namespace Mutsuki.Lib.OpCodes;

// sub_439900: sub 01 takes nothing, 10 and 11 each take one Value.
[OpControl(0x08, "Wave Sample")]
public class Op08 : IOpControl
{
    public static string ToCommand(BinaryReader reader, StringMessage message)
    {
        var subCommand = reader.ReadByte();

        switch (subCommand)
        {
            case 0x01:
                return "Wave Sample, Reset, Command: 08 01";
            case 0x10
            or 0x11:
                var offset = reader.ReadValue();
                return $"Wave Sample, Sample To Flags, Command: 08 {subCommand:X2}, Arguments: {offset}";
            default:
                return $"Wave Sample, No Operation, Command: 08 {subCommand:X2}";
        }
    }
}
