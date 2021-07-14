Imports System.Data.SqlClient
Imports System.Data
Imports System

Public Class frm_customer
    Dim ID As String = 0
    Dim maxcolumn
    Private Sub btnsave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnsave.Click

        If txtaddress.Text = "" Or txtfname.Text = "" Or txtlname.Text = "" Or txtmobile.Text = "" And txttelephone.Text = "" Then
            MsgBox("Se necesita llenar todos los campos.", MsgBoxStyle.Exclamation)
            Exit Sub
        End If
        'For Each txt As Control In Panel1.Controls
        '    'If txt.GetType Is GetType(TextBox) Then
        '    '    If txt.Text = "" Then
        '    '        MsgBox("Reaquired to fill up all the empty fields.", MsgBoxStyle.Exclamation)
        '    '        Exit Sub
        '    '    End If
        '    'End If
        '    If txt.GetType Is GetType(RichTextBox) Then
        '        If txt.Text = "" Then
        '            MsgBox("Reaquired to fill up all the empty fields.", MsgBoxStyle.Exclamation)
        '            Exit Sub
        '        End If
        '    End If
        'Next
        sql = "INSERT INTO tbpersona (ID,CLIENTEPROVEEDORID, NOMBRE, APELLIDOS, DIRECCION, TELEFONO, CELULAR, TIPO)" &
        " VALUES ('" & txtID.Text & "','" & txtcusid.Text & "','" & txtfname.Text & "','" & txtlname.Text & "','" & txtaddress.Text & "','" & txttelephone.Text & "','" & txtmobile.Text & "','cliente')"
        create(sql, txtfname.Text & " " & txtlname.Text, txtfname.Text & " " & txtlname.Text)
        '----------------------------------
        sql = "SELECT * FROM tbpersona WHERE TIPO ='Cliente'"
        reloadDtg(sql, dtglist)
        '---------------------------------
        cleartext(Panel1)
        '----------------------------------
        maxcolumn = dtglist.Columns.Count - 1
        dtglist.Columns(maxcolumn).Visible = False
        dtglist.Columns(0).Visible = False
        '------------------------------------------
        createNoMsg("UPDATE tbautonumber SET FIN = FIN + INCREMENT WHERE ID =1")
        '-------------------------------------
        'reloadtxt("SELECT CONCAT(INICIO, FIN) FROM tbautonumber WHERE ID = 1")
        'txtcusid.Text = dt.Rows(0).Item(0)

        Call save_or_update(sql, add, edit)
        Call btnclear_Click(sender, e)
    End Sub

    Private Sub btnupdate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnupdate.Click
        For Each txt As Control In Panel1.Controls
            If txt.GetType Is GetType(TextBox) Then
                If txt.Text = "" Then
                    MsgBox("Se requiere llenar todos los campos.", MsgBoxStyle.Exclamation)
                    Exit Sub
                End If
            End If
            If txt.GetType Is GetType(RichTextBox) Then
                If txt.Text = "" Then
                    MsgBox("Se requiere llenar todos los campos.", MsgBoxStyle.Exclamation)
                    Exit Sub
                End If
            End If
        Next

        sql = "UPDATE tbpersona SET     NOMBRE='" & txtfname.Text & "', APELLIDOS='" & txtlname.Text &
        "', DIRECCION='" & txtaddress.Text & "', TELEFONO='" & txttelephone.Text & "', CELULAR='" & txtmobile.Text & "' WHERE ID='" & txtcusid.Text & "'"
        updates(sql, txtfname.Text & " " & txtlname.Text, txtfname.Text & " " & txtlname.Text)
        '----------------------------------
        sql = "SELECT * FROM tbpersona WHERE TIPO ='Cliente'"
        reloadDtg(sql, dtglist)
        '---------------------------------
        cleartext(Panel1)
        '----------------------------------
        maxcolumn = dtglist.Columns.Count - 1
        dtglist.Columns(maxcolumn).Visible = False
        dtglist.Columns(0).Visible = False
        '-------------------------------------
        reloadtxt("SELECT CONCAT(INICIO, FIN) FROM tbautonumber WHERE ID = 1")
        ID = dt.Rows(0).Item(0)
    End Sub

    Private Sub btnborrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnborrar.Click
        Try
            sql = "DELETE FROM tbpersona WHERE ID='" & dtglist.CurrentRow.Cells("ID").Value & "'"
            deletes(sql, dtglist.CurrentRow.Cells("ID").Value, dtglist.CurrentRow.Cells("ID").Value)
            '----------------------------------
            sql = "SELECT * FROM tbpersona WHERE TIPO ='cliente'"
            reloadDtg(sql, dtglist)
            '---------------------------------
            cleartext(Panel1)
            '----------------------------------
            maxcolumn = dtglist.Columns.Count - 1
            dtglist.Columns(maxcolumn).Visible = False
            dtglist.Columns(0).Visible = False
            '-------------------------------------
            reloadtxt("SELECT CONCAT(INICIO, FIN) FROM tbautonumber WHERE ID = 1")
            txtcusid.Text = dt.Rows(0).Item(0)
        Catch ex As Exception
            MsgBox("Accion no valida", MsgBoxStyle.Exclamation)
        End Try


    End Sub

    Private Sub txtsearch_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtsearch.TextChanged
        sql = "SELECT * FROM tbpersona WHERE TIPO ='cliente' AND  ID LIKE '%" & txtsearch.Text & "%'"
        reloadDtg(sql, dtglist)
        '---------------------------------- 
        cleartext(Panel1)
        '----------------------------------
        maxcolumn = dtglist.Columns.Count - 1
        dtglist.Columns(maxcolumn).Visible = False
        dtglist.Columns(0).Visible = False
        '-------------------------------------
        'reloadtxt("SELECT CONCAT(INICIO, FIN) FROM tbautonumber WHERE ID = 1")
        'txtcusid.Text = dt.Rows(0).Item(0)


    End Sub

    Private Sub frm_cliente_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        'Dim connectionString As String = "Data Source=.;Initial Catalog=pubs;Integrated Security=True"
        'Dim sql As String = "SELECT * FROM Stores"
        'Dim connection As New SqlConnection(connectionString)
        'cmd = New SqlCommand(sql, con)
        'da = New SqlDataAdapter(cmd)
        'sb = New SqlCommandBuilder(da)
        'ds = New DataSet()
        'da.Fill(ds, "Clientes")
        'dt = ds.Tables("Clientes")
        'dtglist.DataSource = ds.Tables("Clientes")
        'dtglist.ReadOnly = True
        'btnsave.Enabled = False
        'dtglist.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        '----------------------------------
        sql = "SELECT * FROM tbpersona WHERE TIPO ='cliente'"
        reloadDtg(sql, dtglist)
        '---------------------------------
        cleartext(Panel1)
        '----------------------------------
        maxcolumn = dtglist.Columns.Count - 1
        dtglist.Columns(maxcolumn).Visible = False
        dtglist.Columns(0).Visible = False
        '-------------------------------------
        'reloadtxt("SELECT CONCAT(INICIO, FIN) FROM tbautonumber WHERE ID = 1")
        'txtcusid.Text = dt.Rows(0).Item(0)
        'MsgBox(ID)
        reloadtxt("SELECT  ID FROM tbpersona WHERE  TIPO ='cliente'")
        select_navigation(sql)
        inc = 0
        maxrows = dtglist.Rows.Count
        lblinc.Text = inc
        lblmax.Text = maxrows
    End Sub

    Private Sub btnclear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnclear.Click
        '----------------------------------
        sql = "SELECT * FROM tbpersona WHERE TIPO ='cliente'"
        reloadDtg(sql, dtglist)
        '---------------------------------
        cleartext(Panel1)
        '----------------------------------
        maxcolumn = dtglist.Columns.Count - 1
        dtglist.Columns(maxcolumn).Visible = False
        dtglist.Columns(0).Visible = False
        '-------------------------------------
        'reloadtxt("SELECT CONCAT(INICIO, FIN) FROM tbautonumber WHERE ID = 1")
        'txtcusid.Text = dt.Rows(0).Item(0)
        'MsgBox(ID)
        reloadtxt("SELECT  ID FROM tbpersona WHERE  TIPO ='Cliente'")
        'select_navigation(sql)
        lblinc.Text = inc
        lblmax.Text = maxrows
    End Sub

    Private Sub dtglist_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles dtglist.DoubleClick
        Try
            txtID.Text = dtglist.CurrentRow.Cells(0).Value
            txtcusid.Text = dtglist.CurrentRow.Cells(1).Value
            reloadtxt("SELECT * FROM tbpersona WHERE ID ='" & dtglist.CurrentRow.Cells(1).Value & "'")
            txtfname.Text = dt.Rows(0).Item("NOMBRE")
            txtlname.Text = dt.Rows(0).Item("APELLIDOS")
            txtaddress.Text = dt.Rows(0).Item("DIRECCION")
            txttelephone.Text = dt.Rows(0).Item("TELEFONO")
            txtmobile.Text = dt.Rows(0).Item("CELULAR")
        Catch ex As Exception
            MsgBox("Accion no valida.", MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub btnagregar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnagregar.Click
        frm_transaction.txt_cusid.Text = dtglist.CurrentRow.Cells(1).Value
        Me.Close()
    End Sub

    Private Sub btnfirst_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnfirst.Click
        sql = "SELECT  ID FROM tbpersona WHERE  TIPO ='Cliente'"
        select_navigation(sql)
        inc = 0
        lblinc.Text = inc + 1
        navagate_records(txtcusid)
    End Sub

    Private Sub btnprev_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnprev.Click
        Try
            sql = "SELECT  ID FROM tbpersona WHERE  TIPO ='Cliente'"
            select_navigation(sql)
            If inc > 0 Then
                inc = 1
                inc = inc - 1
                lblinc.Text = inc + 1
                navagate_records(txtcusid)
            Else
                If inc - 1 Then
                    MsgBox("Primer records", MsgBoxStyle.Information)
                End If
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnnext_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnnext.Click
        Try
            sql = "SELECT  ID FROM tbpersona WHERE  TIPO ='Cliente'"
            select_navigation(sql)
            If inc <> maxrows - 1 Then
                inc = inc + 1
                lblinc.Text = inc + 1
                navagate_records(txtcusid)

            Else
                If inc = maxrows - 1 Then
                    MsgBox("no hay mas lineas.", MsgBoxStyle.Information)
                End If
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnlast_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnlast.Click
        Try
            sql = "SELECT  ID FROM tbpersona WHERE  TIPO ='Cliente'"
            select_navigation(sql)
            If inc <> maxrows - 1 Then
                inc = maxrows - 1
                lblinc.Text = inc + 1
                navagate_records(txtcusid)
                'navagate_records(lblid)
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub txtcusid_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtcusid.TextChanged
        Try

            reloadtxt("SELECT * FROM tbpersona WHERE ID ='" & txtcusid.Text & "'")
            txtfname.Text = dt.Rows(0).Item("NOMBRE")
            txtlname.Text = dt.Rows(0).Item("APELLIDOS")
            txtaddress.Text = dt.Rows(0).Item("DIRECCION")
            txttelephone.Text = dt.Rows(0).Item("TELEFONO")
            txtmobile.Text = dt.Rows(0).Item("CELULAR")
        Catch ex As Exception

        End Try
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Me.Close()
    End Sub
End Class