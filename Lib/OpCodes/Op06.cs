using Mutsuki.Extension;

namespace Mutsuki.Lib.OpCodes;

[OpControl(0x06, "Wait")]
public class Op06 : IOpControl
{
    public static string ToCommand(BinaryReader reader, StringMessage message)
    {
        var value = reader.ReadValue();

        return "Wait, Wait Key, Command: 06, Arguments: " + value;
    }
}
