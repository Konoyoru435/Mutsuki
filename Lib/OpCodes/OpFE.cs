using System.Diagnostics.CodeAnalysis;
using Mutsuki.Extension;

namespace Mutsuki.Lib.OpCodes;

// Same shape as 0xFF (index then a NUL-terminated run), but hankaku text.
[SuppressMessage("ReSharper", "InconsistentNaming")]
[OpControl(0xfe, "Hankaku Text")]
public class OpFE : IOpControl
{
    public static string ToCommand(BinaryReader reader, StringMessage message)
    {
        var index = reader.ReadInt32Le();
        var text = reader.ReadCString();

        message.AddShiftJISString(text);

        return "Hankaku Text, Display, Command: FE, Arguments: "
            + index
            + ", "
            + BitConverter.ToString(text);
    }
}
