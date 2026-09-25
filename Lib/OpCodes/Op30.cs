using Mutsuki.Extension;

namespace Mutsuki.Lib.OpCodes;

[OpControl(0x30, "Grid Flag")]
public class Op30 : IOpControl
{
    public static string ToCommand(BinaryReader reader, StringMessage message)
    {
        var subCommand = reader.ReadByte();

        switch (subCommand)
        {
            case 0x01:
                return "Grid Flag, Commit Grid, Command: 30 01";
            default:
                // The engine ignores every other sub-command and reads no operands.
                return $"Grid Flag, No Operation, Command: 30 {subCommand:X2}";
        }
    }
}
