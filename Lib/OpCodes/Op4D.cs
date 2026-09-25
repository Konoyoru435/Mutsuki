using Mutsuki.Extension;

namespace Mutsuki.Lib.OpCodes;

[OpControl(0x4d, "Bit/Val Get/Set")]
public class Op4D : IOpControl
{
    public static string ToCommand(BinaryReader reader, StringMessage message)
    {
        var idx = reader.ReadValue();
        var data = reader.ReadValue();

        return "Bit/Val Get/Set, Val Div With Another Val, Command: 4D, Arguments: " + idx + ", " + data;
    }
}
