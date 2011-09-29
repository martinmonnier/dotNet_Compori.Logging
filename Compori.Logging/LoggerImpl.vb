Imports Microsoft.Practices.EnterpriseLibrary.Logging

Public Class LoggerImpl
    Implements ILogger

    ''' <summary>
    ''' Log Writer
    ''' </summary>
    ''' <remarks></remarks>
    Private _log As Log

    ''' <summary>
    ''' An array of category names
    ''' </summary>
    ''' <remarks></remarks>
    Private _categories As List(Of String)

    ''' <summary>
    ''' Creates the log options
    ''' </summary>
    ''' <param name="log"></param>
    ''' <remarks></remarks>
    Friend Sub New(ByVal log As Log)

        _log = log
        _categories = New List(Of String)()

        ' Setup default values
        Me.Priority = Priority.Normal
        Me.Format = String.Empty
        Me.FormatProvider = Nothing
        Me.ExtendedProperties = Nothing
    End Sub

    ''' <summary>
    ''' Returns the formated message using format provider and format string
    ''' </summary>
    ''' <param name="message"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function GetFormattedMessage(ByVal message As Object()) As String

        ' Ideal case no format string an ony
        If String.IsNullOrEmpty(Me.Format) Then
            If message.Count = 1 Then
                Return message(0).ToString()
            Else
                Throw New ArgumentException("More than one messages parts are given, but no format string. Do not know how to put them together!")
            End If
        End If

        ' Format
        If Me.FormatProvider Is Nothing Then
            Return String.Format(Me.Format, message)
        Else
            Return String.Format(Me.FormatProvider, Me.Format, message)
        End If

    End Function

    ''' <summary>
    ''' Writes the log entry
    ''' </summary>
    ''' <param name="message"></param>
    ''' <param name="severity"></param>
    ''' <remarks></remarks>
    Private Sub _Write(ByVal message As String, ByVal severity As TraceEventType)

        Dim entry As LogEntry = New LogEntry()
        entry.Message = message
        entry.Severity = severity
        entry.Priority = Me.Priority

        If _categories.Count > 0 Then
            entry.Categories = New List(Of String)(_categories)
        End If

        If Me.ExtendedProperties IsNot Nothing Then
            entry.ExtendedProperties = Me.ExtendedProperties
        End If

        _log.WriteLogEntry(entry)
    End Sub

    ''' <summary>
    ''' Returns a list of category names
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public ReadOnly Property Categories As ICollection(Of String)
        Get
            Return _categories
        End Get
    End Property

    ''' <summary>
    ''' Add the given categories to log entry
    ''' </summary>
    ''' <param name="category"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function WithCategories(ByVal ParamArray category() As String) As ILogger Implements ILogger.WithCategories
        _categories.AddRange(category)
        Return Me
    End Function

    ''' <summary>
    ''' Sets or gets the priority for current log message
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property Priority As Priority

    ''' <summary>
    ''' Set priority for a log message and returns log options
    ''' </summary>
    ''' <param name="priority"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function WithPriority(ByVal priority As Priority) As ILogger Implements ILogger.WithPriority
        Me.Priority = priority
        Return Me
    End Function

    ''' <summary>
    ''' Sets or gets the log format
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property Format As String

    ''' <summary>
    ''' Format provider
    ''' </summary>
    ''' <remarks></remarks>
    Public Property FormatProvider As IFormatProvider

    ''' <summary>
    ''' Log message will use a format string
    ''' </summary>
    ''' <param name="format"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function WithFormat(ByVal format As String) As ILogger Implements ILogger.WithFormat
        Me.Format = format
        Return Me
    End Function

    ''' <summary>
    ''' Log message will use a format provider and format string
    ''' </summary>
    ''' <param name="formatProvider"></param>
    ''' <param name="format"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function WithFormat(ByVal formatProvider As System.IFormatProvider, ByVal format As String) As ILogger Implements ILogger.WithFormat
        Me.Format = format
        Me.FormatProvider = formatProvider
        Return Me
    End Function

    ''' <summary>
    ''' Extended Properties
    ''' </summary>
    ''' <remarks></remarks>
    Public Property ExtendedProperties As Dictionary(Of String, Object)

    ''' <summary>
    ''' Log a message and add extended properties
    ''' </summary>
    ''' <param name="properties"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function WithExtendedProperties(ByVal properties As System.Collections.Generic.IDictionary(Of String, Object)) As ILogger Implements ILogger.WithExtendedProperties
        ExtendedProperties = properties
        Return Me
    End Function
#Region "Verbs"

    ''' <summary>
    ''' Final verb of a critical log message
    ''' </summary>
    ''' <param name="message"></param>
    ''' <remarks></remarks>
    Public Sub Critical(ByVal ParamArray message() As Object) Implements ILogger.Critical
        _Write(GetFormattedMessage(message), TraceEventType.Critical)
    End Sub

    ''' <summary>
    '''  Final verb of a error log message
    ''' </summary>
    ''' <param name="message"></param>
    ''' <remarks></remarks>
    Public Sub [Error](ByVal ParamArray message() As Object) Implements ILogger.Error
        _Write(GetFormattedMessage(message), TraceEventType.Error)
    End Sub

    ''' <summary>
    ''' final verb of a warn log message
    ''' </summary>
    ''' <param name="message"></param>
    ''' <remarks></remarks>
    Public Sub Warning(ByVal ParamArray message() As Object) Implements ILogger.Warning
        _Write(GetFormattedMessage(message), TraceEventType.Warning)
    End Sub

    ''' <summary>
    ''' final verb of a information/notice message
    ''' </summary>
    ''' <param name="message"></param>
    ''' <remarks></remarks>
    Public Sub Information(ByVal ParamArray message() As Object) Implements ILogger.Information
        _Write(GetFormattedMessage(message), TraceEventType.Information)
    End Sub

    ''' <summary>
    ''' final verb of a verbose (almost everything) message
    ''' </summary>
    ''' <param name="message"></param>
    ''' <remarks></remarks>
    Public Sub Verbose(ByVal ParamArray message() As Object) Implements ILogger.Verbose
        _Write(GetFormattedMessage(message), TraceEventType.Verbose)
    End Sub

#End Region

End Class
