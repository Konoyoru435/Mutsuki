namespace Mutsuki.Lib.OpCodes;

[OpControl(0x25, "Null Command")]
public class Op25 : IOpControl
{
    public static string ToCommand(BinaryReader reader, StringMessage message)
    {
        return "Null Command, Continue, Command 25";
    }
}
