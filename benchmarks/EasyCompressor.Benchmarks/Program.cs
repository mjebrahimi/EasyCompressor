using BenchmarkDotNetVisualizer;
using BenchmarkDotNetVisualizer.Utilities;
using System.Linq;
using System.Threading.Tasks;

#region Create images from html files
//var reportsDir = DirectoryHelper.GetPathRelativeToProjectDirectory("Reports\\SimpleJob-Throughput");
//foreach (var fileName in Directory.GetFiles(reportsDir, searchPattern: "*.html"))
//{
//    var imgPath = fileName.Replace(".html", ".png");
//    var html = File.ReadAllText(fileName);
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

    foreach (var benchmark in benchmarkInfo.Where(p => p.DisplayName != "EasyCompressor.Benchmarks.xLZ4CompressionModesBenchmark"))
    {
        var title = benchmark.Table.First().GetProperty("Type").ToString().RemoveMarkdownBold();

        BenchmarkReportProcessor.GetMaximumFunc = (string _, decimal[] values) =>
        {
            var max = values.OrderBy(p => p).SkipLast(1).Last();
            return max * 2;
        };

        benchmark.Table = benchmark.Table.SplitByGroupAndSpectrumColumns(["Data"], ["CompressionRatio"], boldEntireRowOfLowestValue: true);

        var options = new JoinReportHtmlOptions()
        {
            Title = null!, //Set per case
            MainColumn = "Compressor",
            GroupByColumns = ["Data"],
            PivotProperty = "Method",
            StatisticColumns = null!, //Set per case
            ColumnsOrder = ["Compress", "Decompress", "CompressAndDecompress"],
            SpectrumStatisticColumn = true,
            OtherColumnsToSelect = ["CompressionRatio"],
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
}
#pragma warning restore CS8321 // Local function is declared but never used
#endregion