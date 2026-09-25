using Mutsuki.Extension;

namespace Mutsuki.Lib.OpCodes;

[OpControl(0x43, "Bit/Val Get/Set")]
public class Op43 : IOpControl
{
    public static string ToCommand(BinaryReader reader, StringMessage message)
    {
        var idx = reader.ReadValue();
        var data = reader.ReadValue();

        return "Bit/Val Get/Set, Val Xor, Command: 43, Arguments: " + idx + ", " + data;
    }
}
