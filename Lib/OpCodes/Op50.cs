using Mutsuki.Extension;

namespace Mutsuki.Lib.OpCodes;

[OpControl(0x50, "Bit/Val Get/Set")]
public class Op50 : IOpControl
{
    public static string ToCommand(BinaryReader reader, StringMessage message)
    {
        var idx = reader.ReadValue();
        var data = reader.ReadValue();

        return "Bit/Val Get/Set, Val Or With Another Val, Command: 50, Arguments: " + idx + ", " + data;
    }
}
