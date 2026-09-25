namespace Mutsuki.Lib.OpCodes;

[OpControl(0x28, "Null Command")]
public class Op28 : IOpControl
{
    public static string ToCommand(BinaryReader reader, StringMessage message)
    {
        return "Null Command, Continue, Command 28";
    }
}
