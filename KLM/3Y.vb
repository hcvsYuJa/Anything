Public Class K3Y
    Dim a1, b1, c1, d1, a2, b2, c2, d2, a3, b3, c3, d3 As Long

    Private Sub TextBox13_TextChanged(sender As Object, e As EventArgs) Handles TextBox13.TextChanged

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        MsgBox("" & Fi_Str, vbInformation + vbOKOnly, "運算結果")
    End Sub

    Dim d, dx, dy, dz As Long
    Dim Fi_Str As String = ""


    Private Sub K3Y_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
    Private Sub K3Y_Closed(sender As Object, e As EventArgs) Handles MyBase.Closed
        REM 只要K3Y表單(此表單)按下(x)將此表單隱藏，並叫出初始介面
        S.Show()
        Me.Dispose()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        REM 按下「計算開始」
        TextBox13.Text = "輸出區域..."
        Label13.BringToFront() '「Please Wait... 」此Label物件移至最上層
        Button1.Hide() '「計算開始」的按鈕 -> 隱藏
        Call Input(True)
        REM 讀入數值
        'Val()傳回字串中代表的數值
        a1 = Val(TextBox1.Text) '第一式的a1係數
        b1 = Val(TextBox2.Text) '第一式的b1係數
        c1 = Val(TextBox3.Text) '第一式的c1係數
        d1 = Val(TextBox4.Text) '第一式的d1係數
        a2 = Val(TextBox5.Text) '第二式的a2係數
        b2 = Val(TextBox6.Text) '第二式的b2係數
        c2 = Val(TextBox7.Text) '第二式的c2係數
        d2 = Val(TextBox8.Text) '第二式的d2係數
        a3 = Val(TextBox9.Text) '第三式的a3係數
        b3 = Val(TextBox10.Text) '第三式的b3係數
        c3 = Val(TextBox11.Text) '第三式的c3係數
        d3 = Val(TextBox12.Text) '第三式的d3係數
        REM 計算d , dx , dy , dz 基礎判斷的數值
        d = (a1 * b2 * c3) + (a2 * b3 * c1) + (a3 * c2 * b1) - (c1 * b2 * a3) - (c2 * b3 * a1) - (c3 * a2 * b1)
        dx = (d1 * b2 * c3) + (d2 * b3 * c1) + (d3 * c2 * b1) - (c1 * b2 * d3) - (c2 * b3 * d1) - (c3 * d2 * b1)
        dy = (a1 * d2 * c3) + (a2 * d3 * c1) + (a3 * c2 * d1) - (c1 * d2 * a3) - (c2 * d3 * a1) - (c3 * a2 * d1)
        dz = (a1 * b2 * d3) + (a2 * b3 * d1) + (a3 * d2 * b1) - (d1 * b2 * a3) - (d2 * b3 * a1) - (d3 * a2 * b1)
        If (d = 0) And (dx = 0) And (dy = 0) And (dz = 0) Then
            TextBox13.Text = "無限多組解!"
            Fi_Str = "△ = " & d & vbCrLf & "△x = " & dx & vbCrLf & "△y = " & dy & vbCrLf & "△z = " & dz & vbCrLf
            Fi_Str &= "因: △ = △x = △y = △z = 0" & vbCrLf & "因而:「無限多組解!」"
        ElseIf (d = 0) And (dx <> 0 Or dy <> 0 Or dz <> 0) Then
            TextBox13.Text = "無解!"
            Fi_Str = "△ = " & d & vbCrLf & "△x = " & dx & vbCrLf & "△y = " & dy & vbCrLf & "△z = " & dz & vbCrLf
            Fi_Str &= "因: △ = " & d & " ，但" & vbCrLf
            If dx <> 0 Then
                Fi_Str &= "△x = " & dx & vbCrLf
            End If
            If dy <> 0 Then
                Fi_Str &= "△y = " & dy & vbCrLf
            End If
            If dz <> 0 Then
                Fi_Str &= "△y = " & dz & vbCrLf
            End If
            Fi_Str &= "△x 或 △y 或 △z 至少一個不為0" & vbCrLf & "因而:「無解!」"
        Else
            Call Print()
        End If
        REM 啟動輸入模式
        Call Input(False)
        Button1.Show() '「計算開始」的按鈕 -> 顯示
        Label13.SendToBack() '「Please Wait 」此Label物件移至最下層
        Button2.Show() '運算結果
    End Sub
    Private Sub Input(ByVal B As Boolean)
        'ReadOnly=True 將物件改為唯讀。
        TextBox1.ReadOnly = B 'TextBox1 -> a1
        TextBox2.ReadOnly = B 'TextBox4 -> b1
        TextBox3.ReadOnly = B 'TextBox7 -> c1
        TextBox4.ReadOnly = B 'TextBox2 -> d1
        TextBox5.ReadOnly = B 'TextBox5 -> a2
        TextBox6.ReadOnly = B 'TextBox8 -> b2
        TextBox7.ReadOnly = B 'TextBox3 -> c2
        TextBox8.ReadOnly = B 'TextBox6 -> d2
        TextBox9.ReadOnly = B 'TextBox9 -> a3
        TextBox10.ReadOnly = B 'TextBox9 -> b3
        TextBox11.ReadOnly = B 'TextBox9 -> c3
        TextBox12.ReadOnly = B 'TextBox9 -> d3
    End Sub
    Private Sub Print()
        Dim Str As String = ""

        'd
        Str &= "△ =  ( "
        Fi_Str = "△ =  " & d '懶人包
        Call Fi_PN(d, Fi_Str)
        Call Formula1_PN(a1, Str) : Str &= " * "
        Call Formula1_PN(b2, Str) : Str &= " * "
        Call Formula1_PN(c3, Str) : Str &= " ) + ( "
        Call Formula1_PN(a2, Str) : Str &= " * "
        Call Formula1_PN(b3, Str) : Str &= " * "
        Call Formula1_PN(c1, Str) : Str &= " ) + ( "
        Call Formula1_PN(a3, Str) : Str &= " * "
        Call Formula1_PN(c2, Str) : Str &= " * "
        Call Formula1_PN(b1, Str)
        Str &= " ) - ( "
        Call Formula1_PN(c1, Str) : Str &= " * "
        Call Formula1_PN(b2, Str) : Str &= " * "
        Call Formula1_PN(a3, Str) : Str &= " ) - ( "
        Call Formula1_PN(c2, Str) : Str &= " * "
        Call Formula1_PN(b3, Str) : Str &= " * "
        Call Formula1_PN(a1, Str) : Str &= " ) - ( "
        Call Formula1_PN(c3, Str) : Str &= " * "
        Call Formula1_PN(a2, Str) : Str &= " * "
        Call Formula1_PN(b1, Str)
        Str &= " )" & vbCrLf & " = " & d
        Call Fi_PN(d, Str)

        'dx
        Str &= "△ x =  ( "
        Fi_Str &= "△ x =  " & dx '懶人包
        Call Fi_PN(dx, Fi_Str)
        Call Formula1_PN(d1, Str) : Str &= " * "
        Call Formula1_PN(b2, Str) : Str &= " * "
        Call Formula1_PN(c3, Str) : Str &= " ) + ( "
        Call Formula1_PN(d2, Str) : Str &= " * "
        Call Formula1_PN(b3, Str) : Str &= " * "
        Call Formula1_PN(c1, Str) : Str &= " ) + ( "
        Call Formula1_PN(d3, Str) : Str &= " * "
        Call Formula1_PN(c2, Str) : Str &= " * "
        Call Formula1_PN(b1, Str)
        Str &= " ) - ( "
        Call Formula1_PN(c1, Str) : Str &= " * "
        Call Formula1_PN(b2, Str) : Str &= " * "
        Call Formula1_PN(d3, Str) : Str &= " ) - ( "
        Call Formula1_PN(c2, Str) : Str &= " * "
        Call Formula1_PN(b3, Str) : Str &= " * "
        Call Formula1_PN(d1, Str) : Str &= " ) - ( "
        Call Formula1_PN(c3, Str) : Str &= " * "
        Call Formula1_PN(d2, Str) : Str &= " * "
        Call Formula1_PN(b1, Str)
        Str &= " )" & vbCrLf & " = " & dx
        Call Fi_PN(dx, Str)
        'dy 
        Str &= "△ y =  ( "
        Fi_Str &= "△ y =  " & dy '懶人包
        Call Fi_PN(dy, Fi_Str)
        Call Formula1_PN(a1, Str) : Str &= " * "
        Call Formula1_PN(d2, Str) : Str &= " * "
        Call Formula1_PN(c3, Str) : Str &= " ) + ( "
        Call Formula1_PN(a2, Str) : Str &= " * "
        Call Formula1_PN(d3, Str) : Str &= " * "
        Call Formula1_PN(c1, Str) : Str &= " ) + ( "
        Call Formula1_PN(a3, Str) : Str &= " * "
        Call Formula1_PN(c2, Str) : Str &= " * "
        Call Formula1_PN(d1, Str)
        Str &= " ) - ( "
        Call Formula1_PN(c1, Str) : Str &= " * "
        Call Formula1_PN(d2, Str) : Str &= " * "
        Call Formula1_PN(a3, Str) : Str &= " ) - ( "
        Call Formula1_PN(c2, Str) : Str &= " * "
        Call Formula1_PN(d3, Str) : Str &= " * "
        Call Formula1_PN(a1, Str) : Str &= " ) - ( "
        Call Formula1_PN(c3, Str) : Str &= " * "
        Call Formula1_PN(a2, Str) : Str &= " * "
        Call Formula1_PN(d1, Str)
        Str &= " )" & vbCrLf & " = " & dy
        Call Fi_PN(dy, Str)
        'dz MAKE
        'dz =   - (d1 * b2 * a3) - (d2 * b3 * a1) - (d3 * a2 * b1)
        Str &= "△ z =  ( "
        Fi_Str &= "△ z =  " & dz '懶人包
        Call Fi_PN(dz, Fi_Str)
        Call Formula1_PN(a1, Str) : Str &= " * "
        Call Formula1_PN(b2, Str) : Str &= " * "
        Call Formula1_PN(d3, Str) : Str &= " ) + ( "
        Call Formula1_PN(a2, Str) : Str &= " * "
        Call Formula1_PN(b3, Str) : Str &= " * "
        Call Formula1_PN(d1, Str) : Str &= " ) + ( "
        Call Formula1_PN(a3, Str) : Str &= " * "
        Call Formula1_PN(d2, Str) : Str &= " * "
        Call Formula1_PN(b1, Str)
        Str &= " ) - ( "
        Call Formula1_PN(d1, Str) : Str &= " * "
        Call Formula1_PN(b2, Str) : Str &= " * "
        Call Formula1_PN(a3, Str) : Str &= " ) - ( "
        Call Formula1_PN(d2, Str) : Str &= " * "
        Call Formula1_PN(b3, Str) : Str &= " * "
        Call Formula1_PN(a1, Str) : Str &= " ) - ( "
        Call Formula1_PN(d3, Str) : Str &= " * "
        Call Formula1_PN(a2, Str) : Str &= " * "
        Call Formula1_PN(b1, Str)
        Str &= " )" & vbCrLf & " = " & dz
        Call Fi_PN(dz, Str)
        'X
        Fi_Str &= "分子 / 分母" & vbCrLf & "X = " '懶人包
        Str &= "分子 / 分母" & vbCrLf & "X = "
        Call Fi_XY(dx, d, Str)
        'Y
        Str &= vbCrLf & "Y = "
        Fi_Str &= vbCrLf & "Y = " '懶人包
        Call Fi_XY(dy, d, Str)
        'Z
        Str &= vbCrLf & "Z = "
        Fi_Str &= vbCrLf & "Z = " '懶人包
        Call Fi_XY(dz, d, Str)
        REM 輸出結果
        TextBox13.Text = Str

    End Sub
    Private Sub Formula1_PN(ByVal V As Long, ByRef S As String)
        If V < 0 Then
            S &= "(" & V & ")"
        Else
            S &= V
        End If
    End Sub
    Private Sub Formula2_PN(ByVal V As Long, ByRef S As String)
        If V >= 0 Then
            S &= " + " & V
        Else
            S &= " - " & (V * -1)
        End If
    End Sub
    Private Sub Fi_PN(ByVal V As Long, ByRef S As String)
        If V < 0 Then
            S &= "(負)" & vbCrLf
        Else
            S &= vbCrLf
        End If
    End Sub
    Private Function Max(ByVal dz As Long, ByVal d As Long)
        REM 找最大公因數
        Dim t As Long = 0
        Do While d <> 0
            t = dz Mod d
            dz = d
            d = t
        Loop
        Return dz
    End Function
    Private Sub Fi_XY(ByVal A As Long, ByVal B As Long, ByRef S As String)
        If A Mod B = 0 Then
            S &= " = " & (A / B)
            Fi_Str &= A / B '懶人包
        Else
            Dim M As Long
            M = Max(A, B)
            If M <> 1 And M <> -1 Then
                S &= A & " / " & B & vbCrLf
            End If
            Fi_Str &= A / M & " / " & B / M '懶人包
            S &= " = " & (A / M) & " / " & (B / M)
        End If
        If (A < 0 Or B < 0) And (A > 0 Or B > 0) Then
            S &= "(負)"
            Fi_Str &= "(負)"
        End If
    End Sub
End Class
