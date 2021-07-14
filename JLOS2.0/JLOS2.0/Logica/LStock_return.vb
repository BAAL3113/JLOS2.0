Public Class LStock_return
    Dim id, cant, idclipert, preciotot As Integer
    Dim fechadev As Date
    Dim numdev, itemid As String
    Public Sub New()

    End Sub
    Public Property MDevolucionesID
        Get
            Return id
        End Get
        Set(value)
            id = value
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
    Public Property MIDCliente_pertenece
        Get
            Return idclipert

        End Get
        Set(value)
            idclipert = value

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
    Public Property MFecha_devolucion
        Get
            Return fechadev

        End Get
        Set(value)
            fechadev = value

        End Set
    End Property
    Public Property MNumero_devolucion
        Get
            Return numdev

        End Get
        Set(value)
            numdev = value

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
    Public Sub New(ByVal id As Integer, ByVal cant As Integer, ByVal idclipert As Integer, ByVal preciotot As Integer, ByVal fechadev As Date, ByVal numdev As String, ByVal itemid As String)
        MDevolucionesID = id
        MCantidad = cant
        MIDCliente_pertenece = idclipert
        MPreciototal = preciotot
        MFecha_devolucion = fechadev
        MNumero_devolucion = numdev
        MItemID = itemid

    End Sub
End Class
