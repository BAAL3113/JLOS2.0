Public Class LSettings
    Dim id As Integer
    Dim desc, para As String
    Public Sub New()

    End Sub
    Public Property MID
        Get
            Return id

        End Get
        Set(value)
            id = value

        End Set
    End Property
    Public Property Mdescripcion
        Get
            Return desc

        End Get
        Set(value)
            desc = value

        End Set
    End Property
    Public Property MPARA
        Get
            Return para

        End Get
        Set(value)
            para = value

        End Set
    End Property
    Public Sub New(ByVal id As Integer, ByVal desc As String, ByVal PARA As String)
        MID = id
        Mdescripcion = desc
        MPARA = PARA

    End Sub
End Class
