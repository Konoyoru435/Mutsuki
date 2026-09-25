using Mutsuki.Extension;

namespace Mutsuki.Lib.OpCodes;

[OpControl(0x56, "Bit/Val Get/Set")]
public class Op56 : IOpControl
{
    public static string ToCommand(BinaryReader reader, StringMessage message)
    {
        var idx = reader.ReadValue();

        return "Bit/Val Get/Set, Bit Random Set, Command: 56, Arguments: " + idx;
    }
}
