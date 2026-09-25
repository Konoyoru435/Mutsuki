using Mutsuki.Extension;

namespace Mutsuki.Lib.OpCodes;

[OpControl(0x41, "Bit/Val Get/Set")]
public class Op41 : IOpControl
{
    public static string ToCommand(BinaryReader reader, StringMessage message)
    {
        var idx = reader.ReadValue();
        var data = reader.ReadValue();

        return "Bit/Val Get/Set, Val And, Command: 41, Arguments: " + idx + ", " + data;
    }
}
