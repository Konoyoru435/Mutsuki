using Mutsuki.Extension;

namespace Mutsuki.Lib.OpCodes;

public struct SumTerm
{
    public byte Op;
    public List<Value> Values;

    public override string ToString()
    {
        return Values.Count == 0
            ? $"Term({Op:X2})"
            : $"Term({Op:X2}, {string.Join(", ", Values)})";
    }
}

// Sub 01 accumulates into a flag by walking a 0x00-terminated term list; ops 01
// and 11 take one Value, 02 and 12 take two, and 03-10 take none.
[OpControl(0x5f, "Val Accumulate")]
public class Op5F : IOpControl
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
            case 0x01:
                var target = reader.ReadValue();
                var terms = new List<SumTerm>();
                while (true)
                {
                    var op = reader.ReadByte();
                    if (op == 0x00)
                    {
                        break;
                    }

                    var count = op switch
                    {
                        0x01 or 0x11 => 1,
                        0x02 or 0x12 => 2,
                        _ => 0
                    };
                    terms.Add(new SumTerm { Op = op, Values = ReadValues(reader, count) });
                }
                return $"Val Accumulate, Sum, Command: 5F 01, Arguments: {target}, {string.Join(", ", terms)}";
            case 0x10:
                var percentOf = ReadValues(reader, 3);
                return $"Val Accumulate, Percent, Command: 5F 10, Arguments: {string.Join(", ", percentOf)}";
            case 0x20:
                var gatherCount = reader.ReadByte();
                var gatherBase = ReadValues(reader, 2);
                var gathered = ReadValues(reader, gatherCount);
                return $"Val Accumulate, Gather, Command: 5F 20, Count: {gatherCount}, Arguments: {string.Join(", ", gatherBase)}, {string.Join(", ", gathered)}";
            default:
                return $"Val Accumulate, No Operation, Command: 5F {subCommand:X2}";
        }
    }
}
