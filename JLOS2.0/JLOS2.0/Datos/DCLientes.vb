Imports System.Data.SqlClient
Public Class DCLientes
    'Inherits conexion
    'Dim cmd As SqlCommand
    'Dim dt As DataTable
    'Dim da As SqlDataAdapter
    'Dim cb As SqlCommandBuilder
    'Dim ds As DataSet
    Dim con As SqlConnection = sqldb()


    Public Function Mostrar()
        Try
            conectar()
            cmd = New SqlCommand("MOSTRARCLIENTES")
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Connection = con
            If cmd.ExecuteNonQuery Then
                dt = New DataTable
                da = New SqlDataAdapter(cmd)
                da.Fill(dt)
                Return dt
            Else
                Return Nothing

            End If
            'da = New SqlDataAdapter(cmd)
            'cb = New SqlCommandBuilder(da)
            'ds = New DataSet()
            da.Fill(ds, "Clientes")
            dt = ds.Tables("Clientes")

        Catch ex As Exception
            MsgBox(ex.Message)
            Return Nothing
        Finally
            desconectar()

        End Try
    End Function
    Public Function Insertar(ByVal dts As LClientes) As Boolean
        Try
            conectar()
            cmd = New SqlCommand("INSERTARCLIENTES")
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Connection = con
            cmd.Parameters.AddWithValue("@ID", dts.MID_Clientes)
            cmd.Parameters.AddWithValue("@CLIPROID", dts.MClienteProveedorID)
            cmd.Parameters.AddWithValue("@NOM", dts.MNombre)
            cmd.Parameters.AddWithValue("@APE", dts.MApellidos)
            cmd.Parameters.AddWithValue("@DIR", dts.MDireccion)
            cmd.Parameters.AddWithValue("@TEL", dts.MTelefono)
            cmd.Parameters.AddWithValue("@CEL", dts.MCelular)
            cmd.Parameters.AddWithValue("@TIPO", dts.MTipo)
            cmd.Parameters.AddWithValue("@ITEMNOM", dts.MItemNombre)
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
    Public Function EditarClientes(ByVal dts As LClientes) As Boolean
        Try
            conectar()
            cmd = New SqlCommand("EDITARCLIENTES", con)
            cmd.CommandType = CommandType.StoredProcedure
            With cmd.Parameters
                .AddWithValue("@ID", dts.MID_Clientes)
                .AddWithValue("@CLIPROID", dts.MClienteProveedorID)
                .AddWithValue("@NOM", dts.MNombre)
                .AddWithValue("@APE", dts.MApellidos)
                .AddWithValue("@DIR", dts.MDireccion)
                .AddWithValue("@TEL", dts.MTelefono)
                .AddWithValue("@CEL", dts.MCelular)
                .AddWithValue("@TIPO", dts.MTipo)
                .AddWithValue("@ITEMNOM", dts.MItemNombre)
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
    Public Function EliminarCliente(ByVal dts As LClientes) As Boolean
        Try
            conectar()
            cmd = New SqlCommand("ELIMINARCLIENTE")
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Connection = con
            cmd.Parameters.Add("@ID", SqlDbType.Int).Value = dts.MID_Clientes
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
