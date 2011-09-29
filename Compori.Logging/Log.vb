Imports Microsoft.Practices.EnterpriseLibrary.Common.Configuration
Imports Microsoft.Practices.EnterpriseLibrary.Logging

''' <summary>
''' Logging Facade
''' </summary>
''' <remarks></remarks>
Public NotInheritable Class Log

#Region "Shared/Static API"

    ''' <summary>
    ''' Log writer object
    ''' </summary>
    ''' <remarks></remarks>
    Private Shared _writer As LogWriter

    ''' <summary>
    ''' Default log object
    ''' </summary>
    ''' <remarks></remarks>
    Private Shared _defaultLog As Log

    ''' <summary>
    ''' A map with named log objects
    ''' </summary>
    ''' <remarks></remarks>
    Private Shared _namedLogs As Dictionary(Of String, Log)

    ''' <summary>
    ''' Static Class constructor
    ''' </summary>
    ''' <remarks></remarks>
    Shared Sub New()

        ' Initialize the default log and named log map
        _defaultLog = New Log(GetType(Log))
        _namedLogs = New Dictionary(Of String, Log)()

        ' Setup log writer
        Try
            ' Try getting the log writer from current container
            _writer = EnterpriseLibraryContainer.Current.GetInstance(Of LogWriter)()
        Catch

            ' if some exception raises try to create a log writer by using fluent configuration 
            Dim builder = New ConfigurationSourceBuilder()
            builder.ConfigureLogging() _
                .WithOptions _
                    .DoNotRevertImpersonation() _
                    .LogToCategoryNamed("General") _
                        .WithOptions _
                        .SetAsDefaultCategory()

            Dim configSource = New DictionaryConfigurationSource()
            builder.UpdateConfigurationWithReplace(configSource)

            ' create logger
            _writer = EnterpriseLibraryContainer.CreateDefaultContainer(configSource).GetInstance(Of LogWriter)()
        End Try
    End Sub

    ''' <summary>
    ''' Returns the default Log object
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared ReadOnly Property [Default]() As Log
        Get
            Return _defaultLog
        End Get
    End Property


    ''' <summary>
    ''' Returns the log object for a specific object
    ''' </summary>
    ''' <param name="obj"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function [For](ByVal obj As Object) As Log
        If obj IsNot Nothing Then
            Return [For](obj.GetType())
        Else
            ' object not set
            Return [Default]()
        End If
    End Function

    ''' <summary>
    ''' Returns the log object for specific type
    ''' </summary>
    ''' <param name="type"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function [For](ByVal type As Type) As Log
        If type IsNot Nothing Then

            ' log object already created
            Dim typeName As String = type.FullName
            If _namedLogs.ContainsKey(typeName) Then
                Return _namedLogs.Item(typeName)
            End If

            Dim log As New Log(type)

            For Each assAttr In Attribute.GetCustomAttributes(type.Assembly)
                If TypeOf assAttr Is CategoryAttribute Then
                    Dim attrCustom As CategoryAttribute = CType(assAttr, CategoryAttribute)
                    log.Categories.Add(attrCustom.Name)
                End If
            Next

            ' Iterate through all the attributes of the type
            For Each classAttr In Attribute.GetCustomAttributes(type)
                If TypeOf classAttr Is CategoryAttribute Then
                    Dim attrCustom As CategoryAttribute = CType(classAttr, CategoryAttribute)
                    log.Categories.Add(attrCustom.Name)
                End If
            Next

            ' return log
            _namedLogs.Add(typeName, log)
            Return log
        Else
            ' type not set
            Return [Default]()
        End If
    End Function
#End Region

    ''' <summary>
    ''' An array of category names
    ''' </summary>
    ''' <remarks></remarks>
    Private _categories As List(Of String)

    ''' <summary>
    ''' Creates a log object
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub New(ByVal type As Type)
        _categories = New List(Of String)()
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

#Region "Low Level API"

    ''' <summary>
    ''' Creates a log entry with a message and severity
    ''' </summary>
    ''' <param name="message">Message to log</param>
    ''' <param name="severity">Severity</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function CreateLogEntry(ByVal message As String, ByVal severity As TraceEventType) As LogEntry

        Dim entry As LogEntry = New LogEntry()

        entry.Message = message
        entry.Severity = severity
        entry.Categories = New List(Of String)(_categories)
        'entry.Priority = _priority
        Return entry

    End Function

    ''' <summary>
    ''' Write a log entry
    ''' </summary>
    ''' <param name="entry"></param>
    ''' <remarks></remarks>
    Public Sub WriteLogEntry(ByVal entry As LogEntry)

        ' logger is not available
        If _writer Is Nothing Then
            Exit Sub
        End If

        _writer.Write(entry)
    End Sub

#End Region
End Class
