using Mutsuki.Extension;

namespace Mutsuki.Lib.OpCodes;

// Formats a flag value into the pending text buffer.
[OpControl(0x10, "Number To Text")]
public class Op10 : IOpControl
{
    public static string ToCommand(BinaryReader reader, StringMessage message)
    {
        var subCommand = reader.ReadByte();

        switch (subCommand)
        {
            case 0x01:
                var idx = reader.ReadValue();
                return $"Number To Text, Append Number, Command: 10 01, Arguments: {idx}";
            case 0x02:
                var paddedIdx = reader.ReadValue();
                var width = reader.ReadValue();
                return $"Number To Text, Append Padded Number, Command: 10 02, Arguments: {paddedIdx}, {width}";
            case 0x03:
                var slot = reader.ReadValue();
                return $"Number To Text, Append Name Slot, Command: 10 03, Arguments: {slot}";
            default:
                return $"Number To Text, No Operation, Command: 10 {subCommand:X2}";
        }
    }
}
