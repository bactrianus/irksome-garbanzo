Namespace Aspose.Cells.Cloud.Examples

    Public Class Common
        Public Shared APP_SID As String = Nothing
        Public Shared APP_KEY As String = Nothing
        Public Shared STORAGE As String = Nothing
        Public Shared BASE_PATH As String = "http://api.aspose.com/v1.1/"
        Public Shared Function SignRequestUrl(url As String) As String
            If Not url.Contains("?") Then
                url = url & "?"
            Else
                url = url & "&"
            End If

            url += "appSID=" + APP_SID

            Dim key() As Byte = System.Text.Encoding.UTF8.GetBytes(APP_KEY)
            Dim algorithm As System.Security.Cryptography.HMACSHA1 = New System.Security.Cryptography.HMACSHA1(key)
            Dim sequence() As Byte = System.Text.ASCIIEncoding.ASCII.GetBytes(url)
            Dim hash() As Byte = algorithm.ComputeHash(sequence)
            Dim signature As String = System.Convert.ToBase64String(hash)
            signature = signature.TrimEnd("=")
            url += "&signature=" + signature

            Return url
        End Function

        Shared Sub Main()

        End Sub
    End Class

End Namespace