Imports Microsoft.Practices.EnterpriseLibrary.Logging

''' <summary>
''' For now the log entry object used
''' </summary>
''' <remarks></remarks>
Public Class EntryImpl
    Inherits LogEntry
    Implements IEntry

    ''' <summary>
    ''' Log entry
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub New()
        MyBase.New()
    End Sub

    ''' <summary>
    ''' Delegate to inherited class implementation
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Property _Categories As System.Collections.Generic.ICollection(Of String) Implements IEntry.Categories
        Get
            Return Me.Categories
        End Get
        Set(ByVal value As System.Collections.Generic.ICollection(Of String))
            Me.Categories = value
        End Set
    End Property

    ''' <summary>
    ''' Delegate to inherited class implementation
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Property _ExtendedProperties As System.Collections.Generic.IDictionary(Of String, Object) Implements IEntry.ExtendedProperties
        Get
            Return Me.ExtendedProperties
        End Get
        Set(ByVal value As System.Collections.Generic.IDictionary(Of String, Object))
            Me.ExtendedProperties = value
        End Set
    End Property

    ''' <summary>
    ''' Delegate to inherited class implementation
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Property _Message As String Implements IEntry.Message
        Get
            Return Me.Message
        End Get
        Set(ByVal value As String)
            Me.Message = value
        End Set
    End Property

    ''' <summary>
    ''' Delegate to inherited class implementation
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Property _Priority As Integer Implements IEntry.Priority
        Get
            Return Me.Priority
        End Get
        Set(ByVal value As Integer)
            Me.Priority = value
        End Set
    End Property

    ''' <summary>
    ''' Delegate to inherited class implementation
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Property _Severity As System.Diagnostics.TraceEventType Implements IEntry.Severity
        Get
            Return Me.Severity
        End Get
        Set(ByVal value As System.Diagnostics.TraceEventType)
            Me.Severity = value
        End Set
    End Property
End Class
