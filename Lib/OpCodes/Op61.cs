using Mutsuki.Extension;

namespace Mutsuki.Lib.OpCodes;

public struct SelectOption
{
    public Value Value;
    public List<TextSegment> Text;

    public override string ToString()
    {
        return $"Option({Value}, {string.Join(" ", Text)})";
    }
}

// Layout taken from sub_427C60 (the 0x61 handler) in AVG3217D.EXE; the engine
// accepts 01-04, 10-12, 20, 21, 24, 30 and 31 and ignores everything else.
[OpControl(0x61, "Name Value Get/Set")]
public class Op61 : IOpControl
{
    private static List<Value> ReadValues(BinaryReader reader, int count)
    {
        var values = new List<Value>(count);
        for (var i = 0; i < count; i++)
        {
            values.Add(reader.ReadValue());
        }
        return values;
    }

    public static string ToCommand(BinaryReader reader, StringMessage message)
    {
        var subCommand = reader.ReadByte();

        switch (subCommand)
        {
            case 0x01:
                // 10 values: x1, y1, x2, y2, then two BGR triples.
                var box = ReadValues(reader, 10);
                return $"Name Value Get/Set, Set Name Box, Command: 61 01, Arguments: {string.Join(", ", box)}";
            case 0x02
            or 0x03:
                var toggle = reader.ReadValue();
                return $"Name Value Get/Set, Name Box Toggle, Command: 61 {subCommand:X2}, Arguments: {toggle}";
            case 0x04:
                return "Name Value Get/Set, Reset Name Box, Command: 61 04";
            case 0x10
            or 0x12:
                var idxString = reader.ReadValue();
                var dataString = reader.ReadValue();
                return $"Name Value Get/Set, Get Name String, Command: 61 {subCommand:X2}, Arguments: {idxString}, {dataString}";
            case 0x11:
                var idx = reader.ReadValue();
                var data = reader.ReadValue();
                return $"Name Value Get/Set, Change Name Value, Command: 61 11, Arguments: {idx}, {data}";
            case 0x20:
                var menuIdx = reader.ReadValue();
                return $"Name Value Get/Set, Open Name Menu, Command: 61 20, Arguments: {menuIdx}";
            case 0x21:
                var inputIdx = reader.ReadValue();
                var inputCaption = reader.ReadSlotString();
                var inputArgs = ReadValues(reader, 9);
                return $"Name Value Get/Set, Name Input, Command: 61 21, Arguments: {inputIdx}, {inputCaption}, {string.Join(", ", inputArgs)}";
            case 0x24:
                // One byte count, then that many (value, text) pairs.
                var optionCount = reader.ReadByte();
                var options = new List<SelectOption>(optionCount);
                for (var i = 0; i < optionCount; i++)
                {
                    var optionValue = reader.ReadValue();
                    var optionText = reader.ReadFormattedTextSegments();
                    foreach (var segment in optionText.Where(x => x.Type == 0xff))
                    {
                        message.AddChineseString(segment.Data);
                    }
                    options.Add(new SelectOption { Value = optionValue, Text = optionText });
                }
                return $"Name Value Get/Set, Select, Command: 61 24, Count: {optionCount}, Arguments: {string.Join(", ", options)}";
            case 0x30
            or 0x31:
                return $"Name Value Get/Set, Name Dialog, Command: 61 {subCommand:X2}";
            default:
                throw new Exception(
                    $"Position: {reader.Now()}, Unknown Command: 61 {subCommand:X2}"
                );
        }
    }
}
