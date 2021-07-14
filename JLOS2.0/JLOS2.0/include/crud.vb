Imports System.Data.SqlClient
Imports System.Data
Imports System
Module crud
    Public con As SqlConnection = sqldb()
    Public cmd As New SqlCommand
    Public da As New SqlDataAdapter
    Public dt As New DataTable
    Public ds As New DataSet
    Public sb As New SqlCommandBuilder
    Public sql As String
    Public result As String
    Public add As String
    Public edit As String
#Region "old crud"
    Public Sub save_or_update(ByVal sql As String, ByVal add As String, ByVal edit As String)
        conectar()
        With cmd
            .Connection = con
            .CommandText = sql
        End With
        dt = New DataTable
        da = New SqlDataAdapter(sql, con)
        da.Fill(dt)
        con.Close()
        If dt.Rows.Count > 0 Then

            conectar()
            With cmd
                .Connection = con
                .CommandText = edit
                result = cmd.ExecuteNonQuery

            End With
            desconectar()
        Else
            desconectar()
            With cmd
                .Connection = con
                .CommandText = add
                result = cmd.ExecuteNonQuery

            End With
        End If
        desconectar()
    End Sub

    Public Sub createNoMsg(ByVal sql As String)
        Try
            con.Open()
            With cmd
                .Connection = con
                .CommandText = sql
                cmd.ExecuteNonQuery()

            End With
            con.Close()
        Catch ex As Exception
            MsgBox(ex.Message & "createNoMsg")
        End Try

    End Sub
    Public Sub create(ByVal sql As String, ByVal msgsuccess As String, ByVal msgerror As String)
        Try
            con.Open()
            With cmd
                .Connection = con
                .CommandText = sql
                result = cmd.ExecuteNonQuery
                If result = 0 Then
                    MsgBox(msgerror & " fallo en ser salvado en la base de datos ", MsgBoxStyle.Information)
                Else
                    MsgBox(msgsuccess & " a sido salvado en la base de datos")
                End If
            End With

        Catch ex As Exception
            MsgBox(ex.Message & " create")
        End Try
        con.Close()
    End Sub
    Public Sub reloadDtg(ByVal sql As String, ByVal dtg As DataGridView)
        Try
            conectar()
            With cmd
                .Connection = con
                .CommandText = sql
            End With
            dt = New DataTable
            da = New SqlDataAdapter(sql, con)
            da.Fill(dt)
            dtg.DataSource = dt
        Catch ex As Exception
            MsgBox(ex.Message & "reloadDtg")
        End Try

        desconectar()
        da.Dispose()
    End Sub
    Public Sub reloadtxt(ByVal sql As String)
        Try
            conectar()
            With cmd
                .Connection = con
                .CommandText = sql
            End With
            dt = New DataTable
            da = New SqlDataAdapter(sql, con)
            da.Fill(dt)

        Catch ex As Exception
            MsgBox(ex.Message & "reloadtxt")
        End Try

        desconectar()
        da.Dispose()
    End Sub
    Public Sub updates(ByVal sql As String, ByVal msgsuccess As String, ByVal msgerror As String)
        Try
            con.Open()
            cmd = New SqlCommand
            With cmd
                .Connection = con
                .CommandText = sql
                result = cmd.ExecuteNonQuery
                If result = 0 Then
                    MsgBox(msgerror & " fallo de ser actualizado de la base de datos.", MsgBoxStyle.Information)
                Else
                    MsgBox(msgsuccess & " fue actualizado en la base de datos.")
                End If
            End With
            con.Close()
        Catch ex As Exception
            MsgBox(ex.Message & "actualizaciones")
        End Try

    End Sub
    Public Sub deletes(ByVal sql As String, ByVal msgsuccess As String, ByVal msgerror As String)
        Try
            con.Open()
            With cmd
                .Connection = con
                .CommandText = sql
            End With
            'If MessageBox.Show("Do you want to delete this rocord?", "Delete" _
            '                     , MessageBoxButtons.YesNo, MessageBoxIcon.Information) _
            '                     = Windows.Forms.DialogResult.Yes Then
            result = cmd.ExecuteNonQuery
            If result = 0 Then
                MsgBox(msgerror & " fallo en ser borrado de la base de datos.")
            Else
                MsgBox(msgsuccess & " fue borrado de la base de datos.")
            End If
            'End If
            con.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

#End Region
End Module
