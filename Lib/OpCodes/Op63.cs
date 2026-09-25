using Mutsuki.Extension;

namespace Mutsuki.Lib.OpCodes;

[OpControl(0x63, "Overlay Buffer")]
public class Op63 : IOpControl
{
    public static string ToCommand(BinaryReader reader, StringMessage message)
    {
        var subCommand = reader.ReadByte();

        switch (subCommand)
        {
            case 0x01:
                return "Overlay Buffer, Free, Command: 63 01";
            case 0x02:
                var x = reader.ReadValue();
                var y = reader.ReadValue();
                var pdt = reader.ReadValue();
                return $"Overlay Buffer, Blit, Command: 63 02, Arguments: {x}, {y}, {pdt}";
            case 0x10:
                return "Overlay Buffer, Discard, Command: 63 10";
            case 0x20:
                return "Overlay Buffer, Present, Command: 63 20";
            default:
                return $"Overlay Buffer, No Operation, Command: 63 {subCommand:X2}";
        }
    }
}
