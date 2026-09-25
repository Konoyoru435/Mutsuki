using Mutsuki.Extension;

namespace Mutsuki.Lib.OpCodes;

// sub_405490. Sub-commands 21 and 25 return before touching the stream; every
// other one reads a slot string first and then its own operands.
[OpControl(0x0c, "Animation")]
public class Op0C : IOpControl
{
    private static List<Value> ReadValues(BinaryReader reader, int count)
    {
        var values = new List<Value>(count);
        for (var i = 0; i < count; i++)
        {
            values.Add(reader.ReadValue());
        }
        return values;
    }

    public static string ToCommand(BinaryReader reader, StringMessage message)
    {
        var subCommand = reader.ReadByte();

        switch (subCommand)
        {
            case 0x21:
                return "Animation, Stop All, Command: 0C 21";
            case 0x25:
                return "Animation, Clear, Command: 0C 25";
        }

        var name = reader.ReadSlotString();

        var args = subCommand switch
        {
            0x10 => ReadValues(reader, 1),
            0x16 => ReadValues(reader, 3),
            0x13 => ReadValues(reader, 2),
            0x19 => ReadValues(reader, 4),
            0x11 or 0x12 or 0x17 or 0x18 or 0x1a or 0x30 or 0x20 or 0x24
                => reader.ReadValueList(),
            _ => []
        };

        var label = subCommand switch
        {
            0x10 or 0x16 => "Play",
            0x11 or 0x12 or 0x17 or 0x18 or 0x1a or 0x30 => "Play Multi",
            0x13 or 0x19 => "Play One Shot",
            0x20 or 0x24 => "Queue",
            _ => "No Operation"
        };

        return args.Count == 0
            ? $"Animation, {label}, Command: 0C {subCommand:X2}, Arguments: {name}"
            : $"Animation, {label}, Command: 0C {subCommand:X2}, Arguments: {name}, {string.Join(", ", args)}";
    }
}
