Imports System.Net.Sockets
Imports System.Threading
Imports System.Net
Imports System.Text
Imports ChibiKart_Toolkit.Misc
Imports ChibiKart_Toolkit.Extract
Imports System.IO

Public Class Form1
    Private httpServer As HttpServer
    Private gameServer As GameServer

    Public Sub New()
        InitializeComponent()
        httpServer = New HttpServer(lbxMessages)
        gameServer = New GameServer(lbxMessages)
    End Sub

    'Load
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'Setup DIRs
        If Directory.Exists("logs") = False Then
            Directory.CreateDirectory("logs")
        End If
        If Directory.Exists("xml") = False Then
            Directory.CreateDirectory("xml")
        End If
    End Sub

    'ToolStrip
    Private Sub AboutToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AboutToolStripMenuItem.Click
        MessageBox.Show($"Chibi Kart Toolkit and Server Emulator{vbNewLine}Tool Created by @yuviapp{vbNewLine}Ver:0.01")
    End Sub
    Private Sub PAKToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PAKToolStripMenuItem.Click
        If ofdInputPAK.ShowDialog = DialogResult.OK Then
            ExtractPAK(ofdInputPAK.FileName)
        End If
    End Sub
    Private Sub XORTestToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles XORTestToolStripMenuItem.Click
        Dim InputString As String = "ly#u5"
        XorStringAndWriteToFile(InputString, "OutputXOR.txt")
    End Sub
    Private Sub DecryptStringToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DecryptStringToolStripMenuItem.Click
        DecryptNetworkini("ly#u5")
    End Sub


    'Buttons
    Private Sub btnStartGameServer_Click(sender As Object, e As EventArgs) Handles btnStartGameServer.Click
        gameServer.Start()
    End Sub
    Private Sub btnStartWebServer_Click(sender As Object, e As EventArgs) Handles btnStartWebServer.Click
        httpServer.Start()
    End Sub

End Class
