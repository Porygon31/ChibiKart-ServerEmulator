Imports System.IO
Imports System.Text

Public Class Extract
    Shared Function ExtractPAK(inputpak)
        Dim ExtractFileCount As Integer = 0

        Using br As BinaryReader = New BinaryReader(File.Open(inputpak, FileMode.Open))
            'Get Signature and check
            Dim CorrectSignature = "NKZIP"
            If CorrectSignature = Encoding.UTF8.GetString(br.ReadBytes(5)) = False Then
                MessageBox.Show("Incorrect PAK File")
            End If

            'Let go directly to FileCount in Archive
            br.BaseStream.Position = &H24
            Dim FileCount As UInt32 = br.ReadUInt32

            For i As Integer = 1 To FileCount
                'Calculate Start of Data
                Dim StartofFileData = br.BaseStream.Position + &H108

                'Loop Getting Files
                Dim FileLength = br.ReadUInt32

                'Get FileNameDir Which we need to Save POS to return to
                Dim CharCount As Integer = 0
                Dim FileNameDir As String = ""
                Dim StartofFileName = br.BaseStream.Position
                While br.ReadByte <> 0
                    CharCount += 1
                End While
                br.BaseStream.Position = StartofFileName
                FileNameDir = Encoding.UTF8.GetString(br.ReadBytes(CharCount))
                Dim ExtractedFilename = Path.GetFileName(FileNameDir)
                Dim ExtractedDIR = Path.GetDirectoryName(FileNameDir).Replace("./", "")

                'Create Directory if needed
                Dim ExportDir = "Export/" + Path.GetFileNameWithoutExtension(inputpak) + "/" + ExtractedDIR + "/"
                If Directory.Exists(ExportDir) = False Then
                    Directory.CreateDirectory(ExportDir)
                End If

                'Now get the Data
                br.BaseStream.Position = StartofFileData
                Dim FileData = br.ReadBytes(FileLength)
                File.WriteAllBytes(ExportDir + ExtractedFilename, FileData)
                ExtractFileCount += 1
            Next

            If ExtractFileCount = FileCount Then
                MessageBox.Show("Extracted all " + FileCount.ToString + " Files Successfully")
            Else
                MessageBox.Show("Extracted: " + ExtractFileCount.ToString + vbNewLine + "Expected: FileCount")
            End If
        End Using
    End Function
End Class
