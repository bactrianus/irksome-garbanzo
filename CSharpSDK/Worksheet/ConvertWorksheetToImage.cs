using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Aspose.Cells.Cloud.Examples;

namespace Aspose.Cells.Cloud.Examples.Workbook
{
    class ConvertWorksheetToImage
    {
        static void Main()
        {
            string inputFile = Common.GetPath(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType, "Workbook1.xlsx");
            string outputFile = Common.GetPath(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType, "Sheet1.png");

            Common.GetStorageSdk().File.UploadFile(
                inputFile,
                System.IO.Path.GetFileName(inputFile),
                Common.STORAGE
                );

            Common.GetCellsSdk().Worksheets.ExportWorksheet(
                System.IO.Path.GetFileName(inputFile),
                "Sheet1",
                Aspose.Cloud.WorksheetExportFormat.Png,
                600,
                800,
                "",
                System.IO.Path.GetFileName(outputFile)
                );

/*            Common.GetCellsSdk().Workbook.ExportWorkbook(
                System.IO.Path.GetFileName(inputFile),
                Aspose.Cloud.WorkbookExportFormat.Pdf,
                string.Empty,
                true,
                "",
                System.IO.Path.GetFileName(outputFile)
                );

            Common.GetStorageSdk().File.DownloadFile(
                System.IO.Path.GetFileName(outputFile),
                outputFile
                );
*/
            Common.Pause();
        }
    }
}
