Imports System.Net.Sockets
Imports System.Threading
Imports System.Net
Imports System.Text
Imports ChibiKart_Toolkit.Misc
Imports ChibiKart_Toolkit.Extract

Public Class Form1
    Private listener As TcpListener
    Private clientThread As Thread
    Private httplistener As HttpListener
    Private httplistenerThread As Thread
    Private responses As Dictionary(Of String, Byte())

    Private Sub PAKToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PAKToolStripMenuItem.Click
        If ofdInputPAK.ShowDialog = DialogResult.OK Then
            ExtractPAK(ofdInputPAK.FileName)
        End If
    End Sub

    Private Sub XORTestToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles XORTestToolStripMenuItem.Click
        Dim InputString As String = "ly#u5"
        XorStringAndWriteToFile(InputString, "OutputXOR.txt")
    End Sub

    Private Sub btnStartServer_Click(sender As Object, e As EventArgs) Handles btnStartServer.Click
        ' Start the server in a separate thread
        clientThread = New Thread(AddressOf StartServer)
        clientThread.IsBackground = True
        clientThread.Start()
    End Sub



    ''Games SEREVER FUNCTIONS
    Private Sub StartServer()
        Try
            listener = New TcpListener(IPAddress.Any, 50017)
            listener.Start()

            ' Log that the server has started
            Invoke(New Action(Sub() AddMessage("Server started and listening on port 50017")))

            While True
                Dim client As TcpClient = listener.AcceptTcpClient()
                Dim clientHandlerThread As New Thread(AddressOf HandleClient)
                clientHandlerThread.IsBackground = True
                clientHandlerThread.Start(client)
            End While
        Catch ex As Exception
            ' Handle any exceptions that occur
            Invoke(New Action(Sub() AddMessage("Server error: " & ex.Message)))
        End Try
    End Sub

    Private Sub LoadResponses()
        responses = New Dictionary(Of String, Byte())
        responses.Clear()

        Dim xml = XDocument.Load("responses.xml")
        For Each responseElement In xml.Descendants("Response")
            Dim trigger = responseElement.Element("Trigger").Value
            Dim data = responseElement.Element("Data").Value.Replace(" ", "")
            Dim dataBytes As Byte() = Enumerable.Range(0, data.Length \ 2).Select(Function(i) Convert.ToByte(data.Substring(i * 2, 2), 16)).ToArray()
            responses.Add(trigger, dataBytes)
        Next
    End Sub

    Private Sub HandleClient(client As TcpClient)
        Try
            Using stream As NetworkStream = client.GetStream()
                Dim buffer(1024) As Byte
                Dim bytesRead As Integer = stream.Read(buffer, 0, buffer.Length)
                Dim request As String = BitConverter.ToString(buffer, 0, bytesRead).Replace("-", "")

                ' Convert the first 3 bytes of the request to a hex string
                Dim requestPrefix As String = BitConverter.ToString(buffer, 0, 4).Replace("-", "")

                ' Log the request to the ListView
                Invoke(New Action(Sub() AddMessage("Received:    " & request)))

                ' Load responses from XML
                LoadResponses()

                ' Check if the incoming request starts with any trigger in the XML
                Dim responseBytes As Byte() = Nothing
                If responses.TryGetValue(requestPrefix, responseBytes) Then
                    ' Respond with the bytes from the XML
                    stream.Write(responseBytes, 0, responseBytes.Length)
                    Dim responseString As String = BitConverter.ToString(responseBytes, 0, responseBytes.Length).Replace("-", "")
                    Invoke(New Action(Sub() AddMessage("Responded: " & responseString)))
                Else
                    ' Send the original request back to the client
                    Dim response As Byte() = buffer.Take(bytesRead).ToArray()
                    stream.Write(response, 0, response.Length)
                End If
            End Using
        Catch ex As Exception
            ' Handle any exceptions that occur
            Invoke(New Action(Sub() AddMessage("Client error: " & ex.Message)))
        Finally
            client.Close()
        End Try
    End Sub

    Private Sub AddMessage(message As String)
        lbxMessages.Items.Add(message)
        lbxMessages.TopIndex = lbxMessages.Items.Count - 1
        lbxMessages.SelectedIndex = lbxMessages.Items.Count - 1
    End Sub

    Private Sub Form1_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        If listener IsNot Nothing Then
            listener.Stop()
        End If

        If clientThread IsNot Nothing AndAlso clientThread.IsAlive Then
            clientThread.Abort()
        End If

        httplistener.Stop()
        httplistenerThread.Abort()
    End Sub

    Private Sub DecryptStringToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DecryptStringToolStripMenuItem.Click
        DecryptNetworkini("ly#u5")
    End Sub


    'Web Server Functions   
    Private Sub btnStartWebServer_Click(sender As Object, e As EventArgs) Handles btnStartWebServer.Click
        httplistener = New HttpListener()
        httplistener.Prefixes.Add("http://127.0.0.1:80/")
        httplistener.Start()

        httplistenerThread = New Thread(New ThreadStart(AddressOf HTTPListenForRequests))
        httplistenerThread.IsBackground = True
        httplistenerThread.Start()
        Invoke(New Action(Sub() AddMessage("HTTP Server Started Listening at 127.0.0.1:80")))
    End Sub

    Private Sub HTTPListenForRequests()
        While httplistener.IsListening
            Try
                Dim context As HttpListenerContext = httplistener.GetContext()
                Dim request As HttpListenerRequest = context.Request

                ' Log the incoming request to the ListBox
                Dim requestInfo As String = $"{DateTime.Now}: {request.HttpMethod} {request.RawUrl}"
                Invoke(New Action(Sub() AddMessage("Request: " & requestInfo)))

                ' Check the request path
                If request.Url.AbsolutePath = "/static/Launcher/config/update.xml" Then
                    ' Serve the update.xml file
                    Dim filePath As String = "update.xml"
                    If System.IO.File.Exists(filePath) Then
                        Dim response As HttpListenerResponse = context.Response
                        response.ContentType = "application/xml"
                        Dim buffer() As Byte = System.IO.File.ReadAllBytes(filePath)
                        response.ContentLength64 = buffer.Length
                        response.OutputStream.Write(buffer, 0, buffer.Length)
                        response.OutputStream.Close()
                    Else
                        ' File not found, return 404
                        context.Response.StatusCode = 404
                        context.Response.StatusDescription = "Not Found"
                        context.Response.OutputStream.Close()
                    End If
                Else
                    ' Default response for other requests
                    Dim responseString As String = "<html><body><h1>Hello, World</h1></body></html>"
                    Dim buffer() As Byte = Encoding.UTF8.GetBytes(responseString)
                    Dim response As HttpListenerResponse = context.Response
                    response.ContentLength64 = buffer.Length
                    response.OutputStream.Write(buffer, 0, buffer.Length)
                    response.OutputStream.Close()
                End If
            Catch ex As Exception
                ' Handle exceptions if necessary
            End Try
        End While
    End Sub

    Private Sub AboutToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AboutToolStripMenuItem.Click
        MessageBox.Show($"Chibi Kart Toolkit and Server Emulator{vbNewLine}Tool Created by @yuviapp{vbNewLine}Ver:0.01")
    End Sub
End Class
