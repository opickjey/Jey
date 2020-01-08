Public Class login_edit

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If id.Text = "login" And pass.Text = "12345" Then
            MsgBox("Selamat")
            Me.Hide()
            Barang.Show()

        Else
            MsgBox("UserID atau Pass yang anda masukan salah")


        End If
    End Sub
End Class