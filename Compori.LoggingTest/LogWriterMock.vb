Imports Compori.Logging

Public Class LogWriterMock
    Implements ILogWriter

    Public Property LogEntry

    Public Sub Write(ByVal entry As Microsoft.Practices.EnterpriseLibrary.Logging.LogEntry) Implements Logging.ILogWriter.Write
        LogEntry = entry
    End Sub
End Class
