using BenchmarkDotNetVisualizer;
using BenchmarkDotNetVisualizer.Utilities;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

#region Create images from html files
//var path = @"C:\Users\mjebrahimi\Desktop\Projects\EasyCompressor\benchmarks\EasyCompressor.Benchmarks\BenchmarkDotNet.Artifacts\ShortRunJob\EasyCompressor.Benchmarks.HighestCompressionBenchmark-report-github.md";
//var benchmarkInfoX = BenchmarkInfo.CreateFromFile(path);
//await VisualizeBenchmarks([benchmarkInfoX]);
//return;

//var reportsDir = DirectoryHelper.GetPathRelativeToProjectDirectory("Reports\\ShortRunJob");
//foreach (var fileName in System.IO.Directory.GetFiles(reportsDir, searchPattern: "*.html"))
//{
//    var imgPath = fileName.Replace(".html", ".png");
//    var html = System.IO.File.ReadAllText(fileName);
//    await HtmlHelper.RenderHtmlToImageAsync(html, imgPath);
//}
//return;
#endregion

#region Create reports from artifacts
//var dir = System.IO.Path.Combine(DirectoryHelper.GetProjectBenchmarkArtifactsDirectory(), "results (final)");
//var benchmarkInfo1 = BenchmarkInfo.CreateFromDirectory(dir).ToArray();
//await VisualizeBenchmarks(benchmarkInfo1);
//return;
#endregion

#pragma warning disable S1481 // Unused local variables should be removed
var benchmarkInfo = BenchmarkAutoRunner.SwitcherRun(typeof(Program).Assembly).GetBenchmarkInfo().ToArray();
#pragma warning restore S1481 // Unused local variables should be removed

DirectoryHelper.MoveBenchmarkArtifactsToProjectDirectory();

#region Create reports from summaries
//await VisualizeBenchmarks(benchmarkInfo);
#endregion

#region Visualizer Customization
#pragma warning disable CS8321 // Local function is declared but never used
static async Task VisualizeBenchmarks(BenchmarkInfo[] benchmarkInfo)
{
    if (benchmarkInfo is not { Length: > 0 })
        return;

    var highestCompressionBenchmark = benchmarkInfo.SingleOrDefault(p => p.DisplayName == "EasyCompressor.Benchmarks.HighestCompressionBenchmark");
    if (highestCompressionBenchmark is not null)
    {
        var htmlPath = DirectoryHelper.GetPathRelativeToProjectDirectory("Reports\\Benchmark-HighestCompression.html");
        var imagePath = DirectoryHelper.GetPathRelativeToProjectDirectory("Reports\\Benchmark-HighestCompression.png");
        await highestCompressionBenchmark.SaveAsHtmlAndImageAsync(htmlPath, imagePath, new ReportHtmlOptions
        {
            Title = "Benchmark of Compressors for Highest Compression (Smallest Size)",
            GroupByColumns = ["Data"],
            HighlightGroups = true,
            SortByColumns = ["CompressedSize"],
            SpectrumColumns = ["CompressedSize", "Mean", "Allocated"],
            DividerMode = RenderTableDividerMode.EmptyDividerRow,
            HtmlWrapMode = HtmlDocumentWrapMode.Simple
        });
    }

    var lz4Benchmark = benchmarkInfo.SingleOrDefault(p => p.DisplayName == "EasyCompressor.Benchmarks.xLZ4CompressionModesBenchmark");
    if (lz4Benchmark is not null)
    {
        lz4Benchmark.GroupName = lz4Benchmark.DisplayName;
        BenchmarkReportProcessor.GetMaximumFunc = (string _, decimal[] values) =>
        {
            var max = values.OrderBy(p => p).SkipLast(1).Last();
            return max * 2;
        };

        var options = new JoinReportHtmlOptions()
        {
            Title = null!, //Set per case
            MainColumn = "Categories",
            GroupByColumns = ["Size"],
            PivotProperty = "Method",
            StatisticColumns = null!, //Set per case
            ColumnsOrder = ["Compress", "Decompress", "CompressAndDecompress"],
            SpectrumStatisticColumn = true,
            HighlightGroups = true,
            DividerMode = RenderTableDividerMode.SeparateTables,
            HtmlWrapMode = HtmlDocumentWrapMode.RichDataTables,
        };

        options.Title = "Benchmark of different LZ4 Compressors";
        options.StatisticColumns = ["Mean", "Allocated"];
        await lz4Benchmark.JoinReportsAndSaveAsHtmlAndImageAsync(
            htmlPath: DirectoryHelper.GetPathRelativeToProjectDirectory("Reports\\Benchmark-LZ4.html"),
            imagePath: DirectoryHelper.GetPathRelativeToProjectDirectory("Reports\\Benchmark-LZ4.png"),
            options: options);
    }

#pragma warning disable SYSLIB1045 // Convert to 'GeneratedRegexAttribute'.
    foreach (var benchmark in benchmarkInfo.Where(p => Regex.Match(p.DisplayName, @"EasyCompressor.Benchmarks\.(Binary|Stream|StreamAsync)Benchmark").Success))
    {
        var title = benchmark.Table.First().GetProperty("Type").ToString().RemoveMarkdownBold();

        BenchmarkReportProcessor.GetMaximumFunc = (string _, decimal[] values) =>
        {
            var max = values.OrderBy(p => p).SkipLast(1).Last();
            return max * 2;
        };

        benchmark.Table = benchmark.Table.SplitByGroupAndSpectrumColumns(["Data"], ["CompressedSize"], boldEntireRowOfLowestValue: true);

        var options = new JoinReportHtmlOptions()
        {
            Title = null!, //Set per case
            MainColumn = "Compressor",
            GroupByColumns = ["Data"],
            PivotProperty = "Method",
            StatisticColumns = null!, //Set per case
            ColumnsOrder = ["Compress", "Decompress", "CompressAndDecompress"],
            SpectrumStatisticColumn = true,
            OtherColumnsToSelect = ["CompressedSize"],
            HighlightGroups = true,
            DividerMode = RenderTableDividerMode.SeparateTables,
            HtmlWrapMode = HtmlDocumentWrapMode.RichDataTables,
        };

        options.Title = $"Benchmark of {title} Compressors in terms of Execution Time";
        options.StatisticColumns = ["Mean"];
        await benchmark.JoinReportsAndSaveAsHtmlAndImageAsync(
            htmlPath: DirectoryHelper.GetPathRelativeToProjectDirectory($"Reports\\Benchmark-{title}-Mean.html"),
            imagePath: DirectoryHelper.GetPathRelativeToProjectDirectory($"Reports\\Benchmark-{title}-Mean.png"),
            options: options);

        BenchmarkReportProcessor.GetMaximumFunc = (string spectrumColumn, decimal[] values) =>
        {
            if (spectrumColumn == "Decompress")
                return values.Max();
            var max = values.OrderBy(p => p).SkipLast(1).Last();
            return max * 2;
        };

        options.Title = $"Benchmark of {title} Compressors in terms of Allocation Size";
        options.StatisticColumns = ["Allocated"];
        await benchmark.JoinReportsAndSaveAsHtmlAndImageAsync(
            htmlPath: DirectoryHelper.GetPathRelativeToProjectDirectory($"Reports\\Benchmark-{title}-Allocated.html"),
            imagePath: DirectoryHelper.GetPathRelativeToProjectDirectory($"Reports\\Benchmark-{title}-Allocated.png"),
            options: options);
    }
#pragma warning restore SYSLIB1045 // Convert to 'GeneratedRegexAttribute'.
}
#pragma warning restore CS8321 // Local function is declared but never used
#endregion