using Mutsuki.Extension;

namespace Mutsuki.Lib.OpCodes;

[OpControl(0x2c, "Grid Flag")]
public class Op2C : IOpControl
{
    public static string ToCommand(BinaryReader reader, StringMessage message)
    {
        var subCommand = reader.ReadByte();

        switch (subCommand)
        {
            case 0x01:
                var v0_01 = reader.ReadValue();
                return $"Grid Flag, Set Grid Flag, Command: 2C 01, Arguments: {v0_01}";
            default:
                // The engine ignores every other sub-command and reads no operands.
                return $"Grid Flag, No Operation, Command: 2C {subCommand:X2}";
        }
    }
}
