Public Class LClientes
    Dim ID As Integer
    Dim CliProID, nom, ape, dir, tel, cel, tip, itemnom As String
    Public Property MID_Clientes
        Get
            Return ID
        End Get
        Set(value)
            ID = value
        End Set
    End Property
    Public Property MClienteProveedorID
        Get
            Return CliProID
        End Get
        Set(value)
            CliProID = value
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
    Public Property MApellidos
        Get
            Return ape

        End Get
        Set(value)
            ape = value

        End Set
    End Property
    Public Property MDireccion
        Get
            Return dir

        End Get
        Set(value)
            dir = value
        End Set
    End Property
    Public Property MTelefono
        Get
            Return tel

        End Get
        Set(value)
            tel = value

        End Set
    End Property
    Public Property MCelular
        Get
            Return cel

        End Get
        Set(value)
            cel = value

        End Set
    End Property
    Public Property MTipo
        Get
            Return tip

        End Get
        Set(value)
            tip = value

        End Set
    End Property
    Public Property MItemNombre
        Get
            Return itemnom

        End Get
        Set(value)
            itemnom = value

        End Set
    End Property
    Public Sub New()

    End Sub
    Public Sub New(ByVal id As Integer, ByVal nom As String, ByVal ape As String, ByVal dir As String, ByVal tel As String, ByVal cel As String, ByVal tip As String, ByVal itemnom As String)
        MID_Clientes = id
        MNombre = nom
        MApellidos = ape
        MDireccion = dir
        MTelefono = tel
        MCelular = cel
        MTipo = tip
        MItemNombre = itemnom

    End Sub
End Class
