namespace Mutsuki.Lib.OpCodes;

[OpControl(0x22, "Null Command")]
public class Op22 : IOpControl
{
    public static string ToCommand(BinaryReader reader, StringMessage message)
    {
        return "Null Command, Continue, Command 22";
    }
}
