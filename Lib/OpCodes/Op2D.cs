using Mutsuki.Extension;

namespace Mutsuki.Lib.OpCodes;

[OpControl(0x2d, "Grid Flag")]
public class Op2D : IOpControl
{
    public static string ToCommand(BinaryReader reader, StringMessage message)
    {
        var subCommand = reader.ReadByte();

        switch (subCommand)
        {
            case 0x01
            or 0x02:
                var row = reader.ReadValue();
                return $"Grid Flag, Row {(subCommand == 0x01 ? "Clear" : "Set")}, Command: 2D {subCommand:X2}, Arguments: {row}";
            case 0x03
            or 0x04:
                var cellRow = reader.ReadValue();
                var cellCol = reader.ReadValue();
                return $"Grid Flag, Cell {(subCommand == 0x03 ? "Clear" : "Set")}, Command: 2D {subCommand:X2}, Arguments: {cellRow}, {cellCol}";
            default:
                return $"Grid Flag, No Operation, Command: 2D {subCommand:X2}";
        }
    }
}
