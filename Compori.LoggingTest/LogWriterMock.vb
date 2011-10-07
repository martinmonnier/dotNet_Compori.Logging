Imports Compori.Logging

Public Class LogWriterMock
    Implements IWriter

    <CLSCompliant(False)>
    Public Property LogEntry As IEntry

    <CLSCompliant(False)>
    Public Sub Write(ByVal entry As Logging.IEntry) Implements Logging.IWriter.Write
        LogEntry = entry
    End Sub
End Class
