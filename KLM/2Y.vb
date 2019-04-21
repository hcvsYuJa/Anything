Public Class K2Y
    Dim a1, b1, c1, a2, b2, c2 As Long '輸入值目前只吃整數
    Dim d, dx, dy As Long
    Dim Fi_Str As String = ""
    Private Sub K2Y_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
    Private Sub K2Y_Closed(sender As Object, e As EventArgs) Handles MyBase.Closed
        REM 只要K2Y表單(此表單)按下(x)將此表單隱藏，並叫出初始介面
        S.Show()
        Me.Dispose()
    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        MsgBox("" & Fi_Str, vbInformation + vbOKOnly, "運算結果")
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        REM 按下「計算開始」
        Button2.Hide()
        TextBox7.Text = "輸出區域....."
        Label9.BringToFront() '「Please Wait 」此Label物件移至最上層
        Button1.Hide() '「計算開始」的按鈕 -> 隱藏
        'ReadOnly=True 將物件改為唯讀。
        TextBox1.ReadOnly = True 'TextBox1 -> a1
        TextBox2.ReadOnly = True 'TextBox2 -> b1
        TextBox3.ReadOnly = True 'TextBox3 -> c1
        TextBox4.ReadOnly = True 'TextBox4 -> a2
        TextBox5.ReadOnly = True 'TextBox5 -> b2
        TextBox6.ReadOnly = True 'TextBox6 -> c2
        REM 讀入數值
        'Val()傳回字串中代表的數值
        a1 = Val(TextBox1.Text) '第一式的a1係數
        b1 = Val(TextBox2.Text) '第一式的b1係數
        c1 = Val(TextBox3.Text) '第一式的c1係數
        a2 = Val(TextBox4.Text) '第二式的a2係數
        b2 = Val(TextBox5.Text) '第二式的b2係數
        c2 = Val(TextBox6.Text) '第二式的c2係數
        REM 計算d , dx , dy 基礎判斷的數值
        d = (a1 * b2) - (a2 * b1) '計算d
        dx = (c1 * b2) - (b1 * c2) '計算dx
        dy = (a1 * c2) - (a2 * c1) '計算dy
        If (d = 0 And dx = 0 And dy = 0) Then
            TextBox7.Text = "無限多組解!"
            Fi_Str = "△ = " & d & vbCrLf & "△x = " & dx & vbCrLf & "△y = " & dy & vbCrLf
            Fi_Str &= "因: △ = △x = △y = 0" & vbCrLf & "因而:「無限多組解!」"
        ElseIf (d = 0 And (dx <> 0 Or dy <> 0)) Then
            TextBox7.Text = "無解!"
            Fi_Str = "△ = " & d & vbCrLf & "△x = " & dx & vbCrLf & "△y = " & dy & vbCrLf
            Fi_Str &= "因: △ = " & d & " ，但" & vbCrLf
            If dx <> 0 Then
                Fi_Str &= "△x = " & dx & vbCrLf
            End If
            If dy <> 0 Then
                Fi_Str &= "△y = " & dy & vbCrLf
            End If
            Fi_Str &= "△x 或 △y 至少一個不為0" & vbCrLf & "因而:「無解!」"
        Else
            Call Print()
        End If
        REM 啟動輸入模式
        TextBox1.ReadOnly = False 'TextBox1 -> a1
        TextBox2.ReadOnly = False 'TextBox2 -> b1
        TextBox3.ReadOnly = False 'TextBox3 -> c1
        TextBox4.ReadOnly = False 'TextBox4 -> a2
        TextBox5.ReadOnly = False 'TextBox5 -> b2
        TextBox6.ReadOnly = False 'TextBox6 -> c2
        Button1.Show() '「計算開始」的按鈕 -> 顯示
        Label9.SendToBack() '「Please Wait 」此Label物件移至最下層
        Button2.Show()
    End Sub

    Private Sub Print()
        'Throw New NotImplementedException()
        Dim Str As String = ""
        'd
        Str &= "△ =  ( "
        Call Formula1_PN(a1, Str) : Str &= " * "
        Call Formula1_PN(b2, Str) : Str &= " ) - ( "
        Call Formula1_PN(b1, Str) : Str &= " * "
        Call Formula1_PN(a2, Str)
        Str &= " )" & vbCrLf & " = "
        Call Formula1_PN((a1 * b2), Str)
        Call Formula2_PN((b1 * a2 * -1), Str)
        Str &= vbCrLf & " = " & d
        Fi_Str = "△ = " & d '懶人包
        Call Fi_PN(d, Fi_Str)
        Call Fi_PN(d, Str)
        'dx
        Str &= "△x = ( "
        Call Formula1_PN(c1, Str) : Str &= " * "
        Call Formula1_PN(b2, Str) : Str &= " ) - ( "
        Call Formula1_PN(b1, Str) : Str &= " * "
        Call Formula1_PN(c2, Str)
        Str &= " )" & vbCrLf & " = "
        Call Formula1_PN((c1 * b2), Str)
        Call Formula2_PN((b1 * c2 * -1), Str)
        Str &= vbCrLf & " = " & dx
        Fi_Str &= "△x = " & dx '懶人包
        Call Fi_PN(dx, Fi_Str)
        Call Fi_PN(dx, Str)
        'dy
        Str &= "△y = ( "
        Call Formula1_PN(a1, Str) : Str &= " * "
        Call Formula1_PN(c2, Str) : Str &= " ) - ( "
        Call Formula1_PN(c1, Str) : Str &= " * "
        Call Formula1_PN(a2, Str)
        Str &= " )" & vbCrLf & " = "
        Call Formula1_PN((a1 * c2), Str)
        Call Formula2_PN((c1 * a2 * -1), Str)
        Str &= vbCrLf & " = " & dy
        Fi_Str &= "△y = " & dy '懶人包
        Call Fi_PN(dy, Fi_Str)
        Call Fi_PN(dy, Str)
        'X
        Fi_Str &= "分子 / 分母" & vbCrLf & "X = " '懶人包
        Str &= "分子 / 分母" & vbCrLf & "X = "
        Call Fi_XY(dx, d, Str)
        'Y
        Str &= vbCrLf & "Y = "
        Fi_Str &= vbCrLf & "Y = " '懶人包
        Call Fi_XY(dy, d, Str)
        '輸出結果
        TextBox7.Text = Str
    End Sub
    Private Sub Fi_PN(ByVal V As Long, ByRef S As String)
        If V < 0 Then
            S &= "(負)" & vbCrLf
        Else
            S &= vbCrLf
        End If
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
