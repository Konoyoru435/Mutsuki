namespace Mutsuki.Lib.OpCodes;

[OpControl(0x6e, "Buffer Restore")]
public class Op6E : IOpControl
{
    public static string ToCommand(BinaryReader reader, StringMessage message)
    {
        return "Buffer Restore, Restore, Command: 6E";
    }
}
