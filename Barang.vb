Imports System.Data.SqlClient
Public Class Barang

    Sub Kosongkan()

        Tkd_brng.Clear()
        tnm_barang.Clear()
        cb_satuan.Text = ""
        tb_harga.Clear()
        stok.Clear()
        Tkd_brng.Focus()


    End Sub

    Sub Databaru()
        tnm_barang.Clear()
        cb_satuan.Text = ""
        tb_harga.Clear()
        stok.Clear()
        tnm_barang.Focus()


    End Sub
    Sub ketemu()
        On Error Resume Next
        tnm_barang.Text = Dr.Item("nama_barang")
        cb_satuan.Text = Dr.Item("satuan_barng")
        tb_harga.Text = Dr.Item("harga")
        stok.Text = Dr.Item("stok")
        tnm_barang.Focus()




    End Sub
    Sub Tampilsatuan()
        Call koneksi()
        CMD = New SqlCommand("Select distinct satuan_barng from tb_brg", Conn)
        Dr = CMD.ExecuteReader
        cb_satuan.Items.Clear()
        Do While Dr.Read
            cb_satuan.Items.Add(Dr.Item("satuan_barng"))

        Loop
        Conn.Close()

    End Sub
    Sub Tampilgrid()
        Call koneksi()
        Da = New SqlDataAdapter("Select * from tb_brg", Conn)
        Ds = New DataSet
        Da.Fill(Ds)
        Dgv.DataSource = Ds.Tables(0)
        Dgv.ReadOnly = True

    End Sub
    Sub Carikode()
        Call koneksi()
        CMD = New SqlCommand("Select *from tb_brg where kode_barang='" & Tkd_brng.Text & "'", Conn)
        Dr = CMD.ExecuteReader
        Dr.Read()

    End Sub
    Sub kondisiawal()
        Call Tampilgrid()
        Call Tampilsatuan()
        Call Kosongkan()
    End Sub
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Call kondisiawal()

    End Sub

    Private Sub Tkd_brng_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Tkd_brng.KeyPress
        If e.KeyChar = Chr(13) Then
            Call Carikode()
            If Dr.HasRows Then
                Call ketemu()
            Else
                Call Databaru()


            End If
        End If
    End Sub

    Private Sub B_simpan_Click(sender As Object, e As EventArgs) Handles B_simpan.Click
        Try
            Call Carikode()
            If Not Dr.HasRows Then
                Call koneksi()
                Dim simpan As String = "INSERT INTO tb_brg values  ('" & Tkd_brng.Text & "','" & tnm_barang.Text & "','" & cb_satuan.Text & "','" & tb_harga.Text & "','" & stok.Text & "')"
                CMD = New SqlCommand(simpan, Conn)
                CMD.ExecuteNonQuery()
                Conn.Close()
                Call kondisiawal()
            Else
                Call koneksi()
                Dim edit As String = "Update tb_brg set nama_barang='" & tnm_barang.Text & "',satuan_barng ='" & cb_satuan.Text & "' ,harga ='" & tb_harga.Text & "',stok='" & stok.Text & "' where kode_barang='" & Tkd_brng.Text & "'"
                CMD = New SqlCommand(edit, Conn)
                CMD.ExecuteNonQuery()
                Conn.Close()
                Call kondisiawal()
            End If


        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub

    Private Sub TextBox3_TextChanged(sender As Object, e As EventArgs) Handles TextBox3.TextChanged
        Call koneksi()
        Da = New SqlDataAdapter("select * from tb_brg where nama_barang like '%" & TextBox3.Text & "%'", Conn)
        Ds = New DataSet
        Da.Fill(Ds)
        Dgv.DataSource = Ds.Tables(0)
        Dgv.ReadOnly = True

    End Sub

    Private Sub B_batal_Click(sender As Object, e As EventArgs) Handles B_batal.Click
        Call Kosongkan()

    End Sub

    Private Sub B_tutup_Click(sender As Object, e As EventArgs) Handles B_tutup.Click
        Me.Close()

    End Sub

    Private Sub Hapus_Click(sender As Object, e As EventArgs) Handles Hapus.Click
        If Tkd_brng.Text = "" Then
            MsgBox("Kode barang harus diisi")
            Tkd_brng.Focus()
            Exit Sub

        End If
        Call Carikode()
        If Not Dr.HasRows Then
            MsgBox("Kode tidak terdaftar")
            Exit Sub

        End If
        If MessageBox.Show("Yakin Hapus...?", "", MessageBoxButtons.YesNo) = Windows.Forms.DialogResult.Yes Then
            Call koneksi()
            Dim hapus As String = "delete from tb_brg where kode_barang='" & Tkd_brng.Text & "'"
            CMD = New SqlCommand(hapus, Conn)
            CMD.ExecuteNonQuery()
            Conn.Close()
            Call kondisiawal()
        Else
            Call Kosongkan()


        End If
    End Sub

    Private Sub Dgv_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles Dgv.CellContentClick

    End Sub

    Private Sub Dgv_CellMouseClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles Dgv.CellMouseClick
        Tkd_brng.Text = Dgv.Rows(e.RowIndex).Cells(0).Value
        tnm_barang.Text = Dgv.Rows(e.RowIndex).Cells(1).Value
        cb_satuan.Text = Dgv.Rows(e.RowIndex).Cells(2).Value
        tb_harga.Text = Dgv.Rows(e.RowIndex).Cells(3).Value
        stok.Text = Dgv.Rows(e.RowIndex).Cells(4).Value

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Me.Hide()
        transaksi.Show()

    End Sub
End Class


