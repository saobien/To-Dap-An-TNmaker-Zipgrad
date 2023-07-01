<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
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
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form1))
        Me.Label_thongbao = New System.Windows.Forms.Label()
        Me.TextBox3 = New System.Windows.Forms.TextBox()
        Me.Bt_W2E = New System.Windows.Forms.Button()
        Me.Bt_TODA = New System.Windows.Forms.Button()
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog()
        Me.SaveFileDialog1 = New System.Windows.Forms.SaveFileDialog()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Bt_THOAT = New System.Windows.Forms.Button()
        Me.Bt_NAPDA = New System.Windows.Forms.Button()
        Me.ComboBox_MAU = New System.Windows.Forms.ComboBox()
        Me.ComboBox_MADE = New System.Windows.Forms.ComboBox()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.ProgressBar1 = New System.Windows.Forms.ProgressBar()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.RadioButton3 = New System.Windows.Forms.RadioButton()
        Me.RadioButton1 = New System.Windows.Forms.RadioButton()
        Me.RadioButton2 = New System.Windows.Forms.RadioButton()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.PicDraw = New System.Windows.Forms.PictureBox()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.Bt_BROWSE = New System.Windows.Forms.Button()
        Me.txtSource = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.dlgFolderSelect = New System.Windows.Forms.FolderBrowserDialog()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.Timer2 = New System.Windows.Forms.Timer(Me.components)
        Me.Timer3 = New System.Windows.Forms.Timer(Me.components)
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        CType(Me.PicDraw, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox3.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label_thongbao
        '
        Me.Label_thongbao.AutoSize = True
        Me.Label_thongbao.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label_thongbao.Location = New System.Drawing.Point(16, 359)
        Me.Label_thongbao.Name = "Label_thongbao"
        Me.Label_thongbao.Size = New System.Drawing.Size(204, 13)
        Me.Label_thongbao.TabIndex = 1
        Me.Label_thongbao.Text = "(Có tất cả...mã đề và mỗi mã đề có...câu)"
        '
        'TextBox3
        '
        Me.TextBox3.BackColor = System.Drawing.Color.White
        Me.TextBox3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TextBox3.Location = New System.Drawing.Point(7, 16)
        Me.TextBox3.Multiline = True
        Me.TextBox3.Name = "TextBox3"
        Me.TextBox3.Size = New System.Drawing.Size(120, 71)
        Me.TextBox3.TabIndex = 5
        '
        'Bt_W2E
        '
        Me.Bt_W2E.BackColor = System.Drawing.Color.LimeGreen
        Me.Bt_W2E.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Bt_W2E.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Bt_W2E.ForeColor = System.Drawing.Color.White
        Me.Bt_W2E.Location = New System.Drawing.Point(12, 567)
        Me.Bt_W2E.Name = "Bt_W2E"
        Me.Bt_W2E.Size = New System.Drawing.Size(91, 40)
        Me.Bt_W2E.TabIndex = 4
        Me.Bt_W2E.Text = "NẠP TỪ WORD"
        Me.Bt_W2E.UseVisualStyleBackColor = False
        '
        'Bt_TODA
        '
        Me.Bt_TODA.BackColor = System.Drawing.Color.LimeGreen
        Me.Bt_TODA.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Bt_TODA.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Bt_TODA.ForeColor = System.Drawing.Color.White
        Me.Bt_TODA.Location = New System.Drawing.Point(250, 568)
        Me.Bt_TODA.Name = "Bt_TODA"
        Me.Bt_TODA.Size = New System.Drawing.Size(91, 40)
        Me.Bt_TODA.TabIndex = 9
        Me.Bt_TODA.Text = "TÔ ĐÁP ÁN"
        Me.Bt_TODA.UseVisualStyleBackColor = False
        '
        'OpenFileDialog1
        '
        Me.OpenFileDialog1.FileName = "OpenFileDialog1"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(6, 19)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(58, 13)
        Me.Label4.TabIndex = 13
        Me.Label4.Text = "Mẫu Phiếu"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(107, 19)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(39, 13)
        Me.Label5.TabIndex = 14
        Me.Label5.Text = "Mã Đề"
        '
        'Bt_THOAT
        '
        Me.Bt_THOAT.BackColor = System.Drawing.Color.LimeGreen
        Me.Bt_THOAT.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Bt_THOAT.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Bt_THOAT.ForeColor = System.Drawing.Color.White
        Me.Bt_THOAT.Location = New System.Drawing.Point(368, 567)
        Me.Bt_THOAT.Name = "Bt_THOAT"
        Me.Bt_THOAT.Size = New System.Drawing.Size(91, 40)
        Me.Bt_THOAT.TabIndex = 10
        Me.Bt_THOAT.Text = "THOÁT"
        Me.Bt_THOAT.UseVisualStyleBackColor = False
        '
        'Bt_NAPDA
        '
        Me.Bt_NAPDA.BackColor = System.Drawing.Color.LimeGreen
        Me.Bt_NAPDA.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Bt_NAPDA.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Bt_NAPDA.ForeColor = System.Drawing.Color.White
        Me.Bt_NAPDA.Location = New System.Drawing.Point(129, 567)
        Me.Bt_NAPDA.Name = "Bt_NAPDA"
        Me.Bt_NAPDA.Size = New System.Drawing.Size(91, 40)
        Me.Bt_NAPDA.TabIndex = 5
        Me.Bt_NAPDA.Text = "NẠP TỪ EXCEL"
        Me.Bt_NAPDA.UseVisualStyleBackColor = False
        '
        'ComboBox_MAU
        '
        Me.ComboBox_MAU.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBox_MAU.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ComboBox_MAU.FormattingEnabled = True
        Me.ComboBox_MAU.Location = New System.Drawing.Point(6, 38)
        Me.ComboBox_MAU.Name = "ComboBox_MAU"
        Me.ComboBox_MAU.Size = New System.Drawing.Size(85, 21)
        Me.ComboBox_MAU.TabIndex = 17
        '
        'ComboBox_MADE
        '
        Me.ComboBox_MADE.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBox_MADE.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ComboBox_MADE.FormattingEnabled = True
        Me.ComboBox_MADE.Location = New System.Drawing.Point(110, 38)
        Me.ComboBox_MADE.Name = "ComboBox_MADE"
        Me.ComboBox_MADE.Size = New System.Drawing.Size(85, 21)
        Me.ComboBox_MADE.TabIndex = 18
        '
        'DataGridView1
        '
        Me.DataGridView1.AllowUserToResizeColumns = False
        Me.DataGridView1.AllowUserToResizeRows = False
        Me.DataGridView1.BackgroundColor = System.Drawing.Color.White
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.GridColor = System.Drawing.Color.White
        Me.DataGridView1.Location = New System.Drawing.Point(12, 12)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.ReadOnly = True
        Me.DataGridView1.Size = New System.Drawing.Size(448, 334)
        Me.DataGridView1.TabIndex = 19
        '
        'ProgressBar1
        '
        Me.ProgressBar1.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.ProgressBar1.Location = New System.Drawing.Point(0, 613)
        Me.ProgressBar1.Name = "ProgressBar1"
        Me.ProgressBar1.Size = New System.Drawing.Size(978, 10)
        Me.ProgressBar1.TabIndex = 22
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.RadioButton3)
        Me.GroupBox1.Controls.Add(Me.RadioButton1)
        Me.GroupBox1.Controls.Add(Me.RadioButton2)
        Me.GroupBox1.Controls.Add(Me.TextBox3)
        Me.GroupBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.Location = New System.Drawing.Point(12, 416)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(240, 98)
        Me.GroupBox1.TabIndex = 1
        Me.GroupBox1.TabStop = False
        '
        'RadioButton3
        '
        Me.RadioButton3.AutoSize = True
        Me.RadioButton3.Location = New System.Drawing.Point(141, 63)
        Me.RadioButton3.Name = "RadioButton3"
        Me.RadioButton3.Size = New System.Drawing.Size(55, 17)
        Me.RadioButton3.TabIndex = 30
        Me.RadioButton3.TabStop = True
        Me.RadioButton3.Text = "BTPro"
        Me.RadioButton3.UseVisualStyleBackColor = True
        '
        'RadioButton1
        '
        Me.RadioButton1.AutoSize = True
        Me.RadioButton1.Checked = True
        Me.RadioButton1.Location = New System.Drawing.Point(141, 19)
        Me.RadioButton1.Name = "RadioButton1"
        Me.RadioButton1.Size = New System.Drawing.Size(93, 17)
        Me.RadioButton1.TabIndex = 28
        Me.RadioButton1.TabStop = True
        Me.RadioButton1.Text = "Trnghiem5.xPr"
        Me.RadioButton1.UseVisualStyleBackColor = True
        '
        'RadioButton2
        '
        Me.RadioButton2.AutoSize = True
        Me.RadioButton2.Location = New System.Drawing.Point(141, 40)
        Me.RadioButton2.Name = "RadioButton2"
        Me.RadioButton2.Size = New System.Drawing.Size(76, 17)
        Me.RadioButton2.TabIndex = 29
        Me.RadioButton2.TabStop = True
        Me.RadioButton2.Text = "Smart Test"
        Me.RadioButton2.UseVisualStyleBackColor = True
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.ComboBox_MAU)
        Me.GroupBox2.Controls.Add(Me.ComboBox_MADE)
        Me.GroupBox2.Controls.Add(Me.Label4)
        Me.GroupBox2.Controls.Add(Me.Label5)
        Me.GroupBox2.Location = New System.Drawing.Point(258, 416)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(201, 74)
        Me.GroupBox2.TabIndex = 6
        Me.GroupBox2.TabStop = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(16, 400)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(179, 13)
        Me.Label1.TabIndex = 28
        Me.Label1.Text = "Chép đáp án từ Word vào đây"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(264, 400)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(189, 13)
        Me.Label2.TabIndex = 29
        Me.Label2.Text = "Chọn mẫu phiếu và mã đề để tô"
        '
        'PicDraw
        '
        Me.PicDraw.BackColor = System.Drawing.Color.Transparent
        Me.PicDraw.Location = New System.Drawing.Point(486, 12)
        Me.PicDraw.Name = "PicDraw"
        Me.PicDraw.Size = New System.Drawing.Size(466, 596)
        Me.PicDraw.TabIndex = 10
        Me.PicDraw.TabStop = False
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.Bt_BROWSE)
        Me.GroupBox3.Controls.Add(Me.txtSource)
        Me.GroupBox3.Location = New System.Drawing.Point(12, 517)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(447, 42)
        Me.GroupBox3.TabIndex = 30
        Me.GroupBox3.TabStop = False
        '
        'Bt_BROWSE
        '
        Me.Bt_BROWSE.BackColor = System.Drawing.Color.LimeGreen
        Me.Bt_BROWSE.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Bt_BROWSE.ForeColor = System.Drawing.Color.White
        Me.Bt_BROWSE.Location = New System.Drawing.Point(356, 12)
        Me.Bt_BROWSE.Name = "Bt_BROWSE"
        Me.Bt_BROWSE.Size = New System.Drawing.Size(81, 23)
        Me.Bt_BROWSE.TabIndex = 1
        Me.Bt_BROWSE.Text = "Đường dẫn"
        Me.Bt_BROWSE.UseVisualStyleBackColor = False
        '
        'txtSource
        '
        Me.txtSource.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtSource.Location = New System.Drawing.Point(7, 17)
        Me.txtSource.Name = "txtSource"
        Me.txtSource.ReadOnly = True
        Me.txtSource.Size = New System.Drawing.Size(331, 13)
        Me.txtSource.TabIndex = 0
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(264, 501)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(185, 13)
        Me.Label3.TabIndex = 31
        Me.Label3.Text = "Chọn nơi lưu kết quả sau khi tô"
        '
        'Timer1
        '
        Me.Timer1.Interval = 7000
        '
        'Timer2
        '
        Me.Timer2.Interval = 7000
        '
        'Timer3
        '
        Me.Timer3.Interval = 7000
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.ClientSize = New System.Drawing.Size(964, 619)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.ProgressBar1)
        Me.Controls.Add(Me.DataGridView1)
        Me.Controls.Add(Me.Bt_NAPDA)
        Me.Controls.Add(Me.Bt_THOAT)
        Me.Controls.Add(Me.PicDraw)
        Me.Controls.Add(Me.Bt_TODA)
        Me.Controls.Add(Me.Bt_W2E)
        Me.Controls.Add(Me.Label_thongbao)
        Me.DoubleBuffered = True
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MaximumSize = New System.Drawing.Size(980, 657)
        Me.MinimumSize = New System.Drawing.Size(980, 657)
        Me.Name = "Form1"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "TickZT v1.0.5--->TÔ ĐÁP ÁN (ZIPGRADE, TNMAKER)                              Code " & _
    "By: Trần Quốc Minh (GV Trường THPT Văn Hiến, tp Long Khánh, tỉnh Đồng Nai)"
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        CType(Me.PicDraw, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label_thongbao As System.Windows.Forms.Label
    Friend WithEvents TextBox3 As System.Windows.Forms.TextBox
    Friend WithEvents Bt_W2E As System.Windows.Forms.Button
    Friend WithEvents Bt_TODA As System.Windows.Forms.Button
    Friend WithEvents PicDraw As System.Windows.Forms.PictureBox
    Friend WithEvents OpenFileDialog1 As System.Windows.Forms.OpenFileDialog
    Friend WithEvents SaveFileDialog1 As System.Windows.Forms.SaveFileDialog
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Bt_THOAT As System.Windows.Forms.Button
    Friend WithEvents Bt_NAPDA As System.Windows.Forms.Button
    Friend WithEvents ComboBox_MAU As System.Windows.Forms.ComboBox
    Friend WithEvents ComboBox_MADE As System.Windows.Forms.ComboBox
    Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView
    Friend WithEvents ProgressBar1 As System.Windows.Forms.ProgressBar
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents RadioButton1 As System.Windows.Forms.RadioButton
    Friend WithEvents RadioButton2 As System.Windows.Forms.RadioButton
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents Bt_BROWSE As System.Windows.Forms.Button
    Friend WithEvents txtSource As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents dlgFolderSelect As System.Windows.Forms.FolderBrowserDialog
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
    Friend WithEvents Timer2 As System.Windows.Forms.Timer
    Friend WithEvents RadioButton3 As System.Windows.Forms.RadioButton
    Friend WithEvents Timer3 As System.Windows.Forms.Timer

End Class
