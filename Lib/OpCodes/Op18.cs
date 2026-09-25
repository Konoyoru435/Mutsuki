using Mutsuki.Extension;

namespace Mutsuki.Lib.OpCodes;

[OpControl(0x18, "Cursor Control")]
public class Op18 : IOpControl
{
    public static string ToCommand(BinaryReader reader, StringMessage message)
    {
        var subCommand = reader.ReadByte();

        switch (subCommand)
        {
            case 0x01:
                var v0_01 = reader.ReadValue();
                return $"Cursor Control, Set Cursor, Command: 18 01, Arguments: {v0_01}";
            default:
                // The engine ignores every other sub-command and reads no operands.
                return $"Cursor Control, No Operation, Command: 18 {subCommand:X2}";
        }
    }
}
