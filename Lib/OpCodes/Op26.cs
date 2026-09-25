namespace Mutsuki.Lib.OpCodes;

[OpControl(0x26, "Null Command")]
public class Op26 : IOpControl
{
    public static string ToCommand(BinaryReader reader, StringMessage message)
    {
        return "Null Command, Continue, Command 26";
    }
}
