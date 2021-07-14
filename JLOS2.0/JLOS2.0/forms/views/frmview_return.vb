Public Class frmview_return

    Private Sub frmview_return_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        sql = "SELECT concat(NOMBRE, APELLIDOS) as 'NOMBRECOMPLETO',NUMERODEVOLUCIONES as 'TRANSACCION#',NOMBRE as 'NOMBREITEM', FECHADEVOLUCION FROM tbstock_return r, tbitems i,tbpersona p WHERE i.ITEMID=r.ITEMID and r.ID_CLIENTE_PERTENECE =p.CLIENTEPROVEEDORID and p.TYPE not in ('Proveedor')"
        reloadDtg(sql, dtglist)
    End Sub

    Private Sub txtsearch_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtsearch.TextChanged
        sql = "SELECT concat(NOMBRE, APELLIDOS) as 'FULLNAME',NUMERODEVOLUCIONES as 'TRANSACTION#',NOMBRE as 'ITEMNAME', FECHADEVOLUCION FROM tbstock_return r, tbitems i,tbpersona p WHERE i.ITEMID=r.ITEMID and r.ID_CLIENTE_PERTENECE =p.CLIENTEPROVEEDORID and p.TYPE not in ('Proveedor')" &
        " AND NUMERODEVOLUCIONES LIKE '%" & txtsearch.Text & "%'"
        reloadDtg(sql, dtglist)
    End Sub

End Class