Imports System
Imports System.Collections.Generic
Imports Microsoft.VisualStudio.TestTools.UnitTesting
Imports Compori.Logging

'''<summary>
''' Dies ist eine Testklasse für "LoggerImplTest" und soll alle LoggerImplTest Komponententests enthalten.
'''</summary>
<TestClass()> _
Public Class LoggerImplTest

    Private testContextInstance As TestContext

    '''<summary>
    '''Ruft den Testkontext auf, der Informationen
    '''über und Funktionalität für den aktuellen Testlauf bietet, oder legt diesen fest.
    '''</summary>
    Public Property TestContext() As TestContext
        Get
            Return testContextInstance
        End Get
        Set(ByVal value As TestContext)
            testContextInstance = Value
        End Set
    End Property

#Region "Zusätzliche Testattribute"
    '
    'Sie können beim Verfassen Ihrer Tests die folgenden zusätzlichen Attribute verwenden:
    '
    'Mit ClassInitialize führen Sie Code aus, bevor Sie den ersten Test in der Klasse ausführen.
    '<ClassInitialize()>  _
    'Public Shared Sub MyClassInitialize(ByVal testContext As TestContext)
    'End Sub
    '
    'Mit ClassCleanup führen Sie Code aus, nachdem alle Tests in einer Klasse ausgeführt wurden.
    '<ClassCleanup()>  _
    'Public Shared Sub MyClassCleanup()
    'End Sub
    '
    'Mit TestInitialize können Sie vor jedem einzelnen Test Code ausführen.
    '<TestInitialize()>  _
    'Public Sub MyTestInitialize()
    'End Sub
    '
    'Mit TestCleanup können Sie nach jedem einzelnen Test Code ausführen.
    '<TestCleanup()>  _
    'Public Sub MyTestCleanup()
    'End Sub
    '
#End Region

#Region "Test ILogger Verbs"

    '''<summary>
    ''' Test for "Critical"
    '''</summary>
    <TestMethod()> _
    Public Sub CriticalTest()
        Dim writer As LogWriterMock = New LogWriterMock()
        Dim target As ILogger = New LoggerImpl(writer)

        Dim message As String = "Critical Message"
        target.Critical(message)

        Assert.AreEqual(TraceEventType.Critical, writer.LogEntry.Severity)
        Assert.AreEqual(message, writer.LogEntry.Message)
    End Sub

    '''<summary>
    '''Ein Test für "Error"
    '''</summary>
    <TestMethod()> _
    Public Sub ErrorTest()
        Dim writer As LogWriterMock = New LogWriterMock()
        Dim target As ILogger = New LoggerImpl(writer)

        Dim message As String = "Error Message"
        target.Error(message)

        Assert.AreEqual(TraceEventType.Error, writer.LogEntry.Severity)
        Assert.AreEqual(message, writer.LogEntry.Message)
    End Sub

    '''<summary>
    '''Ein Test für "Information"
    '''</summary>
    <TestMethod()> _
    Public Sub InformationTest()
        Dim writer As LogWriterMock = New LogWriterMock()
        Dim target As ILogger = New LoggerImpl(writer)

        Dim message As String = "Information Message"
        target.Information(message)

        Assert.AreEqual(TraceEventType.Information, writer.LogEntry.Severity)
        Assert.AreEqual(message, writer.LogEntry.Message)
    End Sub

    '''<summary>
    '''Ein Test für "Verbose"
    '''</summary>
    <TestMethod()> _
    Public Sub VerboseTest()
        Dim writer As LogWriterMock = New LogWriterMock()
        Dim target As ILogger = New LoggerImpl(writer)

        Dim message As String = "Verbose Message"
        target.Verbose(message)

        Assert.AreEqual(TraceEventType.Verbose, writer.LogEntry.Severity)
        Assert.AreEqual(message, writer.LogEntry.Message)
    End Sub

    '''<summary>
    '''Ein Test für "Warning"
    '''</summary>
    <TestMethod()> _
    Public Sub WarningTest()
        Dim writer As LogWriterMock = New LogWriterMock()
        Dim target As ILogger = New LoggerImpl(writer)

        Dim message As String = "Warning Message"
        target.Warning(message)

        Assert.AreEqual(TraceEventType.Warning, writer.LogEntry.Severity)
        Assert.AreEqual(message, writer.LogEntry.Message)
    End Sub
#End Region

End Class
