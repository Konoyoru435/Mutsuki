namespace Mutsuki.Lib.OpCodes;

[OpControl(0x1a, "Screen Toggle")]
public class Op1A : IOpControl
{
    public static string ToCommand(BinaryReader reader, StringMessage message)
    {
        return "Screen Toggle, Toggle, Command: 1A";
    }
}
