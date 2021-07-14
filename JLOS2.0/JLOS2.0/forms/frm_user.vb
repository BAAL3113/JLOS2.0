Imports System.Data.SqlClient

Public Class frm_user
    Private Sub frm_adduser_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            cbo_type.Text = "Administrador"
            reloadDtg("Select USUARIO_ID as 'ID' ,NOMBRE as 'Nombre',NOMBRE_USUARIO as 'Nombreusuario',TIPO as 'Tipo' From tbusuario", dtg_listUser)
            dtg_listUser.Columns(0).Visible = False
            If lbl_id.Text = "id" Then

                btn_update.Enabled = False
                btn_delete.Enabled = False
                btn_saveuser.Enabled = True

            Else
                btn_saveuser.Enabled = False
                btn_update.Enabled = True
                btn_delete.Enabled = True
            End If


        Catch ex As Exception
            ' MsgBox(ex.Message)
        End Try

    End Sub

    Private Sub btn_close_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_New.Click
        lbl_id.Text = "id"
        Call frm_adduser_Load(sender, e)
        'cleartext(grp_user)
    End Sub

    Private Sub btn_saveuser_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_saveuser.Click
        'Dim dts As New LUsuario
        'wrapper = New codificacion(txt_pass.Text)
        'Dim Ciphertext As String = wrapper.EncryptData(txt_pass.Text)

        If txt_name.Text = "" Or txt_pass.Text = "" Or txt_username.Text = "" Then
            '   emptymessage()
        Else
            create("insert into tbusuario (USUARIO_ID,NOMBRE,NOMBRE_USUARIO,PASS,TIPO) " _
             & "values('" & txt_ID.Text & "','" & txt_name.Text & "','" & txt_username.Text _
             & "',Convert(VARBINARY(50),'" & txt_pass.Text & "',0),'" & cbo_type.Text _
             & "')", "Usuario", "Usuario")

            Call frm_adduser_Load(sender, e)
            '  cleartext(grp_user)
        End If

    End Sub

    Private Sub btn_update_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_update.Click
        Try
            If txt_name.Text = "" Or txt_pass.Text = "" Or txt_username.Text = "" Then
                '  emptymessage()
            Else
                updates("update tbusuario set NOMBRE = '" & txt_name.Text & "',NOMBRE_USUARIO= '" & txt_username.Text _
                            & "',PASS=Convert(VARBINARY(50),'" & txt_pass.Text & "',0),TIPO= '" & cbo_type.Text _
                            & "' where USUARIO_ID = " & lbl_id.Text, "Usuario", "Usuario")
                Call frm_adduser_Load(sender, e)
                '  cleartext(grp_user)
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub
    Private Sub btn_delete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_delete.Click
        Try
            deletes("delete from tbusuario where USUARIO_ID = '" & lbl_id.Text & "'", "Usuario", "Usuario")
            'Call frm_adduser_Load(sender, e)
            '  cleartext(grp_user)
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub dtg_listUser_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles dtg_listUser.DoubleClick
        Try
            With dtg_listUser.CurrentRow
                lbl_id.Text = .Cells(0).Value
                txt_ID.Text = .Cells(0).Value
                txt_name.Text = .Cells(1).Value
                txt_username.Text = .Cells(2).Value
                cbo_type.Text = .Cells(3).Value
            End With
        Catch ex As Exception

        End Try
    End Sub



    Private Sub lbl_id_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles lbl_id.TextChanged
        Try
            If lbl_id.Text = "id" Then

                btn_update.Enabled = False
                btn_delete.Enabled = False
                btn_saveuser.Enabled = True

            Else
                btn_saveuser.Enabled = False
                btn_update.Enabled = True
                btn_delete.Enabled = True
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Me.Close()
    End Sub
End Class