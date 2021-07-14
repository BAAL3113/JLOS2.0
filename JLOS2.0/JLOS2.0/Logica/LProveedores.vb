Public Class LProveedores
    Dim ID As Integer
    Dim ProID, nom, ape, dir, tel, cel, tip As String
    Public Sub New()

    End Sub

    Public Property MID
        Get
            Return ID
        End Get
        Set(value)
            ID = value
        End Set
    End Property
    Public Property MProveedorID
        Get
            Return ProID
        End Get
        Set(value)
            ProID = value
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
            Dir = value
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
    Public Sub New(ByVal id As Integer, ByVal proid As String, ByVal nom As String, ByVal ape As String, ByVal dir As String, ByVal tel As String, ByVal cel As String, ByVal tip As String)
        MID = id
        MProveedorID = proid
        MNombre = nom
        MApellidos = ape
        MDireccion = dir
        MTelefono = tel
        MCelular = cel
        MTipo = tip
    End Sub
End Class
