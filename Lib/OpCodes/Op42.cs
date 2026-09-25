using Mutsuki.Extension;

namespace Mutsuki.Lib.OpCodes;

[OpControl(0x42, "Bit/Val Get/Set")]
public class Op42 : IOpControl
{
    public static string ToCommand(BinaryReader reader, StringMessage message)
    {
        var idx = reader.ReadValue();
        var data = reader.ReadValue();

        return "Bit/Val Get/Set, Val Or, Command: 42, Arguments: " + idx + ", " + data;
    }
}
