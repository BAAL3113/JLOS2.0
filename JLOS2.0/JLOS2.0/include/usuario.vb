Imports System.Data.SqlClient
Module usuario
    Public con As SqlConnection = sqldb()

    Public Sub login(ByVal username As Object, ByVal pass As Object)
        Try

            con.Open()
            reloadtxt("SELECT * FROM tbusuario WHERE NOMBRE_USUARIO= '" & username.text & "' and PASS = ('" & pass.text & "')")


            If dt.Rows.Count > 0 Then
                If dt.Rows(0).Item("TIPO") = "Administrador" Then
                    MsgBox("Bienvenido " & dt.Rows(0).Item("TIPO"))
                    enable_disable(True)

                    With Form1
                        .ts_Login.Text = "LOGOUT"
                        .ts_Login.Image = My.Resources.logout
                        LoginForm1.Close()
                    End With
                ElseIf dt.Rows(0).Item("TIPO") = "Staff" Then
                    MsgBox("Bienvenido " & dt.Rows(0).Item("TIPO"))
                    enable_disable(True)
                    With Form1
                        .ts_Login.Text = "LOGOUT"
                        .ts_Login.Image = My.Resources.logout
                        LoginForm1.Close()
                    End With
                End If

            Else
                MsgBox("La cuenta no existe!", MsgBoxStyle.Information)
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        con.Close()
        da.Dispose()
    End Sub

    Public Sub append(ByVal sql As String, ByVal field As String, ByVal txt As Object)
        reloadtxt(sql)
        Try
            Dim r As DataRow
            txt.AutoCompleteCustomSource.Clear()
            For Each r In dt.Rows
                txt.AutoCompleteCustomSource.Add(r.Item(field).ToString)
            Next
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try


    End Sub

End Module
