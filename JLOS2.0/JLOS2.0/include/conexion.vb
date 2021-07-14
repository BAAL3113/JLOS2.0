Imports System.Data.SqlClient
Imports System.Configuration
Module conexion
    Public Function sqldb() As SqlConnection
        Return New SqlConnection("Data Source=JLCS\SQLEXPRESS;Initial Catalog=JLOS2;Integrated Security=True")
        'myConn = New SqlConnection("Initial Catalog=Northwind;" & "Data Source=localhost;Integrated Security=SSPI;")
    End Function
    Public con As SqlConnection = sqldb()
    Public Sub conectar()
        Try
            con.Open()

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Public Sub desconectar()
        Try
            If con.State = ConnectionState.Open Then
                con.Close()

            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
End Module
