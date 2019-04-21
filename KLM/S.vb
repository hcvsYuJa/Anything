Public Class S
    Private Sub FileSystemWatcher1_Changed(sender As Object, e As IO.FileSystemEventArgs) Handles FileSystemWatcher1.Changed

    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        K2Y.Show()
        Me.Hide()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        K3Y.Show()
        Me.Hide()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        MsgBox("開發者：薛榆杰" & vbCrLf & "負責項目：最初開發整隻程式" & vbCrLf & "使用語言：C" & vbCrLf & "軟體使用Dev-C++ 5.11" & vbCrLf & "二次開發者：余嘉笠" & vbCrLf & "負責項目：將程式從C轉為VB與表單製作" & vbCrLf & "使用語言Visual Basic" & vbCrLf & "專案使用Windows Form App(.NET Framework)" & vbCrLf & "軟體使用Microsoft Visual Stdio 2019", vbInformation + vbOKOnly, "開發者訊息")
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        End
    End Sub
End Class
