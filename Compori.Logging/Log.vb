Imports Microsoft.Practices.EnterpriseLibrary.Common.Configuration
Imports Microsoft.Practices.EnterpriseLibrary.Logging

''' <summary>
''' Logging Facade
''' </summary>
''' <remarks></remarks>
Public NotInheritable Class Log
    Implements ILogger, IWriter

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
    ''' Creates a log entry object
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function CreateEntry() As IEntry
        Return New EntryImpl()
    End Function

    ''' <summary>
    ''' Returns the default Log object
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared ReadOnly Property [Default]() As ILogger
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
    Public Shared Function [For](ByVal obj As Object) As ILogger
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
    Public Shared Function [For](ByVal type As Type) As ILogger
        If type IsNot Nothing Then

            ' log object already created
            Dim typeName As String = type.FullName
            If _namedLogs.ContainsKey(typeName) Then
                Return _namedLogs.Item(typeName)
            End If

            ' return log
            Dim log As New Log(type)
            _namedLogs.Add(typeName, log)
            Return log
        Else
            ' type not set
            Return [Default]()
        End If
    End Function


#End Region

    ''' <summary>
    ''' Type
    ''' </summary>
    ''' <remarks></remarks>
    Private _typeContext As Type

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
        _typeContext = type
        _categories = New List(Of String)()
        For Each assAttr In Attribute.GetCustomAttributes(type.Assembly)
            If TypeOf assAttr Is CategoryAttribute Then
                Dim attrCustom As CategoryAttribute = CType(assAttr, CategoryAttribute)
                _categories.Add(attrCustom.Name)
            End If
        Next

        ' Iterate through all the attributes of the type
        For Each classAttr In Attribute.GetCustomAttributes(type)
            If TypeOf classAttr Is CategoryAttribute Then
                Dim attrCustom As CategoryAttribute = CType(classAttr, CategoryAttribute)
                _categories.Add(attrCustom.Name)
            End If
        Next
    End Sub

    ''' <summary>
    ''' Returns an array of preset categories
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public ReadOnly Property Categories() As String()
        Get
            Return _categories.ToArray()
        End Get
    End Property

    ''' <summary>
    ''' Returns a logger instance
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function _GetLoggerInstance() As ILogger
        Dim logger As ILogger = CType(New LoggerImpl(Me), ILogger)

        ' Insert categories definied by attributes
        If _categories.Count > 0 Then
            logger.WithCategories(_categories.ToArray())
        End If
        Return logger
    End Function

    ''' <summary>
    ''' Returns the type context of logging
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public ReadOnly Property TypeContext As Type
        Get
            Return _typeContext
        End Get
    End Property


#Region "IWriter Implementation"

    ''' <summary>
    ''' Writes a log entry
    ''' </summary>
    ''' <param name="entry"></param>
    ''' <remarks></remarks>
    Public Sub Write(ByVal entry As IEntry) Implements IWriter.Write

        ' logger is not available
        If _writer Is Nothing Then
            Exit Sub
        End If

        ' Add categories        
        _writer.Write(entry)
    End Sub

#End Region

#Region "ILogger Implementation"

    ''' <summary>
    ''' Delegate
    ''' </summary>
    ''' <param name="message"></param>
    ''' <remarks></remarks>
    Private Sub _Critical(ByVal ParamArray message() As Object) Implements ILogger.Critical
        _GetLoggerInstance.Critical(message)
    End Sub

    ''' <summary>
    ''' Delegate
    ''' </summary>
    ''' <param name="message"></param>
    ''' <remarks></remarks>
    Private Sub _Error(ByVal ParamArray message() As Object) Implements ILogger.Error
        _GetLoggerInstance.Error(message)
    End Sub

    ''' <summary>
    ''' Delegate
    ''' </summary>
    ''' <param name="message"></param>
    ''' <remarks></remarks>
    Private Sub _Information(ByVal ParamArray message() As Object) Implements ILogger.Information
        _GetLoggerInstance.Information(message)
    End Sub

    ''' <summary>
    ''' Delegate
    ''' </summary>
    ''' <param name="message"></param>
    ''' <remarks></remarks>
    Private Sub _Verbose(ByVal ParamArray message() As Object) Implements ILogger.Verbose
        _GetLoggerInstance.Verbose(message)
    End Sub

    ''' <summary>
    ''' Delegate
    ''' </summary>
    ''' <param name="message"></param>
    ''' <remarks></remarks>
    Private Sub _Warning(ByVal ParamArray message() As Object) Implements ILogger.Warning
        _GetLoggerInstance.Warning(message)
    End Sub

    ''' <summary>
    ''' Delegate
    ''' </summary>
    ''' <param name="category"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function _WithCategories(ByVal ParamArray category() As String) As ILogger Implements ILogger.WithCategories
        Return _GetLoggerInstance.WithCategories(category)
    End Function

    ''' <summary>
    ''' Delegate
    ''' </summary>
    ''' <param name="properties"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function _WithExtendedProperties(ByVal properties As System.Collections.Generic.Dictionary(Of String, Object)) As ILogger Implements ILogger.WithExtendedProperties
        Return _GetLoggerInstance.WithExtendedProperties(properties)
    End Function

    ''' <summary>
    ''' Delegate
    ''' </summary>
    ''' <param name="format"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function _WithFormat(ByVal format As String) As ILogger Implements ILogger.WithFormat
        Return _GetLoggerInstance.WithFormat(format)
    End Function

    ''' <summary>
    ''' Delegate
    ''' </summary>
    ''' <param name="formatProvider"></param>
    ''' <param name="format"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function _WithFormat(ByVal formatProvider As System.IFormatProvider, ByVal format As String) As ILogger Implements ILogger.WithFormat
        Return _GetLoggerInstance.WithFormat(formatProvider, format)
    End Function

    ''' <summary>
    ''' Delegate
    ''' </summary>
    ''' <param name="priority"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function _WithPriority(ByVal priority As Priority) As ILogger Implements ILogger.WithPriority
        Return _GetLoggerInstance.WithPriority(priority)
    End Function
#End Region

End Class
