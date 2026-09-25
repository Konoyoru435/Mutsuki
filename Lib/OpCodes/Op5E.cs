namespace Mutsuki.Lib.OpCodes;

[OpControl(0x5e, "Buffer Clear")]
public class Op5E : IOpControl
{
    public static string ToCommand(BinaryReader reader, StringMessage message)
    {
        return "Buffer Clear, Clear, Command: 5E";
    }
}
