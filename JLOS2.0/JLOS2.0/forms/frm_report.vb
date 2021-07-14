Public Class frm_report

    Private Sub btnListStockin_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnListStockin.Click
        'sql = "SELECT * FROM tbitems"
        'reports(sql, "itemlist", CrystalReportViewer1)

        If cbooption.Text = "Reporte Diario" Then
            sql = "SELECT i.ITEMID, NOMBRE, DESCRIPCION, TIPO, PRECIOCOMPRA, PRECIOVENTA, so.CANTIDAD, UNIT,REMARKS FROM tbitems i ,tbstock_in_out so WHERE  i.ITEMID=so.ITEMID AND REMARKS='StockIn' AND DATE(REMARKS)=CURDATE()"
        ElseIf cbooption.Text = "Reporte Semanal" Then
            sql = "SELECT i.ITEMID, NOMBRE, DESCRIPCION, TIPO, PRECIOCOMPRA, PRECIOVENTA, so.CANTIDAD, UNIT,REMARKS FROM tbitems i ,tbstock_in_out so WHERE  i.ITEMID=so.ITEMID AND REMARKS='StockIn' AND WEEKDAY(REMARKS) >=0 AND WEEKDAY(REMARKS) <=4"
        ElseIf cbooption.Text = "Reporte Mensual" Then
            sql = "SELECT i.ITEMID, NOMBRE, DESCRIPCION, TIPO, PRECIOCOMPRA, PRECIOVENTA, so.CANTIDAD, UNIT,REMARKS FROM tbitems i ,tbstock_in_out so WHERE  i.ITEMID=so.ITEMID AND REMARKS='StockIn' AND MONTH(REMARKS)=MONTH(CURDATE())"
        End If

        reports(sql, "itemlist", CrystalReportViewer1)
    End Sub

    Private Sub btnStockOut_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnStockOut.Click
        If cbooption.Text = "Reporte Diario" Then
            sql = "SELECT  NUMEROTRANSACCION , concat(NOMBRE,' ', APELLIDOS) as 'Cliente',    NOMBRE AS  'Item', io.CANTIDAD ,  PRECIOTOTAL ,  REMARKS " &
                          " FROM  tbitems i,  tbstock_in_out io,tbpersona p" &
                          " WHERE i.ITEMID = io.ITEMID AND io.CLIENTEPROVEEDORID=p.CLIENTEPROVEEDORID AND REMARKS ='StockOut' AND DATE(REMARKS)=CURDATE()"
        ElseIf cbooption.Text = "Reporte Semanal" Then
            sql = "SELECT  NUMEROTRANSACCION , concat(NOMBRE,' ', APELLIDOS) as 'Cliente',    NOMBRE AS  'Item', io.CANTIDAD ,  PRECIOTOTAL ,  REMARKS " &
                " FROM  tbitems i,  tbstock_in_out io,tbpersona p" &
                " WHERE i.ITEMID = io.ITEMID AND io.CLIENTEPROVEEDORID=p.CLIENTEPROVEEDORID AND REMARKS ='StockOut' AND WEEKDAY(REMARKS) >=0 AND WEEKDAY(REMARKS) <=4"
        ElseIf cbooption.Text = "Reporte Mensual" Then
            sql = "SELECT  NUMEROTRANSACCION , concat(NOMBRE,' ', APELLIDOS) as 'Cliente',    NOMBRE AS  'Item', io.CANTIDAD ,  PRECIOTOTAL ,  REMARKS " &
                " FROM  tbitems i,  tbstock_in_out io,tbpersona p" &
                " WHERE i.ITEMID = io.ITEMID AND io.CLIENTEPROVEEDORID=p.CLIENTEPROVEEDORID AND REMARKS ='StockOut' AND MONTH(REMARKS)=MONTH(CURDATE())"
        End If
        reports(sql, "soldList", CrystalReportViewer1)
    End Sub

    Private Sub btnStockReturn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnStockReturn.Click
        If cbooption.Text = "Reporte Diario" Then
            sql = "SELECT NUMERODEVOLUCIONES,NOMBRE AS 'Item', FECHADEVOLUCION, r.CANTIDAD as 'Cantidad' FROM tbstock_return r,tbitems i WHERE r.ITEMID=i.ITEMID AND DATE(FECHADEVOLUCION)=CURDATE()"
        ElseIf cbooption.Text = "Reporte Semanal" Then
            sql = "SELECT NUMERODEVOLUCIONES,NOMBRE AS 'Item', FECHADEVOLUCION, r.CANTIDAD as 'Cantidad' FROM tbstock_return r,tbitems i WHERE r.ITEMID=i.ITEMID AND WEEKDAY(FECHADEVOLUCION) >=0 AND WEEKDAY(FECHADEVOLUCION) <=4"
        ElseIf cbooption.Text = "Reporte Mensual" Then
            sql = "SELECT NUMERODEVOLUCIONES,NOMBRE AS 'Item', FECHADEVOLUCION, r.CANTIDAD as 'Cantidad' FROM tbstock_return r,tbitems i WHERE r.ITEMID=i.ITEMID AND MONTH(FECHADEVOLUCION)=MONTH(CURDATE())"
        End If
        reports(sql, "Lista Retorno", CrystalReportViewer1)
    End Sub


    Private Sub dptfrom_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dptfrom.ValueChanged, dtpto.ValueChanged
        sql = "SELECT  NOMBRE ,  DESCRIPCION ,  TIPO , i.CANTIDAD AS  'Stock-In',  UNIT , o.CANTIDAD AS  'Stock-Out',  REMARKS ,  REMARKS " &
                "FROM  tbitems i" &
                " LEFT JOIN  tbstock_in_out o ON i.ITEMID = o.ITEMID " &
                " AND REMARKS =  'StockOut' and REMARKS between '" & Format(dptfrom.Value, "yyyy-MM-dd") & "' and '" & Format(dtpto.Value, "yyyy-MM-dd") & "'"
        reports(sql, "inventorio", CrystalReportViewer1)
    End Sub


    Private Sub btnitemlisat_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnitemlisat.Click
        sql = "SELECT * FROM tbitems"
        reports(sql, "todos los items", CrystalReportViewer1)
    End Sub


End Class