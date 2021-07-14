Public Class frmview_stockout

    Private Sub frmview_stockout_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        sql = "SELECT  NUMEROTRANSACCION,concat(p.NOMBRE, p.APELLIDOS) as 'PROVEEDOR',i.NOMBRE as 'ITEMNOMBRE', DESCRIPCION, PRECIOCOMPRA, PRECIOVENTA ,FECHATRANSACCION, o.CANTIDAD, PRECIOTOTAL FROM  tbpersona p,tbstock_in_out o ,tbitems i WHERE REMARKS='StockOut' AND i.ITEMID=o.ITEMID and p.CLIENTEPROVEEDORID=o.CLIENTEPROVEEDORID and p.TIPO = 'Cliente'"
        reloadDtg(sql, dtglist)
    End Sub
    Private Sub txtsearch_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtsearch.TextChanged
        sql = "SELECT  NUMEROTRANSACCION,concat(p.NOMBRE, p.APELLIDOS) as 'PROVEEDOR',i.NOMBRE as 'ITEMNOMBRE', DESCRIPCION, PRECIOCOMPRA, PRECIOVENTA, FECHATRANSACCION, o.CANTIDAD, PRECIOTOTAL FROM  tbpersona p,tbstock_in_out o ,tbitems i WHERE REMARKS='StockOut' and i.ITEMID=o.ITEMID and p.CLIENTEPROVEEDORID=o.CLIENTEPROVEEDORID and p.TIPO = 'Cliente'" &
        " AND (p.NOMBRE like '%" & txtsearch.Text & "%' OR  NUMEROTRANSACCION like '%" & txtsearch.Text & "%')"
        reloadDtg(sql, dtglist)
    End Sub
End Class