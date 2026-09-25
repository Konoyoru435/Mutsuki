using Mutsuki.Extension;

namespace Mutsuki.Lib.OpCodes;

// sub_4368F0 case 0x65: a sub-command byte then eighteen Values.
[OpControl(0x65, "Graphic Transform")]
public class Op65 : IOpControl
{
    public static string ToCommand(BinaryReader reader, StringMessage message)
    {
        var subCommand = reader.ReadByte();
        var args = new List<Value>(18);
        for (var i = 0; i < 18; i++)
        {
            args.Add(reader.ReadValue());
        }

        return $"Graphic Transform, Transform, Command: 65 {subCommand:X2}, Arguments: {string.Join(", ", args)}";
    }
}
