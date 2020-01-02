Public Class Form1

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        tb_pass.UseSystemPasswordChar = True

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If tb_usr.Text = "admin" And tb_pass.Text = "12345" Then
            MsgBox("Selamat anda berhasil login")
            transaksi.Show()
            Me.Hide()
        Else
            MsgBox("Username atau Password yang anda masukan salah")

        End If
    End Sub

    Private Sub cb_show_CheckedChanged(sender As Object, e As EventArgs) Handles cb_show.CheckedChanged
        If cb_show.Checked = True Then

            tb_pass.UseSystemPasswordChar = False



        Else
            cb_show.Checked = False
            tb_pass.UseSystemPasswordChar = True


        End If
    End Sub
End Class
