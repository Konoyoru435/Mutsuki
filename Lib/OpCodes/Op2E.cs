using Mutsuki.Extension;

namespace Mutsuki.Lib.OpCodes;

[OpControl(0x2e, "Grid Flag")]
public class Op2E : IOpControl
{
    public static string ToCommand(BinaryReader reader, StringMessage message)
    {
        var subCommand = reader.ReadByte();

        switch (subCommand)
        {
            case 0x01:
                var v0_01 = reader.ReadValue();
                return $"Grid Flag, Set Row Flag, Command: 2E 01, Arguments: {v0_01}";
            case 0x02:
                var v0_02 = reader.ReadValue();
                var v1_02 = reader.ReadValue();
                return $"Grid Flag, Set Cell Flag, Command: 2E 02, Arguments: {v0_02}, {v1_02}";
            default:
                // The engine ignores every other sub-command and reads no operands.
                return $"Grid Flag, No Operation, Command: 2E {subCommand:X2}";
        }
    }
}
