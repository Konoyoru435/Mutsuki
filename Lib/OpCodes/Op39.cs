using Mutsuki.Extension;

namespace Mutsuki.Lib.OpCodes;

[OpControl(0x39, "Bit/Val Get/Set")]
public class Op39 : IOpControl
{
    public static string ToCommand(BinaryReader reader, StringMessage message)
    {
        var idx = reader.ReadValue();
        var data = reader.ReadValue();

        return "Bit/Val Get/Set, Bit Copy, Command: 39, Arguments: " + idx + ", " + data;
    }
}
