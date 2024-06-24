<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        MenuStrip1 = New MenuStrip()
        FileToolStripMenuItem = New ToolStripMenuItem()
        ExportToolStripMenuItem = New ToolStripMenuItem()
        PAKToolStripMenuItem = New ToolStripMenuItem()
        ImportToolStripMenuItem = New ToolStripMenuItem()
        MiscToolStripMenuItem = New ToolStripMenuItem()
        XORTestToolStripMenuItem = New ToolStripMenuItem()
        DecryptStringToolStripMenuItem = New ToolStripMenuItem()
        btnStartServer = New Button()
        lbxMessages = New ListBox()
        ofdInputPAK = New OpenFileDialog()
        btnStartWebServer = New Button()
        AboutToolStripMenuItem = New ToolStripMenuItem()
        MenuStrip1.SuspendLayout()
        SuspendLayout()
        ' 
        ' MenuStrip1
        ' 
        MenuStrip1.Items.AddRange(New ToolStripItem() {FileToolStripMenuItem, ExportToolStripMenuItem, ImportToolStripMenuItem, MiscToolStripMenuItem})
        MenuStrip1.Location = New Point(0, 0)
        MenuStrip1.Name = "MenuStrip1"
        MenuStrip1.Size = New Size(800, 24)
        MenuStrip1.TabIndex = 0
        MenuStrip1.Text = "MenuStrip1"
        ' 
        ' FileToolStripMenuItem
        ' 
        FileToolStripMenuItem.DropDownItems.AddRange(New ToolStripItem() {AboutToolStripMenuItem})
        FileToolStripMenuItem.Name = "FileToolStripMenuItem"
        FileToolStripMenuItem.Size = New Size(37, 20)
        FileToolStripMenuItem.Text = "File"
        ' 
        ' ExportToolStripMenuItem
        ' 
        ExportToolStripMenuItem.DropDownItems.AddRange(New ToolStripItem() {PAKToolStripMenuItem})
        ExportToolStripMenuItem.Name = "ExportToolStripMenuItem"
        ExportToolStripMenuItem.Size = New Size(53, 20)
        ExportToolStripMenuItem.Text = "Export"
        ' 
        ' PAKToolStripMenuItem
        ' 
        PAKToolStripMenuItem.Name = "PAKToolStripMenuItem"
        PAKToolStripMenuItem.Size = New Size(95, 22)
        PAKToolStripMenuItem.Text = "PAK"
        ' 
        ' ImportToolStripMenuItem
        ' 
        ImportToolStripMenuItem.Name = "ImportToolStripMenuItem"
        ImportToolStripMenuItem.Size = New Size(55, 20)
        ImportToolStripMenuItem.Text = "Import"
        ' 
        ' MiscToolStripMenuItem
        ' 
        MiscToolStripMenuItem.DropDownItems.AddRange(New ToolStripItem() {XORTestToolStripMenuItem, DecryptStringToolStripMenuItem})
        MiscToolStripMenuItem.Name = "MiscToolStripMenuItem"
        MiscToolStripMenuItem.Size = New Size(44, 20)
        MiscToolStripMenuItem.Text = "Misc"
        ' 
        ' XORTestToolStripMenuItem
        ' 
        XORTestToolStripMenuItem.Name = "XORTestToolStripMenuItem"
        XORTestToolStripMenuItem.Size = New Size(146, 22)
        XORTestToolStripMenuItem.Text = "XOR Test"
        ' 
        ' DecryptStringToolStripMenuItem
        ' 
        DecryptStringToolStripMenuItem.Name = "DecryptStringToolStripMenuItem"
        DecryptStringToolStripMenuItem.Size = New Size(146, 22)
        DecryptStringToolStripMenuItem.Text = "DecryptString"
        ' 
        ' btnStartServer
        ' 
        btnStartServer.Location = New Point(12, 27)
        btnStartServer.Name = "btnStartServer"
        btnStartServer.Size = New Size(126, 34)
        btnStartServer.TabIndex = 1
        btnStartServer.Text = "Start Game Server"
        btnStartServer.UseVisualStyleBackColor = True
        ' 
        ' lbxMessages
        ' 
        lbxMessages.FormattingEnabled = True
        lbxMessages.ItemHeight = 15
        lbxMessages.Location = New Point(12, 77)
        lbxMessages.Name = "lbxMessages"
        lbxMessages.Size = New Size(776, 364)
        lbxMessages.TabIndex = 2
        ' 
        ' ofdInputPAK
        ' 
        ofdInputPAK.FileName = "OpenFileDialog1"
        ' 
        ' btnStartWebServer
        ' 
        btnStartWebServer.Location = New Point(204, 27)
        btnStartWebServer.Name = "btnStartWebServer"
        btnStartWebServer.Size = New Size(157, 34)
        btnStartWebServer.TabIndex = 3
        btnStartWebServer.Text = "Start Web Server"
        btnStartWebServer.UseVisualStyleBackColor = True
        ' 
        ' AboutToolStripMenuItem
        ' 
        AboutToolStripMenuItem.Name = "AboutToolStripMenuItem"
        AboutToolStripMenuItem.Size = New Size(180, 22)
        AboutToolStripMenuItem.Text = "About"
        ' 
        ' Form1
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(800, 455)
        Controls.Add(btnStartWebServer)
        Controls.Add(lbxMessages)
        Controls.Add(btnStartServer)
        Controls.Add(MenuStrip1)
        MainMenuStrip = MenuStrip1
        Name = "Form1"
        Text = "Form1"
        MenuStrip1.ResumeLayout(False)
        MenuStrip1.PerformLayout()
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents MenuStrip1 As MenuStrip
    Friend WithEvents FileToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ExportToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ImportToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents MiscToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents XORTestToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents btnStartServer As Button
    Friend WithEvents lbxMessages As ListBox
    Friend WithEvents PAKToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ofdInputPAK As OpenFileDialog
    Friend WithEvents DecryptStringToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents btnStartWebServer As Button
    Friend WithEvents AboutToolStripMenuItem As ToolStripMenuItem

End Class
