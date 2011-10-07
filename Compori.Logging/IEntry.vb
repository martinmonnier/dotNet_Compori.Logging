''' <summary>
''' Log Entry Interface 
''' </summary>
''' <remarks>
''' Using an interface makes it much more easy to test the facade and allows to switch to a differnt logging enging in the future.
''' </remarks>
Public Interface IEntry

    ''' <summary>
    ''' Category name used to route the log entry to a one or more trace listeners.  
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Property Categories As ICollection(Of String)

    ''' <summary>
    ''' Dictionary of key/value pairs to record. 
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Property ExtendedProperties As IDictionary(Of String, Object)

    ''' <summary>
    ''' Log entry severity as a Severity enumeration. (Unspecified, Information, Warning or Error).  
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Property Severity As TraceEventType

    ''' <summary>
    ''' Message body to log. Value from ToString() method from message object.
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Property Message As String

    ''' <summary>
    ''' Importance of the log message. Only messages whose priority is between the minimum and maximum priorities (inclusive) will be processed.  
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Property Priority As Integer

    ' ActivityId Tracing activity id  
    ' ActivityIdString Tracing activity id as a string to support WMI Queries  
    ' AppDomainName The AppDomain in which the program is running  
    ' CategoriesStrings Category names used to route the log entry to a one or more trace listeners. This readonly property is available to support WMI queries  
    ' ErrorMessages Gets the error message with the LogEntry  
    ' EventId Event number or identifier.  
    ' LoggedSeverity Gets the string representation of the Severity enumeration.
    ' MachineName Name of the computer.  
    ' ManagedThreadName The name of the .NET thread.  
    ' ProcessId The Win32 process ID for the current running process.  
    ' ProcessName The name of the current running process.  
    ' RelatedActivityId Related activity id  
    ' TimeStamp Date and time of the log entry message.  
    ' TimeStampString Read-only property that returns the timeStamp formatted using the current culture.  
    ' Title Additional description of the log entry message.  
    ' Win32ThreadId The Win32 Thread ID for the current thread.  

End Interface
