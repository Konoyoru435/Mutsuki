using Mutsuki.Extension;

namespace Mutsuki.Lib.OpCodes;

[OpControl(0x7f, "Debug")]
public class Op7F : IOpControl
{
    public static string ToCommand(BinaryReader reader, StringMessage message)
    {
        // Pops up a "SEEN%03d   LINE %d" message box.
        var line = reader.ReadValue();

        return "Debug, Show Line, Command: 7F, Arguments: " + line;
    }
}
