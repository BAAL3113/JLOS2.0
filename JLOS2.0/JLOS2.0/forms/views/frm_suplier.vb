Public Class frm_suplier
    Dim ID As String = 0
    Dim maxcolumn
    Private Sub btnsave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnsave.Click
        sql = "INSERT INTO tbpersona (CLIENTEPROVEEDORID, NOMBRE, APELLIDOS, DIRECCION, TELEFONO, CELULAR, TIPO)" &
        " VALUES ('" & ID & "','" & txtfname.Text & "','" & txtlname.Text & "','" & txtaddress.Text & "','" & txttelephone.Text & "','" & txtmobile.Text & "','Proveedor')"
        create(sql, txtfname.Text & " " & txtlname.Text, txtfname.Text & " " & txtlname.Text)
        '----------------------------------
        sql = "SELECT * FROM tbpersona WHERE TIPO='Proveedor'"
        reloadDtg(sql, dtglist)
        '---------------------------------
        cleartext(Panel1)
        '----------------------------------
        maxcolumn = dtglist.Columns.Count - 1
        dtglist.Columns(maxcolumn).Visible = False
        dtglist.Columns(0).Visible = False
        '------------------------------------------
        createNoMsg("UPDATE tbautonumber SET END = END + INCREMENT WHERE ID =3")
        '-------------------------------------
        reloadtxt("SELECT CONCAT(INICIO, FIN) FROM tbautonumber WHERE ID = 3")
        ID = dt.Rows(0).Item(0)
    End Sub

    Private Sub btnupdate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnupdate.Click
        sql = "UPDATE tbpersona SET  NOMBRE='" & txtfname.Text & "', APELLIDOS='" & txtlname.Text &
        "', DIRECCION='" & txtaddress.Text & "', TELEFONO='" & txttelephone.Text & "', CELULAR='" & txtmobile.Text & "' WHERE CLIENTEPROVEEDORID='" & ID & "'"
        updates(sql, txtfname.Text & " " & txtlname.Text, txtfname.Text & " " & txtlname.Text)
        '----------------------------------
        sql = "SELECT * FROM tbpersona WHERE TIPO='Proveedor'"
        reloadDtg(sql, dtglist)
        '---------------------------------
        cleartext(Panel1)
        '----------------------------------
        maxcolumn = dtglist.Columns.Count - 1
        dtglist.Columns(maxcolumn).Visible = False
        dtglist.Columns(0).Visible = False
        '-------------------------------------
        reloadtxt("SELECT CONCAT(INICIO, FIN) FROM tbautonumber WHERE ID = 3")
        ID = dt.Rows(0).Item(0)
    End Sub

    Private Sub btndelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btndelete.Click
        sql = "DELETE FROM tbpersona WHERE CLIENTEPROVEEDORID='" & dtglist.CurrentRow.Cells("CLIENTEPROVEEDORID").Value & "'"
        deletes(sql, dtglist.CurrentRow.Cells("CLIENTEPROVEEDORID").Value, dtglist.CurrentRow.Cells("CLIENTEPROVEEDORID").Value)
        '----------------------------------
        sql = "SELECT * FROM tbpersona WHERE TIPO = 'Proveedor'"
        reloadDtg(sql, dtglist)
        '---------------------------------
        cleartext(Panel1)
        '----------------------------------
        maxcolumn = dtglist.Columns.Count - 1
        dtglist.Columns(maxcolumn).Visible = False
        dtglist.Columns(0).Visible = False
        '-------------------------------------
        reloadtxt("SELECT CONCAT(INICIO, FIN) FROM tbautonumber WHERE ID = 3")
        ID = dt.Rows(0).Item(0)

    End Sub

    Private Sub txtsearch_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtsearch.TextChanged
        sql = "SELECT * FROM tbpersona WHERE TIPO='Proveedor' AND CLIENTEPROVEEDORID LIKE '%" & txtsearch.Text & "%'"
        reloadDtg(sql, dtglist)
        '----------------------------------
        cleartext(Panel1)
        '----------------------------------
        maxcolumn = dtglist.Columns.Count - 1
        dtglist.Columns(maxcolumn).Visible = False
        dtglist.Columns(0).Visible = False
        '-------------------------------------
        reloadtxt("SELECT CONCAT(INICIO, FIN) FROM tbautonumber WHERE ID = 3")
        ID = dt.Rows(0).Item(0)
    End Sub

    Private Sub frm_customer_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        '----------------------------------
        sql = "SELECT * FROM tbpersona WHERE TIPO='Proveedor'"
        reloadDtg(sql, dtglist)
        '---------------------------------
        cleartext(Panel1)
        '----------------------------------
        maxcolumn = dtglist.Columns.Count - 1
        dtglist.Columns(maxcolumn).Visible = False
        dtglist.Columns(0).Visible = False
        '-------------------------------------
        reloadtxt("SELECT CONCAT(INICIO, FIN) FROM tbautonumber WHERE ID = 3")
        ID = dt.Rows(0).Item(0)
        MsgBox(ID)
    End Sub

    Private Sub btnclear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnclear.Click
        '----------------------------------
        sql = "SELECT * FROM tbpersona WHERE TIPO='Proveedor'"
        reloadDtg(sql, dtglist)
        '---------------------------------
        cleartext(Panel1)
        '----------------------------------
        maxcolumn = dtglist.Columns.Count - 1
        dtglist.Columns(maxcolumn).Visible = False
        dtglist.Columns(0).Visible = False
        '-------------------------------------
        reloadtxt("SELECT CONCAT(INICIO, FIN) FROM tbautonumber WHERE ID = 3")
        ID = dt.Rows(0).Item(0)
        MsgBox(ID)
    End Sub

    Private Sub dtglist_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles dtglist.DoubleClick
        Try
            ID = dtglist.CurrentRow.Cells(1).Value
            reloadtxt("SELECT * FROM tbpersona WHERE TIPO='Proveedor' AND CLIENTEPROVEEDORID ='" & dtglist.CurrentRow.Cells(1).Value & "'")
            txtfname.Text = dt.Rows(0).Item("NOMBRE")
            txtlname.Text = dt.Rows(0).Item("APELLIDOS")
            txtaddress.Text = dt.Rows(0).Item("DIRECCION")
            txttelephone.Text = dt.Rows(0).Item("TELEFONO")
            txtmobile.Text = dt.Rows(0).Item("CELULAR")
        Catch ex As Exception
            MsgBox("Accion no valida.", MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub btnadd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnadd.Click
        frm_transaction.txt_suplierId.Text = dtglist.CurrentRow.Cells(1).Value
        Me.Close()
    End Sub
End Class