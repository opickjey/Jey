Imports System.Data.SqlClient

Module Module1
    Public Conn As SqlConnection
    Public Da As SqlDataAdapter
    Public Ds As DataSet
    Public CMD As SqlCommand
    Public Dr As SqlDataReader

    Public Sub koneksi()
        Conn = New SqlConnection("Data Source=DESKTOP-6U85BAF\SQLEXPRESS;Integrated Security=True")
        Conn.Open()

    End Sub
End Module
