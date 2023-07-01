Module molMain
    '  Sub Add_CIRCLE(ByVal bm As Bitmap, ByVal X1 As Decimal, ByVal Y1 As Decimal, ByVal X2 As Decimal, ByVal Y2 As Decimal, ByVal tPen As Pen)
    'KHAI BAO BIEN LA MOT DOI TUONG GRAPHICS
    'Dim gr As Graphics = Graphics.FromImage(bm)
    'KHAI BAO BIEN BR NHU LA MOT DOI TUONG BRUSH MAU ĐEN
    ' Dim BR As Brush = Brushes.Red
    'VE HINH TRON CO TO NEN ĐEN
    '   gr.FillEllipse(BR, X1, Y1, 50, 50)
    '   End Sub
    Sub W2E_PVT(ByVal DATA As String, ByRef KT As Boolean)                     'mẫu đáp án Phạm Văn Trung
        Dim SOMA, TONGCAU, SOCAU As Integer
        Dim DATA_MADE As String = Nothing

        'LAY CAC THONG TIN: TONG SO CAU, SO CAU MOI MA DE, SO MA DE
        'LOAI BO CAC KI TU KO CAN THIET
        DATA = Replace(DATA, Chr(10), "", , , vbTextCompare)
        DATA = Replace(DATA, Chr(13), "", , , vbTextCompare)
        DATA = Replace(DATA, Chr(11), "", , , vbTextCompare)
        DATA = Replace(DATA, Chr(9), "", , , vbTextCompare)
        DATA = Replace(DATA, " ", "", , , vbTextCompare)
        DATA = Replace(DATA, ";", "", , , vbTextCompare)
        DATA = Replace(DATA, ".", "", , , vbTextCompare)

        For i = 1 To Len(DATA)
            If Mid(DATA, i, 1) = "m" Then
                DATA_MADE = DATA_MADE & Mid(DATA, i + 5, 3)
                SOMA += 1
            End If
        Next
        SOCAU = Val(Mid(DATA, Len(DATA) - 2, 2))

        'loai bo chữ "Đáp án mã đề:"
        DATA = Replace(DATA, "Đápánmãđề:", "", , , vbTextCompare)

        'LOAI BO SO CAU TRONG DAP AN
        For i = 0 To 9
            DATA = Replace(DATA, i.ToString, "", , , vbTextCompare)
        Next

        TONGCAU = Len(DATA)

        'kt dap an hop le
        If SOMA * SOCAU < TONGCAU Then
            KT = False
            Exit Sub
        End If

        'THEM DU LIEU COT VAO DATAGRIDVIEW
        Form1.DataGridView1.Columns.Clear()
        If Form1.DataGridView1.Columns.Count = 0 Then
            With Form1.DataGridView1
                .Columns.Clear()
                .Columns.Add("mamon", "mamon")
                .Columns.Add("made", "made")
                .Columns.Add("cautron", "cautron")
                .Columns.Add("dapan", "dapan")
            End With
        End If
        Form1.DataGridView1.DataSource = Nothing

        'NAP TOAN BỘ DỮ LIỆU VAO DATAGRIDVIEW
        For J = 1 To SOMA
            For I = 1 To SOCAU
                With Form1.DataGridView1.Rows
                    Select Case Mid(DATA, I + SOCAU * (J - 1), 1)
                        Case "A", "B", "C", "D", "E", "a", "b", "c", "d", "e"
                            .Add("TQM", Mid(DATA_MADE, J * 3 - 2, 3), I, Mid(DATA, I + SOCAU * (J - 1), 1))
                        Case Else
                            KT = False
                            Exit Sub
                    End Select
                End With
            Next
        Next

        'THONG BÁO SO CAU VA SO MA DE
        Form1.Label_thongbao.Text = "(Có tất cả " & SOMA & " mã đề, mỗi mã đề có " & SOCAU & " câu)"

        'tắt timer
        Form1.Timer1.Stop()
        Form1.Timer2.Stop()
        'NAP MAU VA MA DE PHU HOP
        kt_MAU_MD(SOCAU, SOMA)
    End Sub
    Sub W2E_SMT(ByVal DATA As String, ByRef KT As Boolean)           'mẫu đáp án Smart test
        Dim SOMA, TONGCAU, SOCAU As Integer
        Dim DATA_MADE As String

        'LAY CAC THONG TIN TONG SO CAU, SO CAU MOI MA DE, SO MA DE

        DATA = Replace(DATA, Chr(9), "", , , vbTextCompare) 'LOAI BO DAU CACH
        For i = 1 To 25
            If Mid(DATA, i, 1) = Chr(13) Then
                SOMA = (i - 1) / 3 'CHIA 3 VI MOI MA DE CO 3 KI TU
                Exit For
            End If
        Next

        DATA_MADE = Left(DATA, SOMA * 3) 'LAY DU LIEU PHAN MA DE

        DATA = Replace(DATA, Chr(13), "", , , vbTextCompare)
        DATA = Replace(DATA, Chr(10), "", , , vbTextCompare)
        DATA = Replace(DATA, Chr(11), "", , , vbTextCompare)
        DATA = Replace(DATA, " ", "", , , vbTextCompare)
        DATA = Replace(DATA, DATA_MADE, "", , , vbTextCompare) 'CAT BO PHAN MA DE

        TONGCAU = Val(Len(DATA))
        SOCAU = TONGCAU / SOMA

        'THEM DU LIEU COT VAO DATAGRIDVIEW
        Form1.DataGridView1.Columns.Clear()
        If Form1.DataGridView1.Columns.Count = 0 Then
            With Form1.DataGridView1
                .Columns.Clear()
                .Columns.Add("mamon", "mamon")
                .Columns.Add("made", "made")
                .Columns.Add("cautron", "cautron")
                .Columns.Add("dapan", "dapan")
            End With
        End If
        Form1.DataGridView1.DataSource = Nothing

        'NAP TOAN BỘ DỮ LIỆU VAO DATAGRIDVIEW và kiem tra
        For J = 1 To SOMA
            For I = 1 To SOCAU
                With Form1.DataGridView1.Rows
                    Select Case Mid(DATA, J + SOMA * (I - 1), 1)
                        Case "A", "B", "C", "D", "E", "a", "b", "c", "d", "e"
                            .Add("TQM", Mid(DATA_MADE, J * 3 - 2, 3), I, Mid(DATA, J + SOMA * (I - 1), 1))
                        Case Else
                            KT = False
                            Exit Sub
                    End Select
                End With
            Next
        Next

        'THONG BÁO SO CAU VA SO MA DE
        Form1.Label_thongbao.Text = "(Có tất cả " & SOMA & " mã đề, mỗi mã đề có " & SOCAU & " câu)"

        'tắt timer
        Form1.Timer1.Stop()
        Form1.Timer2.Stop()

        'NAP MAU VA MA DE PHU HOP
        kt_MAU_MD(SOCAU, SOMA)
    End Sub

    Sub W2E_BTP(ByVal DATA As String, ByRef KT As Boolean)           'mẫu đáp án BT PRO
        Dim SOMA, TONGCAU, SOCAU As Integer
        Dim DATA_MADE As String = ""
        SOMA = 0
        'LAY CAC THONG TIN TONG SO CAU, SO CAU MOI MA DE, SO MA DE

        DATA = Replace(DATA, Chr(9), "", , , vbTextCompare) 'LOAI BO DAU CACH
        DATA = Replace(DATA, Chr(13), "", , , vbTextCompare)
        DATA = Replace(DATA, Chr(10), "", , , vbTextCompare)
        DATA = Replace(DATA, Chr(11), "", , , vbTextCompare)
        DATA = Replace(DATA, " ", "", , , vbTextCompare)
        DATA = Replace(DATA, "[", "", , , vbTextCompare)
        DATA = Replace(DATA, "]", "", , , vbTextCompare)

        If Mid(DATA, 1, 4).ToLower = "mãđề" Then
            For i = 1 To Len(DATA)
                If Mid(DATA, i, 1).ToLower = "m" Then
                    DATA_MADE = DATA_MADE & Mid(DATA, i + 4, 3)
                    SOMA += 1
                End If
            Next
            'loai bo chữ "Mã đề:"
            DATA = Replace(DATA, Mid(DATA, 1, 4), "", , , vbTextCompare)
        ElseIf Mid(DATA, 1, 6).ToLower = "mãđề" Then
            For i = 1 To Len(DATA)
                If Mid(DATA, i, 1).ToLower = "m" Then
                    DATA_MADE = DATA_MADE & Mid(DATA, i + 6, 3)
                    SOMA += 1
                End If
            Next
            'loai bo chữ "Mã đề:"
            DATA = Replace(DATA, Mid(DATA, 1, 6), "", , , vbTextCompare)
        End If


        'LOAI BO SO CAU TRONG DAP AN
        For i = 0 To 9
            DATA = Replace(DATA, i.ToString, "", , , vbTextCompare)
        Next

        TONGCAU = Val(Len(DATA))
        SOCAU = TONGCAU / SOMA

        'THEM DU LIEU COT VAO DATAGRIDVIEW
        Form1.DataGridView1.Columns.Clear()
        If Form1.DataGridView1.Columns.Count = 0 Then
            With Form1.DataGridView1
                .Columns.Clear()
                .Columns.Add("mamon", "mamon")
                .Columns.Add("made", "made")
                .Columns.Add("cautron", "cautron")
                .Columns.Add("dapan", "dapan")
            End With
        End If
        Form1.DataGridView1.DataSource = Nothing

        'NAP TOAN BỘ DỮ LIỆU VAO DATAGRIDVIEW và kiem tra
        For J = 1 To SOMA
            For I = 1 To SOCAU
                With Form1.DataGridView1.Rows
                    Select Case Mid(DATA, I + ((J - 1) * SOCAU), 1)
                        Case "A", "B", "C", "D", "E", "a", "b", "c", "d", "e"
                            .Add("TQM", Mid(DATA_MADE, J * 3 - 2, 3), I, Mid(DATA, I + ((J - 1) * SOCAU), 1))
                        Case Else
                            KT = False
                            Exit Sub
                    End Select
                End With
            Next
        Next

        'THONG BÁO SO CAU VA SO MA DE
        Form1.Label_thongbao.Text = "(Có tất cả " & SOMA & " mã đề, mỗi mã đề có " & SOCAU & " câu)"

        'tắt timer
        Form1.Timer1.Stop()
        Form1.Timer2.Stop()

        'NAP MAU VA MA DE PHU HOP
        kt_MAU_MD(SOCAU, SOMA)
    End Sub

    Sub IMG_PDF(ByVal MAU As String, ByVal MADE As String, ByVal TIME As String, ByRef pdf As PdfSharp.Pdf.PdfDocument)   'chuyển hình ảnh png sang pdf
        Dim page As PdfSharp.Pdf.PdfPage
        Dim GR As PdfSharp.Drawing.XGraphics
        Dim font As PdfSharp.Drawing.XFont = New PdfSharp.Drawing.XFont("Verdana", 20, PdfSharp.Drawing.XFontStyle.Bold)

        page = pdf.AddPage()
        'Create XImage object from file.
        Using xImg = PdfSharp.Drawing.XImage.FromFile(Form1.txtSource.Text & "\" & TIME & "_" & MAU & "_" & MADE & ".png")
            'Draw current image file to page.
            GR = PdfSharp.Drawing.XGraphics.FromPdfPage(page)
            'TÉT
            If xImg.PixelHeight < xImg.PixelWidth Then
                page.Height = (841 / xImg.PixelWidth) * xImg.PixelHeight
                page.Width = 841
            End If
            '
            GR.DrawImage(xImg, 0, 0, page.Width, page.Height)
            If MAU <> "TN120" Then GR.DrawString(MADE, font, PdfSharp.Drawing.XBrushes.Black, New PdfSharp.Drawing.XRect(0, 0, page.Width.Point, page.Height.Point), PdfSharp.Drawing.XStringFormats.TopCenter)
        End Using
    End Sub
    Sub LUU_EXCEL()
        '   Dim oExcel As Object
        '  Dim oBook As Object
        '  Dim oSheet, oSheet2 As Object

        Dim oExcel As New Microsoft.Office.Interop.Excel.Application
        Dim misValue As Object = System.Reflection.Missing.Value
        Dim oBook As Microsoft.Office.Interop.Excel.Workbook = oExcel.Workbooks.Add(misValue)
        Dim oSheet As Microsoft.Office.Interop.Excel.Worksheet = CType(oBook.Sheets(1), Microsoft.Office.Interop.Excel.Worksheet)
        Dim oSheet2 As Microsoft.Office.Interop.Excel.Worksheet = CType(oBook.Sheets.Add(), Microsoft.Office.Interop.Excel.Worksheet)


        'khởi tạo workbook in excel

        '     oExcel = CreateObject("Excel.Application")
        '    oBook = oExcel.Workbooks.Add(misValue)
        'Thêm dữ liệu tên cột vào các cột ở hàng đầu tiên trong workbook

        ' oSheet = oBook.Worksheets(1)
        oSheet.Name = "Table1"
        oSheet2.Name = "Sheet1"

        For i = 0 To Form1.DataGridView1.RowCount - 2
            For j = 0 To Form1.DataGridView1.ColumnCount - 1
                For k As Integer = 1 To Form1.DataGridView1.Columns.Count
                    oSheet.Cells(1, k) = Form1.DataGridView1.Columns(k - 1).HeaderText
                    oSheet.Cells(i + 2, j + 1) = Form1.DataGridView1(j, i).Value.ToString()
                Next
            Next
            Form1.ProgressBar1.Value = (i / (Form1.DataGridView1.RowCount - 2)) * 100
        Next

        oBook.SaveAs(Form1.SaveFileDialog1.FileName)
        oBook.Close()
        oExcel.Quit()
    End Sub
    Sub NAP_EXCEL(ByVal duongdan As String, ByRef loi As Boolean)
        On Error GoTo err
        Dim oExcel As New Microsoft.Office.Interop.Excel.Application
        Dim oBook As Microsoft.Office.Interop.Excel.Workbook = oExcel.Workbooks.Open(duongdan)
        Dim oSheet As Microsoft.Office.Interop.Excel.Worksheet = CType(oBook.Sheets(1), Microsoft.Office.Interop.Excel.Worksheet)
        Dim xlrange As Microsoft.Office.Interop.Excel.Range = oSheet.UsedRange
        Dim rowcount As Integer = xlrange.Rows.Count
        Dim colcount As Integer = xlrange.Columns.Count

        loi = False

        'THEM DU LIEU COT VAO DATAGRIDVIEW
        Form1.DataGridView1.Columns.Clear()
        If Form1.DataGridView1.Columns.Count = 0 Then
            With Form1.DataGridView1
                .Columns.Clear()
                .Columns.Add("mamon", "mamon")
                .Columns.Add("made", "made")
                .Columns.Add("cautron", "cautron")
                .Columns.Add("dapan", "dapan")
            End With
        End If
        Form1.DataGridView1.DataSource = Nothing

        'kt mau mcmix hay tnmaker hay mau sai
        If rowcount > 1 Then
            For i = 2 To rowcount
                Select Case oSheet.Cells(i, 4).Value.ToString
                    Case "A", "B", "C", "D", "E", "a", "b", "c", "d", "e"
                        Exit Select
                    Case Else
                        loi = True
                        oBook.Close()
                        oExcel.Quit()
                        Exit Sub
                End Select
                Form1.DataGridView1.Rows.Add(oSheet.Cells(i, 1).value.ToString, oSheet.Cells(i, 2).value.ToString, oSheet.Cells(i, 3).value.ToString, oSheet.Cells(i, 4).value.ToString)
                Form1.ProgressBar1.Value = i / rowcount * 100
            Next
        Else
            Dim oSheet2 As Microsoft.Office.Interop.Excel.Worksheet = CType(oBook.Sheets(2), Microsoft.Office.Interop.Excel.Worksheet)
            xlrange = oSheet2.UsedRange
            rowcount = xlrange.Rows.Count
            colcount = xlrange.Columns.Count
            For i = 2 To rowcount
                Select Case oSheet2.Cells(i, 4).Value.ToString
                    Case "A", "B", "C", "D", "E", "a", "b", "c", "d", "e"
                        Exit Select
                    Case Else
                        loi = True
                        oBook.Close()
                        oExcel.Quit()
                        Exit Sub
                End Select
                Form1.DataGridView1.Rows.Add(oSheet2.Cells(i, 1).value.ToString, oSheet2.Cells(i, 2).value.ToString, oSheet2.Cells(i, 3).value.ToString, oSheet2.Cells(i, 4).value.ToString)
                Form1.ProgressBar1.Value = i / rowcount * 100
            Next
        End If
        oBook.Close()
        oExcel.Quit()
        Exit Sub
err:    loi = True
        oBook.Close()
        oExcel.Quit()
    End Sub
    Sub NAP_MAU(ByVal MAU As String)

        Select Case MAU
            Case "Z100"
                Form1.PicDraw.Image = Nothing
                Form1.PicDraw.BackgroundImage = TickZT.My.Resources.Z100
            Case "Z50"
                Form1.PicDraw.Image = Nothing
                Form1.PicDraw.BackgroundImage = TickZT.My.Resources.Z50
            Case "Z20"
                Form1.PicDraw.Image = Nothing
                Form1.PicDraw.BackgroundImage = TickZT.My.Resources.Z20
            Case "TN120"
                Form1.PicDraw.Image = Nothing
                Form1.PicDraw.BackgroundImage = TickZT.My.Resources.TN120
            Case "TN100"
                Form1.PicDraw.Image = Nothing
                Form1.PicDraw.BackgroundImage = TickZT.My.Resources.TN100
            Case "TN60"
                Form1.PicDraw.Image = Nothing
                Form1.PicDraw.BackgroundImage = TickZT.My.Resources.TN60
            Case "TN40"
                Form1.PicDraw.Image = Nothing
                Form1.PicDraw.BackgroundImage = TickZT.My.Resources.TN40
            Case "TN20"
                Form1.PicDraw.Image = Nothing
                Form1.PicDraw.BackgroundImage = TickZT.My.Resources.TN20
            Case "TN_NGANG_40"
                Form1.PicDraw.Image = Nothing
                Form1.PicDraw.BackgroundImage = TickZT.My.Resources.TNN40
        End Select
    End Sub
    Sub kt_MAU_MD(ByVal SOCAU As Integer, ByVal SOMA As Integer)
        Form1.ComboBox_MAU.Items.Clear()
        Form1.ComboBox_MADE.Items.Clear()
        If SOCAU > 100 Then
            Form1.ComboBox_MAU.Items.Add("TN120")
        ElseIf SOCAU > 60 Then
            Form1.ComboBox_MAU.Items.Add("Z100")
            Form1.ComboBox_MAU.Items.Add("TN100")
            Form1.ComboBox_MAU.Items.Add("TN120")
        ElseIf SOCAU > 50 Then
            Form1.ComboBox_MAU.Items.Add("Z100")
            Form1.ComboBox_MAU.Items.Add("TN60")
            Form1.ComboBox_MAU.Items.Add("TN100")
            Form1.ComboBox_MAU.Items.Add("TN120")
        ElseIf SOCAU > 40 Then
            Form1.ComboBox_MAU.Items.Add("Z50")
            Form1.ComboBox_MAU.Items.Add("Z100")
            Form1.ComboBox_MAU.Items.Add("TN60")
            Form1.ComboBox_MAU.Items.Add("TN100")
            Form1.ComboBox_MAU.Items.Add("TN120")
        ElseIf SOCAU > 20 Then
            Form1.ComboBox_MAU.Items.Add("Z50")
            Form1.ComboBox_MAU.Items.Add("Z100")
            Form1.ComboBox_MAU.Items.Add("TN40")
            Form1.ComboBox_MAU.Items.Add("TN60")
            Form1.ComboBox_MAU.Items.Add("TN100")
            Form1.ComboBox_MAU.Items.Add("TN120")
            Form1.ComboBox_MAU.Items.Add("TN_NGANG_40")
        Else
            Form1.ComboBox_MAU.Items.Add("Z20")
            Form1.ComboBox_MAU.Items.Add("Z50")
            Form1.ComboBox_MAU.Items.Add("Z100")
            Form1.ComboBox_MAU.Items.Add("TN20")
            Form1.ComboBox_MAU.Items.Add("TN40")
            Form1.ComboBox_MAU.Items.Add("TN60")
            Form1.ComboBox_MAU.Items.Add("TN100")
            Form1.ComboBox_MAU.Items.Add("TN120")
            Form1.ComboBox_MAU.Items.Add("TN_NGANG_40")
        End If
        Form1.ComboBox_MADE.Items.Add("Tô hết các mã đề")
        For I = 1 To SOMA
            ' Form1.ComboBox_MADE.Items.Add("Mã đề 0" & Right(Str(100 + I), 2))
            Form1.ComboBox_MADE.Items.Add("Mã đề " & Form1.DataGridView1(1, I * SOCAU - 1).Value.ToString)
        Next

    End Sub
    Sub TODA_LUACHON(ByVal bm As Bitmap, ByVal MAU As String, ByVal MADE As String, ByVal SOCAU As Integer)
        'KHAI BAO BIEN LA MOT DOI TUONG GRAPHICS
        Dim gr As Graphics = Graphics.FromImage(bm)
        'KHAI BAO BIEN BR NHU LA MOT DOI TUONG BRUSH MAU ĐEN
        Dim BR As Brush = Brushes.Black
        Dim CAUBD, CAUKT As Integer
        Dim DATA, DATA_MADE As String
        Dim I, J As Integer
        Dim X, Y As Decimal
        J = 0

        'KIEM TRA CHON MA DE ĐỂ TÔ
        Select Case MADE
            Case 1
                CAUBD = 1
                CAUKT = SOCAU
            Case 2
                CAUBD = SOCAU + 1
                CAUKT = SOCAU * 2
            Case 3
                CAUBD = SOCAU * 2 + 1
                CAUKT = SOCAU * 3
            Case 4
                CAUBD = SOCAU * 3 + 1
                CAUKT = SOCAU * 4
            Case 5
                CAUBD = SOCAU * 4 + 1
                CAUKT = SOCAU * 5
            Case 6
                CAUBD = SOCAU * 5 + 1
                CAUKT = SOCAU * 6
            Case 7
                CAUBD = SOCAU * 6 + 1
                CAUKT = SOCAU * 7
            Case 8
                CAUBD = SOCAU * 7 + 1
                CAUKT = SOCAU * 8
            Case 9
                CAUBD = SOCAU * 8 + 1
                CAUKT = SOCAU * 9
            Case 10
                CAUBD = SOCAU * 9 + 1
                CAUKT = SOCAU * 10

            Case 11
                CAUBD = SOCAU * 10 + 1
                CAUKT = SOCAU * 11
            Case 12
                CAUBD = SOCAU * 11 + 1
                CAUKT = SOCAU * 12
            Case 13
                CAUBD = SOCAU * 12 + 1
                CAUKT = SOCAU * 13
            Case 14
                CAUBD = SOCAU * 13 + 1
                CAUKT = SOCAU * 14
            Case 15
                CAUBD = SOCAU * 14 + 1
                CAUKT = SOCAU * 15
            Case 16
                CAUBD = SOCAU * 15 + 1
                CAUKT = SOCAU * 16
            Case 17
                CAUBD = SOCAU * 16 + 1
                CAUKT = SOCAU * 17
            Case 18
                CAUBD = SOCAU * 17 + 1
                CAUKT = SOCAU * 18
            Case 19
                CAUBD = SOCAU * 18 + 1
                CAUKT = SOCAU * 19
            Case 20
                CAUBD = SOCAU * 19 + 1
                CAUKT = SOCAU * 20

            Case 21
                CAUBD = SOCAU * 20 + 1
                CAUKT = SOCAU * 21
            Case 22
                CAUBD = SOCAU * 21 + 1
                CAUKT = SOCAU * 22
            Case 23
                CAUBD = SOCAU * 22 + 1
                CAUKT = SOCAU * 23
            Case 24
                CAUBD = SOCAU * 23 + 1
                CAUKT = SOCAU * 24
            Case Else
                MsgBox("Chỉ hỗ trợ tối đa 24 mã đề.", MsgBoxStyle.Information, "Thông báo")
        End Select

        'KIEM TRA CHỌN MẪU PHIẾU ĐỂ TÔ, NẾU TÔ HẾT PHẢI THỰC HIỆN VÒNG LẶP
        Select Case MAU
            Case "Z50"
                For I = CAUBD To CAUKT
                    DATA = Form1.DataGridView1(3, I - 1).Value.ToString
                    J = J + 1
                    Select Case J
                        Case 1 To 10
                            Y = 1393 + 80 * (J - 1)
                            Select Case DATA
                                Case "A"
                                    X = 420
                                Case "B"
                                    X = 420 + 69
                                Case "C"
                                    X = 420 + 69 * 2
                                Case "D"
                                    X = 420 + 69 * 3
                                Case "E"
                                    X = 420 + 69 * 4
                            End Select
                        Case 11 To 20
                            Y = 513 + 80 * (J - 11)
                            Select Case DATA
                                Case "A"
                                    X = 858
                                Case "B"
                                    X = 858 + 69
                                Case "C"
                                    X = 858 + 69 * 2
                                Case "D"
                                    X = 858 + 69 * 3
                                Case "E"
                                    X = 858 + 69 * 4
                            End Select
                        Case 21 To 30
                            Y = 1393 + 80 * (J - 21)
                            Select Case DATA
                                Case "A"
                                    X = 858
                                Case "B"
                                    X = 858 + 69
                                Case "C"
                                    X = 858 + 69 * 2
                                Case "D"
                                    X = 858 + 69 * 3
                                Case "E"
                                    X = 858 + 69 * 4
                            End Select
                        Case 31 To 40
                            Y = 513 + 80 * (J - 31)
                            Select Case DATA
                                Case "A"
                                    X = 1290
                                Case "B"
                                    X = 1290 + 69
                                Case "C"
                                    X = 1290 + 69 * 2
                                Case "D"
                                    X = 1290 + 69 * 3
                                Case "E"
                                    X = 1290 + 69 * 4
                            End Select
                        Case 41 To 50
                            Y = 1393 + 80 * (J - 41)
                            Select Case DATA
                                Case "A"
                                    X = 1290
                                Case "B"
                                    X = 1290 + 69
                                Case "C"
                                    X = 1290 + 69 * 2
                                Case "D"
                                    X = 1290 + 69 * 3
                                Case "E"
                                    X = 1290 + 69 * 4
                            End Select
                    End Select


                    'VE HINH TRON CO TO NEN ĐEN
                    gr.FillEllipse(BR, X, Y, 50, 50)
                Next

            Case "Z20"
                For I = CAUBD To CAUKT
                    DATA = Form1.DataGridView1(3, I - 1).Value.ToString
                    J = J + 1
                    Select Case J
                        Case 1 To 10
                            Y = 532 + 91 * (J - 1)
                            Select Case DATA
                                Case "A"
                                    X = 336
                                Case "B"
                                    X = 336 + 69
                                Case "C"
                                    X = 336 + 69 * 2
                                Case "D"
                                    X = 336 + 69 * 3
                                Case "E"
                                    X = 336 + 69 * 4
                            End Select
                        Case 11 To 20
                            Y = 532 + 91 * (J - 11)
                            Select Case DATA
                                Case "A"
                                    X = 826
                                Case "B"
                                    X = 826 + 69
                                Case "C"
                                    X = 826 + 69 * 2
                                Case "D"
                                    X = 826 + 69 * 3
                                Case "E"
                                    X = 826 + 69 * 4
                            End Select
                    End Select
                    'VE HINH TRON CO TO NEN ĐEN
                    gr.FillEllipse(BR, X, Y, 50, 50)
                Next

            Case "Z100"
                For I = CAUBD To CAUKT
                    DATA = Form1.DataGridView1(3, I - 1).Value.ToString
                    J = J + 1
                    Select Case J
                        Case 1 To 10
                            Y = 1244 + 78 * (J - 1)   'HANG 2
                            Select Case DATA
                                Case "A"
                                    X = 501  'COT 1
                                Case "B"
                                    X = 501 + 68
                                Case "C"
                                    X = 501 + 68 * 2
                                Case "D"
                                    X = 501 + 68 * 3
                                Case "E"
                                    X = 501 + 68 * 4
                            End Select
                        Case 11 To 20
                            Y = 2072 + 78 * (J - 11)   'HANG 3
                            Select Case DATA
                                Case "A"
                                    X = 501
                                Case "B"
                                    X = 501 + 68
                                Case "C"
                                    X = 501 + 68 * 2
                                Case "D"
                                    X = 501 + 68 * 3
                                Case "E"
                                    X = 501 + 68 * 4
                            End Select
                        Case 21 To 30
                            Y = 1244 + 78 * (J - 21)    'HANG 2
                            Select Case DATA
                                Case "A"
                                    X = 930  'COT THU 2
                                Case "B"
                                    X = 930 + 68
                                Case "C"
                                    X = 930 + 68 * 2
                                Case "D"
                                    X = 930 + 68 * 3
                                Case "E"
                                    X = 930 + 68 * 4
                            End Select
                        Case 31 To 40
                            Y = 2072 + 78 * (J - 31)   'HANG 3
                            Select Case DATA
                                Case "A"
                                    X = 930
                                Case "B"
                                    X = 930 + 68
                                Case "C"
                                    X = 930 + 68 * 2
                                Case "D"
                                    X = 930 + 68 * 3
                                Case "E"
                                    X = 930 + 68 * 4
                            End Select
                        Case 41 To 50
                            Y = 416 + 78 * (J - 41)     'HÀNG 1
                            Select Case DATA
                                Case "A"
                                    X = 1359   'COT THU 3
                                Case "B"
                                    X = 1359 + 68
                                Case "C"
                                    X = 1359 + 68 * 2
                                Case "D"
                                    X = 1359 + 68 * 3
                                Case "E"
                                    X = 1359 + 68 * 4
                            End Select
                        Case 51 To 60
                            Y = 1244 + 78 * (J - 51)  'HANG 2
                            Select Case DATA
                                Case "A"
                                    X = 1359
                                Case "B"
                                    X = 1359 + 68
                                Case "C"
                                    X = 1359 + 68 * 2
                                Case "D"
                                    X = 1359 + 68 * 3
                                Case "E"
                                    X = 1359 + 68 * 4
                            End Select
                        Case 61 To 70
                            Y = 2072 + 78 * (J - 61)  'HANG 3
                            Select Case DATA
                                Case "A"
                                    X = 1359
                                Case "B"
                                    X = 1359 + 68
                                Case "C"
                                    X = 1359 + 68 * 2
                                Case "D"
                                    X = 1359 + 68 * 3
                                Case "E"
                                    X = 1359 + 68 * 4
                            End Select
                        Case 71 To 80
                            Y = 416 + 78 * (J - 71)  'HANG 1
                            Select Case DATA
                                Case "A"
                                    X = 1786  'CỘT THU 4
                                Case "B"
                                    X = 1786 + 68
                                Case "C"
                                    X = 1786 + 68 * 2
                                Case "D"
                                    X = 1786 + 68 * 3
                                Case "E"
                                    X = 1786 + 68 * 4
                            End Select
                        Case 81 To 90
                            Y = 1244 + 78 * (J - 81)  'HANG 2
                            Select Case DATA
                                Case "A"
                                    X = 1786
                                Case "B"
                                    X = 1786 + 68
                                Case "C"
                                    X = 1786 + 68 * 2
                                Case "D"
                                    X = 1786 + 68 * 3
                                Case "E"
                                    X = 1786 + 68 * 4
                            End Select
                        Case 91 To 100
                            Y = 2072 + 78 * (J - 91)  'HANG 3
                            Select Case DATA
                                Case "A"
                                    X = 1786
                                Case "B"
                                    X = 1786 + 68
                                Case "C"
                                    X = 1786 + 68 * 2
                                Case "D"
                                    X = 1786 + 68 * 3
                                Case "E"
                                    X = 1786 + 68 * 4
                            End Select
                    End Select


                    'VE HINH TRON CO TO NEN ĐEN
                    gr.FillEllipse(BR, X, Y, 50, 50)
                Next
            Case "TN20"
                For I = CAUBD To CAUKT
                    DATA = Form1.DataGridView1(3, I - 1).Value.ToString
                    J = J + 1
                    Select Case J
                        Case 1 To 10
                            Y = 1437 + 57.5 * (J - 1)
                            Select Case DATA
                                Case "A"
                                    X = 574
                                Case "B"
                                    X = 574 + 49.5
                                Case "C"
                                    X = 574 + 49.5 * 2
                                Case "D"
                                    X = 574 + 49.5 * 3
                            End Select
                        Case 11 To 20
                            Y = 1437 + 57.5 * (J - 11)
                            Select Case DATA
                                Case "A"
                                    X = 879
                                Case "B"
                                    X = 879 + 49.5
                                Case "C"
                                    X = 879 + 49.5 * 2
                                Case "D"
                                    X = 879 + 49.5 * 3
                            End Select
                    End Select
                    'VE HINH TRON CO TO NEN ĐEN
                    gr.FillEllipse(BR, X, Y, 37, 37)

                Next
                'TO MA DE
                DATA = Form1.DataGridView1(1, CAUBD - 1).Value.ToString
                DATA_MADE = Nothing
                For k = 1 To 3
                    Select Case k
                        Case 1
                            DATA_MADE = Left(DATA, 1)
                            X = 879
                        Case 2
                            DATA_MADE = Mid(DATA, 2, 1)
                            X = 879 + 49.5
                        Case 3
                            DATA_MADE = Right(DATA, 1)
                            X = 879 + 49.5 * 2
                    End Select

                    Select Case DATA_MADE

                        Case "0"
                            Y = 802
                        Case "1"
                            Y = 802 + 57.5
                        Case "2"
                            Y = 802 + 57.5 * 2
                        Case "3"
                            Y = 802 + 57.5 * 3
                        Case "4"
                            Y = 802 + 57.5 * 4
                        Case "5"
                            Y = 802 + 57.5 * 5
                        Case "6"
                            Y = 802 + 57.5 * 6
                        Case "7"
                            Y = 802 + 57.5 * 7
                        Case "8"
                            Y = 802 + 57.5 * 8
                        Case "9"
                            Y = 802 + 57.5 * 9
                    End Select
                    'VE HINH TRON CO TO NEN ĐEN
                    gr.FillEllipse(BR, X, Y, 37, 37)
                Next

            Case "TN40"
                For I = CAUBD To CAUKT
                    DATA = Form1.DataGridView1(3, I - 1).Value.ToString
                    J = J + 1
                    Select Case J
                        Case 1 To 10
                            Y = 802 + 57.5 * (J - 1)
                            Select Case DATA
                                Case "A"
                                    X = 1032
                                Case "B"
                                    X = 1032 + 49.5
                                Case "C"
                                    X = 1032 + 49.5 * 2
                                Case "D"
                                    X = 1032 + 49.5 * 3
                            End Select
                        Case 11 To 20
                            Y = 1435 + 57.5 * (J - 11)
                            Select Case DATA
                                Case "A"
                                    X = 426
                                Case "B"
                                    X = 426 + 49.5
                                Case "C"
                                    X = 426 + 49.5 * 2
                                Case "D"
                                    X = 426 + 49.5 * 3
                            End Select
                        Case 21 To 30
                            Y = 1435 + 57.5 * (J - 21)
                            Select Case DATA
                                Case "A"
                                    X = 729
                                Case "B"
                                    X = 729 + 49.5
                                Case "C"
                                    X = 729 + 49.5 * 2
                                Case "D"
                                    X = 729 + 49.5 * 3
                            End Select
                        Case 31 To 40
                            Y = 1435 + 57.5 * (J - 31)
                            Select Case DATA
                                Case "A"
                                    X = 1032
                                Case "B"
                                    X = 1032 + 49.5
                                Case "C"
                                    X = 1032 + 49.5 * 2
                                Case "D"
                                    X = 1032 + 49.5 * 3
                            End Select
                    End Select

                    'VE HINH TRON CO TO NEN ĐEN
                    gr.FillEllipse(BR, X, Y, 37, 37)
                Next
                'TO MA DE
                DATA = Form1.DataGridView1(1, CAUBD - 1).Value.ToString
                DATA_MADE = Nothing
                For k = 1 To 3
                    Select Case k
                        Case 1
                            DATA_MADE = Left(DATA, 1)
                            X = 729
                        Case 2
                            DATA_MADE = Mid(DATA, 2, 1)
                            X = 729 + 49.5
                        Case 3
                            DATA_MADE = Right(DATA, 1)
                            X = 729 + 49.5 * 2
                    End Select

                    Select Case DATA_MADE

                        Case "0"
                            Y = 802
                        Case "1"
                            Y = 802 + 57.5
                        Case "2"
                            Y = 802 + 57.5 * 2
                        Case "3"
                            Y = 802 + 57.5 * 3
                        Case "4"
                            Y = 802 + 57.5 * 4
                        Case "5"
                            Y = 802 + 57.5 * 5
                        Case "6"
                            Y = 802 + 57.5 * 6
                        Case "7"
                            Y = 802 + 57.5 * 7
                        Case "8"
                            Y = 802 + 57.5 * 8
                        Case "9"
                            Y = 802 + 57.5 * 9
                    End Select
                    'VE HINH TRON CO TO NEN ĐEN
                    gr.FillEllipse(BR, X, Y, 37, 37)
                Next

            Case "TN60"
                For I = CAUBD To CAUKT
                    DATA = Form1.DataGridView1(3, I - 1).Value.ToString
                    J = J + 1
                    Select Case J
                        Case 1 To 10
                            Y = 936 + 51.5 * (J - 1)
                            Select Case DATA
                                Case "A"
                                    X = 876
                                Case "B"
                                    X = 876 + 44
                                Case "C"
                                    X = 876 + 44 * 2
                                Case "D"
                                    X = 876 + 44 * 3
                            End Select
                        Case 11 To 20
                            Y = 936 + 51.5 * (J - 11)
                            Select Case DATA
                                Case "A"
                                    X = 1146
                                Case "B"
                                    X = 1146 + 44
                                Case "C"
                                    X = 1146 + 44 * 2
                                Case "D"
                                    X = 1146 + 44 * 3
                            End Select
                        Case 21 To 30
                            Y = 1502 + 51.5 * (J - 21)
                            Select Case DATA
                                Case "A"
                                    X = 338
                                Case "B"
                                    X = 338 + 44
                                Case "C"
                                    X = 338 + 44 * 2
                                Case "D"
                                    X = 338 + 44 * 3
                            End Select
                        Case 31 To 40
                            Y = 1502 + 51.5 * (J - 31)
                            Select Case DATA
                                Case "A"
                                    X = 606
                                Case "B"
                                    X = 606 + 44
                                Case "C"
                                    X = 606 + 44 * 2
                                Case "D"
                                    X = 606 + 44 * 3
                            End Select
                        Case 41 To 50
                            Y = 1502 + 51.5 * (J - 41)
                            Select Case DATA
                                Case "A"
                                    X = 876
                                Case "B"
                                    X = 876 + 44
                                Case "C"
                                    X = 876 + 44 * 2
                                Case "D"
                                    X = 876 + 44 * 3
                            End Select
                        Case 51 To 60
                            Y = 1502 + 51.5 * (J - 51)
                            Select Case DATA
                                Case "A"
                                    X = 1146
                                Case "B"
                                    X = 1146 + 44
                                Case "C"
                                    X = 1146 + 44 * 2
                                Case "D"
                                    X = 1146 + 44 * 3
                            End Select
                    End Select

                    'VE HINH TRON CO TO NEN ĐEN
                    gr.FillEllipse(BR, X, Y, 33, 33)
                Next
                'TO MA DE
                DATA = Form1.DataGridView1(1, CAUBD - 1).Value.ToString
                DATA_MADE = Nothing
                For k = 1 To 3
                    Select Case k
                        Case 1
                            DATA_MADE = Left(DATA, 1)
                            X = 604
                        Case 2
                            DATA_MADE = Mid(DATA, 2, 1)
                            X = 604 + 44
                        Case 3
                            DATA_MADE = Right(DATA, 1)
                            X = 604 + 44 * 2
                    End Select

                    Select Case DATA_MADE

                        Case "0"
                            Y = 936
                        Case "1"
                            Y = 936 + 51.5
                        Case "2"
                            Y = 936 + 51.5 * 2
                        Case "3"
                            Y = 936 + 51.5 * 3
                        Case "4"
                            Y = 936 + 51.5 * 4
                        Case "5"
                            Y = 936 + 51.5 * 5
                        Case "6"
                            Y = 936 + 51.5 * 6
                        Case "7"
                            Y = 936 + 51.5 * 7
                        Case "8"
                            Y = 936 + 51.5 * 8
                        Case "9"
                            Y = 936 + 51.5 * 9
                    End Select
                    'VE HINH TRON CO TO NEN ĐEN
                    gr.FillEllipse(BR, X, Y, 33, 33)
                Next

            Case "TN100"
                For I = CAUBD To CAUKT
                    DATA = Form1.DataGridView1(3, I - 1).Value.ToString
                    J = J + 1
                    Select Case J
                        Case 1 To 10
                            Y = 582 + 45 * (J - 1)   'hang 1
                            Select Case DATA         'cot 3
                                Case "A"
                                    X = 866
                                Case "B"
                                    X = 866 + 38.5
                                Case "C"
                                    X = 866 + 38.5 * 2
                                Case "D"
                                    X = 866 + 38.5 * 3
                            End Select
                        Case 11 To 20
                            Y = 582 + 45 * (J - 11)    'hang 1
                            Select Case DATA           'cột 4
                                Case "A"
                                    X = 1101
                                Case "B"
                                    X = 1101 + 38.5
                                Case "C"
                                    X = 1101 + 38.5 * 2
                                Case "D"
                                    X = 1101 + 38.5 * 3
                            End Select
                        Case 21 To 30
                            Y = 1073 + 45 * (J - 21)    'hang 2
                            Select Case DATA            'cot 1
                                Case "A"
                                    X = 399
                                Case "B"
                                    X = 399 + 38.5
                                Case "C"
                                    X = 399 + 38.5 * 2
                                Case "D"
                                    X = 399 + 38.5 * 3
                            End Select
                        Case 31 To 40
                            Y = 1073 + 45 * (J - 31)    'hang 2
                            Select Case DATA            'cot 2
                                Case "A"
                                    X = 633
                                Case "B"
                                    X = 633 + 38.5
                                Case "C"
                                    X = 633 + 38.5 * 2
                                Case "D"
                                    X = 633 + 38.5 * 3
                            End Select
                        Case 41 To 50
                            Y = 1073 + 45 * (J - 41)   'hang 2
                            Select Case DATA           'cot3
                                Case "A"
                                    X = 866
                                Case "B"
                                    X = 866 + 38.5
                                Case "C"
                                    X = 866 + 38.5 * 2
                                Case "D"
                                    X = 866 + 38.5 * 3
                            End Select
                        Case 51 To 60
                            Y = 1073 + 45 * (J - 51)   'hang 2
                            Select Case DATA           'cot 4
                                Case "A"
                                    X = 1101
                                Case "B"
                                    X = 1101 + 38.5
                                Case "C"
                                    X = 1101 + 38.5 * 2
                                Case "D"
                                    X = 1101 + 38.5 * 3
                            End Select

                        Case 61 To 70
                            Y = 1565 + 45 * (J - 61)    'hang 3
                            Select Case DATA            'cot 1
                                Case "A"
                                    X = 399
                                Case "B"
                                    X = 399 + 38.5
                                Case "C"
                                    X = 399 + 38.5 * 2
                                Case "D"
                                    X = 399 + 38.5 * 3
                            End Select
                        Case 71 To 80
                            Y = 1565 + 45 * (J - 71)    'hang 3
                            Select Case DATA            'cot 2
                                Case "A"
                                    X = 633
                                Case "B"
                                    X = 633 + 38.5
                                Case "C"
                                    X = 633 + 38.5 * 2
                                Case "D"
                                    X = 633 + 38.5 * 3
                            End Select
                        Case 81 To 90
                            Y = 1565 + 45 * (J - 81)   'hang 3
                            Select Case DATA           'cot3
                                Case "A"
                                    X = 866
                                Case "B"
                                    X = 866 + 38.5
                                Case "C"
                                    X = 866 + 38.5 * 2
                                Case "D"
                                    X = 866 + 38.5 * 3
                            End Select
                        Case 91 To 100
                            Y = 1565 + 45 * (J - 91)   'hang 3
                            Select Case DATA           'cot 4
                                Case "A"
                                    X = 1101
                                Case "B"
                                    X = 1101 + 38.5
                                Case "C"
                                    X = 1101 + 38.5 * 2
                                Case "D"
                                    X = 1101 + 38.5 * 3
                            End Select
                    End Select

                    'VE HINH TRON CO TO NEN ĐEN
                    gr.FillEllipse(BR, X, Y, 29, 29)
                Next
                'TO MA DE
                DATA = Form1.DataGridView1(1, CAUBD - 1).Value.ToString
                DATA_MADE = Nothing
                For k = 1 To 3
                    Select Case k
                        Case 1
                            DATA_MADE = Left(DATA, 1)    'cot 2
                            X = 633
                        Case 2
                            DATA_MADE = Mid(DATA, 2, 1)
                            X = 633 + 38.5
                        Case 3
                            DATA_MADE = Right(DATA, 1)
                            X = 633 + 38.5 * 2
                    End Select

                    Select Case DATA_MADE     'hang 1

                        Case "0"
                            Y = 582
                        Case "1"
                            Y = 582 + 45
                        Case "2"
                            Y = 582 + 45 * 2
                        Case "3"
                            Y = 582 + 45 * 3
                        Case "4"
                            Y = 582 + 45 * 4
                        Case "5"
                            Y = 582 + 45 * 5
                        Case "6"
                            Y = 582 + 45 * 6
                        Case "7"
                            Y = 582 + 45 * 7
                        Case "8"
                            Y = 582 + 45 * 8
                        Case "9"
                            Y = 582 + 45 * 9
                    End Select
                    'VE HINH TRON CO TO NEN ĐEN
                    gr.FillEllipse(BR, X, Y, 29, 29)
                Next

            Case "TN120"
                For I = CAUBD To CAUKT
                    DATA = Form1.DataGridView1(3, I - 1).Value.ToString
                    J = J + 1
                    Select Case J
                        Case 1 To 30
                            Select Case J
                                Case 1 To 5
                                    Y = 784 + 47.5 * (J - 1) 'hang 1
                                Case 6 To 10
                                    Y = 1024 + 47.5 * (J - 6) 'hang 2
                                Case 11 To 15
                                    Y = 1263 + 47.5 * (J - 11) 'hang 3
                                Case 16 To 20
                                    Y = 1503 + 47.5 * (J - 16) 'hang 4
                                Case 21 To 25
                                    Y = 1743 + 47.5 * (J - 21) 'hang 5
                                Case 26 To 30
                                    Y = 1984 + 47.5 * (J - 26) 'hang 6
                            End Select
                            Select Case DATA         'cot 1
                                Case "A"
                                    X = 197
                                Case "B"
                                    X = 197 + 61
                                Case "C"
                                    X = 197 + 61 * 2
                                Case "D"
                                    X = 197 + 61 * 3
                            End Select
                        Case 31 To 60
                            Select Case J
                                Case 31 To 35
                                    Y = 784 + 47.5 * (J - 31) 'hang 1
                                Case 36 To 40
                                    Y = 1024 + 47.5 * (J - 36) 'hang 2
                                Case 41 To 45
                                    Y = 1263 + 47.5 * (J - 41) 'hang 3
                                Case 46 To 50
                                    Y = 1503 + 47.5 * (J - 46) 'hang 4
                                Case 51 To 55
                                    Y = 1743 + 47.5 * (J - 51) 'hang 5
                                Case 56 To 60
                                    Y = 1984 + 47.5 * (J - 56) 'hang 6
                            End Select
                            Select Case DATA         'cot 2
                                Case "A"
                                    X = 563
                                Case "B"
                                    X = 563 + 61
                                Case "C"
                                    X = 563 + 61 * 2
                                Case "D"
                                    X = 563 + 61 * 3
                            End Select
                        Case 61 To 90
                            Select Case J
                                Case 61 To 65
                                    Y = 784 + 47.5 * (J - 61) 'hang 1
                                Case 66 To 70
                                    Y = 1024 + 47.5 * (J - 66) 'hang 2
                                Case 71 To 75
                                    Y = 1263 + 47.5 * (J - 71) 'hang 3
                                Case 76 To 80
                                    Y = 1503 + 47.5 * (J - 76) 'hang 4
                                Case 81 To 85
                                    Y = 1743 + 47.5 * (J - 81) 'hang 5
                                Case 86 To 90
                                    Y = 1984 + 47.5 * (J - 86) 'hang 6
                            End Select
                            Select Case DATA         'cot 3
                                Case "A"
                                    X = 927
                                Case "B"
                                    X = 927 + 61
                                Case "C"
                                    X = 927 + 61 * 2
                                Case "D"
                                    X = 927 + 61 * 3
                            End Select
                        Case 91 To 120
                            Select Case J
                                Case 91 To 95
                                    Y = 784 + 47.5 * (J - 91) 'hang 1
                                Case 96 To 100
                                    Y = 1024 + 47.5 * (J - 96) 'hang 2
                                Case 101 To 105
                                    Y = 1263 + 47.5 * (J - 101) 'hang 3
                                Case 106 To 110
                                    Y = 1503 + 47.5 * (J - 106) 'hang 4
                                Case 111 To 115
                                    Y = 1743 + 47.5 * (J - 111) 'hang 5
                                Case 116 To 120
                                    Y = 1984 + 47.5 * (J - 116) 'hang 6
                            End Select
                            Select Case DATA         'cot 4
                                Case "A"
                                    X = 1290
                                Case "B"
                                    X = 1290 + 61
                                Case "C"
                                    X = 1290 + 61 * 2
                                Case "D"
                                    X = 1290 + 61 * 3
                            End Select
                    End Select

                    'VE HINH TRON CO TO NEN ĐEN
                    gr.FillEllipse(BR, X, Y, 31, 31)
                Next
                'TO MA DE
                DATA = Form1.DataGridView1(1, CAUBD - 1).Value.ToString
                DATA_MADE = Nothing
                For k = 1 To 3
                    Select Case k
                        Case 1
                            DATA_MADE = Left(DATA, 1)    'cot 2
                            X = 1451
                        Case 2
                            DATA_MADE = Mid(DATA, 2, 1)
                            X = 1483
                        Case 3
                            DATA_MADE = Right(DATA, 1)
                            X = 1515
                    End Select

                    Select Case DATA_MADE

                        Case "0"
                            Y = 206
                        Case "1"
                            Y = 206 + 47.3
                        Case "2"
                            Y = 206 + 47.3 * 2
                        Case "3"
                            Y = 206 + 47.3 * 3
                        Case "4"
                            Y = 206 + 47.3 * 4
                        Case "5"
                            Y = 206 + 47.3 * 5
                        Case "6"
                            Y = 206 + 47.3 * 6
                        Case "7"
                            Y = 206 + 47.3 * 7
                        Case "8"
                            Y = 206 + 47.3 * 8
                        Case "9"
                            Y = 206 + 47.3 * 9
                    End Select
                    'VE HINH TRON CO TO NEN ĐEN
                    gr.FillEllipse(BR, X, Y, 26, 26)
                Next
            Case "TN_NGANG_40"
                For I = CAUBD To CAUKT
                    DATA = Form1.DataGridView1(3, I - 1).Value.ToString
                    J = J + 1
                    Select Case J
                        Case 1 To 10
                            Select Case J
                                Case 1 To 10
                                    Y = 648 + 47 * (J - 1) 'hang 1
                            End Select
                            Select Case DATA         'cot 1
                                Case "A"
                                    X = 213.5
                                Case "B"
                                    X = 213.5 + 60
                                Case "C"
                                    X = 213.5 + 60 * 2
                                Case "D"
                                    X = 213.5 + 60 * 3
                            End Select
                        Case 11 To 20
                            Select Case J
                                Case 11 To 20
                                    Y = 648 + 47 * (J - 11) 'hang 1
                            End Select
                            Select Case DATA         'cot 2
                                Case "A"
                                    X = 573
                                Case "B"
                                    X = 573 + 60
                                Case "C"
                                    X = 573 + 60 * 2
                                Case "D"
                                    X = 573 + 60 * 3
                            End Select
                        Case 21 To 30
                            Select Case J
                                Case 21 To 30
                                    Y = 648 + 47 * (J - 21) 'hang 1
                            End Select
                            Select Case DATA         'cot 3
                                Case "A"
                                    X = 930
                                Case "B"
                                    X = 930 + 60
                                Case "C"
                                    X = 930 + 60 * 2
                                Case "D"
                                    X = 930 + 60 * 3
                            End Select
                        Case 31 To 40
                            Select Case J
                                Case 31 To 40
                                    Y = 648 + 47 * (J - 31) 'hang 1
                            End Select
                            Select Case DATA         'cot 4
                                Case "A"
                                    X = 1285
                                Case "B"
                                    X = 1285 + 60
                                Case "C"
                                    X = 1285 + 60 * 2
                                Case "D"
                                    X = 1285 + 60 * 3
                            End Select
                    End Select

                    'VE HINH TRON CO TO NEN ĐEN
                    gr.FillEllipse(BR, X, Y, 31, 31)
                Next
                'TO MA DE
                DATA = Form1.DataGridView1(1, CAUBD - 1).Value.ToString
                DATA_MADE = Nothing
                For k = 1 To 3
                    Select Case k
                        Case 1
                            DATA_MADE = Left(DATA, 1)    'cot 2
                            X = 1468
                        Case 2
                            DATA_MADE = Mid(DATA, 2, 1)
                            X = 1500
                        Case 3
                            DATA_MADE = Right(DATA, 1)
                            X = 1532
                    End Select

                    Select Case DATA_MADE

                        Case "0"
                            Y = 114
                        Case "1"
                            Y = 114 + 46
                        Case "2"
                            Y = 114 + 46 * 2
                        Case "3"
                            Y = 114 + 46 * 3
                        Case "4"
                            Y = 114 + 46 * 4
                        Case "5"
                            Y = 114 + 46 * 5
                        Case "6"
                            Y = 114 + 46 * 6
                        Case "7"
                            Y = 114 + 46 * 7
                        Case "8"
                            Y = 114 + 46 * 8
                        Case "9"
                            Y = 114 + 46 * 9
                    End Select
                    'VE HINH TRON CO TO NEN ĐEN
                    gr.FillEllipse(BR, X, Y, 26, 26)
                Next
        End Select
    End Sub
End Module
