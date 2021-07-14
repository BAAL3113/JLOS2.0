Imports System.Data.SqlClient
Public Class DUsuario
    Dim con As SqlConnection = sqldb()
    Dim cmd As New SqlCommand
    Public Function Mostrar() As DataTable
        Try
            conectar()
            cmd = New SqlCommand("MOSTRARUSUARIO")
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Connection = con
            If cmd.ExecuteNonQuery Then
                Dim dt As New DataTable
                Dim da As New SqlDataAdapter(cmd)
                da.Fill(dt)
                Return dt
            Else
                Return Nothing
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
            Return Nothing
            desconectar()

        End Try
    End Function
    Public Function Insertar(ByVal dts As LUsuario) As Boolean
        Try
            conectar()
            cmd = New SqlCommand("INSERTARUSUARIO")
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Connection = con
            With cmd.Parameters
                .AddWithValue("@USUARIO_ID", dts.MID)
                .AddWithValue("@NOMBRE", dts.Mnombre)
                .AddWithValue("@NOMBRE_USUARIO", dts.MNombreUsuario)
                .AddWithValue("@PASS", dts.MPass)
                .AddWithValue("@TIPO", dts.Mtipo)
            End With
            If cmd.ExecuteNonQuery Then
                Return True
            Else
                Return False
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
            Return False
        Finally
            desconectar()
        End Try
    End Function
    Public Function Validar_Usuario(ByVal dts As LUsuario) As Boolean
        Try
            conectar()
            cmd = New SqlCommand("ACCEDERUSUARIO")
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Connection = con
            With cmd.Parameters
                .AddWithValue("@NOMBRE_USUARIO", dts.MNombreUsuario)
                .AddWithValue("@PASS", dts.MPass)
            End With
            Dim dr As SqlDataReader
            dr = cmd.ExecuteReader
            If dr.HasRows Then
                Return True
            Else
                Return False
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
            Return False
        Finally
            desconectar()
        End Try
    End Function
    Public Function Verificar_Usuario(ByVal dts As LUsuario) As Boolean
        Try
            conectar()
            cmd = New SqlCommand("VERIFICARUSUARIO")
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Connection = con
            With cmd.Parameters
                .AddWithValue("@USUARIO_ID", dts.MID)

            End With
            Dim dr As SqlDataReader
            dr = cmd.ExecuteReader
            If dr.HasRows Then
                Return True
            Else
                Return False
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
            Return False
        Finally
            desconectar()

        End Try
    End Function
    Public Function Editar(ByVal dts As LUsuario) As Boolean
        Try
            conectar()
            cmd = New SqlCommand("EDITARUSUARIO")
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Connection = con
            With cmd.Parameters
                .AddWithValue("@USUARIO_ID", dts.MID)
                .AddWithValue("@NOMBRE", dts.Mnombre)
                .AddWithValue("@NOMBRE_USUARIO", dts.MNombreUsuario)
                .AddWithValue("@PASS", dts.MPass)
                .AddWithValue("@TIPO", dts.Mtipo)
            End With
            If cmd.ExecuteNonQuery Then
                Return True
            Else
                Return False
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
            Return False
        Finally
            desconectar()
        End Try
    End Function
    Public Function Eliminar(ByVal dts As LUsuario) As Boolean
        Try
            conectar()
            cmd = New SqlCommand("ELIMINARUSUARIO")
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Connection = con
            cmd.Parameters.Add("@USUARIO_ID", SqlDbType.Int).Value = dts.MID
            If cmd.ExecuteNonQuery Then
                Return True
            Else
                Return False

            End If
        Catch ex As Exception
            MsgBox(ex.Message)
            Return False
        Finally
            desconectar()

        End Try
    End Function
End Class
