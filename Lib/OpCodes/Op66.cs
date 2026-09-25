using Mutsuki.Extension;

namespace Mutsuki.Lib.OpCodes;

// sub_439120: a sub-command byte, six Values (x, y, pdt plus a BGR triple)
// and a formatted text run.
[OpControl(0x66, "Graphic Text")]
public class Op66 : IOpControl
{
    public static string ToCommand(BinaryReader reader, StringMessage message)
    {
        var subCommand = reader.ReadByte();
        var args = new List<Value>(6);
        for (var i = 0; i < 6; i++)
        {
            args.Add(reader.ReadValue());
        }
        var text = reader.ReadFormattedTextSegments();
        foreach (var segment in text)
        {
            switch (segment.Type)
            {
                case 0xff:
                    message.AddChineseString(segment.Data);
                    break;
                case 0xfe:
                    // Single-byte runs are never glyph-coded.
                    message.AddShiftJISString(segment.Data);
                    break;
            }
        }

        return $"Graphic Text, Draw Text, Command: 66 {subCommand:X2}, Arguments: {string.Join(", ", args)}, Text: {string.Join(" ", text)}";
    }
}
