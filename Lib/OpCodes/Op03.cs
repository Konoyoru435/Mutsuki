namespace Mutsuki.Lib.OpCodes;

[OpControl(0x03, "Page Control")]
public class Op03 : IOpControl
{
    public static string ToCommand(BinaryReader reader, StringMessage message)
    {
        // sub_430500 takes no operands from the bytecode stream.
        return "Page Control, Page Break, Command: 03";
    }
}
