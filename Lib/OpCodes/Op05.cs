using Mutsuki.Extension;

namespace Mutsuki.Lib.OpCodes;

[OpControl(0x05, "Text Speed")]
public class Op05 : IOpControl
{
    public static string ToCommand(BinaryReader reader, StringMessage message)
    {
        var mode = reader.ReadValue();

        return "Text Speed, Set Mode, Command: 05, Arguments: " + mode;
    }
}
