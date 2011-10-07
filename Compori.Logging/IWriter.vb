''' <summary>
''' Logwriter Interface 
''' </summary>
''' <remarks>
''' Using an interface makes it much more easy to test the facade and allows to switch to a differnt logging enging in the future.
''' For now the only thing a logwriter must do is to write a log entry.
''' </remarks>
Public Interface IWriter

    ''' <summary>
    ''' Write a log entry
    ''' </summary>
    ''' <param name="entry"></param>
    ''' <remarks></remarks>
    Sub Write(ByVal entry As IEntry)

    ''' <summary>
    ''' Create an entry
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Function CreateEntry() As IEntry
End Interface
