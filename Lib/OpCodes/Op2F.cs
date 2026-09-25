using Mutsuki.Extension;

namespace Mutsuki.Lib.OpCodes;

[OpControl(0x2f, "Grid Flag")]
public class Op2F : IOpControl
{
    public static string ToCommand(BinaryReader reader, StringMessage message)
    {
        var subCommand = reader.ReadByte();

        switch (subCommand)
        {
            case 0x01:
                var v0_01 = reader.ReadValue();
                var v1_01 = reader.ReadValue();
                var v2_01 = reader.ReadValue();
                return $"Grid Flag, Set Block Flag, Command: 2F 01, Arguments: {v0_01}, {v1_01}, {v2_01}";
            default:
                // The engine ignores every other sub-command and reads no operands.
                return $"Grid Flag, No Operation, Command: 2F {subCommand:X2}";
        }
    }
}
