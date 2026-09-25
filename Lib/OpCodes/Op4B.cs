using Mutsuki.Extension;

namespace Mutsuki.Lib.OpCodes;

[OpControl(0x4b, "Bit/Val Get/Set")]
public class Op4B : IOpControl
{
    public static string ToCommand(BinaryReader reader, StringMessage message)
    {
        var idx = reader.ReadValue();
        var data = reader.ReadValue();

        return "Bit/Val Get/Set, Val Sub With Another Val, Command: 4B, Arguments: " + idx + ", " + data;
    }
}
