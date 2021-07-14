Public Class frmview_stockin

    Private Sub frmview_stockin_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        sql = "SELECT  NUMEROTRANSACCION,concat(NOMBRE, APELLIDOS) as 'PROVEEDOR',NOMBRE as 'NOMBREITEM', DESCRIPCION, PRECIOCOMPRA, PRECIOVENTA, FECHATRANSACCION, i.CANTIDAD, PRECIOTOTAL FROM  tbpersona p,tbstock_in_out o ,tbitems i WHERE  i.ITEMID=o.ITEMID and p.VENDEDORPROVEEDORID=o.VENDEDORPROVEEDORID and p.TIPO = 'Proveedor'"
        reloadDtg(sql, dtglist)
    End Sub

    Private Sub txtsearch_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtsearch.TextChanged
        sql = "SELECT  NUMEROTRANSACCION,concat(NOMBRE, APELLIDOS) as 'PROVEEDOR',NOMBRE as 'NOMBREITEM', DESCRIPCION, PRECIOCOMPRA, PRECIOVENTA, FECHATRANSACCION, i.CANTIDAD, PRECIOTOTAL FROM  tbpersona p,tbstock_in_out o ,tbitems i WHERE  i.ITEMID=o.ITEMID and p.VENDEDORPROVEEDORID=o.VENDEDORPROVEEDORID and p.TIPO = 'Proveedor'" &
        " AND (NOMBRE like '%" & txtsearch.Text & "%' OR  NUMEROTRANSACCION like '%" & txtsearch.Text & "%')"
        reloadDtg(sql, dtglist)
    End Sub
End Class