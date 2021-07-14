Public Class LUsuario
    Dim id_usuario As Integer
    Dim nom, user_nom, pass, tipo As String
    Public Sub New()

    End Sub
    Public Property Mnombre
        Get
            Return nom
        End Get
        Set(value)
            nom = value
        End Set
    End Property
    Public Property MID
        Get
            Return id_usuario
        End Get
        Set(value)
            id_usuario = value
        End Set
    End Property
    Public Property MNombreUsuario
        Get
            Return user_nom
        End Get
        Set(value)
            user_nom = value
        End Set
    End Property
    Public Property MPass
        Get
            Return pass
        End Get
        Set(value)
            pass = value
        End Set
    End Property
    Public Property Mtipo
        Get
            Return tipo
        End Get
        Set(value)
            tipo = value
        End Set
    End Property
    Public Sub New(ByVal id_usuario As Integer, ByVal nom As String, ByVal nom_user As String, ByVal pass As String, ByVal tipo As String)
        MID = id_usuario
        Mnombre = nom
        MNombreUsuario = nom_user
        MPass = pass
        Mtipo = tipo

    End Sub
End Class
