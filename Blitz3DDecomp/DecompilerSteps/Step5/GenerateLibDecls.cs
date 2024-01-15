﻿using B3DDecompUtils;

namespace Blitz3DDecomp.DecompilerSteps.Step5;

static class GenerateLibDecls
{
    public static void FromDir(string disasmPath, string decompPath)
    {
        var inputDir = disasmPath.AppendToPath("Libs");
        if (!Directory.Exists(inputDir)) { return; }
        var outputDir = decompPath.AppendToPath("Decls");
        Directory.CreateDirectory(outputDir);
        foreach (var filePath in Directory.GetFiles(inputDir))
        {
            var outputLines = new List<string>();

            var lines = File.ReadAllLines(filePath);
            var dllName = lines[0].Trim();
            outputLines.Add($".lib \"{dllName}\"");
            outputLines.Add("");
            foreach (var line in lines.Skip(1))
            {
                var split = line.Split(':', StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries);
                var blitzName = split[0][2..];
                var disasmName = split[0] + "__LIBS";
                var dllSymbolName = split[1];

                var function = Function.GetFunctionByName(disasmName);

                string extractSuffixForBlitzSignature(DeclType declType)
                {
                    if (declType.IsCustomType) { return "*"; }
                    return declType.Suffix;
                }
                var blitzSignature =
                    $"{blitzName}{extractSuffixForBlitzSignature(function.ReturnType)}({string.Join(", ", function.Parameters.Select(p => p.Name + extractSuffixForBlitzSignature(p.DeclType)))})";
                outputLines.Add($"{blitzSignature}:\"{dllSymbolName}\"");
            }
            File.WriteAllLines(outputDir.AppendToPath(dllName.CleanupPath().Replace("/", "_").Replace(".dll", "") + ".decls"), outputLines);
        }
    }
}