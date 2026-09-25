using Mutsuki.Extension;

namespace Mutsuki.Lib.OpCodes;

[OpControl(0x4c, "Bit/Val Get/Set")]
public class Op4C : IOpControl
{
    public static string ToCommand(BinaryReader reader, StringMessage message)
    {
        var idx = reader.ReadValue();
        var data = reader.ReadValue();

        return "Bit/Val Get/Set, Val Mul With Another Val, Command: 4C, Arguments: " + idx + ", " + data;
    }
}
