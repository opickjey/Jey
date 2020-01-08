Imports System.Data.SqlClient
Public Class transaksi

    Private Sub transaksi_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Call koneksi()
        Da = New SqlDataAdapter("Select *from tb_brg", Conn)
        Ds = New DataSet
        Da.Fill(Ds)
        dgv2.DataSource = Ds.Tables(0)
        dgv2.ReadOnly = True
        Timer1.Enabled = True


    End Sub


    Private Sub dgv2_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgv2.CellContentClick

    End Sub

    Private Sub dgv2_CellMouseClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles dgv2.CellMouseClick
        Dim row As String() = New String() {dgv2.Rows(e.RowIndex).Cells(0).Value, dgv2.Rows(e.RowIndex).Cells(1).Value, dgv2.Rows(e.RowIndex).Cells(3).Value, 1, 1 * dgv2.Rows(e.RowIndex).Cells(3).Value}
        dgv1.Rows.Add(row)
        For i As Integer = i + 1 To dgv1.RowCount - 1
            For j As Integer = i + 1 To dgv1.RowCount - 1
                If dgv1.Rows(i).Cells(0).Value = dgv1.Rows(j).Cells(0).Value Then
                    MessageBox.Show("kode " & dgv1.Rows(i).Cells(0).Value & "sudah di entri")
                    SendKeys.Send("{up}")
                    dgv1.Rows(j).Cells(0).Value = ""
                    dgv1.Rows(j).Cells(1).Value = ""
                    dgv1.Rows(j).Cells(2).Value = ""
                    dgv1.Rows(j).Cells(3).Value = ""
                    dgv1.Rows(j).Cells(4).Value = ""
                    dgv1.Rows.RemoveAt(j)
                    Exit Sub

                End If
            Next
        Next


        Call total_barang()
        Call banyak_barang()
    End Sub


    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Me.Hide()
        login_edit.Show()


    End Sub


    Sub Kosongkan()

        tb_bb.Clear()
        t_bayar.Clear()
        t_kembali.Clear()
        tb_bb.Focus()



    End Sub

    Sub banyak_barang()
        Dim hitung As Integer = 0
        For baris As Integer = 0 To dgv1.RowCount - 1
            hitung = hitung + dgv1.Rows(baris).Cells(3).Value
            tb_bb.Text = hitung

        Next
    End Sub
    Sub total_barang()
        Dim hitung As Integer = 0
        For baris As Integer = 0 To dgv1.RowCount - 1
            hitung = hitung + dgv1.Rows(baris).Cells(4).Value
            t_total.Text = hitung

        Next

    End Sub


    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Call Kosongkan()

    End Sub



    Private Sub dgv1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgv1.CellContentClick

    End Sub

    Private Sub dgv1_CellEndEdit(sender As Object, e As DataGridViewCellEventArgs) Handles dgv1.CellEndEdit
        If e.ColumnIndex = 3 Then
            dgv1.Rows(e.RowIndex).Cells(4).Value = dgv1.Rows(e.RowIndex).Cells(2).Value * dgv1.Rows(e.RowIndex).Cells(3).Value
        End If
        Call banyak_barang()
        Call total_barang()

    End Sub

    


    Private Sub dgv1_KeyPress(sender As Object, e As KeyPressEventArgs) Handles dgv1.KeyPress
        On Error Resume Next
        If e.KeyChar = Chr(27) Then
            dgv1.Rows.Remove(dgv1.CurrentRow)
            Call banyak_barang()
            Call total_barang()

        End If
    End Sub

    Private Sub tn_total_TextChanged(sender As Object, e As EventArgs)

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Me.Close()

    End Sub

    Private Sub tb_byr_TextChanged(sender As Object, e As EventArgs)

    End Sub

    Private Sub t_bayar_KeyPress(sender As Object, e As KeyPressEventArgs) Handles t_bayar.KeyPress
        If e.KeyChar = Chr(13) Then
            If Val(t_bayar.Text) < Val(t_total.Text) Then
                MsgBox("Pembayaran kurang")
                Exit Sub

            ElseIf Val(t_bayar.Text) = Val(t_total.Text) Then
                t_bayar.Text = 0
            ElseIf Val(t_bayar.Text) > Val(t_total.Text) Then
                t_kembali.Text = Val(t_bayar.Text) - Val(t_total.Text)

            End If
        End If
    End Sub

  

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Label8.Text = Format(Now, "dd-MM-yyy")
        Label9.Text = Format(Now, "HH:mm:ss")
    End Sub

    Private Sub Timer2_Tick(sender As Object, e As EventArgs)

    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged
        Call koneksi()
        Da = New SqlDataAdapter("select * from tb_brg where nama_barang like '%" & TextBox1.Text & "%'", Conn)
        Ds = New DataSet
        Da.Fill(Ds)
        dgv2.DataSource = Ds.Tables(0)
        dgv2.ReadOnly = True
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Me.Close()
        Login.Show()

    End Sub
End Class