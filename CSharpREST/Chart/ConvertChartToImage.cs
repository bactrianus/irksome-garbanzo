using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Aspose.Cells.Cloud.Examples;

namespace Aspose.Cells.Cloud.Examples.Chart
{
    class ConvertChartToImage
    {
        static void Main()
        {
            string inputFile = Common.GetPath(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType, "Sample.xlsx");
            string outputFile = Common.GetPath(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType, "Chart.png");

            Common.ExecuteRequest(
                Common.SignRequestUrl(Common.BASE_PATH + "storage/file/Sample.xlsx"),
                "PUT",
                System.IO.File.ReadAllBytes(inputFile)
                );

            byte[] buf = Common.ExecuteRequest(
                Common.SignRequestUrl(Common.BASE_PATH + "cells/Sample.xlsx/worksheets/Sheet1/charts/0?format=png"),
                "GET"
                );

            System.IO.File.WriteAllBytes(outputFile, buf);

            Common.Pause();
        }
    }
}
