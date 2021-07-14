Public Class frm_viewTransaction
    Private Sub frm_viewTransaction_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        sql = " SELECT NUMEROTRANSACCION,  FECHATRANSACCION,  NOMBRE, APELLIDOS  FROM tbtransaccion t,tbpersona c WHERE  c.CLIENTEPROVEEDORID=t.CLIENTEPROVEEDORID AND t.TIPO ='StockOut'"
        reloadDtg(sql, dtglist)
    End Sub

    Private Sub txtsearch_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtsearch.TextChanged
        sql = " SELECT NUMEROTRANSACCION,  FECHATRANSACCION,  NOMBRE, APELLIDOS  FROM tbtransaccion t,tbpersona c WHERE  c.CLIENTEPROVEEDORID=t.CLIENTEPROVEEDORID AND t.TIPO ='StockOut' " &
        " WHERE NUMEROTRANSACCION LIKE '%" & txtsearch.Text & "%'"
        reloadDtg(sql, dtglist)
    End Sub

    Private Sub dtglist_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtglist.DoubleClick
        frm_transaction.txttransactionid.Text = dtglist.CurrentRow.Cells(0).Value
        Me.Close()
    End Sub
End Class