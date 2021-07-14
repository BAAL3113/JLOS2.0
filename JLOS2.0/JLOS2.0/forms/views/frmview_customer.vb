Public Class frmview_customer

    Private Sub frmview_customer_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        sql = "SELECT  CLIENTEPROVEEDORID as 'CLIENTEID', NOMBRE, APELLIDOS, DIRECCION, TELEFONO, CELULAR, TIPO FROM tbpersona WHERE  TIPO ='Cliente'"
        reloadDtg(sql, dtglist)
    End Sub

    Private Sub txtsearch_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtsearch.TextChanged
        sql = "SELECT  CLIENTEPROVEEDORID as 'CLIENTEID', NOMBRE, APELLIDOS, DIRECCION, TELEFONO, CELULAR, TIPO FROM tbpersona WHERE  TIPO ='Cliente' AND  CLIENTEPROVEEDORID LIKE '%" & txtsearch.Text & "%'"
        reloadDtg(sql, dtglist)
    End Sub

    Private Sub dtglist_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles dtglist.DoubleClick
        Try
            frm_transaction.txt_cusid.Text = dtglist.CurrentRow.Cells(0).Value
            Me.Close()
        Catch ex As Exception

        End Try
    End Sub
End Class