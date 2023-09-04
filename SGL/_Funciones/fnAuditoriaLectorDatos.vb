Public Class fnAuditoriaLectorDatos
    Private _a As Integer
    Private _DIIO As Integer
    Private _FechaLectura As Date
    Private _OrigenLectura As String
    Private _TipoCarga As String
    Private _CentroCod As String
    Private _Serial As String
    Public Property Serial As String
        Get
            Return _Serial
        End Get
        Set(value As String)
            _Serial = value
        End Set
    End Property

    Public Property CentroCod As String
        Get
            Return _CentroCod
        End Get
        Set(value As String)
            _CentroCod = value
        End Set
    End Property
    Public Property a As Integer
        Get
            Return _a
        End Get
        Set(value As Integer)
            _a = value
        End Set
    End Property
    Public Property DIIO As Integer
        Get
            Return _DIIO
        End Get
        Set(value As Integer)
            _DIIO = value
        End Set
    End Property
    Public Property FechaLectura As DateTime
        Get
            Return _FechaLectura
        End Get
        Set(value As Date)
            _FechaLectura = value
        End Set
    End Property
    'Public Property OrigenLectura As String
    '    Get
    '        Return _OrigenLectura
    '    End Get
    '    Set(value As String)
    '        _OrigenLectura = value
    '    End Set
    'End Property
    Public Property Tipocarga As String
        Get
            Return _TipoCarga
        End Get
        Set(value As String)
            _TipoCarga = value
        End Set
    End Property

End Class
