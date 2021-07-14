Public Class LItems
    Dim itemid, nom, desc, tipo, unit As String
    Dim preciocom, precioven, cant As Integer

    Public Sub New()

    End Sub
    Public Property MItemID
        Get
            Return itemid
        End Get
        Set(value)
            itemid = value
        End Set
    End Property
    Public Property MNombre
        Get
            Return nom
        End Get
        Set(value)
            nom = value
        End Set
    End Property
    Public Property MDescripcion
        Get
            Return desc
        End Get
        Set(value)
            desc = value
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
    Public Property MUnit
        Get
            Return unit
        End Get
        Set(value)
            unit = value
        End Set
    End Property
    Public Property MPrecioCompra
        Get
            Return preciocom
        End Get
        Set(value)
            preciocom = value
        End Set
    End Property
    Public Property MPrecioventa
        Get
            Return precioven

        End Get
        Set(value)
            precioven = value
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
    Public Sub New(ByVal itemid As String, ByVal nom As String, ByVal desc As String, ByVal tipo As String, ByVal unit As String, ByVal preciocom As Integer, ByVal precioven As Integer, ByVal cant As Integer)
        MItemID = itemid
        MNombre = nom
        MDescripcion = desc
        MTipo = tipo
        MUnit = unit
        MPrecioCompra = preciocom
        MPrecioventa = precioven
        MCantidad = cant

    End Sub
End Class
