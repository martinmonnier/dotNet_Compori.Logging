Imports Microsoft.Practices.EnterpriseLibrary.Logging

Public Interface ILogWriter

    ''' <summary>
    ''' Write a log entry
    ''' </summary>
    ''' <param name="entry"></param>
    ''' <remarks></remarks>
    Sub Write(ByVal entry As LogEntry)

End Interface
