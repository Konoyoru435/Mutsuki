using Mutsuki.Extension;

namespace Mutsuki.Lib.OpCodes;

[OpControl(0x4e, "Bit/Val Get/Set")]
public class Op4E : IOpControl
{
    public static string ToCommand(BinaryReader reader, StringMessage message)
    {
        var idx = reader.ReadValue();
        var data = reader.ReadValue();

        return "Bit/Val Get/Set, Val Mod With Another Val, Command: 4E, Arguments: " + idx + ", " + data;
    }
}
