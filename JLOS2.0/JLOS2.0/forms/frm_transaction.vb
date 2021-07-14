Public Class frm_transaction
    'Dim returnid As Integer
    'Dim stockinID As Integer = 0
    'Dim stockoutID As Integer = 0
    'Dim stockreturnID As Integer = 0
    Private Sub btnproveedor_buscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnproveedor_buscar.Click
        frm_suplier.Show()
        txtproveedorID.Clear()
        frm_suplier.btnadd.Visible = True
    End Sub

    Private Sub btnproducto_buscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnproducto_buscar.Click
        frm_StockMaster.Show()
        frm_StockMaster.btnadd.Visible = True
    End Sub

    Private Sub txtproductoID_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtproductoID.TextChanged
        Try

            sql = "SELECT * FROM tbitems WHERE ITEMID ='" & txtproductoID.Text & "'"
            reloadtxt(sql)
            If dt.Rows.Count > 0 Then
                txtproductoNombre.Text = dt.Rows(0).Item("NOMBRE")
                rtbproducto_descripcion.Text = dt.Rows(0).Item("DESCRIPCION")
                txtprod_preciocompra.Text = dt.Rows(0).Item("PRECIOCOMPRA")
                txtprod_precioventa.Text = dt.Rows(0).Item("PRECIOVENTA")
            Else
                txtproductoNombre.Clear()
                rtbproducto_descripcion.Clear()
                txtprod_preciocompra.Clear()
                txtprodCantidad.Clear()
                txtprod_precioventa.Clear()
                txtProdtotal.Clear()

            End If

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub frm_transaction_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        sql = "SELECT ITEMID as 'Item Id', NOMBRE as 'Nombre', DESCRIPCION as 'Descripcion', PRECIOCOMPRA as 'Precio de la Compra', CANTIDAD as 'Cantidad Disponible',PRECIOVENTA as 'Precio de la Venta' FROM tbitems"
        reloadDtg(sql, dtgCus_itemlist)

        sql = "SELECT ITEMID FROM tbitems"
        autocompletetxt(sql, txtproductoID)
        '------------------------------------auto stock in
        'reloadtxt("SELECT STOCKOUTID FROM tbstock_in_out WHERE ID ='"&dt.Rows(txt) .Item (0)& "')
        'stockinID = dt.Rows(0).Item(0)
        '------------------------------------auto stock out
        'reloadtxt("SELECT concat(INICIO,FIN) FROM tbautonumber WHERE ID = 5")
        'stockoutID = dt.Rows(0).Item(0)
        '------------------------------------auto stock return
        'reloadtxt("Select concat(INICIO,FIN) FROM tbautonumber WHERE ID = 6")
        'stockreturnID = dt.Rows(0).Item(0)

        TabControl1.TabPages.Remove(TabPage1)

    End Sub

    Private Sub txtproveedorID_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtproveedorID.TextChanged
        Try

            sql = "Select * FROM tbpersona WHERE CLIENTEPROVEEDORID ='" & txtproveedorID.Text & "'"
            reloadtxt(sql)
            If dt.Rows.Count > 0 Then
                txtproveedor_nombre.Text = dt.Rows(0).Item("NOMBRE")
                txtproveedor_apellidos.Text = dt.Rows(0).Item("APELLIDOS")

            Else
                txtproveedor_nombre.Clear()
                txtproveedor_apellidos.Clear()

            End If

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub txtprodCantidad_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtprodCantidad.TextChanged
        Try
            txtProdtotal.Text = txtprod_preciocompra.Text * txtprodCantidad.Text
        Catch ex As Exception
            If txtprodCantidad.Text <> "" Then
                MsgBox("Cantidad debe ser un numero.", MsgBoxStyle.Exclamation)
                txtprodCantidad.Text = ""
            Else
                txtProdtotal.Text = 0.0
            End If

        End Try
    End Sub

    Private Sub btnproagregar_carro_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnproagregar_carro.Click
        Try
            If txtprodCantidad.Text <> "" Then

                If dtgLista_pro.RowCount = 0 Then
                    dtgLista_pro.ColumnCount = 6
                    dtgLista_pro.Columns(0).Name = "Item Id"
                    dtgLista_pro.Columns(1).Name = "Nombre Item"
                    dtgLista_pro.Columns(2).Name = "Descripcion"
                    dtgLista_pro.Columns(3).Name = "Precio Compra"
                    dtgLista_pro.Columns(4).Name = "Precio Venta"
                    dtgLista_pro.Columns(5).Name = "Cantidad"
                    dtgLista_pro.Columns(6).Name = "Precio Compra Total"
                    Dim row As String() = New String() {txtproductoID.Text,
                                                        txtproductoNombre.Text,
                                                       rtbproducto_descripcion.Text,
                                                       txtprod_preciocompra.Text,
                                                       txtprod_precioventa.Text,
                                                       txtprodCantidad.Text,
                                                       txtProdtotal.Text}
                    dtgLista_pro.Rows.Add(row)
                    cleartext(GroupBox2)
                    cleartext(GroupBox1)
                Else
                    If dtgLista_pro.CurrentRow.Cells(0).Value <> txtproductoID.Text Then
                        dtgLista_pro.ColumnCount = 6
                        dtgLista_pro.Columns(0).Name = "Item Id"
                        dtgLista_pro.Columns(1).Name = "Nombre Item"
                        dtgLista_pro.Columns(2).Name = "Descripcion"
                        dtgLista_pro.Columns(3).Name = "Precio Compra"
                        dtgLista_pro.Columns(4).Name = "Precio Venta"
                        dtgLista_pro.Columns(5).Name = "Cantidad"
                        dtgLista_pro.Columns(6).Name = "Precio Compra Total"
                        Dim row As String() = New String() {txtproductoID.Text,
                                                            txtproductoNombre.Text,
                                                            rtbproducto_descripcion.Text,
                                                            txtprod_preciocompra.Text,
                                                            txtprod_precioventa.Text,
                                                            txtprodCantidad.Text,
                                                            txtProdtotal.Text}
                        dtgLista_pro.Rows.Add(row)
                        cleartext(GroupBox2)
                        cleartext(GroupBox1)
                    Else
                        MsgBox("Esta articulo ya esta en el carro.", MsgBoxStyle.Exclamation)
                    End If
                End If

            Else
                MsgBox("Tienes que llenar todos los campos.", MsgBoxStyle.Exclamation)
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub btnRemover_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRemover.Click
        Try
            dtgLista_pro.Rows.Remove(dtgLista_pro.CurrentRow)
        Catch ex As Exception

        End Try

    End Sub

    Private Sub btnLimpiar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLimpiar.Click
        dtgLista_pro.Rows.Clear()
    End Sub

    Private Sub btnGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGuardar.Click
        For Each r As DataGridViewRow In dtgLista_pro.Rows
            sql = "INSERT INTO tbstock_in_out ( STOCKOUTID,NUMEROTRANSACCION, ITEMID, FECHATRANSACCION,CANTIDAD, PRECIOTOTAL, CLIENTEPROVEEDORID, REMARKS)" &
            " VALUES ('" & txtStockInpro.Text & "','" & txtnumtransaccion.Text & "','" & r.Cells(0).Value & "','" & Format(Now, "yyyy-MM-dd") & "','" & r.Cells(5).Value &
            "','" & r.Cells(6).Value & "','" & txtproveedorID.Text & "','StockIn')"
            createNoMsg(sql)
            '-----------------------------------------------update item
            sql = "UPDATE tbitems  SET CANTIDAD = CANTIDAD + '" & r.Cells(4).Value & "' WHERE ITEMID='" & r.Cells(0).Value & "'"
            createNoMsg(sql)
        Next
        '-------------------------------------------------insert 
        sql = "INSERT INTO  tbtransaccion (STOCKOUTID,NUMEROTRANSACCION,  FECHATRANSACCION,  TIPO, CLIENTEPROVEEDORID)" &
        " VALUES ('" & txtStockInpro.Text & "','" & Format(Now, "yyyy-MM-dd") & "','StockIn','" & txtproveedorID.Text & "')"
        createNoMsg(sql)
        '-----------------------------------------------update autonumber
        'createNoMsg("UPDATE tbautonumber SET FIN = FIN + INCREMENT WHERE ID = 4")
        '------------------------------------auto stock in
        'reloadtxt("SELECT concat(INICIO,FIN) FROM tbautonumber WHERE ID = 4")
        'stockinID = dt.Rows(0).Item(0)
        '------------------------------------------------------------
        MsgBox("Item(s) se han salvado en la base de datos.")
        '------------------------------------------------------------clearing
        cleartext(Panel4)
        cleartext(GroupBox2)
        cleartext(GroupBox1)
        dtgLista_pro.Rows.Clear()

    End Sub


    Private Sub txt_cusid_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_cusid.TextChanged
        Try
            sql = "SELECT * FROM tbpersona WHERE CLIENTEPROVEEDORID='" & txt_cusid.Text & "'"
            reloadtxt(sql)
            If dt.Rows.Count > 0 Then
                txtCus_fname.Text = dt.Rows(0).Item("NOMBRE")
                txtCus_lname.Text = dt.Rows(0).Item("APELLIDOS")
            Else
                txtCus_fname.Clear()
                txtCus_lname.Clear()
            End If

        Catch ex As Exception

        End Try
    End Sub

    Private Sub txtsearch_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtsearch.TextChanged
        sql = "SELECT ITEMID as 'Item Id', NOMBRE as 'Nombre', DESCRIPCION as 'Descripcion',TIPO as 'Tipo', PRECIOCOMPRA as 'Precio Compra', CANTIDAD as 'Cantidad Disponible', PRECIOVENTA as 'Precio Venta' FROM tbitems WHERE  NOMBRE like '%" & txtsearch.Text & "%' or ITEMID = '" & txtsearch.Text & "'"
        reloadDtg(sql, dtgCus_itemlist)
    End Sub


    Private Sub btncus_search_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btncus_search.Click
        frmview_customer.Show()
        'frmview_customer.btnadd.Visible = True
    End Sub

    Private Sub btnCus_add_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCus_add.Click
        Try
            If dtCus_addedlist.RowCount = 0 Then
                With dtgCus_itemlist.CurrentRow
                    dtCus_addedlist.ColumnCount = 7
                    dtCus_addedlist.Columns(0).Name = "Item Id"
                    dtCus_addedlist.Columns(1).Name = "Nombre Item"
                    dtCus_addedlist.Columns(2).Name = "Descripcion"
                    dtCus_addedlist.Columns(3).Name = "Precio Compra"
                    dtCus_addedlist.Columns(4).Name = "Precio Venta"
                    dtCus_addedlist.Columns(5).Name = "Cantidad"
                    dtCus_addedlist.Columns(6).Name = "Precio Compra Total"

                    Dim tot As Double = Double.Parse(.Cells(3).Value) * 1
                    Dim tot2 As Double = Double.Parse(.Cells(5).Value) * 1
                    Dim row As String() = New String() { .Cells(0).Value,
                                                    .Cells(1).Value,
                                                   .Cells(2).Value,
                                                   .Cells(3).Value,
                                                   .Cells(4).Value,
                                                   1,
                                                   tot2}
                    dtCus_addedlist.Rows.Add(row)

                End With
            Else
                For Each r As DataGridViewRow In dtCus_addedlist.Rows
                    If dtgCus_itemlist.CurrentRow.Cells(0).Value = r.Cells(0).Value Then
                        MsgBox("El Item ya esta en el carro", MsgBoxStyle.Exclamation)
                        Exit Sub
                    End If
                Next
                If dtCus_addedlist.CurrentRow.Cells(0).Value <> dtgCus_itemlist.CurrentRow.Cells(0).Value Then
                    With dtgCus_itemlist.CurrentRow
                        dtCus_addedlist.ColumnCount = 7
                        dtCus_addedlist.Columns(0).Name = "Item Id"
                        dtCus_addedlist.Columns(1).Name = "Nombre Item"
                        dtCus_addedlist.Columns(2).Name = "Descripcion"
                        dtCus_addedlist.Columns(3).Name = "Precio Compra"
                        dtCus_addedlist.Columns(4).Name = "Precio Venta"
                        dtCus_addedlist.Columns(5).Name = "Cantidad"
                        dtCus_addedlist.Columns(6).Name = "Precio Venta Total"
                        Dim tot As Double = Double.Parse(.Cells(3).Value) * 1
                        Dim tot2 As Double = Double.Parse(.Cells(4).Value) * 1
                        Dim row As String() = New String() { .Cells(0).Value,
                                                        .Cells(1).Value,
                                                        .Cells(2).Value,
                                                       .Cells(3).Value,
                                                       .Cells(4).Value,
                                                      1,
                                                       tot2}
                        dtCus_addedlist.Rows.Add(row)

                    End With


                Else
                    MsgBox("El Item ya esta en el carro.", MsgBoxStyle.Exclamation)
                End If
            End If



        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub btnCus_Remove_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCus_Remove.Click
        Try
            dtCus_addedlist.Rows.Remove(dtCus_addedlist.CurrentRow)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnCus_clear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCus_clear.Click
        dtCus_addedlist.Rows.Clear()
    End Sub

    Private Sub btnCus_save_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCus_save.Click

        If txt_cusid.Text = "" Then
            MsgBox("Hay campos vacios tiene que llenarlos!", MsgBoxStyle.Exclamation)
            Return
        End If

        If dtCus_addedlist.RowCount = 0 Then
            MsgBox("Carro vacio!", MsgBoxStyle.Exclamation)
            Return
        End If
        sql = "SELECT ITEMID,CANTIDAD FROM tbitems"
        reloadtxt(sql)
        For Each row As DataRow In dt.Rows
            For i As Integer = 0 To dtCus_addedlist.Rows.Count - 1
                If dtCus_addedlist.Rows(i).Cells(0).Value = row.Item(0) Then
                    MsgBox(row.Item(0))
                    If dtCus_addedlist.Rows(i).Cells(4).Value > row.Item(1) Then
                        MsgBox("La cantidad del Aticulo ( " & dtCus_addedlist.Rows(i).Cells(1).Value & " ) es mayor que la cantidad disponible de ese articulo.", MsgBoxStyle.Exclamation)
                        Exit Sub
                    End If

                End If
                If dtCus_addedlist.Rows(i).Cells(5).Value = "" Then
                    MsgBox("Set your purpose.", MsgBoxStyle.Exclamation)
                    Return
                End If
            Next
        Next

        For Each r As DataGridViewRow In dtCus_addedlist.Rows
            sql = "INSERT INTO tbstock_in_out ( STOCKOUTID,NUMEROTRANSACCION, ITEMID, FECHATRANSACCION,CANTIDAD, PRECIOTOTAL, CLIENTEPROVEEDORID,REMARKS)" &
            " VALUES ('" & txtstockinoutID.Text & "','" & txtnumtransaccion.Text & "','" & r.Cells(0).Value & "','" & Format(Now, "yyyy-MM-dd") & "','" & r.Cells(5).Value &
            "','" & r.Cells(6).Value & "','" & txt_cusid.Text & "','StockOut')"
            createNoMsg(sql)
            '-----------------------------------------------update item
            sql = "UPDATE tbitems  SET CANTIDAD= CANTIDAD - '" & r.Cells(4).Value & "' WHERE ITEMID='" & r.Cells(0).Value & "'"
            createNoMsg(sql)
        Next
        '----------------------------------------------transaction
        sql = "INSERT INTO  tbtransaccion (STOCKOUTID,NUMEROTRANSACCION,  FECHATRANSACCION,  TIPO, CLIENTEPROVEEDORID)" &
       " VALUES ('" & txtstockinoutID.Text & "','" & txtnumtransaccion.Text & "','" & Format(Now, "yyyy-MM-dd") & "','StockOut','" & txt_cusid.Text & "')"
        createNoMsg(sql)
        '-----------------------------------------------update autonumber
        'createNoMsg("UPDATE tbautonumber SET FIN= FIN + INCREMENT WHERE ID = 5")
        '------------------------------------auto stock in
        'reloadtxt("SELECT concat(INICIO,FIN) FROM tbautonumber WHERE ID = 5")
        'stockoutID = dt.Rows(0).Item(0)
        '------------------------------------------------------------
        MsgBox("Item(s) se han salvado en la base de datos.")
        '------------------------------------------------------------clearing
        cleartext(Panel1)
        dtCus_addedlist.Rows.Clear()
        dtgreturn_itemlist.Rows.Clear()
        '----------------------------------------------------------------
        sql = "SELECT ITEMID as 'Item Id', NOMBRE as 'Nombre', DESCRIPCION as 'Descripcion', PRECIOCOMPRA as 'Precio Compra',CANTIDAD as 'Cantidad Disponible',PRECIOVENTA as 'Precio Venta' FROM tbitems"
        reloadDtg(sql, dtgCus_itemlist)
    End Sub

    Private Sub txttransactionid_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txttransactionid.TextChanged
        Try

            If txttransactionid.Text <> "" Then

                sql = "SELECT p.CLIENTEPROVEEDORID, p.NOMBRE, p.APELLIDOS ,DIRECCION FROM  tbtransaccion t, tbpersona  p  WHERE t.CLIENTEPROVEEDORID=p.CLIENTEPROVEEDORID AND STOCKOUTID='" & txttransactionid.Text & "'"
                reloadtxt(sql)
                'returnid = dt.Rows(0).Item("CLIENTEPROVEEDORID")
                txtreturn_name.Text = dt.Rows(0).Item("NOMBRE") & " " & dt.Rows(0).Item("APELLIDOS")
                txtreturn_address.Text = dt.Rows(0).Item("DIRECCION")

                sql = "SELECT   i.ITEMID, NOMBRE, DESCRIPCION, PRECIOCOMPRA,FECHATRANSACCION, o.CANTIDAD, PRECIOTOTAL,STOCKOUTID FROM  tbitems i , tbstock_in_out o WHERE i.ITEMID=o.ITEMID AND STOCKOUTID='" & txttransactionid.Text & "'"
                reloadDtg(sql, dtgreturn_itemlist)
                dtgreturn_itemlist.Columns(7).Visible = False
            Else
                txtreturn_name.Clear()
                txtreturn_address.Clear()
                dtgreturn_itemlist.Columns.Clear()
            End If


        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnreturnadd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnreturnadd.Click
        Try


            If dtgreturn_cart.RowCount = 0 Then
                With dtgreturn_itemlist.CurrentRow
                    dtgreturn_cart.ColumnCount = 9
                    dtgreturn_cart.Columns(0).Name = "Item Id"
                    dtgreturn_cart.Columns(1).Name = "Nombre Item"
                    dtgreturn_cart.Columns(2).Name = "Descripcion"
                    dtgreturn_cart.Columns(3).Name = "Precio Compra"
                    dtgreturn_cart.Columns(4).Name = "Cantidad"
                    dtgreturn_cart.Columns(5).Name = "Precio Venta"
                    dtgreturn_cart.Columns(6).Name = "Precio Venta Total"
                    Dim row As String() = New String() { .Cells(0).Value,
                                                   .Cells(1).Value,
                                                       .Cells(2).Value,
                                                       .Cells(3).Value,
                                                       .Cells(5).Value,
                                                       .Cells(6).Value,
                                                       .Cells(7).Value,
                                                       .Cells(8).Value}
                    dtgreturn_cart.Rows.Add(row)

                End With

            Else
                If dtgreturn_cart.CurrentRow.Cells(0).Value <> dtgreturn_itemlist.CurrentRow.Cells(0).Value Then
                    With dtgreturn_itemlist.CurrentRow
                        dtgreturn_cart.ColumnCount = 9
                        dtgreturn_cart.Columns(0).Name = "Item Id"
                        dtgreturn_cart.Columns(1).Name = "Nombre Item"
                        dtgreturn_cart.Columns(2).Name = "Descripcion"
                        dtgreturn_cart.Columns(3).Name = "Precio Compra"
                        dtgreturn_cart.Columns(4).Name = "Precio Venta"
                        dtgreturn_cart.Columns(5).Name = "Cantidad"
                        dtgreturn_cart.Columns(6).Name = "Precio Venta Total"
                        Dim row As String() = New String() { .Cells(0).Value,
                                                        .Cells(1).Value,
                                                       .Cells(2).Value,
                                                       .Cells(3).Value,
                                                       .Cells(5).Value,
                                                       .Cells(6).Value,
                                                       .Cells(7).Value,
                                                       .Cells(8).Value}
                        dtgreturn_cart.Rows.Add(row)

                    End With


                Else
                    MsgBox("El articulo ya esta en el carro.", MsgBoxStyle.Exclamation)
                End If
            End If



        Catch ex As Exception
            dtgreturn_cart.Columns(8).Visible = False
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub btnreturn_remove_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnreturn_remove.Click
        Try
            dtgreturn_cart.Rows.Remove(dtgreturn_cart.CurrentRow)
        Catch ex As Exception

        End Try

    End Sub

    Private Sub btnreturn_clear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnreturn_clear.Click
        dtgreturn_cart.Columns.Clear()
    End Sub

    Private Sub btnreturn_save_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnreturn_save.Click
        If txttransactionid.Text = "" Then
            MsgBox("Hay campos vacios debe llenarlos!", MsgBoxStyle.Exclamation)
            Return
        End If

        If dtgreturn_cart.RowCount = 0 Then
            MsgBox("¡El carro esta vacio!", MsgBoxStyle.Exclamation)
            Return
        End If
        sql = "SELECT ITEMID,CANTIDAD FROM tbstock_in_out WHERE  STOCKOUTID ='" & txttransactionid.Text & "'"
        reloadtxt(sql)
        For Each row As DataRow In dt.Rows
            For i As Integer = 0 To dtgreturn_cart.Rows.Count - 1
                If dtgreturn_cart.Rows(i).Cells(0).Value = row.Item(0) Then
                    MsgBox(row.Item(0))
                    If dtgreturn_cart.Rows(i).Cells(4).Value > row.Item(1) Then
                        MsgBox("La cantidad del Articulo ( " & dtgreturn_cart.Rows(i).Cells(1).Value & " ) es mayor de lo disponible.", MsgBoxStyle.Exclamation)
                        Exit Sub
                    End If

                End If
                'If dtCus_addedlist.Rows(i).Cells(4).Value = "" Then
                '    MsgBox("Set your purpose.", MsgBoxStyle.Exclamation)
                '    Return
                'End If
            Next
        Next



        For Each r As DataGridViewRow In dtgreturn_cart.Rows
            sql = "INSERT INTO tbstock_return (  DEVOLUCIONESID, ITEMID, FECHADEVOLUCION,CANTIDAD, PRECIOTOTAL, ID_CLIENTE_PERTENECE)" &
            " VALUES ('" & r.Cells(0).Value & "','" & Format(Now, "yyyy-MM-dd") & "','" & r.Cells(4).Value &
            "','" & r.Cells(5).Value & "')"
            createNoMsg(sql)
            '-----------------------------------------------update item
            sql = "UPDATE tbitems  SET CANTIDAD=CANTIDAD + '" & r.Cells(4).Value & "' WHERE ITEMID='" & r.Cells(0).Value & "'"
            createNoMsg(sql)

            sql = "UPDATE tbstock_in_out SET CANTIDAD=CANTIDAD-'" & r.Cells(4).Value & "', PRECIOTOTAL=PRECIOTOTAL-'" & r.Cells(5).Value & "'  WHERE STOCKOUTID ='" & r.Cells(6).Value & "'"
            createNoMsg(sql)

        Next
        '--------------------------------------------------
        sql = "INSERT INTO  tbtransaccion (STOCKOUTID,  FECHATRANSACCION,  TIPO, CLIENTEPROVEEDORID)" &
                " VALUES ('" & txttransactionid.Text & "','" & Format(Now, "yyyy-MM-dd") & "','devolucion')"
        createNoMsg(sql)
        '-----------------------------------------------update autonumber
        'createNoMsg("UPDATE tbautonumber SET FIN= FIN + INCREMENT WHERE ID = 6")
        '------------------------------------auto stock in
        'reloadtxt("SELECT concat(INICIO,FIN) FROM tbautonumber WHERE ID = 6")
        'stockreturnID = dt.Rows(0).Item(0)
        '--------------------------------------------a----------------
        MsgBox("Los Item(s) han sido devueltos.")
        '------------------------------------------------------------clearing
        cleartext(Panel6)
        dtgreturn_cart.Columns.Clear()
    End Sub

    Private Sub btnreturn_Search_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnreturn_Search.Click
        frm_viewTransaction.Show()
        frm_viewTransaction.Focus()

    End Sub
    Private Sub btnVerlista_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnVerlista.Click
        frmview_stockin.Show()
        frmview_stockin.Focus()
    End Sub


    Private Sub btnviewStockout_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnviewStockout.Click
        frmview_stockout.Show()
        frmview_stockout.Focus()
    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnvewlreturn.Click
        frmview_return.Show()
        frmview_return.Focus()
    End Sub

    Private Sub TabControl1_Selected(ByVal sender As System.Object, ByVal e As System.Windows.Forms.TabControlEventArgs) Handles TabControl1.Selected
        Try
            '----------------------------------------------------------------
            sql = "SELECT ITEMID as 'Item Id', NOMBRE as 'Nombre', DESCRIPCION as 'Descripcion', PRECIOCOMPRA as 'Precio Compra',CANTIDAD as 'Available Cantidad', PRECIOVENTA as 'Precio Venta' FROM tbitems"
            reloadDtg(sql, dtgCus_itemlist)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Me.Close()
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Me.Close()
    End Sub

    Private Sub dtCus_addedlist_CellBeginEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellCancelEventArgs) Handles dtCus_addedlist.CellBeginEdit
        Try
            Dim total As Double
            For Each row As DataGridViewRow In dtCus_addedlist.Rows
                total = row.Cells(5).Value * row.Cells(4).Value
                row.Cells(6).Value = total
            Next
        Catch ex As Exception

        End Try
    End Sub

    Private Sub dtCus_addedlist_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dtCus_addedlist.CellContentClick

    End Sub

    Private Sub dtCus_addedlist_CellLeave(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dtCus_addedlist.CellLeave

    End Sub

    Private Sub dtCus_addedlist_CellMouseLeave(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dtCus_addedlist.CellMouseLeave
        Try
            If dtCus_addedlist.CurrentCell.ColumnIndex = 4 Then
                Dim total As Double
                For Each row As DataGridViewRow In dtCus_addedlist.Rows
                    total = row.Cells(5).Value * row.Cells(4).Value
                    row.Cells(6).Value = total
                Next
            End If

        Catch ex As Exception

        End Try
    End Sub

    Private Sub dtCus_addedlist_CellValueChanged(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dtCus_addedlist.CellValueChanged
        Try
            If dtCus_addedlist.CurrentCell.ColumnIndex = 4 Then
                Dim total As Double
                For Each row As DataGridViewRow In dtCus_addedlist.Rows
                    total = row.Cells(5).Value * row.Cells(4).Value
                    row.Cells(6).Value = total
                Next
            End If

        Catch ex As Exception

        End Try
    End Sub

    Private Sub dtgreturn_cart_CellValueChanged(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dtgreturn_cart.CellValueChanged
        Try
            If dtgreturn_cart.CurrentCell.ColumnIndex = 4 Then
                Dim total As Double
                For Each row As DataGridViewRow In dtgreturn_cart.Rows
                    total = row.Cells(5).Value * row.Cells(4).Value
                    row.Cells(6).Value = total
                Next
            End If

        Catch ex As Exception

        End Try
    End Sub
End Class