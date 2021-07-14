Imports System.Data.SqlClient
Imports System.Data
Imports System
Public Class frm_settings
    Dim typeid As Integer = 0
    Dim unitid As Integer = 0
    Private Sub btnTypesave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnTypesave.Click
        sql = "INSERT INTO tbsettings (ID,DESCRIPCION,PARA) VALUES ('" & txtIDCategoria.Text & "','" & txtCategory.Text & "','Categoria')"
        create(sql, txtCategory.Text, txtCategory.Text)

        'sql = "INSERT INTO tbautonumber (INICIO,FIN,INCREMENTO,DESCRIPCION)" &
        '   " VALUES ('" & txtCategory.Text.Substring(0, 1) & "0000" & "',1,1,'" & txtCategory.Text & "')"
        'createNoMsg(sql)

        txtCategory.Clear()
        sql = "SELECT ID, DESCRIPCION as 'Categoria' FROM tbsettings WHERE PARA='Categoria'"
        reloadDtg(sql, dtgtypelist)
        dtgtypelist.Columns(0).Visible = False
    End Sub

    Private Sub btntypeLoad_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btntypeLoad.Click
        sql = "SELECT ID, DESCRIPCION as 'Categoria' FROM tbsettings WHERE PARA='Categoria'"
        reloadDtg(sql, dtgtypelist)
        dtgtypelist.Columns(0).Visible = False

        txtCategory.Clear()


    End Sub

    Private Sub dtgtypelist_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles dtgtypelist.DoubleClick
        txtCategory.Text = dtgtypelist.CurrentRow.Cells(1).Value
        txtIDCategoria.Text = dtgtypelist.CurrentRow.Cells(0).Value
        typeid = dtgtypelist.CurrentRow.Cells(0).Value
    End Sub

    Private Sub btntypeupdate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btntypeupdate.Click
        sql = "UPDATE tbsettings  SET DESCRIPCION= '" & txtCategory.Text & "' WHERE ID ='" & typeid & "'"
        updates(sql, txtCategory.Text, txtCategory.Text)
        sql = "SELECT ID, DESCRIPCION as 'Categoria' FROM tbsettings WHERE PARA='Categoria'"
        reloadDtg(sql, dtgtypelist)
        dtgtypelist.Columns(0).Visible = False
        txtCategory.Clear()
    End Sub

    Private Sub btnuload_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnuload.Click
        sql = "SELECT ID, DESCRIPCION as 'Unidad' FROM tbsettings WHERE PARA='Unidad'"
        reloadDtg(sql, dtgulist)
        dtgulist.Columns(0).Visible = False
        txtunit.Clear()
    End Sub

    Private Sub btnusave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnusave.Click
        sql = "INSERT INTO tbsettings (ID,DESCRIPCION,PARA) VALUES ('" & txtIDItemUnit.Text & "','" & txtunit.Text & "','Unidad')"
        create(sql, txtunit.Text, txtunit.Text)
        txtunit.Clear()
        sql = "SELECT ID, DESCRIPCION as 'Item Unit' FROM tbsettings WHERE PARA='Unidad'"
        reloadDtg(sql, dtgulist)
        dtgulist.Columns(0).Visible = False
    End Sub

    Private Sub btnuupdate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnuupdate.Click
        sql = "UPDATE tbsettings  SET DESCRIPCION= '" & txtCategory.Text & "' WHERE ID ='" & unitid & "'"
        updates(sql, txtunit.Text, txtunit.Text)
        sql = "SELECT ID, DESCRIPCION as 'Item Unit' FROM tbsettings WHERE PARA='Unidad'"
        reloadDtg(sql, dtgulist)
        dtgulist.Columns(0).Visible = False
        txtunit.Clear()
    End Sub


    Private Sub dtgulist_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles dtgulist.DoubleClick
        txtunit.Text = dtgulist.CurrentRow.Cells(1).Value
        txtIDItemUnit.Text = dtgulist.CurrentRow.Cells(0).Value
        unitid = dtgulist.CurrentRow.Cells(0).Value
    End Sub

    Private Sub frm_settings_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'For Each dtg As Control In Me.Controls
        '    If TypeOf dtg Is DataGridView Then

        '        For Each r As DataGridViewRow In dtg.rows


        '        Next
        '    End If
        'Next
        dtgtypelist.DefaultCellStyle.ForeColor = Color.Black
        dtgulist.DefaultCellStyle.ForeColor = Color.Black
    End Sub

    Private Sub btncdel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btncdel.Click
        sql = "DELETE FROM tbautonumber WHERE ID='" & dtgtypelist.CurrentRow.Cells(0).Value & "'"
        createNoMsg(sql)
        sql = "DELETE FROM tbsettings WHERE ID='" & dtgtypelist.CurrentRow.Cells(0).Value & "'"
        deletes(sql, txtCategory.Text, txtCategory.Text)
    End Sub

    Private Sub btnunit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnunit.Click
        sql = "DELETE FROM tbsettings WHERE ID='" & dtgulist.CurrentRow.Cells(0).Value & "'"
        deletes(sql, txtCategory.Text, txtCategory.Text)
    End Sub
End Class