Imports Microsoft.Practices.EnterpriseLibrary.Common.Configuration
Imports Microsoft.Practices.EnterpriseLibrary.Logging

''' <summary>
''' Logging Facade
''' </summary>
''' <remarks></remarks>
Public NotInheritable Class Log
    Implements ILogger

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

#Region "Low Level API"

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

        ' Add categories
        If _categories.Count > 0 Then
            Dim categories As New List(Of String)(_categories.ToArray)
            If entry.Categories IsNot Nothing Then
                categories.AddRange(entry.Categories)
            End If
            entry.Categories = categories
        End If
        _writer.Write(entry)
    End Sub

#End Region

    Public Sub Critical(ByVal ParamArray message() As Object) Implements ILogger.Critical
        Dim loggerimpl = New LoggerImpl(Me)
        loggerimpl.Critical(message)
    End Sub

    Public Sub [Error](ByVal ParamArray message() As Object) Implements ILogger.Error
        Dim loggerimpl = New LoggerImpl(Me)
        loggerimpl.[Error](message)
    End Sub

    Public Sub Information(ByVal ParamArray message() As Object) Implements ILogger.Information
        Dim loggerimpl = New LoggerImpl(Me)
        loggerimpl.Information(message)
    End Sub

    Public Sub Verbose(ByVal ParamArray message() As Object) Implements ILogger.Verbose
        Dim loggerimpl = New LoggerImpl(Me)
        loggerimpl.Verbose(message)
    End Sub

    Public Sub Warning(ByVal ParamArray message() As Object) Implements ILogger.Warning
        Dim loggerimpl = New LoggerImpl(Me)
        loggerimpl.Warning(message)
    End Sub

    Public Function WithCategories(ByVal ParamArray category() As String) As ILogger Implements ILogger.WithCategories
        Return New LoggerImpl(Me).WithCategories(category)
    End Function

    Public Function WithExtendedProperties(ByVal properties As System.Collections.Generic.IDictionary(Of String, Object)) As ILogger Implements ILogger.WithExtendedProperties
        Return New LoggerImpl(Me).WithExtendedProperties(properties)
    End Function

    Public Function WithFormat(ByVal format As String) As ILogger Implements ILogger.WithFormat
        Return New LoggerImpl(Me).WithFormat(format)
    End Function

    Public Function WithFormat(ByVal formatProvider As System.IFormatProvider, ByVal format As String) As ILogger Implements ILogger.WithFormat
        Return New LoggerImpl(Me).WithFormat(formatProvider, format)
    End Function

    Public Function WithPriority(ByVal priority As Priority) As ILogger Implements ILogger.WithPriority
        Return New LoggerImpl(Me).WithPriority(priority)
    End Function
End Class
