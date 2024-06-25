Imports System.Net
Imports System.Threading
Imports System.IO

Public Class HttpServer
    Private httpListener As HttpListener
    Private listenerThread As Thread
    Private logFilePath As String = "logs/http_log.txt"
    Private listBox As ListBox
    Private URLString As String = "http://127.0.0.1:80/"

    Public Sub New(listBox As ListBox)
        Me.listBox = listBox
        httpListener = New HttpListener()
        httpListener.Prefixes.Add(URLString)
        listenerThread = New Thread(AddressOf HandleRequests)
    End Sub

    Public Sub Start()
        listenerThread.Start()
        ' Log that the server has started
        LogRequest($"Web Server started and listening at {URLString}")
    End Sub

    Private Sub HandleRequests()
        httpListener.Start()
        While True
            Dim context As HttpListenerContext = httpListener.GetContext()
            Dim request As HttpListenerRequest = context.Request
            Dim response As HttpListenerResponse = context.Response

            ' Extract query string parameters
            Dim queryStringParams As String = String.Join(", ", request.QueryString.AllKeys.Select(Function(key) $"{key}={request.QueryString(key)}"))
            Dim logMessage As String = $"HTTP Request: {request.RawUrl} from {request.RemoteEndPoint}. Query Params: {queryStringParams}"
            LogRequest(logMessage)

            ' Check if the request is for the specific XML file
            If request.Url.AbsolutePath = "/static/Launcher/config/update.xml" Then
                ServeXmlFile(response, "xml/update.xml")
            Else
                ' Default response
                Dim responseString As String = "<html><body>Hello World</body></html>"
                Dim buffer() As Byte = System.Text.Encoding.UTF8.GetBytes(responseString)
                response.ContentLength64 = buffer.Length
                Dim output As Stream = response.OutputStream
                output.Write(buffer, 0, buffer.Length)
                output.Close()
            End If
        End While
    End Sub


    'Serve Response
    Private Sub ServeXmlFile(response As HttpListenerResponse, filePath As String)
        Try
            If File.Exists(filePath) Then
                Dim xmlContent As Byte() = File.ReadAllBytes(filePath)
                response.ContentType = "application/xml"
                response.ContentLength64 = xmlContent.Length
                response.OutputStream.Write(xmlContent, 0, xmlContent.Length)
                response.OutputStream.Close()
                LogRequest($"Served XML file: {filePath}")
            Else
                response.StatusCode = 404
                Dim responseString As String = "<html><body>File not found</body></html>"
                Dim buffer() As Byte = System.Text.Encoding.UTF8.GetBytes(responseString)
                response.ContentLength64 = buffer.Length
                response.OutputStream.Write(buffer, 0, buffer.Length)
                response.OutputStream.Close()
                LogRequest($"XML file not found: {filePath}")
            End If
        Catch ex As Exception
            response.StatusCode = 500
            Dim responseString As String = "<html><body>Internal Server Error</body></html>"
            Dim buffer() As Byte = System.Text.Encoding.UTF8.GetBytes(responseString)
            response.ContentLength64 = buffer.Length
            response.OutputStream.Write(buffer, 0, buffer.Length)
            response.OutputStream.Close()
            LogRequest($"Error serving XML file: {ex.Message}")
        End Try
    End Sub


    'Log Request
    Private Sub LogRequest(message As String)
        If listBox.InvokeRequired Then
            listBox.Invoke(New Action(Sub() listBox.Items.Add(message)))
        Else
            listBox.Items.Add(message)
        End If

        Using writer As New StreamWriter(logFilePath, True)
            writer.WriteLine($"{DateTime.Now}: {message}")
        End Using
    End Sub
End Class