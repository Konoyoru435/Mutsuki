using Mutsuki.Extension;

namespace Mutsuki.Lib.OpCodes;

[OpControl(0x40, "Bit/Val Get/Set")]
public class Op40 : IOpControl
{
    public static string ToCommand(BinaryReader reader, StringMessage message)
    {
        var idx = reader.ReadValue();
        var data = reader.ReadValue();

        return "Bit/Val Get/Set, Val Mod, Command: 40, Arguments: " + idx + ", " + data;
    }
}
