Namespace Aspose.Cells.Cloud.Examples
    Public Class ConvertChartToImage
        Shared Sub Main()
            Dim inputFile As String = Common.GetPath(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType, "Sample.xlsx")
            Dim outputFile As String = Common.GetPath(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType, "Chart.png")

            Common.GetStorageSdk().File.UploadFile(
                inputFile,
                System.IO.Path.GetFileName(inputFile)
                )

            Common.GetCellsSdk().Charts.GetChartInSomeFormat(
                System.IO.Path.GetFileName(inputFile),
                "Sheet1",
                0,
                Global.Aspose.Cloud.CellsChartOutputFormat.Png,
                "",
                System.IO.Path.GetFileName(outputFile),
                )

            Common.GetStorageSdk().File.DownloadFile(
                System.IO.Path.GetFileName(outputFile),
                outputFile
                )

        End Sub
    End Class
End Namespace
