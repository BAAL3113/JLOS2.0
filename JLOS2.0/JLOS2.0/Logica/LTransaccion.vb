Public Class LTransaccion
    Public stockinID As Integer
    Public fecha_trans As Date
    Public num_trans, tipo, cliproID As String
    Public Sub New()

    End Sub
    Public Property MStockinID
        Get
            Return stockinID

        End Get
        Set(value)
            stockinID = value

        End Set
    End Property
    Public Property MFecha_transaccion
        Get
            Return fecha_trans

        End Get
        Set(value)
            fecha_trans = value

        End Set
    End Property
    Public Property MNumero_Transaccion
        Get
            Return num_trans

        End Get
        Set(value)
            num_trans = value

        End Set
    End Property
    Public Property MTipo
        Get
            Return tipo

        End Get
        Set(value)
            tipo = value

        End Set
    End Property
    Public Property MCliente_ProveedorID
        Get
            Return cliproID

        End Get
        Set(value)
            cliproID = value

        End Set
    End Property
    Public Sub New(ByVal stockinid As Integer, ByVal fecha_trans As Date, ByVal numtrans As String, ByVal tipo As String, ByVal cliproID As String)
        MStockinID = stockinid
        MFecha_transaccion = fecha_trans
        MNumero_Transaccion = numtrans
        MTipo = tipo
        MCliente_ProveedorID = cliproID

    End Sub
End Class
