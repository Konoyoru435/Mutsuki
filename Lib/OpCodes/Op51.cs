using Mutsuki.Extension;

namespace Mutsuki.Lib.OpCodes;

[OpControl(0x51, "Bit/Val Get/Set")]
public class Op51 : IOpControl
{
    public static string ToCommand(BinaryReader reader, StringMessage message)
    {
        var idx = reader.ReadValue();
        var data = reader.ReadValue();

        return "Bit/Val Get/Set, Val Xor With Another Val, Command: 51, Arguments: " + idx + ", " + data;
    }
}
