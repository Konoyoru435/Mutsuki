using System.Diagnostics.CodeAnalysis;
using System.Text;
using System.Text.RegularExpressions;
using Mutsuki.Lib;
using ShellProgressBar;

namespace Mutsuki;

using CommandLine;

[SuppressMessage("ReSharper", "ClassNeverInstantiated.Global")]
public class Program
{
    [SuppressMessage("ReSharper", "ClassNeverInstantiated.Local")]
    private class Options
    {
        [Option('i', "input", Required = true, HelpText = "Input file to be processed.")]
        public string Input { set; get; } = null!;

        [Option('o', "output", Required = true, HelpText = "Output folder to be written.")]
        public string Output { set; get; } = null!;

        [Option(
            'm',
            "map",
            Required = false,
            HelpText = "FN.DAT offset table for the Chinese release. Omit it for the "
                + "Japanese original, whose text is plain Shift-JIS."
        )]
        public string? Map { set; get; }
    }

    private static void Main(string[] args)
    {
        Parser
            .Default.ParseArguments<Options>(args)
            .WithParsed(opts =>
            {
                Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
                if (!Directory.Exists(opts.Output))
                {
                    Directory.CreateDirectory(opts.Output);
                }

                var inputFile = File.OpenRead(opts.Input);
                var parser = new SeenParser(inputFile);

                var splitFolder = Path.Combine(opts.Output, "01_SPLIT");
                Directory.CreateDirectory(splitFolder);

                var decompressedFolder = Path.Combine(opts.Output, "02_DECOMPRESSED");
                Directory.CreateDirectory(decompressedFolder);

                var parsedFolder = Path.Combine(opts.Output, "03_PARSED");
                Directory.CreateDirectory(parsedFolder);

                var stringFolder = Path.Combine(opts.Output, "04_STRING");
                Directory.CreateDirectory(stringFolder);

                var options = new ProgressBarOptions
                {
                    ProgressBarOnBottom = true,
                    ProgressCharacter = '─'
                };

                using var progressBar = new ProgressBar(
                    parser.FileCount * 3,
                    "Starting",
                    options
                );
                var failures = new List<(string Name, string Reason)>();
                foreach (var (name, data) in parser.Files)
                {
                    progressBar.Tick($"Writing Split {name}...");
                    var splitFilePath = Path.Combine(splitFolder, name);
                    File.WriteAllBytes(splitFilePath, data);

                    try
                    {
                        progressBar.Tick($"Decompressing {name}...");
                        var decompressedFilePath = Path.Combine(decompressedFolder, name);
                        var decompressed = Decompress.UnPack(data);
                        File.WriteAllBytes(decompressedFilePath, decompressed);

                        progressBar.Tick($"Parsing {name}...");
                        var parsedFilePath = Path.Combine(parsedFolder, name);
                        var parsed = new ScenarioParser(new MemoryStream(decompressed), opts.Map);
                        File.WriteAllText(parsedFilePath, parsed.FinalContent);

                        if (!string.IsNullOrEmpty(parsed.FinalString))
                        {
                            var stringFilePath = Path.Combine(stringFolder, name);
                            File.WriteAllText(stringFilePath, parsed.FinalString);
                        }
                    }
                    catch (Exception e)
                    {
                        // Keep going so one unimplemented opcode does not hide the rest.
                        failures.Add((name, e.Message));
                    }
                }

                progressBar.Dispose();
                Report(failures, parser.FileCount);
            });
    }

    private static void Report(List<(string Name, string Reason)> failures, int total)
    {
        Console.WriteLine($"\nParsed {total - failures.Count}/{total} files.");

        if (failures.Count == 0)
        {
            return;
        }

        var grouped = failures
            .GroupBy(x => Regex.Replace(x.Reason, @"^Position: \d+, ", string.Empty))
            .OrderByDescending(g => g.Count());

        Console.WriteLine($"{failures.Count} failed, grouped by reason:");
        foreach (var group in grouped)
        {
            var names = group.Select(x => x.Name).Take(4).ToList();
            var suffix = group.Count() > names.Count ? $", +{group.Count() - names.Count} more" : string.Empty;
            Console.WriteLine($"  {group.Count(),4}x  {group.Key}  [{string.Join(", ", names)}{suffix}]");
        }
    }
}
