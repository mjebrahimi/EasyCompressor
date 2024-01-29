using BenchmarkDotNetVisualizer;
using System.Linq;
using System.Threading.Tasks;

#region Create reports from artifacts
//var directory = System.IO.Path.Combine(DirectoryHelper.GetProjectBenchmarkArtifactsDirectory(), "results-ShortRunJob");

//var benchmarkInfo1 = BenchmarkInfo.CreateFromDirectory(directory, searchPattern: "*-report-github.md").ToArray();
//await VisualizeBenchmarks(benchmarkInfo1);
//return;
#endregion

var benchmarkInfo = BenchmarkAutoRunner.SwitcherRun(typeof(Program).Assembly).GetBenchmarkInfo().ToArray();

DirectoryHelper.MoveBenchmarkArtifactsToProjectDirectory();

#region Create reports from summaries
//var benchmarkInfo2 = System.Array.FindAll(benchmarkInfo, p => p.BenchmarkType.GetGenericTypeDefinition() == typeof(EasyCompressor.Benchmarks.BinaryBenchmark<>));
//await VisualizeBenchmarks(benchmarkInfo2);
#endregion

#region Visualizer Customization
static async Task VisualizeBenchmarks(BenchmarkInfo[] benchmarkInfo)
{
    if (benchmarkInfo is not { Length: > 0 })
        return;

    //ChangeColorAndNameOfBigOColumn(benchmarkInfo);

    var options = new JoinReportHtmlOptions()
    {
        Title = null!, //Set per case
        MainColumn = "Compressor",
        GroupByColumns = ["Type", "Data"],
        PivotProperty = "Method",
        StatisticColumns = null!, //Set per case
        ColumnsOrder = ["Compress", "Decompress", "CompressAndDecompress"],
        SpectrumStatisticColumn = true,
        OtherColumnsToSelect = ["Compressed", "CompressionRatio"],
        HighlightGroups = true,
        DividerMode = RenderTableDividerMode.SeparateTables,
        HtmlWrapMode = HtmlDocumentWrapMode.RichDataTables,
    };

    options.Title = "Benchmark of Binary Compressors in terms of Execution Time (Mean)";
    options.StatisticColumns = ["Mean"];
    await benchmarkInfo.JoinReportsAndSaveAsHtmlAndImageAsync(
        htmlPath: DirectoryHelper.GetPathRelativeToProjectDirectory("docs\\Benchmark-XXX3-Mean.html"),
        imagePath: DirectoryHelper.GetPathRelativeToProjectDirectory("docs\\Benchmark-XXX3-Mean.webp"),
        options: options);

    options.Title = "Benchmark of Binary Compressors in terms of Allocation Size";
    options.StatisticColumns = ["Allocated"];
    await benchmarkInfo.JoinReportsAndSaveAsHtmlAndImageAsync(
        htmlPath: DirectoryHelper.GetPathRelativeToProjectDirectory("docs\\Benchmark-XXX3-Allocated.html"),
        imagePath: DirectoryHelper.GetPathRelativeToProjectDirectory("docs\\Benchmark-XXX3-Allocated.webp"),
        options: options);
}

//static void ChangeColorAndNameOfBigOColumn(BenchmarkInfo[] benchmarkInfo)
//{
//    const string srcPropertyName = "Categories";
//    const string destPropertyName = "Big O";

//    foreach (var item in benchmarkInfo)
//    {
//        item.Table = item.Table.Select(expando =>
//        {
//            if (expando is not null)
//            {
//                expando.ChangePropertyName(srcPropertyName, destPropertyName);
//                expando.TransferColumnOrder(srcPropertyName, destPropertyName);
//                var value = expando.GetProperty(destPropertyName).ToString().RemoveMarkdownBold();
//                var color = GetColor(value);
//                expando.SetMetaProperty($"{destPropertyName}.background-color", color);
//            }
//            return expando;
//        });
//    }

//    static string GetColor(string value)
//    {
//        return value switch
//        {
//            "O(1)" => "#99FF99",
//            "O(log(N))" => "#FFFF99",
//            "O(N)" => "#FF9999",
//            _ => throw new ArgumentOutOfRangeException()
//        };
//    }
//}
#endregion