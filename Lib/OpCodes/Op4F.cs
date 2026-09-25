using Mutsuki.Extension;

namespace Mutsuki.Lib.OpCodes;

[OpControl(0x4f, "Bit/Val Get/Set")]
public class Op4F : IOpControl
{
    public static string ToCommand(BinaryReader reader, StringMessage message)
    {
        var idx = reader.ReadValue();
        var data = reader.ReadValue();

        return "Bit/Val Get/Set, Val And With Another Val, Command: 4F, Arguments: " + idx + ", " + data;
    }
}
