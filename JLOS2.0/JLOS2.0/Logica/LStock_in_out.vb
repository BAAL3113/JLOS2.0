Public Class LStock_in_out
    Dim stockid, cant, preciotot As Integer
    Dim numtrans, itemid, vendproid, desc As String
    Dim fechatrans As Date

    Public Sub New()

    End Sub
    Public Property MStockID
        Get
            Return stockid

        End Get
        Set(value)
            stockid = value

        End Set
    End Property
    Public Property MCantidad
        Get
            Return cant

        End Get
        Set(value)
            cant = value

        End Set
    End Property
    Public Property MPreciototal
        Get
            Return preciotot

        End Get
        Set(value)
            preciotot = value

        End Set
    End Property
    Public Property MNumerotransaccion
        Get
            Return numtrans

        End Get
        Set(value)
            numtrans = value

        End Set
    End Property
    Public Property MItemID
        Get
            Return itemid

        End Get
        Set(value)
            itemid = value

        End Set
    End Property
    Public Property MVendedorProveedorID
        Get
            Return vendproid

        End Get
        Set(value)
            vendproid = value

        End Set
    End Property
    Public Property MRemarks
        Get
            Return desc

        End Get
        Set(value)
            desc = value

        End Set
    End Property
    Public Property MFechatransaccion
        Get
            Return fechatrans

        End Get
        Set(value)
            fechatrans = value

        End Set
    End Property
    Public Sub New(ByVal stockid As Integer, ByVal cant As Integer, ByVal preciotot As Integer, ByVal numtrans As String, ByVal itemid As String, ByVal venproid As String, ByVal desc As String, ByVal fechatrans As Date)
        MStockID = stockid
        MCantidad = cant
        MPreciototal = preciotot
        MNumerotransaccion = numtrans
        MItemID = itemid
        MVendedorProveedorID = venproid
        MRemarks = desc
        MFechatransaccion = fechatrans

    End Sub
End Class
