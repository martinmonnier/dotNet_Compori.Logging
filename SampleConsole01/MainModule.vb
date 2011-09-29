Imports Compori.Logging

Module MainModule

    Sub Main()
        ' Log.Default
        Log.Default.WithPriority(Priority.Lowest).Verbose("Test")
    End Sub

End Module
