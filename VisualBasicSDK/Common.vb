Imports System.IO
Imports Aspose.Cloud

Namespace Aspose.Cells.Cloud.Examples
    Public Class Common
        Public Shared APP_SID As String = Nothing
        Public Shared APP_KEY As String = Nothing
        Public Shared STORAGE As String = Nothing
        Public Shared BASE_PATH As String = "http://api.aspose.com/v1.1/"

        Public Shared Function GetPath(t As Type, filename As String) As String
            Dim c As String = t.FullName
            c = c.Replace("Aspose.Cells.Cloud.Examples.", "")
            c = c.Replace(".", Path.DirectorySeparatorChar)
            Dim p As String = Path.GetFullPath(Path.Combine(Directory.GetCurrentDirectory(), "..", "..", "..", "Data", c))
            If filename Is Nothing Then
                p = Path.Combine(p, filename)
            End If
            Console.WriteLine("Using {0}", p)
            Return p
        End Function
        Public Shared Function GetStorageSdk() As StorageService
            Return New StorageService(APP_SID, APP_KEY)
        End Function

        Public Shared Function GetCellsSdk() As CellsService
            Return New CellsService(APP_SID, APP_KEY)
        End Function
        Public Shared Sub Pause()
            Console.WriteLine()
            Console.WriteLine("Press any key to continue...")
            Console.ReadKey()
        End Sub

        Shared Sub Main()
        End Sub
    End Class
End Namespace