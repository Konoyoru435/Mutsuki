using Mutsuki.Extension;

namespace Mutsuki.Lib.OpCodes;

[OpControl(0x57, "Bit/Val Get/Set")]
public class Op57 : IOpControl
{
    public static string ToCommand(BinaryReader reader, StringMessage message)
    {
        var idx = reader.ReadValue();
        var min = reader.ReadValue();
        var max = reader.ReadValue();

        return "Bit/Val Get/Set, Val Random, Command: 57, Arguments: "
            + idx
            + ", "
            + min
            + ", "
            + max;
    }
}
