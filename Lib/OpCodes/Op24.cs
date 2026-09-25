namespace Mutsuki.Lib.OpCodes;

[OpControl(0x24, "Null Command")]
public class Op24 : IOpControl
{
    public static string ToCommand(BinaryReader reader, StringMessage message)
    {
        return "Null Command, Continue, Command 24";
    }
}
