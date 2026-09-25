using Mutsuki.Extension;

namespace Mutsuki.Lib.OpCodes;

[OpControl(0x6f, "Buffer Region")]
public class Op6F : IOpControl
{
    public static string ToCommand(BinaryReader reader, StringMessage message)
    {
        var x1 = reader.ReadValue();
        var y1 = reader.ReadValue();
        var x2 = reader.ReadValue();
        var y2 = reader.ReadValue();

        return $"Buffer Region, Set Region, Command: 6F, Arguments: {x1}, {y1}, {x2}, {y2}";
    }
}
