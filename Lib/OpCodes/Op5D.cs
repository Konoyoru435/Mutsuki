using Mutsuki.Extension;

namespace Mutsuki.Lib.OpCodes;

[OpControl(0x5d, "Bit Range")]
public class Op5D : IOpControl
{
    public static string ToCommand(BinaryReader reader, StringMessage message)
    {
        // The engine reads the sub-command and all three operands up front, then
        // dispatches; sub-commands other than 01/02 consume the same operands.
        var subCommand = reader.ReadByte();
        var start = reader.ReadValue();
        var flag = reader.ReadValue();
        var count = reader.ReadValue();

        var name = subCommand switch
        {
            0x01 => "Bit Range Set",
            0x02 => "Bit Range Fill",
            _ => "No Operation"
        };

        return $"Bit Range, {name}, Command: 5D {subCommand:X2}, Arguments: {start}, {flag}, {count}";
    }
}
