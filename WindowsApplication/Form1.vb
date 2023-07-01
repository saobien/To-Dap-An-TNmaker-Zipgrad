'Imports System.Linq
Imports System.Data.SqlClient
Imports System.Data.OleDb
'Imports Microsoft.Office.Core
Imports Excel = Microsoft.Office.Interop.Excel
Imports ExcelAutoFormat = Microsoft.Office.Interop.Excel.XlRangeAutoFormat
Imports Microsoft.Office.Interop
Imports System.Xml.XPath
Imports System.Data
Imports System.Xml
Imports PdfSharp.Pdf
Imports PdfSharp
Imports PdfSharp.Drawing
Imports System.IO

Public Class Form1

    Public TONGCAU As Integer
    Public SOCAU As Integer
    Public SOMA As Integer

    Private Property xImg As PdfSharp.Drawing.XImage

    Private Sub Bt_W2E_Click(sender As Object, e As EventArgs) Handles Bt_W2E.Click
        Dim DATA As String
        Dim KT As Boolean = True

        'LAY DU LIEU TU TEXT BOX
        DATA = TextBox3.Text

        On Error GoTo err
        'KIEM TRA KIEU DU LIEU ĐỂ CHUYỂN CHO PHÙ HỢP
        If RadioButton1.Checked = True Then
            W2E_PVT(DATA, KT)
            If KT = False Then GoTo ERR
        ElseIf RadioButton2.Checked = True Then
            W2E_SMT(DATA, KT)
            If KT = False Then GoTo ERR
        Else
            W2E_BTP(DATA, KT)
            If KT = False Then GoTo ERR
        End If

        'Save the Workbook and Quit Excel
        If MsgBox("Đã nạp xong. Bạn có thể chọn mẫu phiếu và mã đề để tô đáp án hoặc lưu lại thành file excel để dùng nạp cho TNMaker. Bạn có muốn lưu không?", MsgBoxStyle.YesNo, "Thông báo") = MsgBoxResult.Yes Then
            SaveFileDialog1.Filter = "Excel Document (*.xlsx)|*.xlsx"
            If SaveFileDialog1.ShowDialog() = System.Windows.Forms.DialogResult.OK Then
                LUU_EXCEL()
                MsgBox("Đã lưu xong" & vbCrLf & "Tập tin được lưu tại: " & SaveFileDialog1.FileName, MsgBoxStyle.Information, "Thông báo")
            End If
        End If
        TextBox3.Text = ""
        Bt_W2E.Enabled = False
        RadioButton1.Enabled = False
        RadioButton2.Enabled = False
        RadioButton3.Enabled = False
        ComboBox_MAU.Enabled = True
        ComboBox_MADE.Enabled = True
        ComboBox_MADE.SelectedIndex = 0
        ComboBox_MAU.SelectedIndex = 0

        Exit Sub
err:
        MsgBox("Mẫu đáp án chép vào không phù hợp", MsgBoxStyle.Information, "Thông báo")
        DataGridView1.Columns.Clear()
        TextBox3.Text = ""
        Bt_W2E.Enabled = False
        ComboBox_MAU.Enabled = False
        ComboBox_MADE.Enabled = False
    End Sub


    Private Sub Bt_TODA_Click(sender As Object, e As EventArgs) Handles Bt_TODA.Click
        'KHAI BAO BIEN BITMAP VA TOA DO X,Y
        Dim bm As New Bitmap(PicDraw.Width, PicDraw.Height)
        Dim myGraphic As Graphics = Graphics.FromImage(bm)
        Dim imgBack As Image

        Dim pdf As New PdfDocument

        '    Dim page As PdfPage
        '   Dim GR As XGraphics
        '    Dim font As XFont = New XFont("Verdana", 20, XFontStyle.Bold)

        Dim MAU, MADE, TIME As String

        MAU = ComboBox_MAU.Text

        '   MADE = ComboBox_MADE.Text
        MADE = ComboBox_MADE.SelectedIndex

        TONGCAU = Val(DataGridView1.RowCount - 2)
        SOCAU = Val(DataGridView1(2, TONGCAU).Value)
        SOMA = TONGCAU / SOCAU

        TIME = Replace(Now.ToLongTimeString, ":", "_")
        ProgressBar1.Value = 0

        '    If txtSource.Text = "" Then
        'MsgBox("Bạn phải chọn đường dẫn để lưu kết quả sau khi tô.", MsgBoxStyle.Information, "Thông báo")
        '   Exit Sub
        '  End If

        'kiem tra chon ma de nao de to, sau do to len phieu phu hop rồi luu dưới dạng file png (mac định)

        '    If MADE <> "Tô hết các mã đề" Then
        If MADE <> 0 Then
            imgBack = PicDraw.BackgroundImage
            bm = PicDraw.BackgroundImage
            TODA_LUACHON(bm, MAU, MADE, SOCAU)
            myGraphic.DrawImageUnscaled(imgBack, 0, 0)
            myGraphic.DrawImageUnscaled(bm, 0, 0)
            myGraphic.Save()
            PicDraw.Image = bm
            MADE = ComboBox_MADE.Text

            bm.Save(txtSource.Text & "\" & TIME & "_" & MAU & "_" & MADE & ".png")

        Else
            For I = 1 To SOMA
                imgBack = PicDraw.BackgroundImage
                bm = PicDraw.BackgroundImage
                MADE = I
                TODA_LUACHON(bm, MAU, MADE, SOCAU)
                myGraphic.DrawImageUnscaled(imgBack, 0, 0)
                myGraphic.DrawImageUnscaled(bm, 0, 0)
                myGraphic.Save()
                PicDraw.Image = bm
                MADE = "Mã đề " & DataGridView1(1, I * SOCAU - 1).Value.ToString
                bm.Save(txtSource.Text & "\" & TIME & "_" & MAU & "_" & MADE & ".png")
                NAP_MAU(MAU)
            Next
        End If

        MADE = ComboBox_MADE.Text
        ProgressBar1.Value = 5

        Select Case MADE
            Case "Tô hết các mã đề"
                For I = 1 To SOMA
                    ' lay thong tin ma de
                    MADE = "Mã đề " & DataGridView1(1, I * SOCAU - 1).Value.ToString
                    'chuyen anh thanh pdf
                    IMG_PDF(MAU, MADE, TIME, pdf)

                    ProgressBar1.Value = (I / SOMA) * 100
                    'xoa file anh
                    File.Delete(txtSource.Text & "\" & TIME & "_" & MAU & "_" & MADE & ".png")
                Next
                'lưu thành file pdf
                pdf.Save(txtSource.Text & "\" & TIME & "_" & MAU & "_" & "ALL" & ".pdf")
            Case Else
                ProgressBar1.Value = 50
                'chuyen anh thanh pdf
                IMG_PDF(MAU, MADE, TIME, pdf)
                'xoa file anh
                File.Delete(txtSource.Text & "\" & TIME & "_" & MAU & "_" & MADE & ".png")
                ProgressBar1.Value = 100
                'lưu thành file pdf
                pdf.Save(txtSource.Text & "\" & TIME & "_" & MAU & "_" & MADE & ".pdf")
        End Select
        'đóng pdf
        pdf.Close()
        ' hoi xem co muon mo thu muc chua file da tao hay ko
        If MsgBox("Đã tô xong. Bạn có muốn mở thư mục đã lưu không?", MsgBoxStyle.OkCancel, "Thông báo") = MsgBoxResult.Ok Then Process.Start("explorer.exe", txtSource.Text)
    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        '  TextBox3.Text = Replace(Application.ExecutablePath, Application.ProductName & ".exe", "", , , vbTextCompare)
        txtSource.Text = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)
        'THUOC TINH OPEN FILE DIALOG (OFP)
        OpenFileDialog1.Title = "CHỌN FILE"
        '   OpenFileDialog1.Filter = "WINDOWS BITMAP|*.BMP|JPEG IMAGE|*.JPG|PNG IMAGE|*.PNG|ALL FILES|*.*"
        '  OpenFileDialog1.Filter = "All Files (*.*)|*.*|Excel files (*.xlsx)|*.xlsx|CSV Files (*.csv)|*.csv|XLS Files (*.xls)|*xls"
        OpenFileDialog1.Filter = "Excel files (*.xls; *.xlsx)|*.xls;*.xlsx"

        'THUOC TINH SAVE FILE DIALOG (OFP)
        SaveFileDialog1.Title = "LƯU FILE"
        SaveFileDialog1.Filter = "PDF files|*.pdf|ALL FILES|*.*"


        'THUOC TINH PICTURE BOX
        ' PicDraw.BackgroundImage = Image.FromFile("C:\Users\Win7\Desktop\thu nghiem\Z50.png")
        PicDraw.BackgroundImageLayout = PictureBoxSizeMode.Zoom
        PicDraw.SizeMode = PictureBoxSizeMode.Zoom

        '   PicDraw.BackgroundImage = TickZT.My.Resources.mau_PVT
        'test

        'THUOC TINH DATAGRIDVIEW
        DataGridView1.EnableHeadersVisualStyles = False
        DataGridView1.ReadOnly = True
        DataGridView1.ColumnHeadersDefaultCellStyle.BackColor = Color.LightGreen
        DataGridView1.RowHeadersDefaultCellStyle.BackColor = Color.Snow
        'THUOC TINH COMBOBOX
        ComboBox_MADE.DropDownStyle = ComboBoxStyle.DropDownList
        ComboBox_MAU.DropDownStyle = ComboBoxStyle.DropDownList

        'AN CAC NUT LENH, COMBOBOX
        Bt_W2E.Enabled = False
        Bt_TODA.Enabled = False
        ComboBox_MAU.Enabled = False
        ComboBox_MADE.Enabled = False

        'THUOC TINH RADIO BUTTON
        RadioButton1.Checked = True
        RadioButton2.Checked = False
        RadioButton3.Checked = False

        'thu tu con tro khi nhan tab

        'kich hoat timer hien thi huong dan nap dap an tu word
        Timer1.Start()
    End Sub

    Private Sub Bt_THOAT_Click(sender As Object, e As EventArgs) Handles Bt_THOAT.Click
        Me.Close()
    End Sub

    Private Sub ComboBox_MAU_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox_MAU.SelectedIndexChanged
        Dim MAU As String
        MAU = ComboBox_MAU.Text
        NAP_MAU(MAU)
        Bt_TODA.Enabled = True
    End Sub

    Private Sub TextBox3_TextChanged(sender As Object, e As EventArgs) Handles TextBox3.TextChanged
        Bt_W2E.Enabled = True
        RadioButton1.Enabled = True
        RadioButton2.Enabled = True
        RadioButton3.Enabled = True
    End Sub

    Private Sub Bt_NAPDA_Click(sender As Object, e As EventArgs) Handles Bt_NAPDA.Click
        Dim loi As Boolean
        Bt_TODA.Enabled = False

        'nap file excel vao chuong trinh, hien thi len datagridview
        '   Dim conn As OleDbConnection
        '  Dim dta As OleDbDataAdapter
        '  Dim dts As DataSet
        '   Dim excel As String
        Dim OpenFileDialog As New OpenFileDialog
        OpenFileDialog1.FileName = ""
        OpenFileDialog1.InitialDirectory = My.Computer.FileSystem.SpecialDirectories.Desktop
        OpenFileDialog1.Filter = "Excel files (*.xls; *.xlsx)|*.xls;*.xlsx"

        If (OpenFileDialog1.ShowDialog(Me) = System.Windows.Forms.DialogResult.OK) Then
            DataGridView1.Columns.Clear()

            Dim fi As New FileInfo(OpenFileDialog1.FileName)
            Dim FileName As String = OpenFileDialog1.FileName

            '      excel = fi.FullName
            '      conn = New OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + excel + ";Extended Properties=Excel 12.0;")
            '     dta = New OleDbDataAdapter("Select * From [Table1$]", conn)
            '    dts = New DataSet
            '    dta.Fill(dts, "[Table1$]")
            '    DataGridView1.DataSource = dts
            '    DataGridView1.DataMember = "[Table1$]"
            '    conn.Close()

            NAP_EXCEL(OpenFileDialog1.FileName, loi)
            If loi = True Then
                MsgBox("Mẫu đáp án nạp vào không phù hợp. Phải dùng mẫu đáp án file excel của McMix.", MsgBoxStyle.Information, "Thông báo")
                DataGridView1.Columns.Clear()
                ComboBox_MAU.Enabled = False
                ComboBox_MADE.Enabled = False
                Exit Sub
            End If
        Else
            Exit Sub
        End If

        'thong bao so cau va mã de
        TONGCAU = Val(DataGridView1.RowCount - 2)
        SOCAU = Val(DataGridView1(2, TONGCAU).Value)
        SOMA = TONGCAU / SOCAU

        Label_thongbao.Text = "(Có tất cả " & SOMA & " mã đề, mỗi mã đề có " & SOCAU & " câu)"

        'tắt timer
        Timer1.Stop()
        Timer2.Stop()
        Timer3.Stop()

        'NAP MAU VA MA DE PHU HOP
        kt_MAU_MD(SOCAU, SOMA)

        'cho phep CHON MAU PHIEU VA MA DE
        RadioButton1.Enabled = False
        RadioButton2.Enabled = False
        RadioButton3.Enabled = False
        ComboBox_MAU.Enabled = True
        ComboBox_MADE.Enabled = True
        ComboBox_MADE.SelectedIndex = 0
        ComboBox_MAU.SelectedIndex = 0

        If MsgBox("Đã nạp xong. Bạn có thể chọn mẫu phiếu và mã đề để tô đáp án hoặc lưu lại thành file excel để dùng nạp cho TNMaker. Bạn có muốn lưu không?", MsgBoxStyle.YesNo, "Thông báo") = MsgBoxResult.Yes Then
            SaveFileDialog1.Filter = "Excel Document (*.xlsx)|*.xlsx"
            If SaveFileDialog1.ShowDialog() = System.Windows.Forms.DialogResult.OK Then
                LUU_EXCEL()
                MsgBox("Đã lưu xong" & vbCrLf & "Tập tin được lưu tại: " & SaveFileDialog1.FileName, MsgBoxStyle.Information, "Thông báo")
            End If
        End If
    End Sub

    Private Sub ComboBox_MADE_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox_MADE.SelectedIndexChanged
        Dim MAU As String = ComboBox_MAU.Text
        NAP_MAU(MAU)
    End Sub

    Private Sub Bt_BROWSE_Click(sender As Object, e As EventArgs) Handles Bt_BROWSE.Click
        If dlgFolderSelect.ShowDialog = Windows.Forms.DialogResult.OK Then
            txtSource.Text = dlgFolderSelect.SelectedPath
        End If
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        PicDraw.BackgroundImage = TickZT.My.Resources.mau_PVT
        Timer1.Stop()
        Timer2.Start()
        Timer3.Stop()
    End Sub

    Private Sub Timer2_Tick(sender As Object, e As EventArgs) Handles Timer2.Tick
        PicDraw.BackgroundImage = TickZT.My.Resources.Mau_SMT
        Timer2.Stop()
        Timer1.Stop()
        Timer3.Start()
    End Sub

    Private Sub Timer3_Tick(sender As Object, e As EventArgs) Handles Timer3.Tick
        PicDraw.BackgroundImage = TickZT.My.Resources.MAU_BTP
        Timer2.Stop()
        Timer1.Start()
        Timer3.Stop()
    End Sub
End Class
