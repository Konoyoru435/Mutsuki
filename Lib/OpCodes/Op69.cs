using Mutsuki.Extension;

namespace Mutsuki.Lib.OpCodes;

// sub_4368F0 case 0x69: sub-command byte, a mode byte, then six Values.
[OpControl(0x69, "Graphic Wipe")]
public class Op69 : IOpControl
{
    public static string ToCommand(BinaryReader reader, StringMessage message)
    {
        var subCommand = reader.ReadByte();
        var mode = reader.ReadByte();
        var args = new List<Value>(6);
        for (var i = 0; i < 6; i++)
        {
            args.Add(reader.ReadValue());
        }

        return $"Graphic Wipe, Wipe, Command: 69 {subCommand:X2}, Mode: {mode}, Arguments: {string.Join(", ", args)}";
    }
}
