﻿Public Class frm_StockMaster
    Dim itemid As Integer
    Dim maxcolumn As Integer
    Private Sub btnsave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnsave.Click

        For Each obj As Control In pnl_stockmaster.Controls
            If TypeOf obj Is TextBox Then
                If obj.Text = "" Then
                    MsgBox("No se puede hacer la accion. Todos los campos deben estar llenos.", MsgBoxStyle.Exclamation)
                    Exit Sub
                End If
            End If
            If TypeOf obj Is ComboBox Then
                If obj.Text = "----Seleccionar----" Or obj.Text = "" Then
                    MsgBox("No se puede hacer la accion. Todos los campos deben estar llenos.", MsgBoxStyle.Exclamation)
                    Exit Sub
                End If
            End If
        Next


        'sql = "INSERT INTO  tbstock_in_out (ITEMID, CANTIDAD,FECHATRANSACCION, PRECIOTOTAL, REMARKS)" &
        '   " VALUES ('" & txtitemid.Text & "','" & txtqty.Text & "','" & Format(Now, "yyyy-MM-dd") & "','" & txtprice.Text &
        '   "','StockIn')"
        'createNoMsg(sql)


        sql = "SELECT ITEMID FROM tbitems WHERE ITEMID='" & txtitemid.Text & "'"
        reloadtxt(sql)
        If dt.Rows.Count > 0 Then
            sql = "UPDATE tbitems SET CANTIDAD =CANTIDAD + '" & txtqty.Text & "' WHERE ITEMID ='" & txtitemid.Text & "'"
            createNoMsg(sql)

            MsgBox(txtname.Text & " ha sido salvado a la base de datos.")

        Else
            sql = "insert into tbitems  (ITEMID,NOMBRE, DESCRIPCION, TIPO, PRECIOCOMPRA, PRECIOVENTA, CANTIDAD,UNIT)" &
           "VALUES ('" & txtitemid.Text & "','" & txtname.Text & "','" & txtdescription.Text & "','" & cbotype.Text _
           & "','" & txtprice.Text & "','" & txtSellprice.Text & "','" & txtqty.Text & "','" & cbounit.Text & "' )"
            create(sql, txtname.Text, txtname.Text)
            updateautonumber(cbotype.Text)
        End If


        '--------------------------------------
        sql = "SELECT * FROM tbitems"
        reloadDtg(sql, dtglist)
        '------------------------------------------
        cleartext(pnl_stockmaster)
        '--------------------------------------
        maxcolumn = dtglist.Columns.Count - 1
        dtglist.Columns(maxcolumn).Visible = True

        dtgcolor(dtglist, 5)
        ' loadautonumber("itemid", txtitemid)
    End Sub

    Private Sub frm_stockmaster_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load


        sql = "SELECT * FROM tbitems"
        reloadDtg(sql, dtglist)
        '------------------------------------------
        dtgcolor(dtglist, 5)
        '------------------------------
        fillcbo("SELECT * FROM tbsettings WHERE PARA='Categoria'", cbotype)
        fillcbo("SELECT * FROM tbsettings WHERE PARA='Unidad'", cbounit)
        '-------------------------
        cleartext(pnl_stockmaster)
        '--------------------------------------
        maxcolumn = dtglist.Columns.Count - 1
        dtglist.Columns(maxcolumn).Visible = True
        '------------------------------------------
        btnadd.Visible = False

        ' loadautonumber("itemid", txtitemid)

        select_navigation("SELECT ITEMID FROM tbitems")
        lblmax.Text = maxrows
        lblinc.Text = inc
    End Sub

    Private Sub btndelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btndelete.Click
        Try
            sql = "DELETE FROM tbitems WHERE ITEMID='" & dtglist.CurrentRow.Cells(0).Value & "'"
            deletes(sql, "Item", "Item")
            '--------------------------------------
            sql = "SELECT * FROM tbitems"
            reloadDtg(sql, dtglist)
            '------------------------------------------
            cleartext(pnl_stockmaster)
            '--------------------------------------
            maxcolumn = dtglist.Columns.Count - 1
            dtglist.Columns(maxcolumn).Visible = True
            ' loadautonumber("itemid", txtitemid)
        Catch ex As Exception
            MsgBox("Accion invalida.", MsgBoxStyle.Exclamation)
        End Try


    End Sub

    Private Sub btnupdate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnupdate.Click
        sql = "UPDATE tbitems SET NOMBRE='" & txtname.Text & "', DESCRIPCION='" & txtdescription.Text & "', TIPO='" & cbotype.Text & "', PRECIOCOMPRA='" & txtprice.Text & "',PRECIOVENTA'" & txtSellprice.Text & "'" &
            ",UNIT='" & cbounit.Text & "' WHERE ITEMID='" & txtitemid.Text & "'"
        updates(sql, txtname.Text, txtname.Text)
        '--------------------------------------
        sql = "SELECT * FROM tbitems"
        reloadDtg(sql, dtglist)
        '------------------------------------------
        cleartext(pnl_stockmaster)
        '--------------------------------------
        maxcolumn = dtglist.Columns.Count - 1
        dtglist.Columns(maxcolumn).Visible = True
        'loadautonumber("itemid", txtitemid)
        dtgcolor(dtglist, 5)
    End Sub

    Private Sub btnnew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnnew.Click
        sql = "SELECT * FROM tbitems"
        reloadDtg(sql, dtglist)
        '------------------------------------------
        dtgcolor(dtglist, 5)
        '------------------------------------------
        cleartext(pnl_stockmaster)
        '--------------------------------------
        maxcolumn = dtglist.Columns.Count - 1
        dtglist.Columns(maxcolumn).Visible = True
        ' loadautonumber("itemid", txtitemid)
    End Sub

    Private Sub dtglist_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtglist.DoubleClick
        Try

            sql = "SELECT * FROM tbitems WHERE ITEMID='" & dtglist.CurrentRow.Cells(0).Value & "'"
            reloadtxt(sql)
            txtitemid.Text = dt.Rows(0).Item("ITEMID")
            txtname.Text = dt.Rows(0).Item("NOMBRE")
            txtdescription.Text = dt.Rows(0).Item("DESCRIPCION")
            txtprice.Text = dt.Rows(0).Item("PRECIOCOMPRA")
            txtSellprice.Text = dt.Rows(0).Item("PRECIOVENTA")
            cbotype.Text = dt.Rows(0).Item("TIPO")
            txtqty.Text = dt.Rows(0).Item("CANTIDAD")
            cbounit.Text = dt.Rows(0).Item("UNIT")
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub txtsearch_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtsearch.TextChanged
        sql = "SELECT * FROM tbitems WHERE ITEMID LIKE '%" & txtsearch.Text & "%' OR NOMBRE LIKE '%" & txtsearch.Text & "%'"
        reloadDtg(sql, dtglist)
        '------------------------------------------
        cleartext(pnl_stockmaster)
        '--------------------------------------
        maxcolumn = dtglist.Columns.Count - 1
        dtglist.Columns(maxcolumn).Visible = True

        'loadautonumber("itemid", txtitemid)

    End Sub

    Private Sub btnadd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnadd.Click
        frm_transaction.txtSup_itemid.Text = dtglist.CurrentRow.Cells(0).Value
        Me.Close()
    End Sub

    Private Sub btnfirst_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnfirst.Click
        sql = "SELECT ITEMID FROM tbitems"
        select_navigation(sql)
        inc = 0
        lblinc.Text = inc + 1
        navagate_records(txtitemid)
    End Sub

    Private Sub btnprev_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnprev.Click
        Try
            select_navigation("SELECT ITEMID FROM tbitems")
            If inc > 0 Then
                inc = inc - 1
                lblinc.Text = inc + 1
                navagate_records(txtitemid)
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
            select_navigation("SELECT ITEMID FROM tbitems")
            If inc <> maxrows - 1 Then
                inc = inc + 1
                lblinc.Text = inc + 1
                navagate_records(txtitemid)

            Else
                If inc = maxrows - 1 Then
                    MsgBox("No hay mas lineas", MsgBoxStyle.Information)
                End If
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnlast_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnlast.Click
        Try
            select_navigation("SELECT ITEMID FROM tbitems")
            If inc <> maxrows - 1 Then
                inc = maxrows - 1
                lblinc.Text = inc + 1
                navagate_records(txtitemid)
                'navagate_records(lblid)
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub txtitemid_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtitemid.TextChanged
        Try
            sql = "SELECT * FROM tbitems WHERE ITEMID='" & txtitemid.Text & "'"
            reloadtxt(sql)
            If dt.Rows.Count > 0 Then
                txtname.Text = dt.Rows(0).Item(1)
                txtdescription.Text = dt.Rows(0).Item(2)
                txtprice.Text = dt.Rows(0).Item(4)
                txtSellprice.Text = dt.Rows(0).Item(5)
                cbotype.Text = dt.Rows(0).Item(3)
                txtqty.Text = dt.Rows(0).Item("CANTIDAD")
                cbounit.Text = dt.Rows(0).Item("UNIT")
            End If


        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Me.Close()
    End Sub



    Private Sub cbotype_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbotype.SelectedIndexChanged

        Try
            sql = "SELECT * FROM tbitems WHERE ITEMID='" & txtitemid.Text & "'"
            reloadtxt(sql)
            If dt.Rows.Count > 0 Then
                txtname.Text = dt.Rows(0).Item(1)
            Else
                loadautonumber(cbotype.Text, txtitemid)

            End If
        Catch ex As Exception

        End Try


    End Sub
End Class