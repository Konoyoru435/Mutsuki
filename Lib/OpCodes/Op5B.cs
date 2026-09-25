using Mutsuki.Extension;

namespace Mutsuki.Lib.OpCodes;

// Sub 01 and 02 both read a base Value followed by a 0x00-terminated Value list.
[OpControl(0x5b, "Bit/Val Block")]
public class Op5B : IOpControl
{
    public static string ToCommand(BinaryReader reader, StringMessage message)
    {
        var subCommand = reader.ReadByte();

        switch (subCommand)
        {
            case 0x01
            or 0x02:
                var start = reader.ReadValue();
                var values = reader.ReadValueList();
                return $"Bit/Val Block, {(subCommand == 0x01 ? "Val Block Set" : "Bit Block Set")}, Command: 5B {subCommand:X2}, Arguments: {start}, {string.Join(", ", values)}";
            default:
                return $"Bit/Val Block, No Operation, Command: 5B {subCommand:X2}";
        }
    }
}
