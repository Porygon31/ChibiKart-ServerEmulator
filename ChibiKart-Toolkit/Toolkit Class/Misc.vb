Imports System.IO
Imports System.Text

Public Class Misc
    Shared Function XorStringAndWriteToFile(ByVal input As String, ByVal outputPath As String)
        Dim result As New StringBuilder()
        ' Convert the input string to a byte array
        Dim inputBytes As Byte() = Encoding.UTF8.GetBytes(input)

        For i As Integer = 0 To 255
            Try
                Dim xorBytes As Byte() = New Byte(inputBytes.Length - 1) {}

                ' XOR each byte in the array
                For j As Integer = 0 To inputBytes.Length - 1
                    xorBytes(j) = inputBytes(j) Xor CByte(i)
                Next

                ' Convert the XORed byte array back to a string
                Dim xorResult As String = Encoding.UTF8.GetString(xorBytes)
                result.AppendLine($"XOR with {i:X2}: {xorResult}")
                Using SW As StreamWriter = New StreamWriter(File.Open(outputPath, FileMode.Append))
                    SW.WriteLine($"XOR with {i:X4}: {xorResult.ToString()}")
                End Using
            Catch ex As Exception
                ' Skip this XOR value if any error occurs
                Continue For
            End Try
        Next

        MessageBox.Show("Finished XOR Test")
    End Function


    Shared Function DecryptNetworkini(inputstring As String)
        Dim StringBytes = Encoding.UTF8.GetBytes(inputstring)
        Dim result As New System.Text.StringBuilder()
        For Each b As Byte In StringBytes
            result.Append(Chr(b - &H33))
        Next
        MessageBox.Show(result.ToString())
    End Function

    Shared Function FormatByteArray(data As Byte()) As String
        Dim sb As New StringBuilder()
        Dim lineLength As Integer = 16

        For i As Integer = 0 To data.Length - 1 Step lineLength
            ' Print the address
            sb.AppendFormat("{0:X8}: ", i)

            ' Print the hexadecimal part
            For j As Integer = 0 To lineLength - 1
                If i + j < data.Length Then
                    sb.AppendFormat("{0:X2} ", data(i + j))
                Else
                    sb.Append("   ")
                End If
                If j = 7 Then sb.Append(" ") ' Extra space after 8 bytes for readability
            Next

            sb.Append(" ")

            ' Print the ASCII part
            For j As Integer = 0 To lineLength - 1
                If i + j < data.Length Then
                    Dim ch As Char = Convert.ToChar(data(i + j))
                    If Char.IsControl(ch) Then
                        sb.Append(".")
                    Else
                        sb.Append(ch)
                    End If
                Else
                    sb.Append(" ")
                End If
            Next

            sb.AppendLine()
        Next

        Return sb.ToString()
    End Function


End Class
