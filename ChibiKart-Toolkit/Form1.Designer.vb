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
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.FileToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AboutToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ExportToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.PAKToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ImportToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.MiscToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.XORTestToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.DecryptStringToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.btnStartGameServer = New System.Windows.Forms.Button()
        Me.lbxMessages = New System.Windows.Forms.ListBox()
        Me.ofdInputPAK = New System.Windows.Forms.OpenFileDialog()
        Me.btnStartWebServer = New System.Windows.Forms.Button()
        Me.MenuStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.FileToolStripMenuItem, Me.ExportToolStripMenuItem, Me.ImportToolStripMenuItem, Me.MiscToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(1197, 24)
        Me.MenuStrip1.TabIndex = 0
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'FileToolStripMenuItem
        '
        Me.FileToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.AboutToolStripMenuItem})
        Me.FileToolStripMenuItem.Name = "FileToolStripMenuItem"
        Me.FileToolStripMenuItem.Size = New System.Drawing.Size(37, 20)
        Me.FileToolStripMenuItem.Text = "File"
        '
        'AboutToolStripMenuItem
        '
        Me.AboutToolStripMenuItem.Name = "AboutToolStripMenuItem"
        Me.AboutToolStripMenuItem.Size = New System.Drawing.Size(107, 22)
        Me.AboutToolStripMenuItem.Text = "About"
        '
        'ExportToolStripMenuItem
        '
        Me.ExportToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.PAKToolStripMenuItem})
        Me.ExportToolStripMenuItem.Name = "ExportToolStripMenuItem"
        Me.ExportToolStripMenuItem.Size = New System.Drawing.Size(53, 20)
        Me.ExportToolStripMenuItem.Text = "Export"
        '
        'PAKToolStripMenuItem
        '
        Me.PAKToolStripMenuItem.Name = "PAKToolStripMenuItem"
        Me.PAKToolStripMenuItem.Size = New System.Drawing.Size(95, 22)
        Me.PAKToolStripMenuItem.Text = "PAK"
        '
        'ImportToolStripMenuItem
        '
        Me.ImportToolStripMenuItem.Name = "ImportToolStripMenuItem"
        Me.ImportToolStripMenuItem.Size = New System.Drawing.Size(55, 20)
        Me.ImportToolStripMenuItem.Text = "Import"
        '
        'MiscToolStripMenuItem
        '
        Me.MiscToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.XORTestToolStripMenuItem, Me.DecryptStringToolStripMenuItem})
        Me.MiscToolStripMenuItem.Name = "MiscToolStripMenuItem"
        Me.MiscToolStripMenuItem.Size = New System.Drawing.Size(44, 20)
        Me.MiscToolStripMenuItem.Text = "Misc"
        '
        'XORTestToolStripMenuItem
        '
        Me.XORTestToolStripMenuItem.Name = "XORTestToolStripMenuItem"
        Me.XORTestToolStripMenuItem.Size = New System.Drawing.Size(146, 22)
        Me.XORTestToolStripMenuItem.Text = "XOR Test"
        '
        'DecryptStringToolStripMenuItem
        '
        Me.DecryptStringToolStripMenuItem.Name = "DecryptStringToolStripMenuItem"
        Me.DecryptStringToolStripMenuItem.Size = New System.Drawing.Size(146, 22)
        Me.DecryptStringToolStripMenuItem.Text = "DecryptString"
        '
        'btnStartGameServer
        '
        Me.btnStartGameServer.Location = New System.Drawing.Point(12, 27)
        Me.btnStartGameServer.Name = "btnStartGameServer"
        Me.btnStartGameServer.Size = New System.Drawing.Size(126, 34)
        Me.btnStartGameServer.TabIndex = 1
        Me.btnStartGameServer.Text = "Start Game Server"
        Me.btnStartGameServer.UseVisualStyleBackColor = True
        '
        'lbxMessages
        '
        Me.lbxMessages.FormattingEnabled = True
        Me.lbxMessages.ItemHeight = 15
        Me.lbxMessages.Location = New System.Drawing.Point(12, 77)
        Me.lbxMessages.Name = "lbxMessages"
        Me.lbxMessages.Size = New System.Drawing.Size(1173, 529)
        Me.lbxMessages.TabIndex = 2
        '
        'ofdInputPAK
        '
        Me.ofdInputPAK.FileName = "OpenFileDialog1"
        '
        'btnStartWebServer
        '
        Me.btnStartWebServer.Location = New System.Drawing.Point(204, 27)
        Me.btnStartWebServer.Name = "btnStartWebServer"
        Me.btnStartWebServer.Size = New System.Drawing.Size(157, 34)
        Me.btnStartWebServer.TabIndex = 3
        Me.btnStartWebServer.Text = "Start Web Server"
        Me.btnStartWebServer.UseVisualStyleBackColor = True
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1197, 626)
        Me.Controls.Add(Me.btnStartWebServer)
        Me.Controls.Add(Me.lbxMessages)
        Me.Controls.Add(Me.btnStartGameServer)
        Me.Controls.Add(Me.MenuStrip1)
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Name = "Form1"
        Me.Text = "Chibi Kart POC Server Toolkit"
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents MenuStrip1 As MenuStrip
    Friend WithEvents FileToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ExportToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ImportToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents MiscToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents XORTestToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents btnStartGameServer As Button
    Friend WithEvents lbxMessages As ListBox
    Friend WithEvents PAKToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ofdInputPAK As OpenFileDialog
    Friend WithEvents DecryptStringToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents btnStartWebServer As Button
    Friend WithEvents AboutToolStripMenuItem As ToolStripMenuItem

End Class
