''' <summary>
''' Interface for this logging facade
''' </summary>
''' <remarks>
''' The Interface provides a fluent call of methods that always ends with a verb e.g. verbose, critical etc.
''' </remarks>
Public Interface ILogger

#Region "Fluent Configuration"

    ''' <summary>
    ''' Log message will be exposed with those categories
    ''' </summary>
    ''' <param name="category">One or more categories to log to</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Function WithCategories(ByVal ParamArray category As String()) As ILogger

    ''' <summary>
    ''' Log message will be exposed with this priority
    ''' </summary>
    ''' <param name="priority">A priority of log message</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Function WithPriority(ByVal priority As Priority) As ILogger

    ''' <summary>
    ''' Log message will use a format string
    ''' </summary>
    ''' <param name="format">Used format string for the log message</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Function WithFormat(ByVal format As String) As ILogger

    ''' <summary>
    ''' Log message will use a format provider and format string
    ''' </summary>
    ''' <param name="formatProvider">A specific format provider for formatting</param>
    ''' <param name="format">Used format string for the log message</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Function WithFormat(ByVal formatProvider As IFormatProvider, ByVal format As String) As ILogger

    ''' <summary>
    ''' Log a message and add extended properties
    ''' </summary>
    ''' <param name="properties">A dictionary of other context properties, that will be logged.</param>
    ''' <returns></returns>
    ''' <remarks>Be careful using extended property extensively that leads in a greater io load 
    ''' especially by using log files.</remarks>
    Function WithExtendedProperties(ByVal properties As Dictionary(Of String, Object)) As ILogger

#End Region

#Region "Verbs"

    ''' <summary>
    ''' Final verb of a critical log message.
    ''' </summary>
    ''' <param name="message">One or more critical messages</param>
    ''' <remarks>A critical log finally leads into an abort of program execution. 
    ''' If more than one parameter are specified you must have call <see cref="WithFormat">WithFormat</see> prior.</remarks>
    Sub Critical(ByVal ParamArray message As Object())

    ''' <summary>
    '''  Final verb of an error log message
    ''' </summary>
    ''' <param name="message">One or more error messages</param>
    ''' <remarks>An error log should be catchable exception. The program should abort a sub module but not itself.
    ''' If more than one parameter are specified you must have call <see cref="WithFormat">WithFormat</see> prior.</remarks>
    Sub [Error](ByVal ParamArray message As Object())

    ''' <summary>
    ''' final verb of a warn log message
    ''' </summary>
    ''' <param name="message">One or more warning messages</param>
    ''' <remarks>A warning log should be occur if an something is not as it should be e.g. expected data. 
    ''' The program should continue or just skip a small amount of code.
    ''' If more than one parameter are specified you must have call <see cref="WithFormat">WithFormat</see> prior.</remarks>
    Sub Warning(ByVal ParamArray message As Object())

    ''' <summary>
    ''' final verb of a information/notice message
    ''' </summary>
    ''' <remarks>A information log can be used to log a significate state of program execution e.g. successfully processed 1.234.567 records in 12.3 seconds.
    ''' If more than one parameter are specified you must have call <see cref="WithFormat">WithFormat</see> prior.</remarks>
    Sub Information(ByVal ParamArray message As Object())

    ''' <summary>
    ''' final verb of a verbose (almost everything) message
    ''' </summary>
    ''' <param name="message"></param>
    ''' <remarks>A verbose log can be used to log almost everthing in an execution path.
    ''' If more than one parameter are specified you must have call <see cref="WithFormat">WithFormat</see> prior.</remarks>
    Sub Verbose(ByVal ParamArray message As Object())

#End Region

End Interface
