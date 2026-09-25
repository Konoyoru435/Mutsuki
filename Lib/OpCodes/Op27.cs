namespace Mutsuki.Lib.OpCodes;

[OpControl(0x27, "Null Command")]
public class Op27 : IOpControl
{
    public static string ToCommand(BinaryReader reader, StringMessage message)
    {
        return "Null Command, Continue, Command 27";
    }
}
