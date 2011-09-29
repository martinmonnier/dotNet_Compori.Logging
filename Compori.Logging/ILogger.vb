''' <summary>
''' Interface for log
''' </summary>
''' <remarks></remarks>
Public Interface ILogger

#Region "Configure"

    ''' <summary>
    ''' Log message will be exposed with those categories
    ''' </summary>
    ''' <param name="category"></param>
    ''' <remarks></remarks>
    Function WithCategories(ByVal ParamArray category As String()) As ILogger

    ''' <summary>
    ''' Log message will be exposed with this priority
    ''' </summary>
    ''' <param name="priority"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Function WithPriority(ByVal priority As Priority) As ILogger

    ''' <summary>
    ''' Log message will use a format string
    ''' </summary>
    ''' <param name="format"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Function WithFormat(ByVal format As String) As ILogger

    ''' <summary>
    ''' Log message will use a format provider and format string
    ''' </summary>
    ''' <param name="formatProvider"></param>
    ''' <param name="format"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Function WithFormat(ByVal formatProvider As IFormatProvider, ByVal format As String) As ILogger

    ''' <summary>
    ''' Log a message and add extended properties
    ''' </summary>
    ''' <param name="properties"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Function WithExtendedProperties(ByVal properties As IDictionary(Of String, Object)) As ILogger

#End Region

#Region "Verbs"

    ''' <summary>
    ''' Final verb of a critical log message
    ''' </summary>
    ''' <param name="message"></param>
    ''' <remarks></remarks>
    Sub Critical(ByVal ParamArray message As Object())

    ''' <summary>
    '''  Final verb of a error log message
    ''' </summary>
    ''' <param name="message"></param>
    ''' <remarks></remarks>
    Sub [Error](ByVal ParamArray message As Object())

    ''' <summary>
    ''' final verb of a warn log message
    ''' </summary>
    ''' <param name="message"></param>
    ''' <remarks></remarks>
    Sub Warning(ByVal ParamArray message As Object())

    ''' <summary>
    ''' final verb of a information/notice message
    ''' </summary>
    ''' <param name="message"></param>
    ''' <remarks></remarks>
    Sub Information(ByVal ParamArray message As Object())

    ''' <summary>
    ''' final verb of a verbose (almost everything) message
    ''' </summary>
    ''' <param name="message"></param>
    ''' <remarks></remarks>
    Sub Verbose(ByVal ParamArray message As Object())

#End Region

End Interface
