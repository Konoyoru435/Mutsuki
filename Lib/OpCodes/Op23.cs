namespace Mutsuki.Lib.OpCodes;

[OpControl(0x23, "Null Command")]
public class Op23 : IOpControl
{
    public static string ToCommand(BinaryReader reader, StringMessage message)
    {
        return "Null Command, Continue, Command 23";
    }
}
