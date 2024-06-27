Imports System.Net
Imports System.Net.Sockets
Imports System.Text
Imports System.Threading
Imports System.IO
Imports ChibiKart_Toolkit.Misc

Public Class GameServer
    Private tcpListener As TcpListener
    Private listenerThread As Thread
    Private logFilePath As String = "logs/gameserver_log.txt"
    Private RTF As RichTextBox
    Private responses As Dictionary(Of String, Byte())

    Public Sub New(RTF As RichTextBox)
        Me.RTF = RTF
        tcpListener = New TcpListener(IPAddress.Parse("127.0.0.1"), 9981)
        listenerThread = New Thread(AddressOf StartServer)
    End Sub

    Public Sub Start()
        listenerThread.Start()
    End Sub

    Private Sub StartServer()
        Try
            tcpListener = New TcpListener(IPAddress.Any, 50017)
            tcpListener.Start()

            ' Log that the server has started
            LogRequest("Server started and listening on port 50017")

            While True
                Dim client As TcpClient = tcpListener.AcceptTcpClient()
                Dim clientHandlerThread As New Thread(AddressOf HandleClient)
                clientHandlerThread.IsBackground = True
                clientHandlerThread.Start(client)
            End While
        Catch ex As Exception
            ' Handle any exceptions that occur
            LogRequest("Server error: " & ex.Message)
        End Try
    End Sub

    Private Sub HandleClient(client As TcpClient)
        Try
            Using stream As NetworkStream = client.GetStream()
                Dim buffer(1024) As Byte
                Dim bytesRead As Integer = stream.Read(buffer, 0, buffer.Length)
                Dim request As String = BitConverter.ToString(buffer, 0, bytesRead).Replace("-", "")
                Dim REQdata(bytesRead - 1) As Byte
                Array.Copy(buffer, REQdata, bytesRead)

                ' Convert the first 3 bytes of the request to a hex string
                Dim requestPrefix As String = BitConverter.ToString(buffer, 0, 4).Replace("-", "")

                ' Log the request to the ListView
                Dim FomattedByteREQ = FormatByteArray(REQdata)
                LogRequest("Received:" & vbNewLine & FomattedByteREQ)

                ' Load responses from XML
                LoadResponses()

                ' Check if the incoming request starts with any trigger in the XML
                Dim responseBytes As Byte() = Nothing
                If responses.TryGetValue(requestPrefix, responseBytes) Then
                    ' Respond with the bytes from the XML
                    stream.Write(responseBytes, 0, responseBytes.Length)
                    Dim responseString As String = BitConverter.ToString(responseBytes, 0, responseBytes.Length).Replace("-", "")
                    Dim FomattedByteRES = FormatByteArray(responseBytes)
                    LogRequest("Responded: " & vbNewLine & FomattedByteRES)
                Else
                    ' Send the original request back to the client
                    Dim response As Byte() = buffer.Take(bytesRead).ToArray()
                    stream.Write(response, 0, response.Length)
                End If
            End Using
        Catch ex As Exception
            ' Handle any exceptions that occur
            LogRequest("Client error: " & ex.Message)
        Finally
            client.Close()
        End Try
    End Sub


    Private Sub LoadResponses()
        responses = New Dictionary(Of String, Byte())
        responses.Clear()

        Dim xml = XDocument.Load("xml/responses.xml")
        For Each responseElement In xml.Descendants("Response")
            Dim trigger = responseElement.Element("Trigger").Value
            Dim data = responseElement.Element("Data").Value.Replace(" ", "")
            Dim dataBytes As Byte() = Enumerable.Range(0, data.Length \ 2).Select(Function(i) Convert.ToByte(data.Substring(i * 2, 2), 16)).ToArray()
            responses.Add(trigger, dataBytes)
        Next
    End Sub

    Private Sub LogRequest(message As String)
        If RTF.InvokeRequired Then
            RTF.Invoke(New Action(Sub() RTF.AppendText(message & vbNewLine)))
        Else
            RTF.AppendText(message)
        End If

        Using writer As New StreamWriter(logFilePath, True)
            writer.WriteLine($"{DateTime.Now}: {vbNewLine & message}")
        End Using
    End Sub
End Class